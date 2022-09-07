using Dapper;
using FitemaAPI.Database;
using FitemaAPI.Repository.Contracts;
using FitemaEntity.Models;
using FitemaEntity.Utils.Constants;

namespace FitemaAPI.Repository.Impl
{
    public class BillRepository : IBillRepository
    {
        private readonly IDatabaseConnectionFactory _databaseConnectionFactory;

        public BillRepository(IDatabaseConnectionFactory databaseConnectionFactory)
        {
            _databaseConnectionFactory = databaseConnectionFactory;
        }

        public async Task<int> CreateBill(Bills data)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            return await db.ExecuteScalarAsync<int>(@"
                insert into Bills (
                    OrgId, PlanId, VoucherCode, TotalPayment, StatusId, StartDate, EndDate
                )
                values (
                    @OrgId, @PlanId, @VoucherCode, @TotalPayment, @StatusId, @StartDate, @EndDate
                );
                select Id from Bills where Id = last_insert_id()
            ", data);
        }

        public async Task<Bills> GetActiveBill(int orgId)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            var status = StatusActive.ACTIVE;
            return await db.QueryFirstAsync<Bills>(@"
            select * from Bills 
            where Status = @status OrgId = @id", new { status = status, id = orgId });
        }

        public async Task<IEnumerable<Bills>> GetListBill(int orgId)
        {
            var db = _databaseConnectionFactory.GetDbConnection();
            return await db.QueryAsync<Bills>(@"
            select * from Bills 
            where OrgId = @id", new { id = orgId });
        }

        public async Task UpdateBillStatus(int billId, int statusId)
        {
            using var db = _databaseConnectionFactory.GetDbConnection();
            await db.ExecuteAsync(@"
                update Bills 
                set StatusId = @statusId,
                    UpdatedAt = @now
                where Id = @id
            ", new { id = billId, statusId = statusId, now = DateTime.UtcNow });
        }
    }
}
