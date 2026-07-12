using MyBigShop.Domain.UserManager.Events.IEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Events.DomainEvents
{
    public class UserChangeEmailEvent :IDomainEvents
    {
        public Guid Id { get; }
        public DateTime OccurredOn { get; }

        public UserChangeEmailEvent(Guid id)
        {
            Id = id;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
