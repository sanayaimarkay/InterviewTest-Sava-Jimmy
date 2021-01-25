using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.Data
{
    public interface IGenreRepository
    {
        List<GenreBook_DTO> GetGenre();
    }
}
