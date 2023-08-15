// See https://aka.ms/new-console-template for more information

//Create a mathematical function that takes two parameters that are numeric types
//and performs a basic arithmetic function on them and prints the result to the console.
//Try addition and multiplication.

int mathAddFunction(int a, int b)
{ return a + b;
}

int resultAdd = mathAddFunction(5, 5);

Console.WriteLine("The result of adding " + 5 + " and " + 5 + " is: " + resultAdd);

int mathMultiplyFunction(int a, int b)
{
    return a * b;
}

int resultMultiply = mathMultiplyFunction(5, 5);

Console.WriteLine("The result of multiplying " + 5 + " and " + 5 + " is: " + resultMultiply);