namespace WebserviceClientAdmin
{
    partial class FormMain
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
            this.buttonGo_Click = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.exerciciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxOp = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.logIn = new System.Windows.Forms.ToolStripMenuItem();
            this.logOut = new System.Windows.Forms.ToolStripMenuItem();
            this.signUp = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vegetaisToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurantesToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exercíciosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.vegetaisToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.restaurantesToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.exercíciosToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.exerciciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonGo_Click
            // 
            this.buttonGo_Click.Location = new System.Drawing.Point(617, 109);
            this.buttonGo_Click.Name = "buttonGo_Click";
            this.buttonGo_Click.Size = new System.Drawing.Size(75, 23);
            this.buttonGo_Click.TabIndex = 3;
            this.buttonGo_Click.Text = "GO!";
            this.buttonGo_Click.UseVisualStyleBackColor = true;
            this.buttonGo_Click.Click += new System.EventHandler(this.buttonGo_Click_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(452, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Operation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "All resources:";
            // 
            // exerciciosBindingSource
            // 
            this.exerciciosBindingSource.DataSource = typeof(WebserviceClientAdmin.ServiceReferenceWebservice.Exercicios);
            // 
            // comboBoxOp
            // 
            this.comboBoxOp.FormattingEnabled = true;
            this.comboBoxOp.Location = new System.Drawing.Point(514, 82);
            this.comboBoxOp.Name = "comboBoxOp";
            this.comboBoxOp.Size = new System.Drawing.Size(178, 21);
            this.comboBoxOp.TabIndex = 8;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 159);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(680, 324);
            this.dataGridView1.TabIndex = 9;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.logIn,
            this.logOut,
            this.signUp,
            this.searchToolStripMenuItem,
            this.addToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(704, 24);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // logIn
            // 
            this.logIn.Name = "logIn";
            this.logIn.Size = new System.Drawing.Size(52, 20);
            this.logIn.Text = "Log In";
            this.logIn.Click += new System.EventHandler(this.logIn_Click);
            // 
            // logOut
            // 
            this.logOut.Name = "logOut";
            this.logOut.Size = new System.Drawing.Size(62, 20);
            this.logOut.Text = "Log Out";
            this.logOut.Click += new System.EventHandler(this.logOut_Click);
            // 
            // signUp
            // 
            this.signUp.Name = "signUp";
            this.signUp.Size = new System.Drawing.Size(60, 20);
            this.signUp.Text = "Sign Up";
            this.signUp.Click += new System.EventHandler(this.signUp_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // addToolStripMenuItem
            // 
            this.addToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vegetaisToolStripMenuItem1,
            this.restaurantesToolStripMenuItem1,
            this.exercíciosToolStripMenuItem1});
            this.addToolStripMenuItem.Name = "addToolStripMenuItem";
            this.addToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.addToolStripMenuItem.Text = "Add";
            // 
            // vegetaisToolStripMenuItem1
            // 
            this.vegetaisToolStripMenuItem1.Name = "vegetaisToolStripMenuItem1";
            this.vegetaisToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.vegetaisToolStripMenuItem1.Text = "Vegetais";
            // 
            // restaurantesToolStripMenuItem1
            // 
            this.restaurantesToolStripMenuItem1.Name = "restaurantesToolStripMenuItem1";
            this.restaurantesToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.restaurantesToolStripMenuItem1.Text = "Restaurantes";
            // 
            // exercíciosToolStripMenuItem1
            // 
            this.exercíciosToolStripMenuItem1.Name = "exercíciosToolStripMenuItem1";
            this.exercíciosToolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.exercíciosToolStripMenuItem1.Text = "Exercícios";
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.vegetaisToolStripMenuItem2,
            this.restaurantesToolStripMenuItem2,
            this.exercíciosToolStripMenuItem2});
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.deleteToolStripMenuItem.Text = "Delete";
            // 
            // vegetaisToolStripMenuItem2
            // 
            this.vegetaisToolStripMenuItem2.Name = "vegetaisToolStripMenuItem2";
            this.vegetaisToolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.vegetaisToolStripMenuItem2.Text = "Vegetais";
            // 
            // restaurantesToolStripMenuItem2
            // 
            this.restaurantesToolStripMenuItem2.Name = "restaurantesToolStripMenuItem2";
            this.restaurantesToolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.restaurantesToolStripMenuItem2.Text = "Restaurantes";
            // 
            // exercíciosToolStripMenuItem2
            // 
            this.exercíciosToolStripMenuItem2.Name = "exercíciosToolStripMenuItem2";
            this.exercíciosToolStripMenuItem2.Size = new System.Drawing.Size(141, 22);
            this.exercíciosToolStripMenuItem2.Text = "Exercícios";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 495);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.comboBoxOp);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGo_Click);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.exerciciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonGo_Click;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.BindingSource exerciciosBindingSource;
        private System.Windows.Forms.ComboBox comboBoxOp;
        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem logIn;
        private System.Windows.Forms.ToolStripMenuItem logOut;
        private System.Windows.Forms.ToolStripMenuItem signUp;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vegetaisToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem restaurantesToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exercíciosToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem vegetaisToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem restaurantesToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem exercíciosToolStripMenuItem2;
    }
}