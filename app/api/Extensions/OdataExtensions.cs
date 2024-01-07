using domain;
using Microsoft.AspNetCore.OData;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;

namespace api.Extensions
{
    public static class OdataExtensions
    {
        public static IMvcBuilder RegisterOdata(this IMvcBuilder mvcBuilder)
        {
            return mvcBuilder.AddOData(option =>
            {
                option.Select().Filter().Count().OrderBy().Expand().SetMaxTop(50)
                .AddRouteComponents("odata", GetEdmModel());
            });
        }
        public static IEdmModel GetEdmModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();

            builder.EntitySet<Account>(nameof(Account));
            builder.EntitySet<Student>(nameof(Student));
            builder.EntitySet<Subject>(nameof(Subject));
            builder.EntitySet<Score>(nameof(Score));
            builder.EntitySet<Slot>(nameof(Slot));
            builder.EntitySet<Semester>(nameof(Semester));
            builder.EntitySet<Teacher>(nameof(Teacher));
            builder.EntitySet<Class>(nameof(Class));
            builder.EntitySet<Major>(nameof(Major));
            builder.EntitySet<Timetable>(nameof(Timetable));
            builder.EnableLowerCamelCase();
            return builder.GetEdmModel();
        }
    }
}
