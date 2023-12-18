using System.Text.Json;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.Urls.Add("http://localhost:5000");

app.MapGet("/", () => "OK");

// Contacts API
var contacts = new List<string> { "Bob", "Jane", "Mike" }
    .Select((name, index) => new Contact(name, index + 1))
    .ToList();

app.MapGet("/contacts/", () => contacts);
app.MapGet("/contacts/{id}", GetContactById);
app.MapPost("/contacts/", async (HttpContext context) =>
{
    var requestBody = await new StreamReader(context.Request.Body).ReadToEndAsync();
    var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
    var Contact = JsonSerializer.Deserialize<Contact>(requestBody, options);
    contacts.Add(new Contact(Contact.Name, Contact.Email, Contact.Phone, Contact.Avatar, Contact.Twitter, Contact.Notes));
    return Results.Ok("Contact added successfully.");
});

app.Run();

Contact GetContactById(int id)
{
    return contacts.FirstOrDefault(c => c.Id == id);
}

public record Contact
{
    public Contact(string name, int id)
    {
        Name = name;
        Id = id;
        Email = $"{name.ToLower()}@test.com";
    }

    public Contact(string name, string email, string phone, string avatar, string twitter, string notes)
    {
        Name = name;
        Email = email;
        Phone = phone;
        Avatar = avatar;
        Twitter = twitter;
        Notes = notes;
    }


    public int Id { get; set; } // Primary key
    public string Name { get; set; }
    public string? Email { get; set; } = "email@demo.com";
    public string? Phone { get; set; } = "1234567890";
    public string? Avatar { get; set; } = "/avatars/headshot_1.png";
    public string? Twitter { get; set; } = "TwitterHandle";
    public string? Notes { get; set; }
}
