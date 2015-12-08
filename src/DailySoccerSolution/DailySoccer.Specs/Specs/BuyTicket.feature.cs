﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:1.9.0.77
//      SpecFlow Generator Version:1.9.0.0
//      Runtime Version:4.0.30319.42000
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace DailySoccer.Specs
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "1.9.0.77")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [Microsoft.VisualStudio.TestTools.UnitTesting.TestClassAttribute()]
    public partial class BuyTicketFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BuyTicket.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "BuyTicket", "In order to avoid silly mistakes\nAs a math idiot\nI want to be told the sum of two" +
                    " numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassCleanupAttribute()]
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestInitializeAttribute()]
        public virtual void TestInitialize()
        {
            if (((TechTalk.SpecFlow.FeatureContext.Current != null) 
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "BuyTicket")))
            {
                DailySoccer.Specs.BuyTicketFeature.FeatureSetup(null);
            }
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCleanupAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioSetup(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioStart(scenarioInfo);
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 7
#line 8
 testRunner.Given("Setup mocking", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "SecretCode",
                        "Points",
                        "MaximumGuessAmount",
                        "CurrentOrderedCoupon"});
            table1.AddRow(new string[] {
                        "1",
                        "s01",
                        "0",
                        "5",
                        "0"});
#line 9
 testRunner.And("ผู้ใช้ในระบบมีดังนี้", ((string)(null)), table1, "And ");
#line hidden
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ซื้อคูปองแต่มีแต้มไม่พอ ระบบยกเลิกการสั่งซื้อ")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "BuyTicket")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mock")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mock")]
        public virtual void ซอคปองแตมแตมไมพอระบบยกเลกการสงซอ()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ซื้อคูปองแต่มีแต้มไม่พอ ระบบยกเลิกการสั่งซื้อ", new string[] {
                        "mock",
                        "mock"});
#line 14
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line 15
 testRunner.Given("วันเวลาในปัจจุบันเป็น \'1/1/2015 00:00\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "RequestPoints",
                        "ExpiredDate",
                        "RequestPoints"});
            table2.AddRow(new string[] {
                        "1",
                        "100",
                        "1/10/2015 00:00",
                        "100"});
#line 16
 testRunner.And("กลุ่มของรางวัลทั้งหมดในระบบมีดังนี้", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Id",
                        "RewardGroupId",
                        "Name",
                        "Description",
                        "Amount",
                        "RemainingAmount",
                        "ImagePath"});
            table3.AddRow(new string[] {
                        "1",
                        "1",
                        "iPhone 6S",
                        "iPhone 6S description",
                        "5",
                        "5",
                        "iphone6S.jpg"});
            table3.AddRow(new string[] {
                        "2",
                        "1",
                        "iPhone 6",
                        "iPhone 6 description",
                        "10",
                        "10",
                        "iphone6.jpg"});
            table3.AddRow(new string[] {
                        "3",
                        "1",
                        "iPhone 5S",
                        "iPhone 5S description",
                        "15",
                        "15",
                        "iphone5S.jpg"});
#line 19
 testRunner.And("ของรางวัลในแต่ละกลุ่มเป็นดังนี้", ((string)(null)), table3, "And ");
#line 24
 testRunner.When("ผู้ใช้ UserId: \'s01\' สั่งซื้อคูปองจำนวน \'1\' คูปอง", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 25
 testRunner.Then("ระบบไม่ทำการบันทึกการสั่งซื้อ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 26
 testRunner.And("แต้มผู้ใช้ไม่ถูกหัก", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
