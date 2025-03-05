using Microsoft.EntityFrameworkCore;
using socialfeed.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SocialFeedContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.Run();

