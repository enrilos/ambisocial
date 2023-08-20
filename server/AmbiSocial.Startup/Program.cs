using AmbiSocial.Web;
using AmbiSocial.Web.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddWebComponents();

var app = builder.Build();

app.UseSwagger(app.Environment);
app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(opts => opts
    .AllowAnyOrigin()
    .AllowAnyHeader()
    .AllowAnyMethod());
app.UseAuthorization();

app.MapControllers();

app.Run();
