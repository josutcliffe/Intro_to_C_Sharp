// See https://aka.ms/new-console-template for more information
Console.WriteLine("Enter your birthday month as a number:");

int userMonth = Convert.ToInt32(Console.ReadLine());

switch (userMonth)
{
    case 12:
    case 1:
    case 2:
        Console.WriteLine("Summer");
        break;
    case 3:
    case 4:
    case 5:
        Console.WriteLine("Autumn");
        break;
    case 6:
    case 7:
    case 8:
        Console.WriteLine("Winter");
        break;
    case 9:
    case 10:
    case 11:
        Console.WriteLine("Spring");
        break;
}
