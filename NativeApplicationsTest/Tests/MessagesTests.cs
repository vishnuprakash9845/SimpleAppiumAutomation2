using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium.Service;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using NativeApplicationsTest.PageActions;
using static NativeApplicationsTest.Utilities;
using System.Threading;

namespace NativeApplicationsTest.Tests
{
    [TestClass]
    public class MessagesTests
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
            cap.SetCapability("appPackage", "com.google.android.apps.messaging");
            cap.SetCapability("appActivity", "com.google.android.apps.messaging.ui.ConversationListActivity");
            //cap.SetCapability("appActivity", "com.google.android.apps.messaging.ui.conversationlist.ConversationListActivity");

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
        [TestCategory("Sanity_MessagesApp")]
        public void LaunchingMessagesApplicationTest()
        {
            Console.WriteLine("Test Execution Started");

            //driver = new AndroidDriver<IWebElement>(new Uri("http://127.0.0.1:4723/wd/hub"), cap);

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            Console.WriteLine("Test Execution Completed");
        }

        [TestMethod]
        [TestCategory("Sanity_MessagesApp")]
        public void SearchMessagesApplicationTest()
        {
            MessagesHomeAction action = new MessagesHomeAction(driver);

            Console.WriteLine("Test Execution Started");

            action.ClickOnSpamProtectionOKButton();
            action.SearchMessagesByText(SelectorOptions.XPath, ".//*[@text='VKHDFCBK']");

            var tt = action.GetMessageText(SelectorOptions.XPath, ".//android.widget.TextView[@resource-id='com.google.android.apps.messaging:id/message_text']");

            Assert.IsNotNull(driver.Context);
            Console.WriteLine("App Type is : " + driver.Context);

            Console.WriteLine("Test Execution Completed");
        }
    }
}

