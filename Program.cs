using creating_a_form_backend.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<Form_FormService>();
builder.Services.AddScoped<Form_UserService>();

var connectionString=builder.Configuration.GetConnectionString("FormDbString");

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

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("FormPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
