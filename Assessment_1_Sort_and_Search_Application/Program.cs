// See https://aka.ms/new-console-template for more information
//====================================
//Student: Joshua Sutcliffe
//Student ID: 20107131
//Student email: 20107131@tafe.wa.edu.au
//====================================

int totalNumbers = 5;
int rangeMin = 1;
int rangeMax = 20;

int[] userNumbers = new int[totalNumbers];
int[] randomNumbers = new int[totalNumbers];

//int [] defaultNumberArray = new int[5] {1, 3, 6, 7, 9}; //for use when testing application

void GetUserNumbers()
{
    Console.WriteLine("Welcome to The Lottery Game");
    Console.WriteLine("Please enter " + totalNumbers + " numbers between " + rangeMin + " and " + rangeMax + ".");

    for (int i = 0; i < userNumbers.Length; i++)
    {
        Console.WriteLine($"Enter value " + i + ":");
        string userInput = Console.ReadLine();
        if (!int.TryParse(userInput, out userNumbers[i]) || userNumbers[i] < rangeMin || userNumbers[i] > rangeMax)
        {
            Console.WriteLine("You did not select a valid number. Please try again.");  //user input error checking
            i--;
        }
        else
        {
            bool repeatedNumber = false;  //checking for repeated numbers
            for (int j = 0; j < i; j++)
            {
                if (userNumbers[j] == userNumbers[i])
                {
                    repeatedNumber = true;
                    break;
                }
            }
            if (repeatedNumber)
            {
                Console.WriteLine("You have already selected this number. Please choose a different number.");
                i--;
            }
        }
    }
}

GetUserNumbers();


void PrintArray(int[] arrayToPrint) //Function to print array values
{
    for (int i = 0; i < arrayToPrint.Length; i++)
    {
        if (i == arrayToPrint.Length - 1)
        {
            Console.WriteLine(arrayToPrint[i] + ".");
            continue;
        }
        Console.Write(arrayToPrint[i] + ", ");
    }
}

//PrintArray(userNumbers);
Array.Sort(userNumbers);
Console.WriteLine("You chose the following numbers:");
PrintArray(userNumbers);



void RandomArrayCreate() //Random number array creation
{
    for (int i = 0; i < randomNumbers.Length; i++)
    {
        // TODO: edit/update to make sure no numbers are repeated in the randomNumbers array
        Random random = new Random();
        randomNumbers[i] = random.Next(rangeMin, rangeMax + 1);
    }
}

RandomArrayCreate();


Array.Sort(randomNumbers);
Console.WriteLine("The random lottery numbers were:");
PrintArray(randomNumbers);




void LinearSearch(int[] firstArray, int[] secondArray)  //Use a linear search to compare the values between two arrays.
{
    if (firstArray.Length == secondArray.Length)
    {
        for (int i = 0; i < firstArray.Length; i++)
        {
            bool correctNumber = false;
            for (int j = 0; j < secondArray.Length; j++)
            {
                if (firstArray[i] == secondArray[j])
                {
                    Console.WriteLine("Your guessed number " + firstArray[i] + " is a winning lottery number.");
                    correctNumber = true;
                    break;
                }
                else
                {
                    if (firstArray[i] != secondArray[j])
                    {
                        Console.WriteLine("Your guessed number " + firstArray[i] + " is not a winning lottery number.");
                    }
                }
            }
        }
    }
}

LinearSearch(userNumbers, randomNumbers);

int.Parse(Console.ReadLine());  //force the terminal to stay open


//int BinarySearch(int[] arrayToSearch, int value, int low, int high)
//{
//    if (high >= low)
//    {
//        int mid = (high - low) / 2;  //Get mid value

//        if (arrayToSearch[mid] == value) return mid;  //Checks if value equals mid

//        if (arrayToSearch[mid] > value) return BinarySearch(arrayToSearch, value, low, mid - 1);  //Determine is value is lower or higher than mid in the sorted array

//        Console.WriteLine("test");
//        return BinarySearch(arrayToSearch, value, mid + 1, high);
//    }
//    return -1;  // -1 in C# means we have not found the values it a non index number.
//}

//BinarySearch(GetUserNumbers, 3, 0, defaultNumberArray.Length - 1);

//int.Parse(Console.ReadLine());  //force the terminal to stay open
