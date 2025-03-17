using Hospitality_Management_System.Models;
using HospitalityManagementSystem.Models;
using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HospitalityManagementSystem.Services
{
    public class BillingService
    {
        private readonly IMongoCollection<Billing> _billings;

        public BillingService(IMongoDatabase database)
        {
            _billings = database.GetCollection<Billing>("Billings");
        }

        // Get all billings
        public async Task<List<Billing>> GetBillingsAsync()
        {
            return await _billings.Find(_ => true).ToListAsync();
        }

        // Get billing by ID
        public async Task<Billing?> GetBillingByIdAsync(string id)
        {
            var filter = Builders<Billing>.Filter.Eq(b => b.Id, id);
            return await _billings.Find(filter).FirstOrDefaultAsync();
        }

        // Create a new billing record
        public async Task<bool> CreateBillingAsync(Billing billing)
        {
            // Check if a billing with the same BillId already exists (optional, depending on your use case)
            var existingBilling = await _billings.Find(b => b.Id == billing.Id).FirstOrDefaultAsync();
            if (existingBilling != null) return false;

            await _billings.InsertOneAsync(billing);
            return true;
        }

        // Update an existing billing record
        public async Task<bool> UpdateBillingAsync(Billing billing)
        {
            var filter = Builders<Billing>.Filter.Eq(b => b.Id, billing.Id);
            var updateResult = await _billings.ReplaceOneAsync(filter, billing);
            return updateResult.IsAcknowledged && updateResult.ModifiedCount > 0;
        }

        // Delete a billing record by ID
        public async Task<bool> DeleteBillingAsync(string id)
        {
            var filter = Builders<Billing>.Filter.Eq(b => b.Id, id);
            var deleteResult = await _billings.DeleteOneAsync(filter);
            return deleteResult.IsAcknowledged && deleteResult.DeletedCount > 0;
        }
    }
}
