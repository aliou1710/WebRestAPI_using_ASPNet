using Microsoft.EntityFrameworkCore;
using WebApp_API.Repositories;
using WebAppAPI.DataModels;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors((options) =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder.WithOrigins("http://localhost:4200")
        .AllowAnyHeader()
        .WithMethods("GET", "POST", "PUT", "DELETE")
        .WithExposedHeaders("*");
    });
});
builder.Services.AddControllers();
builder.Services.AddDbContext<StudentAdminContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdminPortalDb")));
//les controller que j'ai ajouté
builder.Services.AddScoped<IStudentRepository,SQLStudentRepository>();
builder.Services.AddScoped<IImageRepository, LocalStorageImageRepository>();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//action automapper
//lorsque l'application sera lancer, il partira dans le program class , ensuite recuperer l'assembly  ensuite il va rechercher tous les classes qui heritent de "Profile"
builder.Services.AddAutoMapper(typeof(Program).Assembly);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

//ajouter
app.UseCors("angularApplication");


app.UseAuthorization();

app.MapControllers();

app.Run();
