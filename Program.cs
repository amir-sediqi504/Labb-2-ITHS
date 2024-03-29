﻿namespace Labb_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Kitchen k = new Kitchen();
            k.startList();
            k.val();
        }
    }

    class KitchenAppliance : IKitchenAppliance // typ av objekt i list
    {
        public string Type { get; set; }
        public string Brand { get; set; }
        public bool IsFunctioning { get; set; }

        public void Use() // dubblett i Kitchen klassen finns
        {

            if (IsFunctioning == true)
            {
                Console.WriteLine(Type + " används");
            } else
            {
                Console.WriteLine("trasig");
            }

        }
    }


    class Kitchen
    {

        List<string> fakeList = new List<string>();
        List<KitchenAppliance> kitchenAppliances = new List<KitchenAppliance>();

        bool valOpen = true;


        public void val()
        {
            while (valOpen)
            {
                Console.WriteLine("1. använd \n 2. lägg till\n 3. Lista alla köksapparater\n 4. ta bort köksapparat\n5. avsluta ");
                try
                {
                    var input = Convert.ToInt32(Console.ReadLine());
                    if (input == 1)
                    {
                        Use();

                    }
                    else if (input == 2)
                    {
                        AddItem();
                    }
                    else if (input == 3)
                    {
                        ShowAll();
                    }
                    else if (input == 4)
                    {
                        taBort();
                    }
                    else if (input == 5)
                    {
                        Environment.Exit(0);
                    }
                } catch
                {
                    Console.WriteLine("fel input, skriv bara in siffror som visas i konsolen");
                }
               
            }
        }

        public void defaultList()
        {
            KitchenAppliance mikro = new KitchenAppliance();
            mikro.Type = "mikro";
            mikro.Brand = "electroluxs";
            mikro.IsFunctioning = true;
            kitchenAppliances.Add(mikro);
        }

        public void Use()
        {
            try
            {
                Console.WriteLine("vilken köksapparat vill du använda?");
                ShowAll();
                int userInp = Convert.ToInt32(Console.ReadLine());
                if (kitchenAppliances[userInp - 1].IsFunctioning == true)
                {
                    Console.WriteLine(kitchenAppliances[userInp - 1].Type + " används");
                }
                else
                {
                    Console.WriteLine(kitchenAppliances[userInp - 1].Type + " är trasig");
                }
            }
            catch (Exception ex) 
            {
                Console.WriteLine("fel input inmatad, använd bara mellan de siffror som visas");
            }
            
            
        }

        public void taBort()
        {
            try
            {
                Console.WriteLine("lista: ");
                int i = 1;
                foreach (var item in kitchenAppliances)
                {
                    Console.WriteLine(i + ". " + item.Type);
                    i++;
                }
                int applianceToRemive = Convert.ToInt32(Console.ReadLine());
                kitchenAppliances.RemoveAt(applianceToRemive - 1);
                Console.WriteLine("borttagen");
            }
            catch
            {
                Console.WriteLine("Skriv endast in de siffror som visas i konsolen".ToUpper());
            }
            
        }



        public void AddItem()
        {
            KitchenAppliance kit = new KitchenAppliance();
            Console.WriteLine("typ att lägga till: ");
            string type = Console.ReadLine();
            Console.WriteLine("märke att lägga till: ");
            string brand = Console.ReadLine();
            Console.WriteLine("funkar den? ");
            bool funkar;
            string isFunc = Console.ReadLine();

            if (isFunc == "j")
            {
                funkar = true;
                kit.Type = type;
                kit.Brand = brand;
                kit.IsFunctioning = funkar;
                kit.Use();
                kitchenAppliances.Add(kit);
                foreach (var item in kitchenAppliances)
                {
                    Console.WriteLine(item.Type);
                }
            } else if (isFunc == "n")
            {
                funkar = false;
                kit.Type = type;
                kit.Brand = brand;
                kit.IsFunctioning = funkar;
                kit.Use();
                kitchenAppliances.Add(kit);
                foreach (var item in kitchenAppliances)
                {
                    Console.WriteLine(item.Type);
                }
            }


        }
        public void ShowAll()
        {
            int num = 1;

            fakeList.Add("thing");
            KitchenAppliance kk = new KitchenAppliance();
            kk.Type = "våffeljärn";
            kk.Brand = "Siemens";
            kk.IsFunctioning = true;
            kitchenAppliances.Add(kk);
            string braSkickEllerEj;
            if (kk.IsFunctioning)
            {
                braSkickEllerEj = "bra skick";
            } else
            {
                braSkickEllerEj = "dåligt skick";
            }
            
            foreach (var item in kitchenAppliances)
            {
                Console.WriteLine(num + " " + item.Type + " av märke " + item.Brand + " och den är i " + braSkickEllerEj);
                num++;
                
            }
        }
        public void startList()
        {
            KitchenAppliance kk = new KitchenAppliance();
            kk.Type = "våffeljärn";
            kk.Brand = "Siemens";
            kk.IsFunctioning = true;
            kitchenAppliances.Add(kk);
        }

    }
    // l   
}