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
    public class KonsumenRepo : IKonsumen
    {
        IConfiguration _configuration;
        DynamicParameters parameters = new DynamicParameters();
        public KonsumenRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int Create(KonsumenVM konsumenVM)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPInsertKonsumen";
                parameters.Add("nama", konsumenVM.nama);
                parameters.Add("addr", konsumenVM.alamat);
                parameters.Add("phone", konsumenVM.tlp);
                var insert = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPDeleteKonsumen";
                parameters.Add("id", id);
                var Delete = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Delete;
            }
        }

        public async Task<IEnumerable<KonsumenVM>> getAll()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetAllKonsumen";
                var getAll = await connection.QueryAsync<KonsumenVM>(procName, commandType: CommandType.StoredProcedure);
                return getAll;
            }
        }

        public KonsumenVM getID(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetIDKonsumen";
                parameters.Add("id", id);
                var getId = connection.Query<KonsumenVM>(procName, parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return getId;
            }
        }

        public int Update(KonsumenVM konsumenVM, int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPEditKonsumen";
                parameters.Add("id", id);
                parameters.Add("nama", konsumenVM.nama);
                parameters.Add("addr", konsumenVM.alamat);
                parameters.Add("phone", konsumenVM.tlp);
                var Edit = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Edit;
            }
        }

    }
}
