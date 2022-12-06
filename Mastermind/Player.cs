using System.Drawing;

namespace Mastermind;

public static class Player
{
    public static Colour[] Guess()
    {
        Colour guess;
        do
        {
            Console.Write("Enter guess: ");
        } while (Enum.TryParse(Console.ReadLine(), out guess));

        return new []{guess};
    }
}