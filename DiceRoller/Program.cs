using System.Collections;

Console.WriteLine("Welcome to the Dice Roller!");


Console.WriteLine("How many sides should each die have?");
int n = -1;
bool runProgram = true;
    while (!int.TryParse(Console.ReadLine(), out n) || n <= 0) //while false or while negative
    {
        Console.WriteLine("Invalid input, try again");
    }
    Console.WriteLine($"You've chosen to have {n} sided die.");
    int rollNumber = 1;
while (runProgram)
{
    int rollAmount = 0;
    int total = 0;
    List<int> dice = new List<int>();

    while (rollAmount < 2)
    {
        int roll = GetRandom(n);
        dice.Add(roll);
        total += roll;
        rollAmount++;
    }
    int firstRoll = dice[0];
    int secondRoll = dice[1];
    Console.WriteLine($"Roll {rollNumber}: you rolled a {firstRoll} and a {secondRoll} and scored {total}!");
    while (n == 6)
    {
        Console.WriteLine(RollCombos(firstRoll, secondRoll));
        break;
        Console.WriteLine(WinCombos(firstRoll, secondRoll));
        break;
    }
    rollNumber++;
    runProgram = GetContinue();
}






//methods
static int GetRandom(int x)
{
    Random rollRandom = new Random();
    int roll = rollRandom.Next(1, x + 1);
    return roll;
}

static string RollCombos(int x, int y)
{
    if (x == 1 && y == 1)
    {
        return "Snake Eyes!";
    }
    else if (x + y == 3)
    {
        return "Ace Deuce!";
    }
    else if (x == 6 && y == 6)
    {
        return "Box Cars!";
    }
    else
    {
        return "";
    }
}

static string WinCombos(int x, int y)
{
    if (x + y == 7 || x + y == 11)
    {
        return "Win!";
    }
    else if (x + y == 2 || x + y == 3 || x + y == 12)
    {
        return "Craps!";
    }
    else
    {
        return "";
    }
}

static bool GetContinue()
{
    while (true)
    {

        Console.WriteLine("Would you like to roll again? (y/n)");
        string answer = Console.ReadLine();
        if (answer == "y" || answer == "yes")
        {
            return true;
        }
        else if (answer == "n" || answer == "no")
        {
            Console.WriteLine("Thank you for playing!");
            return false;
        }
        else
        {
            Console.WriteLine("Please enter a valid answer.");
            continue;
        }
    }
}