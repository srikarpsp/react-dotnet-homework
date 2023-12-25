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

// Update a contact
app.MapPost("/contacts/{id}", async (ContactContext context, HttpContext httpContext, int id) =>
{
    var requestBody = await new StreamReader(httpContext.Request.Body).ReadToEndAsync();
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var contact = JsonSerializer.Deserialize<Contact>(requestBody, options);
    var contactToUpdate = context.Contacts.FirstOrDefault(c => c.Id == id);
    if (contactToUpdate != null)
    {
        contactToUpdate.Name = contact.Name;
        contactToUpdate.Email = contact.Email;
        contactToUpdate.Phone = contact.Phone;
        contactToUpdate.Avatar = contact.Avatar;
        contactToUpdate.Twitter = contact.Twitter;
        contactToUpdate.Notes = contact.Notes;
        contactToUpdate.Address = contact.Address;

        await context.SaveChangesAsync();
        return Results.Ok("Contact updated successfully.");
    }
    return Results.NotFound("Contact not found.");
});

app.MapDelete("/contacts/{id}", async (ContactContext context, int id) =>
{
    var contactToDelete = context.Contacts.FirstOrDefault(c => c.Id == id);
    context.Contacts.Remove(contactToDelete);
    await context.SaveChangesAsync();
    return Results.Ok("Contact Deleted successfully.");
});

app.Run();
