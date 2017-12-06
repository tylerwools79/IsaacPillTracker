using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

/*
Have you ever been in the middle of a run and you see a pill in the shop or across some spikes that you know you've seen in this run, but you can't remember if it was a Health Up or a <insert marginally less useful pill here>? I know I have several times, and it bothered me enough that I've written an app in C# to track what pills in what orientation do what for your current run.
*/
//possible UPDATES:Curse of the lost tracker, curse of the unknown tracker, Transformations sheet
namespace Isaac_Pill_Tracker
{
    public partial class PillTracker : Form
    {
        private string[] rebirth = { "48 Hour Energy", "Amnesia", "Bad Gas", "Bad Trip", "Balls of Steel", "Bombs are Key", "Explosive Diarrhea", "Full Health", "Health Down", "Health Up", "Hematemesis", "I Can See Forever", "I Found Pills", "Lemon Party", "Luck Down", "Luck Up", "Paralysis", "Pheromones", "Puberty", "Pretty Fly", "Range Down", "Range Up", "R U a Wizard?", "Speed Down", "Speed Up", "Tears Down", "Tears Up", "Telepills" };
        private string[] afterbirth = { "48 Hour Energy", "Amnesia", "Bad Gas", "Bad Trip", "Balls of Steel", "Bombs are Key", "Explosive Diarrhea", "Full Health", "Health Down", "Health Up", "Hematemesis", "I Can See Forever", "I Found Pills", "Lemon Party", "Luck Down", "Luck Up", "Paralysis", "Pheromones", "Puberty", "Pretty Fly", "Range Down", "Range Up", "R U a Wizard?", "Speed Down", "Speed Up", "Tears Down", "Tears Up", "Telepills", "Addicted", "Friends Till The End", "Infested!", "Infested?", "One Makes You Small", "One Makes You Larger", "Percs", "Power Pill", "Re-Lax", "Retro Vision", "???" };
        private string[] afterbirthPlus = { "48 Hour Energy", "Amnesia", "Bad Gas", "Bad Trip", "Balls of Steel", "Bombs are Key", "Explosive Diarrhea", "Full Health", "Health Down", "Health Up", "Hematemesis", "I Can See Forever", "I Found Pills", "Lemon Party", "Luck Down", "Luck Up", "Paralysis", "Pheromones", "Puberty", "Pretty Fly", "Range Down", "Range Up", "R U a Wizard?", "Speed Down", "Speed Up", "Tears Down", "Tears Up", "Telepills", "Addicted", "Friends Till The End", "Infested!", "Infested?", "One Makes You Small", "One Makes You Larger", "Percs", "Power Pill", "Re-Lax", "Retro Vision", "???", "Feels Like I'm Walking On Sunshine!", "Gulp!", "Horf!", "I'm Drowsy", "I'm Excited!!!", "Something's Wrong...", "Vurp!", "X-Lax" };
        private int resetVal = -1;
        private int rows = 0;
        private bool clearClicked = false;
        public PillTracker()
        {            
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //textBox1.Text = pillSelectBox.SelectedItem.ToString();
            //clearBoxes();
            //Rebirth_Click(sender, e);//this is causing the error
            //addBtn.Enabled = true;
            rows = 0;
            clearBoxes();
            for (int i = 0; i < rebirth.Length; i++)
            {
                EffectsBx.Items.Add(rebirth[i]);
            }
            resetVal = 0;
            //this.Pills.BorderStyle = BorderStyle.None; //this is causing an error and/or not working when running from the .exe
        }

        private void EffectsBx1_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        
        private void validateInput()
        {
            if (orientationBx.SelectedItem == null || EffectsBx.SelectedItem == null)
                return;
            if (pillSelectBox.SelectedItem != null && orientationBx.SelectedItem.ToString() != "" && EffectsBx.SelectedItem.ToString() != ""&&rows<=13)
                addBtn.Enabled = true;
            else
                addBtn.Enabled = false;
            RemoveDups();
            
        }

