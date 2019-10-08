using System;
using System.Threading.Tasks;
using Shared.BuilderPatternPosts.Models;
using Shared.BuilderPatternPosts.Repositories;

namespace AsyncBuilderWithOrderedFuncOfTasks
{
  public class OrderedTasksConsumer
  {
    public static void Consume()
    {
      Console.WriteLine($"======= STARTING ORDERED TASKS CONSUMER =======");
      var getContactTask = GetContact();
      getContactTask.Wait();
      var contact = getContactTask.Result;
      Console.WriteLine($"I have a new contact with name: {contact.Name}");
    }

    public async static Task<Contact> GetContact()
    {
      var builder = new ContactBuilder(new LinkedinRepository(), new GoogleContactsRepository(), "selcuk");
      return await builder
        .WithName()
        .WithSurname()
        .WithAddress()
        .Build();
    }
  }
}
