using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace InterviewTest.Data
{
    //Class that reflects the GetGenres stored procedure in database
    public class GenreBook_DTO
    {
        #region Properties
        
        public Int64 Id{ get; set; }
        public string Description{ get; set; }
        

        #endregion

        #region Intialisation
        public GenreBook_DTO(DataRow dr)
        {
            try
            {
                if (dr["Id"] != DBNull.Value) { Id = (Int64)dr["Id"]; }
                if (dr["Description"] != DBNull.Value) { Description = (string)dr["Description"]; }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        #endregion
    }
}
