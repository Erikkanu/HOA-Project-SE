using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace HOA.Areas.Identity.Data;

// Add profile data for application users by adding properties to the HOAUser class
public class HOAUser : IdentityUser
{
    public string Name { get; set; }

    public string Apartment { get; set; }

    public string PhoneNumber { get; set; }

    public string Email { get; set; }

    public string Status { get; set; } = "Active";

    public string Role { get; set; } = "Resident";

}

