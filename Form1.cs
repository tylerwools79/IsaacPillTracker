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
Pitch: Have you ever been in the middle of a run and you see a pill in the shop or across some spikes that you know you've seen in this run, but you can't remember if it was a Health Up or a <insert marginally less useful pill here>? I know I have several times, and it bothered me enough that I've written an app in C# to track what pills in what orientation do what for your current run.
*/

//possible UPDATES:Curse of the lost tracker, curse of the unknown tracker, Transformations sheet 

//TODO:
//DONE: Add something to save and load to open the correct DLC for a run [x]. Reorganize code [x], Also make a quicksave option if they've already saved once[x], also remove the limitation for selecting a pill until you select an orientation[x], add a back end memory bank that will allow you to revert pills to what they were before PhD and Virgo [x], also make tooltips for the other menus because when it's shrunk down you can't read the longer effect names[x], also make save pull from memory rather than the data grid [x], also before you push it look into getting better pics for the rotated pills (the reason they are so bad is because the pixels cant be rotated 45 degrees. you'll need to manually make them in gimp) [x],add a thing that disables pill colors if they aren't in the proper DLC [x] (white-black, black-yellow, white-cyan, and white-yellow were added in afterbirth), got rid of that ugly extra bar at the bottom of the datagrid (comments in the functions in case of bug discovery) add a tooltip thing for the grid over the pills and the effects (if that's not possible at least have an option where it displays the name of the pill and effect if you click it)[x], Add a thing in the save to indicate if the phd/virgo box was checked [x], Added Transformation sheet[x]
namespace Isaac_Pill_Tracker
{
    public partial class PillTracker : Form
    {
        private string[] dlcPills = { "blackWhite", "blackYellow", "whiteCyan", "whiteYellow" };
        private string[] rebirth = { "48 Hour Energy", "Amnesia", "Bad Gas", "Bad Trip", "Balls of Steel", "Bombs are Key", "Explosive Diarrhea", "Full Health", "Health Down", "Health Up", "Hematemesis", "I Can See Forever", "I Found Pills", "Lemon Party", "Luck Down", "Luck Up", "Paralysis", "Pheromones", "Puberty", "Pretty Fly", "Range Down", "Range Up", "R U a Wizard?", "Speed Down", "Speed Up", "Tears Down", "Tears Up", "Telepills" };
        private string[] afterbirth = { "48 Hour Energy", "Amnesia", "Bad Gas", "Bad Trip", "Balls of Steel", "Bombs are Key", "Explosive Diarrhea", "Full Health", "Health Down", "Health Up", "Hematemesis", "I Can See Forever", "I Found Pills", "Lemon Party", "Luck Down", "Luck Up", "Paralysis", "Pheromones", "Puberty", "Pretty Fly", "Range Down", "Range Up", "R U a Wizard?", "Speed Down", "Speed Up", "Tears Down", "Tears Up", "Telepills", "Addicted", "Friends Till The End", "Infested!", "Infested?", "One Makes You Small", "One Makes You Larger", "Percs", "Power Pill", "Re-Lax", "Retro Vision", "???" };
        private string[] afterbirthPlus = { "48 Hour Energy", "Amnesia", "Bad Gas", "Bad Trip", "Balls of Steel", "Bombs are Key", "Explosive Diarrhea", "Full Health", "Health Down", "Health Up", "Hematemesis", "I Can See Forever", "I Found Pills", "Lemon Party", "Luck Down", "Luck Up", "Paralysis", "Pheromones", "Puberty", "Pretty Fly", "Range Down", "Range Up", "R U a Wizard?", "Speed Down", "Speed Up", "Tears Down", "Tears Up", "Telepills", "Addicted", "Friends Till The End", "Infested!", "Infested?", "One Makes You Small", "One Makes You Larger", "Percs", "Power Pill", "Re-Lax", "Retro Vision", "???", "Feels Like I'm Walking On Sunshine!", "Gulp!", "Horf!", "I'm Drowsy", "I'm Excited!!!", "Something's Wrong...", "Vurp!", "X-Lax" };
        private string savePath = "";
        private const string UNFINISHED_FEATURE = "This feature is still in development!\nUnfortunately this feature is not available yet. As soon as I finish it I will upload it to the github page.\nThank you for your support and patience!\n    -Tyler";
        private List<string> memory = new List<string>();
        private int resetVal = -1;
        private int rows = 0;
        private const int MAX_PILLS = 12;
        private bool clearClicked = false;

