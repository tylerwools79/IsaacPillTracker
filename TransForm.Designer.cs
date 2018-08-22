namespace Isaac_Pill_Tracker
{
    partial class TransForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransForm));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.RebirthTrans = new System.Windows.Forms.ImageList(this.components);
            this.AfterbirthTrans = new System.Windows.Forms.ImageList(this.components);
            this.AbplusTrans = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Transformations = new Isaac_Pill_Tracker.transparentDataGrid();
            this.TransName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransImage = new System.Windows.Forms.DataGridViewImageColumn();
            this.TransEffects = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TransItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transformations)).BeginInit();
            this.SuspendLayout();
            // 
            // RebirthTrans
            // 
            this.RebirthTrans.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("RebirthTrans.ImageStream")));
            this.RebirthTrans.TransparentColor = System.Drawing.Color.Transparent;
            this.RebirthTrans.Images.SetKeyName(0, "Beelzebub.png");
            this.RebirthTrans.Images.SetKeyName(1, "Guppy.png");
            // 
            // AfterbirthTrans
            // 
            this.AfterbirthTrans.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AfterbirthTrans.ImageStream")));
            this.AfterbirthTrans.TransparentColor = System.Drawing.Color.Transparent;
            this.AfterbirthTrans.Images.SetKeyName(0, "Bob.png");
            this.AfterbirthTrans.Images.SetKeyName(1, "Conjoined.png");
            this.AfterbirthTrans.Images.SetKeyName(2, "Fun_Guy.png");
            this.AfterbirthTrans.Images.SetKeyName(3, "Leviathan.png");
            this.AfterbirthTrans.Images.SetKeyName(4, "Oh_Crap.png");
            this.AfterbirthTrans.Images.SetKeyName(5, "Seraphim.png");
            this.AfterbirthTrans.Images.SetKeyName(6, "Spun.png");
            this.AfterbirthTrans.Images.SetKeyName(7, "Yes_Mother.png");
            this.AfterbirthTrans.Images.SetKeyName(8, "Super_Bum.png");
            // 
            // AbplusTrans
            // 
            this.AbplusTrans.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("AbplusTrans.ImageStream")));
            this.AbplusTrans.TransparentColor = System.Drawing.Color.Transparent;
            this.AbplusTrans.Images.SetKeyName(0, "Bookworm.png");
            this.AbplusTrans.Images.SetKeyName(1, "Spider_Baby.png");
            this.AbplusTrans.Images.SetKeyName(2, "Adult.png");
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.menuStrip1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1006, 28);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.helpToolStripMenuItem.Text = "Help";
            this.helpToolStripMenuItem.Click += new System.EventHandler(this.helpToolStripMenuItem_Click);
            // 
            // Transformations
            // 
            this.Transformations.AllowUserToAddRows = false;
            this.Transformations.AllowUserToDeleteRows = false;
            this.Transformations.AllowUserToResizeColumns = false;
            this.Transformations.AllowUserToResizeRows = false;
            this.Transformations.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Transformations.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.Transformations.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.RaisedHorizontal;
            this.Transformations.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Transformations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.Transformations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransName,
            this.TransImage,
            this.TransEffects,
            this.TransItem});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.Transformations.DefaultCellStyle = dataGridViewCellStyle4;
            this.Transformations.GridColor = System.Drawing.SystemColors.Control;
            this.Transformations.Location = new System.Drawing.Point(12, 31);
            this.Transformations.MultiSelect = false;
            this.Transformations.Name = "Transformations";
            this.Transformations.ReadOnly = true;
            this.Transformations.RowHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
            this.Transformations.RowHeadersVisible = false;
            this.Transformations.RowTemplate.Height = 40;
            this.Transformations.Size = new System.Drawing.Size(982, 486);
            this.Transformations.TabIndex = 0;
            this.Transformations.TabStop = false;
            // 
            // TransName
            // 
            this.TransName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.NullValue = null;
            this.TransName.DefaultCellStyle = dataGridViewCellStyle1;
            this.TransName.HeaderText = "Transformation";
            this.TransName.Name = "TransName";
            this.TransName.ReadOnly = true;
            this.TransName.Width = 133;
            // 
            // TransImage
            // 
            this.TransImage.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCellsExceptHeader;
            this.TransImage.HeaderText = "";
            this.TransImage.Name = "TransImage";
            this.TransImage.ReadOnly = true;
            this.TransImage.Width = 5;
            // 
            // TransEffects
            // 
            this.TransEffects.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TransEffects.DefaultCellStyle = dataGridViewCellStyle2;
            this.TransEffects.HeaderText = "Effects";
            this.TransEffects.Name = "TransEffects";
            this.TransEffects.ReadOnly = true;
            this.TransEffects.Width = 80;
            // 
            // TransItem
            // 
            this.TransItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.TransItem.DefaultCellStyle = dataGridViewCellStyle3;
            this.TransItem.HeaderText = "Items";
            this.TransItem.Name = "TransItem";
            this.TransItem.ReadOnly = true;
            this.TransItem.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.TransItem.Width = 70;
            // 
            // TransForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1006, 529);
            this.Controls.Add(this.Transformations);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "TransForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Isaac Transformation Sheet";
            this.Load += new System.EventHandler(this.TransForm_Load);
            this.Resize += new System.EventHandler(this.TransForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.Transformations)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ImageList RebirthTrans;
        private System.Windows.Forms.ImageList AfterbirthTrans;
        private System.Windows.Forms.ImageList AbplusTrans;
        private transparentDataGrid Transformations;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransName;
        private System.Windows.Forms.DataGridViewImageColumn TransImage;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransEffects;
        private System.Windows.Forms.DataGridViewTextBoxColumn TransItem;
    }
}