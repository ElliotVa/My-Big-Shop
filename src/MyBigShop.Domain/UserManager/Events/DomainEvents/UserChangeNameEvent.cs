using MyBigShop.Domain.UserManager.Events.IEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Events.DomainEvents
{
    public class UserChangeNameEvent : IDomainEvents
    {
        public Guid UserId { get; }
        public DateTime OccurredOn { get; }

        public UserChangeNameEvent(Guid userId)
        {
            UserId = userId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
