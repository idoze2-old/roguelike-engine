namespace Mapper
{
    partial class MapScreen
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
            this.SaveFile_Dropdown = new System.Windows.Forms.ComboBox();
            this.Depth_Selector = new System.Windows.Forms.NumericUpDown();
            this.SaveFile_Label = new System.Windows.Forms.Label();
            this.Depth_Label = new System.Windows.Forms.Label();
            this.PrintArea_panel = new System.Windows.Forms.Panel();
            this.CellMarker = new System.Windows.Forms.PictureBox();
            this.Print_box = new System.Windows.Forms.PictureBox();
            this.Brush_Selector = new System.Windows.Forms.ComboBox();
            this.Brush_Label = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Depth_Selector)).BeginInit();
            this.PrintArea_panel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellMarker)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Print_box)).BeginInit();
            this.SuspendLayout();
            // 
            // SaveFile_Dropdown
            // 
            this.SaveFile_Dropdown.FormattingEnabled = true;
            this.SaveFile_Dropdown.Location = new System.Drawing.Point(12, 38);
            this.SaveFile_Dropdown.Name = "SaveFile_Dropdown";
            this.SaveFile_Dropdown.Size = new System.Drawing.Size(122, 21);
            this.SaveFile_Dropdown.TabIndex = 0;
            this.SaveFile_Dropdown.SelectedIndexChanged += new System.EventHandler(this.SaveFile_Dropdown_SelectedIndexChanged);
            // 
            // Depth_Selector
            // 
            this.Depth_Selector.Location = new System.Drawing.Point(140, 38);
            this.Depth_Selector.Name = "Depth_Selector";
            this.Depth_Selector.Size = new System.Drawing.Size(36, 20);
            this.Depth_Selector.TabIndex = 1;
            this.Depth_Selector.ValueChanged += new System.EventHandler(this.Depth_Selector_ValueChanged);
            // 
            // SaveFile_Label
            // 
            this.SaveFile_Label.AutoSize = true;
            this.SaveFile_Label.Location = new System.Drawing.Point(12, 19);
            this.SaveFile_Label.Name = "SaveFile_Label";
            this.SaveFile_Label.Size = new System.Drawing.Size(48, 13);
            this.SaveFile_Label.TabIndex = 2;
            this.SaveFile_Label.Text = "SaveFile";
            // 
            // Depth_Label
            // 
            this.Depth_Label.AutoSize = true;
            this.Depth_Label.Location = new System.Drawing.Point(140, 19);
            this.Depth_Label.Name = "Depth_Label";
            this.Depth_Label.Size = new System.Drawing.Size(36, 13);
            this.Depth_Label.TabIndex = 3;
            this.Depth_Label.Text = "Depth";
            // 
            // PrintArea_panel
            // 
            this.PrintArea_panel.Controls.Add(this.CellMarker);
            this.PrintArea_panel.Controls.Add(this.Print_box);
            this.PrintArea_panel.Location = new System.Drawing.Point(15, 66);
            this.PrintArea_panel.Name = "PrintArea_panel";
            this.PrintArea_panel.Size = new System.Drawing.Size(299, 173);
            this.PrintArea_panel.TabIndex = 4;
            // 
            // CellMarker
            // 
            this.CellMarker.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.CellMarker.Location = new System.Drawing.Point(0, 0);
            this.CellMarker.Name = "CellMarker";
            this.CellMarker.Size = new System.Drawing.Size(8, 16);
            this.CellMarker.TabIndex = 1;
            this.CellMarker.TabStop = false;
            this.CellMarker.Click += new System.EventHandler(this.CellMarker_Click);
            // 
            // Print_box
            // 
            this.Print_box.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Print_box.Location = new System.Drawing.Point(0, 0);
            this.Print_box.MaximumSize = new System.Drawing.Size(160, 80);
            this.Print_box.MinimumSize = new System.Drawing.Size(160, 80);
            this.Print_box.Name = "Print_box";
            this.Print_box.Size = new System.Drawing.Size(160, 80);
            this.Print_box.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.Print_box.TabIndex = 0;
            this.Print_box.TabStop = false;
            this.Print_box.Click += new System.EventHandler(this.Print_box_Click);
            this.Print_box.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Print_box_MouseMove);
            // 
            // Brush_Selector
            // 
            this.Brush_Selector.FormattingEnabled = true;
            this.Brush_Selector.Location = new System.Drawing.Point(229, 37);
            this.Brush_Selector.Name = "Brush_Selector";
            this.Brush_Selector.Size = new System.Drawing.Size(85, 21);
            this.Brush_Selector.TabIndex = 5;
            this.Brush_Selector.SelectedIndexChanged += new System.EventHandler(this.Brush_Selector_SelectedIndexChanged);
            // 
            // Brush_Label
            // 
            this.Brush_Label.AutoSize = true;
            this.Brush_Label.Location = new System.Drawing.Point(226, 19);
            this.Brush_Label.Name = "Brush_Label";
            this.Brush_Label.Size = new System.Drawing.Size(74, 13);
            this.Brush_Label.TabIndex = 6;
            this.Brush_Label.Text = "Current Brush:";
            // 
            // MapScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 308);
            this.Controls.Add(this.Brush_Label);
            this.Controls.Add(this.Brush_Selector);
            this.Controls.Add(this.Depth_Label);
            this.Controls.Add(this.SaveFile_Label);
            this.Controls.Add(this.Depth_Selector);
            this.Controls.Add(this.SaveFile_Dropdown);
            this.Controls.Add(this.PrintArea_panel);
            this.Name = "MapScreen";
            this.Text = "MapScreen";
            this.Load += new System.EventHandler(this.MapScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Depth_Selector)).EndInit();
            this.PrintArea_panel.ResumeLayout(false);
            this.PrintArea_panel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.CellMarker)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Print_box)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        

        #endregion

        private System.Windows.Forms.ComboBox SaveFile_Dropdown;
        private System.Windows.Forms.NumericUpDown Depth_Selector;
        private System.Windows.Forms.Label SaveFile_Label;
        private System.Windows.Forms.Label Depth_Label;
        private System.Windows.Forms.Panel PrintArea_panel;
        private System.Windows.Forms.PictureBox Print_box;
        private System.Windows.Forms.ComboBox Brush_Selector;
        private System.Windows.Forms.Label Brush_Label;
        private System.Windows.Forms.PictureBox CellMarker;
    }
}