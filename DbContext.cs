using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using System.Net;

public class ContactContext : DbContext
{
    public DbSet<Contact> Contacts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var connection = new SqlConnection(connectionString);

        connection.ConnectionString = connectionString;

        // Bypass SSL certificate validation
        ServicePointManager.ServerCertificateValidationCallback =
            (sender, certificate, chain, sslPolicyErrors) => true;

        optionsBuilder.UseSqlServer(connection);
    }
}
