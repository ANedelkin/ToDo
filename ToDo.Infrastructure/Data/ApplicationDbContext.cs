using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Infrastructure.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //LabelTask

        builder.Entity<LabelTask>().HasKey(lt => new { lt.LabelId, lt.TaskId });

        builder.Entity<LabelTask>()
            .HasOne(lt => lt.Label)
            .WithMany()
            .HasForeignKey(lt => lt.LabelId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<LabelTask>()
            .HasOne(lt => lt.Task)
            .WithMany()
            .HasForeignKey(lt => lt.TaskId)
            .OnDelete(DeleteBehavior.ClientCascade);

        //RoleUser

        builder.Entity<RoleUser>().HasKey(ru => new { ru.RoleId, ru.UserId });

        builder.Entity<RoleUser>()
            .HasOne(ru => ru.Role)
            .WithMany()
            .HasForeignKey(ru => ru.RoleId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<RoleUser>()
            .HasOne(ru => ru.User)
            .WithMany()
            .HasForeignKey(ru => ru.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);

        //UserTask

        builder.Entity<UserTask>().HasKey(ut => new { ut.UserId, ut.TaskId });

        builder.Entity<UserTask>()
            .HasOne(ut => ut.User)
            .WithMany()
            .HasForeignKey(ut => ut.UserId)
            .OnDelete(DeleteBehavior.ClientCascade);

        builder.Entity<UserTask>()
            .HasOne(ut => ut.Task)
            .WithMany()
            .HasForeignKey(ut => ut.TaskId)
            .OnDelete(DeleteBehavior.ClientCascade);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Models.Label> Labels { get; set; }
    public DbSet<LabelTask> LabelTasks { get;set; }
    public DbSet<RoleUser> RoleUsers { get; set; }
    public DbSet<UserTask> UserTasks { get; set; }
}
