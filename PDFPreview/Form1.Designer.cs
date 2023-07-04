
namespace PDFPreview
{
    partial class PdfPreview
    {
        /// <summary>
        /// Variabile di progettazione necessaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Pulire le risorse in uso.
        /// </summary>
        /// <param name="disposing">ha valore true se le risorse gestite devono essere eliminate, false in caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Codice generato da Progettazione Windows Form

        /// <summary>
        /// Metodo necessario per il supporto della finestra di progettazione. Non modificare
        /// il contenuto del metodo con l'editor di codice.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PdfPreview));
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pdfViewer1 = new Patagames.Pdf.Net.Controls.WinForms.PdfViewer();
            this.xNumeric = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.sizeNumeric = new System.Windows.Forms.NumericUpDown();
            this.yNumeric = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.pageNumeric = new System.Windows.Forms.NumericUpDown();
            this.saveButton = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.changePdfButton = new System.Windows.Forms.Button();
            this.changeSignatureButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pdfViewer1
            // 
            this.pdfViewer1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.pdfViewer1.CurrentIndex = -1;
            this.pdfViewer1.CurrentPageHighlightColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.Document = null;
            this.pdfViewer1.FormHighlightColor = System.Drawing.Color.Transparent;
            this.pdfViewer1.FormsBlendMode = Patagames.Pdf.Enums.BlendTypes.FXDIB_BLEND_MULTIPLY;
            this.pdfViewer1.LoadingIconText = "Loading...";
            this.pdfViewer1.Location = new System.Drawing.Point(12, 60);
            this.pdfViewer1.MouseMode = Patagames.Pdf.Net.Controls.WinForms.MouseModes.Default;
            this.pdfViewer1.Name = "pdfViewer1";
            this.pdfViewer1.OptimizedLoadThreshold = 1000;
            this.pdfViewer1.Padding = new System.Windows.Forms.Padding(10);
            this.pdfViewer1.PageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.pdfViewer1.PageAutoDispose = true;
            this.pdfViewer1.PageBackColor = System.Drawing.Color.White;
            this.pdfViewer1.PageBorderColor = System.Drawing.Color.Black;
            this.pdfViewer1.PageMargin = new System.Windows.Forms.Padding(10);
            this.pdfViewer1.PageSeparatorColor = System.Drawing.Color.Gray;
            this.pdfViewer1.RenderFlags = ((Patagames.Pdf.Enums.RenderFlags)((Patagames.Pdf.Enums.RenderFlags.FPDF_LCD_TEXT | Patagames.Pdf.Enums.RenderFlags.FPDF_NO_CATCH)));
            this.pdfViewer1.ShowCurrentPageHighlight = true;
            this.pdfViewer1.ShowLoadingIcon = true;
            this.pdfViewer1.ShowPageSeparator = true;
            this.pdfViewer1.Size = new System.Drawing.Size(776, 378);
            this.pdfViewer1.SizeMode = Patagames.Pdf.Net.Controls.WinForms.SizeModes.FitToWidth;
            this.pdfViewer1.TabIndex = 0;
            this.pdfViewer1.TextSelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(130)))), ((int)(((byte)(180)))));
            this.pdfViewer1.TilesCount = 2;
            this.pdfViewer1.UseProgressiveRender = true;
            this.pdfViewer1.ViewMode = Patagames.Pdf.Net.Controls.WinForms.ViewModes.Vertical;
            this.pdfViewer1.Zoom = 1F;
            this.pdfViewer1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pdfViewer1_MouseDown);
            this.pdfViewer1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pdfViewer1_MouseUp);
            // 
            // xNumeric
            // 
            this.xNumeric.Location = new System.Drawing.Point(143, 7);
            this.xNumeric.Name = "xNumeric";
            this.xNumeric.Size = new System.Drawing.Size(40, 20);
            this.xNumeric.TabIndex = 1;
            this.xNumeric.ValueChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Position";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(235, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Size";
            // 
            // sizeNumeric
            // 
            this.sizeNumeric.Location = new System.Drawing.Point(268, 7);
            this.sizeNumeric.Name = "sizeNumeric";
            this.sizeNumeric.Size = new System.Drawing.Size(40, 20);
            this.sizeNumeric.TabIndex = 3;
            this.sizeNumeric.ValueChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // yNumeric
            // 
            this.yNumeric.Location = new System.Drawing.Point(189, 7);
            this.yNumeric.Name = "yNumeric";
            this.yNumeric.Size = new System.Drawing.Size(40, 20);
            this.yNumeric.TabIndex = 7;
            this.yNumeric.ValueChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(9, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 11;
            this.label4.Text = "Page";
            // 
            // pageNumeric
            // 
            this.pageNumeric.Location = new System.Drawing.Point(47, 7);
            this.pageNumeric.Name = "pageNumeric";
            this.pageNumeric.Size = new System.Drawing.Size(40, 20);
            this.pageNumeric.TabIndex = 10;
            this.pageNumeric.ValueChanged += new System.EventHandler(this.ControlValueChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(314, 4);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 12;
            this.saveButton.Text = "Save pdf";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // changePdfButton
            // 
            this.changePdfButton.Location = new System.Drawing.Point(395, 4);
            this.changePdfButton.Name = "changePdfButton";
            this.changePdfButton.Size = new System.Drawing.Size(75, 23);
            this.changePdfButton.TabIndex = 13;
            this.changePdfButton.Text = "Change pdf";
            this.changePdfButton.UseVisualStyleBackColor = true;
            this.changePdfButton.Click += new System.EventHandler(this.changePdfButton_Click);
            // 
            // changeSignatureButton
            // 
            this.changeSignatureButton.Location = new System.Drawing.Point(476, 4);
            this.changeSignatureButton.Name = "changeSignatureButton";
            this.changeSignatureButton.Size = new System.Drawing.Size(103, 23);
            this.changeSignatureButton.TabIndex = 14;
            this.changeSignatureButton.Text = "Change signature";
            this.changeSignatureButton.UseVisualStyleBackColor = true;
            this.changeSignatureButton.Click += new System.EventHandler(this.changeSignatureButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(585, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "label3";
            // 
            // PdfPreview
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.changeSignatureButton);
            this.Controls.Add(this.changePdfButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.pageNumeric);
            this.Controls.Add(this.yNumeric);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.sizeNumeric);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.xNumeric);
            this.Controls.Add(this.pdfViewer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PdfPreview";
            this.Text = "PdfPreview";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sizeNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.yNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pageNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Patagames.Pdf.Net.Controls.WinForms.PdfViewer pdfViewer1;
        private System.Windows.Forms.NumericUpDown xNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown sizeNumeric;
        private System.Windows.Forms.NumericUpDown yNumeric;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown pageNumeric;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button changePdfButton;
        private System.Windows.Forms.Button changeSignatureButton;
        private System.Windows.Forms.Label label3;
    }
}

