using API.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
// Replaced Swagger
//builder.Services.AddOpenApi();
builder.Services.AddDbContext<StoreContext>(opt =>
{
    opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});



var app = builder.Build();

/////////////////////////////////////////////////////////////
// Configure the HTTP request pipeline.
// middleware container start

//app.UseAuthorization();

app.MapControllers();
// middleware container end

DbInitializer.InitDb(app);

app.Run();
