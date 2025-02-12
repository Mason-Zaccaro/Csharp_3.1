using System;
using System.IO;

class BankAccount
{
    private decimal _balance;

    public decimal Balance
    {
        get { return _balance; }
        private set
        {
            if (_balance != value)
            {
                _balance = value;
                BalanceChanged?.Invoke(_balance);
            }
        }
    }

    public event Action<decimal> BalanceChanged;

    public void Deposit(decimal amount)
    {
        if (amount > 0)
            Balance += amount;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > 0 && amount <= Balance)
            Balance -= amount;
    }
}

class Logger
{
    private const string LogFilePath = "balance_log.txt";

    public Logger(BankAccount account)
    {
        account.BalanceChanged += OnBalanceChanged;
    }

    private void OnBalanceChanged(decimal newBalance)
    {
        string logMessage = $"Balance changed to: {newBalance} at {DateTime.Now}";
        File.AppendAllText(LogFilePath, logMessage + Environment.NewLine);
    }
}

class Program
{
    static void Main(string[] args)
    {
        BankAccount account = new BankAccount();
        Logger logger = new Logger(account);

        account.Deposit(1000);
        account.Withdraw(500);
        account.Deposit(200);
    }
}