using System.ComponentModel;

namespace SoftCircuits.MenuStatus
{
    public partial class MenuStatus : Component
    {
        private readonly HashSet<MenuStrip> AttachedMenuStrips = new();
        private ToolStripItem? SelectedMenuItem = null;

        [Description("Gets or sets whether menu item tool tips are disabled on MenuStrips attached to this component. Allows you to use the ToolTipText property to hold status text.")]
        [Category("Behavior")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [DefaultValue(false)]
        public bool DisableMenuToolTips { get; set; } = false;

        [Description("Occurs when the selected menu item has changed.")]
        public event EventHandler<SelectedMenuItemChangedArgs>? SelectedMenuItemChanged;

        public MenuStatus()
        {
            InitializeComponent();
        }

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
            if (AttachedMenuStrips.Contains(menuStrip))
                DetachMenuStrip(menuStrip);

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
        /// Safely handles attempts to detach a <see cref="MenuStrip"/> that was
        /// never attached.
        /// </remarks>
        public void DetachMenuStrip(MenuStrip menuStrip)
        {
            if (AttachedMenuStrips.Contains(menuStrip))
            {
                DetachToolStrip(menuStrip);
                //menuStrip.MenuActivate -= MenuStrip_MenuActivate;
                menuStrip.MenuDeactivate -= MenuStrip_MenuDeactivate;
                AttachedMenuStrips.Remove(menuStrip);
            }
        }

        /// <summary>
        /// Detaches all attached <see cref="MenuStrip"/>s.
        /// </summary>
        public void DetachAll()
        {
            List<MenuStrip> attachedMenuStrips = AttachedMenuStrips.ToList();
            foreach (MenuStrip menuStrip in attachedMenuStrips)
                DetachMenuStrip(menuStrip);
        }

        /// <summary>
        /// Raises the <see cref="SelectedMenuItemChanged"/> event.
        /// </summary>
        public virtual void OnSelectedMenuItemChanged()
        {
            SelectedMenuItemChangedArgs args = new()
            {
                SelectedMenuItem = SelectedMenuItem
            };
            SelectedMenuItemChanged?.Invoke(this, args);
        }

        #endregion

        #region Helper methods

        // Sets event handlers and properties of a ToolStrip in order to respond
        // to the selected menu item changing.
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

        // Undoes what is done by AttachToolStrip().
        private void DetachToolStrip(ToolStrip toolStrip)
        {
            toolStrip.ShowItemToolTips = true;
            toolStrip.KeyUp -= ToolStrip_KeyUp;
            foreach (ToolStripItem toolStripItem in toolStrip.Items)
            {
                toolStripItem.AutoToolTip = true;
                toolStripItem.MouseEnter -= ToolStripItem_MouseEnter;
                toolStripItem.MouseLeave -= ToolStripItem_MouseLeave;
                if (toolStripItem is ToolStripDropDownItem dropDownItem)
                    DetachToolStrip(dropDownItem.DropDown);
            }
        }

        // Updates the currently selected menu item.
        private void SetSelectedMenuItem(ToolStripItem? item)
        {
            if (!ReferenceEquals(item, SelectedMenuItem))
            {
                SelectedMenuItem = item;
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
                ToolStripMenuItem? menuItem = dropDownMenu.Items.OfType<ToolStripMenuItem>()
                    .Where(m => m.Selected)
                    .FirstOrDefault();
                SetSelectedMenuItem(menuItem);
            }
        }

        #endregion

    }
}
