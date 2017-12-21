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
            ((System.ComponentModel.ISupportInitialize)(this.Depth_Selector)).BeginInit();
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
            // MapScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(470, 308);
            this.Controls.Add(this.Depth_Label);
            this.Controls.Add(this.SaveFile_Label);
            this.Controls.Add(this.Depth_Selector);
            this.Controls.Add(this.SaveFile_Dropdown);
            this.Name = "MapScreen";
            this.Text = "MapScreen";
            this.Load += new System.EventHandler(this.MapScreen_Load);
            ((System.ComponentModel.ISupportInitialize)(this.Depth_Selector)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SaveFile_Dropdown;
        private System.Windows.Forms.NumericUpDown Depth_Selector;
        private System.Windows.Forms.Label SaveFile_Label;
        private System.Windows.Forms.Label Depth_Label;
    }
}