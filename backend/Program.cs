using Microsoft.EntityFrameworkCore;
using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ContactContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.Urls.Add("http://localhost:5000");

app.MapGet("/", () => "OK");

app.MapGet("/contacts/", (ContactContext context) =>
{
    return context.Contacts.ToList();
});
app.MapGet("/contacts/{id}", (ContactContext context, int id) =>
{
    return context.Contacts.FirstOrDefault(c => c.Id == id);
});
app.MapPost("/contacts/", async (ContactContext context, HttpContext httpContext) =>
{
    var requestBody = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var contact = JsonSerializer.Deserialize<Contact>(requestBody, options);
    context.Contacts.Add(contact);
    await context.SaveChangesAsync();
    return Results.Ok("Contact added successfully.");
});

app.Run();
