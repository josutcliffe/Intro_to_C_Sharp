// See https://aka.ms/new-console-template for more information
//====================================
//Student: Joshua Sutcliffe
//Student ID: 20107131
//Student email: 20107131@tafe.wa.edu.au
//====================================

int totalNumbers = 5;
int rangeMin = 0;
int rangeMax = 20;

int[] userNumbers = new int[totalNumbers];
int[] randomNumbers = new int[totalNumbers];

// int [] defaultNumberArray = net int[3] {3, 6, 9}; //for use when testing application

void GetUserNumbers()
{
    Console.WriteLine("Welcome to The Lottery Game");
    Console.WriteLine("Please enter " + totalNumbers + " numbers between " + rangeMin + " and " + rangeMax + ".");

    for (int i = 0; i < userNumbers.Length; i++)
    {
        Console.WriteLine($"Enter Value " + i + ":");
        string userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out userNumbers[i]) || userNumbers[i] < rangeMin || userNumbers[i] > rangeMax)
        {
            //user input error checking
            Console.WriteLine("You did not select a valid number. Please try again.");
            i--;
        }
    }
    Console.WriteLine(userNumbers);
}

GetUserNumbers();

void PrintArray(int[] array)
{
    for (int i = 0; i < array.Length; i++)
    {
        if (i == array.Length - 1)
        {
            Console.WriteLine(array[i] + ".");
            continue;
        }
        Console.Write(array[i] + ", ");
    }
}

PrintArray(userNumbers);


//random array creation
for (int i = 0; i < randomNumbers.Length; i++)
{
    Random random = new Random();
    randomNumbers[i] = random.Next(rangeMin, rangeMax + 1);
}

PrintArray(randomNumbers);

int.Parse(Console.ReadLine());  //force the terminal to stay open


//using System;

//class Program
//{
//    static void Main()
//    {
//        // Set the number of elements in the arrays
//        int arraySize = 10;

//        // Set the range of random numbers
//        int minValue = 1;
//        int maxValue = 101;

//        // Prompt user to enter a list of numbers
//        int[] userNumbers;
//        while (true)
//        {
//            Console.WriteLine("Enter a list of " + arraySize + " numbers separated by spaces: ");
//            string input = Console.ReadLine();
//            userNumbers = Array.ConvertAll(input.Split(' '), int.Parse);

//            if (userNumbers.Length == arraySize)
//                break;

//            Console.WriteLine("Warning: You entered fewer than " + arraySize + " numbers. Please try again.");
//        }

//        // Sort the userNumbers array
//        Array.Sort(userNumbers);

//        // Generate a random list of numbers
//        Random rand = new Random();
//        int[] randomNumbers = new int[arraySize];
//        for (int i = 0; i < randomNumbers.Length; i++)
//            randomNumbers[i] = rand.Next(minValue, maxValue);

//        // Sort the randomNumbers array
//        Array.Sort(randomNumbers);

//        // Print the randomNumbers array
//        Console.WriteLine("Random numbers: " + string.Join(" ", randomNumbers));

//        // Compare the two arrays using binary search
//        bool areEqual = CompareArrays(userNumbers, randomNumbers);
//        Console.WriteLine("The two arrays are " + (areEqual ? "equal" : "not equal"));
//    }

//    static bool CompareArrays(int[] array1, int[] array2)
//    {
//        if (array1.Length != array2.Length)
//            return false;

//        for (int i = 0; i < array1.Length; i++)
//            if (Array.BinarySearch(array2, array1[i]) < 0)
//                return false;

//        return true;
//    }
//}