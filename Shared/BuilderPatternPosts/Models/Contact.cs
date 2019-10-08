namespace Shared.BuilderPatternPosts.Models
{
  public class Contact
  {
    // Mandatory properties
    public string Name { get; set; }
    public string Surname { get; set; }
    public string PhoneNumber { get; set; }

    // Optional properties
    public string Email { get; set; }
    public string Address { get; set; }
    public string Notes { get; set; }
  }
}
