namespace Trees.Ui
{
    /*    - We want to implement a simulation for tree growth and shrinking.
    - Each tree has a current height and
    - can become higher (by growing) or 
    - lower (by shrinking). 
    - Every tree also has a maximum height, for example, a Birch has a much higher maximum height than a cedar tree. 
    - The application should display some information about a tree.
    - There are two buttons to modify the height of a tree.
    - Clicking one of the buttons should result in updating some data in the tree-object and 
    - showing information about the tree in the label.   */

    public partial class TreeDisplayForm : Form
    {
        Tree cedar = new Tree(30, 55);
        Tree birch = new Tree(100, 100);

        public TreeDisplayForm()
        {
            InitializeComponent();
            DisplayTreeHeights();
        }

        private void btnShrink_Click(object sender, EventArgs e)
        {
            cedar.Shrink();
            birch.Shrink();
            DisplayTreeHeights();
        }
      
        private void DisplayTreeHeights()
        {
            lblResult.Text = cedar.HeightCurrent.ToString();
            lblResult2.Text = birch.HeightCurrent.ToString();
        }

        private void btnGrow_Click(object sender, EventArgs e)
        {
            cedar.Grow();
            birch.Grow();
            DisplayTreeHeights();
        }
    }
}