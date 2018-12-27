namespace BuilderWithMandatoryCalls
{
  public class BuilderConsumerClass
  {
    public BuilderConsumerClass(IContactWithMandatoryNameBuilder builder )
    {
      var contact = builder
            .WithName("John")
            .WithSurname("Doe")
            .WithPhone("+1234567890")
            .Build();
    }
  }
}
