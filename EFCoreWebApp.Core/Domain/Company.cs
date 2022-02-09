using System.Collections.Generic;

namespace EFCoreWebApp.Core.Domain
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } 

        public List<User> Users { get; set; }
    }
}
