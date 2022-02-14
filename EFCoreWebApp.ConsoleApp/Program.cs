﻿using System;
using System.Linq;
using EFCoreWebApp.ConsoleApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace EFCoreWebApp.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                // пересоздадим базу данных
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                // добавляем начальные данные
                Company microsoft = new Company { Name = "Microsoft" };
                Company google = new Company { Name = "Google" };
                db.Companies.AddRange(microsoft, google);

                User tom = new User { Name = "Tom", Company = microsoft };
                User bob = new User { Name = "Bob", Company = google };
                User alice = new User { Name = "Alice", Company = microsoft };
                User kate = new User { Name = "Kate", Company = google };
                db.Users.AddRange(tom, bob, alice, kate);

                db.SaveChanges();

                // получаем пользователей
                var users = db.Users
                    .Include(u => u.Company)  // подгружаем данные по компаниям
                    .ToList();
                foreach (var user in users)
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var users = db.Users.ToList();
                foreach (User user in users)
                    Console.WriteLine($"{user.Name} - {user.Company?.Name}");
            }
            using (ApplicationContext db = new ApplicationContext())
            {
                var companies = db.Companies.ToList();
                foreach (Company company in companies)
                {
                    Console.Write($"{company.Name}:");
                    foreach (User user in company.Users)
                        Console.Write($"{user.Name} ");
                    Console.WriteLine();
                }
            }
        }
    }
}
