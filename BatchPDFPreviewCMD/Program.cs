using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BatchPDFPreviewCMD
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length == 0)
            {
                PrintHelp();
            }
            else
            {
                if (args[0] == "?" || args[0].ToLower() == "help" || args[0].ToLower() == "-help" || args.Length < 7)
                {
                    Console.WriteLine("Help:");
                    PrintHelp();
                }
                else
                {
                    string pdfFilePath = args[0];
                    string signatureFilePath = args[1];
                    int signatureXPosition = int.Parse(args[2]);
                    int signatureYPosition = int.Parse(args[3]);
                    int signatureWidth = int.Parse(args[4]);
                    string outputPdfPath = args[5];
                    int[] pageNumbers;
                    var outputPdfFI = new FileInfo(outputPdfPath);
                    pageNumbers = new int[args.Length - 6];
                    if (args[6] == "all")
                    {
                        FileInfo pdfFI = new FileInfo(pdfFilePath);
                        FileInfo signatureFI = new FileInfo(signatureFilePath);
                        Console.WriteLine($"Opening file \"{pdfFI.FullName}\"");
                        var pdf = PdfReader.Open(pdfFilePath, PdfDocumentOpenMode.Modify);
                        var pagMsg = pdf.PageCount > 1 ? $"The document has {pdf.PageCount} pages" : $"The document has {pdf.PageCount} page";
                        Console.WriteLine(pagMsg);
                        XImage signature = XImage.FromFile(signatureFilePath);
                        int signatureHeight = (int)(signatureWidth * signature.Height / signature.Width);
                        for (int i = 0; i < pdf.PageCount; i++)
                        {
                            Console.WriteLine($"Loading page {i + 1}");
                            var page = pdf.Pages[i];
                            var gfx = XGraphics.FromPdfPage(page);
                            Console.WriteLine($"Applying signature at {signatureXPosition}x{signatureYPosition} with a size of {signatureWidth}x{signatureHeight}");
                            gfx.DrawImage(signature, signatureXPosition, signatureYPosition, signatureWidth, signatureHeight);
                        }
                        Console.WriteLine($"Saving edited pdf as {outputPdfFI.FullName}");
                        pdf.Save(outputPdfPath);
                    }
                    else
                    {
                        for (int i = 6, j = 0; i < args.Length; i++, j++)
                        {
                            pageNumbers[j] = int.Parse(args[i]);
                        }
                        FileInfo pdfFI = new FileInfo(pdfFilePath);
                        FileInfo signatureFI = new FileInfo(signatureFilePath);
                        Console.WriteLine($"Opening file \"{pdfFI.FullName}\"");
                        var pdf = PdfReader.Open(pdfFilePath, PdfDocumentOpenMode.Modify);
                        var pagMsg = pdf.PageCount > 1 ? $"The document has {pdf.PageCount} pages" : $"The document has {pdf.PageCount} page";
                        Console.WriteLine(pagMsg);
                        XImage signature = XImage.FromFile(signatureFilePath);
                        int signatureHeight = (int)(signatureWidth * signature.Height / signature.Width);
                        foreach (var pageNumber in pageNumbers)
                        {
                            Console.WriteLine($"Loading page {pageNumber}");
                            var page = pdf.Pages[pageNumber - 1];
                            var gfx = XGraphics.FromPdfPage(page);
                            Console.WriteLine($"Applying signature at {signatureXPosition}x{signatureYPosition} with a size of {signatureWidth}x{signatureHeight}");
                            gfx.DrawImage(signature, signatureXPosition, signatureYPosition, signatureWidth, signatureHeight);
                        }
                        Console.WriteLine($"Saving edited pdf as {outputPdfFI.FullName}");
                        pdf.Save(outputPdfPath);
                    }
                }
            }
        }

        private static void PrintHelp()
        {
            Console.WriteLine("Command sintax:\nPDFPreview.exe pdfFilePath signatureFilePath signatureXPosition signatureYPosition signatureWidth outputPdfPath pageNumber(s)\nFor example: PDFPreviewCMD.exe \"Asimov-Isaac-I-Robot.pdf\" \"Isaac_Asimov_signature.svg.png\" 1 10 10 100 \"Asimov-Isaac-I-Robot-signed.pdf\" all");
            Console.ReadLine();
        }
    }
}
