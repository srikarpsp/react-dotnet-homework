using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5000");

app.MapGet("/", () => "OK");

// Contacts API
var contacts = new List<string> { "Bob", "Jane", "Mike" }.Select(name => new Contact(name)).ToList();

app.MapGet("/contacts/", () => contacts);
app.MapPost("/contacts/", async (HttpContext context) =>
{
    var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var Contact = JsonSerializer.Deserialize<Contact>(requestBody, options);
    contacts.Add(new Contact(Contact.Name, Contact.Email, Contact.Phone));
    return Results.Ok("Contact added successfully.");
});

app.Run();

public record Contact
{
    public Contact(string name)
    {
        Name = name;
        Email = $"{name.ToLower()}@test.com";
        Phone = "1234567890";
    }

    public Contact(string name, string email, string phone)
    {
        Name = name;
        Email = email;
        Phone = phone;
    }

    public string Name { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }
    public string Guid { get; set; } = System.Guid.NewGuid().ToString();
}
