using System;
using AngleSharp.Dom;
using static OpenQA.Selenium.BiDi.Modules.Network.AuthCredentials;

namespace MsTestBase.UI.PageModels
{
	public class PdfDocument : IDisposable
    {
        private string _filePath;
        private FileStream _fileStream;

        public int NumberOfPages { get; private set; }

        private List<PdfPage> Pages { get; set; }

        private PdfDocument(string path)
        {
            _filePath = path;
            _fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);

            // Logic to read the PDF, populate pages, and set NumberOfPages
        }

        public static PdfDocument Open(string path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentException("File path cannot be null or empty.", nameof(path));
            }

            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File not found.", path);
            }

            return new PdfDocument(path);
        }

        public PdfPage GetPage(int pageIndex)
        {
            if (pageIndex < 0 || pageIndex >= NumberOfPages)
            {
                throw new ArgumentOutOfRangeException(nameof(pageIndex), "Invalid page index.");
            }

            return Pages[pageIndex];
        }

        public void Dispose()
        {
            _fileStream?.Close();
            _fileStream?.Dispose();
        }
    }
}

