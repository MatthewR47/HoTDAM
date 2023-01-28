using FlyKnockdown.Controller;
using FlyKnockdown.Model;
using System.Windows.Forms;
using System.Windows.Forms.Design;

namespace FlyKnockdown.View
{
    public partial class MainView : Form
    {
        List<ActivityMonitor> monitors;
        string multiSelectGroupName;

        public MainView()
        {
            monitors = new List<ActivityMonitor>();
            InitializeComponent();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            groupDesignationGroupBox.Enabled = true;
            groupDesignationGroupBox.Text = monitorListBox.Text + " Group Designation";
            updateCells();
        }

        private void groupDefineBtn_Click(object sender, EventArgs e)
        {
            if (groupDefineBtn.Text.Equals("Start Multi-Select Group Definition"))
            {
                groupDefineBtn.Text = "Stop Multi-Select Group Definition";
                monitorGroupBox.Enabled = false;           
                menuStrip1.Enabled = false;
                copyGroupDefinitionsBtn.Enabled = false;

                string groupName = "Default Group Name";
                showInputDialog(ref groupName);

                multiSelectGroupName = groupName;
            }
            else
            {
                groupDefineBtn.Text = "Start Multi-Select Group Definition";
                monitorGroupBox.Enabled = true;
                menuStrip1.Enabled = true;
                copyGroupDefinitionsBtn.Enabled = true;
                multiSelectGroupName = null;
            }
        }

        private void loadDataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FileController fileController = new FileController();

            try
            {
                List<ActivityMonitor> tempMonitors = fileController.loadFiles();

                if (tempMonitors.Count > 0)
                {
                    monitorGroupBox.Enabled = true;
                    monitors = tempMonitors;
                }

                monitorListBox.DataSource = monitors;
            }
            catch (IOException) 
            {
                showMessageDialog("There was an issue opening one or more of the " +
                                  "files selected (this is often caused by the file " +
                                  "being open in another program).");
            }
            catch (Exception) 
            {
                showMessageDialog("There was an issue with one or more of the files" +
                                  " you selected.");
            }
        }

        private static DialogResult showInputDialog(ref string input)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form inputBox = new Form();
            inputBox.StartPosition = FormStartPosition.CenterScreen;

            inputBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            inputBox.ClientSize = size;
            inputBox.Text = "Name";

            System.Windows.Forms.TextBox textBox = new TextBox();
            textBox.Size = new System.Drawing.Size(size.Width - 10, 23);
            textBox.Location = new System.Drawing.Point(5, 5);
            textBox.Text = input;
            inputBox.Controls.Add(textBox);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Location = new System.Drawing.Point(size.Width - 80 - 80, 39);
            inputBox.Controls.Add(okButton);

            inputBox.AcceptButton = okButton;

