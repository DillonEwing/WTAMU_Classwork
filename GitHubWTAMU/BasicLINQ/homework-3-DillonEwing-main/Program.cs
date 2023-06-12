using System;
using System.Collections.Generic;
using System.Linq;
// You need to add another using directive for LINQ. Put it here. Don't forget!

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            // Prep Work: Copy and Paste list of data
            List<Game> games = new List<Game> {
                new Game {Name = "Counter-Strike: Global Offensive", Developer = "Valve", Genre = "Action", PeakPlayers = 620408, Price = 0.00M, ReleaseDate = DateTime.Parse("8/21/2012"), ReviewScore = "Very Positive"},
                new Game {Name = "Dota 2", Developer = "Valve", Genre = "Action", PeakPlayers = 840712, Price = 0.00M, ReleaseDate = DateTime.Parse("7/9/2013"), ReviewScore = "Very Positive"},
                new Game {Name = "PLAYERUNKNOWN'S BATTLEGROUNDS", Developer = "PUBG Corporation", Genre = "Action", PeakPlayers = 935918, Price = 29.99M, ReleaseDate = DateTime.Parse("12/21/2017"), ReviewScore = "Mixed"},
                new Game {Name = "Tom Clancy's Rainbow Six Siege", Developer = "Ubisoft", Genre = "Action", PeakPlayers = 137686, Price = 39.99M, ReleaseDate = DateTime.Parse("12/1/2015"), ReviewScore = "Very Positive"},
                new Game {Name = "Grand Theft Auto V", Developer = "Rockstar Games", Genre = "Action", PeakPlayers = 89756, Price = 29.99M, ReleaseDate = DateTime.Parse("4/14/2015"), ReviewScore = "Mixed"},
                new Game {Name = "RESIDENT EVIL 2 / BIOHAZARD RE:2", Developer = "CAPCOM Co., Ltd.", Genre = "Action", PeakPlayers = 74241, Price = 59.99M, ReleaseDate = DateTime.Parse("1/24/2019"), ReviewScore = "Overwhelmingly Positive"},
                new Game {Name = "Warframe", Developer = "Digital Extremes", Genre = "Action", PeakPlayers = 79181, Price = 0.0M, ReleaseDate = DateTime.Parse("3/25/2013"), ReviewScore = "Very Positive"},
                new Game {Name = "Rust", Developer = "Facepunch Studios", Genre = "Action", PeakPlayers = 64788, Price = 34.99M, ReleaseDate = DateTime.Parse("2/8/2018"), ReviewScore = "Very Positive"},
                new Game {Name = "Football Manager 2019", Developer = "Sports Interactive", Genre = "Simulation", PeakPlayers = 64139, Price = 49.99M, ReleaseDate = DateTime.Parse("11/2/2018"), ReviewScore = "Mostly Positive"},
                new Game {Name = "Team Fortress 2", Developer = "Valve", Genre = "Action", PeakPlayers = 62806, Price = 0.00M, ReleaseDate = DateTime.Parse("10/10/2007"), ReviewScore = "Very Positive"},
                new Game {Name = "MONSTER HUNTER: WORLD", Developer = "CAPCOM Co., Ltd.", Genre = "Action", PeakPlayers = 94455, Price = 59.99M, ReleaseDate = DateTime.Parse("8/9/2018"), ReviewScore = "Mixed"},
                new Game {Name = "Rocket League", Developer = "Psyonix, Inc.", Genre = "Racing", PeakPlayers = 55813, Price = 19.99M, ReleaseDate = DateTime.Parse("7/7/2015"), ReviewScore = "Very Positive"},
                new Game {Name = "Garry's Mod", Developer = "Facepunch Studios", Genre = "Simulation", PeakPlayers = 51230, Price = 9.99M, ReleaseDate = DateTime.Parse("11/29/2006"), ReviewScore = "Overwhelmingly Positive"},
                new Game {Name = "ARK: Survival Evolved", Developer = "Studio Wildcard", Genre = "Action", PeakPlayers = 51005, Price = 49.99M, ReleaseDate = DateTime.Parse("8/27/2017"), ReviewScore = "Mixed"},
                new Game {Name = "Path of Exile", Developer = "Grinding Gear Games", Genre = "Action", PeakPlayers = 39222, Price = 0.00M, ReleaseDate = DateTime.Parse("10/23/2013"), ReviewScore = "Very Positive"},
                new Game {Name = "Sid Meier's Civilization VI", Developer = "Firaxis Games", Genre = "Strategy", PeakPlayers = 38246, Price = 59.99M, ReleaseDate = DateTime.Parse("10/20/2016"), ReviewScore = "Mixed"},
                new Game {Name = "Terraria", Developer = "Re-Logic", Genre = "Action", PeakPlayers = 36420, Price = 9.99M, ReleaseDate = DateTime.Parse("5/16/2011"), ReviewScore = "Overwhelmingly Positive"},
                new Game {Name = "Sid Meier's Civilization V", Developer = "Firaxis Games", Genre = "Strategy", PeakPlayers = 35982, Price = 29.99M, ReleaseDate = DateTime.Parse("9/21/2010"), ReviewScore = "Overwhelmingly Positive"},
                new Game {Name = "Euro Truck Simulator 2", Developer = "SCS Software", Genre = "Simulation", PeakPlayers = 35153, Price = 19.99M, ReleaseDate = DateTime.Parse("10/12/2012"), ReviewScore = "Overwhelmingly Positive"},
                new Game {Name = "Ring of Elysium", Developer = "Aurora Software", Genre = "Action", PeakPlayers = 43183, Price = 0.00M, ReleaseDate = DateTime.Parse("9/19/2018"), ReviewScore = "Mostly Positive"},
            };

            // Question 1: Select the first game in the list.
            // What is the exact data type of this query result? Put your answer in README.md
            Console.WriteLine("\n---Question 1---");
            var q1 = games.First();
            Console.WriteLine(q1);

            // Question 2
            Console.WriteLine("\n---Question 2---");
            var q2 = games.Take(3);
            foreach (Game g in q2) {
                Console.WriteLine(g);
            }

            //Question 3
            Console.WriteLine("\n---Question 3---");
            var q3 = games.Skip(4).Take(3);
            foreach (Game g in q3) {
                Console.WriteLine(g);
            }

            //Question 4 Method Syntax
            Console.WriteLine("\n---Qustion 4 Method Syntax---");
            var q4 = games.Where(g => g.PeakPlayers > 100000);
            foreach (Game g in q4) {
                Console.WriteLine(g);
            }
            //Qustion 4 Query Syntax
            Console.WriteLine("\n---Qustion 4 Query Syntax---");
            var q4Q = 
                    from g in games
                    where g.PeakPlayers > 100000
                    select g;            
            foreach (Game g in q4Q) {
                Console.WriteLine(g);
            }

            //Qustion 5 Method syntax
            Console.WriteLine("\n---Qustion 5 Method Syntax---");
            var q5 = games.Where(g => g.PeakPlayers > 100000).Where(g => g.ReleaseDate <  DateTime.Parse("1/1/2013"));
            foreach (Game g in q5) {
                Console.WriteLine(g);
            }
            //Qustion 5 Query Syntax
            Console.WriteLine("\n---Qustion 5 Query Syntax---");
            var q5Q =
                    from g in games
                    where g.PeakPlayers > 100000
                    where g.ReleaseDate < DateTime.Parse("1/1/2013")
                    select g;
            foreach (Game g in q5Q) {
                Console.WriteLine(g);
            }

            //Qustion 6
            Console.WriteLine("\n---Question 6---");
            var q6 = games.Where(g => g.ReleaseDate < DateTime.Parse("1/1/2006")).FirstOrDefault();
            if (q6 == null) {
                Console.WriteLine("No top 20 games released before 1/1/2006");
            } else {                
                Console.WriteLine(q6);                 
            }

            //Question 7
            Console.WriteLine("\n---Question 7---");
            try {
                var q7 = games.Where(g => g.ReleaseDate < DateTime.Parse("1/1/2006")).First();                
                Console.WriteLine(q7);            
            }
            catch {
                Console.WriteLine("No top 20 games released before 1/1/2006");
            }
            
            //Question 8
            Console.WriteLine("\n---Question 8---");
            try{
                var q8 = games.Single(g => g.Name == "Rust");
                Console.WriteLine(q8);
            }
            catch {
                Console.WriteLine("Game does not exist or is not in top 20");
            }

            //Qustion 9 Method Syntax
            Console.WriteLine("\n---Qustion 9 Method Syntax---");
            var q9 = games.OrderBy(g => g.ReleaseDate);
            foreach (Game g in q9) {
                Console.WriteLine(g);
            }
            //Qustion 9 Query Syntax
            Console.WriteLine("\n---Qustion 9 Query Syntax---");
            var q9Q =
                    from g in games
                    orderby g.ReleaseDate
                    select g;
            foreach (Game g in q9Q) {
                Console.WriteLine(g);
            }

            //Qustion 10 Method Syntax
            Console.WriteLine("\n---Qustion 10 Method Syntax---");
            var q10 = games.OrderBy(g => g.Genre).OrderByDescending(g => g.PeakPlayers);
            foreach (Game g in q10) {
                Console.WriteLine(g);
            }
            //Qustion 10 Query Syntax
            Console.WriteLine("\n---Qustion 10 Query Syntax---");
            var q10Q =
                    from g in games
                    orderby g.Genre
                    orderby g.PeakPlayers descending 
                    select g;
            foreach (Game g in q10Q) {
                Console.WriteLine(g);
            }

            //Question 11 Method Syntax
            Console.WriteLine("\n---Qustion 11 Method Syntax---");
            var q11 = games.Where(g => g.Price == 0.00M).Select(g => g.Name);
            foreach (var g in q11) {
                Console.WriteLine(g);
            }
            //Question 11 Query Syntax
            Console.WriteLine("\n---Qustion 11 Query Syntax---");
            var q11Q =
                    from g in games
                    where g.Price == 0.00M
                    select g.Name;
            foreach (var g in q11Q) {
                Console.WriteLine(g);
            }

            //Question 12 Method Syntax
            Console.WriteLine("\n---Qustion 12 Method Syntax---"); 
            var q12 = games.Where(g => g.Price == 0.00M).Select(g => new {g.Name, g.PeakPlayers});
            foreach (var g in q12) {
                Console.WriteLine($"{g.Name}, {g.PeakPlayers} peak players");
            } 
            //Question 12 Query Syntax
            Console.WriteLine("\n---Qustion 12 Query Syntax---");
            var q12Q =
                    from g in games
                    where g.Price == 0.00M
                    select new {g.Name, g.PeakPlayers};
            foreach (var g in q12Q) {
                Console.WriteLine($"{g.Name}, {g.PeakPlayers} peak players");
            }

            // Question 13
            Console.WriteLine("\n---Question 13---");
            var q13 = games.GroupBy(g => g.Developer);
            foreach (var group in q13) {
                Console.WriteLine($"{group.Key} - {group.Count()} game(s)");
                foreach (var game in group) {
                    Console.WriteLine("\t" + game);
                }
            }

            // Question 14
            Console.WriteLine("\n---Question 14---");
            var q14 = games.Where(g => g.PeakPlayers == games.Max(m => m.PeakPlayers));
            foreach (var g in q14) {
                Console.WriteLine(g);
            }

            // Question 15
            Console.WriteLine("\n---Question 15---");
            var q15 = games.Where(g => g.PeakPlayers < games.Average(a => a.PeakPlayers));
            foreach (var g in q15) {
                Console.WriteLine(g);
            }
        }
    }
}
