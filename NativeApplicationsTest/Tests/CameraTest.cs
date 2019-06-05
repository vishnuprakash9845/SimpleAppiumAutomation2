using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using NativeApplicationsTest.PageActions;

namespace NativeApplicationsTest.Tests
{
    [TestClass]
    public class CameraTest
    {
        AppiumDriver<IWebElement> driver = null;
        public static AppiumLocalService appiumLocalService = null;
        public static DesiredCapabilities cap;
        private static TestContext testContext;

        [ClassInitialize]
        public static void InitTestSuite(TestContext context)
        {
            testContext = context;

            appiumLocalService = new AppiumServiceBuilder()
                                 .UsingPort(4723)
                                 .WithAppiumJS(new System.IO.FileInfo(@"C:\Program Files (x86)\Appium\resources\app\node_modules\appium\build\lib\main.js"))
                                 .Build();

            if (!appiumLocalService.IsRunning)
                appiumLocalService.Start();
        }

        [ClassCleanup()]
        public static void CleanupTestSuite()
        {
            if (appiumLocalService.IsRunning)
                appiumLocalService.Dispose();
        }

        [TestInitialize]
        public void TestSetUp()
        {
            cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("appPackage", "com.motorola.camera");
            cap.SetCapability("appActivity", "com.motorola.camera.Camera");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
        }

        [TestMethod]
        [TestCategory("Sanity_Camera")]
        public void LaunchingMobileCameraTest()
        {
            CameraHomeAction action = new CameraHomeAction(driver);
            Console.WriteLine("Test Execution Started");

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            action.ClickOnPermissionAllow();

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_Camera")]
        public void TakingPhotoTest()
        {
            CameraHomeAction action = new CameraHomeAction(driver);
            Console.WriteLine("Test Execution Started");

            action.ClickOnPermissionAllow();
            action.HandleInitialClicks();

            Console.WriteLine("Test Execution Completed");
        }
    }
}
