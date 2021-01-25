using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InterviewTest.Data
{
    
    public class BaseRepository
    {
        #region Local Variables
        internal String connectionString = null;
        internal SqlCommand query = null;
        internal SqlDataAdapter dataAdapter = null;
        internal DataTable dataTable = null;
        private readonly IConfiguration _Config;
        #endregion

        public BaseRepository(IConfiguration Config)
        {

            _Config = Config;
            try
            {
                connectionString = _Config.GetConnectionString("BooksConnection");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Dispose the ADO accessors and containers
        ///</summary>
        internal void Dispose()
        {
            if (dataAdapter != null)
            {
                dataAdapter.Dispose();
            }
            if (dataTable != null)
            {
                dataTable.Clear();
                dataTable.Dispose();
            }
            if (query != null)
            {
                if (query.Connection.State == ConnectionState.Open)
                {
                    query.Connection.Close();
                }
                query.Dispose();
            }
        }
    }
}
