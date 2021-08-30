using System.Collections.Generic;
namespace rock_paper_c_.Models
{
    public class Player
    {

    public void sayHiToPlayer(){
        System.Console.WriteLine($"You ready to take on the best {Name}. Good luck!");
    }

    public void addHand(Hand pHand, Hand cHand)
    {
        int result = pHand.whoWon(cHand.Name);
        switch (result){
            case -1:

                System.Console.ForegroundColor = System.ConsoleColor.Red;
                System.Console.WriteLine(@$"You LOSE! 😥:
                player Hand: {pHand.Name.ToUpper()} VS  computer Hand: {cHand.Name.ToUpper()}");
                System.Console.ResetColor();
                HandsThrown.Add(pHand);
                break;
            case 0:
                System.Console.WriteLine(@$"You tied the computer:
                player Hand: {pHand.Name.ToUpper()} VS  computer Hand: {cHand.Name.ToUpper()}");
                HandsThrown.Add(pHand);

                break;
            case 1:
                System.Console.ForegroundColor = System.ConsoleColor.Green;
                System.Console.WriteLine(@$"You WON! 🎉✨:
                player Hand: {pHand.Name.ToUpper()} VS  computer Hand: {cHand.Name.ToUpper()}");
                HandsThrown.Add(pHand);

                System.Console.ResetColor();
                break;
            default:
                System.Console.WriteLine("Please give a valid hand");
                break;
        }
        TotalHands++;
    }

    public void addToHint(char letter){
        System.Console.ForegroundColor = System.ConsoleColor.Yellow;
        HintsSeen.Add(letter);
        System.Console.ResetColor();

    }

    public void displayStats(){
        System.Console.ForegroundColor = System.ConsoleColor.Cyan;
        System.Console.WriteLine(
            @$"xxxxxxxxxxxxxx {Name} STATS: xxxxxxxxxxxxxx
            Time Played: {TotalHands}
            Wins: {Wins}
            {this.HandStats()}");
        System.Console.ResetColor();
    }



    public string HandStats() {
        int rock=0;
        int paper=0;
        int scissor=0;
        HandsThrown.ForEach(h => {
            switch(h.Name.ToLower()){
                case "rock":
                    rock++;
                    break;
                case "paper":
                    paper++;
                    break;
                case "scissors":
                    scissor++;
                    break;
                default:
                    throw new System.ArgumentException($"Illegal hand was in player History: {h.Name}");
            }});
        string result = $"Rocks thrown: {rock} \n             Papers thrown: {paper} \n             Scissors thrown: {scissor}";
        return result;

    }

    public void seeHint(){
        System.Console.WriteLine(@$"Hint so far:
        {this.hintToString()}");
    }
    private string hintToString(){
        string result = "";
        HintsSeen.ForEach(h => result += h);
        return result;
    }

    public string Name { get; private set; }
    public int TotalHands { get; private set; }
    public List<Hand> HandsThrown { get; private set; }
    public int Wins { get; private set; }
    public List<char> HintsSeen { get; set; }

    public Player(string name)
    {
      Name = name;
      TotalHands = 0;
      HandsThrown = new List<Hand>();
      Wins = 0;
      HintsSeen = new List<char>();
    }
    }
}