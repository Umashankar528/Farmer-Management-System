using Project;
using System;
using System.Collections.Generic;
using System.Linq;

class SchemePayment
{
    public int PaymentId;
    public int FarmerId;
    public int Year;
    public int InstallmentNo = 1;
    public decimal Amount;
    public DateTime PaymentDate;
    public string Remarks;
}

class Payment_Services
{
    public List<SchemePayment> payment_list_obj = new List<SchemePayment>();
    public List<Farmer> farmer_list_obj;

    public Payment_Services(List<Farmer> farmers)
    {
        farmer_list_obj = farmers;
    }

    internal void Add_Payment()
    {
        try
        {
            SchemePayment p = new SchemePayment();

            Console.Write("Enter Payment ID: ");
            p.PaymentId = int.Parse(Console.ReadLine());
            bool exists = false;
            foreach (SchemePayment sp in payment_list_obj)
            {
                if (p.PaymentId == sp.PaymentId)
                {
                    exists = true;
                    break;
                }
            }

            if (exists == true)
            {
                Console.WriteLine("Payment ID already exists");
            }
            else
            {
                Console.Write("Enter Farmer ID: ");
                p.FarmerId = int.Parse(Console.ReadLine());
                bool found = false;
                foreach (Farmer f in farmer_list_obj)
                {
                    if (f.ID == p.FarmerId)
                    {
                        found = true;
                        break;
                    }
                }

                if (found == false)
                {
                    Console.WriteLine("Farmer ID not found");
                }
                else
                {
                    Console.Write("Enter Year: ");
                    p.Year = int.Parse(Console.ReadLine());
                    Console.Write("Enter Installment Number (1-3): ");
                    p.InstallmentNo = int.Parse(Console.ReadLine());
                    if (p.InstallmentNo < 1 || p.InstallmentNo > 3)
                    {
                        Console.WriteLine("Invalid installment number");
                    }
                    else
                    {
                        bool installmentExists = false;
                        foreach (SchemePayment sp in payment_list_obj)
                        {
                            if (sp.FarmerId == p.FarmerId &&
                                sp.Year == p.Year &&
                                sp.InstallmentNo == p.InstallmentNo)
                            {
                                installmentExists = true;
                                break;
                            }
                        }

                        if (installmentExists == true)
                        {
                            Console.WriteLine("Installment already exists");
                        }
                        else
                        {
                            Console.Write("Enter Amount: ");
                            p.Amount = decimal.Parse(Console.ReadLine());
                            if (p.Amount < 0)
                            {
                                Console.WriteLine("Amount cannot be negative");
                            }
                            else
                            {
                                Console.Write("Enter Payment Date: ");
                                p.PaymentDate = DateTime.Parse(Console.ReadLine());
                                Console.Write("Enter Remarks: ");
                                p.Remarks = Console.ReadLine();
                                payment_list_obj.Add(p);
                                Console.WriteLine("Payment added successfully");
                            }
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error :- " + e.Message);
        }
    }

    internal void Update_Payment()
    {
        try
        {
            Console.Write("Enter Payment ID: ");
            int id = int.Parse(Console.ReadLine());
            int index = -1;
            for (int i = 0; i < payment_list_obj.Count; i++)
            {
                if (payment_list_obj[i].PaymentId == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Payment ID not found");
            }
            else
            {
                SchemePayment p = payment_list_obj[index];
                Console.Write("Enter new year: ");
                int year = int.Parse(Console.ReadLine());
                Console.Write("Enter new installment number: ");
                int installmentNo = int.Parse(Console.ReadLine());
                if (installmentNo < 1 || installmentNo > 3)
                {
                    Console.WriteLine("Invalid installment number");
                }
                else
                {
                    bool exists = false;
                    foreach (SchemePayment sp in payment_list_obj)
                    {
                        if (sp.PaymentId != id && sp.FarmerId == p.FarmerId &&
                            sp.Year == year && sp.InstallmentNo == installmentNo)
                        {
                            exists = true;
                            break;
                        }
                    }

                    if (exists == true)
                    {
                        Console.WriteLine("Installment already exists");
                    }
                    else
                    {
                        Console.Write("Enter new amount: ");
                        decimal amount = decimal.Parse(Console.ReadLine());
                        if (amount < 0)
                        {
                            Console.WriteLine("Amount cannot be negative");
                        }
                        else
                        {
                            Console.Write("Enter new payment date: ");
                            DateTime date = DateTime.Parse(Console.ReadLine());
                            p.PaymentDate = date;
                            Console.Write("Enter new remarks: ");
                            string remarks = Console.ReadLine();
                            p.Year = year;
                            p.InstallmentNo = installmentNo;
                            p.Amount = amount;
                            p.PaymentDate = date;
                            p.Remarks = remarks;
                            Console.WriteLine("Payment updated successfully");
                        }
                    }
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error :- " + e.Message);
        }
    }

    internal void Delete_Payment()
    {
        try
        {
            Console.Write("Enter Payment ID: ");
            int id = int.Parse(Console.ReadLine());
            int index = -1;
            for (int i = 0; i < payment_list_obj.Count; i++)
            {
                if (payment_list_obj[i].PaymentId == id)
                {
                    index = i;
                    break;
                }
            }

            if (index == -1)
            {
                Console.WriteLine("Payment not found");
            }
            else
            {
                Console.Write("Do you want to delete payment (y/n): ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    payment_list_obj.RemoveAt(index);
                    Console.WriteLine("Payment deleted successfully");
                }
                else
                {
                    Console.WriteLine("Delete operation cancelled");
                }
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error :- " + e.Message);
        }
    }

    internal void GetByFarmerAndYear()
    {
        try
        {
            Console.Write("Enter Farmer ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Year: ");
            int year = int.Parse(Console.ReadLine());
            var res = from p in payment_list_obj where p.FarmerId == id && p.Year == year orderby p.InstallmentNo select p;
            bool found = false;
            foreach (SchemePayment p in res)
            {
                found = true;
                Console.WriteLine("Payment ID: " + p.PaymentId);
                Console.WriteLine("Farmer ID: " + p.FarmerId);
                Console.WriteLine("Year: " + p.Year);
                Console.WriteLine("Installment: " + p.InstallmentNo);
                Console.WriteLine("Amount: " + p.Amount);
                Console.WriteLine("Payment Date: " + p.PaymentDate.ToString("dd/MM/yyyy"));
                Console.WriteLine("Remarks: " + p.Remarks);
                Console.WriteLine("----------------------------------------");
            }

            if (found == false)
            {
                Console.WriteLine("No payment records found");
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error :- " + e.Message);
        }
    }

    internal void GetTotal()
    {
        try
        {
            Console.Write("Enter Farmer ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Enter Year: ");
            int year = int.Parse(Console.ReadLine());
            bool found = false;
            foreach (Farmer f in farmer_list_obj)
            {
                if (f.ID == id)
                {
                    found = true;
                    break;
                }
            }

            if (found == false)
            {
                Console.WriteLine("Farmer ID not found");
            }
            else
            {
                decimal total = (from p in payment_list_obj where p.FarmerId == id && p.Year == year select p.Amount).Sum();
                Console.WriteLine("Total received amount: " + total);
            }
        }
        catch (Exception e)
        {
            Console.WriteLine("Error :- " + e.Message);
        }
    }
}
