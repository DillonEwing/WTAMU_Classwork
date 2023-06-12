## Your Name: Dillon Ewing

# CIDM 3312 Homework 3: Basic LINQ
The objective of this homework is to practice LINQ queries. You will write several LINQ queries based on data from the top 20 games on Steam (from 2019). Starter code is given in the GitHub repository. That code contains an entity class called `Game` and a List of `games`. The list will be your data source.

**Useful LINQ resources**: https://docs.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/linq/


## Homework Requirements

0. Within your entity class, make a `ToString()` method. Return the game name, genre, and number of peak players.

For the following questions, write a LINQ query using the **Method Syntax** unless directed otherwise. Display the results taking advantage of your `ToString()` method where appropriate.

1. Select the first game in the list. Answer the following question in this `README.md` file:

What is the exact data type of this query result? The first Object in the list

2. Select the first THREE games. Answer the following question:

What is the exact data type of *this* query result? Ienumerable

3. Select the 3 games after the first 4 games.
4. Select games with peak players over 100,000 in both Method and Query Syntax.
5. Select games with peak players over 100,000 and a release date before January 1, 2013 in both Method and Query Syntax.
6. Select the first game with a release date before January 1, 2006 using `.FirstOrDefault()`. If there are none, display "No top 20 games released before 1/1/2006".
7. Perform the same query as Question 7 above, but use the `.First()` method.
8. Select the game named “Rust”. Use the `.Single()` method to return just that one game.
9. Select all games ordered by release date oldest to newest in both Method and Query Syntax.
10. Select all games ordered by genre A-Z and then peak players highest to lowest in both Method and Query Syntax.
11. Select just the game name (using projection) of all games that are free in both Method and Query Syntax.
12. Select the game name and peak players of all games that are free in both Method and Query Syntax (using projection). Display the results. NOTE: You cannot use your `ToString()` to display these results. Why not?
13. Group the games by developer. Print the results to the console in a similar format to below.
```
Valve - 3 game(s)
        Counter-Strike: Global Offensive, Action, 620,408 peak players
        Dota 2, Action, 840,712 peak players
        Team Fortress 2, Action, 62,806 peak players
PUBG Corporation - 1 game(s)
        PLAYERUNKNOWN'S BATTLEGROUNDS, Action, 935,918 peak players
Ubisoft - 1 game(s)
        Tom Clancy's Rainbow Six Siege, Action, 137,686 peak players
```
14. Select the game with the most peak players.
15. Select all the games with peak players lower than the average number of peak players.

## Submit your assignment
1. Save your program and run it. At the terminal prompt, type `dotnet run`.
2. Please remember to comment your code. Add small, one line comments explaining each task. Add more detailed comments to highlight new things you learned and challenges you encountered and how you overcame them.
3. Edit `README.md`, put your name at the top, and remember to answer the TWO questions.
4. Push your changes to GitHub:
    - Click the source control icon in VS Code
    - Type in a commit message
    - Click the checkbox icon to commit. (Click yes on the message box to stage your commit)
    - Click the 3 dots icon (...) for more actions and click Push.
5. Or you can push your changes to GitHub using the Terminal:
    ```
    git add -A
    git commit -m "Ready for grading"
    git push
    git status
    ```
6. Verify that your changes are on GitHub.
7. Congratulations! Your assignment is complete.


