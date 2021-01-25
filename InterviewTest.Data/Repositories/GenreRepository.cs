using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InterviewTest.Data
{
    //Retrieve Genre data from database
    public class GenreRepository:BaseRepository,IGenreRepository
    {
        public GenreRepository(IConfiguration config) : base(config)
        {

        }

        public List<GenreBook_DTO> GetGenre()
        {
            var results = new List<GenreBook_DTO>();
            dataTable = new DataTable();
            try
            {
                query = new SqlCommand("[GetGenres]", new SqlConnection(connectionString));
                query.CommandType = CommandType.StoredProcedure;



                dataAdapter = new SqlDataAdapter(query);
                dataAdapter.Fill(dataTable);
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    results.Add(new GenreBook_DTO(dataTable.Rows[i]));
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
