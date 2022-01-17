using System.Diagnostics.CodeAnalysis;

namespace SoftCircuits.MenuStatus
{
    public class SelectedMenuItemChangedArgs : EventArgs
    {
        /// <summary>
        /// The currently selected menu item. May be null when no menu item
        /// is selected.
        /// </summary>
        public ToolStripItem? SelectedMenuItem { get; set; }

        /// <summary>
        /// Returns true if <see cref="SelectedMenuItem"/> is not null. Otherwise,
        /// false is returned.
        /// </summary>
        [MemberNotNullWhen(true)]
        public bool HasSelectedItem => SelectedMenuItem != null;

        /// <summary>
        /// Constructs a new <see cref="SelectedMenuItemChangedArgs"/> instance.
        /// </summary>
        public SelectedMenuItemChangedArgs()
        {
            SelectedMenuItem = null;
        }

        /// <summary>
        /// Constructs a new <see cref="SelectedMenuItemChangedArgs"/> instance.
        /// </summary>
        public SelectedMenuItemChangedArgs(ToolStripItem? selectedMenuItem)
        {
            SelectedMenuItem = selectedMenuItem; ;
        }
    }
}
