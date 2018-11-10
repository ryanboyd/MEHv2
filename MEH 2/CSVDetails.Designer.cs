namespace MEHv2
{
    partial class CSVDetailsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CSVDetailsForm));
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ID_CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.Text_CheckedListBox = new System.Windows.Forms.CheckedListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.ColumnsAsSeparateTextsCheckbox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(360, 428);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(75, 23);
            this.OKButton.TabIndex = 0;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.CancelButton.Location = new System.Drawing.Point(237, 428);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 1;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ID_CheckedListBox
            // 
            this.ID_CheckedListBox.CheckOnClick = true;
            this.ID_CheckedListBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ID_CheckedListBox.FormattingEnabled = true;
            this.ID_CheckedListBox.HorizontalScrollbar = true;
            this.ID_CheckedListBox.Location = new System.Drawing.Point(37, 55);
            this.ID_CheckedListBox.Name = "ID_CheckedListBox";
            this.ID_CheckedListBox.Size = new System.Drawing.Size(267, 310);
            this.ID_CheckedListBox.TabIndex = 2;
            // 
            // Text_CheckedListBox
            // 
            this.Text_CheckedListBox.CheckOnClick = true;
            this.Text_CheckedListBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text_CheckedListBox.FormattingEnabled = true;
            this.Text_CheckedListBox.HorizontalScrollbar = true;
            this.Text_CheckedListBox.Location = new System.Drawing.Point(368, 55);
            this.Text_CheckedListBox.Name = "Text_CheckedListBox";
            this.Text_CheckedListBox.Size = new System.Drawing.Size(267, 310);
            this.Text_CheckedListBox.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(34, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 16);
            this.label1.TabIndex = 4;
            this.label1.Text = "Column(s) to use as Row Identifier:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(365, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 16);
            this.label2.TabIndex = 5;
            this.label2.Text = "Column(s) Containing Text:";
            // 
            // ColumnsAsSeparateTextsCheckbox
            // 
            this.ColumnsAsSeparateTextsCheckbox.AutoSize = true;
            this.ColumnsAsSeparateTextsCheckbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ColumnsAsSeparateTextsCheckbox.Location = new System.Drawing.Point(373, 381);
            this.ColumnsAsSeparateTextsCheckbox.Name = "ColumnsAsSeparateTextsCheckbox";
            this.ColumnsAsSeparateTextsCheckbox.Size = new System.Drawing.Size(258, 20);
            this.ColumnsAsSeparateTextsCheckbox.TabIndex = 6;
            this.ColumnsAsSeparateTextsCheckbox.Text = "Treat Each Column as a Separate Text";
            this.ColumnsAsSeparateTextsCheckbox.UseVisualStyleBackColor = true;
            // 
            // CSVDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ClientSize = new System.Drawing.Size(676, 476);
            this.ControlBox = false;
            this.Controls.Add(this.ColumnsAsSeparateTextsCheckbox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Text_CheckedListBox);
            this.Controls.Add(this.ID_CheckedListBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(692, 515);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(692, 515);
            this.Name = "CSVDetailsForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Spreadsheet Details";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.CheckedListBox ID_CheckedListBox;
        private System.Windows.Forms.CheckedListBox Text_CheckedListBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox ColumnsAsSeparateTextsCheckbox;
    }
}