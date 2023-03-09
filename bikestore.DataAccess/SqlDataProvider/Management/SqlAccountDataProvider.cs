using System.Data;
using System.Data.SqlClient;
using bikestore.Core;
using bikestore.Core.Entity;
using bikestore.Core.Helper;
using bikestore.DataAccess.DataMapper.Management;
using bikestore.DataAccess.DataProvider.Management;
using bikestore.Entity.Management;

namespace bikestore.DataAccess.SqlDataProvider.Management
{
    public class SqlAccountDataProvider : IAccountDataProvider
    {
        private readonly ICommonService _commonService;

        public SqlAccountDataProvider(ICommonService commonService)
        {
            _commonService = commonService;
        }


        public Account GetByEmail(string email)
        {
            Account result = new();
            try
            {
                SqlConnection con = new()
                {
                    ConnectionString = _commonService.GetConnectionString(),
                };

                using (con)
                {
                    SqlCommand cmd = new("Account_GetByEmail", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email;
                    con.Open();

                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        var map = new AccountDataMapper();
                        var account = map.MapAll(dataReader);
                        if (account.Count == 1)
                            result = account[0];
                    }
                }
                con.Close();
            }
            catch
            {
            }
            return result;
        }


        public ExecutionResult Insert(Account entity)
        {

            var rs = new ExecutionResult();
            try
            {
                bool IsSucess = false;
                SqlConnection con = new()
                {
                    ConnectionString = _commonService.GetConnectionString(),
                };

                using (con)
                {
                    SqlCommand cmd = new("Account_Insert", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entity.Email;
                    cmd.Parameters.Add("@PasswordHash", SqlDbType.VarChar).Value = entity.PasswordHash;
                    cmd.Parameters.Add("@PasswordSalt", SqlDbType.VarChar).Value = entity.PasswordSalt;
                    cmd.Parameters.Add("@PasswordResetCode", SqlDbType.VarChar).Value = entity.PasswordResetCode;

                    cmd.Parameters.Add("@Id", SqlDbType.Int).Direction = ParameterDirection.Output;
                    cmd.Parameters.Add("@OUT_PUT", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    con.Open();

                    cmd.ExecuteNonQuery();

                    entity.Id = ConvertHelper.ToInt32(cmd.Parameters["@Id"].Value);
                    IsSucess = ConvertHelper.ToBoolean(cmd.Parameters["@OUT_PUT"].Value);

                }
                con.Close();

                rs.DataOutput = IsSucess;

                if (IsSucess)
                {
                    rs.Result = ExecutionResult.StatusCode.OK;
                    rs.Data = entity;
                }
                else
                {
                    rs.Result = ExecutionResult.StatusCode.FORBIDDEN;
                }
            }
            catch (Exception ex)
            {
                rs.Result = ExecutionResult.StatusCode.INTERNAL_SERVER_ERROR;
                rs.UserMessage = ex.Message;
            }
            return rs;
        }


        #region not implement
        public ExecutionResult Update(Account entity)
        {
            throw new NotImplementedException();
        }
        public Account GetById(int id)
        {
            throw new NotImplementedException();
        }
        public List<Account> GetAll()
        {
            throw new NotImplementedException();
        }
        public ExecutionResult Delete(int id)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}

