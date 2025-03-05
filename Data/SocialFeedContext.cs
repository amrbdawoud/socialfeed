using System;
using Microsoft.EntityFrameworkCore;
using socialfeed.Models;

namespace socialfeed.Data;

public class SocialFeedContext : DbContext
{
    public SocialFeedContext(DbContextOptions<SocialFeedContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Follows>()
        .HasOne(f => f.Follower)
        .WithMany()
        .HasForeignKey(f => f.FollowerId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Follows>()
        .HasOne(f => f.Following)
        .WithMany()
        .HasForeignKey(f => f.FollowingId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
        .HasOne(c => c.User)
        .WithMany()
        .HasForeignKey(c => c.UserId)
        .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<User>()
        .HasIndex(u => u.Email)
        .IsUnique();
    }

    public DbSet<User> Users { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<Comment> Comments { get; set; }
    public DbSet<Follows> Follows { get; set; }

}
