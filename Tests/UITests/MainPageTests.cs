﻿using Allure.NUnit.Attributes;
using CoreTestProject.Pages;
using CoreTestProject.StaticData;
using CoreTestProject.Utils;
using Tests.TestFixtures;

namespace Tests.UITests
{
    [TestFixture]
    [AllureSuite("Main page")]
    public class MainPageTests : BaseTest
    {
        private MainPage _mainPage;

        [SetUp]
        public void TestSetup()
        {
            _mainPage = new MainPage(Page);
        }

        [Test]
        [AllureOwner("Andrei Kasachou")]
        [AllureSubSuite("Main layout")]
        public async Task VerifyMainPageTitle()
        {
            Assert.That(await _mainPage.GetPageName(), Is.EqualTo("Welcome to your software automation practice website!"));
        }

        [Test]
        [AllureOwner("Andrei Kasachou")]
        [AllureSubSuite("Main layout")]
        public async Task VerifyAllButtonsPresenceOnMainPage()
        {
            foreach (var btn in StringConstantUtil.GetAllConstants<MainPageButton>())
            {
                Assert.That(await _mainPage.IsButtonVisible(btn), Is.True, "{0} button is not displayed on the page", btn.Name);
            }
        }
    }
}
