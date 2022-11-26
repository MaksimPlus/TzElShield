namespace TzElShield
{
    partial class Education
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
            this.dGVEducation = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dGVEducation)).BeginInit();
            this.SuspendLayout();
            // 
            // dGVEducation
            // 
            this.dGVEducation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dGVEducation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dGVEducation.Location = new System.Drawing.Point(0, 0);
            this.dGVEducation.Name = "dGVEducation";
            this.dGVEducation.RowHeadersWidth = 51;
            this.dGVEducation.RowTemplate.Height = 24;
            this.dGVEducation.Size = new System.Drawing.Size(800, 450);
            this.dGVEducation.TabIndex = 0;
            this.dGVEducation.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Education
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dGVEducation);
            this.Name = "Education";
            this.Text = "Education";
            this.Load += new System.EventHandler(this.Education_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dGVEducation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dGVEducation;
    }
}