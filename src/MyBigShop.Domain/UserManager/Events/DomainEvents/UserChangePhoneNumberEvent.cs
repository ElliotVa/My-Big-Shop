using MyBigShop.Domain.UserManager.Events.IEvents;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Events.DomainEvents
{
    public class UserChangePhoneNumberEvent : IDomainEvents
    {
        public Guid UserId { get; }
        public DateTime OccurredOn { get; }

        public UserChangePhoneNumberEvent(Guid userId)
        {
            UserId = userId;
            OccurredOn = DateTime.UtcNow;
        }
    }
}
