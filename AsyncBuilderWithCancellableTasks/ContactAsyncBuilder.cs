using System;
using System.Collections.Generic;
using System.Threading;
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
  private CancellationToken cancellationToken;
  private CancellationTokenSource cancellationTokenSource;
  private Queue<Task> builderQueue;

  public ContactBuilder(
    ILinkedinRepository linkedinRepository,
    IGoogleContactsRepository googleContactsRepository,
    string username)
  {
    this.linkedinRepository = linkedinRepository;
    this.googleContactsRepository = googleContactsRepository;
    this.contact = new Contact();
    this.username = username;
    this.cancellationTokenSource = new CancellationTokenSource();
    this.cancellationToken = cancellationTokenSource.Token;
    this.builderQueue = new Queue<Task>();
  }

  public IContactBuilder WithName()
  {
    builderQueue.Enqueue(Task.Run(() => 
    {
      var name = this.linkedinRepository.GetName(this.username);

      if (cancellationToken.IsCancellationRequested)
      {
        cancellationToken.ThrowIfCancellationRequested();
      }

      contact.Name = name;
    }));

    return this;
  }
  public IContactBuilder WithSurname()
  {
    builderQueue.Enqueue(Task.Run(() => 
    {
      var surname = this.linkedinRepository.GetSurname(this.username);
      
      if (cancellationToken.IsCancellationRequested)
      {
        cancellationToken.ThrowIfCancellationRequested();
      }

      contact.Surname = surname;
    }));
    
    return this;
  }

  public IContactBuilder WithPhone()
  {
    builderQueue.Enqueue(Task.Run(() => 
    {
      var phoneNumber = this.googleContactsRepository.GetPhone(this.username);

      if (cancellationToken.IsCancellationRequested)
      {
        cancellationToken.ThrowIfCancellationRequested();
      }

      contact.PhoneNumber = phoneNumber;
    }));
    
    return this;
  }
  public IContactBuilder WithEmail()
  {
    builderQueue.Enqueue(Task.Run(() => 
    {
      var email = this.googleContactsRepository.GetEmail(this.username);

      if (cancellationToken.IsCancellationRequested)
      {
        cancellationToken.ThrowIfCancellationRequested();
      }

      contact.Email = email;
    }));
    
    return this;
  }
  public IContactBuilder WithAddress()
  {
    builderQueue.Enqueue(Task.Run(() => 
    {
      var address = this.googleContactsRepository.GetAddress(this.username);
      
      // Let's simulate adding an address did not go so well:
      // Comment out the following line to see success
      // cancellationTokenSource.Cancel();

      if (cancellationToken.IsCancellationRequested)
      {
        cancellationToken.ThrowIfCancellationRequested();
      }

      contact.Address = address;
    }));
    
    return this;
  }
  public IContactBuilder WithNotes()
  {
    builderQueue.Enqueue(Task.Run(() => 
    {
      var notes = this.googleContactsRepository.GetNotes(this.username);

      if (cancellationToken.IsCancellationRequested)
      {
        cancellationToken.ThrowIfCancellationRequested();
      }
      
      contact.Notes = notes;
    }));
    
    return this;
  }
  public async Task<Contact> Build()
  {
    Task currentTask = null;
    Console.WriteLine(">>> Building contact...");
    
    while (builderQueue.TryDequeue(out currentTask))
		{
			await currentTask.ConfigureAwait(false);
		}
    
    Console.WriteLine(">>> Done...");
    return this.contact;
  }
}