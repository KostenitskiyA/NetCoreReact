using Microsoft.EntityFrameworkCore;
using NetCore.Server.Models.Entities;

namespace NetCore.Server.Models
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Group> Groups { get; set; }

        public DbSet<Account> Accounts { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<TodoStatus> TodoStatuses { get; set; }

        public DbSet<Todo> Todos { get; set; }

        /*public DbSet<FriendsRelationship> FriendsRelationships { get; set; }*/

        public DbSet<GroupAccount> GroupsAccounts { get; set; }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            : base(options)
        {
            /*Database.EnsureDeleted();
            Database.EnsureCreated();*/
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var group1 = new Group()
            {
                Id = 1,
                Name = "КДСофт",
                Code = "kds"
            };
            var group2 = new Group()
            {
                Id = 2,
                Name = "ГКИнтеграция",
                Code = "gki"
            };
            var groups = new List<Group>()
            {
                group1,
                group2
            };

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

            var friendsRelationship1 = new FriendsRelationship()
            {
                AccountId = 1,
                FriendId = 2
            };
            var friendsRelationship2 = new FriendsRelationship()
            {
                AccountId = 2,
                FriendId = 1
            };
            var friendsRelationship3 = new FriendsRelationship()
            {
                AccountId = 2,
                FriendId = 3
            };
            var friendsRelationship4 = new FriendsRelationship()
            {
                AccountId = 3,
                FriendId = 2
            };
            var friendsRelationship5 = new FriendsRelationship()
            {
                AccountId = 1,
                FriendId = 3
            };
            var friendsRelationship6 = new FriendsRelationship()
            {
                AccountId = 3,
                FriendId = 1
            };
            var friendsRelationship = new List<FriendsRelationship>()
            {
                friendsRelationship1,
                friendsRelationship2,
                friendsRelationship3,
                friendsRelationship4,
                friendsRelationship5,
                friendsRelationship6
            };

            var groupAccount1 = new GroupAccount()
            {
                IsCreator = true,
                GroupId = 1,
                AccountId = 1
            };
            var groupAccount2 = new GroupAccount()
            {
                IsCreator = true,
                GroupId = 2,
                AccountId = 2
            };
            var groupAccount3 = new GroupAccount()
            {
                IsCreator = false,
                GroupId = 2,
                AccountId = 3
            };
            var groupAccount = new List<GroupAccount>()
            {
                groupAccount1,
                groupAccount2,
                groupAccount3
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

            var todoStatus1 = new TodoStatus()
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
                GroupId = 1,
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
                GroupId = 2,
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
                GroupId = 2,
                CreateDate = new DateTime(2022, 03, 27),
                ChangeDate = new DateTime(2022, 03, 27)
            };
            var todo4 = new Todo()
            {
                Id = 4,
                Title = "Шарамба",
                Description = "Шарамба",
                StatusId = 3,
                CreatorId = 3,
                GroupId = 2,
                CreateDate = new DateTime(2022, 03, 27),
                ChangeDate = new DateTime(2022, 03, 27)
            };
            var todos = new List<Todo>()
             {
                 todo1,
                 todo2,
                 todo3,
                 todo4
             };

            modelBuilder.Entity<Group>().HasData(groups);
            modelBuilder.Entity<Account>().HasData(accounts);
            /*modelBuilder.Entity<FriendsRelationship>().HasData(friendsRelationship);*/
            modelBuilder.Entity<GroupAccount>().HasData(groupAccount);
            modelBuilder.Entity<User>().HasData(users);
            modelBuilder.Entity<TodoStatus>().HasData(todoStatuses);
            modelBuilder.Entity<Todo>().HasData(todos);

            /*modelBuilder.Entity<Account>()
                .HasMany(a => a.AccountsAccounts)
                .WithOne(aa => aa.Account)
                .HasForeignKey(a => a.AccountId);

            modelBuilder.Entity<FriendsRelationship>()
                .HasOne(a => a.Friend)
                .WithMany(f => f.AccountsAccounts)
                .HasForeignKey(a => a.FriendId);*/

            /*modelBuilder.Entity<Account>()
                .HasMany(a => a.Accounts)
                .WithMany(f => f.Accounts)
                .UsingEntity<FriendsRelationship>(
                    e => e
                    .HasOne(a => a.Account)
                    .WithMany(b => b.Friends)
                    .HasForeignKey(fr => fr.AccountId),
                    e => e
                    .HasOne(a => a.Account)
                    .WithMany(b => b.Friends)
                    .HasForeignKey(fr => fr.FriendId)
                );*/

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Accounts)
                .WithMany(a => a.Groups)
                .UsingEntity<GroupAccount>(
                    e => e
                    .HasOne(ga => ga.Account)
                    .WithMany(a => a.GroupsAccounts)
                    .HasForeignKey(ga => ga.AccountId),
                    e => e
                    .HasOne(ga => ga.Group)
                    .WithMany(g => g.GroupsAccounts)
                    .HasForeignKey(ga => ga.GroupId));

            modelBuilder.Entity<Account>()
                .HasOne(a => a.User)
                .WithOne(u => u.Account)
                .HasForeignKey<User>(u => u.AccountId);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Status)
                .WithMany(s => s.Todos)
                .HasForeignKey(t => t.StatusId);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Creator)
                .WithMany(c => c.Todos)
                .HasForeignKey(t => t.CreatorId);

            modelBuilder.Entity<Todo>()
                .HasOne(t => t.Group)
                .WithMany(g => g.Todos)
                .HasForeignKey(t => t.GroupId);
        }
    }
}
