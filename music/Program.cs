using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace music
{
    public class data
    {
        public string musicname;
        public string musicartist;
        public string musicAlbum;
        public string musicGenre;
        public int musicSize;
        public int musicTime;
        public int musicYear;
        public int musicPlays;

    }


    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("MusicPlaylistAnalyzer <music_playlist_file_path> <report_file_path>");
                return;
            }

            string filename = args[0];
            string output = args[1];


            List<data> songs = new List<data>();
            StreamReader file = new StreamReader(filename);
            var line = file.ReadLine();
            while (!file.EndOfStream)
            {
                line = file.ReadLine();
                var values = line.Split('\t');
                string name = values[0];
                string artist = values[1];
                string album = values[2];
                string genre = values[3];
                int size = int.Parse(values[4]);
                int time = int.Parse(values[5]);
                int year = int.Parse(values[6]);
                int plays = int.Parse(values[7]);
                songs.Add(new data() { musicname = name, musicartist = artist, musicAlbum = album, musicGenre = genre, musicSize = size, musicTime = time, musicYear = year, musicPlays = plays });
            }


            //Write report
            var report = new StreamWriter(output);
            report.WriteLine("Music Playlist Report");
            report.WriteLine("");

            report.WriteLine("Songs that received 200 or more plays:");
            var playesdata = from song in songs where song.musicPlays >= 200 select song;
            foreach (var song in playesdata)
            {
                report.WriteLine("Name: " + song.musicname + ", " + "Artist: " + song.musicartist + ", " + "Album: " + song.musicAlbum + ", " + "Genre: " + song.musicGenre + ", " + "Size: " + song.musicSize + ", " + "Time: " + song.musicTime + ", " + "Year: " + song.musicYear + ", " + "Plays: " + song.musicPlays);
            }
            report.WriteLine("");

            int playlist = 0;
            var song_playlist = from song in songs where song.musicGenre == "Alternative" select song;
            foreach (var alt in song_playlist)
                playlist++;
            report.WriteLine("Number of Alternative songs: " + playlist);
            report.WriteLine("");

            int rap_playlist = 0;
            var song_rap_playlist = from song in songs where song.musicGenre == "Hip-Hop/Rap" select song;
            foreach (var alt in song_rap_playlist)
                rap_playlist++;
            report.WriteLine("Number of Hip-Hop/Rap songs: " + rap_playlist);
            report.WriteLine("");

            report.WriteLine("Songs from the album Welcome to the Fishbowl:");
            var albumdata = from song in songs where song.musicAlbum == "Welcome to the Fishbowl" select song;
            foreach (var song in albumdata)
            {
                report.WriteLine("Name: " + song.musicname + ", " + "Artist: " + song.musicartist + ", " + "Album: " + song.musicAlbum + ", " + "Genre: " + song.musicGenre + ", " + "Size: " + song.musicSize + ", " + "Time: " + song.musicTime + ", " + "Year: " + song.musicYear + ", " + "Plays: " + song.musicPlays);
            }
            report.WriteLine("");

            report.WriteLine("Songs from before 1970:");
            var before = from song in songs where song.musicYear < 1970 select song;
            foreach (var song in before)
            {
                report.WriteLine("Name: " + song.musicname + ", " + "Artist: " + song.musicartist + ", " + "Album: " + song.musicAlbum + ", " + "Genre: " + song.musicGenre + ", " + "Size: " + song.musicSize + ", " + "Time: " + song.musicTime + ", " + "Year: " + song.musicYear + ", " + "Plays: " + song.musicPlays);
            }
            report.WriteLine("");

            report.WriteLine("Song names longer than 85 characters:");
            var longer = from song in songs where song.musicname.Length > 85 select song;
            foreach (var song in longer)
            {
                report.WriteLine("Name: " + song.musicname + ", " + "Artist: " + song.musicartist + ", " + "Album: " + song.musicAlbum + ", " + "Genre: " + song.musicGenre + ", " + "Size: " + song.musicSize + ", " + "Time: " + song.musicTime + ", " + "Year: " + song.musicYear + ", " + "Plays: " + song.musicPlays);
            }
            report.WriteLine("");

            report.WriteLine("Longest song Name:");
            var longest = from song in songs orderby song.musicTime descending select song;
            foreach (var song in longest)
            {
                report.WriteLine("Name: " + song.musicname + ", " + "Artist: " + song.musicartist + ", " + "Album: " + song.musicAlbum + ", " + "Genre: " + song.musicGenre + ", " + "Size: " + song.musicSize + ", " + "Time: " + song.musicTime + ", " + "Year: " + song.musicYear + ", " + "Plays: " + song.musicPlays);
                break;
            }

            report.Close();
        }
    }
}