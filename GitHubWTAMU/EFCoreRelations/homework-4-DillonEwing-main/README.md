## Your Name:

# CIDM 3312 Homework 4 - WT Overflow (EF Core Relationships)
Create a Stack Overflow like app that will keep track of users’ questions and answers. Each user will have a first name, last name, e-mail address, and registration date/time. Each question includes a question text and date/time posted. Each answer should have an answer text and date/time posted. The data model must adhere to the following business rules:
  - Each user can post many questions; each question is posted by one user.
  - Each user can post many answers; each answer is posted by one user.
  - Each question can have many answers; each answer applies to one question.
  

The app should have an interface like Homework 2. A user should be able to perform the following tasks. Separate these tasks into individual methods:
1. Log In. When your app first starts, ask the user for their email address. If it is already in the database, log the user in automatically, otherwise create a new user account for them. You can use `DateTime.Now` to store the current date/time as the registration date. You don't need to deal with passwords, just check the email address.
2. List all questions.
3. List only unanswered questions. Hint: This is the same as task 2 except you will use a `.Where()` LINQ method to filter only unanswered questions. Unanswered questions should have their `List<Answer>` navigation property with `.Count() == 0`.
4. Ask a question.
5. Remove a question the user previously asked. You will need some business logic to prevent users from removing other users' questions or questions that don't exist.
6. Answer a question. Notify the user if they try to answer a question that doesn't exist.

The app should be a console app with Entity Framework Core using a SQLite database.

When listing questions, format the printing so that it looks “good” and is easy to read. Display the question ID, the user who posted it, the date it was posted, the question text, and then all answers (including user name and date answer was posted) underneath in a hierarchy. Implement the `.ToString()` method for each entity.

Don’t forget to include primary keys, foreign keys, and navigation properties in your entity classes. They are always required for your app to work properly even if they are omitted from the business rules.

**Useful Entity Framework Core Resources to help with this assignment:**
  - My Videos, Sample Code, and Slides
  - Microsoft Documentation:
      - https://docs.microsoft.com/en-us/ef/core/modeling/relationships
      - https://docs.microsoft.com/en-us/ef/core/saving/related-data

**Don't forget to comment your code.**


**Push all your changes to GitHub when you are finished with the commit message "Ready for Grading".**
