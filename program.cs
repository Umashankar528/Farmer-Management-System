using System;
using System.Collections.Generic;
using System.Linq;

namespace Project
{
    class Farmer
    {
        public int ID;
        public string Name, Village, GuardianName, District, State;
        public long Mobile;
    }

    class Farmer_Service
    {
        public List<Farmer> farmer_list_obj = new List<Farmer>();

        internal void Add_Farmer()
        {
            try
            {
                Farmer f = new Farmer();

                Console.Write("Enter farmer id: ");
                f.ID = int.Parse(Console.ReadLine());
                bool exists = false;
                foreach (Farmer fa in farmer_list_obj)
                {
                    if (f.ID == fa.ID)
                    {
                        exists = true;
                        break;
                    }
                }
                if (exists)
                {
                    Console.WriteLine("Farmer ID already exists.");
                    return;
                }
                Console.Write("Enter name: ");
                f.Name = Console.ReadLine().ToUpper();

                Console.Write("Enter father/Guardian name: ");
                f.GuardianName = Console.ReadLine().ToUpper();

                Console.Write("Enter 10 digit contact number: ");
                f.Mobile = long.Parse(Console.ReadLine());

                if (f.Mobile < 1000000000L || f.Mobile > 9999999999L)// help from ai
                {
                    Console.WriteLine("Mobile number must contain exactly 10 digits.");
                    return;
                }
                Console.Write("Enter village name: ");
                f.Village = Console.ReadLine().ToUpper();
                Console.Write("Enter district: ");
                f.District = Console.ReadLine().ToUpper();
                Console.Write("Enter state: ");
                f.State = Console.ReadLine().ToUpper();
                farmer_list_obj.Add(f);
                Console.WriteLine("Farmer added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        internal void Update_Farmer()
        {
            try
            {
                Console.Write("Enter Farmer id: ");
                int id = int.Parse(Console.ReadLine());
                int index = -1;
                for (int i = 0; i < farmer_list_obj.Count; i++)
                {
                    if (farmer_list_obj[i].ID == id)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Farmer Id Not Found!");
                }
                else
                {
                    Farmer fa = farmer_list_obj[index];
                    Console.Write("Enter new name: ");
                    fa.Name = Console.ReadLine().ToUpper();
                    Console.Write("Enter new father/Guardian name: ");
                    fa.GuardianName = Console.ReadLine().ToUpper();

                    //Console.Write("Enter new contact number: ");
                    //fa.Mobile = long.Parse(Console.ReadLine());    // old

                    Console.Write("Enter new contact number: ");  // help from ai
                    fa.Mobile = long.Parse(Console.ReadLine());

                    if (fa.Mobile < 1000000000L || fa.Mobile > 9999999999L)
                    {
                        Console.WriteLine("Mobile number must contain exactly 10 digits.");
                        return;
                    }

                    Console.Write("Enter new village name: ");
                    fa.Village = Console.ReadLine().ToUpper();
                    Console.Write("Enter new district: ");
                    fa.District = Console.ReadLine().ToUpper();
                    Console.Write("Enter new state: ");
                    fa.State = Console.ReadLine().ToUpper();
                    Console.WriteLine();
                    Console.WriteLine("Farmer details updated successfully!  ");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        internal void Delete_Farmer()
        {
            try
            {
                Console.Write("Enter Farmer Id: ");
                int id = int.Parse(Console.ReadLine());
                int index = -1;
                for (int i = 0; i < farmer_list_obj.Count; i++)
                {
                    if (farmer_list_obj[i].ID == id)
                    {
                        index = i;
                        break;
                    }
                }

                if (index == -1)
                {
                    Console.WriteLine("Farmer not found!");
                }
                else
                {
                    Console.Write("Do you really want to delete farmer record (y/n): ");
                    string choice = Console.ReadLine().ToLower();
                    if (choice == "y")
                    {
                        farmer_list_obj.RemoveAt(index);
                        Console.WriteLine("Farmer deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Delete operation cancelled.");
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        internal void Display_All_Farmers()
        {
            if (farmer_list_obj.Count == 0)
            {
                Console.WriteLine("No farmer records found!");
            }
            else
            {
                foreach (Farmer f in farmer_list_obj)
                {
                    Console.WriteLine(
                        $"ID: {f.ID} | Name: {f.Name} | " +
                        $"Guardian: {f.GuardianName} | " +
                        $"Mobile: {f.Mobile} | " +
                        $"Village: {f.Village} | " +
                        $"District: {f.District} | " +
                        $"State: {f.State}"
                    );
                    Console.WriteLine("------------------------------------------------------------------------------------------------");
                }
            }
        }

        internal void search_by()
        {
            try
            {
                Console.WriteLine("\nPlease Enter Your Choice You Want To Search: ");
                Console.WriteLine("\nPress 1: Search By Id");
                Console.WriteLine("Press 2: Search By Name");
                Console.WriteLine("Press 3: Search By Village");
                Console.WriteLine("Press 4: Search By Mobile Number");
                Console.Write("\nPress Number: ");
                int choice = int.Parse(Console.ReadLine());
                if (choice == 1)
                {
                    Search_BY_id();
                }
                else if (choice == 2)
                {
                    Search_BY_Name();
                }
                else if (choice == 3)
                {
                    Search_BY_Village();
                }
                else if (choice == 4)
                {
                    Search_BY_Mobile();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        internal void Search_BY_id()
        {
            try
            {
                Console.Write("\nEnter Id You Want To Search: ");
                int entered_id = int.Parse(Console.ReadLine());
                bool b = false;
                foreach (Farmer fr in farmer_list_obj)
                {
                    if (entered_id == fr.ID)
                    {
                        b = true;
                        var res = from f in farmer_list_obj where f.ID == entered_id select f;
                        foreach (Farmer f in res)
                        {
                            Console.WriteLine("\nFarmer Id: " + f.ID);
                            Console.WriteLine("Farmer Name: " + f.Name);
                            Console.WriteLine("Farmer Father/Guardian Name: " + f.GuardianName);
                            Console.WriteLine("Farmer Mobile No: " + f.Mobile);
                            Console.WriteLine("Farmer Village Name: " + f.Village);
                            Console.WriteLine("Farmer District Name: " + f.District);
                            Console.WriteLine("Farmer State Name: " + f.State);
                        }
                    }
                }
                if (b == false)
                {
                    Console.WriteLine("\nEnter Invalid Id. Please Try Again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        internal void Search_BY_Name()
        {
            string Entered_Name;
            Console.Write("\nEnter Name You Want To Search: ");
            Entered_Name = Console.ReadLine().ToUpper();
            bool b = false;
            var res = from f in farmer_list_obj where f.Name == Entered_Name select f;

            foreach (Farmer f in res)
            {
                b = true;
                Console.WriteLine($"\nFarmer Id: {f.ID}, Farmer Name: {f.Name}," +
                    $" Father/Guardian Name: {f.GuardianName}, Mobile No: {f.Mobile}, " +
                    $"Village: {f.Village}, District: {f.District}, State: {f.State}");
            }
            if (b == false)
            {
                Console.WriteLine("\nEntered Invalid Name. Please Try Again.");
            }
        }

        internal void Search_BY_Village()
        {
            Console.Write("\nEnter Village Name You Want To Search: ");
            string Entered_Village = Console.ReadLine().ToUpper();

            bool b = false;

            foreach (Farmer fr in farmer_list_obj)
            {
                if (Entered_Village == fr.Village)
                {
                    b = true;
                    var res = from f in farmer_list_obj where f.Village == Entered_Village select f;
                    foreach (Farmer f in res)
                    {
                        Console.WriteLine($"\nFarmer Id: {f.ID}, Farmer Name: {f.Name}," +
                            $" Father/Guardian Name: {f.GuardianName}, Mobile No: {f.Mobile}, " +
                            $"Village: {f.Village}, District: {f.District}, State: {f.State}");
                    }
                }
            }
            if (b == false)
            {
                Console.WriteLine("\nEntered Invalid Village Name. Please Try Again.");
            }
        }

        internal void Search_BY_Mobile()
        {
            try
            {
                Console.Write("\nEnter Mobile Number You Want To Search: ");
                long Entered_Mobile = long.Parse(Console.ReadLine());
                bool b = false;
                foreach (Farmer fr in farmer_list_obj)
                {
                    if (Entered_Mobile == fr.Mobile)
                    {
                        b = true;
                        var res = from f in farmer_list_obj where f.Mobile == Entered_Mobile select f;
                        foreach (Farmer f in res)
                        {
                            Console.WriteLine($"\nFarmer Id: {f.ID}," +
                                $" Farmer Name: {f.Name}, Father/Guardian Name: {f.GuardianName}," +
                                $" Mobile No: {f.Mobile}, Village: {f.Village}, District: {f.District}, State: {f.State}");
                        }
                    }
                }
                if (b == false)
                {
                    Console.WriteLine("\nEnter Invalid Mobile Number. Please Try Again.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)

        {


            string Choice;

            Farmer_Service farmer_Service_obj = new Farmer_Service();
            Payment_Services payment_Service_obj = new Payment_Services(farmer_Service_obj.farmer_list_obj);

            do
            {
                Console.WriteLine("==============================================================================");
                Console.WriteLine("\t\t\tFARMERS MANAGEMENT SYSTEM");
                Console.WriteLine("==============================================================================\n");

                Console.WriteLine("Press 1: Add Farmer.");
                Console.WriteLine("Press 2: Update Farmer.");
                Console.WriteLine("Press 3: Delete Farmer.");
                Console.WriteLine("Press 4: Display All Farmer Details.");
                Console.WriteLine("Press 5: Search Farmer.");
                Console.WriteLine("Press 6: Add Scheme Payment.");
                Console.WriteLine("Press 7: Update Scheme Payment.");
                Console.WriteLine("Press 8: Delete Scheme Payment.");
                Console.WriteLine("Press 9: Get Payment Details By Farmer ID and Year.");
                Console.WriteLine("Press 10: Get Total Payment By Farmer ID and Year.");

                Console.WriteLine("\n==============================================================================");
                int Case = 0;
                try
                {



                    Console.Write("\nEnter Your Choice: ");
                    Case = int.Parse(Console.ReadLine());
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fault: " + ex.Message);
                }

                switch (Case)
                {
                    case 1:
                        do
                        {
                            farmer_Service_obj.Add_Farmer();// Deepanshi

                            Console.Write("Do you want to continue adding farmers (y/n): ");
                            Choice = Console.ReadLine().ToLower();

                            Console.WriteLine();

                        } while (Choice == "y");

                        break;

                    case 2:
                        farmer_Service_obj.Update_Farmer(); // vikas
                        break;

                    case 3:
                        farmer_Service_obj.Delete_Farmer();
                        break;

                    case 4:
                        Console.WriteLine("\nDetails of all farmers:\n");

                        farmer_Service_obj.Display_All_Farmers(); 

                        Console.WriteLine("\nTotal farmer: " +
                            farmer_Service_obj.farmer_list_obj.Count);

                        break;

                    case 5:
                        farmer_Service_obj.search_by(); 
                        break;
                    case 6:
                        payment_Service_obj.Add_Payment();
                        break;
                    case 7:
                        payment_Service_obj.Update_Payment();
                        break;

                    case 8:
                        payment_Service_obj.Delete_Payment(); 
                        break;

                    case 9:
                        payment_Service_obj.GetByFarmerAndYear(); 
                        break;

                    case 10:
                        payment_Service_obj.GetTotal();
                        break;
                }
                Console.Write("\nDo you want to close (Press -> n): ");
                Choice = Console.ReadLine().ToLower();
                Console.Clear();
            } while (Choice != "n");






        }

    }
}