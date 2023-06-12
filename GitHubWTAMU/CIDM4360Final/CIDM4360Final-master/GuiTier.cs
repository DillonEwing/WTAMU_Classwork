using System;
using System.Data;
using MySql.Data.MySqlClient;
class GuiTier{
    User user = new User();
    DataTier database = new DataTier();

    // print login page
    public User Login(){
        Console.WriteLine("------Welcome to Package Management System------");
        Console.WriteLine("Please input user Username: ");
        user.userID = Console.ReadLine();
        Console.WriteLine("Please input password: ");
        user.userPassword = Console.ReadLine();
        return user;
    }

    public int Dashboard(User user){
        DateTime localDate = DateTime.Now;
        Console.WriteLine("---------------Dashboard-------------------");
        Console.WriteLine($"Hello: {user.userID}; Date/Time: {localDate.ToString()}");
        Console.WriteLine("Please select an option to continue:");
        Console.WriteLine("1. Add A Package");
        Console.WriteLine("2. Add An Unknown Package");
        Console.WriteLine("3. Pickup A Package");
        Console.WriteLine("4. Check Package History");
        Console.WriteLine("5. Log Out");
        
        int option = Convert.ToInt16(Console.ReadLine());
        return option;
    }

    public void DisplayUnit(DataTable tableUnit){
        Console.WriteLine("---------------Unit List-------------------");
        foreach(DataRow row in tableUnit.Rows){
           Console.WriteLine($"ID: {row["ID"]} \t Full Name: {row["full_name"]} \t Email:{row["email"]} \t Unit:{row["unit_number"]}");
        }
    }

    public void DisplayPackages(DataTable tablePackages){
        Console.WriteLine("---------------Package List-------------------");
        foreach(DataRow row in tablePackages.Rows){
           Console.WriteLine($"PackageID: {row["PackageID"]} Unit: {row["UnitID"]} \t Resident:{row["ResidentID"]} \t Devivery Service:{row["Deliver"]}");
        }
    }

    public void DisplayHistory(DataTable tableHistory) {
        Console.WriteLine("---------------Package History List-------------------");
        foreach(DataRow row in tableHistory.Rows){
            Console.WriteLine($"PackageID: {row["HistoryID"]} Unit: {row["UnitID"]} \t Resident:{row["ResidentID"]} \t Devivery Service:{row["Deliver"]}");
        }
    }

    public void DisplayUnknown(DataTable tableUnknown) {
        Console.WriteLine("---------------Unknown Package List-------------------");
        foreach(DataRow row in tableUnknown.Rows){
            Console.WriteLine($"PackageID: {row["UnknownID"]} Owner: {row["UnknownOwner"]} \t Delivery Service:{row["UnknownDeliver"]} \t Date Delivered:{row["UnknownDate"]}");
        }
    }
}


