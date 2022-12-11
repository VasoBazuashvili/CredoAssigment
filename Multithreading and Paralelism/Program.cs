// See https://aka.ms/new-console-template for more information
using Multithreading_and_Paralelism;

Console.WriteLine("Hello, World!");

BankAccount account1 = new BankAccount();
BankAccount account2 = new BankAccount();
TransactionService transferService = new TransactionService();
var tasks = new List<Task>();
var amountToTransfer = 10000;

for (var i = 0; i < 101; i++)
{
    var task = Task.Run(() =>
    {
        transferService.Transfer(account1, account2, amountToTransfer);
    });
    tasks.Add(task);
}
Task.WaitAll(tasks.ToArray());

ValidateResults();


void ValidateResults()
{
    var expectedAccount1Balance = 0;
    var expectedAccount2Balance = 1_000_000;
    if (account1.Balance != expectedAccount1Balance)
    {
        Console.WriteLine($"Something went wrong with account1. Expected balance is {expectedAccount1Balance} but was {account1.Balance}");
    }
    else
    {
        Console.WriteLine("account1 balance is correct");
    }

    if (account2.Balance != expectedAccount2Balance)
    {
        Console.WriteLine($"Something went wrong with account2. Expected balance is {expectedAccount2Balance} but was {account2.Balance}");
    }
    else
    {
        Console.WriteLine("account2 balance is correct");
    }
}
