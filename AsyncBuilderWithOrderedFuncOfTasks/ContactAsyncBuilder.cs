using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Shared.BuilderPatternPosts.Models;
using Shared.BuilderPatternPosts.Repositories;

public interface IContactBuilder
{
  IContactBuilder WithName();
  IContactBuilder WithSurname();
  IContactBuilder WithPhone();
  IContactBuilder WithEmail();
  IContactBuilder WithAddress();
  IContactBuilder WithNotes();
  Task<Contact> Build();
}

public class ContactBuilder : IContactBuilder
{
  private readonly ILinkedinRepository linkedinRepository;
  private readonly IGoogleContactsRepository googleContactsRepository;
  private readonly Contact contact;
  private readonly string username;
  private Queue<Func<Task>> builderQueue;

  public ContactBuilder(
    ILinkedinRepository linkedinRepository,
    IGoogleContactsRepository googleContactsRepository,
    string username)
  {
    this.linkedinRepository = linkedinRepository;
    this.googleContactsRepository = googleContactsRepository;
    this.contact = new Contact();
    this.username = username;
    this.builderQueue = new Queue<Func<Task>>();
  }

  public IContactBuilder WithName()
  {
    builderQueue.Enqueue(() => Task.Run(() => 
    {
      var name = this.linkedinRepository.GetName(this.username);
      contact.Name = name;
    }));

    return this;
  }
  public IContactBuilder WithSurname()
  {
    builderQueue.Enqueue(() => Task.Run(() => 
    {
      var surname = this.linkedinRepository.GetSurname(this.username);
      contact.Surname = surname;
    }));
    
    return this;
  }

  public IContactBuilder WithPhone()
  {
    builderQueue.Enqueue(() => Task.Run(() => 
    {
      var phoneNumber = this.googleContactsRepository.GetPhone(this.username);
      contact.PhoneNumber = phoneNumber;
    }));
    
    return this;
  }
  public IContactBuilder WithEmail()
  {
    builderQueue.Enqueue(() => Task.Run(() => 
    {
      var email = this.googleContactsRepository.GetEmail(this.username);
      contact.Email = email;
    }));
    
    return this;
  }
  public IContactBuilder WithAddress()
  {
    builderQueue.Enqueue(() => Task.Run(() => 
    {
      var address = this.googleContactsRepository.GetAddress(this.username);
      contact.Address = address;
    }));
    
    return this;
  }
  public IContactBuilder WithNotes()
  {
    builderQueue.Enqueue(() => Task.Run(() => 
    {
      var notes = this.googleContactsRepository.GetNotes(this.username);
      contact.Notes = notes;
    }));
    
    return this;
  }
  public async Task<Contact> Build()
  {
    Func<Task> startTaskExecution = null;
    Console.WriteLine(">>> Building contact...");
    while (builderQueue.TryDequeue(out startTaskExecution))
    {
      var currentTask = startTaskExecution.Invoke();
      await currentTask.ConfigureAwait(false);
    }
    Console.WriteLine(">>> Done...");
    return this.contact;
  }
}