using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.Services;
using TrainTracker.Infra.Services;

namespace TrainTracker.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {
        private readonly ITestimonialsService _testimonialsService;

        public TestimonialsController(ITestimonialsService testimonialsService)
        {
            _testimonialsService = testimonialsService;
        }
        [HttpGet]
        public List<Testimonial> GetAllTestimonials()
        {
            return _testimonialsService.GetAllTestimonials();
        }

        [HttpGet]
        [Route("getbyId/{id}")]
        public Testimonial GetTestimonialById(int id)
        {
            return _testimonialsService.GetTestimonialById(id);
        }


        [HttpPost]
        public void CreateTestimonial(Testimonial testimonial)
        {
            _testimonialsService.CreateTestimonial(testimonial);
        }

        [HttpPut]
        public void UpdateTestimonial(Testimonial testimonial)
        {
            _testimonialsService.UpdateTestimonial(testimonial);
        }

        [HttpDelete]
        [Route("DeleteTestimonial/{id}")]

        public void DeleteTestimonial(int id)
        {
            _testimonialsService.DeleteTestimonial(id);
        }
    }
}
