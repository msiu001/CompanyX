namespace EmployeeData.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Collections.Generic;
    using System.Linq;
    using EmployeeData.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<EmployeeData.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EmployeeData.Models.ApplicationDbContext context)
        {
            var emp = new List<Employee>
            {
                new Employee(){Name = "Mario", ContactNo = "0123456789", Age= 35, Email = "mario01@gmail.com"},
                new Employee(){Name = "Enzo", ContactNo = "123456123", Age= 1, Email = "enzo01@gmail.com"},
                new Employee(){Name = "Yisel", ContactNo = "987654321", Age= 26, Email = "yisel01@gmail.com"}
            };

            emp.ForEach(e => context.Employees.AddOrUpdate(p => p.Id, e));
            context.SaveChanges();

            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
