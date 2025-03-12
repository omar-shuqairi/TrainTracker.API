﻿using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainTracker.Core.Common;
using TrainTracker.Core.Data;
using TrainTracker.Core.Repository;
using static System.Collections.Specialized.BitVector32;

namespace TrainTracker.Infra.Repository
{
    public class TestimonialsRepository : ITestimonialsRepository
    {
        private readonly IDbContext _dbContext;
        public TestimonialsRepository(IDbContext dbContext)
        {

            _dbContext = dbContext;

        }
        public void CreateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("p_Testimonial_Text", testimonial.TestimonialText, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Created_At", testimonial.CreatedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_User_ID", testimonial.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Testimonials_PKG.CreateTestimonial", p, commandType: CommandType.StoredProcedure);
        }

        public void DeleteTestimonial(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Testimonial_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            var result = _dbContext.Connection.Execute("Testimonials_PKG.DeleteTestimonial", p, commandType: CommandType.StoredProcedure);

        }

        public List<Testimonial> GetAllTestimonials()
        {

            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>
            ("Testimonials_PKG.GetAllTestimonials", commandType: CommandType.StoredProcedure);
            return result.ToList();
        }

        public Testimonial GetTestimonialById(int id)
        {
            var p = new DynamicParameters();
            p.Add("p_Testimonial_ID", id, dbType: DbType.Int32, direction: ParameterDirection.Input);
            IEnumerable<Testimonial> result = _dbContext.Connection.Query<Testimonial>
               ("Testimonials_PKG.GetTestimonialById", p, commandType: CommandType.StoredProcedure);
            return result.FirstOrDefault();
        }

        public void UpdateTestimonial(Testimonial testimonial)
        {
            var p = new DynamicParameters();
            p.Add("p_Testimonial_ID", testimonial.TestimonialId, dbType: DbType.Int32, direction: ParameterDirection.Input);
            p.Add("p_Testimonial_Text", testimonial.TestimonialText, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Status", testimonial.Status, dbType: DbType.String, direction: ParameterDirection.Input);
            p.Add("p_Created_At", testimonial.CreatedAt, dbType: DbType.DateTime, direction: ParameterDirection.Input);
            p.Add("p_User_ID", testimonial.UserId, dbType: DbType.Int32, direction: ParameterDirection.Input);

            var result = _dbContext.Connection.Execute("Testimonials_PKG.UpdateTestimonial", p, commandType: CommandType.StoredProcedure);
        }
    }
}
