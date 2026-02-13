using System;
using System.Collections.Generic;
using System.Linq;

public class Song
{
    public string SongId { get; set; }
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Genre { get; set; }
    public string Album { get; set; }
    public TimeSpan Duration { get; set; }
    public int PlayCount { get; set; }
}

public class Playlist
{
    public string PlaylistId { get; set; }
    public string Name { get; set; }
    public string CreatedBy { get; set; }
    public List<Song> Songs { get; set; } = new List<Song>();
}

public class User
{
    public string UserId { get; set; }
    public string UserName { get; set; }
    public List<string> FavoriteGenres { get; set; } = new List<string>();
    public List<Playlist> UserPlaylists { get; set; } = new List<Playlist>();
}

public class MusicManager
{
    private List<Song> songs = new List<Song>();
    private List<User> users = new List<User>();
    private int songCounter = 1;
    private int playlistCounter = 1;

    public void AddUser(string userName)
    {
        users.Add(new User
        {
            UserId = "U" + users.Count,
            UserName = userName
        });
    }

    public void AddSong(string title, string artist, string genre, string album, TimeSpan duration)
    {
        songs.Add(new Song
        {
            SongId = "S" + songCounter++,
            Title = title,
            Artist = artist,
            Genre = genre,
            Album = album,
            Duration = duration,
            PlayCount = 0
        });
    }

    public void CreatePlaylist(string userId, string playlistName)
    {
        var user = users.FirstOrDefault(u => u.UserId == userId);
        if (user == null) return;

        user.UserPlaylists.Add(new Playlist
        {
            PlaylistId = "P" + playlistCounter++,
            Name = playlistName,
            CreatedBy = userId
        });
    }

    public bool AddSongToPlaylist(string playlistId, string songId)
    {
        var playlist = users
            .SelectMany(u => u.UserPlaylists)
            .FirstOrDefault(p => p.PlaylistId == playlistId);

        var song = songs.FirstOrDefault(s => s.SongId == songId);

        if (playlist == null || song == null) return false;

        playlist.Songs.Add(song);
        song.PlayCount++;
        return true;
    }

    public Dictionary<string, List<Song>> GroupSongsByGenre()
    {
        return songs
            .GroupBy(s => s.Genre)
            .ToDictionary(g => g.Key, g => g.ToList());
    }

    public List<Song> GetTopPlayedSongs(int count)
    {
        return songs
            .OrderByDescending(s => s.PlayCount)
            .Take(count)
            .ToList();
    }
}

public class Program
{
    public static void Main()
    {
        MusicManager manager = new MusicManager();

        manager.AddUser("Shubhankar");

        manager.AddSong("Song A", "Artist 1", "Hip-Hop", "Album X", TimeSpan.FromMinutes(3));
        manager.AddSong("Song B", "Artist 2", "Pop", "Album Y", TimeSpan.FromMinutes(4));
        manager.AddSong("Song C", "Artist 1", "Hip-Hop", "Album Z", TimeSpan.FromMinutes(5));

        manager.CreatePlaylist("U0", "My Favorites");

        manager.AddSongToPlaylist("P1", "S1");
        manager.AddSongToPlaylist("P1", "S3");

        var grouped = manager.GroupSongsByGenre();

        Console.WriteLine("Songs Grouped By Genre:");
        foreach (var genre in grouped)
        {
            Console.WriteLine(genre.Key);
            foreach (var song in genre.Value)
            {
                Console.WriteLine(" - " + song.Title);
            }
        }

        var topSongs = manager.GetTopPlayedSongs(2);

        Console.WriteLine("\nTop Played Songs:");
        foreach (var song in topSongs)
        {
            Console.WriteLine(song.Title + " - Plays: " + song.PlayCount);
        }
    }
}
