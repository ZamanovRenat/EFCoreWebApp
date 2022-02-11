using System;

namespace EFCoreWebApp.Models
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
    }
}
