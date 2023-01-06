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
        switch (result)
        {
            case "BasePrice":
                model.Results.Should().Be(TestCommon.BasePrice);
                break;
            case "BasePrice-WeekendDiscount":
                model.Results.Should().Be(TestCommon.BasePrice - Ref.WeekendDiscountAmount);
                break;
            case "SilverPriceTimesPoints":
                model.Results.Should().Be(Ref.SilverPricePerPoint * TestCommon.TripToBuy.Points);
                break;
            case "SilverPriceTimesPoints-WeekendDiscount":
                model.Results.Should().Be(Ref.SilverPricePerPoint * TestCommon.TripToBuy.Points - Ref.WeekendDiscountAmount);
                break;
            case "GoldPriceTimesPoints":
                model.Results.Should().Be(Ref.GoldPricePerPoint * TestCommon.TripToBuy.Points);
                break;
            case "GoldPriceTimesPoints-WeekendDiscount":
                model.Results.Should().Be(Ref.GoldPricePerPoint * TestCommon.TripToBuy.Points - Ref.WeekendDiscountAmount);
                break;
        }
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
