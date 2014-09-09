namespace Blogging.Migrations
{
    using Blogging.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Blogging.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Blogging.Models.ApplicationDbContext context)
        {
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
            AddUserAndRole(context);

            context.Posts.AddOrUpdate(
              p => p.Title,
              new Post { PostId = 1, Title = "Blog 1", Body = "Body1", PostDate = DateTime.Now, EditDate = DateTime.Now },
              new Post { PostId = 2, Title = "Blog 2", Body = "Body2", PostDate = DateTime.Now, EditDate = DateTime.Now },
              new Post { PostId = 3, Title = "Blog 3", Body = "Body3", PostDate = DateTime.Now, EditDate = DateTime.Now },
              new Post { PostId = 4, Title = "Blog 4", Body = "Body4", PostDate = DateTime.Now, EditDate = DateTime.Now }
            );
            context.Comments.AddOrUpdate(
             p => p.CommentBody,
             new Comment { CommentId = 1, CommentBody = "Comment 1", CommentDate = DateTime.Now.AddDays(10), PostId = 1 },
             new Comment { CommentId = 2, CommentBody = "Comment 2", CommentDate = DateTime.Now.AddDays(10), PostId = 2 },
             new Comment { CommentId = 3, CommentBody = "Comment 3", CommentDate = DateTime.Now.AddDays(10), PostId = 3 },
             new Comment { CommentId = 4, CommentBody = "Comment 4", CommentDate = DateTime.Now.AddDays(10), PostId = 4 }
           );
        }
        bool AddUserAndRole(Blogging.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("Admin"));
            var um = new UserManager<ApplicationUser>
                (new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "Admin1",
                FirstName = "John",
                LastName = "Koo"
            };
            ir = um.Create(user, "admin123");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "Admin");
            return ir.Succeeded;
        }
    }
}
