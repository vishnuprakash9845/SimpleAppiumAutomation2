using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;

namespace StartingAppiumServer
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void StartingAppiumServerTest()
        {
            //Starting the Appium Server
            //For Calculator Application
            //Performing the Actions on the Calculator Application
            //Starting sever with default port no
            AppiumServiceBuilder appiumServiceBuilder = new AppiumServiceBuilder()
                                                          .UsingAnyFreePort()
                                                          .WithAppiumJS(new System.IO.FileInfo(@"C:\Program Files (x86)\Appium\resources\app\node_modules\appium\build\lib\main.js"));

            AppiumLocalService appiumLocalService = appiumServiceBuilder.Build();
            if (!appiumLocalService.IsRunning)
                appiumLocalService.Start();

            DesiredCapabilities desiredCapabilities = new DesiredCapabilities();
            desiredCapabilities.SetCapability("platformName", "Android");
            desiredCapabilities.SetCapability("platformVersion", "6.0");
            desiredCapabilities.SetCapability("deviceName", "Moto G");
            desiredCapabilities.SetCapability("appPackage", "com.android.calculator2");
            desiredCapabilities.SetCapability("appActivity", "com.android.calculator2.Calculator");

            AndroidDriver<AndroidElement> androidDriver = new AndroidDriver<AndroidElement>(appiumLocalService, desiredCapabilities);

            androidDriver.FindElementById("digit_6").Click();

        }
    }
}
