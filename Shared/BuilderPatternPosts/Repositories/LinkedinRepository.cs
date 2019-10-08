using System;
using System.Threading;

namespace Shared.BuilderPatternPosts.Repositories
{

  // In a real world example this repository would also be async
  // Skipped for now for simplicity
  public interface ILinkedinRepository
  {
    string GetName(string username);
    string GetSurname(string username);
  }

  public class LinkedinRepository : ILinkedinRepository
  {
    public string GetName(string username)
    {
      // Simulating network delay:
      Thread.Sleep(2400);
      Console.WriteLine("Received name from Linkedin...");
      return "Selcuk";
    }

    public string GetSurname(string username)
    {
      // Simulating network delay:
      Thread.Sleep(1800);
      Console.WriteLine("Received surname from Linkedin...");
      return "Sasoglu";
    }
  }
}