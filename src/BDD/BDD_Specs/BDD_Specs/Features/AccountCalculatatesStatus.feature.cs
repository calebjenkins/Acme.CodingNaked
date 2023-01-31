﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.9.0.0
//      SpecFlow Generator Version:3.9.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace BDD_Specs.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    public partial class AccountCanCalculateAccountTypeFeature : object, Xunit.IClassFixture<AccountCanCalculateAccountTypeFeature.FixtureData>, System.IDisposable
    {
        
        private static TechTalk.SpecFlow.ITestRunner testRunner;
        
        private static string[] featureTags = ((string[])(null));
        
        private Xunit.Abstractions.ITestOutputHelper _testOutputHelper;
        
#line 1 "AccountCalculatatesStatus.feature"
#line hidden
        
        public AccountCanCalculateAccountTypeFeature(AccountCanCalculateAccountTypeFeature.FixtureData fixtureData, BDD_Specs_XUnitAssemblyFixture assemblyFixture, Xunit.Abstractions.ITestOutputHelper testOutputHelper)
        {
            this._testOutputHelper = testOutputHelper;
            this.TestInitialize();
        }
        
        public static void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "Account can calculate Account Type", "A record for handeling Accounts", ProgrammingLanguage.CSharp, featureTags);
            testRunner.OnFeatureStart(featureInfo);
        }
        
        public static void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public void TestInitialize()
        {
        }
        
        public void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<Xunit.Abstractions.ITestOutputHelper>(_testOutputHelper);
        }
        
        public void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        void System.IDisposable.Dispose()
        {
            this.TestTearDown();
        }
        
        [Xunit.SkippableTheoryAttribute(DisplayName="Account calculates Account Status")]
        [Xunit.TraitAttribute("FeatureTitle", "Account can calculate Account Type")]
        [Xunit.TraitAttribute("Description", "Account calculates Account Status")]
        [Xunit.TraitAttribute("Category", "bdd,")]
        [Xunit.TraitAttribute("Category", "specFlow,")]
        [Xunit.TraitAttribute("Category", "codingNaked")]
        [Xunit.InlineDataAttribute("0", "Standard", new string[0])]
        [Xunit.InlineDataAttribute("10", "Standard", new string[0])]
        [Xunit.InlineDataAttribute("499", "Standard", new string[0])]
        [Xunit.InlineDataAttribute("500", "Silver", new string[0])]
        [Xunit.InlineDataAttribute("550", "Silver", new string[0])]
        [Xunit.InlineDataAttribute("999", "Silver", new string[0])]
        [Xunit.InlineDataAttribute("1000", "Gold", new string[0])]
        [Xunit.InlineDataAttribute("1200", "Gold", new string[0])]
        public void AccountCalculatesAccountStatus(string points, string accountStatus, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "bdd,",
                    "specFlow,",
                    "codingNaked"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("points", points);
            argumentsOfScenario.Add("accountStatus", accountStatus);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Account calculates Account Status", null, tagsOfScenario, argumentsOfScenario, featureTags);
#line 7
this.ScenarioInitialize(scenarioInfo);
#line hidden
            if ((TagHelper.ContainsIgnoreTag(tagsOfScenario) || TagHelper.ContainsIgnoreTag(featureTags)))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 8
 testRunner.Given(string.Format("an Account with trips worth {0} points", points), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 9
 testRunner.When("calculating account Status", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.Then(string.Format("account status should be {0}", accountStatus), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.9.0.0")]
        [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
        public class FixtureData : System.IDisposable
        {
            
            public FixtureData()
            {
                AccountCanCalculateAccountTypeFeature.FeatureSetup();
            }
            
            void System.IDisposable.Dispose()
            {
                AccountCanCalculateAccountTypeFeature.FeatureTearDown();
            }
        }
    }
}
#pragma warning restore
#endregion
