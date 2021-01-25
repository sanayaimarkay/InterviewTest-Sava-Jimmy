using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InterviewTest.Data
{
    //Retrieve books data from database
    public class BooksRepository :  BaseRepository,IBooksRepository
    {
        
        public BooksRepository(IConfiguration config) : base(config)
        {

        }
        
        public List<Books_DTO> GetBooks()
        {
            var results = new List<Books_DTO>();
            dataTable = new DataTable();
            try
            {
                query = new SqlCommand("[GetBooks]", new SqlConnection(connectionString));
                query.CommandType = CommandType.StoredProcedure;



                dataAdapter = new SqlDataAdapter(query);
                dataAdapter.Fill(dataTable);
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    results.Add(new Books_DTO(dataTable.Rows[i]));
                }
            }
            catch (Exception ex)
            {
               

                throw ex;

            }
            finally
            {
                Dispose();
            }

            return results;
        }
    }
}
