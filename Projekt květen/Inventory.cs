using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Projekt_květen2
{

    public class Product
    {
        public Product (string nazev, double cena) {
            Nazev = nazev;
            Cena = cena;
        }

        public string Nazev { get; set; }
        public double Cena { get; set; }


    }


    private static class Inventory
    {
        public static List<Product> Products { get; set; } = new List<Product>();
        
        public static int pocet { get; set; }

        public static void AddProduct(string nazev, double cena)
        {
            try
            {
                Products.Add(new Product(nazev, cena));
                pocet++;
                Console.WriteLine($"produkt {nazev} byl přidán");
                Console.ReadKey();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void RemoveProduct(string nazev)
        {
            int index = Products.IndexOf(Products.Find(p => p.Nazev == nazev));

            if (index == -1) throw new Exception();

            Products.RemoveAt(index);
            Console.WriteLine($"produkt {nazev} byl odebrán");
            Console.ReadKey();
        }
    }


    public static void Main()
    {


        while(true)
        {

            Console.Clear();
            Console.WriteLine("Zadej akci: (pridat, odebrat, zobrazit, konec)");
            string input = Console.ReadLine();
            switch(input)
            {
                case "pridat":
                    {
                        try
                        {
                            Console.WriteLine("Zadej název produktu");
                            string name = Console.ReadLine();
                            Console.WriteLine("Zadej cenu produktu");
                            double cena = double.Parse(Console.ReadLine());
                            Inventory.AddProduct(name, cena);
                        }
                        catch(Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                        }
                    } break;

                case "odebrat":
                    {
                        Console.WriteLine("zadej jméno produktu který chceš odebrat");
                        try
                        {
                            Inventory.RemoveProduct(Console.ReadLine());
                        } catch
                        {
                            Console.WriteLine("CHYBA");
                            Console.ReadKey();
                            continue;
                        }
                    }
                    break;

                case "zobrazit":
                    {
                        foreach (var product in Inventory.Products) 
                        { 
                            Console.WriteLine($"{product.Nazev}, {product.Cena}Kč");
                            
                        }
                        Console.ReadKey();
                    }
                    break;

                case "konec":
                    {
                        Console.WriteLine("Konec");
                        break;
                    }
                    break;

            }
        }   
    }
}
