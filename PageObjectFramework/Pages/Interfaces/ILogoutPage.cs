namespace PageObjectFramework.Pages.Interfaces
{
    public interface ILogoutPage
    {
        string GetPageTitel();
        void Shutown();
        bool VerifyElementDisplayed(string selector);
        T ClickOnLoginAppLink<T>() where T : class;
        bool VerifyLogoutText(string emailText);
    }
}
