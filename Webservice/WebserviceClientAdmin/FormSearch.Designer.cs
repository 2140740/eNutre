namespace WebserviceClientAdmin
{
    partial class FormSearch
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
            this.buttonSearch = new System.Windows.Forms.Button();
            this.textBoxSearch = new System.Windows.Forms.TextBox();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxresource = new System.Windows.Forms.ComboBox();
            this.buttonprocuracalorias = new System.Windows.Forms.Button();
            this.buttonCalorias_Exercicios = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(16, 85);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 0;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // textBoxSearch
            // 
            this.textBoxSearch.Location = new System.Drawing.Point(16, 59);
            this.textBoxSearch.Name = "textBoxSearch";
            this.textBoxSearch.Size = new System.Drawing.Size(193, 20);
            this.textBoxSearch.TabIndex = 1;
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(16, 149);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(448, 216);
            this.textBoxOutput.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Search:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 121);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Output:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(340, 43);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Search resource:";
            // 
            // comboBoxresource
            // 
            this.comboBoxresource.FormattingEnabled = true;
            this.comboBoxresource.Items.AddRange(new object[] {
            "Vegetais",
            "Restaurantes",
            "Exercícios"});
            this.comboBoxresource.Location = new System.Drawing.Point(343, 59);
            this.comboBoxresource.Name = "comboBoxresource";
            this.comboBoxresource.Size = new System.Drawing.Size(121, 21);
            this.comboBoxresource.TabIndex = 6;
            // 
            // buttonprocuracalorias
            // 
            this.buttonprocuracalorias.Location = new System.Drawing.Point(12, 12);
            this.buttonprocuracalorias.Name = "buttonprocuracalorias";
            this.buttonprocuracalorias.Size = new System.Drawing.Size(123, 23);
            this.buttonprocuracalorias.TabIndex = 7;
            this.buttonprocuracalorias.Text = "Calorias Específicas";
            this.buttonprocuracalorias.UseVisualStyleBackColor = true;
            this.buttonprocuracalorias.Click += new System.EventHandler(this.buttonprocuracalorias_Click);
            // 
            // buttonCalorias_Exercicios
            // 
            this.buttonCalorias_Exercicios.Location = new System.Drawing.Point(170, 12);
            this.buttonCalorias_Exercicios.Name = "buttonCalorias_Exercicios";
            this.buttonCalorias_Exercicios.Size = new System.Drawing.Size(132, 23);
            this.buttonCalorias_Exercicios.TabIndex = 8;
            this.buttonCalorias_Exercicios.Text = "Calorias Exercícios";
            this.buttonCalorias_Exercicios.UseVisualStyleBackColor = true;
            this.buttonCalorias_Exercicios.Click += new System.EventHandler(this.buttonCalorias_Exercicios_Click);
            // 
            // FormSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(476, 377);
            this.Controls.Add(this.buttonCalorias_Exercicios);
            this.Controls.Add(this.buttonprocuracalorias);
            this.Controls.Add(this.comboBoxresource);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.textBoxSearch);
            this.Controls.Add(this.buttonSearch);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormSearch";
            this.Text = "FormSeacrh";
            this.Load += new System.EventHandler(this.FormSeacrh_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.TextBox textBoxSearch;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxresource;
        private System.Windows.Forms.Button buttonprocuracalorias;
        private System.Windows.Forms.Button buttonCalorias_Exercicios;
    }
}