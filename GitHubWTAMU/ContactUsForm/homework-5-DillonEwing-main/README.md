## Your Name:

# CIDM 3312 Homework 5 - Contact Us Form (Razor Pages)
Create an ASP.NET Core application that has a Razor Page asking a user to enter their name, e-mail address, and a message. Once the user clicks Submit, confirm their submission. You DO NOT need to store the message in a database, there is no EF Core component yet.

## Requirements
Create a Razor Page called `Contact.cshtml` and a corresponding Page Model called `Contact.cshtml.cs`.

Match the layout of the Razor Page to the picture in Figure 1 below:
   - Use a &lt;h1&gt; tag with the text "Contact Us".
   - Use a &lt;form&gt; tag that will perform an HTTP Post request.
   - Use the Bootstrap grid system to layout the page.
   - The &lt;form&gt; should be in a Bootstrap column of size 4.
   - The Message should use the &lt;textarea&gt;&lt;/textarea&gt; HTML tags.
   - Ensure that all HTML tags use the proper Bootstrap classes. 
   - Add a link to your razor page in the navigation menu of the web site by adding the correct HTML code to Pages\Shared\_Layout.cshtml.
  
  
Create the Page Model to read in the contents of the form when the user clicks Submit:
   - Use Model Binding to input the Name, E-Mail address, and Message.
   - Use logging to display the Name, E-Mail address, and Message to the console when the user clicks Submit. You should log at the LogWarning level.
   - Use the proper tag helpers on the &lt;label&gt; and &lt;input&gt; tags on the Razor Page.
   - Perform Data Validation:
      - The Name field should be required.
      - The E-Mail field should be required, display as “E-Mail”, and validated as an E-Mail address.
      - The Message should be required and limited to maximum length of 200 characters.
   - Place the proper HTML tags, tag helpers, and code on the Razor Page to perform the validation and display errors as shown in Figure 2.
   
When the user clicks Submit display a message at the bottom of the page saying “Thank you for your message {Name} ({Email}): {Message}” as shown in Figure 3. This message should NOT display until the user successfully clicks Submit.

**Don't forget to comment your code.**


**Push all your changes to GitHub when you are finished with the commit message "Ready for Grading".**


![Figure 1](https://i.imgur.com/r2X2Zhz.png)Figure 1: Web page when user first visits


![Figure 2](https://i.imgur.com/UCk50C2.png)Figure 2: Data Validation Errors



![Figure 3](https://i.imgur.com/yWQczjT.png)Figure 3: Web Page after user clicks Submit. Page should reload and display the message.
