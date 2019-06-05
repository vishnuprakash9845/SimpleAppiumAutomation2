using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ImageFormat = System.Drawing.Imaging.ImageFormat;

namespace NativeApplicationsTest
{
    public class Utilities
    {
        public enum CalculatorOperations
        {
            Add=1,
            Subtract=2,
            Multiply=3,
            Divide=4,
            Equals=5,
            Delete=6

        }

        public enum ScrollOptions
        {
            up = 1,
            down = 2,
        }

        public enum SelectorOptions
        {
            AccessibilityId = 1,
            ClassName = 2,
            Id = 3,
            LinkText = 4,
            Name = 5,
            PartialLinkText = 6,
            TagName = 7,
            XPath = 8
        }

        public void VerticalSwipeDown(AppiumDriver<IWebElement> driver)
        {
            int height = driver.Manage().Window.Size.Height;
            int width = driver.Manage().Window.Size.Width;
            int x = width / 2;
            int starty = (int)(height * 0.6);
            int endy = (int)(height * 0.3);
            driver.Swipe(x, starty, x, endy, 1000);
        }

        public void VerticalSwipeUp(AppiumDriver<IWebElement> driver)
        {
            int height = driver.Manage().Window.Size.Height;
            int width = driver.Manage().Window.Size.Width;
            int x = width / 2;
            int starty = (int)(height * 0.20);
            int endy = (int)(height * 0.80);
            driver.Swipe(x, starty, x, endy, 1000);
        }

        public void HorizontalSwipeLeft(AppiumDriver<IWebElement> driver)
        {
            int height = driver.Manage().Window.Size.Height;
            int width = driver.Manage().Window.Size.Width;
            int y = (int)(height * 0.20);
            int startx = (int)(width * 0.85);
            int endx = (int)(width * 0.01);
            driver.Swipe(startx, y, endx, y, 1000);
        }

        public void HorizontalSwipeRight(AppiumDriver<IWebElement> driver)
        {
            int height = driver.Manage().Window.Size.Height;
            int width = driver.Manage().Window.Size.Width;
            int y = (int)(height * 0.20);
            int startx = (int)(width * 0.01);
            int endx = (int)(width * 0.85);
            driver.Swipe(startx, y, endx, y, 1000);
        }
        public void getScreenShotMobile(AppiumDriver<IWebElement> appdriver, string testCaseName)
        {
            Screenshot image = ((ITakesScreenshot)appdriver).GetScreenshot();
            string fileName = string.Format(@"C:\Auto\AppiumScreenshots\{0}.png", testCaseName + "_" + DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss"));
            image.SaveAsFile(fileName, ImageFormat.Png);
        }

        public void VerticalSwipe(AppiumDriver<IWebElement> driver,string direction)
        {
            switch (direction)
            {
                case "up":
                    VerticalSwipeUp(driver);
                    break;
                case "down":
                    VerticalSwipeDown(driver);
                    break;
                default:
                    break;
            }
        }

        public void HorizontalSwipe(AppiumDriver<IWebElement> driver, string direction)
        {
            switch (direction)
            {
                case "up":
                    HorizontalSwipeLeft(driver);
                    break;
                case "right":
                    HorizontalSwipeRight(driver);
                    break;
                default:
                    break;
            }
        }
    }
}
