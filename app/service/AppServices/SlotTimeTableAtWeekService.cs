using AutoMapper;
using domain;
using Microsoft.EntityFrameworkCore;
using repository.contract.IAppRepositories;
using service.AppServices.Base;
using service.contract.DTOs.Semester;
using service.contract.DTOs.SlotTimeTableAtWeek;
using service.contract.IAppServices;

namespace service.AppServices
{
    public class SlotTimeTableAtWeekService : AppCRUDDefaultKeyService<SlotTimeTableAtWeekDTO, SlotTimeTableAtWeekDTO, SlotTimeTableAtWeekDTO, SlotTimeTableAtWeek>, ISlotTimeTableAtWeekService
    {
        public SlotTimeTableAtWeekService(
            ISlotTimeTableAtWeekRepository genericRepository,
             IMapper mapper) : base(genericRepository, mapper)
        {
        }
        public async Task<List<SlotTimeTableAtWeekDTO>> GetSlotTimeTableAtWeeks(SemesterDTO currentSemester)
        {
            var year = currentSemester.CreatedAt.Year;
            DateTime startOfTerm = new DateTime(year, currentSemester.StartMonth, currentSemester.StartDay);
            if (currentSemester.StartMonth > currentSemester.EndMonth) { year++; }
            DateTime endOfTerm = new DateTime(year, currentSemester.EndMonth, currentSemester.EndDay);

            DateTime currentDate = DateTime.Now;
            if (currentDate >= startOfTerm && currentDate <= endOfTerm)
            {
                int totalDays = (int)(currentDate - startOfTerm).TotalDays;
                int currentWeek = totalDays / 7 + 1;

                var result = await Repository.Entities
                    .Where(staw => staw.Week.WeekName.Equals(currentWeek)).ToListAsync();
                return Mapper.Map<List<SlotTimeTableAtWeekDTO>>(result);
            }
            return Enumerable.Empty<SlotTimeTableAtWeekDTO>().ToList();
        }

    }
}