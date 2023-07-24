using System.ComponentModel.Design;
using static Program;

internal class Program
{
    public enum Plays
    {
        Rock,
        Paper,
        Scissors
    }

    private static void Main(string[] args)
    {

        Console.WriteLine("Hello, and welcome to the game Rock, Paper, Scissors. You will be compeating against the computer. Would you like to go first or second? Select 1 to go first, or 2 to go second.");
        int timeBetweenGos = 2000;

        ChooseGo(timeBetweenGos);
    }

    static void ChooseGo(int milliseconds)
    {
        int firstOrSecondSelection = int.Parse(Console.ReadLine());

        while (firstOrSecondSelection > 2)
        {
            Console.WriteLine("Please choose a valid option 1 or 2.");
            ChooseGo(milliseconds);
        }

        if (firstOrSecondSelection == 1)
        {
            Console.WriteLine("You will go first, Lets play!");
            Thread.Sleep(milliseconds);
            PlayerChoosesAPlay(milliseconds);

        }
        else if (firstOrSecondSelection == 2)
        {
            Console.WriteLine("The computer will go first, Lets Play!");
            Thread.Sleep(milliseconds);
            ComputerChoosesAPLay(0, milliseconds, true);
        } 
    }
    static void PlayerChoosesAPlay(int milliseconds)
    {
        Console.WriteLine("Please choose a play out of the following: 1.Rock, 2.Paper or 3.Scissors");
        int selection = int.Parse(Console.ReadLine());

        while (selection > 3)
        {
            Console.WriteLine("Please choose a valid option 1, 2 or 3.");
            PlayerChoosesAPlay(milliseconds);

        }
            if (selection == 1)
            {
                Console.WriteLine($"You selected: {Plays.Rock}");
                Thread.Sleep(milliseconds);
                ComputerChoosesAPLay(selection, milliseconds, false);
            }
            else if(selection == 2) 
            {
                Console.WriteLine($"You selected: {Plays.Paper}");
                Thread.Sleep(milliseconds);
                ComputerChoosesAPLay(selection, milliseconds, false);
            }
            else if(selection == 3)
            {
                Console.WriteLine($"You selected: {Plays.Scissors}");
                Thread.Sleep(milliseconds);
                ComputerChoosesAPLay(selection, milliseconds, false);
            }

    }

    static void ComputerChoosesAPLay(int selection, int milliseconds, bool isItPlayersTurn)
    {
        Array values = Enum.GetValues(typeof(Plays));
        Random random = new Random();
        Plays randomPlay = (Plays)values.GetValue(random.Next(values.Length));
        Console.WriteLine($"The computers has chosen a play...");
        Thread.Sleep(milliseconds);
        if(isItPlayersTurn == true)
        {
            Console.WriteLine("Please choose a play, 1.Rock, 2.Paper or 3.Scissors");
            Thread.Sleep(milliseconds);
            int selectionOne = int.Parse(Console.ReadLine());
            WhoWins(selectionOne, randomPlay, milliseconds, true);
            Thread.Sleep(milliseconds);

        }
        else
        {
          Thread.Sleep(milliseconds);
          WhoWins(selection, randomPlay, milliseconds, false);
        }

    }

    static void WhoWins(int play, Plays randomPlay, int milliseconds, bool showPlayerValue)
    {
        string playedPlay = "";
        switch (play)
        {
            case 1:
                playedPlay = "Rock";
                break;
            case 2:
                playedPlay = "Paper";
                break;
            case 3:
                playedPlay = "Scissors";
                break;
        }

        Console.WriteLine($"The computer has chosen {randomPlay}...");
        Thread.Sleep(milliseconds);
        if(showPlayerValue == true)
        {
            Console.WriteLine($"You have chosen {playedPlay}...");
            Thread.Sleep(milliseconds);
        }

        switch (play)
        {
            case 1:
                switch (randomPlay)
                {
                    case Plays.Rock:
                        Console.WriteLine("It's a draw!");
                        break;
                    case Plays.Paper:
                        Console.WriteLine("The computer has won, beter luck next time!");
                        break;
                    case Plays.Scissors:
                        Console.WriteLine("You have won, congratulations!");
                        break;
                }
                break;
            case 2:
                switch (randomPlay)
                {
                    case Plays.Rock:
                        Console.WriteLine("You have won, congratulations!");
                        break;
                    case Plays.Paper:
                        Console.WriteLine("It's a draw!");
                        break;
                    case Plays.Scissors:
                        Console.WriteLine("The computer has won, beter luck next time!");
                        break;
                }
                break;
            case 3:
                switch (randomPlay)
                {
                    case Plays.Rock:
                        Console.WriteLine("The computer has won, beter luck next time!");
                        break;
                    case Plays.Paper:
                        Console.WriteLine("You have won, congratulations!");
                        break;
                    case Plays.Scissors:
                        Console.WriteLine("It's a draw!");
                        break;
                }
                break;
        }
    }
}