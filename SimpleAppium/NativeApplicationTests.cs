using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Remote;

namespace SimpleAppium
{
    [TestClass]
    public class NativeApplicationTests
    {
        AppiumDriver<IWebElement> driver;

        [TestMethod]
        [TestCategory("NativeApp")]
        public void CalculatorTest()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("appPackage", "com.android.calculator2");
            cap.SetCapability("appActivity", "com.android.calculator2.Calculator");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            driver.FindElementById("digit_9").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementById("op_add").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementById("digit_8").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementById("eq").Click();

            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            string result = driver.FindElementById("formula").Text;

            Assert.AreEqual(17, Convert.ToInt32(result), "Sum is not maching the expected result");

            Console.WriteLine("Result is: "+result);
        }

        [TestMethod]
        [TestCategory("NativeApp")]
        public void PhoneContactsTest()
        {
            string contactName = "House";

            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("appPackage", "com.android.dialer");
            cap.SetCapability("appActivity", "com.android.dialer.DialtactsActivity");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            driver.FindElementById("search_box_start_search").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementById("search_view").SendKeys(contactName);
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementByAccessibilityId("Quick contact for " + contactName + "").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementByAccessibilityId("More options").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(5));
            driver.FindElementByXPath("//android.widget.TextView[@text='Place on Home screen']").Click();
         
        }

        [TestMethod]
        [TestCategory("NativeApp")]
        public void MyCamsTest()
        {
            DesiredCapabilities cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("appPackage", "com.KCamsApp");
            cap.SetCapability("appActivity", "com.KCamsApp.SplashScreenActivity");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Console.WriteLine("App Type is : "+driver.Context);

            driver.FindElementById("login_button").Click();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElementById("user_name_et").SendKeys("vishnuprakash9845@gmail.com");
            driver.HideKeyboard();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElementById("password_et").SendKeys("Farewell@1234");
            driver.HideKeyboard();
            driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            driver.FindElementById("login_button").Click();
        }
    }
}
