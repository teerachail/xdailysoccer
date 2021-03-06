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
    public partial class GetAllLeagueFeature
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "GetAllLeague.feature"
#line hidden
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.ClassInitializeAttribute()]
        public static void FeatureSetup(Microsoft.VisualStudio.TestTools.UnitTesting.TestContext testContext)
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "GetAllLeague", "In order to avoid silly mistakes\r\nAs a math idiot\r\nI want to be told the sum of t" +
                    "wo numbers", ProgrammingLanguage.CSharp, ((string[])(null)));
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
                        && (TechTalk.SpecFlow.FeatureContext.Current.FeatureInfo.Title != "GetAllLeague")))
            {
                DailySoccer.Specs.GetAllLeagueFeature.FeatureSetup(null);
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
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ขอข้อมูลทีมทั้งหมดในตอนที่ไม่มีข้อมูลทีม ระบบส่งข้อมูลเปล่ากลับไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetAllLeague")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mock")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mock")]
        public virtual void ขอขอมลทมทงหมดในตอนทไมมขอมลทมระบบสงขอมลเปลากลบไป()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ขอข้อมูลทีมทั้งหมดในตอนที่ไม่มีข้อมูลทีม ระบบส่งข้อมูลเปล่ากลับไป", new string[] {
                        "mock",
                        "mock"});
#line 11
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "TeamId",
                        "TeamName",
                        "LeagueName"});
#line 12
 testRunner.Given("ข้อมูลทีมทั้งหมดในระบบมีเป็น", ((string)(null)), table1, "Given ");
#line 14
 testRunner.When("ขอข้อมูลทีมทั้งหมดในระบบ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "TeamId",
                        "TeamName",
                        "LeagueName"});
#line 15
 testRunner.Then("ระบบส่งข้อมูลทีมทั้งหมดในระบบมีเป็น", ((string)(null)), table2, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ขอข้อมูลทีมทั้งหมดในตอนที่มีอยู่ข้อมูลเดียว ระบบส่งข้อมูลทีมทั้งหมดที่มีกลับไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetAllLeague")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mock")]
        public virtual void ขอขอมลทมทงหมดในตอนทมอยขอมลเดยวระบบสงขอมลทมทงหมดทมกลบไป()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ขอข้อมูลทีมทั้งหมดในตอนที่มีอยู่ข้อมูลเดียว ระบบส่งข้อมูลทีมทั้งหมดที่มีกลับไป", new string[] {
                        "mock"});
#line 19
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "TeamId",
                        "TeamName",
                        "LeagueName"});
            table3.AddRow(new string[] {
                        "1",
                        "AS Roma",
                        "EUFA Champions League"});
#line 20
 testRunner.Given("ข้อมูลทีมทั้งหมดในระบบมีเป็น", ((string)(null)), table3, "Given ");
#line 23
 testRunner.When("ขอข้อมูลทีมทั้งหมดในระบบ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "TeamId",
                        "TeamName",
                        "LeagueName"});
            table4.AddRow(new string[] {
                        "1",
                        "AS Roma",
                        "EUFA Champions League"});
#line 24
 testRunner.Then("ระบบส่งข้อมูลทีมทั้งหมดในระบบมีเป็น", ((string)(null)), table4, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestMethodAttribute()]
        [Microsoft.VisualStudio.TestTools.UnitTesting.DescriptionAttribute("ขอข้อมูลทีมทั้งหมดในตอนที่มีอยู่หลายข้อมูล ระบบส่งข้อมูลทีมทั้งหมดที่มีกลับไป")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestPropertyAttribute("FeatureTitle", "GetAllLeague")]
        [Microsoft.VisualStudio.TestTools.UnitTesting.TestCategoryAttribute("mock")]
        public virtual void ขอขอมลทมทงหมดในตอนทมอยหลายขอมลระบบสงขอมลทมทงหมดทมกลบไป()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ขอข้อมูลทีมทั้งหมดในตอนที่มีอยู่หลายข้อมูล ระบบส่งข้อมูลทีมทั้งหมดที่มีกลับไป", new string[] {
                        "mock"});
#line 29
this.ScenarioSetup(scenarioInfo);
#line 7
this.FeatureBackground();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "TeamId",
                        "TeamName",
                        "LeagueName"});
            table5.AddRow(new string[] {
                        "1",
                        "AS Roma",
                        "EUFA Champions League"});
            table5.AddRow(new string[] {
                        "2",
                        "Bayer Leverkusen",
                        "EUFA Champions League"});
            table5.AddRow(new string[] {
                        "3",
                        "Barcelona",
                        "EUFA Champions League"});
            table5.AddRow(new string[] {
                        "4",
                        "BATE Borisov",
                        "EUFA Champions League"});
            table5.AddRow(new string[] {
                        "5",
                        "Bayern Munich",
                        "EUFA Champions League"});
#line 30
 testRunner.Given("ข้อมูลทีมทั้งหมดในระบบมีเป็น", ((string)(null)), table5, "Given ");
#line 37
 testRunner.When("ขอข้อมูลทีมทั้งหมดในระบบ", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
            TechTalk.SpecFlow.Table table6 = new TechTalk.SpecFlow.Table(new string[] {
                        "TeamId",
                        "TeamName",
                        "LeagueName"});
            table6.AddRow(new string[] {
                        "1",
                        "AS Roma",
                        "EUFA Champions League"});
            table6.AddRow(new string[] {
                        "2",
                        "Bayer Leverkusen",
                        "EUFA Champions League"});
            table6.AddRow(new string[] {
                        "3",
                        "Barcelona",
                        "EUFA Champions League"});
            table6.AddRow(new string[] {
                        "4",
                        "BATE Borisov",
                        "EUFA Champions League"});
            table6.AddRow(new string[] {
                        "5",
                        "Bayern Munich",
                        "EUFA Champions League"});
#line 38
 testRunner.Then("ระบบส่งข้อมูลทีมทั้งหมดในระบบมีเป็น", ((string)(null)), table6, "Then ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
