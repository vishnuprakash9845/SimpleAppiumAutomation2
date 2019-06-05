using NativeApplicationsTest.PageObjects;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace NativeApplicationsTest.PageActions
{
    public class CameraHomeAction
    {
        private readonly CameraHomePage _pageInstance;
        private AppiumDriver<IWebElement> driver;
        public CameraHomeAction(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            _pageInstance = new CameraHomePage(driver);
        }

        public void ClickOnPermissionAllow()
        {
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            if(_pageInstance.PermissionAllowButton.Displayed)
                _pageInstance.PermissionAllowButton.Click();
        }

        public void ClickOnPermissionDeny()
        {
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            if(_pageInstance.PermissionDenyButton.Displayed)
                _pageInstance.PermissionDenyButton.Click();
        }

        public void HandleInitialClicks()
        {
            bool isDisplayed = false;
            //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            isDisplayed = _pageInstance.NextButton.Displayed;
            do
            {
                if (isDisplayed)
                {
                    int x = driver.Manage().Window.Size.Height/2;
                    int y = driver.Manage().Window.Size.Width/2;

                    IWebElement ele= driver.FindElementByXPath("//android.view.ViewGroup[@resource-id='com.motorola.camera:id/settings_rotate_layout2']");
                    IWebElement ele2 = driver.FindElementByXPath("//android.widget.RelativeLayout[@resource-id='com.motorola.camera:id/sub_main']");

                    WaitForMoment(5);

                    ITouchAction a1 = new TouchAction(driver);
                    a1.Tap(ele2, 590, 1108);

                    TouchAction touchAction = new TouchAction(driver);
                    touchAction.Tap(ele,572,1107,1).Perform();

                }
                //driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
                isDisplayed = _pageInstance.NextButton.Displayed;
            } while (isDisplayed);            
            
        }

        public static void WaitForMoment(int value)
        {
            Thread.Sleep(value * 1000);
        }
    }
}
