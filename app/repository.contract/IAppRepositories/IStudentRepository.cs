﻿using domain;
using repository.contract.IAppRepositories.Base;

namespace repository.contract.IAppRepositories
{
    public interface IStudentRepository : IAppGenericDefaultKeyRepository<Student>
    {
        Task AddRange(List<Student> students);
        Task<List<FeeDetail>> GetFeeDetails(Guid semesterId, Guid studentId);
        Task<FeeDetail> GetFeeDetailBySubject(Guid studentSemesterId, Guid subjectId);
        Task<List<Slot>> GetSlots();
        Task<List<SlotTimeTableAtWeek>?> GetSlotTimeTableAtWeeks(Guid feeDetailId, Guid studentId);
        Task<List<Timetable>> GetTimetables();
    }
}
