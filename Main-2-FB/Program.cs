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

class Account
{
    // encapsulation - stop change from being made to member
    private string name;
    private AccountState state;
    private decimal balance = 0;
    
    // constructors
    public Account(string inName, AccountState inState, decimal inBalance)
    {
        name = inName;
        state = inState;
        balance = inBalance;
    }

    // only wanted to have balance as a parameter for testing
    public Account(decimal inBalance) :
     this("", AccountState.UnderAudit, inBalance)
    {
    }
    

    // public - code running outside the class can make calls to that method
    public bool WithdrawFunds(decimal amount)
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
        return name;
    }

    public AccountState GetState()
    {
        return state;
    }
};



class BankProgram
{
    // method with parameter of class type
    public static void PrintAccount(Account a)
    {
        Console.WriteLine("Name: " + a.GetName());
        Console.WriteLine("Account state: " + a.GetState());
        Console.WriteLine("Balance: " + a.GetBalance());
    }



    public static void Main()
    {
        const int MAX_CUST = 100;

        // declare an array of type Account
        Account[] Accounts = new Account[MAX_CUST];

        // access and populate fields in rows of array
        Accounts[0] = new Account("Rob", AccountState.New, 1000000);
        PrintAccount(Accounts[0]);

        Accounts[1] = new Account("Jim", AccountState.Frozen, 0);
        PrintAccount(Accounts[1]);

        // withdraw from Robs account
        Accounts[0].WithdrawFunds(999999);
        Console.WriteLine($"{Accounts[0].GetName()}'s balance is now {Accounts[0].GetBalance()}");


        // Run test
        Account test = new Account(0);
        test.PayInFunds(50);
        if (test.GetBalance() != 50)
        {
            Console.WriteLine("Pay In test failed");
        } else
        {
            Console.WriteLine("Pay In test succeeded");
        }

    }


}