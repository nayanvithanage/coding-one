var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi(); //?
builder.Services.AddControllers(); // Register controller

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    var xmlFileName = $"{System.Reflection.Assembly.GetExecutingAssembly().GetName().Name}.xml";
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFileName));
});



var app = builder.Build(); //? 

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment()) //?
{
    app.MapOpenApi();
}

app.MapControllers(); //?
app.UseHttpsRedirection(); //?

app.UseSwagger();
app.UseSwaggerUI();

app.Run();

