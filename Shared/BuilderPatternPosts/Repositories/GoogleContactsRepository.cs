using System;
using System.Threading;

namespace Shared.BuilderPatternPosts.Repositories
{
  // In a real world example this repository would also be async
  // Skipped for now for simplicity
  public interface IGoogleContactsRepository
  {
    string GetPhone(string username);
    string GetAddress(string username);
    string GetEmail(string username);
    string GetNotes(string username);
  }

  public class GoogleContactsRepository : IGoogleContactsRepository
  {
    public string GetPhone(string username)
    {
      // Simulating network delay:
      Thread.Sleep(800);
      Console.WriteLine("Received phone number from Google...");
      return "+1234567890";
    }

    public string GetAddress(string username)
    {
      // Simulating network delay:
      Thread.Sleep(1600);
      Console.WriteLine("Received address number from Google...");
      return "Awesome Street 1";
    }

    public string GetEmail(string username)
    {
      // Simulating network delay:
      Thread.Sleep(2400);
      Console.WriteLine("Received e-mail from Google...");
      return "awesome-nonexisting-address@gmail.com";
    }

    public string GetNotes(string username)
    {
      // Simulating network delay:
      Thread.Sleep(2400);
      Console.WriteLine("Received notes from Google...");
      return "My notes";
    }
  }
}