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
    // method with parameter of structure type
    public static void PrintAccount(Account a)
    {
        Console.WriteLine("Name: " + a.Name);
        Console.WriteLine("Address: " + a.State);
        Console.WriteLine("Balance: " + a.Balance);
    }

    //public static void ReadAccount()
    //{

    //}

    public static void Main()
    {
        const int MAX_CUST = 100;

        // declare an array of structure values of type Account
        Account[] Bank = new Account[MAX_CUST];

        // access and populate fields in rows of array
        Bank[0].Name = "Rob";
        Bank[0].State = AccountState.New;
        Bank[0].Balance = 1000000;
        // print out contents of first record
        PrintAccount(Bank[0]);


        Bank[1].Name = "Jim";
        Bank[1].State = AccountState.Frozen;
        Bank[1].Balance = 0;
        // print out contents of second record
        PrintAccount(Bank[1]);
    }
}