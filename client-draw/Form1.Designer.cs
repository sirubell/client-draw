using System.Net.Sockets;

namespace client_draw
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnConnect = new System.Windows.Forms.Button();
            this.pictureBoxCanvas = new System.Windows.Forms.PictureBox();
            this.textBoxServerIP = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.labelTime = new System.Windows.Forms.Label();
            this.labelHeart = new System.Windows.Forms.Label();
            this.playername = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(688, 57);
            this.btnConnect.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(129, 46);
            this.btnConnect.TabIndex = 0;
            this.btnConnect.Text = "Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // pictureBoxCanvas
            // 
            this.pictureBoxCanvas.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBoxCanvas.Location = new System.Drawing.Point(12, 12);
            this.pictureBoxCanvas.Name = "pictureBoxCanvas";
            this.pictureBoxCanvas.Size = new System.Drawing.Size(600, 900);
            this.pictureBoxCanvas.TabIndex = 1;
            this.pictureBoxCanvas.TabStop = false;
            this.pictureBoxCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBoxCanvas_Paint);
            // 
            // textBoxServerIP
            // 
            this.textBoxServerIP.Location = new System.Drawing.Point(618, 12);
            this.textBoxServerIP.Name = "textBoxServerIP";
            this.textBoxServerIP.Size = new System.Drawing.Size(254, 36);
            this.textBoxServerIP.TabIndex = 2;
            this.textBoxServerIP.Text = "127.0.0.1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(618, 109);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "Time: ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(618, 139);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "HP: ";
            // 
            // labelTime
            // 
            this.labelTime.AutoSize = true;
            this.labelTime.Location = new System.Drawing.Point(688, 109);
            this.labelTime.Name = "labelTime";
            this.labelTime.Size = new System.Drawing.Size(0, 30);
            this.labelTime.TabIndex = 5;
            // 
            // labelHeart
            // 
            this.labelHeart.AutoSize = true;
            this.labelHeart.Location = new System.Drawing.Point(688, 139);
            this.labelHeart.Name = "labelHeart";
            this.labelHeart.Size = new System.Drawing.Size(0, 30);
            this.labelHeart.TabIndex = 6;
            // 
            // playername
            // 
            this.playername.AutoSize = true;
            this.playername.Location = new System.Drawing.Point(618, 169);
            this.playername.Name = "playername";
            this.playername.Size = new System.Drawing.Size(127, 30);
            this.playername.TabIndex = 7;
            this.playername.Text = "playername";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 924);
            this.Controls.Add(this.playername);
            this.Controls.Add(this.labelHeart);
            this.Controls.Add(this.labelTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxServerIP);
            this.Controls.Add(this.pictureBoxCanvas);
            this.Controls.Add(this.btnConnect);
            this.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(5, 6, 5, 6);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "小方塊下樓梯";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnConnect;
        private PictureBox pictureBoxCanvas;
        private TextBox textBoxServerIP;
        private Label label1;
        private TcpClient client;
        private Dir dir;
        private Game game;
        private Label label2;
        private Label labelTime;
        private Label labelHeart;
        private Label playername;
    }
}