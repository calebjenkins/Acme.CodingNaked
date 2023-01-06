namespace BDD_Specs.StepDefinitions;

[Binding]
public class AccountServiceStepDefinitions
{
    private AccountServiceStepsModel model;
    public AccountServiceStepDefinitions(AccountServiceStepsModel Model)
    {
        model = Model;
    }

    [Given(@"an Account with Standard Status")]
    public void GivenAnAccountWithStandardStatus()
    {
        model.AccountType = AccountType.Standard;
    }

    [Given(@"the Trip has 500 points")]
    public void GivenTheTripHas500Points()
    {
        model.TripPoints = 500;
    }

    [Given(@"its not a weekend")]
    public void GivenItsNotAWeekend()
    {
        model.AccountServ = new AccountService(new DateTimeProvider(), () => TestCommon.Wednesday);
    }

    [Given(@"it IS a weekend")]
    public void GivenItISAWeekend()
    {
        model.AccountServ = new AccountService(new DateTimeProvider(), () => TestCommon.Sunday);
    }

    [Given(@"an Account with Silver Status")]
    public void GivenAnAccountWithSilverStatus()
    {
        model.AccountType = AccountType.Silver;
    }

    [Given(@"an Account with Gold Status")]
    public void GivenAnAccountWithGoldStatus()
    {
        model.AccountType = AccountType.Gold;
    }

    [When(@"Trip value is calculated")]
    public void WhenTripValueIsCalculated()
    {
        var testAccount = GetAccount(model.AccountType);
        var trip = TestCommon.TripToBuy;
        model.Results = model.AccountServ.CalculateTripPriceForAccount(testAccount, trip);
    }

    [Then("the result should be (.*)")]
    public void ThenTheResultShouldBe(string result)
    {
        model.Results.Should().Be(2000.00m);
    }

    private Account GetAccount(AccountType Status)
    {
        switch (Status)
        {
            case AccountType.Standard:
                return TestCommon.StandardAccount;
            case AccountType.Silver:
                return TestCommon.SilverAccount;
            case AccountType.Gold:
                return TestCommon.GoldAccount;

            default:
                throw new Exception("AccountType not found");
        }
    }
}

public class AccountServiceStepsModel
{
    public AccountType AccountType { get; set; } = AccountType.Standard;
    public IAccountService AccountServ { get; set; } = new AccountService(new DateTimeProvider(), () => TestCommon.Wednesday);
    public int TripPoints { get; set; } = 500;
    public decimal Results { get; set; }
}