        private void getPreview()
        {
            if (addBtn.Enabled == true)
            {
                int pill = pillSelectBox.SelectedIndex;
                string orientation = (string)orientationBx.SelectedItem;
                switch (orientation)
                {
                    case "Normal":
                        previewBx.Image = imageList1.Images[pill];
                        break;
                    case "Reverse":
                        previewBx.Image = imageListR.Images[pill];
                        break;
                    case "Horizontal":
                        previewBx.Image = imageListH.Images[pill];
                        break;
                    case "Vertical":
                        previewBx.Image = imageListV.Images[pill];
                        break;
                    default:
                        break;
                }
            }
        }

        private void clearBoxes()
        {
            addBtn.Enabled = false;
            phdChkBx.Checked = false;
            pillSelectBox.Text = "";
            EffectsBx.Text = "";
            orientationBx.Text = "";
            pillSelectBox.Enabled = false;
            previewBx.Image = emptyBx.Image;
        }

        private void Rebirth_Click(object sender, EventArgs e)
        {
            clearClicked = true;
            clearBoxes();
            rows = 0;
            
            for (int i = 0; i < Pills.RowCount-1; i++)
            {
                Pills.Rows.Clear();
            }
            if(PillTracker.ActiveForm != null)
                PillTracker.ActiveForm.BackgroundImage = rebirthPx.BackgroundImage;
            EffectsBx.Items.Clear();
            
            for (int i = 0; i < rebirth.Length; i++)
            {
                EffectsBx.Items.Add(rebirth[i]);

            }
            resetVal = 0;
            clearClicked = false;
        }

        private void Afterbirth_Click(object sender, EventArgs e)
        {
            clearClicked = true;
            clearBoxes();
            rows = 0;
            for (int i = 0; i < Pills.RowCount-1; i++)
            {
                Pills.Rows.Clear();
            }
            if (PillTracker.ActiveForm != null)
                PillTracker.ActiveForm.BackgroundImage = afterbirthPx.BackgroundImage;
            EffectsBx.Items.Clear();
            
            
            for (int i = 0; i < afterbirth.Length; i++)
            {
                EffectsBx.Items.Add(afterbirth[i]);

            }
            resetVal = 1;
            clearClicked = false;
        }

        private void AfterbirthPlus_Click(object sender, EventArgs e)
        {
            clearClicked = true;
            clearBoxes();
            rows = 0;
            for (int i = 0; i < Pills.RowCount-1; i++)
            {
                Pills.Rows.Clear();
            }
            if (PillTracker.ActiveForm != null)
                PillTracker.ActiveForm.BackgroundImage = afterbirthplusPx.BackgroundImage;
            EffectsBx.Items.Clear();
            
            for (int i = 0; i < afterbirthPlus.Length; i++)
            {
                EffectsBx.Items.Add(afterbirthPlus[i]);

            }
            resetVal = 2;
            clearClicked = false;
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            switch (resetVal)
            {
                case 0:
                    Rebirth_Click(sender, e);
                    break;
                case 1:
                    Afterbirth_Click(sender, e);
                    break;
                case 2:
                    AfterbirthPlus_Click(sender, e);
                    break;
            }
            
        }

        private void pillSelectBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.DrawFocusRectangle();
            if (e.Index > -1 && imageList1.Images.Count >= e.Index)
            {
                //if (orientationBx.SelectedText == "Normal")
                e.Graphics.DrawImage(imageList1.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
                //else if (orientationBx.SelectedText == "Vertical")
                //    e.Graphics.DrawImage(imageListV.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
                //else if (orientationBx.SelectedText == "Reverse")
                //    e.Graphics.DrawImage(imageListR.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
                //else if (orientationBx.SelectedText == "Horizontal")
                //    e.Graphics.DrawImage(imageListH.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
                //else
                //    e.Graphics.DrawImage(imageList1.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
            }
        }

