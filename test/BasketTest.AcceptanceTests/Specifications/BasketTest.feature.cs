﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (http://www.specflow.org/).
//      SpecFlow Version:2.4.0.0
//      SpecFlow Generator Version:2.4.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BasketTest.AcceptanceTests.Specifications
{
    using TechTalk.SpecFlow;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "2.4.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("Basket with vouchers")]
    public partial class BasketWithVouchersFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
#line 1 "BasketTest.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Basket with vouchers", "\tIn order to pay less for goods\r\n\tAs a customer\r\n\tI want to be able to apply vouc" +
                    "hers to my basket", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void ScenarioTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Basket 1")]
        public virtual void Basket1()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basket 1", null, ((string[])(null)));
#line 6
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Price",
                        "Quantity"});
            table1.AddRow(new string[] {
                        "Hat",
                        "10.50",
                        "1"});
            table1.AddRow(new string[] {
                        "Jumper",
                        "54.65",
                        "1"});
#line 7
 testRunner.Given("I have added the following items to my basket:", ((string)(null)), table1, "Given ");
#line 11
 testRunner.When("I apply a £5.00 Gift Voucher XXX-XXX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 12
 testRunner.Then("my basket total will be £60.15", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Basket 2")]
        public virtual void Basket2()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basket 2", null, ((string[])(null)));
#line 14
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Price",
                        "Quantity"});
            table2.AddRow(new string[] {
                        "Hat",
                        "25.00",
                        "1"});
            table2.AddRow(new string[] {
                        "Jumper",
                        "26",
                        "1"});
#line 15
 testRunner.Given("I have added the following items to my basket:", ((string)(null)), table2, "Given ");
#line 19
 testRunner.When("I apply a £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 20
 testRunner.Then("my basket total will be £51.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 21
 testRunner.And("I will receive a message \"There are no products in your basket applicable to vouc" +
                    "her Voucher YYY-YYY .\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Basket 3")]
        public virtual void Basket3()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basket 3", null, ((string[])(null)));
#line 23
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Price",
                        "Category",
                        "Quantity"});
            table3.AddRow(new string[] {
                        "Hat",
                        "25.00",
                        "",
                        "1"});
            table3.AddRow(new string[] {
                        "Jumper",
                        "26",
                        "",
                        "1"});
            table3.AddRow(new string[] {
                        "Head Light",
                        "3.50",
                        "Head Gear",
                        "1"});
#line 24
 testRunner.Given("I have added the following items to my basket:", ((string)(null)), table3, "Given ");
#line 29
 testRunner.When("I apply a £5.00 off Head Gear in baskets over £50.00 Offer Voucher YYY-YYY", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 30
 testRunner.Then("my basket total will be £51.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Basket 4")]
        public virtual void Basket4()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basket 4", null, ((string[])(null)));
#line 32
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Price",
                        "Quantity"});
            table4.AddRow(new string[] {
                        "Hat",
                        "25.00",
                        "1"});
            table4.AddRow(new string[] {
                        "Jumper",
                        "26",
                        "1"});
#line 33
 testRunner.Given("I have added the following items to my basket:", ((string)(null)), table4, "Given ");
#line 37
 testRunner.When("I apply a £5.00 Gift Voucher XXX-XXX", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 38
 testRunner.When("I apply a £5.00 off baskets over £50.00 Offer Voucher YYY-YYY", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 39
 testRunner.Then("my basket total will be £41.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Basket 5")]
        public virtual void Basket5()
        {
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Basket 5", null, ((string[])(null)));
#line 41
this.ScenarioInitialize(scenarioInfo);
            this.ScenarioStart();
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "Name",
                        "Price",
                        "Quantity"});
            table5.AddRow(new string[] {
                        "Hat",
                        "25.00",
                        "1"});
            table5.AddRow(new string[] {
                        "Gift Voucher",
                        "30.00",
                        "1"});
#line 42
 testRunner.Given("I have added the following items to my basket:", ((string)(null)), table5, "Given ");
#line 46
 testRunner.When("I apply a £5.00 off baskets over £50.00 Offer Voucher YYY-YYY", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line 47
 testRunner.Then("my basket total will be £55.00", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line 48
 testRunner.And("I will receive a message \"You have not reached the spend threshold for voucher YY" +
                    "Y-YYY. Spend another £25.01 to receive £5.00 discount from your basket total.\"", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
