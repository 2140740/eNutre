namespace WebserviceClientAdmin
{
    partial class FormDelete
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonVegetais = new System.Windows.Forms.RadioButton();
            this.radioButtonRestaurantes = new System.Windows.Forms.RadioButton();
            this.radioButtonExercícios = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonExercícios);
            this.groupBox1.Controls.Add(this.radioButtonRestaurantes);
            this.groupBox1.Controls.Add(this.radioButtonVegetais);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 111);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "O que pretende Eliminar?";
            // 
            // radioButtonVegetais
            // 
            this.radioButtonVegetais.AutoSize = true;
            this.radioButtonVegetais.Location = new System.Drawing.Point(6, 32);
            this.radioButtonVegetais.Name = "radioButtonVegetais";
            this.radioButtonVegetais.Size = new System.Drawing.Size(66, 17);
            this.radioButtonVegetais.TabIndex = 0;
            this.radioButtonVegetais.TabStop = true;
            this.radioButtonVegetais.Text = "Vegetais";
            this.radioButtonVegetais.UseVisualStyleBackColor = true;
            this.radioButtonVegetais.Click += new System.EventHandler(this.radioButtonVegetais_Click);
            // 
            // radioButtonRestaurantes
            // 
            this.radioButtonRestaurantes.AutoSize = true;
            this.radioButtonRestaurantes.Location = new System.Drawing.Point(6, 55);
            this.radioButtonRestaurantes.Name = "radioButtonRestaurantes";
            this.radioButtonRestaurantes.Size = new System.Drawing.Size(88, 17);
            this.radioButtonRestaurantes.TabIndex = 1;
            this.radioButtonRestaurantes.TabStop = true;
            this.radioButtonRestaurantes.Text = "Restaurantes";
            this.radioButtonRestaurantes.UseVisualStyleBackColor = true;
            this.radioButtonRestaurantes.Click += new System.EventHandler(this.radioButtonRestaurantes_Click);
            // 
            // radioButtonExercícios
            // 
            this.radioButtonExercícios.AutoSize = true;
            this.radioButtonExercícios.Location = new System.Drawing.Point(6, 78);
            this.radioButtonExercícios.Name = "radioButtonExercícios";
            this.radioButtonExercícios.Size = new System.Drawing.Size(75, 17);
            this.radioButtonExercícios.TabIndex = 2;
            this.radioButtonExercícios.TabStop = true;
            this.radioButtonExercícios.Text = "Exercícios";
            this.radioButtonExercícios.UseVisualStyleBackColor = true;
            this.radioButtonExercícios.Click += new System.EventHandler(this.radioButtonExercícios_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(328, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Eliminar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(120, 129);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(283, 20);
            this.textBox1.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 132);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Nome do vegetal";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 132);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nome do exercício";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 132);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Nome do Item";
            // 
            // FormDelete
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(415, 192);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormDelete";
            this.Text = "FormDelete";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonExercícios;
        private System.Windows.Forms.RadioButton radioButtonRestaurantes;
        private System.Windows.Forms.RadioButton radioButtonVegetais;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}