using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainTracker.Core.Data;
using TrainTracker.Core.DTO;
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

        [HttpGet]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        [Route("GetApprovedTestimonialsForAdmindash")]
        public List<ManageTestimonialsDto> GetApprovedTestimonialsForAdmindash()
        {
            return _testimonialsService.GetApprovedTestimonialsForAdmindash();
        }

        [HttpGet]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        [Route("GetPendingTestimonials")]
        public List<ManageTestimonialsDto> GetPendingTestimonials()
        {
            return _testimonialsService.GetPendingTestimonials();
        }

        [HttpGet]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        [Route("GetRejectedTestimonials")]
        public List<ManageTestimonialsDto> GetRejectedTestimonials()
        {
            return _testimonialsService.GetRejectedTestimonials();
        }

        [HttpGet]
        [Route("GetApprovedTestimonialsForHome")]
        public List<ViewTestimonialsDto> GetApprovedTestimonialsForHome()
        {
            return _testimonialsService.GetApprovedTestimonialsForHome();
        }

        [HttpPost]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        [Route("UpdateTestimonialToApprove/{id}")]
        public void UpdateTestimonialToApprove(int id)
        {
            _testimonialsService.UpdateTestimonialToApprove(id);
        }

        [HttpPost]
        [Authorize]
        [CheckClaimsAtt("RoleId", "1")]
        [Route("UpdateTestimonialToReject/{id}")]
        public void UpdateTestimonialToReject(int id)
        {
            _testimonialsService.UpdateTestimonialToReject(id);
        }

        [HttpPost]
        [Route("PostTestimonialFromUsers")]

        public void PostTestimonialFromUsers(PostTestimonialFromUsersDto postTestimonial)
        {
            _testimonialsService.PostTestimonialFromUsers(postTestimonial);
        }



    }
}