            DialogResult result = inputBox.ShowDialog();
            input = textBox.Text;
            return result;
        }

        private static DialogResult showMessageDialog(string message)
        {
            System.Drawing.Size size = new System.Drawing.Size(200, 70);
            Form messageBox = new Form();
            messageBox.StartPosition = FormStartPosition.CenterScreen;
            messageBox.AutoSize = true;

            messageBox.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            messageBox.ClientSize = size;
            messageBox.Text = "Name";

            System.Windows.Forms.Label label = new Label();
            label.AutoSize = true;
            label.Location = new System.Drawing.Point(5, 5);
            label.Text = message;
            messageBox.Controls.Add(label);

            Button okButton = new Button();
            okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            okButton.Name = "okButton";
            okButton.Size = new System.Drawing.Size(75, 23);
            okButton.Text = "&OK";
            okButton.Left = (messageBox.Width - okButton.Width) / 2;
            okButton.Top = (39);
            messageBox.Controls.Add(okButton);

            messageBox.AcceptButton = okButton;

            DialogResult result = messageBox.ShowDialog();
            return result;
        }

        private void updateCells()
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;

            cellOne.Text = currentMonitor.getGroup(0);
            cellTwo.Text = currentMonitor.getGroup(1);
            cellThree.Text = currentMonitor.getGroup(2);
            cellFour.Text = currentMonitor.getGroup(3);
            cellFive.Text = currentMonitor.getGroup(4);
            cellSix.Text = currentMonitor.getGroup(5);
            cellSeven.Text = currentMonitor.getGroup(6);
            cellEight.Text = currentMonitor.getGroup(7);
            cellNine.Text = currentMonitor.getGroup(8);
            cellTen.Text = currentMonitor.getGroup(9);
            cellEleven.Text = currentMonitor.getGroup(10);
            cellTwelve.Text = currentMonitor.getGroup(11);
            cellThirteen.Text = currentMonitor.getGroup(12);
            cellFourteen.Text = currentMonitor.getGroup(13);
            cellFifteen.Text = currentMonitor.getGroup(14);
            cellSixteen.Text = currentMonitor.getGroup(15);
            cellSeventeen.Text = currentMonitor.getGroup(16);
            cellEighteen.Text = currentMonitor.getGroup(17);
            cellNineteen.Text = currentMonitor.getGroup(18);
            cellTwenty.Text = currentMonitor.getGroup(19);
            cellTwentyone.Text = currentMonitor.getGroup(20);
            cellTwentytwo.Text = currentMonitor.getGroup(21);
            cellTwentythree.Text = currentMonitor.getGroup(22);
            cellTwentyfour.Text = currentMonitor.getGroup(23);
            cellTwentyfive.Text = currentMonitor.getGroup(24);
            cellTwentysix.Text = currentMonitor.getGroup(25);
            cellTwentyseven.Text = currentMonitor.getGroup(26);
            cellTwentyeight.Text = currentMonitor.getGroup(27);
            cellTwentynine.Text = currentMonitor.getGroup(28);
            cellThirty.Text = currentMonitor.getGroup(29);
            cellThirtyone.Text = currentMonitor.getGroup(30);
            cellThirtytwo.Text = currentMonitor.getGroup(31);
        }

        private void cellOne_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellOne.Text = groupName;
            }
            else
            {
                groupName= multiSelectGroupName;
            }
            currentMonitor.setGroup(0, groupName);
            updateCells();
        }

        private void cellTwo_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwo.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(1, groupName);
            updateCells();
        }

        private void cellThree_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellThree.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(2, groupName);
            updateCells();
        }

        private void cellFour_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellFour.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(3, groupName);
            updateCells();
        }

        private void cellFive_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellFive.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(4, groupName);
            updateCells();
        }

        private void cellSix_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellSix.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(5, groupName);
            updateCells();
        }

        private void cellSeven_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellSeven.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(6, groupName);
            updateCells();
        }

        private void cellEight_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellEight.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(7, groupName);
            updateCells();
        }

        private void cellNine_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellNine.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(8, groupName);
            updateCells();
        }

        private void cellTen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(9, groupName);
            updateCells();
        }

        private void cellEleven_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellEleven.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(10, groupName);
            updateCells();
        }

        private void cellTwelve_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwelve.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(11, groupName);
            updateCells();
        }

        private void cellThirteen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellThirteen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(12, groupName);
            updateCells();
        }

        private void cellFourteen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellFourteen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(13, groupName);
            updateCells();
        }

        private void cellFifteen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellFifteen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(14, groupName);
            updateCells();
        }

        private void cellSixteen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellSixteen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(15, groupName);
            updateCells();
        }

        private void cellSeventeen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellSeventeen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(16, groupName);
            updateCells();
        }

        private void cellEighteen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellEighteen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(17, groupName);
            updateCells();
        }

        private void cellNineteen_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellNineteen.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(18, groupName);
            updateCells();
        }

        private void cellTwenty_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwenty.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(19, groupName);
            updateCells();
        }

        private void cellTwentyone_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentyone.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(20, groupName);
            updateCells();
        }

        private void cellTwentytwo_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentytwo.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(21, groupName);
            updateCells();
        }

        private void cellTwentythree_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentythree.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(22, groupName);
            updateCells();
        }

        private void cellTwentyfour_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentyfour.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(23, groupName);
            updateCells();
        }

        private void cellTwentyfive_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentyfive.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(24, groupName);
            updateCells();
        }

        private void cellTwentysix_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentysix.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(25, groupName);
            updateCells();
        }

        private void cellTwentyseven_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentyseven.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(26, groupName);
            updateCells();
        }

        private void cellTwentyeight_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentyeight.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(27, groupName);
            updateCells();
        }

        private void cellTwentynine_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellTwentynine.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(28, groupName);
            updateCells();
        }

        private void cellThirty_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellThirty.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(29, groupName);
            updateCells();
        }

        private void cellThirtyone_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellThirtyone.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(30, groupName);
            updateCells();
        }

        private void cellThirtytwo_Click(object sender, EventArgs e)
        {
            ActivityMonitor currentMonitor = (ActivityMonitor)monitorListBox.SelectedItem;
            string groupName = "Default Group Name";
            if (multiSelectGroupName == null)
            {
                showInputDialog(ref groupName);
                cellThirtytwo.Text = groupName;
            }
            else
            {
                groupName = multiSelectGroupName;
            }
            currentMonitor.setGroup(31, groupName);
            updateCells();
        }
    }
}