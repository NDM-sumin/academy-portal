using AutoMapper;
using domain.shared.AppSettings;
using Microsoft.Extensions.Options;
using repository.AppRepositories;
using repository.contract.IAppRepositories;
using service.AppServices;
using service.contract.DTOs.Email;
using service.contract.IAppServices;

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
                .AddScoped<IRoomRepository, RoomRepository>()
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
