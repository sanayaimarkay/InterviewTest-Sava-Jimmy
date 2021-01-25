using InterviewTest.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterviewTestMvc
{
    //BookGenreViewModel is a combination of book,genre and review count
    public class BookGenreViewModel
    {
        public Books_DTO book { get; set; }
        public string genre { get; set;}
        public int reviewCount { get; set; }
    }
}
