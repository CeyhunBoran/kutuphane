using System;

namespace Kutuphane.Logic
{
    public interface ITransactionService
    {
        string Login(string username, string password);
    }
    public class TransactionService : ITransactionService
    {
        public string Login(string username, string password)
        {
            throw new NotImplementedException();
        }
    }
}
