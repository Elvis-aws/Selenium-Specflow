using OpenQA.Selenium;
using static CoreFramework.Enumerations.Enums;

namespace CoreFramework.BrowserConfig
{
    public static class Session
    {

       public static void StartBrowser()
        {
            BrowserSession.OpenBrowser();
            BrowserSession.GoToDesiredUrl();
        }

        public static void CloseBrowser()
        {
            BrowserSession.QuitBrowser();
           //BrowserSession.KillBrowser();
        }

        public static IWebDriver Driver
        {
            get { return BrowserSession.driver; }
        }
    }
}
