// Type ysome text and press enter
Console.WriteLine("Enter some text:");

// Create a string variable and get user input from the keyboard and store it in the variable which wil be returned later
string UserInputText = Console.ReadLine();

// Print the value of the variable (UserInputText), which will display the input value
Console.WriteLine("You entered: \"" + UserInputText +"\"");
if  (UserInputText == "wow")
{
    Console.WriteLine("Yes very cool secret!");

    // Type ysome text and press enter
    Console.WriteLine("Enter some text again:");

    // Create a string variable and get user input from the keyboard and store it in the variable which wil be returned later
    string UserInputTextt = Console.ReadLine();

    // Print the value of the variable (UserInputText), which will display the input value
    Console.WriteLine("You entered: \"" + UserInputTextt + ",\" this was your seond input");
}
