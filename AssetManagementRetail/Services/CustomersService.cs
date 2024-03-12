using AssetManagementRetail.Data;
using AssetManagementRetail.Models;
using Dapper;
using Microsoft.AspNetCore.Connections;
using Npgsql;

namespace AssetManagementRetail.Services
{
    public class CustomersService
    {
        private readonly AssetDBConn _assetDBConn;

        public CustomersService(AssetDBConn assetDBConn)
        {
            _assetDBConn = assetDBConn;
        }

        public async Task<List<Customers>> GetAllCustomersAsync()
        {
            using (var connection = _assetDBConn.CreateConnection())
            {
                string query = "SELECT * FROM Customers";
                return (await connection.QueryAsync<Customers>(query)).ToList();
            }
        }
        public async Task<Customers> GetCustomerByIdAsync(int customerId)
        {
            using (var connection = _assetDBConn.CreateConnection())
            {
                string query = "SELECT * FROM Customers WHERE CustomerId = @CustomerId";
                return await connection.QueryFirstOrDefaultAsync<Customers>(query, new { CustomerId = customerId });
            }
        }

        public async Task<int> AddCustomerAsync(Customers customer)
        {
            using (var connection = _assetDBConn.CreateConnection())
            {
                string query = @"INSERT INTO Customers (FirstName, LastName, Email) 
                             VALUES (@FirstName, @LastName, @Email)
                             RETURNING CustomerId";
                return await connection.QueryFirstOrDefaultAsync<int>(query, customer);
            }
        }

        public async Task<bool> UpdateCustomerAsync(Customers customer)
        {
            using (var connection = _assetDBConn.CreateConnection())
            {
                string query = @"UPDATE Customers 
                             SET FirstName = @FirstName, LastName = @LastName, Email = @Email
                             WHERE CustomerId = @CustomerId";
                var rowsAffected = await connection.ExecuteAsync(query, customer);
                return rowsAffected > 0;
            }
        }

        public async Task<bool> DeleteCustomerAsync(int customerId)
        {
            using (var connection = _assetDBConn.CreateConnection())
            {
                string query = "DELETE FROM Customers WHERE CustomerId = @CustomerId";
                var rowsAffected = await connection.ExecuteAsync(query, new { CustomerId = customerId });
                return rowsAffected > 0;
            }
        }
    }
}
