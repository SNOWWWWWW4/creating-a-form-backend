using creating_a_form_backend.Models;
using creating_a_form_backend.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
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

app.MapGet("/GetFormData", () => _formService.GetFormData());

app.MapPost("/AddFormData", (FormModel newUser) => {
    _formService.AddFormData(newUser);
});

// app.UseAuthorization();

// app.MapControllers();

app.Run();
