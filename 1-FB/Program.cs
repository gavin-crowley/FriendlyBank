using System;

//enumerated types - a type with a number of states
enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
};

// struct - like gathering associated fields to form a record template
struct Account
{
    public AccountState State;
    public string Name;
    public string Address;
    public int AccountNumber;
    public int Balance;
    public int Overdraft;
};

class BankProgram
{

    public static void Main()
    {
        Account RobsAccount; // declare struct of type Account
        
        // populate fields
        RobsAccount.State = AccountState.Active;
        RobsAccount.Balance = 1000000;
        Console.WriteLine(RobsAccount.State);
        Console.WriteLine(RobsAccount.Balance);
    }
}