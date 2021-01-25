using System;
using System.Collections.Generic;
using System.Text;

namespace InterviewTest.Data
{
    public interface IReviewsRepository
    {
        List<Reviews_DTO> GetReviews();
        bool AddReview(Reviews_DTO review);
    }
}
