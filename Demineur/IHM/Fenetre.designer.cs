namespace IHM
{
    partial class Fenetre
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
            this.StartButton = new System.Windows.Forms.Button();
            this.MineLabel = new System.Windows.Forms.Label();
            this.GridPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // StartButton
            // 
            this.StartButton.Image = global::Demineur.Properties.Resources.happySmiley;
            this.StartButton.Location = new System.Drawing.Point(90, 12);
            this.StartButton.Name = "StartButton";
            this.StartButton.Size = new System.Drawing.Size(25, 25);
            this.StartButton.TabIndex = 0;
            this.StartButton.UseVisualStyleBackColor = true;
            this.StartButton.Click += new System.EventHandler(this.StartButton_Click);
            // 
            // MineLabel
            // 
            this.MineLabel.AutoSize = true;
            this.MineLabel.Location = new System.Drawing.Point(12, 18);
            this.MineLabel.Name = "MineLabel";
            this.MineLabel.Size = new System.Drawing.Size(35, 13);
            this.MineLabel.TabIndex = 2;
            this.MineLabel.Text = "label2";
            // 
            // GridPanel
            // 
            this.GridPanel.Location = new System.Drawing.Point(12, 50);
            this.GridPanel.Name = "GridPanel";
            this.GridPanel.Size = new System.Drawing.Size(200, 200);
            this.GridPanel.TabIndex = 3;
            // 
            // Fenetre
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(224, 262);
            this.Controls.Add(this.GridPanel);
            this.Controls.Add(this.MineLabel);
            this.Controls.Add(this.StartButton);
            this.Name = "Fenetre";
            this.Text = "Demineur";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button StartButton;
        private System.Windows.Forms.Label MineLabel;
        private System.Windows.Forms.Panel GridPanel;
    }
}

