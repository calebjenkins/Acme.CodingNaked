﻿namespace BDD_ExampleLib;

public class AccountService : IAccountService
{
    private IDateTime dt;
    private Func<DateTime> fDt;

    public AccountService(IDateTime DateProvider, Func<DateTime> funcDt)
    {
        dt = DateProvider ?? throw new ArgumentNullException(nameof(DateProvider));
        fDt = funcDt ?? throw new ArgumentNullException(nameof(funcDt));
    }

    public Account Create(string AccountNumber, List<Trip> Trips)
    {
        //return new Account(AccountNumber, Trips) { Now =  dt.Now() };
        return new Account(AccountNumber, Trips) { Now = fDt(), FunNow = fDt };
    }
}