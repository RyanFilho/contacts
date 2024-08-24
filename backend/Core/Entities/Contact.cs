using  System;
using  System.Collections.Generic;

namespace Core.Entities;

public partial class Contact
{
    public int ContactId { get; set; }

    public int UserId { get; set; }

    public string Name { get; set; }

    public required string PhoneNumber { get; set; }

    public DateTime SaveDate { get; set; }

    public virtual UserProfile? User { get; set; }
}
