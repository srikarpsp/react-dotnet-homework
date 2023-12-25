namespace Contacts.Tests;

public class ContactTests
{
    [Fact]
    public void Constructor_Sets_Name_And_Id()
    {
        var contact = new Contact("Test Name", 1);
        Assert.Equal("Test Name", contact.Name);
        Assert.Equal(1, contact.Id);
        Assert.Equal("test_name@test.com", contact.Email);
    }

    [Fact]
    public void Constructor_Sets_All_Properties()
    {
        var contact = new Contact("Test Name", "test@test.com", "1234567890", "avatar.png", "@test", "Test notes","Test Address");
        Assert.Equal("Test Name", contact.Name);
        Assert.Equal("test@test.com", contact.Email);
        Assert.Equal("1234567890", contact.Phone);
        Assert.Equal("avatar.png", contact.Avatar);
        Assert.Equal("@test", contact.Twitter);
        Assert.Equal("Test notes", contact.Notes);
        Assert.Equal("Test Address", contact.Address)
    }
    
    [Fact]
    public void Constructor_Sets_All_Properties_Null()
    {
        var contact = new Contact(null, null, null, null, null, null,null);
        Assert.Null(contact.Name);
        Assert.Null(contact.Email);
        Assert.Null(contact.Phone);
        Assert.Null(contact.Avatar);
        Assert.Null(contact.Twitter);
        Assert.Null(contact.Notes);
        Assert.Null( contact.Address);
    }

    [Fact]
    public void Constructor_Checks_Default_Values()
    {
        var contact = new Contact();
        Assert.Equal("email@demo.com", contact.Email);
        Assert.Equal("1234567890", contact.Phone);
        Assert.Equal("/avatars/headshot_1.png", contact.Avatar);
        Assert.Equal("TwitterHandle", contact.Twitter);
    }
}
