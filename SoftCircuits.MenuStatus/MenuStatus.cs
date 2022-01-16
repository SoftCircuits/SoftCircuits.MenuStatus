using System.ComponentModel;

namespace SoftCircuits.MenuStatus
{
    public partial class MenuStatus : Component
    {
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
        /// <param name="menuStrip"></param>
        public void AttachMenuStrip(MenuStrip menuStrip)
        {
            DoAttachMenuStrip(menuStrip);
            menuStrip.MenuActivate += MenuStrip_MenuActivate;
            menuStrip.MenuDeactivate += MenuStrip_MenuDeactivate;
        }

        /// <summary>
        /// Detaches a <see cref="MenuStrip"/> that was previously attached using
        /// <see cref="AttachMenuStrip(MenuStrip)"/>.
        /// </summary>
        /// <param name="menuStrip"></param>
        public void DetachMenuStrip(MenuStrip menuStrip)
        {
            DoDetachMenuStrip(menuStrip);
            menuStrip.MenuActivate -= MenuStrip_MenuActivate;
            menuStrip.MenuDeactivate -= MenuStrip_MenuDeactivate;
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
        private void DoAttachMenuStrip(ToolStrip toolStrip)
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
                    DoAttachMenuStrip(dropDownItem.DropDown);
            }
        }

        // Undoes what is done by DoAttachMenuStrip.
        private void DoDetachMenuStrip(ToolStrip toolStrip)
        {
            // TODO: Is there a check to see if this ToolStrip was attached?

            toolStrip.ShowItemToolTips = true;
            toolStrip.KeyUp -= ToolStrip_KeyUp;
            foreach (ToolStripItem toolStripItem in toolStrip.Items)
            {
                toolStripItem.AutoToolTip = true;
                toolStripItem.MouseEnter -= ToolStripItem_MouseEnter;
                toolStripItem.MouseLeave -= ToolStripItem_MouseLeave;
                if (toolStripItem is ToolStripDropDownItem dropDownItem)
                    DoDetachMenuStrip(dropDownItem.DropDown);
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

        //
        private void MenuStrip_MenuActivate(object? sender, EventArgs e)
        {
            //
        }

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
