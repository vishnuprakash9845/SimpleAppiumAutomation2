using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Android;
using OpenQA.Selenium.Appium.Service;
using NativeApplicationsTest.PageActions;
using System.Threading;
using static NativeApplicationsTest.Utilities;

namespace NativeApplicationsTest
{
    [TestClass]
    public class APIDemoAppTest
    {
        AppiumDriver<IWebElement> driver = null;
        public static AppiumLocalService appiumLocalService = null;
        public static DesiredCapabilities cap;
        public static Recorder recorder;
        public static string _testVideoFileName;
        public static string TestRecordingVideo;
        public TestContext TestContext { get; set; }

        [ClassInitialize]
        public static void InitTestSuite(TestContext context)
        {
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
            TestRecordingVideo = @"C:\Auto\AppiumVideos\";

            cap = new DesiredCapabilities();
            cap.SetCapability("platformName", "Android");
            cap.SetCapability("platformVersion", "6.0");
            cap.SetCapability("deviceName", "Moto G");
            cap.SetCapability("appPackage", "io.appium.android.apis");
            cap.SetCapability("appActivity", "io.appium.android.apis.ApiDemos");

            _testVideoFileName = TestContext.TestName + "_" + ISO_Date();
            StartRecording(_testVideoFileName);

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);
        }

        [TestCleanup]
        public void MyTestCleanUp()
        {
            if (TestContext.CurrentTestOutcome == UnitTestOutcome.Failed)
            {
                //Stops and Saves Screen Recording
                StopRecording();
            }
            else
            {
                //Stops and Deletes Screen Recording
                recorder.DeleteRecording(TestRecordingVideo + _testVideoFileName + ".avi");
            }
        }

        private static string ISO_Date()
        {
            return DateTime.Now.ToString("MM_dd_yyyy_HH_mm_ss");
        }

        private static void StartRecording(string fileName)
        {
            recorder = new Recorder(new RecorderParams(TestRecordingVideo + fileName + ".avi", 2, SharpAvi.KnownFourCCs.Codecs.MotionJpeg, 70));
        }

        private static void StopRecording()
        {
            recorder.StopRecording();
        }

        [TestMethod]
        [TestCategory("Sanity_APIDemoApp")]
        public void LaunchingAPIDemoApplicationTest()
        {
            Console.WriteLine("Test Execution Started");

            driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_APIDemoApp")]
        public void VerticalSwipeTest()
        {
            Utilities utl = new Utilities();
            utl.VerticalSwipeDown(driver);
        }

        [TestMethod]
        [TestCategory("Sanity_APIDemoApp")]
        public void HorizontalSwipeTest()
        {
            Utilities utl = new Utilities();
            APIDemoHomeAction action = new APIDemoHomeAction(driver);

            utl.VerticalSwipeDown(driver);
            action.ClickOnHomePageOptions("Views");
            utl.VerticalSwipeDown(driver);
            utl.VerticalSwipeDown(driver);
            utl.VerticalSwipeDown(driver);
            utl.VerticalSwipeDown(driver);
            action.ClickOnHomePageOptions("Tabs");
            action.ClickOnHomePageOptions("5. Scrollable");
            Thread.Sleep(5000);
            utl.HorizontalSwipeLeft(driver);
            utl.HorizontalSwipeLeft(driver);
            utl.HorizontalSwipeLeft(driver);
        }

        [TestMethod]
        [TestCategory("Sanity_APIDemoApp")]
        public void NavigateToTabsTest()
        {
            APIDemoHomeAction action = new APIDemoHomeAction(driver);
            Utilities utl = new Utilities();

            try
            {
                action.SelectViewsTabsContentByID("Views", "Tabs", "1. Content By Id1");
            }
            catch (Exception ex)
            {
                utl.getScreenShotMobile(driver, TestContext.TestName);
                Assert.Fail("Test Case Failed with error: {0}",ex.Message);
            }
            
        }

        [TestMethod]
        [TestCategory("Sanity_APIDemoApp")]
        public void CheckTouchActionsTest()
        {
            APIDemoHomeAction action = new APIDemoHomeAction(driver);
            Utilities utl = new Utilities();

            try
            {
                utl.VerticalSwipe(driver, ScrollOptions.down.ToString());
                action.ClickOnPageOneOptions(SelectorOptions.AccessibilityId,"Views");
                utl.VerticalSwipe(driver, ScrollOptions.down.ToString());
                utl.VerticalSwipe(driver, ScrollOptions.down.ToString());
                utl.VerticalSwipe(driver, ScrollOptions.down.ToString());
                utl.VerticalSwipe(driver, ScrollOptions.down.ToString());
                action.ClickOnPageTwoOptions(SelectorOptions.AccessibilityId, "Tabs");
                action.ClickOnPageThreeOptions(SelectorOptions.AccessibilityId, "1. Content By Id");
                action.ClickOnPageFourOptions(SelectorOptions.XPath, ".//android.widget.TextView[@text='tab2']");
                action.ClickOnPageFourOptions(SelectorOptions.XPath, ".//android.widget.TextView[@text='tab3']");
            }
            catch (Exception ex)
            {
                utl.getScreenShotMobile(driver, TestContext.TestName);
                Assert.Fail("Test Case Failed with error: {0}", ex.Message);
            }

        }

    }
}
