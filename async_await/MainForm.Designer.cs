namespace async_await
{
    partial class MainForm
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
            this.btnDownloadStringV1 = new System.Windows.Forms.Button();
            this.edOutput = new System.Windows.Forms.TextBox();
            this.lblDownloadStringV1 = new System.Windows.Forms.Label();
            this.btnDownloadStringV2 = new System.Windows.Forms.Button();
            this.lblDownloadStringV3 = new System.Windows.Forms.Label();
            this.btnDownloadStringV5 = new System.Windows.Forms.Button();
            this.lblDownloadStringV5 = new System.Windows.Forms.Label();
            this.btnAsyncConnection1 = new System.Windows.Forms.Button();
            this.lblAsyncConnection1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnDownloadStringV1
            // 
            this.btnDownloadStringV1.Location = new System.Drawing.Point(12, 11);
            this.btnDownloadStringV1.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadStringV1.Name = "btnDownloadStringV1";
            this.btnDownloadStringV1.Size = new System.Drawing.Size(171, 28);
            this.btnDownloadStringV1.TabIndex = 2;
            this.btnDownloadStringV1.Text = "DownloadStringV1";
            this.btnDownloadStringV1.UseVisualStyleBackColor = true;
            this.btnDownloadStringV1.Click += new System.EventHandler(this.btnDownloadStringV1_Click);
            // 
            // edOutput
            // 
            this.edOutput.Location = new System.Drawing.Point(12, 213);
            this.edOutput.Multiline = true;
            this.edOutput.Name = "edOutput";
            this.edOutput.Size = new System.Drawing.Size(773, 110);
            this.edOutput.TabIndex = 3;
            // 
            // lblDownloadStringV1
            // 
            this.lblDownloadStringV1.AutoSize = true;
            this.lblDownloadStringV1.Location = new System.Drawing.Point(214, 20);
            this.lblDownloadStringV1.Name = "lblDownloadStringV1";
            this.lblDownloadStringV1.Size = new System.Drawing.Size(0, 13);
            this.lblDownloadStringV1.TabIndex = 4;
            // 
            // btnDownloadStringV2
            // 
            this.btnDownloadStringV2.Location = new System.Drawing.Point(12, 42);
            this.btnDownloadStringV2.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadStringV2.Name = "btnDownloadStringV2";
            this.btnDownloadStringV2.Size = new System.Drawing.Size(171, 28);
            this.btnDownloadStringV2.TabIndex = 5;
            this.btnDownloadStringV2.Text = "DownloadStringV3";
            this.btnDownloadStringV2.UseVisualStyleBackColor = true;
            this.btnDownloadStringV2.Click += new System.EventHandler(this.btnDownloadStringV2_Click);
            // 
            // lblDownloadStringV3
            // 
            this.lblDownloadStringV3.AutoSize = true;
            this.lblDownloadStringV3.Location = new System.Drawing.Point(214, 50);
            this.lblDownloadStringV3.Name = "lblDownloadStringV3";
            this.lblDownloadStringV3.Size = new System.Drawing.Size(0, 13);
            this.lblDownloadStringV3.TabIndex = 6;
            // 
            // btnDownloadStringV5
            // 
            this.btnDownloadStringV5.Location = new System.Drawing.Point(12, 74);
            this.btnDownloadStringV5.Margin = new System.Windows.Forms.Padding(2);
            this.btnDownloadStringV5.Name = "btnDownloadStringV5";
            this.btnDownloadStringV5.Size = new System.Drawing.Size(171, 28);
            this.btnDownloadStringV5.TabIndex = 7;
            this.btnDownloadStringV5.Text = "DownloadStringV5";
            this.btnDownloadStringV5.UseVisualStyleBackColor = true;
            this.btnDownloadStringV5.Click += new System.EventHandler(this.btnDownloadStringV5_Click);
            // 
            // lblDownloadStringV5
            // 
            this.lblDownloadStringV5.AutoSize = true;
            this.lblDownloadStringV5.Location = new System.Drawing.Point(214, 82);
            this.lblDownloadStringV5.Name = "lblDownloadStringV5";
            this.lblDownloadStringV5.Size = new System.Drawing.Size(0, 13);
            this.lblDownloadStringV5.TabIndex = 8;
            // 
            // btnAsyncConnection1
            // 
            this.btnAsyncConnection1.Location = new System.Drawing.Point(12, 106);
            this.btnAsyncConnection1.Margin = new System.Windows.Forms.Padding(2);
            this.btnAsyncConnection1.Name = "btnAsyncConnection1";
            this.btnAsyncConnection1.Size = new System.Drawing.Size(171, 28);
            this.btnAsyncConnection1.TabIndex = 9;
            this.btnAsyncConnection1.Text = "Async connection 1";
            this.btnAsyncConnection1.UseVisualStyleBackColor = true;
            this.btnAsyncConnection1.Click += new System.EventHandler(this.btnAsyncConnection1_Click);
            // 
            // lblAsyncConnection1
            // 
            this.lblAsyncConnection1.AutoSize = true;
            this.lblAsyncConnection1.Location = new System.Drawing.Point(214, 114);
            this.lblAsyncConnection1.Name = "lblAsyncConnection1";
            this.lblAsyncConnection1.Size = new System.Drawing.Size(0, 13);
            this.lblAsyncConnection1.TabIndex = 10;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 335);
            this.Controls.Add(this.lblAsyncConnection1);
            this.Controls.Add(this.btnAsyncConnection1);
            this.Controls.Add(this.lblDownloadStringV5);
            this.Controls.Add(this.btnDownloadStringV5);
            this.Controls.Add(this.lblDownloadStringV3);
            this.Controls.Add(this.btnDownloadStringV2);
            this.Controls.Add(this.lblDownloadStringV1);
            this.Controls.Add(this.edOutput);
            this.Controls.Add(this.btnDownloadStringV1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "MainForm";
            this.Text = "Testing async/await";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDownloadStringV1;
        private System.Windows.Forms.TextBox edOutput;
        private System.Windows.Forms.Label lblDownloadStringV1;
        private System.Windows.Forms.Button btnDownloadStringV2;
        private System.Windows.Forms.Label lblDownloadStringV3;
        private System.Windows.Forms.Button btnDownloadStringV5;
        private System.Windows.Forms.Label lblDownloadStringV5;
        private System.Windows.Forms.Button btnAsyncConnection1;
        private System.Windows.Forms.Label lblAsyncConnection1;
    }
}

