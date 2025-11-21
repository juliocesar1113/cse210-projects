using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // video title
        Video video1 = new Video("C# Basics Tutorial", "Alice", 600);
        Video video2 = new Video("Advanced C# Techniques", "Bob", 1200);
        Video video3 = new Video("YouTube API Overview", "Charlie", 900);

        // adding the comments of video1
        video1.AddComment(new Comment("John", "Great tutorial!"));
        video1.AddComment(new Comment("Sarah", "Very helpful, thanks!"));
        video1.AddComment(new Comment("Mike", "I learned a lot."));

        // comments of video2
        video2.AddComment(new Comment("Linda", "Excellent explanation."));
        video2.AddComment(new Comment("Tom", "Can you do a follow-up video?"));
        video2.AddComment(new Comment("Emma", "Super clear and detailed."));

        // comments of video3
        video3.AddComment(new Comment("Alex", "This helped me understand the API."));
        video3.AddComment(new Comment("Sophie", "Nice overview."));
        video3.AddComment(new Comment("Daniel", "Thanks for sharing!"));

        List<Video> videos = new List<Video>() { video1, video2, video3 };

        // Display the video title, author, length and comments
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthInSeconds} seconds");
            Console.WriteLine($"Number of comments: {video.GetNumberOfComments()}");
            video.DisplayComments();
            Console.WriteLine();
        }
    }
}
