using System;
using System.Collections.Generic;
using System.Linq;

// User Class
public class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public string Bio { get; set; }
    public int FollowersCount { get; set; } = 0;
    public List<string> Following { get; set; } = new List<string>();
}

// Post Class
public class Post
{
    public string PostId { get; set; }
    public string UserId { get; set; }
    public string Content { get; set; }
    public DateTime PostTime { get; set; }
    public string PostType { get; set; }
    public int Likes { get; set; } = 0;
    public List<string> Comments { get; set; } = new List<string>();
}

// Manager Class
public class SocialMediaManager
{
    private List<User> users = new List<User>();
    private List<Post> posts = new List<Post>();

    private int userCounter = 1;
    private int postCounter = 1;

    // Register User
    public void RegisterUser(string userName, string bio)
    {
        users.Add(new User
        {
            UserId = "U" + userCounter++,
            UserName = userName,
            Bio = bio
        });
    }

    // Create Post
    public void CreatePost(string userId, string content, string type)
    {
        if (!users.Any(u => u.UserId == userId))
        {
            Console.WriteLine("User not found!");
            return;
        }

        posts.Add(new Post
        {
            PostId = "P" + postCounter++,
            UserId = userId,
            Content = content,
            PostTime = DateTime.Now,
            PostType = type
        });
    }

    // Like Post
    public void LikePost(string postId, string userId)
    {
        var post = posts.FirstOrDefault(p => p.PostId == postId);

        if (post != null)
            post.Likes++;
    }

    // Add Comment
    public void AddComment(string postId, string userId, string comment)
    {
        var post = posts.FirstOrDefault(p => p.PostId == postId);

        if (post != null)
            post.Comments.Add($"{userId}: {comment}");
    }

    // Group Posts By User
    public Dictionary<string, List<Post>> GroupPostsByUser()
    {
        return posts.GroupBy(p => p.UserId)
                    .ToDictionary(g => g.Key, g => g.ToList());
    }

    // Get Trending Posts
    public List<Post> GetTrendingPosts(int minLikes)
    {
        return posts.Where(p => p.Likes >= minLikes).ToList();
    }

    // Helper method to display posts
    public void DisplayPosts(List<Post> postList)
    {
        foreach (var p in postList)
        {
            Console.WriteLine($"PostId: {p.PostId}, User: {p.UserId}, Likes: {p.Likes}");
        }
    }
}

// ✅ Program Class (Main Entry Point)
public class Program
{
    public static void Main()
    {
        SocialMediaManager manager = new SocialMediaManager();

        // Register Users
        manager.RegisterUser("Shubhankar", "Tech Enthusiast");
        manager.RegisterUser("Aman", "Traveler");

        // Create Posts
        manager.CreatePost("U1", "Hello World!", "Text");
        manager.CreatePost("U2", "Beautiful Mountains", "Image");

        // Like Posts
        manager.LikePost("P1", "U2");
        manager.LikePost("P1", "U2");
        manager.LikePost("P2", "U1");

        // Add Comments
        manager.AddComment("P1", "U2", "Nice post!");
        manager.AddComment("P2", "U1", "Amazing view!");

        // Group Posts By User
        Console.WriteLine("\nPosts Grouped By User:");
        var grouped = manager.GroupPostsByUser();

        foreach (var userPosts in grouped)
        {
            Console.WriteLine($"User: {userPosts.Key}");
            manager.DisplayPosts(userPosts.Value);
        }

        // Trending Posts
        Console.WriteLine("\nTrending Posts (Likes >= 2):");
        var trending = manager.GetTrendingPosts(2);
        manager.DisplayPosts(trending);
    }
}
