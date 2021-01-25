using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace InterviewTest.Data
{
    //Class that reflects the Review table in database
    public class Reviews_DTO
    {
        #region Properties
        public Int64 Id { get; set; }
        public Int64 BookId { get; set; }
        public int Rating { get; set; }
        public string Name { get; set; }
        public string Review { get; set; }
        public DateTime ReviewedOn { get; set; }
        #endregion

        #region Intialisation
        public Reviews_DTO()
        {

        }
        public Reviews_DTO(DataRow dr)
        {
            try
            {
                if (dr["Id"] != DBNull.Value) { Id = (Int64)dr["Id"]; }
                if (dr["BookId"] != DBNull.Value) { BookId = (Int64)dr["BookId"]; }
                if (dr["Rating"] != DBNull.Value) { Rating = (int)dr["Rating"]; }
                if (dr["Name"] != DBNull.Value) { Name = (string)dr["Name"]; }
                if (dr["Review"] != DBNull.Value) { Review = (string)dr["Review"]; }
                if (dr["ReviewedOn"] != DBNull.Value) { ReviewedOn = (DateTime)dr["ReviewedOn"]; }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
