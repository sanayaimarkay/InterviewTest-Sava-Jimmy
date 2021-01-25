using InterviewTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTestMvc
{
    //BookDetailsViewModel combines book,review and genre
    public class BookDetailsViewModel
    {
       public  Books_DTO Book { get; set; }
       public List<Reviews_DTO> Reviews { get; set; }
       public List<string> Genres { get; set; }

    }
}
