using AutoMapper;
using domain.shared.AppSettings;
using Microsoft.Extensions.Options;
using repository;
using repository.AppRepositories;
using repository.AppRepositories.Base;
using repository.contract;
using repository.contract.IAppRepositories;
using repository.contract.IAppRepositories.Base;
using service;
using service.AppServices;
using service.AppServices.Base;
using service.contract;
using service.contract.DTOs.Email;
using service.contract.IAppServices;
using service.contract.IAppServices.Base;

namespace api.Extensions
{
    public static class DependencyInjectionExtensions
    {
        public static IServiceCollection RegisterAppServices(this IServiceCollection services)
        {

            return services
                .AddScoped<IAccountService, AccountService>()
                .AddScoped<IMajorService, MajorService>()
                .AddScoped<IClassService, ClassService>()
                .AddScoped<ISubjectService, SubjectService>()
                .AddScoped<ITeacherService, TeacherService>()
                .AddScoped<IStudentService, StudentService>()
                .AddScoped<IScoreService, ScoreService>()
                .AddScoped<ISemesterService, SemesterService>()

                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IMajorRepository, MajorRepository>()
                .AddScoped<IClassRepository, ClassRepository>()
                .AddScoped<ISubjectRepository, SubjectRepository>()
                .AddScoped<ITeacherRepository, TeacherRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IScoreRepository, ScoreRepository>()
                .AddScoped<ISemesterRepository, SemesterRepository>()
                .AddScoped<IEmailService>(impl =>
                {
                    var mapper = impl.GetService<IMapper>();
                    var mailCOnfig = impl.GetService<IOptions<MailConfiguration>>();
                    var smtpConfig = mapper.Map<SmtpConfigModel>(mailCOnfig.Value);
                    return new EmailService(smtpConfig);
                })

               ;
        }

    }
}