        private void addBtn_Click(object sender, EventArgs e)
        {

            int pill = pillSelectBox.SelectedIndex;
            string effect = (string)EffectsBx.SelectedItem;
            string orientation = (string)orientationBx.SelectedItem;


            if (orientation == "Normal")
            {
               // Pills.Rows.Add(blueBlue.Image, effect, orientation, pill);
                Pills.Rows.Add(imageList1.Images[pill], effect, orientation,pill);
            }
            else if (orientation == "Vertical")
            {
               // Pills.Rows.Add(pictureBox1.Image, effect, orientation, pill);
                Pills.Rows.Add(imageListV.Images[pill], effect, orientation,pill);
            }
            else if (orientation == "Reverse")
            {
                Pills.Rows.Add(imageListR.Images[pill], effect, orientation,pill);
            }
            else if (orientation == "Horizontal")
            {
                Pills.Rows.Add(imageListH.Images[pill], effect, orientation,pill);
            }
            else
                Pills.Rows.Add(imageList1.Images[pill], effect, orientation,pill);
            addBtn.Enabled = false;
            previewBx.Image = emptyBx.Image;
            return;

        }

        //this function removes effects so that you can't have duplicate effects.
        //it will also disable the add button if the pill orientation and color already exists
        private void RemoveDups()
        {
            if (rows > 0)
            {
                int pill = pillSelectBox.SelectedIndex;
                //System.Drawing.Image pill = imageList1.Images[pillSelectBox.SelectedIndex];//why aren't I basing this off of the selected index?
                string effect = (string)EffectsBx.SelectedItem;
                string orientation = (string)orientationBx.SelectedItem;
                for (int i = 0; i < Pills.Rows.Count-1; i++)
                {
                    if (Pills.Rows[i].Cells[3].Value.ToString() == pill.ToString() && Pills.Rows[i].Cells[2].Value.ToString() == orientation)
                        addBtn.Enabled = false;
                }
            }
            getPreview();

        }

        private void pillSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateInput();
        }

