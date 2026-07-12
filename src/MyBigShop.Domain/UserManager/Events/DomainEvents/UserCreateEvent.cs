using MyBigShop.Domain.UserManager.Events.IEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Events.Events
{
    public class UserCreateEvent:IDomainEvents
    {
        public Guid UserId { get; }
        public DateTime OccurredOn { get; }

        public UserCreateEvent (Guid userId)
        {
            UserId = userId;
            OccurredOn = DateTime.UtcNow;

        }
    }
}
