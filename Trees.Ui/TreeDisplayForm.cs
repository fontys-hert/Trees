using System.Data.SqlClient;

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
        Tree cedar;
        Tree birch;
        TreeRepository repo;

        public TreeDisplayForm()
        {
            InitializeComponent();
            repo = new TreeRepository(); 
            var trees = repo.RetrieveHeightFromDatabase();
            cedar = trees.cedar;
            birch = trees.birch;
            DisplayTreeHeights();
        }

        private void btnShrink_Click(object sender, EventArgs e)
        {
            cedar.Shrink();
            birch.Shrink();
            repo.SaveToDatabase(birch, cedar);
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
            repo.SaveToDatabase(birch, cedar);
            DisplayTreeHeights();
        }
    }
}