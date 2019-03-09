using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace MyFarkleBots
{
    public partial class Starbuck : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //commands 
            string cmd = Request.QueryString["cmd"];

            if (string.IsNullOrWhiteSpace(cmd)) return;

            //remove html
            this.Controls.Clear();

            if (cmd == "is_farklebot")
            {
                Response.Write("YES");
            }

            else if (cmd == "payment_info")
            {
                //remove html
                this.Controls.Clear();
                Response.Write("http://paypal.me/wigiwiz");
            }

            else if (cmd == "bot_name")
            {
                //remove html
                this.Controls.Clear();
                Response.Write("Starbuck");
            }

            else if (cmd == "move")
            {
                //remove html
                this.Controls.Clear();

                //the dice that were just rolled
                string dice = Request.QueryString["dice"];

                //how much your bot has banked
                string banked = Request.QueryString["banked"];

                //turn number
                string turnCount = Request.QueryString["turn_count"];

                Play(dice, banked, turnCount);
            }


        }

        private void Play(string dice, string banked, string turnCount)
        {
            // dice = the dice that were just rolled
            // banked = how much your bot has banked
            // turnCount = turn count in case it matters

            // OK, Starbuck's strategy for now is to pull 3 of a kinds and always bank.


            if (dice == "farkle")
            {
                Response.Write("OK");
                return;
            }

            string hold = dice.Replace("1", "H");
            if (TestPull(hold)) return;

            hold = dice.Replace("6", "H");
            if (TestPull(hold)) return;

            hold = dice.Replace("5", "H");
            if (TestPull(hold)) return;

            hold = dice.Replace("4", "H");
            if (TestPull(hold)) return;

            hold = dice.Replace("3", "H");
            if (TestPull(hold)) return;

            hold = dice.Replace("2", "H");
            if (TestPull(hold)) return;

            Response.Write(dice + ":BANK");


        }

        private bool TestPull(string hold)
        {
            int selected = hold.ToCharArray().Where(h => h == 'H').Count();

            if (selected >= 3)
            {
                Response.Write(hold + ":BANK");
                return true;
            }

            else return false;

        }
    }
}