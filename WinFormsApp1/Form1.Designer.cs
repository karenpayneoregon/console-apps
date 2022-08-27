namespace WinFormsApp1
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.NewColumnButton = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.ListColumnsButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.ListColumnsButton);
            this.panel1.Controls.Add(this.NewColumnButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 196);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(566, 51);
            this.panel1.TabIndex = 0;
            // 
            // NewColumnButton
            // 
            this.NewColumnButton.Location = new System.Drawing.Point(12, 16);
            this.NewColumnButton.Name = "NewColumnButton";
            this.NewColumnButton.Size = new System.Drawing.Size(103, 23);
            this.NewColumnButton.TabIndex = 0;
            this.NewColumnButton.Text = "New column";
            this.NewColumnButton.UseVisualStyleBackColor = true;
            this.NewColumnButton.Click += new System.EventHandler(this.NewColumnButton_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 25;
            this.dataGridView1.Size = new System.Drawing.Size(566, 196);
            this.dataGridView1.TabIndex = 1;
            // 
            // ListColumnsButton
            // 
            this.ListColumnsButton.Location = new System.Drawing.Point(121, 16);
            this.ListColumnsButton.Name = "ListColumnsButton";
            this.ListColumnsButton.Size = new System.Drawing.Size(103, 23);
            this.ListColumnsButton.TabIndex = 1;
            this.ListColumnsButton.Text = "List columns";
            this.ListColumnsButton.UseVisualStyleBackColor = true;
            this.ListColumnsButton.Click += new System.EventHandler(this.ListColumnsButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 247);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.panel1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New columns";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Panel panel1;
        private Button NewColumnButton;
        private DataGridView dataGridView1;
        private Button ListColumnsButton;
    }
}