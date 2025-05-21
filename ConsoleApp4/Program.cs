using System;
//Uppgift 1: Klasser som borde vara med är anställd och personalregister.
//Uppgift 2: Anställd borde ha string Namn, decimal Lön. Decimal i detta fallet eftersom man vill vara specifik med lön, man kan typ ha double också.

internal class Program
{
    static void Main(string[] args)
    {
        var register = new PersonalRegister(); // Skapar ett nytt personalregister för att lagra anställda

        while (true) // Evig loop som gör att vi kan fortsätta använda programmet tills vi väljer att avsluta
        {
            Console.WriteLine("1. Lägg till anställd");
            Console.WriteLine("2. Skriv ut personalregister");
            Console.WriteLine("3. Avsluta");
            Console.Write("Välj: ");
            var val = Console.ReadLine(); // Läser in användarens val som text

            if (val == "1") // Om användaren valt 1, alltså lägga till en anställd
            {
                Console.Write("Namn: "); // Ber användaren att ange namn på den anställde
                var namn = Console.ReadLine(); // Läser in namnet som text

                Console.Write("Lön: "); 
                if (decimal.TryParse(Console.ReadLine(), out decimal lön)) // Försöker att läsa in lönen som decimal. Out används för att skicka tillbaka värdet till variabeln lön. TryParse konverterar sträng till decimal och returnerar true om det lyckas.
                {
                    register.Add(namn, lön); // Lägger till den anställde i registret
                }
                else
                {
                    Console.WriteLine("Felaktigt löneformat.");
                }
            }
            else if (val == "2")
            {
                register.SkrivUt(); // Anropar metod som skriver ut alla anställda
            }
            else if (val == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Fel val, försök igen."); // Om användaren gör ett ogiltigt val
            }
        }
    }
}

class Anställd
{
    public string Namn; // Namn på den anställde. Public gör den tillgänglig för andra klasser
    public decimal Lön; // Lön på den anställde

    public Anställd(string namn, decimal lön) // tar emot namn och lön som parametrar och tilldelar dem till de lokala variablerna.
    {
        Namn = namn; // Tilldelar namn till den lokala variabeln
        Lön = lön;
    }
}

class PersonalRegister
{
    List<Anställd> anställda = new List<Anställd>(); // Lista som håller alla anställda

    public void Add(string namn, decimal lön) // Metod för att lägga till en ny anställd i listan
    {
        anställda.Add(new Anställd(namn, lön)); // Skapar en ny anställd och lägger till i listan
    }

    public void SkrivUt() //Skriver ut alla anställda i konsolen
    {
        Console.WriteLine("\nPersonalregister:");
        foreach (var a in anställda) // Loopar igenom alla anställda i listan
            Console.WriteLine($"Namn: {a.Namn}, Lön: {a.Lön} kr");
    }
}
