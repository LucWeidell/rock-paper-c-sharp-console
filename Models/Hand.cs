namespace rock_paper_c_.Models
{
    public class Hand
    {

    public int whoWon(string cHand){
        if(cHand == WinsAgainst){
            return 1;
        } else if (cHand == LosesAgainst){
            return -1;
        } else if (cHand == Name){
            return 0;
        } else {
            return 100;
        }
    }

    public string Name { get;  private set; }
    public string WinsAgainst { get; private set; }
    public string LosesAgainst { get; private set; }

    public Hand(string name, string winsAgainst, string losesAgainst)
    {
      Name = name.ToLower();
      WinsAgainst = winsAgainst.ToLower();
      LosesAgainst = losesAgainst.ToLower();
    }
    }
}