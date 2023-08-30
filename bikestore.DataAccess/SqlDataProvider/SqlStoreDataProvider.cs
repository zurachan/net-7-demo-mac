using System.Data;
using System.Data.SqlClient;
using bikestore.Core;
using bikestore.Core.Entity;
using bikestore.Core.Helper;
using bikestore.DataAccess.DataMapper.Sale;
using bikestore.DataAccess.DataProvider;
using bikestore.Entity.BikeStore.Sale;

namespace bikestore.DataAccess.SqlDataProvider
{
    public class SqlStoreDataProvider : IStoreDataProvider
    {
        private readonly ICommonService _commonService;

        public SqlStoreDataProvider(ICommonService commonService)
        {
            _commonService = commonService;
        }


        public List<Store> GetAll()
        {
            List<Store> result = new List<Store>();
            try
            {
                SqlConnection con = new()
                {
                    ConnectionString = _commonService.GetConnectionString(),
                };

                using (con)
                {
                    SqlCommand cmd = new("Store_GetAll", con)
                    {
                        CommandType = CommandType.StoredProcedure,
                    };
                    con.Open();

                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        var map = new StoreDataMapper();
                        result = map.MapAll(dataReader);
                    }
                }
                con.Close();
            }
            catch
            {
            }
            return result;
        }

        public Store GetById(int id)
        {
            Store result = new();
            try
            {
                SqlConnection con = new()
                {
                    ConnectionString = _commonService.GetConnectionString(),
                };

                using (con)
                {
                    SqlCommand cmd = new("Store_GetById", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;
                    con.Open();

                    using (IDataReader dataReader = cmd.ExecuteReader())
                    {
                        var map = new StoreDataMapper();
                        var stores = map.MapAll(dataReader);
                        if (stores.Count == 1)
                            result = stores[0];
                    }
                }
                con.Close();
            }
            catch
            {
            }
            return result;
        }

        public ExecutionResult Insert(Store entity)
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
                    SqlCommand cmd = new("Store_Insert", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = entity.Name;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = entity.Phone;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entity.Email;
                    cmd.Parameters.Add("@Street", SqlDbType.VarChar).Value = entity.Street;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = entity.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = entity.State;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = entity.ZipCode;
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

        public ExecutionResult Update(Store entity)
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
                    SqlCommand cmd = new("Store_Update", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = entity.Id;
                    cmd.Parameters.Add("@Name", SqlDbType.VarChar).Value = entity.Name;
                    cmd.Parameters.Add("@Phone", SqlDbType.VarChar).Value = entity.Phone;
                    cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = entity.Email;
                    cmd.Parameters.Add("@Street", SqlDbType.VarChar).Value = entity.Street;
                    cmd.Parameters.Add("@City", SqlDbType.VarChar).Value = entity.City;
                    cmd.Parameters.Add("@State", SqlDbType.VarChar).Value = entity.State;
                    cmd.Parameters.Add("@ZipCode", SqlDbType.VarChar).Value = entity.ZipCode;

                    cmd.Parameters.Add("@OUT_PUT", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    con.Open();

                    cmd.ExecuteNonQuery();

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

        public ExecutionResult Delete(int id)
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
                    SqlCommand cmd = new("Store_Delete", con)
                    {
                        CommandType = CommandType.StoredProcedure
                    };
                    cmd.Parameters.Add("@Id", SqlDbType.Int).Value = id;

                    cmd.Parameters.Add("@OUT_PUT", SqlDbType.Bit).Direction = ParameterDirection.Output;

                    con.Open();

                    cmd.ExecuteNonQuery();

                    IsSucess = ConvertHelper.ToBoolean(cmd.Parameters["@OUT_PUT"].Value);
                }
                con.Close();

                rs.DataOutput = IsSucess;

                if (IsSucess)
                {
                    rs.Result = ExecutionResult.StatusCode.OK;
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
    }
}