        public PillTracker()
        {            
            InitializeComponent();
        }

        private void PillTracker_Load(object sender, EventArgs e)
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
        
        /// <summary>
        /// This function will make saving more efficient by keeping a back end version of memory. 
        /// Memory is typically stored as it is entered but this is a backup  to gather memory for all of the pills on the grid
        /// </summary>
        private void accuMem()
        {
            int j = 0;
            while (j < Pills.Rows.Count)//.Lines.Count()) //copies what's in the edit window into a new string list for saving
            {
                string temp = Pills.Rows[j].Cells[1].Value.ToString();//effect
                temp += "," + Pills.Rows[j].Cells[2].Value.ToString();//orientation
                temp += "," + Pills.Rows[j].Cells[3].Value.ToString();//pill index
                temp += '\n';//newline to separate pills
                memory.Add(temp);
                j++;
            }
        }

        
        //DLC selectors and reset handlers
        private void clearBoxes()
        {
            addBtn.Enabled = false;
            phdChkBx.Checked = false;
            pillSelectBox.Text = "";
            EffectsBx.Text = "";
            orientationBx.Text = "";
            orientationBx.SelectedIndex = -1;
            //pillSelectBox.Enabled = false;
            previewBx.Image = emptyBx.Image;

            pillSelectBox.SelectedIndex = -1;
        }
        private void Rebirth_Click(object sender, EventArgs e)
        {
            clearClicked = true;
            clearBoxes();
            rows = 0;
            
            for (int i = 0; i < Pills.RowCount-1; i++)
                Pills.Rows.Clear();
            
            //if (PillTracker.ActiveForm != null)
            //    PillTracker.ActiveForm.BackgroundImage = rebirthPx.BackgroundImage;
            this.BackgroundImage = rebirthPx.BackgroundImage;
            EffectsBx.Items.Clear();
            
            for (int i = 0; i < rebirth.Length; i++)
                EffectsBx.Items.Add(rebirth[i]);

            if (pillSelectBox.Items.Count != 9)//this will remove the last four pills as options if necessary
                for (int i = 12; i > 8; i--)
                    if (dlcPills.Any(pillSelectBox.Items[i].ToString().Contains))
                        pillSelectBox.Items.RemoveAt(i);

            //string curpill = pillSelectBox.Items[i].ToString();
            //if (curpill==dlcPills[0]|| curpill == dlcPills[1]|| curpill == dlcPills[2]|| curpill == dlcPills[3])



            resetVal = 0;
            savePath = "";
            memory.Clear();
            clearClicked = false;
        }
        private void Afterbirth_Click(object sender, EventArgs e)
        {
            clearClicked = true;
            clearBoxes();
            rows = 0;
            for (int i = 0; i < Pills.RowCount-1; i++)
                Pills.Rows.Clear();
            
            //if (PillTracker.ActiveForm != null)
            //    PillTracker.ActiveForm.BackgroundImage = afterbirthPx.BackgroundImage;
            this.BackgroundImage = afterbirthPx.BackgroundImage;
            EffectsBx.Items.Clear();
            
            
            for (int i = 0; i < afterbirth.Length; i++)
                EffectsBx.Items.Add(afterbirth[i]);

            if (pillSelectBox.Items.Count == 9)//this adds the last four pills if necessary
                foreach (string x in dlcPills)
                    pillSelectBox.Items.Add(x);

            resetVal = 1;
            savePath = "";
            memory.Clear();
            clearClicked = false;
        }
        private void AfterbirthPlus_Click(object sender, EventArgs e)
        {
            clearClicked = true;
            clearBoxes();
            rows = 0;

            for (int i = 0; i < Pills.RowCount-1; i++)
                Pills.Rows.Clear();
            
            //if (PillTracker.ActiveForm != null)
            //    PillTracker.ActiveForm.BackgroundImage = afterbirthplusPx.BackgroundImage;
            //alternatively
            this.BackgroundImage = afterbirthplusPx.BackgroundImage;
            EffectsBx.Items.Clear();
            
            for (int i = 0; i < afterbirthPlus.Length; i++)
                EffectsBx.Items.Add(afterbirthPlus[i]);

            if (pillSelectBox.Items.Count == 9)//this adds the last four pills if necessary
                foreach (string x in dlcPills)
                    pillSelectBox.Items.Add(x);


            resetVal = 2;
            savePath = "";
            memory.Clear();
            clearClicked = false;
        }
        /// <summary>
        /// clears memory and resets to the proper DLC
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void clearBtn_Click(object sender, EventArgs e)
        {
            
            //clear memory first

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
        //DLC selectors and reset handlers end


        //Validation functions
        /// <summary>
        /// this function removes effects so that you can't have duplicate effects.
        /// it will also disable the add button if the pill orientation and color already exists
        /// </summary>
        private void RemoveDups()
        {
            if (rows > 0)
            {
                int pill = pillSelectBox.SelectedIndex;
                //System.Drawing.Image pill = imageList1.Images[pillSelectBox.SelectedIndex];//why aren't I basing this off of the selected index?
                string effect = (string)EffectsBx.SelectedItem;
                string orientation = (string)orientationBx.SelectedItem;
                for (int i = 0; i <= Pills.Rows.Count-1; i++)//used to be just < in case of horrible bug caused by data grid row
                {
                    if (Pills.Rows[i].Cells[3].Value.ToString() == pill.ToString() && Pills.Rows[i].Cells[2].Value.ToString() == orientation)
                        addBtn.Enabled = false;
                }
            }
            getPreview();

        }
        private void validateInput()
        {
            if (orientationBx.SelectedItem == null || EffectsBx.SelectedItem == null)
                return;
            if (pillSelectBox.SelectedIndex != -1 && pillSelectBox.SelectedItem != null && orientationBx.SelectedItem.ToString() != "" && EffectsBx.SelectedItem.ToString() != "" && rows <= MAX_PILLS)
                addBtn.Enabled = true;
            else
                addBtn.Enabled = false;
            RemoveDups();

        }
        private void pillSelectBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            validateInput();
        }
        private void orientationBx_SelectedIndexChanged(object sender, EventArgs e)
        {
            //if (orientationBx.SelectedIndex >= 0 && orientationBx.SelectedItem.ToString() != "")
            //    pillSelectBox.Enabled = true;
            //else
            //    pillSelectBox.Enabled = false;
            validateInput();
        }
        private void EffectsBx_SelectedValueChanged(object sender, EventArgs e)
        {
            validateInput();
        }
        //Validation functions end
        
        
        //Add, remove, and modify functions
        /// <summary>
        /// Adds and removes the bad pills from the selection box. changes names in the table to positive effects
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void phdChkBx_CheckedChanged(object sender, EventArgs e)
        {

            //if( == true)
            //phdChkBx.Click = true;
            //make it so it doen't call this if it's cleared or a different thing. change event listener to click (This is a non-issue now I think)
            string[] badPills = { "Bad Trip", "Amnesia", "Health Down", "Range Down", "Luck Down", "Tears Down", "Speed Down", "???", "Addicted", "I'm Excited!!!", "Paralysis", "Retro Vision", "R U a Wizard?", "X-Lax" };
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
                        case "R U a Wizard?":
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
                        case "R U a Wizard?":
                            if (resetVal == 2)
                            {
                                EffectsBx.Items.Remove("R U a Wizard?");//becomes power pill
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
                if (!clearClicked)
                {
                    if (resetVal != 2)//reason for this is to make sure only the pills that were originally there are added back in
                        for (int i = 0; i < badPills.Length - 7; i++)
                            EffectsBx.Items.Add(badPills[i]);
                    else
                        for (int i = 0; i < badPills.Length; i++)
                            EffectsBx.Items.Add(badPills[i]);

                    for (int i = 0; i < Pills.Rows.Count - 1; i++)
                    {
                        string temp = memory[i].Split(',')[0];
                        if (Pills.Rows[i].Cells[1].Value.ToString() != temp)
                            Pills.Rows[i].Cells[1].Value = temp;
                    }
                }

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
                Pills.Rows.Add(imageList1.Images[pill], effect, orientation, pill);
            }
            else if (orientation == "Vertical")
            {
                // Pills.Rows.Add(pictureBox1.Image, effect, orientation, pill);
                Pills.Rows.Add(imageListV.Images[pill], effect, orientation, pill);
            }
            else if (orientation == "Reverse")
            {
                Pills.Rows.Add(imageListR.Images[pill], effect, orientation, pill);
            }
            else if (orientation == "Horizontal")
            {
                Pills.Rows.Add(imageListH.Images[pill], effect, orientation, pill);
            }
            else
                Pills.Rows.Add(imageList1.Images[pill], effect, orientation, pill);

            //now add the pill to memory as well
            string temp = Pills.Rows[memory.Count].Cells[1].Value.ToString();//effect
            temp += "," + Pills.Rows[memory.Count].Cells[2].Value.ToString();//orientation
            temp += "," + Pills.Rows[memory.Count].Cells[3].Value.ToString();//pill index
            temp += '\n';//newline to separate pills
            memory.Add(temp);

            //cleanup
            addBtn.Enabled = false;
            previewBx.Image = emptyBx.Image;
            pillSelectBox.SelectedIndex = -1;
            EffectsBx.SelectedIndex = -1;
            EffectsBx.Text = "";
            orientationBx.SelectedIndex = -1;
            orientationBx.Text = "";
            return;

        }
        private void removeBtn_Click(object sender, EventArgs e)
        {
            if (Pills.CurrentRow.Index <= Pills.Rows.Count-1)//used to just be < in case of horrible bug
            {
                rows--;
                memory.RemoveAt(Pills.CurrentRow.Index); //in theory removes the pill from memory.
                Pills.Rows.RemoveAt(Pills.CurrentRow.Index);
                

                validateInput();
            }
        }
        //Add, remove, and modify functions end


