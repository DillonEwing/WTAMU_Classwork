## Your Name:

# CIDM 3312 Homework 1 - C# Review
The objective of this homework is to review C# classes, objects, and lists which are vital components to this course. This homework also introduces the concept of relationships between classes. You will create a class that contains a list of objects from another class.

Create a C# app that models doctors and their patients. Your app should meet the following requirements:

1. Start by cloning this assignment repository into VS Code.
2. Create a new C# console app using the `dotnet new console` command.
3. Model patients with a `Patient.cs` class. The `Patient` class should contain first and last name properties.
4. Model doctors with a `Doctor.cs` class. The `Doctor` class should contain a first name, last name, and **list of patients** properties.
    - This is a **challenging task**. We have not used a list within a class before. Reach out on slack for help.
5. Both `Patient.cs` and `Doctor.cs` should have the namespace `Homework1.Models`. Don't forget the proper using keyword to ensure the classes are accessible.
6. Back in the `Main` method in `Program.cs`, create a list of at least THREE doctors.
    - Each doctor should have a unique first and last name and at least TWO patients.
    - This is the **second challenging task**. You have to create the patients and add them to the list of patients for each doctor that you created in Task 4.
7. Loop through your list of doctors. Display the doctor's name, how many patients they have, and then list each patient on their own line. See the following output for an example:
```
Dr. Kareem Dana has the following 2 patients:
 Jeff Babb
 Samantha Carter
Dr. Amjad Abdullat has the following 3 patients:
 Daniel Jackson
 Jack O'Neill
 George Bush
Dr. Sean Humpherys has the following 4 patients:
 George Hammond
 Elizabeth Weir
 Ibrahim Lazrig
 Yao Ming
```
8. Please remember to comment your code. Add small, one line comments explaining each task. Add more detailed comments to highlight new things you learned and challenges you encountered and how you overcame them.

## Submit your assignment
1. Save your program and run it. At the terminal prompt, type `dotnet run`.
2. Edit `README.md` and put your name at the top.
3. Push your changes to GitHub:
    - Click the source control icon in VS Code
    - Type in a commit message
    - Click the checkbox icon to commit. (Click yes on the message box to stage your commit)
    - Click the 3 dots icon (...) for more actions and click Push.
4. Or you can push your changes to GitHub using the Terminal:
    ```
    git add -A
    git commit -m "Your commit message"
    git push
    git status
    ```
4. Verify that your changes are on GitHub.
6. Congratulations! Your assignment is complete.


