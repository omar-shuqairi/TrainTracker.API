using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
using TrainTracker.Core.Repository;
using TrainTracker.Core.Services;

namespace TrainTracker.Infra.Services
{
    public class TestimonialsService : ITestimonialsService
    {
        private readonly ITestimonialsRepository _testimonialsRepository;

        public TestimonialsService(ITestimonialsRepository testimonialsRepository)
        {
            _testimonialsRepository = testimonialsRepository;
        }

        public void CreateTestimonial(Testimonial testimonial)
        {
            _testimonialsRepository.CreateTestimonial(testimonial);
        }

        public void DeleteTestimonial(int id)
        {
            _testimonialsRepository.DeleteTestimonial(id);
        }

        public List<Testimonial> GetAllTestimonials()
        {
            return _testimonialsRepository.GetAllTestimonials();
        }

        public Testimonial GetTestimonialById(int id)
        {
            return _testimonialsRepository.GetTestimonialById(id);
        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialsRepository.UpdateTestimonial(testimonial);
        }

        public List<ManageTestimonialsDto> GetApprovedTestimonialsForAdmindash()
        {
            return _testimonialsRepository.GetApprovedTestimonialsForAdmindash();
        }

        public List<ManageTestimonialsDto> GetPendingTestimonials()
        {
            return _testimonialsRepository.GetPendingTestimonials();
        }

        public List<ManageTestimonialsDto> GetRejectedTestimonials()
        {
            return _testimonialsRepository.GetRejectedTestimonials();
        }

        public List<ViewTestimonialsDto> GetApprovedTestimonialsForHome()
        {
            return _testimonialsRepository.GetApprovedTestimonialsForHome();
        }

        public void UpdateTestimonialToApprove(int id)
        {
            _testimonialsRepository.UpdateTestimonialToApprove(id);
        }

        public void UpdateTestimonialToReject(int id)
        {
            _testimonialsRepository.UpdateTestimonialToReject(id);
        }
    }
}
