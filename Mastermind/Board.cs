using System.Drawing;
using System.Net.Http.Headers;

namespace Mastermind;

public static class Board
{
    private const int CodeLength = 4;
    private const int BoardLength = 8;
    private static readonly Random Rand = new();

    public static void Play()
    {
        PrintInstructions();
        
        var shield = CreateShield();
        var board = CreateBoard();

        for (int i = 0; i < BoardLength; i++)
        {
            var userGuess = UserGuess();
            foreach (var c in userGuess)
            {
                Console.WriteLine(c);
            }
        }
    }

    private static void PrintInstructions()
    {
        Console.WriteLine(@"
The shield is made up of 4 randomly selected colours.
You need to guess the 4 colours by typing in 4 guesses.
The possible colours are: Red, Green, Blue, Yellow, Brown, Orange, White, Black.
If the right colour is in the correct position a black peg will be placed by the codemaker.
If the right colour is in the wrong position a white peg will be placed by the codemaker.
        ");
    }

    private static IEnumerable<Colour> UserGuess()
    {
        var guesses = new Colour[CodeLength];
        for (int i = 0; i < CodeLength; i++)
        {
            var guess = Player.Guess();
            guesses = (Colour[])guesses.Concat(guess);
        }

        return guesses;
    }

    private static IEnumerable<Colour> CreateBoard()
    {
        // var shield = CreateShield();
        IEnumerable<Colour> board = new Colour[] { };
        // board = board.Concat(shield);
        return board;
    }
    
    private static IEnumerable<Colour> CreateShield()
    {
        var shieldColours = new Colour[CodeLength];
        for (int i = 0; i < CodeLength; i++)
        {
            var colour = RandomColour();
            shieldColours[i] = colour;
        }

        return shieldColours;
    }

    private static Colour RandomColour()
    {
        var colours = Enum.GetValues<Colour>();
        return (Colour)colours.GetValue(Rand.Next(colours.Length))!;
    }
}