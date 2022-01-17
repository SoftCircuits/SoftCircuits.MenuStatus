namespace TestMenuStatus
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            menuStatus1.AttachMenuStrip(menuStrip1);
            menuStatus1.AttachMenuStrip(menuStrip2);
        }

        private void btnAddSubmenu_Click(object sender, EventArgs e)
        {
            ToolStripItemCollection toolStripItems = submenusToolStripMenuItem.DropDownItems;
            toolStripItems.Add($"Submenu {toolStripItems.Count + 1}");
            menuStatus1.AttachMenuStrip(menuStrip2);
        }

        private void menuStatus1_SelectedMenuItemChanged(object sender, SoftCircuits.MenuStatus.SelectedMenuItemChangedArgs e)
        {
            lblStatus.Text = e.SelectedMenuItem?.Text ?? "Ready";
        }
    }
}
