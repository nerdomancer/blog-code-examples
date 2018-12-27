namespace BuilderWithMandatoryCalls
{
  public interface IContactWithMandatoryNameBuilder
  {
    IContactWithMandatorySurnameBuilder WithName(string name);
  }

  public interface IContactWithMandatorySurnameBuilder
  {
    IContactWithMandatoryPhoneBuilder WithSurname(string surname);
  }

  public interface IContactWithMandatoryPhoneBuilder
  {
    IContactBuilder WithPhone(string phoneNumber);
  }

  public interface IContactBuilder
  {
    IContactBuilder WithEmail(string email);
    IContactBuilder WithAddress(string address);
    IContactBuilder WithNotes(string notes);
    Contact Build();
  }
}