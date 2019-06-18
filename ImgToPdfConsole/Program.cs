using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Drawing;
using ImgToPdf;

namespace ImgToPdfConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //var stream = new MemoryStream(file);
            var img = Image.FromFile("C:\\1.jpg");

            var pdf = ImageToPdfConvetrer.ImageToPdf(img);
            pdf.Save("D:\\2.PDF");
        }
    }
}
