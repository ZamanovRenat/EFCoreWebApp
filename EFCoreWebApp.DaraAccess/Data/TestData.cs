using System.Collections.Generic;
using EFCoreWebApp.Core.Domain;

namespace EFCoreWebApp.DaraAccess.Data
{
    public class TestData
    {
        public static IEnumerable<User> Users => new List<User>()
        {
            new User()
                { Name = "Tom", Age = 26 },
            new User()
                { Name = "Jerry", Age = 12 },
            new User()
                { Name = "Bull", Age = 29 },
        };
    }
}
