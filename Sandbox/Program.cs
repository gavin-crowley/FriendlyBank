using System;

class Account
{   // encapsulation - stop change from being made to member
    private decimal balance = 0;

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
};

class Bank
{
    public static void Main()
    {
        Account RobsAccount;
        RobsAccount = new Account();
        if (RobsAccount.WithdrawFunds(5))
        {
            Console.WriteLine("Cash Withdrawn");
        }
        else
        {
            Console.WriteLine("Insufficient Funds");
        }
    }
}

