using Microsoft.EntityFrameworkCore;

namespace NetCore.Server.Models
{
    public class ApplicationContext : DbContext
    {
        //public DbSet<Group> Groups { get; set; }
              
        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }

        //public DbSet<TodoStatus> TodoStatuses { get; set; }

        //public DbSet<Todo> Todos { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            /*var group1 = new Group() { 
                Id = 1, 
                Name = "КДСофт", 
                Code = "kds"                
            };
            var group2 = new Group() { 
                Id = 2, 
                Name = "ГКИнтеграция", 
                Code = "gki" 
            };
            var groups = new List<Group>() 
            { 
                group1, 
                group2 
            };*/

            var account1 = new Account() 
            { 
                Id = 1, 
                Name = "Сашка"
            };
            var account2 = new Account() 
            {
                Id = 2,
                Name = "ВлаDick"
            };
            var account3 = new Account()
            {
                Id = 3,
                Name = "Соффка"
            };
            var accounts = new List<Account>() 
            {
                account1,
                account2,
                account3
            };

            var user1 = new User()
            {
                Id = 1,
                Login = "Alex",
                Password = "Alex",
                AccountId = 1
            };
            var user2 = new User()
            {
                Id = 2,
                Login = "Vlad",
                Password = "Vlad",
                AccountId = 2
            };
            var user3 = new User()
            {
                Id = 3,
                Login = "Sofa",
                Password = "Sofa",
                AccountId = 3
            };
            var users = new List<User>()
            {
                user1,
                user2,
                user3
            };

            /*var todoStatus1 = new TodoStatus()
            {
                Id = 1,
                Name = "Backlog"
            };
            var todoStatus2 = new TodoStatus()
            {
                Id = 2,
                Name = "In Progress"
            };
            var todoStatus3 = new TodoStatus()
            {
                Id = 3,
                Name = "Done"
            };
            var todoStatuses = new List<TodoStatus>()
            {
                todoStatus1,
                todoStatus2,
                todoStatus3
            };

            var todo1 = new Todo()
            {
                Id = 1,
                Title = "Бебра",
                Description = "Бебра",
                StatusId = 1,
                CreatorId = 1,
                ExecutorId = 2,
                CreateDate = new DateTime(2022, 03, 27),
                ChangeDate = new DateTime(2022, 03, 27)
            };
            var todo2 = new Todo()
            {
                Id = 2,
                Title = "Пипикс",
                Description = "Пипикс",
                StatusId = 2,
                CreatorId = 2,
                ExecutorId = 3,
                CreateDate = new DateTime(2022, 03, 27),
                ChangeDate = new DateTime(2022, 03, 27)                
            };
            var todo3 = new Todo()
            {
                Id = 3,
                Title = "Шарамба",
                Description = "Шарамба",
                StatusId = 3,
                CreatorId = 3,
                ExecutorId = 1,
                CreateDate = new DateTime(2022, 03, 27),
                ChangeDate = new DateTime(2022, 03, 27)
            };
            var todos = new List<Todo>()
             {
                 todo1,
                 todo2,
                 todo3
             };*/

            /*modelBuilder.Entity<Group>().HasData(groups);*/
            modelBuilder.Entity<Account>().HasData(accounts);
            modelBuilder.Entity<User>().HasData(users);
            /*modelBuilder.Entity<TodoStatus>().HasData(todoStatuses);
            modelBuilder.Entity<Todo>().HasData(todos);*/

            /*modelBuilder.Entity<Group>()
                .HasMany(g => g.Accounts)
                .WithMany(a => a.Groups)
                .UsingEntity<GroupAccount>(
                    e => e
                    .HasOne(ga => ga.Account)
                    .WithMany(a => a.GroupAccounts)
                    .HasForeignKey(ga => ga.AccountId),
                    e => e
                    .HasOne(ga => ga.Group)
                    .WithMany(g => g.GroupAccounts)
                    .HasForeignKey(ga => ga.GroupId));*/

            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<User>(u => u.AccountId);

            /*modelBuilder.Entity<Todo>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Todos)
                .HasForeignKey(t => t.StatusId);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Creator)
                .WithMany(c => c.Todos)
                .HasForeignKey(t => t.CreatorId);*/

            /*modelBuilder.Entity<Todo>()
                .HasOne(t => t.Executor)
                .WithMany(e => e.Todos)
                .HasForeignKey(t => t.ExecutorId);*/
        }
    }
}
