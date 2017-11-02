namespace ServerChatGUI
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.inMessage_txtbox = new System.Windows.Forms.TextBox();
            this.send_btn = new System.Windows.Forms.Button();
            this.connection_lbl = new System.Windows.Forms.Label();
            this.chatDisplay_txtbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // inMessage_txtbox
            // 
            this.inMessage_txtbox.Location = new System.Drawing.Point(12, 492);
            this.inMessage_txtbox.Name = "inMessage_txtbox";
            this.inMessage_txtbox.Size = new System.Drawing.Size(316, 20);
            this.inMessage_txtbox.TabIndex = 0;
            // 
            // send_btn
            // 
            this.send_btn.Location = new System.Drawing.Point(335, 489);
            this.send_btn.Name = "send_btn";
            this.send_btn.Size = new System.Drawing.Size(75, 23);
            this.send_btn.TabIndex = 1;
            this.send_btn.Text = "SEND";
            this.send_btn.UseVisualStyleBackColor = true;
            this.send_btn.Click += new System.EventHandler(this.button1_Click);
            // 
            // connection_lbl
            // 
            this.connection_lbl.AutoSize = true;
            this.connection_lbl.Location = new System.Drawing.Point(332, 9);
            this.connection_lbl.Name = "connection_lbl";
            this.connection_lbl.Size = new System.Drawing.Size(79, 13);
            this.connection_lbl.TabIndex = 2;
            this.connection_lbl.Text = "Not Connected";
            // 
            // chatDisplay_txtbox
            // 
            this.chatDisplay_txtbox.Location = new System.Drawing.Point(12, 43);
            this.chatDisplay_txtbox.Multiline = true;
            this.chatDisplay_txtbox.Name = "chatDisplay_txtbox";
            this.chatDisplay_txtbox.ReadOnly = true;
            this.chatDisplay_txtbox.Size = new System.Drawing.Size(398, 440);
            this.chatDisplay_txtbox.TabIndex = 3;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 527);
            this.Controls.Add(this.chatDisplay_txtbox);
            this.Controls.Add(this.connection_lbl);
            this.Controls.Add(this.send_btn);
            this.Controls.Add(this.inMessage_txtbox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox inMessage_txtbox;
        private System.Windows.Forms.Button send_btn;
        private System.Windows.Forms.Label connection_lbl;
        private System.Windows.Forms.TextBox chatDisplay_txtbox;
    }
}

