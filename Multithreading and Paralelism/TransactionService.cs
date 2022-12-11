using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Multithreading_and_Paralelism
{
    public class TransactionService
    {

        private static object _lockObject = new object();
        public void Transfer(BankAccount fromTheAccount,BankAccount toTheAccount, decimal amount)
        {
            lock (_lockObject)
            {
                if (amount < fromTheAccount.Balance)
                {
                    Console.WriteLine($"{fromTheAccount.Iban} has insufficient funds");
                    return;
                }
                fromTheAccount.Balance -= amount;
                toTheAccount.Balance += amount;
            }
        }
    }
}
