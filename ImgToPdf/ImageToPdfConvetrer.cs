using PdfSharp.Drawing;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ImgToPdf
{
    public static class ImageToPdfConvetrer
    {
        public static PdfDocument ImageToPdf(string ImageFileName)
        {
            return ImageToPdfConvetrer.ImageToPdf((IEnumerable<string>)new string[1]
            {
        ImageFileName
            });
        }

        public static PdfDocument ImageToPdf(IEnumerable<string> fileNames)
        {
            List<Image> imageList = new List<Image>();
            foreach (string imageFileName in fileNames)
                imageList.Add(Image.FromFile(imageFileName));
            PdfDocument pdf = ImageToPdfConvetrer.ImageToPdf((IEnumerable<Image>)imageList);
            foreach (Image image in imageList)
                image.Dispose();
            return pdf;
        }

        public static PdfDocument ImageToPdf(Image Image)
        {
            return ImageToPdfConvetrer.ImageToPdf((IEnumerable<Image>)new Image[1]
            {
        Image
            });
        }

        public static PdfDocument ImageToPdf(IEnumerable<Image> Images)
        {
            PdfDocument pdfDocument = new PdfDocument();
            foreach (Image image in Images)
            {
                PdfPage pdfPage = pdfDocument.AddPage();
                pdfPage.Width = image.Width;
                pdfPage.Height = image.Height;
                pdfPage.TrimMargins.All = XUnit.Zero;
                ImageToPdfConvetrer.aaa(XGraphics.FromPdfPage(pdfPage), image, 0, 0);
            }
            return pdfDocument;
        }

        private static void aaa(XGraphics _param0, Image _param1, int _param2, int _param3)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                _param1.Save((Stream)memoryStream, ImageFormat.Png);
                XImage ximage = XImage.FromStream((Stream)memoryStream);
                _param0.DrawImage(ximage, (double)_param2, (double)_param3, (double)_param1.Width, (double)_param1.Height);
            }
        }
    }
}
