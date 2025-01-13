using System;
namespace MsTestBase
{
    public class Config
    {
        public string CareerSiteURL { get; set; } 
        public int MaxTimeOutSeconds { get; set; }
        public bool ScreenshotOnAssert { get; set; }
        public bool F1TakeScreenshot { get; set; }
        public static TimeSpan DefaultTimeout => TimeSpan.FromSeconds(30);
    }

    
}

