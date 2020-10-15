﻿using System;
using OpenQA.Selenium;

namespace CoreFramework.BaseClasses
{
    public abstract partial class BaseClass
    {

        public void EnterText(By by,string text)
        {
            var element = driver.FindElement(by);

            try
            {
                HighlightElement(element);
                element.Clear();
                element.SendKeys(text);
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                element.Clear();
                foreach (var item in text)
                {
                    element.SendKeys(item.ToString());
                }
                
            }
            finally
            {
                // Report to user unable to click
            }
        }

        public bool ClickOnElement(By by)
        {
            var element = driver.FindElement(by);
            try
            {
                HighlightElement(element);
                element.Click();
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                element.Click();
            }
            finally
            {
                // Report to user unable to click
            }

            return true;
        }

        public bool ClickOnElementJavaScript(By by)
        {
            var element = driver.FindElement(by);

            try
            {
                HighlightElement(element);
                JavaScriptClick(element);
            }
            catch (Exception)
            {
                ScrollToView(element);
                HighlightElement(element);
                JavaScriptClick(element);
            }
            finally
            {
                // Report to user unable to click
            }

            return true;
        }

        private void JavaScriptClick(IWebElement element)
        {
            try
            {
                HighlightElement(element);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].click();", element);
            }
            catch (Exception e)
            {
                // Report
            }
        }

        private void ScrollToView(IWebElement element)
        {
            try
            {
                HighlightElement(element);
                IJavaScriptExecutor executor = (IJavaScriptExecutor)driver;
                executor.ExecuteScript("arguments[0].scrollIntoView(true);", element);
            }
            catch (Exception e)
            {
                // Report
            }
        }

        private void HighlightElement(IWebElement element)
        {
            var jsDriver = (IJavaScriptExecutor)driver;
            string highlightJavascript = @"$(arguments[0]).css({ ""border-width"" : ""2px"", ""border-style"" : ""solid"", ""border-color"" : ""red"", ""background"" : ""yellow"" });";
            jsDriver.ExecuteScript(highlightJavascript, new object[] { element });
        }
    }
}