        //Toolstrip functions
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "\tCopyright Tyler J Woolstenhulme\n\tpublished November 17th, 2017, all rights reserved\n\tI DO NOT OWN THE IMAGES USED IN THIS APP";
            msg += "\n\n==============================================\n\tContact me with any bugs or ideas you'd like to see added: \n\t\t>/u/tylerwools79 on Reddit\n\t\t>burneremail2142@gmail.com\n==============================================";
            msg += "\n\ncredit for rebirth background: https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwid-57KisLXAhVBH2MKHfACA_oQjRwIBw&url=https%3A%2F%2Fwww.youtube.com%2Fwatch%3Fv%3D1bm3QtT6cdY&psig=AOvVaw02A_SGxPKXqRHkw3ZrVqQo&ust=1510886933908357";
            msg += "\n\ncredit for afterbirth background:  https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwjox8rTicLXAhUN1WMKHUO6COYQjRwIBw&url=https%3A%2F%2Fwall.alphacoders.com%2Fbig.php%3Fi%3D807117%26lang%3DSwedish&psig=AOvVaw3ydxu-AQZGMKto4JyNgYM8&ust=1510886684348841";
            msg += "\n\ncredit for afterbirth+ background: https://www.google.com/url?sa=i&rct=j&q=&esrc=s&source=images&cd=&cad=rja&uact=8&ved=0ahUKEwiQ5MGzisLXAhVI02MKHfWkCfwQjRwIBw&url=http%3A%2F%2Fspaceone2.tistory.com%2F4&psig=AOvVaw1WvvrCZ3oxzNRXVPGsfUCA&ust=1510886883293161";
            msg += "\n\ncredit for pill pictures (Normal and reversed orientations): https://bindingofisaacrebirth.gamepedia.com/Pills";
            msg += "\n\ncredit for Transformation Sheet background: https://images7.alphacoders.com/555/thumb-1920-555641.png";
            msg += "\n\nNo Copyright Infringement Intended.";
            MessageBox.Show(msg);
        }
        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string msg = "Hello! Thank you for using this Binding Of Isaac Pill Tracking App!\nThere are a few basic steps to using this tool...\n\n";
            msg += "1.First choose which version of the game you're playing using the buttons in the box labelled \"DLC\"\n";
            msg += "2.Second choose the pill, the effect, and the orientation from the selection boxes. You can verify the pill's name by hovering the mouse over the selection box.\n";
            msg += "3.Confirm that the pill looks correct in the pill preview box and then click the add button, this will add the pill to the table.\n";
            msg += "\nMake sure you check the PHD/Virgo box when you pick up either of those items, \nthis will convert the pills in the table and remove the bad pills from the effects selection box.\n";
            msg += "Unchecking the box will add the bad pill effects back to the selection box, but it will not change the pills in the table back.";
            msg += "\nSaving: it is recommended that you name your files after the seed of your run, and it is advisable to create a designated folder for saving.\nDefault save location is your documents folder.\n\n";