        private void orientationBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (orientationBx.SelectedItem.ToString() != "")
                pillSelectBox.Enabled = true;
            else
                pillSelectBox.Enabled = false;
            validateInput();
        }

        private void EffectsBx1_SelectedValueChanged(object sender, EventArgs e)
        {
            validateInput();
        }

        private void Pills_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {

            if (!clearClicked)
            {
                rows++;
                Pills.CurrentCell = Pills.Rows[rows].Cells[0];
            }
            clearClicked = false;
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "\t\tCopyright Tyler J Woolstenhulme\n\t\tpublished November 17th, 2017\n\t\t\tall rights reserved\n\tI DO NOT OWN THE IMAGES USED IN THIS APP";
            msg += "\n\n======================================================\n\tContact me with any bugs or ideas you'd like to see added: \n\t\t>/u/tylerwools79 on Reddit\n\t\t>burneremail2142@gmail.com\n======================================================";
            msg += "\n\ncredit for rebirth background: https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwid-57KisLXAhVBH2MKHfACA_oQjRwIBw&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3D1bm3QtT6cdY&psig=AOvVaw02A_SGxPKXqRHkw3ZrVqQo&ust=1510886933908357";
            msg += "\n\ncredit for afterbirth background:  https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwjox8rTicLXAhUN1WMKHUO6COYQjRwIBw&url=https%3A%2F%2Fwall.alphacoders.com%2Fbig.php%3Fi%3D807117%26lang%3DSwedish&psig=AOvVaw3ydxu-AQZGMKto4JyNgYM8&ust=1510886684348841";
            msg += "\n\ncredit for afterbirth+ background: https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwiQ5MGzisLXAhVI02MKHfWkCfwQjRwIBw&url=http%3A%2F%2Fspaceone2.tistory.com%2F4&psig=AOvVaw1WvvrCZ3oxzNRXVPGsfUCA&ust=1510886883293161";
            msg += "\n\ncredit for pill pictures: https://bindingofisaacrebirth.gamepedia.com/Pills";
            MessageBox.Show(msg);
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Hello! Thank you for using this Binding Of Isaac Pill Tracking App!\nThere are a few basic steps to using this tool...\n\n";
            msg += "1.First choose which version of the game you're playing using the buttons in the box labelled \"DLC\"\n";
            msg += "2.Second choose the pill, the effect, and the orientation from the selection boxes.\n";
            msg += "3.Confirm that the pill looks correct in the pill preview box and then click the add button, this will add the pill to the table.\n";
            msg += "\nMake sure you check the PHD/Virgo box when you pick up either of those items, \nthis will convert the pills in the table and remove the bad pills from the effects selection box.\n";
            msg += "Unchecking the box will add the bad pill effects back to the selection box, but it will not change the pills in the table back.";

            msg += "When you die, just click the clear button to reset the pills and effects. Have fun!";
            msg += "";
            MessageBox.Show(msg);
        }

        /// <summary>
        /// Adds and removes the bad pills from the selection box. changes names in the table to positive effects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phdChkBx_CheckedChanged(object sender, EventArgs e)
        {//make it so it doen't call this if it's cleared or a different thing. change event listener to mouse down probably
            string[] badPills = { "Bad Trip", "Amnesia", "Health Down", "Range Down", "Luck Down", "Tears Down", "Speed Down", "???", "Addicted", "I'm Excited!!!", "Paralysis", "Retro Vision", "R U A Wizard?", "X-Lax" };
            if (phdChkBx.Checked)
            {
                for (int i = 0; i < Pills.Rows.Count - 1; i++)
                {

                    switch (Pills.Rows[i].Cells[1].Value.ToString())
                    {
                        case "Bad Trip":
                            Pills.Rows[i].Cells[1].Value = "Balls of Steel";//becomes balls of steel
                            break;
                        case "Amnesia":
                            Pills.Rows[i].Cells[1].Value = "I Can See Forever"; //becomes I can see forever
                            break;
                        case "Health Down":
                            Pills.Rows[i].Cells[1].Value = "Health Up";
                            break;
                        case "Range Down":
                            Pills.Rows[i].Cells[1].Value = "Range Up";
                            break;
                        case "Luck Down":
                            Pills.Rows[i].Cells[1].Value = "Luck Up";
                            break;
                        case "Speed Down":
                            Pills.Rows[i].Cells[1].Value = "Speed Up";
                            break;
                        case "Tears Down":
                            Pills.Rows[i].Cells[1].Value = "Tears Up";
                            break;
                        case "???":
                            if (resetVal == 2)
                                Pills.Rows[i].Cells[1].Value = "Telepills"; //becomes telepills
                            break;
                        case "Addicted":
                            if (resetVal == 2)
                                Pills.Rows[i].Cells[1].Value = "Percs";//becomes Percs!
                            break;
                        case "I'm Excited!!!":
                            if (resetVal == 2)
                                Pills.Rows[i].Cells[1].Value = "I'm Drowsy";//becomes I'm drowsy
                            break;
                        case "Paralysis":
                            if (resetVal == 2)
                                Pills.Rows[i].Cells[1].Value = "Pheromones";//becomes pheromones
                            break;
                        case "Retro Vision":
                            if (resetVal == 2)
                                Pills.Rows[i].Cells[1].Value = "I Can See Forever";//becomes I can see forever
                            break;
                        case "R U A Wizard?":
                            if (resetVal == 2)
                                Pills.Rows[i].Cells[1].Value = "Power Pill";//becomes power pill
                            break;
                        case "X-Lax":
                            if (resetVal == 2)
                                Pills.Rows[i].Cells[1].Value = "Something's Wrong...";//becomes somethings wrong
                            break;
                        default:
                            break;

                    }

                }
                for (int i = 0; i < EffectsBx.Items.Count; ++i)
                {
                    switch (EffectsBx.Items[i].ToString())
                    {
                        case "Bad Trip":
                            EffectsBx.Items.Remove("Bad Trip");//becomes balls of steel
                            i--;
                            break;
                        case "Amnesia":
                            EffectsBx.Items.Remove("Amnesia"); //becomes I can see forever
                            i--;
                            break;
                        case "Health Down":
                            EffectsBx.Items.Remove("Health Down");
                            i--;
                            break;
                        case "Range Down":
                            EffectsBx.Items.Remove("Range Down");
                            i--;
                            break;
                        case "Luck Down":
                            EffectsBx.Items.Remove("Luck Down");
                            i--;
                            break;
                        case "Speed Down":
                            EffectsBx.Items.Remove("Speed Down");
                            i--;
                            break;
                        case "Tears Down":
                            EffectsBx.Items.Remove("Tears Down");
                            i--;
                            break;
                        case "???":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("???"); //becomes telepills
                                i--;
                            }
                            break;
                        case "Addicted":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("Addicted");//becomes Percs!
                                i--;
                            }

                            break;
                        case "I'm Excited!!!":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("I'm Excited!!!");//becomes I'm drowsy
                                i--;
                            }
                            break;
                        case "Paralysis":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("Paralysis");//becomes pheromones
                                i--;
                            }
                            break;
                        case "Retro Vision":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("Retro Vision");//becomes I can see forever
                                i--;
                            }
                            break;
                        case "R U A Wizard?":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("R U A Wizard?");//becomes power pill
                                i--;
                            }
                            break;
                        case "X-Lax":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("X-Lax");//becomes somethings wrong
                                i--;
                            }
                            break;
                        default:
                            break;

                    }
                }
            }
            else
            {
                if(!clearClicked)
                    if (resetVal != 2)
                        for (int i = 0; i < badPills.Length - 7; i++)
                            EffectsBx.Items.Add(badPills[i]);
                    else
                        for (int i = 0; i < badPills.Length; i++)
                            EffectsBx.Items.Add(badPills[i]);

            }
        }

        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (Pills.CurrentRow.Index < Pills.Rows.Count-1)
            {
                //foreach (DataGridViewRow item in Pills.CurrentRow)
                //{
                    rows--;
                    Pills.Rows.RemoveAt(Pills.CurrentRow.Index);
                //}
                validateInput();
            }
        }

        //These don't work
        private void EffectsBx_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void plannedUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Future updates include: \n>a tracker for curse of the unknown (Health tracker)\t- submitted by reddit user /u/nitronomer\n>a tracker for curse of the lost (map builder)\t- submitted by reddit user /u/nitronomer\n>a chart for all transformations (items and effects)\t- submitted by Tyler J Woolstenhulme");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Saving: it is recommended that you name your files after the seed of your run");
            List<string> memory = new List<string>();
            int j = 0;
            while (j < Pills.Rows.Count-1)//.Lines.Count()) //copies what's in the edit window into a new string list for saving
            {
                string temp = Pills.Rows[j].Cells[1].Value.ToString();//Effect
                temp += ","+Pills.Rows[j].Cells[2].Value.ToString();//orientation
                temp += "," + Pills.Rows[j].Cells[3].Value.ToString();//pill index
                temp += '\n';//newline to separate pills

                memory.Add(temp);
                j++;
            }
            SaveFileDialog toSave = new SaveFileDialog();
            Stream myStream = null;
            toSave.Filter = "data files (*.dat) |*.dat";
            if (toSave.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = toSave.OpenFile()) != null)
                {
                    //create streamwriter object
                    StreamWriter data = new StreamWriter(myStream);
                    for (int i = 0; i < memory.Count; i++)
                    {
                        data.WriteLine(memory[i]);
                    }
                    data.Close();
                }
            }
        } 

        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string openFilter = "data files (*.dat)|*dat";
            //List<string> pillList = new List<string>();
            //Stream myStream = null;
            OpenFileDialog toOpen = new OpenFileDialog();
            //define file extensions to show in the dialog
            toOpen.Filter = openFilter;
            Stream myStream = null;
            string entry;
            //check if operation worked
            if (toOpen.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = toOpen.OpenFile()) != null)
                {
                    StreamReader data = new StreamReader(myStream);
                    int i = 0;
                    do
                    {
                        entry = data.ReadLine();
                        if (entry == null||entry == "")
                            break;
                        //pillList.Add(entry); 
                        string[] newPill = entry.Split(',');
                        if (newPill[1] == "Normal")
                        {
                            // Pills.Rows.Add(blueBlue.Image, effect, orientation, pill);
                            Pills.Rows.Add(imageList1.Images[int.Parse(newPill[2])], newPill[0], newPill[1], int.Parse(newPill[2]));
                        }
                        else if (newPill[1] == "Vertical")
                        {
                            // Pills.Rows.Add(pictureBox1.Image, effect, orientation, pill);
                            Pills.Rows.Add(imageListV.Images[int.Parse(newPill[2])], newPill[0], newPill[1], int.Parse(newPill[2]));
                        }
                        else if (newPill[1] == "Reverse")
                        {
                            Pills.Rows.Add(imageListR.Images[int.Parse(newPill[2])], newPill[0], newPill[1], int.Parse(newPill[2]));
                        }
                        else if (newPill[1] == "Horizontal")
                        {
                            Pills.Rows.Add(imageListH.Images[int.Parse(newPill[2])], newPill[0], newPill[1], int.Parse(newPill[2]));
                        }
                        else
                            MessageBox.Show("Error Loading File");

                    } while (i < 13 && entry != null);
                    data.Close();
                }
            }
            myStream.Close();
        }

        private void PillTracker_ResizeEnd(object sender, EventArgs e)
        {
            Pills.Visible = false;
            Pills.Visible = true;
        }

        private void Pills_Scroll(object sender, ScrollEventArgs e)
        {
            Pills.Visible = false;
            Pills.Visible = true;
        }
    }


    public partial class transparentDataGrid : System.Windows.Forms.DataGridView
    {

        public transparentDataGrid() { }

        protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        {
            
            base.PaintBackground(graphics, clipBounds, gridBounds);
            Rectangle rectSource = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
            Rectangle rectDest = new Rectangle(0, 0, rectSource.Width, rectSource.Height);

            Bitmap b = new Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height);
            Graphics.FromImage(b).DrawImage(this.Parent.BackgroundImage, Parent.ClientRectangle);
            //this.BorderStyle

            graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel);

        }
        //protected override void PaintBackground(Graphics graphics, Rectangle clipBounds, Rectangle gridBounds)
        //{
        //    base.PaintBackground(graphics, clipBounds, gridBounds);
        //    Rectangle rectSource = new Rectangle(this.Location.X, this.Location.Y, this.Width, this.Height);
        //    Rectangle rectDest = new Rectangle(0, 0, rectSource.Width, rectSource.Height);

        //    Bitmap b = new Bitmap(Parent.ClientRectangle.Width, Parent.ClientRectangle.Height);
        //    Graphics.FromImage(b).DrawImage(this.Parent.BackgroundImage, Parent.ClientRectangle);


        //    graphics.DrawImage(b, rectDest, rectSource, GraphicsUnit.Pixel);
        //    SetCellsTransparent();
        //}


        //public void SetCellsTransparent()
        //{
        //    this.EnableHeadersVisualStyles = false;
        //    this.ColumnHeadersDefaultCellStyle.BackColor = Color.Transparent;
        //    this.RowHeadersDefaultCellStyle.BackColor = Color.Transparent;


        //    foreach (DataGridViewColumn col in this.Columns)
        //    {
        //        col.DefaultCellStyle.BackColor = Color.Transparent;
        //        col.DefaultCellStyle.SelectionBackColor = Color.Transparent;
        //    }
        //}
        
    }
}
/*
"48 Hour Energy","Amnesia","Bad Gas","Bad Trip","Balls of Steel","Bombs are Key","Explosive Diarrhea","Full Health","Health Down","Health Up","Hematemesis","I Can See Forever","I Found Pills","Lemon Party","Luck Down","Luck Up","Paralysis","Pheromones","Puberty","Pretty Fly","Range Down","Range Up","R U a Wizard?","Speed Down","Speed Up","Tears Down","Tears Up","Telepills"

Afterbirth:
"Addicted","Friends Till The End","Infested!","Infested?","One Makes You Small","One Makes You Larger","Percs","Power Pill","Re-Lax","Retro Vision","???"

Afterbirth +:
"Feels Like I'm Walking On Sunshine!","Gulp!","Horf!","I'm Drowsy","I'm Excited!!!","Something's Wrong...","Vurp!","X-Lax"
*/
