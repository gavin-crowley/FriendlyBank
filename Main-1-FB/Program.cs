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
    public int Overdraft;

    // encapsulation - stop change from being made to member
    private decimal balance = 0;

    public Account(AccountState state, string name, string address, int accountNumber, int overdraft, decimal balance)
    {
        State = state;
        Name = name;
        Address = address;
        AccountNumber = accountNumber;
        Overdraft = overdraft;
        this.balance = balance;
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
}


class BankProgram
{
    // method with parameter of structure type
    public static void PrintAccount(Account a)
    {
        Console.WriteLine("Name: " + a.Name);
        Console.WriteLine("Address: " + a.State);
        Console.WriteLine("Balance: " + a.GetBalance());
    }



    public static void Main()
    {
        const int MAX_CUST = 100;

        // declare an array of structure values of type Account
        Account[] Bank = new Account[MAX_CUST];

        // access and populate fields in rows of array
        Bank[0].Name = "Rob";
        Bank[0].State = AccountState.New;
        Bank[0].PayInFunds(1000000);
        // print out contents of first record
        PrintAccount(Bank[0]);


        Bank[1].Name = "Jim";
        Bank[1].State = AccountState.Frozen;
        Bank[1].PayInFunds(0);
        // print out contents of second record
        PrintAccount(Bank[1]);

        // withdraw from Robs account
        Bank[0].WithdrawFunds(999999);
        Console.WriteLine($"{Bank[0].Name}'s balance is now {Bank[0].GetBalance()}");


        // Run test
        Account test = new Account();
        test.PayInFunds(50);
        if (test.GetBalance() != 50)
        {
            Console.WriteLine("Pay In test failed");
        }
        Console.WriteLine("Pay In test succeeded");

    }


}