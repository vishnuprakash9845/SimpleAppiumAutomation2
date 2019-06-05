using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using NativeApplicationsTest.PageActions;

namespace NativeApplicationsTest
{
    /// <summary>
    /// Summary description for PhoneSanityTests
    /// </summary>
    [TestClass]
    public class PhoneSanityTests
    {
        AppiumDriver<IWebElement> driver = null;
        public static DesiredCapabilities cap;

        [TestInitialize]
        public void TestSetUp()
        {
            cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("appPackage", "com.android.dialer");
            cap.SetCapability("appActivity", "com.android.dialer.DialtactsActivity");
        }

        [TestMethod]
        [TestCategory("Sanity_Phone")]
        public void LaunchingPhoneTest()
        {
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_Phone")]
        public void EnteringPhoneNumberTest()
        {
            string searchPersonName = "House";
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            PhoneHomeAction action = new PhoneHomeAction(driver);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            action.ClickOnSearchView();
            action.EnterNameofPerson(searchPersonName);
            bool isPresent=action.VerifyFilterName(searchPersonName);

            Console.WriteLine("Person by Name {0} present: {1}", searchPersonName, isPresent);


            Console.WriteLine("Test Execution Completed");
        }

    }
}
