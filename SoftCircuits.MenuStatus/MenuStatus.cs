using System.ComponentModel;
using System.Diagnostics;

namespace SoftCircuits.MenuStatus
{
    [Description("Simple component to provide events as menu items are selected.")]
    public partial class MenuStatus : Component
    {
        private readonly HashSet<MenuStrip> AttachedMenuStrips = new();
        private ToolStripItem? SelectedToolStripItem = null;

        [Description("Gets or sets whether menu item tool tips are disabled on MenuStrips attached to this component. Set to true when using the ToolTipText property to hold status text.")]
        [Category("Behavior")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(false)]
        public bool DisableMenuToolTips { get; set; } = false;

        [Description("Occurs when the selected menu item has changed.")]
        public event EventHandler<SelectedMenuItemChangedArgs>? SelectedMenuItemChanged;

        /// <summary>
        /// Initializes a new <see cref="MenuStatus"/> instance.
        /// </summary>
        public MenuStatus()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Initializes a new <see cref="MenuStatus"/> instance.
        /// </summary>
        public MenuStatus(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        #region Public methods

        /// <summary>
        /// Attaches the specified <see cref="MenuStrip"/> so that the <see cref="SelectedMenuItemChanged"/>
        /// event is fired whenever that menu's selected item changes.
        /// </summary>
        /// <param name="menuStrip">The <see cref="MenuStrip"/> to attach.</param>
        /// <remarks>
        /// <para>
        /// If new menu items are added to the <see cref="MenuStrip"/>, you will need to call this method
        /// again in order for the new menu items to be detected.
        /// </para>
        /// <para>
        /// If <paramref name="menuStrip"/> is already attached, it is detached and then
        /// reattached. So it is safe to call this method multiple times on the same
        /// <see cref="MenuStrip"/> without calling <see cref="DetachMenuStrip(MenuStrip)"/>.
        /// </para>
        /// </remarks>
        public void AttachMenuStrip(MenuStrip menuStrip)
        {
            // Detach this menu strip if already attached
            if (AttachedMenuStrips.Contains(menuStrip))
                DetachMenuStrip(menuStrip);
            // Attach menu strip
            Debug.Assert(!AttachedMenuStrips.Contains(menuStrip));
            AttachToolStrip(menuStrip);
            //menuStrip.MenuActivate += MenuStrip_MenuActivate;
            menuStrip.MenuDeactivate += MenuStrip_MenuDeactivate;
            AttachedMenuStrips.Add(menuStrip);
        }

        /// <summary>
        /// Detaches a <see cref="MenuStrip"/> that was previously attached using
        /// <see cref="AttachMenuStrip(MenuStrip)"/>.
        /// </summary>
        /// <param name="menuStrip">The <see cref="MenuStrip"/> to detach.</param>
        /// <remarks>
        /// This method simply returns if <paramref name="menuStrip"/> is not
        /// attached.
        /// </remarks>
        public void DetachMenuStrip(MenuStrip menuStrip)
        {
            // Only detach if menu strip is attached
            if (AttachedMenuStrips.Contains(menuStrip))
            {
                DetachToolStrip(menuStrip);
                //menuStrip.MenuActivate -= MenuStrip_MenuActivate;
                menuStrip.MenuDeactivate -= MenuStrip_MenuDeactivate;
                AttachedMenuStrips.Remove(menuStrip);
                Debug.Assert(!AttachedMenuStrips.Contains(menuStrip));
            }
        }

        /// <summary>
        /// Detaches all attached <see cref="MenuStrip"/>s.
        /// </summary>
        public void DetachAll()
        {
            // Detach all attached menu strips.
            List<MenuStrip> attachedMenuStrips = AttachedMenuStrips.ToList();
            foreach (MenuStrip menuStrip in attachedMenuStrips)
                DetachMenuStrip(menuStrip);
            Debug.Assert(AttachedMenuStrips.Count == 0);
        }

        /// <summary>
        /// Gets the currently selected menu item. Returns null if no menu item
        /// is currently selected.
        /// </summary>
        public ToolStripItem? SelectedMenuItem => SelectedToolStripItem;

        /// <summary>
        /// Raises the <see cref="SelectedMenuItemChanged"/> event.
        /// </summary>
        public virtual void OnSelectedMenuItemChanged()
        {
            SelectedMenuItemChangedArgs args = new(SelectedToolStripItem);
            SelectedMenuItemChanged?.Invoke(this, args);
        }

        #endregion

        #region Helper methods

        /// <summary>
        /// Sets event handlers and properties of a ToolStrip in order to respond
        /// to the selected menu item changing.
        /// </summary>
        /// <param name="toolStrip"></param>
        private void AttachToolStrip(ToolStrip toolStrip)
        {
            if (DisableMenuToolTips)
                toolStrip.ShowItemToolTips = false;
            toolStrip.KeyUp += ToolStrip_KeyUp;
            foreach (ToolStripItem toolStripItem in toolStrip.Items)
            {
                if (DisableMenuToolTips)
                    toolStripItem.AutoToolTip = false;
                toolStripItem.MouseEnter += ToolStripItem_MouseEnter;
                toolStripItem.MouseLeave += ToolStripItem_MouseLeave;
                if (toolStripItem is ToolStripDropDownItem dropDownItem)
                    AttachToolStrip(dropDownItem.DropDown);
            }
        }

        /// <summary>
        /// Undoes what is done by AttachToolStrip().
        /// </summary>
        private void DetachToolStrip(ToolStrip toolStrip)
        {
            if (DisableMenuToolTips)
                toolStrip.ShowItemToolTips = true;
            toolStrip.KeyUp -= ToolStrip_KeyUp;
            foreach (ToolStripItem toolStripItem in toolStrip.Items)
            {
                if (DisableMenuToolTips)
                    toolStripItem.AutoToolTip = true;
                toolStripItem.MouseEnter -= ToolStripItem_MouseEnter;
                toolStripItem.MouseLeave -= ToolStripItem_MouseLeave;
                if (toolStripItem is ToolStripDropDownItem dropDownItem)
                    DetachToolStrip(dropDownItem.DropDown);
            }
        }

        /// <summary>
        /// Updates <see cref="SelectedToolStripItem"/> and fires the
        /// <see cref="SelectedMenuItemChanged"/> event if the selected item has changed.
        /// </summary>
        /// <param name="item"></param>
        private void SetSelectedMenuItem(ToolStripItem? item)
        {
            if (!ReferenceEquals(item, SelectedToolStripItem))
            {
                SelectedToolStripItem = item;
                OnSelectedMenuItemChanged();
            }
        }

        #endregion

        #region Event handlers

        ////
        //private void MenuStrip_MenuActivate(object? sender, EventArgs e)
        //{
        //}

        //
        private void MenuStrip_MenuDeactivate(object? sender, EventArgs e)
        {
            SetSelectedMenuItem(null);
        }

        //
        private void ToolStripItem_MouseEnter(object? sender, EventArgs e)
        {
            if (sender is ToolStripMenuItem menuItem && menuItem.Selected)
                SetSelectedMenuItem(menuItem);
        }

        //
        private void ToolStripItem_MouseLeave(object? sender, EventArgs e)
        {
            SetSelectedMenuItem(null);
        }

        //
        private void ToolStrip_KeyUp(object? sender, KeyEventArgs e)
        {
            if (sender is ToolStripDropDownMenu dropDownMenu)
            {
                SetSelectedMenuItem(dropDownMenu.Items.OfType<ToolStripMenuItem>()
                    .Where(m => m.Selected)
                    .FirstOrDefault());
            }
        }

        #endregion

    }
}
