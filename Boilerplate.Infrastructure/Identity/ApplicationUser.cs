﻿using Microsoft.AspNetCore.Identity;

namespace Boilerplate.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
