using System;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using Azure;
using Azure.Communication.Email;
using Azure.Communication.Email.Models;
class DataTier{
    public static string connStr = "";

    // perform login check using Stored Procedure "LoginCount" in Database based on given user' studentID and Password
    public bool LoginCheck(User user){
        MySqlConnection conn = new MySqlConnection(connStr);
        try
        {  
            conn.Open();
            string procedure = "LoginCount";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure; // set the commandType as storedProcedure
            cmd.Parameters.AddWithValue("@inputUsername", user.userID);
            cmd.Parameters.AddWithValue("@inputPassword", user.userPassword);
            cmd.Parameters.Add("@userCount", MySqlDbType.Int32).Direction =  ParameterDirection.Output;
            MySqlDataReader rdr = cmd.ExecuteReader();
           
            int returnCount = (int) cmd.Parameters["@userCount"].Value;
            rdr.Close();
            conn.Close();

            if (returnCount ==1){
                return true;
            }
            else{
                return false;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return false;
        }
       
    }

    public DataTable CheckResident(){
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("Please input a unit number");
        string unit = Console.ReadLine();
        try
        {  
            conn.Open();
            string procedure = "CheckUnit";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputUnit", unit);
            cmd.Parameters["@inputUnit"].Direction = ParameterDirection.Input;
            

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableEnrollment = new DataTable();
            tableEnrollment.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableEnrollment;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public  DataTable AddPackage() {
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("Please confirm the Unit ID");
        int inputUnit = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input a Resident ID");
        int inputResident = Int32.Parse(Console.ReadLine());
        Console.WriteLine("Please input a delevery service (FedEx, USPS, UPS, ect)");
        string deliver = Console.ReadLine();

        conn.Open();
        
        MySqlCommand cmd;
        // = new MySqlCommand(str, conn);
        cmd = new MySqlCommand("INSERT INTO PendingPackages (PendingPackages.ResidentID, PendingPackages.UnitID, PendingPackages.Deliver) VALUES ("+ inputResident + ", "+ inputUnit +", '"+ deliver +"')", conn);
        cmd.ExecuteNonQuery();

        MySqlCommand cmd3 = new MySqlCommand($"SELECT email FROM `Residents` WHERE Residents.id = {inputResident};", conn);
        string result = (string)cmd3.ExecuteScalar();

        email(result);

        
        
        try
        {  
            // conn.Open();
            string procedure = "CheckUnit";
            MySqlCommand cmd2 = new MySqlCommand(procedure, conn);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@inputUnit", inputUnit);
            cmd2.Parameters["@inputUnit"].Direction = ParameterDirection.Input;
            

            MySqlDataReader rdr2 = cmd2.ExecuteReader();

            DataTable tableEnrollment = new DataTable();
            tableEnrollment.Load(rdr2);
            rdr2.Close();
            conn.Close();
            return tableEnrollment;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public DataTable CheckPackages() {
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("Input a unit for which you want to check pending packages");
        int inputUnit = Int32.Parse(Console.ReadLine());

        try
        {  
            conn.Open();
            string procedure = "CheckPackages";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputUnitID", inputUnit);
            cmd.Parameters["@inputUnitID"].Direction = ParameterDirection.Input;
            

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableEnrollment = new DataTable();
            tableEnrollment.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableEnrollment;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public DataTable AddHistory() {
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("What Package was picked up?");
        int inputPackage = Int32.Parse(Console.ReadLine());

        try
        {  
            conn.Open();
            string procedure = "MoveToHistory";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@inputPackageID", inputPackage);
            cmd.Parameters["@inputPackageID"].Direction = ParameterDirection.Input;


            

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableHistory = new DataTable();
            tableHistory.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableHistory;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public DataTable CheckHistory() {
        MySqlConnection conn = new MySqlConnection(connStr);
        // Console.WriteLine("What Package was picked up?");
        // int inputPackage = Int32.Parse(Console.ReadLine());

        try
        {  
            conn.Open();
            string procedure = "CheckHistory";
            MySqlCommand cmd = new MySqlCommand(procedure, conn);
            cmd.CommandType = CommandType.StoredProcedure;
            // cmd.Parameters.AddWithValue("@inputPackageID", inputPackage);
            // cmd.Parameters["@inputPackageID"].Direction = ParameterDirection.Input;


            

            MySqlDataReader rdr = cmd.ExecuteReader();

            DataTable tableHistory = new DataTable();
            tableHistory.Load(rdr);
            rdr.Close();
            conn.Close();
            return tableHistory;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public  DataTable AddUnknown() {
        MySqlConnection conn = new MySqlConnection(connStr);
        Console.WriteLine("Please enter the package owner");
        string inputOwner = Console.ReadLine();        
        Console.WriteLine("Please input a delevery service (FedEx, USPS, UPS, ect)");
        string inputdeliver = Console.ReadLine();
        // Console.WriteLine("Please enter a date (06/09/2001)");
        // DateTime inputDate = DateTime.Parse(Console.ReadLine());
        // string formatDate = inputDate.ToString("yyyy-MM-dd HH:mm:ss");
        
        

        conn.Open();
        
        MySqlCommand cmd;
        // = new MySqlCommand(str, conn);
        cmd = new MySqlCommand("INSERT INTO UnknownPackages (UnknownPackages.UnknownOwner, UnknownPackages.UnknownDeliver) VALUES ('" + inputOwner + "', '" + inputdeliver +"')", conn);
        cmd.ExecuteNonQuery();
        try
        {  
            // conn.Open();
            string procedure = "CheckUnknown";
            MySqlCommand cmd2 = new MySqlCommand(procedure, conn);
            cmd2.CommandType = CommandType.StoredProcedure;
           
            

            MySqlDataReader rdr2 = cmd2.ExecuteReader();

            DataTable tableEnrollment = new DataTable();
            tableEnrollment.Load(rdr2);
            rdr2.Close();
            conn.Close();
            return tableEnrollment;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
            conn.Close();
            return null;
        }
    }

    public static async Task email(string email) {
        // this serviceConnectionString is stored in the code diectly in this example for demo purpose
        // it should be stored in the server when working for a business application.
        // ref: https://learn.microsoft.com/en-us/azure/communication-services/quickstarts/create-communication-resource?tabs=windows&pivots=platform-azp#store-your-connection-string
        string serviceConnectionString =  "";
        EmailClient emailClient = new EmailClient(serviceConnectionString);
        var subject = "Hello CIDM4360/5360 Week10";
        var emailContent = new EmailContent(subject);
        // use Multiline String @ to design html content
        emailContent.Html= @"
                    <html>
                        <body>
                            <h1>Hello,</h1>
                            <p>We have received a package in the office for you. Due to limited storing space you will have 5 days to pick up your package or it will be sent back.</p>
                            <p>Thank You!!</p>
                        </body>
                    </html>";


        // mailfrom domain of your email service on Azure
        var sender = "DoNotReply@55bcfa3a-a176-4978-ba9b-dce4a17a63e6.azurecomm.net";

        // Console.WriteLine("Please input an email address: ");
        string inputEmail = email;
        var emailRecipients = new EmailRecipients(new List<EmailAddress> {
            new EmailAddress(inputEmail) { DisplayName = "Testing" },
        });

        var emailMessage = new EmailMessage(sender, emailContent, emailRecipients);

        try
        {
            SendEmailResult sendEmailResult = emailClient.Send(emailMessage);

            string messageId = sendEmailResult.MessageId;
            if (!string.IsNullOrEmpty(messageId))
            {
                Console.WriteLine($"Email sent, MessageId = {messageId}");
            }
            else
            {
                Console.WriteLine($"Failed to send email.");
                return;
            }

            // wait max 2 minutes to check the send status for mail.
            var cancellationToken = new CancellationTokenSource(TimeSpan.FromMinutes(2));
            do
            {
                SendStatusResult sendStatus = emailClient.GetSendStatus(messageId);
                Console.WriteLine($"Send mail status for MessageId : <{messageId}>, Status: [{sendStatus.Status}]");

                if (sendStatus.Status != SendStatus.Queued)
                {
                    break;
                }
                await Task.Delay(TimeSpan.FromSeconds(10));
               
            } while (!cancellationToken.IsCancellationRequested);

            if (cancellationToken.IsCancellationRequested)
            {
                Console.WriteLine($"Looks like we timed out for email");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in sending email, {ex}");
        }
    }
}