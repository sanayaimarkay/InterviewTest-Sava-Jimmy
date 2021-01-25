using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTestMvc
{
    public class Reviews
    {
        #region Properties
        public Int64 BookId { get; set; }
        [Required]
        public int Rating { get; set; }
        public string Name { get; set; }
        [Required]
        public string Review { get; set; }
        public DateTime ReviewedOn { get; set; }
        #endregion
    }
}
