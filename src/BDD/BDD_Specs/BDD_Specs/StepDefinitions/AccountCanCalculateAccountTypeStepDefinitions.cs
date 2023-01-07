using System;
using System.Reflection.Metadata;
using TechTalk.SpecFlow;

// SpecFlow: generate report:
// > dotnet tool install --global SpecFlow.Plus.LivingDoc.CLI
// > livingdoc test-assembly SpecFlowCalculator.Specs.dll -t TestExecution.json 


namespace BDD_Specs.StepDefinitions
{
    [Binding]
    public class AccountCanCalculateAccountTypeStepDefinitions
    {
        AccountCanCalculateModel model;

        public AccountCanCalculateAccountTypeStepDefinitions(AccountCanCalculateModel Model)
        {
            model = Model;
        }
        [Given(@"an Account with trips worth (.*) points")]
        public void GivenAnAccountWithTripsWorthPoints(int points)
        {
            var t = new Trip(points, "abc", TestCommon.Wednesday, TestCommon.Wednesday);
            model.Account = new Account("123", new List<Trip> { t });
        }

        [When("calculating account Status")]
        public void WhenCalculatingAccountStatus()
        {
            model.Status = model?.Account?.CalculateAccountType();
        }

        [Then(@"account status should be (.*)")]
        public void ThenAccountStatusShouldBeStandard(string status)
        {
            var stat = status.Parse<AccountType>(ignoreCase: true);
            status.Should().NotBeNull();
            model.Status.Should().Be(stat);
        }
    }
}
