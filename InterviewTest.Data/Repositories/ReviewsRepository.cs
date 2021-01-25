using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace InterviewTest.Data
{
    //Retrieve reviews data from database
    public class ReviewsRepository : BaseRepository, IReviewsRepository
    {
        public ReviewsRepository(IConfiguration config) : base(config)
        {

        }

        public List<Reviews_DTO> GetReviews()
        {
            var results = new List<Reviews_DTO>();
            dataTable = new DataTable();
            try
            {
                query = new SqlCommand("[GetReviews]", new SqlConnection(connectionString));
                query.CommandType = CommandType.StoredProcedure;



                dataAdapter = new SqlDataAdapter(query);
                dataAdapter.Fill(dataTable);
                for (Int32 i = 0; i < dataTable.Rows.Count; i++)
                {
                    results.Add(new Reviews_DTO(dataTable.Rows[i]));
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
        public bool AddReview(Reviews_DTO review)
        {
            try
            {
                SqlCommand query = new SqlCommand("[ReviewAdd]", new SqlConnection(connectionString));
                query.CommandType = CommandType.StoredProcedure;

                SqlParameter param;

                param = query.Parameters.Add("@BookId", SqlDbType.BigInt);
                param.Value = review.BookId;

                param = query.Parameters.Add("@Name", SqlDbType.VarChar, 64);
                param.Value = review.Name;

                param = query.Parameters.Add("@Rating", SqlDbType.Int);
                param.Value = review.Rating;

                param = query.Parameters.Add("@Review", SqlDbType.VarChar);
                param.Value = review.Review;

                param = query.Parameters.Add("@ReviewedOn", SqlDbType.DateTime);
                param.Value = review.ReviewedOn;

                // Execute the command.
                query.Connection.Open();
                query.ExecuteNonQuery();
                query.Connection.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }

            finally
            {
                Dispose();
            }


            return true;
        }
    }
}
