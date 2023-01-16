using System;


//enumerated types - a type with a number of states
public enum AccountState
{
    New,
    Active,
    UnderAudit,
    Frozen,
    Closed
}



class Account
{
    // encapsulation - stop change from being made to member
    private string name;
    private AccountState state;
    private decimal balance = 0;

    private static decimal interestRateCharged = 0.1M;


    //-------------------------------------

    public bool SetName(string inName)
    {
        if (inName == "")
            return false;

        name = inName;

        return true;
    }

    public bool SetAccountState(AccountState inState)
    {
        if (inState == AccountState.Frozen)
            return false;

        state = inState;

        return true;
    }

    const decimal MAX_BALANCE = 10000000;
    const decimal MIN_BALANCE = -10000000;

    public bool SetBalance(decimal inBalance)
    {
        if (inBalance < MIN_BALANCE ||
            inBalance > MAX_BALANCE)
            return false;

        balance = inBalance;
        return true;
    }

    // constructors
    public Account(string inName, AccountState inState, decimal inBalance)
    {
        string errorMessage = "";

        if (SetBalance(inBalance) == false)
            errorMessage = errorMessage + "Bad Balance: " + inBalance;

        if (SetName(inName) == false)
        {
            errorMessage = errorMessage + "Bad Name: " + inName;
        }

        if (SetAccountState(inState) == false)
        {
            errorMessage = errorMessage + " Bad State : " + inState;
        }

        if (errorMessage != "")
        {
            throw new Exception("Account construction failed "
                + errorMessage);
        }
    }

    // only wanted to have balance as a parameter for testing
    public Account(decimal inBalance) :
     this("", AccountState.UnderAudit, inBalance)
    {
    }

    // use of this for method overloading, as above
    public Account(string inName, AccountState inState) :
     this(inName, inState, 0)
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

    public static decimal GetInterest()
    {
        return interestRateCharged;
    }


    // Account Allowed Method
    private static decimal minIncome = 10000;
    private static int minAge = 18;
    public static bool AccountAllowed(decimal income, int age)
    {
        if ((income >= minIncome) && (age >= minAge))
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}



class BankProgram
{
    // method with parameter of class type
    public static void PrintAccount(Account a)
    {
        Console.WriteLine("Name: " + a.GetName());
        Console.WriteLine("Account state: " + a.GetState());
        Console.WriteLine("Balance: " + a.GetBalance());
        Console.WriteLine();
    }



    public static void Main()
    {   
        // check account allowed
        if (Account.AccountAllowed(50000, 21))
        {
            Console.WriteLine("Account Allowed");
        } 
        else
        {
            Console.WriteLine("Account Not Allowed");
        }

        Console.WriteLine("Interest Rate Charged: " + Account.GetInterest());


        Console.WriteLine("----------------");


        const int MAX_CUST = 100;

        // declare an array of type Account
        Account[] Accounts = new Account[MAX_CUST];

        // access and populate fields in rows of array
        Accounts[0] = new Account("Rob", AccountState.New, 1000000);
        PrintAccount(Accounts[0]);

        Accounts[1] = new Account("Jim", AccountState.Active, 23);
        PrintAccount(Accounts[1]);

        Accounts[2] = new Account("Julie", AccountState.Active);
        PrintAccount(Accounts[2]);


        // withdraw from Robs account
        Accounts[0].WithdrawFunds(999999);
        Console.WriteLine($"{Accounts[0].GetName()}'s balance is now {Accounts[0].GetBalance()}");

        Console.WriteLine("----------------");

        // Run test
        Account test = new Account(0);
        test.PayInFunds(50);
        if (test.GetBalance() != 50)
        {
            Console.WriteLine("Pay In test failed");
        }
        else
        {
            Console.WriteLine("Pay In test succeeded");
        }

    }


}