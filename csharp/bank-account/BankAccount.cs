using System;

public class BankAccount
{
    bool isOpened;
    decimal balance;
    public void Open()
    {
        isOpened = true;
    }

    public void Close()
    {
        isOpened = false;
    }

    public decimal Balance  => isOpened ? balance : throw new InvalidOperationException("Account is closed.");

    public void UpdateBalance(decimal change)
    {
        if (!isOpened)
            throw new InvalidOperationException("Account is closed.");

        lock (this)
        {
           balance += change;       
        }
    }
}
