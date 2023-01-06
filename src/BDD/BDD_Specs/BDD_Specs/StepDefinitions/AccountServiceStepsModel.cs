namespace BDD_Specs.StepDefinitions;

public class AccountServiceStepsModel
{
    public AccountType AccountType { get; set; } = AccountType.Standard;
    public IAccountService AccountServ { get; set; } = new AccountService(new DateTimeProvider(), () => TestCommon.Wednesday);
    public int TripPoints { get; set; } = 500;
    public decimal Results { get; set; }
}