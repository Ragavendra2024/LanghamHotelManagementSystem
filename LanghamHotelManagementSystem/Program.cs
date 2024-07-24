using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace assessment503_2
{
    internal class Program
    {

        static string myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        static void AddRoom() // create a method for add rooms
        {

            string directoryPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LHMS HotelManagement");
            string filePath = Path.Combine(directoryPath, "lhms_AddRoomfile.txt");
            if (!Directory.Exists(directoryPath))
            {
                // Create the directory
                Directory.CreateDirectory(directoryPath);
                Console.WriteLine("Directory created: " + directoryPath);
            }
            else
            {
                Console.WriteLine("Directory already exists: " + directoryPath);
            }


            // Check if the file exists
            if (!File.Exists(filePath))
            {
                // Create the file
                using (FileStream fs = File.Create(filePath))
                {
                    Console.WriteLine("File createdfor LHMS Hotel : " + filePath);
                }
            }
            else
            {
                Console.WriteLine("File already exists for LHMS Hotel: " + filePath);
            }



            Console.WriteLine("\n****************");
            Console.WriteLine("\n Add Room");
            Console.WriteLine("\n****************");
            Console.WriteLine("Enter the Room NUmber");
            int roomnum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Floor numbber");
            int floornum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Room Created by: ");
            string createdname = Convert.ToString(Console.ReadLine());
            // storing the input in the text file 
            using (StreamWriter writer = new StreamWriter(myDocuments + "\\LHMS HotelManagement\\lhms_AddRoomfile.txt", true))
            {
                writer.WriteLine("**************************");
                writer.WriteLine("  Room Add List" + DateTime.Now); ;
                writer.WriteLine("\n Room Number: " + roomnum + "\n Floor Number: " + floornum);
                writer.WriteLine("  Room Created by: " + createdname);
                writer.WriteLine("**************************");
            }

        }
        // creating the method to display the aded rooms
        static void DisplayRooms()
        {
            try
            {


                // read the room from the roomadded file
                string allfileText = File.ReadAllText(myDocuments + "\\LHMS HotelManagement\\lhms_AddRoomfile.txt");

                Console.WriteLine(allfileText); //  display the added room list
                Console.ReadLine();

            }
            catch (UnauthorizedAccessException ex)
            {
                Console.WriteLine("UnauthorizedAccessException: Unable to access file.");
                Console.WriteLine(ex.Message);
            }
        }

        // creating the method for roomallocation 
        static void AllocateRoom()
        {
            Console.WriteLine("Enter the room number:");
            int roomnum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Floor Number:");
            int floornum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the coustmer full name:");
            string nameofcustomer = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter customer phone number:");
            int phonenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Number of days staying:");
            int days = Convert.ToInt32(Console.ReadLine());
            using (StreamWriter writer = new StreamWriter(myDocuments + "\\LHMS HotelManagement\\lhms_Allocatedroomlist.txt", true))
            {
                writer.WriteLine("**************************");
                writer.WriteLine("  Allocate Room List " + DateTime.Now); ;
                writer.WriteLine("\n Room Number: " + roomnum + "\n Floor Number: " + floornum);
                writer.WriteLine(" customer name: " + nameofcustomer + "\n customer phone number: " + phonenumber);
                writer.WriteLine("number of days staying: " + days);
                writer.WriteLine("**************************");
            }

        }
        static void DeAllocateRoom()
        {
            Console.WriteLine("Enter the room number:");
            int roomnum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter Floor Number:");
            int floornum = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the coustmer full name:");
            string nameofcustomer = Convert.ToString(Console.ReadLine());
            Console.WriteLine("Enter customer phone number");
            int phonenumber = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Enter the Employee Name");
            string roomcreated = Convert.ToString(Console.ReadLine());

            using (StreamWriter writer = new StreamWriter(myDocuments + "\\LHMS HotelManagement\\lhms_Allocatedroomlist.txt", true))
            {
                writer.WriteLine("**************************");
                writer.WriteLine(" De Allocate Room List" + DateTime.Now); ;
                writer.WriteLine("\n Room Number: " + roomnum + "\n Floor Number: " + floornum);
                writer.WriteLine(" customer name: " + nameofcustomer + "\n customer phone number: " + phonenumber);
                writer.WriteLine("Deallcote Room Created by: " + roomcreated);
                writer.WriteLine("**************************");
            }

        }

        static void DisplayRoomAllocations()

        {


            string allfileText = File.ReadAllText(myDocuments + "\\LHMS HotelManagement\\lhms_Allocatedroomlist.txt");
            Console.WriteLine(allfileText);
            Console.ReadLine();


        }

        static void SaveRoomAllocationsToFile()
        {
            try
            {
                string temporarysave = "fileback.txt";
                string Addroomfile = File.ReadAllText(myDocuments + "\\LHMS HotelManagement\\lhms_AddRoomfile.txt");// add rooms
                string Allocateroomfile = File.ReadAllText(myDocuments + "\\LHMS HotelManagement\\lhms_Allocatedroomlist.txt");//allocate room
                string savefile = myDocuments + "\\LHMS HotelManagement\\" + temporarysave;
                using (StreamWriter newfile = new StreamWriter(savefile))
                {
                    newfile.WriteLine("information from Room Added");
                    newfile.WriteLine(Addroomfile);
                    newfile.WriteLine("information from Allocate and De Allocate Room");
                    newfile.WriteLine(Allocateroomfile);

                }
                string Backupdocument = myDocuments + "\\LHMS HotelManagement\\" + temporarysave + "_finalbackup.txt";

                File.Copy(savefile, Backupdocument);
                using (FileStream fs = new FileStream(savefile, FileMode.Open))
                {
                    fs.SetLength(0);

                }
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine("Unauthorized access! Unable to write to file.");
            }
            Console.WriteLine("backup created");
        }
        static void ShowRoomAllocationsFromFile()
        {
            try
            {
                string allfileText = File.ReadAllText(myDocuments + "\\LHMS HotelManagement\\fileback.txt_finalbackup.txt");
                Console.WriteLine(allfileText);
                Console.ReadLine();
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("Error: The specified file was not found.");
            }
        }
        static void ProcessInput(string input)
        {

        }
        static void Main(string[] args)
        {


            char ans = 'n';
            do
            {
                Console.WriteLine("\n**********************************");
                Console.WriteLine("Hotel Management System Menu:       ");
                Console.WriteLine("***********************************");
                Console.WriteLine("1.Add Room");
                Console.WriteLine("2.Display Rooms");
                Console.WriteLine("3.Allocate Room");
                Console.WriteLine("4.De-Allocate Room");
                Console.WriteLine("5.Display Room Allocation");
                Console.WriteLine("6.Billing*");
                Console.WriteLine("7.Save Room Allocation to File");
                Console.WriteLine("8.Show Room Allocation from File*");
                Console.WriteLine("9.Exit");
                Console.WriteLine("Please enter your choice (1-9):");


                try
                {

                    int choice;
                    choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            AddRoom();
                            break;
                        case 2:
                            DisplayRooms();
                            break;
                        case 3:
                            AllocateRoom();
                            break;
                        case 4:
                            DeAllocateRoom();
                            break;
                        case 5:
                            DisplayRoomAllocations();
                            break;
                        case 6:
                            Console.WriteLine("Billing Feature is Under Construction and will be added soon...!!!");
                            break;
                        case 7:
                            SaveRoomAllocationsToFile();
                            break;
                        case 8:
                            ShowRoomAllocationsFromFile();
                            break;

                        case 9:
                            Console.WriteLine("Now it is exiting from this program...");
                            break;
                        default:
                            throw new InvalidOperationException();

                    }


                }
                catch (FormatException)
                {
                    Console.WriteLine("Error: The input is not a valid number. Please enter a numeric value.");
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine("Error: It does not match any existing items." + ex.Message);
                }


                Console.Write("\nWould You Like To Continue(Y/N):");
                ans = Convert.ToChar(Console.ReadLine());
            }


            while (ans == 'y');


        }


    }

}
