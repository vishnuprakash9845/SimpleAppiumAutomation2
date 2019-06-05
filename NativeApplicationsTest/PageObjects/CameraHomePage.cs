using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NativeApplicationsTest.PageObjects
{
    public class CameraHomePage
    {
        private AppiumDriver<IWebElement> driver;
        private WebDriverWait wait;

        public CameraHomePage(AppiumDriver<IWebElement> driver)
        {
            this.driver = driver;
            //wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(20));
        }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Allow']")]
        public IWebElement PermissionAllowButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.widget.Button[@text='Deny']")]
        public IWebElement PermissionDenyButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//android.view.View[@resource-id='com.motorola.camera:id/preview_surface']")]
        public IWebElement NextButton { get; set; }

        //public AppiumWebElement NextButton()
        //{
        //    var t = driver.FindElementsByClassName("android.view.ViewGroup");
        //    var tt = driver.FindElementsByXPath("//android.view.ViewGroup[@resource-id='com.motorola.camera:id/settings_rotate_layout']");
        //    var ttt = driver.FindElementsByXPath("//*[@resource-id='com.motorola.camera:id/settings_rotate_layout']");
        //    var tttt = driver.FindElementsByXPath("//android.view.ViewGroup[@index='0']");
        //    return (AppiumWebElement)ttt[1];
        //}

    }
}
