namespace ReceiptTransformer
{
    partial class frmReceiptTransformer
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
            this.btnTransform = new System.Windows.Forms.Button();
            this.txtOutput = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.btnCopy = new System.Windows.Forms.Button();
            this.txtInput = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnOpen = new System.Windows.Forms.Button();
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.linkNewVersion = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // btnTransform
            // 
            this.btnTransform.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnTransform.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.btnTransform.Location = new System.Drawing.Point(12, 408);
            this.btnTransform.Name = "btnTransform";
            this.btnTransform.Size = new System.Drawing.Size(172, 56);
            this.btnTransform.TabIndex = 4;
            this.btnTransform.Text = "&Transform";
            this.btnTransform.UseVisualStyleBackColor = true;
            this.btnTransform.Click += new System.EventHandler(this.btnTransform_Click);
            // 
            // txtOutput
            // 
            this.txtOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtOutput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtOutput.Location = new System.Drawing.Point(503, 39);
            this.txtOutput.Multiline = true;
            this.txtOutput.Name = "txtOutput";
            this.txtOutput.ReadOnly = true;
            this.txtOutput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtOutput.Size = new System.Drawing.Size(488, 361);
            this.txtOutput.TabIndex = 3;
            // 
            // lblCount
            // 
            this.lblCount.AutoSize = true;
            this.lblCount.Location = new System.Drawing.Point(909, 403);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(62, 13);
            this.lblCount.TabIndex = 7;
            this.lblCount.Text = "x total items";
            // 
            // btnCopy
            // 
            this.btnCopy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCopy.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCopy.Location = new System.Drawing.Point(503, 406);
            this.btnCopy.Name = "btnCopy";
            this.btnCopy.Size = new System.Drawing.Size(166, 56);
            this.btnCopy.TabIndex = 6;
            this.btnCopy.Text = "&Copy DPCIs";
            this.btnCopy.UseVisualStyleBackColor = true;
            this.btnCopy.Click += new System.EventHandler(this.btnCopy_Click);
            // 
            // txtInput
            // 
            this.txtInput.AllowDrop = true;
            this.txtInput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInput.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtInput.Location = new System.Drawing.Point(12, 39);
            this.txtInput.Multiline = true;
            this.txtInput.Name = "txtInput";
            this.txtInput.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtInput.Size = new System.Drawing.Size(485, 361);
            this.txtInput.TabIndex = 2;
            this.txtInput.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragDrop);
            this.txtInput.DragOver += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragOver);
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            this.btnClear.Location = new System.Drawing.Point(244, 418);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(119, 35);
            this.btnClear.TabIndex = 5;
            this.btnClear.Text = "C&lear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Text Files|*.txt";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(369, 10);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(134, 23);
            this.btnOpen.TabIndex = 1;
            this.btnOpen.Text = "&Open Transaction...";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.btnOpen_Click);
            // 
            // txtFilePath
            // 
            this.txtFilePath.AllowDrop = true;
            this.txtFilePath.Location = new System.Drawing.Point(12, 12);
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.Size = new System.Drawing.Size(351, 20);
            this.txtFilePath.TabIndex = 0;
            this.txtFilePath.DragDrop += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragDrop);
            this.txtFilePath.DragOver += new System.Windows.Forms.DragEventHandler(this.txtFilePath_DragOver);
            this.txtFilePath.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtFilePath_KeyDown);
            this.txtFilePath.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFilePath_KeyPress);
            this.txtFilePath.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtFilePath_KeyUp);
            // 
            // linkNewVersion
            // 
            this.linkNewVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.linkNewVersion.AutoSize = true;
            this.linkNewVersion.Enabled = false;
            this.linkNewVersion.Location = new System.Drawing.Point(839, 15);
            this.linkNewVersion.Name = "linkNewVersion";
            this.linkNewVersion.Size = new System.Drawing.Size(132, 13);
            this.linkNewVersion.TabIndex = 8;
            this.linkNewVersion.TabStop = true;
            this.linkNewVersion.Text = "A new version is available!";
            this.linkNewVersion.Visible = false;
            this.linkNewVersion.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkNewVersion_LinkClicked);
            // 
            // frmReceiptTransformer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1007, 476);
            this.Controls.Add(this.linkNewVersion);
            this.Controls.Add(this.btnOpen);
            this.Controls.Add(this.txtFilePath);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtInput);
            this.Controls.Add(this.btnCopy);
            this.Controls.Add(this.lblCount);
            this.Controls.Add(this.txtOutput);
            this.Controls.Add(this.btnTransform);
            this.Name = "frmReceiptTransformer";
            this.Text = "Receipt Transformer - Version 1.1";
            this.Load += new System.EventHandler(this.frmReceiptTransformer_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnTransform;
        private System.Windows.Forms.TextBox txtOutput;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.Button btnCopy;
        private System.Windows.Forms.TextBox txtInput;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.LinkLabel linkNewVersion;
    }
}

