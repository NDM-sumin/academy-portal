using api.Extensions;
using api.Hubs;
using domain.shared.AppSettings;
using domain.shared.Constants;
using Microsoft.AspNetCore.Builder;
using service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services
    .AddControllers()
    .AddJsonOptions(config =>
{
    config.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
}).RegisterOdata();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.Configure<JwtConfiguration>(builder.Configuration.GetSection("Jwt"));
builder.Services.Configure<MailConfiguration>(builder.Configuration.GetSection("Mail"));
builder.Services.Configure<VNPayConfiguration>(builder.Configuration.GetSection("VNPay"));
builder.Services.AddCors(options =>
{
    options.AddPolicy(CorsConstants.PolicyName,
        build => build
        .AllowAnyMethod()
        .AllowAnyHeader()
        .AllowCredentials().SetIsOriginAllowed(hostName => true).Build());
});
builder.Services.AddAppDefaultDbContext(builder.Configuration);
builder.Services.RegisterAppServices();
builder.Services.AddJwtAuthentication();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseExceptionHandler("/error");
app.UseAuthorization();
app.UseStaticFiles();
app.MapControllers();
app.UseCors(CorsConstants.PolicyName);
app.MapHub<PaymentHub>("/payment");

app.Run();
