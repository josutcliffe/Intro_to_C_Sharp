// See https://aka.ms/new-console-template for more information
string lastName = "Sutcliffe";
int age = 37;
string theirLastName = "Jones";
int theirAge = 32;
int ageDifference = (age - theirAge);

if (age > theirAge) {
    Console.WriteLine("I am older than them.");
    Console.WriteLine("The age difference is " + ageDifference + " years.");
} 
else {
    Console.WriteLine("They are older than me.");
}

if (lastName.Length > theirLastName.Length) {
    Console.WriteLine("My last name is longer than theirs.");
} 
else {
    Console.WriteLine("Their last name is longer than mine.");
}
