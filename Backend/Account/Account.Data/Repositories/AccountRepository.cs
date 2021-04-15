using System.Collections.Generic;
using System.Threading.Tasks;
using Account.Data.Interfaces;
using Account.Service.Models.Query;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Account.Data.Repositories
{
    public class AccountRepository : GenericRepository<Domain.Account>, IAccountRepository
    {

        public AccountRepository(AccountContext context) : base(context)
        {
        }

        private readonly string connectionStr = "Server=localhost,1433; Database=AccountDataBase; User=sa; Password=yourStrong(!)Password;";

        public async Task<List<Domain.Account>> SearchAccount(SearchAccount request)
        {
            using(SqlConnection con = new SqlConnection(connectionStr))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;
                cmd.CommandText = "SearchAccountStoreProcedure";
                cmd.CommandType = System.Data.CommandType.StoredProcedure;

                if(!string.IsNullOrEmpty(request.FirstName))
                {
                    SqlParameter param = new SqlParameter("@FirstName", request.FirstName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(request.LastName))
                {
                    SqlParameter param = new SqlParameter("@LastName", request.LastName);
                    cmd.Parameters.Add(param);
                }

                if (!string.IsNullOrEmpty(request.Username))
                {
                    SqlParameter param = new SqlParameter("@Username", request.Username);
                    cmd.Parameters.Add(param);
                }

                if (request.Role != 0 && request.Role != null)
                {
                    SqlParameter param = new SqlParameter("@Role", request.Role);
                    cmd.Parameters.Add(param);
                }

                con.Open();
                var dataReader = await cmd.ExecuteReaderAsync();

                var accounts = new List<Domain.Account>();

                if(dataReader.HasRows)
                {
                    while (dataReader.Read())
                    {
                        var pom = new Domain.Account()
                        {
                            FirstName = dataReader["FirstName"].ToString(),
                            LastName = dataReader["LastName"].ToString(),
                            Password = dataReader["Password"].ToString(),
                            Username = dataReader["Username"].ToString(),
                            Id = int.Parse(dataReader["Id"].ToString()),
                            Role = int.Parse(dataReader["Role"].ToString()),
                            PhoneNumber = dataReader["PhoneNumber"].ToString(),
                            Address = dataReader["Address"].ToString()
                        };

                        accounts.Add(pom);
                    }
                }

                dataReader.Close();
                con.Close();

                return accounts;
            }
        }
    }
}
