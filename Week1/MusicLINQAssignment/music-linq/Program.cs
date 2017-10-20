using System;
using System.Collections.Generic;
using System.Linq;
using JsonData;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //Collections to work with
            List<Artist> Artists = JsonToFile<Artist>.ReadJson();
            List<Group> Groups = JsonToFile<Group>.ReadJson();

            //========================================================
            //Solve all of the prompts below using various LINQ queries
            //========================================================

            //There is only one artist in this collection from Mount Vernon, what is their name and age?
            IEnumerable<Artist> Result1 = Artists.Where(artist => artist.Hometown == "Mount Vernon").ToArray();

            Console.WriteLine("ARTIST FROM MOUNT VERNON:");
            foreach (var val in Result1)
            {
                Console.WriteLine("Artist from Mt. Vernon: {0}, Age: {1}", val.RealName, val.Age);
            }
                    
            //Who is the youngest artist in our collection of artists?
            Artist Result2 = Artists.OrderBy(artist => artist.Age).First();

            Console.WriteLine("YOUNGEST ARTIST:");
            Console.WriteLine("Name: {0}, Youngest Age: {1}.", Result2.RealName, Result2.Age);

            //Display all artists with 'William' somewhere in their real name
            List<Artist> Result3 = Artists.Where(artist => artist.RealName.Contains("William")).ToList();

            Console.WriteLine("ARTISTS WITH 'WILLIAM' IN REAL NAME:");
            foreach (var val in Result3)
            {
                Console.WriteLine("Name: {0}.", val.RealName);
            }

            // Display all groups with names less than 8 characters in length.
            List<Group> Result4 = Groups.Where(group => group.GroupName.Length < 8).ToList();

            Console.WriteLine("GROUP WITH GROUPNAMES OF LESS THAN 8 CHARACTERS:");
            
            foreach (var val in Result4)
            {
                Console.WriteLine("Group Name: {0}", val.GroupName);
            }

            //Display the 3 oldest artist from Atlanta
            List<Artist> Result5 = Artists.Where(artist => artist.Hometown == "Atlanta").OrderByDescending(artist => artist.Age).ToList();

            Console.WriteLine("OLDEST ARTISTS FROM ATLANTA:");
            Console.WriteLine("Name: {0}, Age: {1}.", Result5[0].RealName, Result5[0].Age);
            Console.WriteLine("Name: {0}, Age: {1}.", Result5[1].RealName, Result5[1].Age);
            Console.WriteLine("Name: {0}, Age: {1}.", Result5[2].RealName, Result5[2].Age);

            //(Optional) Display the Group Name of all groups that have members that are not from New York City
            List<string> Result6 = Artists.Join(Groups,
                                                artist => artist.GroupId,
                                                group => group.Id,
                                                (artist, group) => {artist.Group = group; return artist;})
                                                .Where(artist => (artist.Hometown != "New York City" && artist.Group != null))
                                                .Select(artist => artist.Group.GroupName)
                                                .Distinct()
                                                .ToList();

            Console.WriteLine("DISPLAY GROUP NAME OF ALL GROUPS NOT FROM NY:");
            foreach (var group in Result6)
            {
                Console.WriteLine(group);
            }

            //(Optional) Display the artist names of all members of the group 'Wu-Tang Clan'
            List<Artist> Result7 = Artists.Join(Groups,
                                                artist => artist.GroupId,
                                                group => group.Id,
                                                (artist, group) => {artist.Group = group; return artist;})
                                                .Where(artist => (artist.Group.GroupName == "Wu-Tang Clan"))
                                                .ToList();

            Console.WriteLine("DISPLAY ARTISTS NAMES OF MEMBERS IN 'WU-TANG CLAN'");
            foreach (var val in Result7)
            {
                Console.WriteLine("Artist Name: {0}", val.RealName);
            }
        }   
    }
}
