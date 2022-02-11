using System;
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
                Id = Guid.Parse("4fe33943-5aac-42c9-b331-0e2fb4a77ce6"),
                Name = "Tom",
                Age = 23,
                //CompanyId = 1, 
            },
            new User()
            {
                Id = Guid.Parse("a1aeb3b7-6b76-4a17-acf9-a4608b236cf2"),
                Name = "Bob",
                Age = 23,
                //CompanyId = 2,
            },
            new User()
            {
                Id = Guid.Parse("df18fd90-9a71-4c81-8cc9-9b56f2edbbee"),
                Name = "Sam",
                Age = 23,
                //CompanyId = 2,
            },
        };

        public static IEnumerable<Company> Companies => new List<Company>()
        {
            new Company()
            {
                Id = Guid.Parse("50bd5471-6c0d-4e44-8196-d60ba4740c6c"),
                Name = "Google"
            },
            new Company()
            {
                Id = Guid.Parse("d4a40610-098f-4a8a-bf18-3fd4279adaea"),
                Name = "Microsoft"
            },
        };
    }
}
