public record Contact
{
    public Contact()
    {
    }

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
