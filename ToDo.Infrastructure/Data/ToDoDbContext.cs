using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using ToDo.Infrastructure.Data.Models;

namespace ToDo.Infrastructure.Data;

public class ToDoDbContext : IdentityDbContext<User>
{
    public ToDoDbContext(DbContextOptions<ToDoDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        //LabelTask

        builder.Entity<Models.Label>()
               .HasMany(l => l.Tasks)
               .WithMany(t => t.Labels)
               .UsingEntity<LabelTask>(
                    lt => lt.HasOne(lt => lt.Task)
                            .WithMany()
                            .HasForeignKey(lt => lt.TaskId)
                            .OnDelete(DeleteBehavior.Restrict),
                    lt => lt.HasOne(lt => lt.Label)
                            .WithMany()
                            .HasForeignKey(lt => lt.LabelId)
                            .OnDelete(DeleteBehavior.Cascade),
                    lt => lt.HasKey(x => new { x.LabelId, x.TaskId })
                );

        // UserProject

        builder.Entity<Project>()
               .HasMany(p => p.Participants)
               .WithMany(u => u.ParticipatedProjects)
               .UsingEntity<UserProject>(
                   up => up.HasOne(up => up.User)
                           .WithMany()
                           .HasForeignKey(up => up.UserId)
                           .OnDelete(DeleteBehavior.ClientCascade),
                   up => up.HasOne(up => up.Project)
                           .WithMany()
                           .HasForeignKey(up => up.ProjectId)
                           .OnDelete(DeleteBehavior.ClientCascade),
                   up => up.HasKey(up => new { up.UserId, up.ProjectId })
               );
        builder.Entity<Project>()
               .HasOne(p => p.Owner)
               .WithMany(u => u.CreatedProjects)
               .HasForeignKey(p => p.OwnerId)
               .OnDelete(DeleteBehavior.ClientCascade);
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Project> Projects { get; set; }
    public DbSet<Models.Task> Tasks { get; set; }
    public DbSet<Role> Roles { get; set; }
    public DbSet<Models.Label> Labels { get; set; }
    public DbSet<LabelTask> LabelTasks { get; set; }
}
