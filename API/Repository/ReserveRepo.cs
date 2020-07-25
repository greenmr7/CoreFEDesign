using Dapper;
using API.Repository.Interface;
using API.ViewModels;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace API.Repository
{
    public class ReserveRepo : IReserve
    {
        IConfiguration _configuration;
        DynamicParameters parameters = new DynamicParameters();
        public ReserveRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int Create(ReserveVM reserveVM)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPInsertReserve";
                parameters.Add("start", reserveVM.start_date);
                parameters.Add("end", reserveVM.end_date);
                parameters.Add("status", reserveVM.status);
                parameters.Add("tot", reserveVM.total);
                parameters.Add("tgl_bayar", reserveVM.tgl_bayar);
                parameters.Add("carID", reserveVM.carID);
                parameters.Add("konsumenID", reserveVM.konsumenID);
                var insert = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPDeleteReserve";
                parameters.Add("id", id);
                var Delete = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Delete;
            }
        }

        public async Task<IEnumerable<ReserveVM>> getAll()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetAllReserve";
                var getAll = await connection.QueryAsync<ReserveVM>(procName, commandType: CommandType.StoredProcedure);
                return getAll;
            }
        }

        public ReserveVM getID(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetIDReserve";
                parameters.Add("id", id);
                var getId = connection.Query<ReserveVM>(procName, parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return getId;
            }
        }

        public int Update(ReserveVM reserveVM, int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPEditReserve";
                parameters.Add("id", id);
                parameters.Add("start", reserveVM.start_date);
                parameters.Add("end", reserveVM.end_date);
                parameters.Add("status", reserveVM.status);
                parameters.Add("tot", reserveVM.total);
                parameters.Add("tgl_bayar", reserveVM.tgl_bayar);
                parameters.Add("carID", reserveVM.carID);
                parameters.Add("konsumenID", reserveVM.konsumenID);
                var Edit = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Edit;
            }
        }

    }
}
