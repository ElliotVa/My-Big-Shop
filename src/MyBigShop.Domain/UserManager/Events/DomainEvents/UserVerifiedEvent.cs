using MyBigShop.Domain.UserManager.Events.IEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Events.DomainEvents
{
    public class UserVerifiedEvent : IDomainEvents
    {
        public Guid UserId { get; }
        public DateTime OccurredOn { get; }
        public UserVerifiedEvent(Guid userId)
        {
            UserId = userId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
