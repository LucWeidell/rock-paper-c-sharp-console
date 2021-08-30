using System.Collections.Generic;
namespace rock_paper_c_.Models
{
    public class Computer
    {

    public int TotalHandsEver { get; private set; }
    private bool IsCheating { get; set; }

    public void cheater(){
        if(IsCheating){
            System.Console.ForegroundColor = System.ConsoleColor.Green;
            System.Console.WriteLine("You caught me i'll play fair now: You'll still lose!  (Beep Boop)");
            IsCheating = !IsCheating;
            System.Console.ResetColor();
        }
        else
        {
            System.Console.ForegroundColor = System.ConsoleColor.DarkRed;
            System.Console.WriteLine("Hard Mode re-activated: Pass your friend the challenge! (Boop Beep)");
            System.Console.ResetColor();
        }
    }

    public void totalChallenges(){
        System.Console.ForegroundColor = System.ConsoleColor.Gray;
        System.Console.WriteLine(
            @$"xxxxxxxxxxxxxx COMPUTER STATS xxxxxxxxxxxxxx
            Times Ever Challenged: {TotalHandsEver}");
        System.Console.ResetColor();

    }

    public string compChoice(Hand pHand){
        if(IsCheating) {
            return pHand.LosesAgainst;
        }
        else
        {
            return compFair();
        }
    }

    public string compFair() {
        int rand = new System.Random().Next(0, 2);
        string[] choices = new string[3]{"rock", "paper", "scissors"};
        return choices[rand];
    }

    public void addCompTot(){
        TotalHandsEver++;
    }

    public Computer()
    {
      TotalHandsEver = 0;
      IsCheating = true;
    }

    }
}