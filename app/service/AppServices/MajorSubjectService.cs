﻿using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.MajorSubject;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class MajorSubjectService : AppCRUDDefaultKeyService<MajorSubjectDto, MajorSubjectDto, MajorSubjectDto, MajorSubject>, IMajorSubjectService
    {
        public MajorSubjectService(IMajorSubjectRepository genericRepository, IMapper mapper) : base(genericRepository, mapper)
        {
        }
        public List<MajorSubjectDto> GetSubjectsOfMajorInSemester(Guid majorId, Guid semesterId)
        {
            var data = Repository.Entities.Include(ms => ms.Subject).Where(ms => ms.MajorId == majorId && ms.SemesterId == semesterId).ToList();
            return Mapper.Map<List<MajorSubjectDto>>(data);
        }
    }
}
