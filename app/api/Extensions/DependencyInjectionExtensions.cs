﻿using AutoMapper;
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
        public static IServiceCollection RegisterAppRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IMajorRepository, MajorRepository>()
                .AddScoped<IClassRepository, ClassRepository>()
                .AddScoped<ISubjectRepository, SubjectRepository>()
                .AddScoped<ITeacherRepository, TeacherRepository>()
                .AddScoped<IStudentRepository, StudentRepository>()
                .AddScoped<IScoreRepository, ScoreRepository>()
                 .AddScoped<ISemesterRepository, SemesterRepository>()
                .AddScoped<IRoomRepository, RoomRepository>()
                .AddScoped<IStudentSemesterRepository, StudentSemesterRepository>()
                .AddScoped<IMajorSubjectRepository, MajorSubjectRepository>()
                .AddScoped<IFeeDetailRepository, FeeDetailRepository>()
                .AddScoped<ISlotRepository, SlotRepository>()
                .AddScoped<ISubjectComponentRepository, SubjectComponentRepository>()
                .AddScoped<ITimeTableRepository, TimeTableRepository>()
                .AddScoped<ISlotTimeTableAtWeekRepository, SlotTimeTableAtWeekRepository>()
                .AddScoped<IAttedanceRepository, AttendanceRepository>()
                .AddScoped<IPaymentTransactionRepository, PaymentTransactionRepository>()
                .AddScoped<IWeekRepository, WeekRepository>()


                ;

        }

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
                .AddScoped<ISubjectComponentService, SubjectComponentService>()
                .AddScoped<ISemesterService, SemesterService>()
                .AddScoped<IFeeDetailService, FeeDetailService>()
                .AddScoped<IMajorSubjectService, MajorSubjectService>()
                .AddScoped<IStudentSemesterService, StudentSemesterService>()
                .AddScoped<ISlotService, SlotService>()
                .AddScoped<ITimeTableService, TimeTableService>()
                .AddScoped<ISlotTimeTableAtWeekService, SlotTimeTableAtWeekService>()
                .AddScoped<IAttendanceService, AttendanceService>()
                .AddScoped<IRoomService, RoomService>()
                .AddScoped<IPaymentTransactionService, PaymentTransactionService>()

                .AddScoped<IEmailService>(impl =>
                {
                    var mapper = impl.GetService<IMapper>()!;
                    var mailCOnfig = impl.GetService<IOptions<MailConfiguration>>()!;
                    var smtpConfig = mapper.Map<SmtpConfigModel>(mailCOnfig.Value);
                    return new EmailService(smtpConfig);
                }).AddScoped<IVnPayService>(c =>
                {
                    var vnpayConfig = c.GetService<IOptions<VNPayConfiguration>>();

                    return new VNPayService(vnpayConfig.Value);
                })




               ;
        }

    }
}
