using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cachet;
using Spire.Pdf;
using Spire.Pdf.Annotations;
using Spire.Pdf.Annotations.Appearance;
using Spire.Pdf.Graphics;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile(@"D:\DQ\Spire.Pdf.DEMO\WindowsFormsApp1\WindowsFormsApp1\bin\Debug\FromIMG.pdf");

            PdfRubberStampAnnotation loStamp = new PdfRubberStampAnnotation(new RectangleF(new PointF(200, 30), new SizeF(200, 200)));
            PdfAppearance loApprearance = new PdfAppearance(loStamp);
            PdfImage image = PdfImage.FromFile(@"D:\\1.png");

            PdfTemplate template = new PdfTemplate(160, 160);
            template.Graphics.DrawImage(image, 0, 0);
            loApprearance.Normal = template;
            loStamp.Appearance = loApprearance;
            foreach (PdfPageBase page in doc.Pages)
            {
                page.AnnotationsWidget.Add(loStamp);
            }
            string output = "ImageStamp.pdf";
            doc.SaveToFile(output);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            CreatPublicSeal.CreatSeal("合肥东青信息科技公司", "软件部", @"D:\");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();


            // Create one page
            PdfPageBase page = doc.Pages.Add();
            //Draw the text
            page.Canvas.DrawString("Hello, I'm Created By SPIRE.PDF!",
            new PdfFont(PdfFontFamily.TimesRoman, 30f),
            new PdfSolidBrush(Color.Black), 10, 10);
            //Save pdf file.
            doc.SaveToFile("FromHTML.pdf", FileFormat.PDF);
            doc.Close();
            System.Diagnostics.Process.Start("FromHTML.pdf");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            PdfDocument doc = new PdfDocument();

            // Create one page
            PdfPageBase page = doc.Pages.Add();

            PdfImage pdfImage = PdfImage.FromFile(@"D:\1.jpg");
            //Draw the text
            page.Canvas.DrawImage(pdfImage, new PointF(-15, -15));
            //Save pdf file.
            doc.SaveToFile("FromIMG.pdf", FileFormat.PDF);
            doc.Close();
            System.Diagnostics.Process.Start("FromIMG.pdf");
        }
    }
}
