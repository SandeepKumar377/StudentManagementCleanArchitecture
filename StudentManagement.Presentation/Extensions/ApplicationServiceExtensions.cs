using StudentManagement.Business.Implementations;
using StudentManagement.Business.Interfaces;
using StudentManagement.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagement.Presentation.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationService(this IServiceCollection services)
        {
            services.AddScoped<IAccountBL, AccountBL>();
            services.AddScoped<IExamBL, ExamBL>();
            services.AddScoped<IGroupBL, GroupBL>();
            services.AddScoped<IQnAsBL, QnAsBL>();
            services.AddScoped<IStudentBL, StudentBL>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUtilityBL, UtilityBL>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            return services;
        }
    }
}
