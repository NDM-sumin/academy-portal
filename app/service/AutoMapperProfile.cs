﻿using AutoMapper;
using domain;
using domain.shared.AppSettings;
using service.contract.DTOs.Account;
using service.contract.DTOs.Class;
using service.contract.DTOs.Email;
using service.contract.DTOs.FeeDetail;
using service.contract.DTOs.Major;
using service.contract.DTOs.Score;
using service.contract.DTOs.Semester;
using service.contract.DTOs.Student;
using service.contract.DTOs.Subject;
using service.contract.DTOs.Teacher;

namespace service
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            this.CreateMap<Account, AccountDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Account, CreateAccountDTO>().ReverseMap();
            this.CreateMap<Account, UpdateAccountDTO>().ReverseMap();
            this.CreateMap<Account, AccountNoPasswordDTO>().ReverseMap();

            this.CreateMap<Class, ClassDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Class, CreateClassDTO>().ReverseMap();
            this.CreateMap<Class, UpdateClassDTO>().ReverseMap();

            this.CreateMap<Major, MajorDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Major, CreateMajorDTO>().ReverseMap();
            this.CreateMap<Major, UpdateMajorDTO>().ReverseMap();

            this.CreateMap<Semester, SemesterDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Semester, CreateSemesterDTO>().ReverseMap();
            this.CreateMap<Semester, UpdateSemesterDTO>().ReverseMap();

            this.CreateMap<Subject, SubjectDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Subject, CreateSubjectDTO>().ReverseMap();
            this.CreateMap<Subject, UpdateSubjectDTO>().ReverseMap();

            this.CreateMap<Score, ScoreDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Score, CreateScoreDTO>().ReverseMap();
            this.CreateMap<Score, UpdateScoreDTO>().ReverseMap();

            this.CreateMap<Student, StudentDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Student, CreateStudentDTO>().ReverseMap();
            this.CreateMap<Student, UpdateStudentDTO>().ReverseMap();

            this.CreateMap<Teacher, TeacherDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion()); ;
            this.CreateMap<Teacher, CreateTeacherDTO>().ReverseMap();
            this.CreateMap<Teacher, UpdateTeacherDTO>().ReverseMap();

            this.CreateMap<FeeDetail, FeeDetailDTO>().ReverseMap().ForAllMembers(o => o.ExplicitExpansion());
            this.CreateMap<FeeDetail, CreateFeeDetailDTO>().ReverseMap();

            this.CreateMap<MailConfiguration, SmtpConfigModel>().ReverseMap();

        }
    }
}
