using System;
using EFCoreWebApp.Core.Domain;
using EFCoreWebApp.Models;

namespace EFCoreWebApp.Mappers
{
    public class UserMapper
    {
        public static User MapFromModel(CreateOrEditUserRequest model, User user)
        {
            if (user == null)
            {
                user = new User();
                user.Id = Guid.NewGuid();
            }

            //user.Id = model.Id;
            user.Name = model.Name;
            user.Age = model.Age;
            //user.Email = model.Email;

            return user;
        }
    }
}
