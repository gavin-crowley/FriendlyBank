using System;

public interface IAccount
{
    void PayInFunds(decimal amount);
    bool WithdrawFunds(decimal amount);
    decimal GetBalance();
    string GetName();
    AccountState GetState();
    //string RudeLetterString();
}


//enumerated types - a type with a number of states
// made public when adding interface
public enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}




public class CustomerAccount : IAccount
{
    public string Name;
    public AccountState State;
    private decimal balance = 0;

    // constructors
    public CustomerAccount(string inName, AccountState inState, decimal inBalance)
    {
        Name = inName;
        State = inState;
        balance = inBalance;
    }

    //public abstract string RudeLetterString();

    public virtual bool WithdrawFunds(decimal amount)
    {
        if (balance < amount)
        {
            return false;
        }
        balance = balance - amount;
        return true;
    }

    public void PayInFunds(decimal amount)
    {
        balance = balance + amount;
    }

    public decimal GetBalance()
    {
        return balance;
    }

    public string GetName()
    {
        return Name;
    }

    public AccountState GetState()
    {
        return State;
    }


}

public class BabyAccount : CustomerAccount
{
    public BabyAccount(string inName, AccountState inState, decimal inBalance)
        : base(inName, inState, inBalance)
    {
    }
    public override bool WithdrawFunds(decimal amount)

    {
        if (amount > 10)
        {
            return false;
        }
        return base.WithdrawFunds(amount);
    }

    //public override string RudeLetterString()
    //{
    //    return "Tell daddy you are overdrawn";
    //}
}



class BankProgram
{
    // method with parameter of class type
    public static void PrintAccount(IAccount a)
    {
        Console.WriteLine("Name: " + a.GetName());
        Console.WriteLine("Account state: " + a.GetState());
        Console.WriteLine("Balance: " + a.GetBalance());
        Console.WriteLine();
    }



    public static void Main()
    {


        Console.WriteLine("----------------");




        const int MAX_CUST = 100;

        IAccount[] Accounts = new IAccount[MAX_CUST];


        // access and populate fields in rows of array
        Accounts[0] = new CustomerAccount("Rob", AccountState.New, 1000000);
        PrintAccount(Accounts[0]);

        Accounts[1] = new CustomerAccount("Jim", AccountState.Active, 23);
        PrintAccount(Accounts[1]);

        Accounts[2] = new CustomerAccount("Julie", AccountState.Active,0);
        PrintAccount(Accounts[2]);

        Accounts[3] = new BabyAccount("Baby Driver", AccountState.New, 20);
        PrintAccount(Accounts[3]);


        BabyAccount b = new BabyAccount("baby", AccountState.New,30);
        b.PayInFunds(50);
        Console.WriteLine(b.GetBalance());


        // withdraw from Robs account
        Accounts[0].WithdrawFunds(999999);
        Console.WriteLine($"{Accounts[0].GetName()}'s balance is now {Accounts[0].GetBalance()}");

        // withdraw from Baby's account
        Accounts[3].WithdrawFunds(10);
        Console.WriteLine($"{Accounts[3].GetName()}'s balance is now {Accounts[3].GetBalance()}");

        Console.WriteLine("----------------");

    }


}