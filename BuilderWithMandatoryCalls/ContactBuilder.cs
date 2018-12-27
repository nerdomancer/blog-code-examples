namespace BuilderWithMandatoryCalls
{
  public class ContactBuilder : IContactBuilder, IContactWithMandatoryNameBuilder, IContactWithMandatorySurnameBuilder, IContactWithMandatoryPhoneBuilder
  {
    private readonly Contact contact;

    public ContactBuilder()
    {
      contact = new Contact();
    }

    public IContactWithMandatorySurnameBuilder WithName(string name)
    {
      contact.Name = name;
      return this;
    }

    public IContactWithMandatoryPhoneBuilder WithSurname(string surname)
    {
      contact.Surname = surname;
      return this;
    }

    public IContactBuilder WithPhone(string phoneNumber)
    {
      contact.PhoneNumber = phoneNumber;
      return this;
    }

    public IContactBuilder WithEmail(string email)
    {
      contact.Email = email;
      return this;
    }

    public IContactBuilder WithAddress(string address)
    {
      contact.Address = address;
      return this;
    }

    public IContactBuilder WithNotes(string notes)
    {
      contact.Notes = notes;
      return this;
    }

    public Contact Build()
    {
      return this.contact;
    }
  }
}
