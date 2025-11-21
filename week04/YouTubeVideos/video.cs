using System.Collections.Generic;

public class Video
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int LengthInSeconds { get; set; }

    private List<Comment> Comments = new List<Comment>();

    public Video(string title, string author, int lengthInSeconds)
    {
        Title = title;
        Author = author;
        LengthInSeconds = lengthInSeconds;
    }

    // Method to add the comment
    public void AddComment(Comment comment)
    {
        Comments.Add(comment);
    }

    // Method to add the number of comment per video
    public int GetNumberOfComments()
    {
        return Comments.Count;
    }

    // method to display comments
    public void DisplayComments()
    {
        foreach (Comment comment in Comments)
        {
            System.Console.WriteLine($"- {comment.CommenterName}: {comment.Text}");
        }
    }
}
