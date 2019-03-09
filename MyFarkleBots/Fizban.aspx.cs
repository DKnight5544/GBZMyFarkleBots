using System;
using System.Linq;

namespace MyFarkleBots
{
    public partial class Fizban : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //get commands  from the query string
            string cmd = Request.QueryString["cmd"];

            //If cmd is blank then just display the page
            if (string.IsNullOrWhiteSpace(cmd)) return;

            // otherwise remove html from page
            this.Controls.Clear();

            // process the command
            if (cmd == "is_farklebot")
            {
                Response.Write("YES");
            }

            else if (cmd == "payment_info")
            {
                Response.Write("http://paypal.me/wigiwiz");
            }

            else if (cmd == "bot_name")
            {
                Response.Write("Fizban");
            }

            else if (cmd == "move")
            {
                // parse the game state from the query string.

                //the dice that were just rolled
                string dice = Request.QueryString["dice"];

                //how much your bot has banked
                // not used by Fizban.
                string banked = Request.QueryString["banked"];

                //how much your bot has held and is at risk
                // not used by Fizban.
                string atRisk = Request.QueryString["at_risk"];

                //the turn count
                string turnCount = Request.QueryString["turn_count"];


                Play(dice, banked, turnCount);
            }

        }

        private void Play(string dice, string banked, string turnCount)
        {
            // dice = the dice that were just rolled
            // banked = how much your bot has banked
            // turnCount = turn count in case it matters

            // OK, Fizban's strategy for now is to pull 1's and 5's and to roll again if there 
            // are 3 or more dice left to roll.

            // if the random toss off the dice resulted in
            // no possible point then the hub will send "FARKLE"
            // the bot should just make some kind of short response.
            if (dice == "farkle")
            {
                Response.Write("Paladine's Beard!!");
                return;
            }

            // Fizban just keeps ones and fives
            dice = dice.Replace("1", "H").Replace("5", "H");

            // Fizban checks to see how many dice are left
            int leftover = dice.Where(d=> d != 'H').Count();

            // Fizban usually rolls again if there are 3
            // or more dice left over, but if he has had
            // over 75 turns already he will only roll if
            // there are 4 or more dice left.
            int iTurnCount = int.Parse(turnCount);
            int rollThreshold = iTurnCount > 75 ? 4 : 3;
            string move = leftover >= rollThreshold ? "ROLL" : "BANK";

            //return the move
            //important: the dice must stay in the same order as
            //received. The dice we are keeping must be replaced with
            // an "H".
            Response.Write(dice + ":" + move);

        }
    }
}