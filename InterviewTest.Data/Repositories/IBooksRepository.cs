using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.Data
{
   public interface IBooksRepository
    {
        List<Books_DTO> GetBooks();
    }
}
