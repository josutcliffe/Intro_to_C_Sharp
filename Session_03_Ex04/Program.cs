// See https://aka.ms/new-console-template for more information
Console.WriteLine("Please enter a number from 0-12:");

int number = Convert.ToInt32(Console.ReadLine());

if (number >= 0 && number <= 12)
    {
        Console.WriteLine("You selected the number " + number + ".");
        for (int i = 0; i <= 12; i++)
    {
        Console.WriteLine(number + " x " + i + " = " + (number * i));
    }
}
else
{
    Console.WriteLine("Please select a number from 0-12.");
    }