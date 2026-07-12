using System;
using System.Collections.Generic;
using System.Text;

namespace MyBigShop.Domain.UserManager.Events.IEvents
{
    public interface IDomainEvents
    {
        DateTime OccurredOn { get; }
    }
}
