using System.Collections.Generic;
using MongoDB.Driver;
using Hospitality_Management_System.Models;

namespace Hospitality_Management_System.Persistence
{
    public class BillingEF : IBillingDataAccess
    {
        private readonly HospitalityContext _context = new HospitalityContext();

        public List<Billing> GetBillings()
        {
            return _context.Billings.Find(_ => true).ToList();
        }

        public Billing GetBillingById(string id)
        {
            var filter = Builders<Billing>.Filter.Eq(b => b.BillID, id);
            return _context.Billings.Find(filter).FirstOrDefault();
        }

        public void InsertBilling(Billing billing)
        {
            _context.Billings.InsertOne(billing);
        }

        public void UpdateBilling(Billing billing)
        {
            var filter = Builders<Billing>.Filter.Eq(b => b.BillID, billing.BillID);
            _context.Billings.ReplaceOne(filter, billing);
        }

        public void DeleteBilling(string id)
        {
            var filter = Builders<Billing>.Filter.Eq(b => b.BillID, id);
            _context.Billings.DeleteOne(filter);
        }
    }
}
