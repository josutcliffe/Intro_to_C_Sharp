// See https://aka.ms/new-console-template for more information
//====================================
//Student: Joshua Sutcliffe
//Student ID: 20107131
//Student email: 20107131@tafe.wa.edu.au
//====================================

using System.Runtime.InteropServices;
using System.Threading.Tasks.Sources;

int totalNumbers = 10;
int rangeMin = 1;
int rangeMax = 100;

int[] userNumbers = new int[totalNumbers];
int[] randomNumbers = new int[totalNumbers];

//int [] defaultNumberArray = new int[5] {1, 3, 6, 7, 9}; //for use when testing application

void GetUserNumbers()
{
    Console.WriteLine("Welcome to The Lottery Game");
    Console.WriteLine("Please enter " + totalNumbers + " numbers between " + rangeMin + " and " + rangeMax + ".");

    for (int i = 0; i < userNumbers.Length; i++)
    {
        Console.WriteLine($"Enter value " + (i + 1) + ":");
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



void RandomArrayCreate() //Random number array creation
{
    for (int i = 0; i < randomNumbers.Length; i++)
    {
        // TODO: edit/update to make sure no numbers are repeated in the randomNumbers array
        Random random = new Random();
        randomNumbers[i] = random.Next(rangeMin, rangeMax + 1);
    }
}



void LinearSearch(int[] firstArray, int[] secondArray)  //Use a linear search to compare the values between two arrays.
{
    Console.WriteLine();
    Console.WriteLine("Performing linear search of user numbers against lottery numbers.");
    for (int i = 0; i < firstArray.Length; i++)
    {
        bool correctNumber = false;
        for (int j = 0; j < secondArray.Length; j++)
        {
            if (firstArray[i] == secondArray[j])
            {
                Console.WriteLine("Your guessed number, " + firstArray[i] + " is a winning lottery number.");
                correctNumber = true;
                break;
            }
        }
        if (!correctNumber)
            Console.WriteLine("Your guessed number, {0}, was not a lottery number.", firstArray[i]);
    }
}




int BinarySearch(int[] userNumberValue, int[] randomNumberValue, int low, int high)
{
    Console.WriteLine();
    Console.WriteLine("Performing binary search of user numbers against lottery numbers.");

    int score = 0;  // counter variable, to track how many numbers the user guesses correctly
    for (int i = 0; i < randomNumberValue.Length; i++)
    {
        low = 0;
        high = randomNumberValue.Length - 1;
        int valueToCheck = userNumberValue[i];
        bool correctNumber = false;
        while (high >= low)
        {
            int mid = low + (high - low) / 2;
            
            // print statements to check binary search is working correctly
            //Console.WriteLine("User number to check: {0}", valueToCheck);
            //Console.WriteLine("Low value: " + low);
            //Console.WriteLine("High value: " + high);
            //Console.WriteLine("Mid value: " + mid);

            if (randomNumberValue[mid] == valueToCheck)
            {
                Console.WriteLine("Your guessed number, {0}, was a lottery number (and is found at index {1}).", valueToCheck, mid);
                correctNumber = true;
                score++;  // if user guessed correctly, add to counter
                break;
            }

            if (randomNumberValue[mid] > valueToCheck)
                high = mid - 1;
            else
                low = mid + 1;
        }
        if (!correctNumber)
        {
            Console.WriteLine("Your guessed number, {0}, was not a lottery number.", valueToCheck);
        }
    }
    Console.WriteLine("You correctly selected {0} of the {1} lottery numbers.", score, randomNumberValue.Length);  // give user feedback on how many numbers they guessed correctly.
    return score;
}



void PlayAgain()
{
    Console.WriteLine();
    Console.WriteLine("That is the end of the Lottery Game. Would you like to play again?");
    Console.WriteLine("Press 'Y' to play again, or 'N' to quit.");
    string userInput = Console.ReadLine();
    if (userInput.ToUpper() == "Y")
    {
        GameLoop();
    }
    else if (userInput.ToUpper() == "N")
    {
        Console.WriteLine("Thank you for playing the Lottery Game. Please play again soon!");
        Thread.Sleep(3000);  // delay to keep console open so user can read message
        System.Environment.Exit(0);
    }
}


void GameLoop()  // Wrapper to put all the functions into one, allowing a game loop.
{
    GetUserNumbers();
    Array.Sort(userNumbers);
    Console.WriteLine("You chose the following numbers:");
    PrintArray(userNumbers);
    RandomArrayCreate();
    Array.Sort(randomNumbers);
    Console.WriteLine("The random lottery numbers were:");
    PrintArray(randomNumbers);
    LinearSearch(userNumbers, randomNumbers);
    BinarySearch(userNumbers, randomNumbers, rangeMin, randomNumbers.Length - 1);
    PlayAgain();
}

GameLoop();
