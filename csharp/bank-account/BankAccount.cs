using System;

public class BankAccount
{
    object balancer = new object();
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

        lock (balancer)
        {
           balance += change;       
        }
    }
}
