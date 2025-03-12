using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;
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
    }
}
