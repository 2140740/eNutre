namespace formMain
{
    partial class Main
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
            this.button_upload = new System.Windows.Forms.Button();
            this.button_Excel = new System.Windows.Forms.Button();
            this.button_JSON = new System.Windows.Forms.Button();
            this.button_TXT = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ValidateAll = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_upload
            // 
            this.button_upload.Location = new System.Drawing.Point(451, 19);
            this.button_upload.Name = "button_upload";
            this.button_upload.Size = new System.Drawing.Size(25, 23);
            this.button_upload.TabIndex = 0;
            this.button_upload.Text = "...";
            this.button_upload.UseVisualStyleBackColor = true;
            this.button_upload.Click += new System.EventHandler(this.button_upload_Click);
            // 
            // button_Excel
            // 
            this.button_Excel.Location = new System.Drawing.Point(20, 96);
            this.button_Excel.Name = "button_Excel";
            this.button_Excel.Size = new System.Drawing.Size(100, 23);
            this.button_Excel.TabIndex = 1;
            this.button_Excel.Text = "Excel to XML";
            this.button_Excel.UseVisualStyleBackColor = true;
            this.button_Excel.Click += new System.EventHandler(this.button_Excel_Click);
            // 
            // button_JSON
            // 
            this.button_JSON.Location = new System.Drawing.Point(20, 125);
            this.button_JSON.Name = "button_JSON";
            this.button_JSON.Size = new System.Drawing.Size(100, 23);
            this.button_JSON.TabIndex = 2;
            this.button_JSON.Text = "JSON to XML";
            this.button_JSON.UseVisualStyleBackColor = true;
            this.button_JSON.Click += new System.EventHandler(this.button_JSON_Click);
            // 
            // button_TXT
            // 
            this.button_TXT.Location = new System.Drawing.Point(20, 154);
            this.button_TXT.Name = "button_TXT";
            this.button_TXT.Size = new System.Drawing.Size(100, 23);
            this.button_TXT.TabIndex = 3;
            this.button_TXT.Text = "TXT to XML";
            this.button_TXT.UseVisualStyleBackColor = true;
            this.button_TXT.Click += new System.EventHandler(this.button_TXT_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 80);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Convert Options:";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(86, 22);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(359, 20);
            this.textBox_path.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Upload File:";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // ValidateAll
            // 
            this.ValidateAll.Location = new System.Drawing.Point(328, 125);
            this.ValidateAll.Name = "ValidateAll";
            this.ValidateAll.Size = new System.Drawing.Size(117, 23);
            this.ValidateAll.TabIndex = 7;
            this.ValidateAll.Text = "Validate File";
            this.ValidateAll.UseVisualStyleBackColor = true;
            this.ValidateAll.Click += new System.EventHandler(this.ValidateAll_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 109);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Check if your file is valid";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(488, 183);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ValidateAll);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_TXT);
            this.Controls.Add(this.button_JSON);
            this.Controls.Add(this.button_Excel);
            this.Controls.Add(this.button_upload);
            this.Name = "Main";
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_upload;
        private System.Windows.Forms.Button button_Excel;
        private System.Windows.Forms.Button button_JSON;
        private System.Windows.Forms.Button button_TXT;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button ValidateAll;
        private System.Windows.Forms.Label label3;
    }
}

