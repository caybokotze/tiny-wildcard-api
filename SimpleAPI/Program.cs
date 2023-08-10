using System.Text;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Map("/{**any}", async context =>
{
    Console.WriteLine(context.Request.Path);

    var memoryStream = new MemoryStream();
    await context.Request.Body.CopyToAsync(memoryStream);
    var bytes = memoryStream.ToArray();
    
    Console.WriteLine(Encoding.UTF8.GetString(bytes));
    
    // Console.WriteLine(JsonSerializer.Serialize(context.Request.Form, new JsonSerializerOptions{WriteIndented = true}));
});

app.Run();