using Hospitality_Management_System.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Hospitality_Management_System.Services
{
    public class BillingService
    {
        private readonly IMongoCollection<Billing> _billings;

        public BillingService(IMongoDatabase database)
        {
            _billings = database.GetCollection<Billing>("Billings");
        }

        // Create a new billing record
        public async Task CreateBillingAsync(Billing billing)
        {
            await _billings.InsertOneAsync(billing);
        }

        // Get billing record by ID
        public async Task<Billing?> GetBillingByIdAsync(string id)
        {
            return await _billings.Find(b => b.Id == id).FirstOrDefaultAsync();
        }

        // Get all billing records
        public async Task<List<Billing>> GetAllBillingsAsync()
        {
            return await _billings.Find(_ => true).ToListAsync();
        }

        // Update a billing record
        public async Task<bool> UpdateBillingAsync(string id, Billing updatedBilling)
        {
            var result = await _billings.ReplaceOneAsync(b => b.Id == id, updatedBilling);
            return result.ModifiedCount > 0;
        }

        // Delete a billing record by ID
        public async Task<bool> DeleteBillingAsync(string id)
        {
            var result = await _billings.DeleteOneAsync(b => b.Id == id);
            return result.DeletedCount > 0;
        }
    }
}
