using System.Collections.Generic;

namespace BankApp
{
    public interface IAuditLogger
    {
        void AddMessage(string message);
        List<string> GetLog();
    }
}