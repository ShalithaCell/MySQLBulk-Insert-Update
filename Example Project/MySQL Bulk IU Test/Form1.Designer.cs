namespace MySQL_Bulk_IU_Test
{
    partial class Form1
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
            this.btnTableCreate = new System.Windows.Forms.Button();
            this.btnBulkInsert = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnTableCreate
            // 
            this.btnTableCreate.Location = new System.Drawing.Point(218, 56);
            this.btnTableCreate.Name = "btnTableCreate";
            this.btnTableCreate.Size = new System.Drawing.Size(458, 63);
            this.btnTableCreate.TabIndex = 0;
            this.btnTableCreate.Text = "Create Table";
            this.btnTableCreate.UseVisualStyleBackColor = true;
            this.btnTableCreate.Click += new System.EventHandler(this.btnTableCreate_Click);
            // 
            // btnBulkInsert
            // 
            this.btnBulkInsert.Location = new System.Drawing.Point(218, 155);
            this.btnBulkInsert.Name = "btnBulkInsert";
            this.btnBulkInsert.Size = new System.Drawing.Size(458, 63);
            this.btnBulkInsert.TabIndex = 1;
            this.btnBulkInsert.Text = "Insert Bulk";
            this.btnBulkInsert.UseVisualStyleBackColor = true;
            this.btnBulkInsert.Click += new System.EventHandler(this.btnBulkInsert_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(218, 251);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(458, 63);
            this.button1.TabIndex = 2;
            this.button1.Text = "Update Bulk";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 351);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnBulkInsert);
            this.Controls.Add(this.btnTableCreate);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnTableCreate;
        private System.Windows.Forms.Button btnBulkInsert;
        private System.Windows.Forms.Button button1;
    }
}

