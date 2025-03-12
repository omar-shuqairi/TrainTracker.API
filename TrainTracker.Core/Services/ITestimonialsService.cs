using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Data;

namespace TrainTracker.Core.Services
{
    public interface ITestimonialsService
    {
        List<Testimonial> GetAllTestimonials();
        void CreateTestimonial(Testimonial testimonial);
        void UpdateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
        Testimonial GetTestimonialById(int id);
    }
}
