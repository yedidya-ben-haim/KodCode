using BlogPlatformAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatformAPI.Data;

public class BlogPlatformDbContext: DbContext
{
    public BlogPlatformDbContext(DbContextOptions<BlogPlatformDbContext> options)
        : base(options)
    {
    }

    public DbSet<Author> Authors { get; set; } = null!;
    public DbSet<Comment> Comments { get; set; } = null!;
    public DbSet<Post> Posts { get; set; } = null!;
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Post>()
            .HasOne(p => p.Author)
            .WithMany(a => a.Posts)
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Comment>()
            .HasOne(c => c.Post)
            .WithMany(p => p.Comments)
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);
        
        var authors = new List<Author>();
        for (int i = 1; i <= 5; i++)
        {
            authors.Add(new Author { Id = i, FullName = $"Author {i}", Email = $"author{i}@test.com", JoinedDate = DateTime.Now.AddDays(-i * 10) });
        }
        modelBuilder.Entity<Author>().HasData(authors);

       
        var posts = new List<Post>();
        int postId = 1;
        foreach (var author in authors)
        {
            for (int i = 1; i <= 5; i++)
            {
                posts.Add(new Post 
                { 
                    Id = postId, 
                    AuthorId = author.Id, 
                    Title = $"Post {postId} by Author {author.Id}", 
                    Body = "This is a dummy post body.", 
                    PublishedDate = DateTime.Now.AddDays(-postId), 
                    IsPublished = true 
                });
                postId++;
            }
        }
        modelBuilder.Entity<Post>().HasData(posts);

        
        var comments = new List<Comment>();
        int commentId = 1;
        foreach (var post in posts)
        {
            for (int i = 1; i <= 3; i++)
            {
                comments.Add(new Comment 
                { 
                    Id = commentId, 
                    PostId = post.Id, 
                    CommenterName = $"Reader {commentId}", 
                    Text = $"Great post number {post.Id}!", 
                    CreatedAt = DateTime.Now 
                });
                commentId++;
            }
        }
        modelBuilder.Entity<Comment>().HasData(comments);
        
        


    }
}
