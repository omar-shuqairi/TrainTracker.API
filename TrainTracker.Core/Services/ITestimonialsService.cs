using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;

namespace TrainTracker.Core.Services
{
    public interface ITestimonialsService
    {
        List<Testimonial> GetAllTestimonials();
        void CreateTestimonial(Testimonial testimonial);
        void UpdateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
        Testimonial GetTestimonialById(int id);
        List<ManageTestimonialsDto> GetApprovedTestimonialsForAdmindash();
        List<ManageTestimonialsDto> GetPendingTestimonials();
        List<ManageTestimonialsDto> GetRejectedTestimonials();
        List<ViewTestimonialsDto> GetApprovedTestimonialsForHome();
        void UpdateTestimonialToApprove(int id);
        void UpdateTestimonialToReject(int id);

    }
}
