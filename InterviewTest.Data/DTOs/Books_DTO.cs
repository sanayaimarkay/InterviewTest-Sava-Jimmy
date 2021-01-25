using System;
using System.Data;

namespace InterviewTest.Data
{
    //Class that reflects the Book table in database
    public class Books_DTO
    {
        #region Properties
        public Int64 Id { get; set; }
        public string Title { get; set; }
        public string Forename { get; set; }
        public string Surname { get; set; }
        public string ISBN { get; set; }
        public int FirstPublished { get; set; }
        public string ImageUrl { get; set; }

        #endregion

        #region Intialisation
        public Books_DTO(DataRow dr)
        {
            try
            {
                if (dr["Id"] != DBNull.Value) { Id = (Int64)dr["Id"]; }
                if (dr["Title"] != DBNull.Value) { Title = (string)dr["Title"]; }
                if (dr["Forename"] != DBNull.Value) { Forename = (string)dr["Forename"]; }
                if (dr["Surname"] != DBNull.Value) { Surname = (string)dr["Surname"]; }
                if (dr["ISBN"] != DBNull.Value) { ISBN = (string)dr["ISBN"]; }
                if (dr["FirstPublished"] != DBNull.Value) { FirstPublished = (int)dr["FirstPublished"]; }
                if (dr["ImageUrl"] != DBNull.Value) { ImageUrl = (string)dr["ImageUrl"]; }

            }
            catch (Exception ex)
            {
#if DEBUG
                throw ex;
#endif
            }

        }
        #endregion
    }
}
