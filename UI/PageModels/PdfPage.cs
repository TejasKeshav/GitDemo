using System;
namespace MsTestBase.UI.PageModels
{
	public class PdfPage
	{
        public string Text { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }

        public PdfPage(string text, double width, double height)
        {
            Text = text;
            Width = width;
            Height = height;
        }

        public string ExtractText()
        {
            return Text;
        }
    }
}

