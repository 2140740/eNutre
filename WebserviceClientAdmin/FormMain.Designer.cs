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
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogOut = new System.Windows.Forms.Button();
            this.buttonSignUp_Click = new System.Windows.Forms.Button();
            this.buttonGo_Click = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxOutput = new System.Windows.Forms.TextBox();
            this.exerciciosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxOp = new System.Windows.Forms.ComboBox();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.exerciciosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(12, 12);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 0;
            this.buttonLogin.Text = "Log In";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogOut
            // 
            this.buttonLogOut.Location = new System.Drawing.Point(93, 12);
            this.buttonLogOut.Name = "buttonLogOut";
            this.buttonLogOut.Size = new System.Drawing.Size(75, 23);
            this.buttonLogOut.TabIndex = 1;
            this.buttonLogOut.Text = "Log Out";
            this.buttonLogOut.UseVisualStyleBackColor = true;
            this.buttonLogOut.Click += new System.EventHandler(this.buttonLogOut_Click);
            // 
            // buttonSignUp_Click
            // 
            this.buttonSignUp_Click.Location = new System.Drawing.Point(174, 12);
            this.buttonSignUp_Click.Name = "buttonSignUp_Click";
            this.buttonSignUp_Click.Size = new System.Drawing.Size(75, 23);
            this.buttonSignUp_Click.TabIndex = 2;
            this.buttonSignUp_Click.Text = "Sign Up";
            this.buttonSignUp_Click.UseVisualStyleBackColor = true;
            this.buttonSignUp_Click.Click += new System.EventHandler(this.buttonSignUp_Click_Click);
            // 
            // buttonGo_Click
            // 
            this.buttonGo_Click.Location = new System.Drawing.Point(174, 89);
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
            this.label1.Location = new System.Drawing.Point(9, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Operation:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 143);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Output:";
            // 
            // textBoxOutput
            // 
            this.textBoxOutput.Location = new System.Drawing.Point(12, 159);
            this.textBoxOutput.Multiline = true;
            this.textBoxOutput.Name = "textBoxOutput";
            this.textBoxOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxOutput.Size = new System.Drawing.Size(241, 324);
            this.textBoxOutput.TabIndex = 7;
            // 
            // exerciciosBindingSource
            // 
            this.exerciciosBindingSource.DataSource = typeof(WebserviceClientAdmin.ServiceReferenceWebservice.Exercicios);
            // 
            // comboBoxOp
            // 
            this.comboBoxOp.FormattingEnabled = true;
            this.comboBoxOp.Location = new System.Drawing.Point(71, 62);
            this.comboBoxOp.Name = "comboBoxOp";
            this.comboBoxOp.Size = new System.Drawing.Size(178, 21);
            this.comboBoxOp.TabIndex = 8;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(265, 495);
            this.Controls.Add(this.comboBoxOp);
            this.Controls.Add(this.textBoxOutput);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonGo_Click);
            this.Controls.Add(this.buttonSignUp_Click);
            this.Controls.Add(this.buttonLogOut);
            this.Controls.Add(this.buttonLogin);
            this.Name = "FormMain";
            this.Text = "FormMain";
            ((System.ComponentModel.ISupportInitialize)(this.exerciciosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogOut;
        private System.Windows.Forms.Button buttonSignUp_Click;
        private System.Windows.Forms.Button buttonGo_Click;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxOutput;
        private System.Windows.Forms.BindingSource exerciciosBindingSource;
        private System.Windows.Forms.ComboBox comboBoxOp;
        private System.Windows.Forms.BindingSource bindingSource1;
    }
}