using System;
using System.Threading.Tasks;
using Shared.BuilderPatternPosts.Models;
using Shared.BuilderPatternPosts.Repositories;

namespace AsyncBuilderWithParallelTasks
{
  public class ParallelTasksConsumer
  {
    public static void Consume()
    {
      Console.WriteLine($"======= STARTING PARALLEL TASKS CONSUMER =======");
      var getContactTask = GetContact();
      getContactTask.Wait();
      var contact = getContactTask.Result;
      Console.WriteLine($"I have a new contact with name: {contact.Name}");
    }

    public async static Task<Contact> GetContact()
    {
      var builder = new ContactBuilder(new LinkedinRepository(), new GoogleContactsRepository(), "selcuks");
      return await builder
        .WithName()
        .WithSurname()
        .WithAddress()
        .Build();
    }
  }
}
