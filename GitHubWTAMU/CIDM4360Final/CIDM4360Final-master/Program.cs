using System;
using System.Data;
using MySql.Data.MySqlClient;

class Program {
    static void Main(string[] args) {
        User user;
        bool _continue = true;
        DataTier database = new DataTier();

        GuiTier appGUI = new GuiTier();

        user = appGUI.Login();


        // Console.WriteLine("Enter Username:");
        // var inputUser = Console.ReadLine();
        // Console.WriteLine("Enter Password:");
        // var inputPass = Console.ReadLine();
        
        if (database.LoginCheck(user)){

            while(_continue){
                int option  = appGUI.Dashboard(user);
                switch(option)
                {
                    // New Package
                    case 1:
                        DataTable tableResident = database.CheckResident();
                        appGUI.DisplayUnit(tableResident);

                        DataTable AddPackage = database.AddPackage();
                        DataTable tablePackages = database.CheckPackages();
                        appGUI.DisplayPackages(tablePackages);
                    break;
                    case 2:
                        DataTable tableUnknown = database.AddUnknown();
                        appGUI.DisplayUnknown(tableUnknown);
                    
                    break;
                    // Package pickup
                    case 3:
                        
                        DataTable tablePackages2 = database.CheckPackages();
                        appGUI.DisplayPackages(tablePackages2);

                        DataTable MoveToHistory = database.AddHistory();
                        DataTable tableHistory = database.CheckHistory();
                        //appGUI.DisplayHistory(tableHistory);
                        Console.WriteLine("Package was picked up and moved to History!");
                        break;
                    // Drop A Course
                    case 4:
                        DataTable tableHistory2 = database.CheckHistory();
                        appGUI.DisplayHistory(tableHistory2);
                        
                        break;

                    case 5:
                        _continue = false;
                        Console.WriteLine("Logged out, Goodbye.");
                        break;
                    // default: wrong input
                    default:
                        Console.WriteLine("Wrong Input");
                        break;
                }

            }
        }
        else{
                Console.WriteLine("Login Failed, Goodbye.");
        }

    }
}