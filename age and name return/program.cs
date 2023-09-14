string? Age;
string? FirstName;

Console.WriteLine("Enter your name:");
FirstName = Console.ReadLine();
Console.WriteLine("Enter your age:");
Age = Console.ReadLine();


Console.WriteLine($"Your name is: \"{FirstName}\", you are {Age} years old");
