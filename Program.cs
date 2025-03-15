using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Middleware.Example;
using Scalar.AspNetCore;
using socialfeed.Data;
using socialfeed.Models;
using socialfeed.Services.UserService;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SocialFeedContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllers();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseRouting();
// app.UseHttpsRedirection();

// error handling middleware
app.UseMiddleware<ErrorMiddleware>();
app.MapControllers();

app.MapOpenApi();
app.MapScalarApiReference(options =>
options
.WithTitle("ScoialFeed API")
.WithDefaultHttpClient(ScalarTarget.CSharp, ScalarClient.HttpClient)
);

// app.UseAuthentication();
// app.UseAuthorization();


app.Run();

