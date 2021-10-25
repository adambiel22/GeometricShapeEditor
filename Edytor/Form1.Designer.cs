
namespace Edytor
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tipLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.drawListView = new System.Windows.Forms.ListView();
            this.antiCheckBox = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.BackColor = System.Drawing.SystemColors.Window;
            this.pictureBox.Location = new System.Drawing.Point(12, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(927, 543);
            this.pictureBox.TabIndex = 0;
            this.pictureBox.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.antiCheckBox);
            this.panel1.Controls.Add(this.tipLabel);
            this.panel1.Controls.Add(this.groupBox1);
            this.panel1.Location = new System.Drawing.Point(945, 12);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(244, 543);
            this.panel1.TabIndex = 1;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // tipLabel
            // 
            this.tipLabel.AutoSize = true;
            this.tipLabel.Location = new System.Drawing.Point(6, 438);
            this.tipLabel.Name = "tipLabel";
            this.tipLabel.Size = new System.Drawing.Size(139, 20);
            this.tipLabel.TabIndex = 1;
            this.tipLabel.Text = "Select Tool in Menu";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.drawListView);
            this.groupBox1.Location = new System.Drawing.Point(0, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 425);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Menu";
            // 
            // drawListView
            // 
            this.drawListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.drawListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.drawListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.drawListView.HideSelection = false;
            this.drawListView.Location = new System.Drawing.Point(6, 26);
            this.drawListView.MultiSelect = false;
            this.drawListView.Name = "drawListView";
            this.drawListView.Size = new System.Drawing.Size(226, 393);
            this.drawListView.TabIndex = 0;
            this.drawListView.UseCompatibleStateImageBehavior = false;
            // 
            // antiCheckBox
            // 
            this.antiCheckBox.AutoSize = true;
            this.antiCheckBox.Location = new System.Drawing.Point(6, 470);
            this.antiCheckBox.Name = "antiCheckBox";
            this.antiCheckBox.Size = new System.Drawing.Size(109, 24);
            this.antiCheckBox.TabIndex = 2;
            this.antiCheckBox.Text = "Antialiasing";
            this.antiCheckBox.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1201, 567);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView drawListView;
        private System.Windows.Forms.Label tipLabel;
        private System.Windows.Forms.CheckBox antiCheckBox;
    }
}

