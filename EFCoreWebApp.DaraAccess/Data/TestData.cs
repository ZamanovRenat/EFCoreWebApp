using System.Collections.Generic;
using System.Linq;
using EFCoreWebApp.Core.Domain;

namespace EFCoreWebApp.DaraAccess.Data
{
    public class TestData
    {
        public static IEnumerable<User> Users => new List<User>()
        {
            new User()
            {
                Id = 1,
                Name = "Tom",
                Age = 23,
                CompanyId = 1, 
            },
            new User()
            {
                Id = 2,
                Name = "Bob",
                Age = 23,
                CompanyId = 2,
            },
            new User()
            {
                Id = 3,
                Name = "Sam",
                Age = 23,
                CompanyId = 2,
            },
        };

        public static IEnumerable<Company> Companies => new List<Company>()
        {
            new Company()
            {
                Id = 1,
                Name = "Google"
            },
            new Company()
            {
                Id = 2,
                Name = "Microsoft"
            },
        };
    }
}
