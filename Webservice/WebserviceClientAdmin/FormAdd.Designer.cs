namespace WebserviceClientAdmin
{
    partial class FormAdd
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
            this.radioButtonExercicios = new System.Windows.Forms.RadioButton();
            this.radioButtonRestaurantes = new System.Windows.Forms.RadioButton();
            this.radioButtonVegetais = new System.Windows.Forms.RadioButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.textBoxQuantidade = new System.Windows.Forms.TextBox();
            this.textBoxNome = new System.Windows.Forms.TextBox();
            this.textBoxCalorias = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonGravar = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.textBoxCaloriasRestaurante = new System.Windows.Forms.TextBox();
            this.textBoxQuantidadeRestaurante = new System.Windows.Forms.TextBox();
            this.textBoxItemRestaurante = new System.Windows.Forms.TextBox();
            this.textBoxNomeRestaurante = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.textBoxMet = new System.Windows.Forms.TextBox();
            this.textBoxCaloriasExercicio = new System.Windows.Forms.TextBox();
            this.textBoxNomeExercicio = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonExercicios);
            this.groupBox1.Controls.Add(this.radioButtonRestaurantes);
            this.groupBox1.Controls.Add(this.radioButtonVegetais);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(187, 107);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "O que pretende adicionar?";
            // 
            // radioButtonExercicios
            // 
            this.radioButtonExercicios.AutoSize = true;
            this.radioButtonExercicios.Location = new System.Drawing.Point(6, 77);
            this.radioButtonExercicios.Name = "radioButtonExercicios";
            this.radioButtonExercicios.Size = new System.Drawing.Size(75, 17);
            this.radioButtonExercicios.TabIndex = 2;
            this.radioButtonExercicios.TabStop = true;
            this.radioButtonExercicios.Text = "Exercícios";
            this.radioButtonExercicios.UseVisualStyleBackColor = true;
            this.radioButtonExercicios.Click += new System.EventHandler(this.radioButtonExercicios_Click);
            // 
            // radioButtonRestaurantes
            // 
            this.radioButtonRestaurantes.AutoSize = true;
            this.radioButtonRestaurantes.Location = new System.Drawing.Point(6, 54);
            this.radioButtonRestaurantes.Name = "radioButtonRestaurantes";
            this.radioButtonRestaurantes.Size = new System.Drawing.Size(88, 17);
            this.radioButtonRestaurantes.TabIndex = 1;
            this.radioButtonRestaurantes.TabStop = true;
            this.radioButtonRestaurantes.Text = "Restaurantes";
            this.radioButtonRestaurantes.UseVisualStyleBackColor = true;
            this.radioButtonRestaurantes.Click += new System.EventHandler(this.radioButtonRestaurantes_Click);
            // 
            // radioButtonVegetais
            // 
            this.radioButtonVegetais.AutoSize = true;
            this.radioButtonVegetais.Location = new System.Drawing.Point(6, 31);
            this.radioButtonVegetais.Name = "radioButtonVegetais";
            this.radioButtonVegetais.Size = new System.Drawing.Size(66, 17);
            this.radioButtonVegetais.TabIndex = 0;
            this.radioButtonVegetais.TabStop = true;
            this.radioButtonVegetais.Text = "Vegetais";
            this.radioButtonVegetais.UseVisualStyleBackColor = true;
            this.radioButtonVegetais.Click += new System.EventHandler(this.radioButtonVegetais_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.textBoxQuantidade);
            this.panel1.Controls.Add(this.textBoxNome);
            this.panel1.Controls.Add(this.textBoxCalorias);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 125);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(425, 104);
            this.panel1.TabIndex = 1;
            // 
            // textBoxQuantidade
            // 
            this.textBoxQuantidade.Location = new System.Drawing.Point(83, 71);
            this.textBoxQuantidade.Name = "textBoxQuantidade";
            this.textBoxQuantidade.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantidade.TabIndex = 4;
            // 
            // textBoxNome
            // 
            this.textBoxNome.Location = new System.Drawing.Point(103, 41);
            this.textBoxNome.Name = "textBoxNome";
            this.textBoxNome.Size = new System.Drawing.Size(312, 20);
            this.textBoxNome.TabIndex = 3;
            // 
            // textBoxCalorias
            // 
            this.textBoxCalorias.Location = new System.Drawing.Point(65, 11);
            this.textBoxCalorias.Name = "textBoxCalorias";
            this.textBoxCalorias.Size = new System.Drawing.Size(100, 20);
            this.textBoxCalorias.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Quantidade:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Nome do vegetal:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Calorias:";
            // 
            // buttonGravar
            // 
            this.buttonGravar.Location = new System.Drawing.Point(362, 274);
            this.buttonGravar.Name = "buttonGravar";
            this.buttonGravar.Size = new System.Drawing.Size(75, 23);
            this.buttonGravar.TabIndex = 2;
            this.buttonGravar.Text = "Gravar";
            this.buttonGravar.UseVisualStyleBackColor = true;
            this.buttonGravar.Click += new System.EventHandler(this.buttonGravar_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.textBoxCaloriasRestaurante);
            this.panel2.Controls.Add(this.textBoxQuantidadeRestaurante);
            this.panel2.Controls.Add(this.textBoxItemRestaurante);
            this.panel2.Controls.Add(this.textBoxNomeRestaurante);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Location = new System.Drawing.Point(12, 125);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(425, 129);
            this.panel2.TabIndex = 3;
            // 
            // textBoxCaloriasRestaurante
            // 
            this.textBoxCaloriasRestaurante.Location = new System.Drawing.Point(65, 98);
            this.textBoxCaloriasRestaurante.Name = "textBoxCaloriasRestaurante";
            this.textBoxCaloriasRestaurante.Size = new System.Drawing.Size(160, 20);
            this.textBoxCaloriasRestaurante.TabIndex = 8;
            // 
            // textBoxQuantidadeRestaurante
            // 
            this.textBoxQuantidadeRestaurante.Location = new System.Drawing.Point(83, 68);
            this.textBoxQuantidadeRestaurante.Name = "textBoxQuantidadeRestaurante";
            this.textBoxQuantidadeRestaurante.Size = new System.Drawing.Size(160, 20);
            this.textBoxQuantidadeRestaurante.TabIndex = 7;
            // 
            // textBoxItemRestaurante
            // 
            this.textBoxItemRestaurante.Location = new System.Drawing.Point(48, 38);
            this.textBoxItemRestaurante.Name = "textBoxItemRestaurante";
            this.textBoxItemRestaurante.Size = new System.Drawing.Size(288, 20);
            this.textBoxItemRestaurante.TabIndex = 6;
            // 
            // textBoxNomeRestaurante
            // 
            this.textBoxNomeRestaurante.Location = new System.Drawing.Point(132, 8);
            this.textBoxNomeRestaurante.Name = "textBoxNomeRestaurante";
            this.textBoxNomeRestaurante.Size = new System.Drawing.Size(249, 20);
            this.textBoxNomeRestaurante.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 101);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(47, 13);
            this.label7.TabIndex = 4;
            this.label7.Text = "Calorias:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 71);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 13);
            this.label6.TabIndex = 2;
            this.label6.Text = "Quantidade:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 41);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(30, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Item:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(114, 13);
            this.label4.TabIndex = 0;
            this.label4.Text = "Nome do Restaurante:";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.textBoxMet);
            this.panel3.Controls.Add(this.textBoxCaloriasExercicio);
            this.panel3.Controls.Add(this.textBoxNomeExercicio);
            this.panel3.Controls.Add(this.label10);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Location = new System.Drawing.Point(12, 125);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(425, 129);
            this.panel3.TabIndex = 4;
            // 
            // textBoxMet
            // 
            this.textBoxMet.Location = new System.Drawing.Point(48, 68);
            this.textBoxMet.Name = "textBoxMet";
            this.textBoxMet.Size = new System.Drawing.Size(195, 20);
            this.textBoxMet.TabIndex = 5;
            // 
            // textBoxCaloriasExercicio
            // 
            this.textBoxCaloriasExercicio.Location = new System.Drawing.Point(65, 38);
            this.textBoxCaloriasExercicio.Name = "textBoxCaloriasExercicio";
            this.textBoxCaloriasExercicio.Size = new System.Drawing.Size(195, 20);
            this.textBoxCaloriasExercicio.TabIndex = 4;
            // 
            // textBoxNomeExercicio
            // 
            this.textBoxNomeExercicio.Location = new System.Drawing.Point(119, 11);
            this.textBoxNomeExercicio.Name = "textBoxNomeExercicio";
            this.textBoxNomeExercicio.Size = new System.Drawing.Size(262, 20);
            this.textBoxNomeExercicio.TabIndex = 3;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(12, 71);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(28, 13);
            this.label10.TabIndex = 2;
            this.label10.Text = "Met:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(12, 41);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 1;
            this.label9.Text = "Calorias:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 14);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 13);
            this.label8.TabIndex = 0;
            this.label8.Text = "Nome do Exercício:";
            // 
            // FormAdd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(447, 309);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.buttonGravar);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormAdd";
            this.Text = "FormAdd";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonExercicios;
        private System.Windows.Forms.RadioButton radioButtonRestaurantes;
        private System.Windows.Forms.RadioButton radioButtonVegetais;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox textBoxQuantidade;
        private System.Windows.Forms.TextBox textBoxNome;
        private System.Windows.Forms.TextBox textBoxCalorias;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonGravar;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox textBoxCaloriasRestaurante;
        private System.Windows.Forms.TextBox textBoxQuantidadeRestaurante;
        private System.Windows.Forms.TextBox textBoxItemRestaurante;
        private System.Windows.Forms.TextBox textBoxNomeRestaurante;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox textBoxMet;
        private System.Windows.Forms.TextBox textBoxCaloriasExercicio;
        private System.Windows.Forms.TextBox textBoxNomeExercicio;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
    }
}