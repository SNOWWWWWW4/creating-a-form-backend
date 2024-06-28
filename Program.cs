using creating_a_form_backend.Models;
using creating_a_form_backend.Models.DTO;
using creating_a_form_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options => options.AddPolicy("FormPolicy",
builder =>
{
    builder.WithOrigins("http://localhost:3000", "https://phamh-formvalidation.vercel.app")
    .AllowAnyHeader()
    .AllowAnyMethod();
}));

// Add services to the container.

// builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<FormService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

FormService _formService = new FormService();
// Form_UserService _formUserService = new Form_UserService();

app.MapGet("/GetFormData", () => _formService.GetFormData());

app.MapPost("/AddFormData", (FormModel newUser) =>
{
    _formService.AddFormData(newUser);
});

// app.MapPost("/AddUser", (Form_CreateAccountDTO UserToAdd) =>
// {
//     _formUserService.AddUser(UserToAdd);
// });
// app.MapPost("/Login", (Form_LoginDTO newUser) =>
// {
//     _formUserService.Login(newUser);
// });
// app.MapPut("/UpdateUserPassword", (string username, string password) =>
// {
//     _formUserService.UpdateUserPassword(username, password);
// });
// app.MapGet("/GetUserByUsername", (string username) =>
// {
//     _formUserService.GetUserByUsername(username);
// });

// app.UseAuthorization();

// app.MapControllers();

app.UseCors("FormPolicy");

app.Run();