            msg += "When you die, just click the clear button to reset the pills and effects. Have fun!";
            msg += "";
            MessageBox.Show(msg);
        }
        private void plannedUpdatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Future updates include: \n>a tracker for curse of the unknown (Health tracker)\t- submitted by reddit user /u/nitronomer\n>a tracker for curse of the lost (map builder)\t- submitted by reddit user /u/nitronomer\n");
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //accuMem();//actually is this even necessary since I'm adding it at every add button push?
            SaveFileDialog toSave = new SaveFileDialog();
            Stream myStream = null;
            toSave.Filter = "data files (*.dat) |*.dat";
            //System.IO.Directory.CreateDirectory("BOI_Pills/");
            //toSave.InitialDirectory = "BOI_Pills/";
            if (savePath == "")
            {
                if (toSave.ShowDialog() == DialogResult.OK)
                {
                    if ((myStream = toSave.OpenFile()) != null)
                    {
                        savePath = toSave.FileName;
                        //create streamwriter object
                        StreamWriter data = new StreamWriter(myStream);
                        data.WriteLine(resetVal);                       //this will save which DLC was used
                        data.WriteLine(phdChkBx.Checked ? 1 : 0);
                        for (int i = 0; i < memory.Count; i++)
                        {
                            data.Write(memory[i]);
                        }
                        data.Close();
                    }
                }
            }
            else
            {
                toSave.FileName = savePath;
                if ((myStream = toSave.OpenFile()) != null)
                {
                    StreamWriter data = new StreamWriter(myStream);
                    data.WriteLine(resetVal);
                    data.WriteLine(phdChkBx.Checked ? 1 : 0);
                    for (int i = 0; i < memory.Count; i++)
                    {
                        data.Write(memory[i]);
                    }
                    data.Close();
                }
                MessageBox.Show("Save Successful!");
                myStream.Close();
            }            
        }
        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            savePath = "";
            saveAsToolStripMenuItem_Click(sender, e);
        }
        private void loadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //has initial directory
            string openFilter = "data files (*.dat)|*dat";
            //Stream myStream = null;
            OpenFileDialog toOpen = new OpenFileDialog();
            //define file extensions to show in the dialog
            //toOpen.InitialDirectory ="BOI_Pills/";
            toOpen.Filter = openFilter;
            Stream myStream = null;
            string entry;
            //toOpen.ShowDialog();
            //check if operation worked
            try {
                if (toOpen.ShowDialog() == DialogResult.OK)// this is failing, check your browser for a webpage of someone who has the same problem but the site is blocked on alpine. I have no idea why this began happening though
                {
                    if ((myStream = toOpen.OpenFile()) != null)
                    {
                        
                        StreamReader data = new StreamReader(myStream);
                        int i = 0;
                        if (int.TryParse(data.ReadLine(), out resetVal)) //this will process the resetVal saved at the very top of the file.
                            clearBtn_Click(sender, e); //should load proper DLC
                        else
                        {
                            MessageBox.Show("Something went wrong while attempting to load. Please report this error.\nContact information can be found in the \"About\" menu tab");
                            return;
                        }
                        bool checkPHD = false;
                        int nextchar = data.Peek();
                        if (nextchar == '1')
                            checkPHD = true;
                        else if (nextchar == '0')
                            checkPHD = false;
                        else
                            MessageBox.Show("Old save file detected, check PHD/Virgo box if you have the item");

                        savePath = toOpen.FileName; //enables quick save

                        do
                        {
                            entry = data.ReadLine();
                            if (entry == null)//||entry == "")
                                break;
                            string[] newPill = entry.Split(',');
                            if (newPill.Length == 1)//no split was made
                            {
                                int blCount = 1; //blank line counter (terminates a loop if it exceeds a number to prevent overflow
                                while (true)
                                {
                                    entry = data.ReadLine();
                                    if (entry == null)
                                    {
                                        data.Close();
                                        myStream.Close();
                                        return;
                                    }
                                    newPill = entry.Split(',');
                                    if (newPill.Length == 1)
                                        blCount++;
                                    else
                                        break;

                                    if (blCount > 20)
                                    {
                                        MessageBox.Show("ERROR: Too many blank lines in file.\n");
                                        data.Close();
                                        myStream.Close();
                                        return;
                                    }
                                }
                            }


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
                                MessageBox.Show("Error Loading File\nUnknown pill orientation detected...");

                        } while (i < 13 && entry != null);
                        data.Close();

                        myStream.Close();
                        accuMem(); //populates the back end memory list with what was added to the table. Realistically could've done this during the loop.
                        if (checkPHD)
                            phdChkBx.Checked = checkPHD;
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            
        }
        /// <summary>
        /// Loads a separate form with all the transformations on it
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void transformationsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TransForm TransformationSheet = new TransForm(resetVal);
            TransformationSheet.Show();
        }
        /// <summary>
        /// Separate map builder application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void floorTrackerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(UNFINISHED_FEATURE);
        }
        //Toolstrip functions end


        //Refresh and render functions
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
            else
                previewBx.Image = emptyBx.Image;
        }
        private void Pills_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            //previous code in case of horrible bug discovery
            //if (!clearClicked)
            //{
            //    rows++;
            //    Pills.CurrentCell = Pills.Rows[rows].Cells[0];
            //}

            if (!clearClicked)
            {
                
                if (Pills.CurrentCell == null)
                    Pills.CurrentCell = Pills.Rows[Pills.Rows.Count - 1].Cells[0];
                    
                Pills.CurrentCell = Pills.Rows[rows].Cells[0];
                rows++;
            }
            clearClicked = false;
        }
        private void pillSelectBox_DrawItem(object sender, DrawItemEventArgs e)
        {
            if (resetVal != 0 && e.Index > -1 && imageList1.Images.Count - 1 >= e.Index)
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawImage(imageList1.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
            }
            else if (resetVal == 0 && e.Index > -1 && imageList1.Images.Count - 5 >= e.Index)//This keeps it from drawing the last 4 pills, still leaves empty spaces without the code in the resets though
            {
                e.DrawBackground();
                e.DrawFocusRectangle();
                e.Graphics.DrawImage(imageList1.Images[e.Index], new PointF(e.Bounds.X, e.Bounds.Y));
            }

        }
        private void PillTracker_ResizeEnd(object sender, EventArgs e)
        {
            Pills.Refresh();
            //Pills.Visible = false;
            //Pills.Visible = true;
        }
        private void Pills_Scroll(object sender, ScrollEventArgs e)
        {
            Pills.Refresh();
            //Pills.Visible = false;
            //Pills.Visible = true;
        }
        //Refresh and render functions end

        
        //Key press handlers
        /// <summary>
        /// Hides the drop down when a user types into the selection box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void EffectsBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            //alternative to this, set style to DropDown, capture the KeyPress, check the control's text plus e.KeyChar, if it's not in the list set e.Handled = True.
            EffectsBx.DroppedDown = false;
            if (e.KeyChar == '\b')
                EffectsBx.SelectedIndex = -1;
        }
        private void orientationBx_KeyPress(object sender, KeyPressEventArgs e)
        {
            orientationBx.DroppedDown = false;
            if (e.KeyChar == '\b')
                orientationBx.SelectedIndex = -1;
        }
        private void pillSelectBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\b')
                pillSelectBox.SelectedIndex = -1;
            else
                e.Handled = true;
        }
        //Key press handlers end


        //Tooltip hover handlers & associated helper functions
        /// <summary>
        /// This function was made to reduce redundant code by isolating a reused switch statement. Used by pillSelectBox_MouseHover and Pills_CellFormatting
        /// </summary>
        /// <param name="pill">The pill name selected to display the description of</param>
        /// <returns>a description of the pill passed in</returns>
        private string pillTooltipHelper(string pill)
        {
            string selectpill = "";
            switch (pill)
            {
                case "blueBlue":
                case "0":
                    selectpill = "Blue Blue pill";
                    break;
                case "blueCyan":
                case "1":
                    selectpill = "Blue Cyan pill";
                    break;
                case "orangeOrange":
                case "2":
                    selectpill = "Orange Orange pill";
                    break;
                case "whiteWhite":
                case "3":
                    selectpill = "White White pill";
                    break;
                case "redSpecled":
                case "4":
                    selectpill = "White Red Speckled pill";
                    break;
                case "spottedWhiteWhite":
                case "5":
                    selectpill = "Spotted White White pill";
                    break;
                case "whiteBlue":
                case "6":
                    selectpill = "White Blue pill";
                    break;
                case "whiteRed":
                case "7":
                    selectpill = "White Red pill";
                    break;
                case "yellowOrange":
                case "8":
                    selectpill = "Yellow Orange pill";
                    break;
                case "blackWhite":
                case "9":
                    selectpill = "White Black pill";
                    break;
                case "blackYellow":
                case "10":
                    selectpill = "Black Yellow pill";
                    break;
                case "whiteCyan":
                case "11":
                    selectpill = "White Cyan pill";
                    break;
                case "whiteYellow":
                case "12":
                    selectpill = "White Yellow pill";
                    break;
                default:
                    selectpill = "Unknown pill color\nPlease contact Tyler Woolstenhulme to report this bug.\nContact info is in the about page.";
                    break;
            }
            return selectpill;
        }
        /// <summary>
        /// tooltip hover function to aid in selecting the correct pill
        /// Necessary due to the compression of the pills. difficult to tell white white from white speckled and such
        /// </summary>
        /// <param name="sender">should be the pill select box</param>
        /// <param name="e">should be mouse hover</param>
        private void pillSelectBox_MouseHover(object sender, EventArgs e)
        {
            if (pillSelectBox.SelectedIndex == -1)
                return;
            string selectpill = (string)pillSelectBox.SelectedItem;
            selectpill = pillTooltipHelper(selectpill);
            this.toolTip1.Show(selectpill, pillSelectBox);
        }
        private void EffectsBx_MouseHover(object sender, EventArgs e)
        {
            if (EffectsBx.SelectedIndex == -1)
                this.toolTip1.Hide(EffectsBx);
            else
            {
                string effect = (string)EffectsBx.SelectedItem;
                //if (EffectsBx.Focus() == true)
                //    if (effect != EffectsBx.SelectedText)
                //        effect = EffectsBx.SelectedText;
                this.toolTip1.Show(effect, EffectsBx);
            }
        }
        /// <summary>
        /// Tooltips for the data grid
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Pills_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if(e.RowIndex <= rows)//used to just be < in case of horrible data grid bug discovery
            {
                var cell = Pills.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (e.ColumnIndex == Pills.Columns[0].Index)//this should be the image column
                {
                    int pIndex = (int)Pills.Rows[e.RowIndex].Cells[3].Value;//the pill index for the image from the hidden imgIndex column of the datagrid
                    cell.ToolTipText = $"{ pillTooltipHelper(pIndex.ToString())}";
                }
                else if (e.ColumnIndex == Pills.Columns[1].Index)//this is the effects column
                {
                    cell.ToolTipText = Pills.Rows[e.RowIndex].Cells[1].Value.ToString();
                }
            }            
        }
        //Tooltip hover handlers end
    }

    /// <summary>
    /// Class that allows for a transparent background on a data grid
    /// </summary>
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
