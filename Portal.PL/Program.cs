using Portal.BL.Interface;
using Portal.BL.Repository;
using Portal.DAL.Entity;
using Portal.BL.Mapper;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//Add scoped
builder.Services.AddScoped<IDepartment,DepartmentRep>();
builder.Services.AddScoped<IEmployee, EmployeeRep>();


//Auto mapper
builder.Services.AddAutoMapper(x=>x.AddProfile(new DomainProfile()));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Department}/{action=Department}/{id?}");

app.Run();
