// See https://aka.ms/new-console-template for more information
//====================================
//Student: Joshua Sutcliffe
//Student ID: 20107131
//Student email: 20107131@tafe.wa.edu.au
//====================================

using System.Threading.Tasks.Sources;

int totalNumbers = 10;
int rangeMin = 1;
int rangeMax = 50;

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
        if (!int.TryParse(userInput, out userNumbers[i]) || userNumbers[i] < rangeMin || userNumbers[i] > rangeMax) //user input error checking
        {
            Console.WriteLine("You did not select a valid number. Please try again.");  
            i--;
        }
        else
        {
            bool repeatedNumber = false;  //check for repeated numbers
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




//void LinearSearch(int[] firstArray, int[] secondArray)  //Use a linear search to compare the values between two arrays.
//{
      //Console.WriteLine("Performing linear search of user numbers against lottery numbers.");
//    if (firstArray.Length == secondArray.Length)
//    {
//        for (int i = 0; i < firstArray.Length; i++)
//        {
//            bool correctNumber = false;
//            for (int j = 0; j < secondArray.Length; j++)
//            {
//                if (firstArray[i] == secondArray[j])
//                {
//                    Console.WriteLine("Your guessed number " + firstArray[i] + " is a winning lottery number.");
//                    correctNumber = true;
//                    break;
//                }
//                else
//                {
//                    if (firstArray[i] != secondArray[j])
//                    {
//                        Console.WriteLine("Your guessed number " + firstArray[i] + " is not a winning lottery number.");
//                    }
//                }
//            }
//        }
//    }
//}

//LinearSearch(userNumbers, randomNumbers);

//int.Parse(Console.ReadLine());  //force the terminal to stay open


int BinarySearch(int[] userNumberValue, int[] randomNumberValue, int low, int high)
{
    Console.WriteLine("Performing binary search of user numbers against lottery numbers.");

    int score = 0;
    for (int i = 0; i < randomNumberValue.Length; i++)
    {
        low = 0;
        high = randomNumberValue.Length - 1;
        int valueToCheck = userNumberValue[i];
        bool found = false;
        while (high >= low)
        {
            int mid = low + (high - low) / 2;
            Console.WriteLine("Value to check: {0}", valueToCheck);
            Console.WriteLine("Binary search low value: " + low);
            Console.WriteLine("Binary search mid value: " + mid);
            Console.WriteLine("Binary search high value: " + high);

            if (randomNumberValue[mid] == valueToCheck)
            {
                Console.WriteLine("Your guessed number, {0}, was a lottery number (and is found at index {1}).", valueToCheck, mid);
                found = true;
                score++;
                break;
            }

            if (randomNumberValue[mid] > valueToCheck)
                high = mid - 1;
            else
                low = mid + 1;
        }
        if (!found)
        {
            Console.WriteLine("Your guessed number, {0}, was not a lottery number.", valueToCheck);
        }
    }
    Console.WriteLine("You correctly selected {0} of the {1} lottery numbers.", score, randomNumberValue.Length);
    return score;
}

BinarySearch(userNumbers, randomNumbers, 0, randomNumbers.Length - 1);


// TODO: ability for user to play again from the beginning
//void PlayAgain()
//{
//    Console.WriteLine("That is the end of the Lottery Game. Would you like to play again?");
//    Console.WriteLine("Press 'Y' to play again, or 'N' to quit.");
//    if (Console.ReadLine().)
//    string userInput = Console.ReadLine();

//}


int.Parse(Console.ReadLine());  //force the terminal to stay open