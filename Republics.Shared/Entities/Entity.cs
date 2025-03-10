using System.Data.Common;
using Flunt.Notifications;


namespace Republics.Shared.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public Entity()
    {
        Id = Guid.NewGuid();
    }
    public Guid Id { get; private set; }
}