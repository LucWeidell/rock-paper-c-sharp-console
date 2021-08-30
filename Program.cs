using System;
using System.Collections.Generic;
using rock_paper_c_.Models;

namespace rock_paper_c_
{
    class Program
    {
        static void Main(string[] args)
        {
            string hint = "Put in console: cheater";
            List<Hand> hands = new List<Hand>();
            hands.Add(new Hand("rock", "scissors", "paper"));
            hands.Add(new Hand("paper", "rock", "scissors"));
            hands.Add(new Hand("scissors", "paper", "rock"));
            Computer comp = new Computer();
            List<Player> players = new List<Player>();
            System.Console.WriteLine("Welcome to Rock Paper Scissors!");
            bool computerTrickedAll= true;
            bool needAccount = true;
            while(needAccount)
            {
                System.Console.WriteLine("Enter Your name Below to get started: (enter quit to leave)");
                string name = System.Console.ReadLine();
                name = name.ToLower();
                if(name == "quit"){
                    needAccount = false;
                    continue;
                }
                Player current = players.Find(p => p.Name == name);
                if(current == null)
                {
                    current = new Player("name");
                    players.Add(current);
                }
                else
                {
                    System.Console.WriteLine($"Continuing Session {current.Name}:");
                }
                bool login = true;
                while(login){
                    if(current.TotalHands > 0){
                        comp.totalChallenges();
                        current.displayStats();
                    }
                    System.Console.WriteLine("xxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxxx");
                    System.Console.WriteLine("To stop playing on this account type: stop");
                    System.Console.WriteLine("Choose a Hand: (rock, paper, scissors)");
                    string pchoice = Console.ReadLine().ToLower();
                    if(pchoice == "stop"){
                        login = false;
                        continue;
                    } else if( pchoice == "cheater"){
                        comp.cheater();
                        if(computerTrickedAll){
                            computerTrickedAll = false;
                        }
                        continue;
                    } else if(pchoice == "hint"){
                        current.seeHint();
                        continue;
                    }
                    Hand pHand = hands.Find(h => h.Name == pchoice);
                    if(pHand == null)
                    {
                        System.Console.WriteLine($"Invalid Hand: {pchoice}");
                        continue;
                    }
                    else
                    {
                        string compHandstr = comp.compChoice(pHand);
                        Hand cHand = hands.Find(h => h.Name == compHandstr);
                        current.addHand(pHand, cHand);
                        if(current.HintsSeen.Count < 24){
                            current.HintsSeen.Add(hint[current.HintsSeen.Count]);
                        }
                        comp.addCompTot();
                        if((current.TotalHands > 0) && (current.TotalHands % 7 == 0)){
                            System.Console.ForegroundColor = System.ConsoleColor.Yellow;
                            System.Console.WriteLine("If you can win I recommend typing 'hint' in the console!.");
                            System.Console.ResetColor();


                        }
                    }
                }
            }
            if(computerTrickedAll)
            {
                System.Console.WriteLine("THE COMPUTER GOT AWAY WITH IT! ಥ_ಥ");
            }
            else
            {
                System.Console.WriteLine("YOU CAUGHT THE COMPUTER! (☞ﾟヮﾟ)☞ 🏆🏆🏆 ☜(ﾟヮﾟ☜)");
            }
            System.Console.WriteLine();
        }
    }
}
