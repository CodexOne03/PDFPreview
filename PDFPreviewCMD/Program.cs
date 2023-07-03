using PdfSharp.Drawing;
using PdfSharp.Pdf.IO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PDFPreviewCMD
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
                if (args[0] == "?" || args[0].ToLower() == "help" || args[0].ToLower() == "-help" || args.Length != 7)
                {
                    Console.WriteLine("Help:");
                    PrintHelp();
                }
                else
                {
                    string pdfFilePath = args[0];
                    string signatureFilePath = args[1];
                    int pageNumber;
                    int signatureXPosition;
                    int signatureYPosition;
                    int signatureWidth;
                    string outputPdfPath = args[6];
                    var outputPdfFI = new FileInfo(outputPdfPath);
                    if (File.Exists(pdfFilePath) && File.Exists(signatureFilePath) && int.TryParse(args[2], out pageNumber) && int.TryParse(args[3], out signatureXPosition) && int.TryParse(args[4], out signatureYPosition) && int.TryParse(args[5], out signatureWidth) && outputPdfFI.Directory.Exists)
                    {
                        FileInfo pdfFI = new FileInfo(pdfFilePath);
                        FileInfo signatureFI = new FileInfo(signatureFilePath);
                        //"PNG (*.png)|*.png|JPEG (*.jpg)|*.jpg|BITMAP (*.bmp)|*.bmp";
                        var signatureExt = signatureFI.Extension.ToLower();
                        if (pdfFI.Extension.ToLower() == ".pdf" && (signatureExt == ".png" || signatureExt == ".jpg" || signatureExt == ".bmp"))
                        {
                            Console.WriteLine($"Opening file \"{pdfFI.FullName}\"");
                            var pdf = PdfReader.Open(pdfFilePath, PdfDocumentOpenMode.Modify);
                            var pagMsg = pdf.PageCount > 1 ? $"The document has {pdf.PageCount} pages" : $"The document has {pdf.PageCount} page";
                            Console.WriteLine(pagMsg);
                            if (pageNumber <= pdf.PageCount && pageNumber > 1)
                            {
                                Console.WriteLine($"Loading page {pageNumber}");
                                var page = pdf.Pages[pageNumber - 1];
                                var gfx = XGraphics.FromPdfPage(page);
                                XImage signature = XImage.FromFile(signatureFilePath);
                                int signatureHeight = (int)(signatureWidth * signature.Height / signature.Width);
                                Console.WriteLine($"Applying signature at {signatureXPosition}x{signatureYPosition} with a size of {signatureWidth}x{signatureHeight}");
                                gfx.DrawImage(signature, signatureXPosition, signatureYPosition, signatureWidth, signatureHeight);
                                Console.WriteLine($"Saving edited pdf as {outputPdfFI.FullName}");
                                pdf.Save(outputPdfPath);
                            }
                            else
                            {
                                Console.WriteLine("Invalid page number");
                                PrintHelp();
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid file format");
                            PrintHelp();
                        }
                    }
                    else
                    {
                        if (!File.Exists(pdfFilePath))
                        {
                            Console.WriteLine("Invalid input pdf path:");
                            Console.WriteLine(pdfFilePath);
                        }
                        if (!File.Exists(signatureFilePath))
                        {
                            Console.WriteLine("Invalid signature path:");
                            Console.WriteLine(signatureFilePath);
                        }
                        if (!int.TryParse(args[2], out pageNumber))
                        {
                            Console.WriteLine("Invalid page number:");
                            Console.WriteLine(args[2]);
                        }
                        if (!int.TryParse(args[3], out signatureXPosition))
                        {
                            Console.WriteLine("Invalid signature X position:");
                            Console.WriteLine(args[3]);
                        }
                        if (!int.TryParse(args[4], out signatureYPosition))
                        {
                            Console.WriteLine("Invalid signature Y position:");
                            Console.WriteLine(args[4]);
                        }
                        if (!int.TryParse(args[5], out signatureWidth))
                        {
                            Console.WriteLine("Invalid signature width:");
                            Console.WriteLine(args[5]);
                        }
                        if (!outputPdfFI.Directory.Exists)
                        {
                            Console.WriteLine("Invalid output pdf path:");
                            Console.WriteLine(outputPdfPath);
                        }
                        PrintHelp();
                    }
                }
            }
        }

        private static void PrintHelp()
        {
            //PDFPreviewCMD.exe "C:\Users\ferra\source\repos\PDFSignature\PDFPreviewCMD\bin\Debug\Asimov-Isaac-I-Robot.pdf" "C:\Users\ferra\source\repos\PDFSignature\PDFPreviewCMD\bin\Debug\Isaac_Asimov_signature.svg.png" 1 10 10 100
            Console.WriteLine("Command sintax:\nPDFPreview.exe pdfFilePath signatureFilePath pageNumber signatureXPosition signatureYPosition signatureWidth outputPdfPath\nFor example: PDFPreviewCMD.exe \"Asimov-Isaac-I-Robot.pdf\" \"Isaac_Asimov_signature.svg.png\" 1 10 10 100 \"Asimov-Isaac-I-Robot-signed.pdf\"");
        }
    }
}
