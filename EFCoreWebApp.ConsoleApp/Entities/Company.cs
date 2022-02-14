using System.Collections.Generic;

namespace EFCoreWebApp.ConsoleApp.Entities
{
    public class Company
    {
        public int Id { get; set; }
        public string? Name { get; set; } // название компании

        public virtual List<User> Users { get; set; } = new();
    }
}
