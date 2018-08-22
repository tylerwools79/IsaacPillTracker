using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Isaac_Pill_Tracker
{

    public partial class TransForm : Form
    {
        
        //Rebirth Item Lists
        private static Item[] beelzItems = { new Item("Jar of Flies", 1), new Item("???'s only Friend"), new Item("Angry Fly",2), new Item("BBF"), new Item("Best Bud"), new Item("Big Fan"), new Item("Distant Admiration"), new Item("Forever Alone"), new Item("Friend Zone",1), new Item("Halo of Flies"), new Item("Hive Mind"), new Item("Infestation"), new Item("Lost Fly",1), new Item("The Mulligan"), new Item("Obsessed Fan"), new Item("Papa Fly"), new Item("Skatole"), new Item("Smart Fly") };
        private static Item[] guppyItems = { new Item("Guppy's Head"), new Item("Guppy's Paw"), new Item("Dead Cat"), new Item("Guppy's Collar"), new Item("Guppy's Tail"), new Item("Guppy's Hair Ball") };
        //private Trans Beelz = new Trans("Beelzebub", "Flight,\nConverts small enemy flies into blue flies", beelzItems);
        //private Trans Guppy = new Trans("Guppy", "Flight,\nSpawns a blue fly each time a tear hits an enemy", guppyItems);


        //Afterbirth item Lists
        private Item[] bobItems = { new Item("Bob's Rotten Head"),new Item("Bob's Brain"),new Item("Bob's Curse"), new Item("Ipecac")};
        private Item[] conjItems = { new Item("Brother Bobby"), new Item("Harlequin Baby"), new Item("Headless Baby"), new Item("Little Steven"), new Item("Mongo Baby"), new Item("Rotten Baby"), new Item("Sister Maggy") };
        private Item[] funguyItems = { new Item("1up!"),new Item("Blue Cap"), new Item("God's Flesh"), new Item("Magic Mushroom"), new Item("Mini Mush"), new Item("Odd Mushroom (Large)"), new Item("Odd Mushroom (Thin)") };
        private Item[] leviaItems = { new Item("The nail"), new Item("Abaddon"), new Item("Brimstone"), new Item("The Mark"), new Item("Maw of the Void"), new Item("The Pact"), new Item("Pentagram"), new Item("Spirit of the Night")};
        private Item[] ohcrapItems = { new Item("Flush!"),new Item("The Poop"), new Item("E-Coli")};
        private Item[] seraItems = { new Item("The Bible"), new Item("Dead Dove"),new Item("Guardian Angel"),new Item("The Halo"),new Item("Holy Grail"),new Item("Holy Mantle"),new Item("Mitre"),new Item("Rosary"),new Item("Sworn Protector") };
        private Item[] spunItems = { new Item("Adrenaline",2), new Item("Euthanasia",2),new Item("Experimental Treatment"),new Item("Growth Hormones"),new Item("Roid Rage"),new Item("Speed Ball"),new Item("Synthoil")};
        private Item[] momItems = { new Item("Mom's Bottle of Pills"),new Item("Mom's Bra"),new Item("Mom's Pad"),new Item("Mom's Shovel",2),new Item("Mom's Coin Purse"),new Item("Mom's Contacts"),new Item("Mom's Eye"),new Item("Mom's Eyeshadow"),new Item("Mom's Heels"),new Item("Mom's Key"),new Item("Mom's Knife"),new Item("Mom's Lipstick"),new Item("Mom's Pearls"),new Item("Mom's Perfume"),new Item("Mom's Purse"),new Item("Mom's Razor",2),new Item("Mom's Underwear"),new Item("Mom's Wig") };
        private Item[] sbumItems = { new Item("Bum Friend"),new Item("Dark Bum"),new Item("Key Bum") };

        //Afterbirth+ item Lists
        private Item[] bookItems = { new Item("Anarchist Cookbook"),new Item("The Bible"),new Item("The Book of Belial"),new Item("Book of Revelations"),new Item("Book of Secrets"),new Item("Book of Shadows"),new Item("The Book of Sin"),new Item("Book of the Dead"),new Item("How to Jump"),new Item("The Necronomicon"),new Item("Monster Manual"),new Item("Satanic Bible"),new Item("Telepathy for Dummies") };
        private Item[] spidItems = { new Item("Box of Spiders"),new Item("Spider Butt"),new Item("Mutant Spider"),new Item("Spider Baby"),new Item("Spider Bite"),new Item("Spider Mod")};
        

        private int rVal = -1;
        public TransForm()
        {
            InitializeComponent();
        }
        public TransForm(int resetVal)
        {
            rVal = resetVal;
            InitializeComponent();
            //display the correct table and transformations
        }

        private void TransForm_Load(object sender, EventArgs e)
        {
            Transformations.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            switch (rVal)
            {
                case 0:
                    populateRebirth();
                    break;
                case 1:
                    populateAfterbirth();
                    break;
                case 2:
                    populateAfterbirthPlus();
                    break;
                default:
                    MessageBox.Show("Error occurred trying to get the DLC");
                    break;
            }
            
        }



        private string filterForDLC(Item[] list)
        {
            string itemList = "\n";
            if (rVal != 2)
            {
                foreach (Item i in list)
                    if (i.getDLC() <= rVal)
                        itemList += $" - {i.getName()}\n";
            }
            else
            {
                foreach (Item i in list)
                        itemList += $" - {i.getName()}\n";
            }

            return itemList;
        }
        private void populateRebirth()
        {
            string filtered_items = "";
            //beelz loop
            filtered_items = filterForDLC(beelzItems);
            Transformations.Rows.Add("Beelzebub", RebirthTrans.Images[0], "Flight,\nConverts small enemy flies into blue flies", filtered_items);
            

            //guppy loop
            filtered_items = filterForDLC(guppyItems);
            Transformations.Rows.Add("Guppy", RebirthTrans.Images[1], "Flight,\nSpawns a blue fly each time a tear hits an enemy", filtered_items);

        }
        private void populateAfterbirth()
        {
            populateRebirth();
            string filtered_items = "";
            //bob
            filtered_items = filterForDLC(bobItems);
            Transformations.Rows.Add("Bob", AfterbirthTrans.Images[0], "Grants a trail of poisonous green creep", filtered_items);

            //conjoined
            filtered_items = filterForDLC(conjItems);
            Transformations.Rows.Add("Conjoined", AfterbirthTrans.Images[1], "Grants two tumor faces that shoot tears diagonally,\n-0.3 damage,\nSlight increase to tear rate", filtered_items);

            //Fun Guy
            filtered_items = filterForDLC(funguyItems);
            Transformations.Rows.Add("Fun Guy", AfterbirthTrans.Images[2], "+1 Heart Container", filtered_items);

            //Leviathan
            filtered_items = filterForDLC(leviaItems);
            Transformations.Rows.Add("Leviathan", AfterbirthTrans.Images[3], "Flight,\n+2 Black Hearts", filtered_items);

            //Oh Crap
            filtered_items = filterForDLC(ohcrapItems);
            Transformations.Rows.Add("Oh Crap", AfterbirthTrans.Images[4], "Replenishes 1/2 a red heart for every poop destroyed", filtered_items);

            //Seraphim
            filtered_items = filterForDLC(seraItems);
            Transformations.Rows.Add("Seraphim", AfterbirthTrans.Images[5], "Flight,\n+3 Soul Hearts", filtered_items);

            //Spun
            filtered_items = filterForDLC(spunItems);
            Transformations.Rows.Add("Spun", AfterbirthTrans.Images[6], "+2 Damage,\n+0.15 Speed,\nSpawns a random pill", filtered_items);

            //Yes Mother?
            filtered_items = filterForDLC(momItems);
            Transformations.Rows.Add("Yes, Mother?", AfterbirthTrans.Images[7], "Grants a stationary knife that trails behind Isaac", filtered_items);

            //Super Bum
            filtered_items = filterForDLC(sbumItems);
            Transformations.Rows.Add("Super Bum", AfterbirthTrans.Images[8], "Combines all three beggar followers into one, Super Bum offers twice the rewards and can pick up coins, hearts, and keys", filtered_items);
        }
        private void populateAfterbirthPlus()
        {
            populateAfterbirth();
            string filtered_items = "";

            //Bookworm
            filtered_items = filterForDLC(bookItems);
            Transformations.Rows.Add("Bookworm", AbplusTrans.Images[0], "50% of the time Isaac shoots an extra tear like 20/20", filtered_items);

            //Spider Baby
            filtered_items = filterForDLC(spidItems);
            Transformations.Rows.Add("Spider Baby", AbplusTrans.Images[1], "Spawns a spider familiar that applies random status effects to enemies", filtered_items);

            //Adult
            Transformations.Rows.Add("Adult", AbplusTrans.Images[2], "+1 Heart Container", "\n - Puberty (Pill) x3\n");
        }

        private void helpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string message = "";

            message += "This is the transformation sheet!\n";
            message += "This sheet detects which DLC you're using from the Pill Tracker form and automatically populates the grid with the appropriate transformations and items included in that DLC.\n";
            message += "\nIf you find any glitches with this form please report them as I will not be testing this form as thoroughly since it has no interactivity. For contact info refer to the About tab on the main form.\nThank You!\n-Tyler";

            MessageBox.Show(message);
        }

        private void TransForm_Resize(object sender, EventArgs e)
        {
            Transformations.Refresh();
        }
    }



    public class Item
    {
        private int resetVal = -1;
        private string name;
        public Item() { }
        public Item(string n, int rVal = 0) { resetVal = rVal; name = n; }
        public int getDLC()
        {
            return resetVal;
        }
        public string getName()
        {
            return name;
        }
    }
    
}
/*
    public partial class TransForm : Form
    {
        ///=====REBIRTH=====
        //Item Lists
        private static Item[] beelzItems = { new Item(1, "Jar of Flies"), new Item(0,"???'s only Friend"), new Item(2,"Angry Fly"),new Item(0,"BBF"),new Item(0, "Best Bud"), new Item(0,"Big Fan"),new Item(0,"Distant Admiration"),new Item(0, "Forever Alone"),new Item(1,"Friend Zone"),new Item(0,"Halo of Flies"),new Item(0,"Hive Mind"),new Item(0,"Infestation"),new Item(1,"Lost Fly"),new Item(0,"The Mulligan"),new Item(1,"Obsessed Fan"),new Item(1,"Papa Fly"),new Item(0,"Skatole"),new Item(0,"Smart Fly")};
        private  static Item[] guppyItems = { new Item(0,"Guppy's Head"),new Item(0,"Guppy's Paw"),new Item(0,"Dead Cat"),new Item(0,"Guppy's Collar"),new Item(0,"Guppy's Tail"),new Item(0,"Guppy's Hair Ball") };
        //transformation objects
        private Trans Beelz = new Trans("Beelzebub", "Flight,\nConverts small enemy flies into blue flies", beelzItems);
        private Trans Guppy = new Trans("Guppy","Flight,\nSpawns a blue fly each time a tear hits an enemy", guppyItems);
        //Afterbirth item trans
        private Item[] bobItems = { };
        private Item[] conjItems = { };
        private Item[] funguyItems = { };
        private Item[] leviaItems = { };
        private Item[] ohcrapItems = { };
        private Item[] seraItems = { };
        private Item[] spunItems = { };
        private Item[] momItems = { };
        private Item[] sbumItems = { };

        //Afterbirth+ item trans
        private Item[] bookItems = { };
        private Item[] spidItems = { };


        private int rVal=-1;
        public TransForm()
        {
            InitializeComponent();
        }
        public TransForm(int resetVal)
        {
            rVal = resetVal;
            InitializeComponent();
            //display the correct table and transformations
        }

        private void TransForm_Load(object sender, EventArgs e)
        {
            Transformations.AutoGenerateColumns = false; //this allows for row collapsing
            switch (rVal)
            {
                case 0:
                    populateRebirth();
                    break;
                case 1:
                    populateAfterbirth();
                    break;
                case 2:
                    populateAfterbirthPlus();
                    break;
                default:
                    MessageBox.Show("Error occurred trying to get the DLC");
                    break;
            }
        }
        private void populateRebirth()
        {
            //beelz loop
            foreach (Item i in Beelz.getItems())
                Transformations.Rows.Add(Beelz.getName(), RebirthTrans.Images[0], Beelz.getFX(), (i.getDLC() == rVal) ? i.getName() : "");
            
            //guppy loop
            foreach (Item i in Guppy.getItems())
                Transformations.Rows.Add(Guppy.getName(), RebirthTrans.Images[0], Guppy.getFX(), (i.getDLC() == rVal) ? i.getName() : ""); 

        }
        private void populateAfterbirth()
        {
            populateRebirth();
        }
        private void populateAfterbirthPlus()
        {
            populateAfterbirth();
        }

        bool IsTheSameCellValue(int column, int row)
        {
            DataGridViewCell c1 = Transformations[column, row];
            DataGridViewCell c2 = Transformations[column, row - 1];
            if (c1.Value == null || c2.Value == null)
                return false;
            return c1.Value == c2.Value;//maybe remove toString to make it work with images?
        }

        /// <summary>
        /// This will allow me to "collapse" rows within a certain column
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Transformations_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
            if (e.RowIndex < 1 || e.ColumnIndex < 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
            }
            else
            {
                e.AdvancedBorderStyle.Top = Transformations.AdvancedCellBorderStyle.Top;
            }
        }

        private void Transformations_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = null;
                e.FormattingApplied = true;
            }
        }
    }
    public class Item
    {
        private int resetVal = -1;
        private string name;
        public Item() { }
        public Item(int rVal, string n) { resetVal = rVal; name = n; }
        public int getDLC()
        {
            return resetVal;
        }
        public string getName()
        {
            return name;
        }
    }

    public class Trans
    {
        
        List<Item> items = new List<Item>();
        string name, effects;
        public Trans() { }
        public Trans(string n, string fx, Item[] itemList)
        {
            
            name = n;
            effects = fx;
            foreach (Item i in itemList)
            {
                items.Add(i);
            }
        }
        
        public string getFX() { return effects; }
        public string getName() { return name; }
        public List<Item> getItems() { return items; }
    }
}

*/
