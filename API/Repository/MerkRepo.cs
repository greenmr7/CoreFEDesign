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
    public class MerkRepo : IMerk
    {
        IConfiguration _configuration;
        DynamicParameters parameters = new DynamicParameters();
        public MerkRepo(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public int Create(MerkVM merkVM)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPInsertMerk";
                parameters.Add("merk", merkVM.Merk);
                var insert = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return insert;
            }
        }

        public int Delete(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPDeleteMerk";
                parameters.Add("id", id);
                var Delete = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Delete;
            }
        }

        public async Task<IEnumerable<MerkVM>> getAll()
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetAllMerk";
                var getAll = await connection.QueryAsync<MerkVM>(procName, commandType: CommandType.StoredProcedure);
                return getAll;
            }
        }

        public MerkVM getID(int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPGetIDMerk";
                parameters.Add("id", id);
                var getId = connection.Query<MerkVM>(procName, parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
                return getId;
            }
        }

        public int Update(MerkVM merkVM, int id)
        {
            using (SqlConnection connection = new SqlConnection(_configuration.GetConnectionString("myConn")))
            {
                var procName = "SPEditMerk";
                parameters.Add("id", id);
                parameters.Add("merk", merkVM.Merk);
                var Edit = connection.Execute(procName, parameters, commandType: CommandType.StoredProcedure);
                return Edit;
            }
        }

        
    }
}
