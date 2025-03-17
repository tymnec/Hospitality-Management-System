using System.Collections.Generic;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public interface IBillingDataAccess
    {
        List<Billing> GetBillings();
        Billing GetBillingById(string billId);
        void InsertBilling(Billing billing);
        void UpdateBilling(Billing billing);
        void DeleteBilling(string billId);
    }
}
