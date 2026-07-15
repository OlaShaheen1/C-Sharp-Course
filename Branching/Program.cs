using System;

// ==========================================
// REQUIREMENT 1: The mandatory welcome message
// ==========================================
Console.ForegroundColor = ConsoleColor.Cyan;
Console.WriteLine("Welcome to Package Express. Please follow the instructions below.");
Console.ResetColor();
Console.WriteLine(new string('-', 65));

// --- 1. Weight Input & Validation ---
double weight = GetSafeDoubleInput("Please enter the package weight (lbs):");

if (weight > 50)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nPackage too heavy to be shipped via Package Express. Have a good day.");
    Console.ResetColor();
    return; // Safe termination
}

// --- 2. Dimensions Input ---
Console.WriteLine("\nPlease enter the package dimensions:");
double width = GetSafeDoubleInput("  -> Width (inches):");
double height = GetSafeDoubleInput("  -> Height (inches):");
double length = GetSafeDoubleInput("  -> Length (inches):");

// --- 3. Dimension Check ---
double dimensionTotal = width + height + length;

if (dimensionTotal > 50)
{
    Console.ForegroundColor = ConsoleColor.Red;
    Console.WriteLine("\nPackage too big to be shipped via Package Express.");
    Console.ResetColor();
    return; // Safe termination
}

// --- 4. Quote Calculation ---
// Formula: (Width * Height * Length * Weight) / 100
double volume = width * height * length;
double shippingQuote = (volume * weight) / 100;

// --- 5. Output Results ---
Console.WriteLine(new string('-', 65));
Console.ForegroundColor = ConsoleColor.Green;
Console.WriteLine($"Your estimated total for shipping this package is: ${shippingQuote:F2}");
Console.ResetColor();
Console.WriteLine("Thank you!");
Console.WriteLine(new string('-', 65));


// ==========================================
// HELPER METHOD: Prevents crashes on bad input
// ==========================================
static double GetSafeDoubleInput(string prompt)
{
    double value;
    while (true)
    {
        Console.Write($"{prompt} ");
        string input = Console.ReadLine();
        
        // TryParse ensures that entering "abc" won't crash the program
        if (double.TryParse(input, out value) && value > 0)
        {
            return value;
        }
        
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine("   [!] Invalid input. Please enter a valid positive number.");
        Console.ResetColor();
    }
}
