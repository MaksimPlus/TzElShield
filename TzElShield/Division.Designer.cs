namespace TzElShield
{
    partial class Division
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
            this.dGVDivision = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGVDivision)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVDivision
            // 
            this.dGVDivision.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVDivision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVDivision.Location = new System.Drawing.Point(0, 0);
            this.dGVDivision.Name = "dGVDivision";
            this.dGVDivision.RowHeadersWidth = 51;
            this.dGVDivision.RowTemplate.Height = 24;
            this.dGVDivision.Size = new System.Drawing.Size(800, 450);
            this.dGVDivision.TabIndex = 0;
            // 
            // Division
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dGVDivision);
            this.Name = "Division";
            this.Text = "Division";
            this.Load += new System.EventHandler(this.Division_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVDivision)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVDivision;
    }
}