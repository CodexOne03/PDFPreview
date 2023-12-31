﻿using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace PDFPreview
{
    public partial class PdfPreview : Form
    {
        string pdfPath;
        string signaturePath;
        PdfSharp.Pdf.PdfDocument pdf;
        Image signature;

        public PdfPreview()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select the pdf file";
            openFileDialog1.Filter = "Portable Document Format (*.pdf)|*.pdf";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pdfPath = openFileDialog1.FileName;
                var pdfFileInfo = new FileInfo(pdfPath);
                openFileDialog1.Title = "Select the signature image";
                openFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BITMAP (*.bmp)|*.bmp";
                result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    signaturePath = openFileDialog1.FileName;
                    signature = Image.FromFile(signaturePath);

                    pageNumeric.Minimum = 1;
                    pageNumeric.Maximum = pdf.PageCount;
                    xNumeric.Minimum = 0;
                    xNumeric.Maximum = decimal.MaxValue;
                    xNumeric.Value = 10;
                    yNumeric.Minimum = 0;
                    yNumeric.Maximum = decimal.MaxValue;
                    yNumeric.Value = 10;
                    sizeNumeric.Minimum = 0;
                    sizeNumeric.Maximum = decimal.MaxValue;
                    sizeNumeric.Value = 100;

                    UpdatePdf();
                }
            }
        }

        private void UpdatePdf()
        {
            var scroll = pdfViewer1.VerticalScroll.Value;
            pdf = PdfReader.Open(pdfPath, PdfDocumentOpenMode.Modify);
            var page = pdf.Pages[Convert.ToInt32(pageNumeric.Value - 1)];
            var gfx = XGraphics.FromPdfPage(page);
            XImage signature = XImage.FromFile(signaturePath);
            gfx.DrawImage(signature, Convert.ToInt32(xNumeric.Value), Convert.ToInt32(yNumeric.Value), Convert.ToInt32(sizeNumeric.Value), Convert.ToInt32(sizeNumeric.Value) * signature.Height / signature.Width);
            MemoryStream stream = new MemoryStream();
            pdf.Save(stream);
            if (pdfViewer1.Document != null)
            {
                pdfViewer1.CloseDocument();
            }
            pdfViewer1.LoadDocument(stream);
            pdfViewer1.VerticalScroll.Value = scroll;
            pdfViewer1.AutoScrollPosition = new Point(pdfViewer1.HorizontalScroll.Value, scroll);
        }

        private void ControlValueChanged(object sender, EventArgs e)
        {
            UpdatePdf();
            //pdfViewer1.ScrollToPage(Convert.ToInt32(pageNumeric.Value - 1));
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "Portable Document Format (*.pdf)|*.pdf";
            var result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pdf.Save(saveFileDialog1.FileName);
                MessageBox.Show("Done");
            }
        }

        private void changePdfButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select the pdf file";
            openFileDialog1.Filter = "Portable Document Format (*.pdf)|*.pdf";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                pdfPath = openFileDialog1.FileName;
                var pdfFileInfo = new FileInfo(pdfPath);
                openFileDialog1.Title = "Select the signature image";
                openFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BITMAP (*.bmp)|*.bmp";
                result = openFileDialog1.ShowDialog();
                if (result == DialogResult.OK)
                {
                    signaturePath = openFileDialog1.FileName;
                    signature = Image.FromFile(signaturePath);

                    pageNumeric.Value = 1;

                    UpdatePdf();

                    pageNumeric.Minimum = 1;
                    pageNumeric.Maximum = pdf.PageCount;
                    xNumeric.Minimum = 0;
                    xNumeric.Maximum = decimal.MaxValue;
                    xNumeric.Value = 10;
                    yNumeric.Minimum = 0;
                    yNumeric.Maximum = decimal.MaxValue;
                    yNumeric.Value = 10;
                    sizeNumeric.Minimum = 0;
                    sizeNumeric.Maximum = decimal.MaxValue;
                    sizeNumeric.Value = 100;
                }
            }
        }

        private void changeSignatureButton_Click(object sender, EventArgs e)
        {
            openFileDialog1.Title = "Select the signature image";
            openFileDialog1.Filter = "PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BITMAP (*.bmp)|*.bmp";
            var result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                signaturePath = openFileDialog1.FileName;
                signature = Image.FromFile(signaturePath);

                UpdatePdf();
            }
        }

        Point startingMousePoint;
        private void pdfViewer1_MouseDown(object sender, MouseEventArgs e)
        {
            startingMousePoint = e.Location;
        }

        private void pdfViewer1_MouseUp(object sender, MouseEventArgs e)
        {
            if (startingMousePoint != null)
            {
                Point size = new Point(Math.Abs(e.Location.X - startingMousePoint.X), Math.Abs(e.Location.Y - startingMousePoint.Y));
                if (e.Location.X < startingMousePoint.X && e.Location.Y < startingMousePoint.Y)
                {
                    HandleMouseClickPlacement(e.Location, size);
                }
                else if (e.Location.X < startingMousePoint.X && e.Location.Y > startingMousePoint.Y)
                {
                    HandleMouseClickPlacement(new Point(e.Location.X, startingMousePoint.Y), size);
                }
                else if (e.Location.X > startingMousePoint.X && e.Location.Y < startingMousePoint.Y)
                {
                    HandleMouseClickPlacement(new Point(startingMousePoint.X, e.Location.Y), size);
                }
                else if (e.Location.X > startingMousePoint.X && e.Location.Y > startingMousePoint.Y)
                {
                    HandleMouseClickPlacement(startingMousePoint, size);
                }
            }
        }

        private void HandleMouseClickPlacement(Point location, Point size)
        {
            var page = pdfViewer1.PointInPage(location);
            var pagePoint = pdfViewer1.ClientToPage(page, location);
            this.xNumeric.Value = (decimal)Math.Min(Math.Max(pagePoint.X, 0), pdfViewer1.Size.Width);
            this.yNumeric.Value = (decimal)Math.Min(Math.Max(pdfViewer1.Document.Pages[0].Height - pagePoint.Y, 0), pdfViewer1.Size.Width);
            this.sizeNumeric.Value = (decimal)this.pdfViewer1.ClientToPage(page, size).X;
            this.pageNumeric.Value = (decimal)page + 1;
        }
    }
}
