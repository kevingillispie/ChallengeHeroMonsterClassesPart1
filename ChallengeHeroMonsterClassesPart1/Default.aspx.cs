using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ChallengeHeroMonsterClassesPart1
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                Character hero = new Character();
                hero.Name = "Manducate";
                hero.Health = 50;
                hero.DamageMaximum = 10;
                hero.AttackBonus = true;

                Character monster = new Character();
                monster.Name = "Bolus";
                monster.Health = 55;
                monster.DamageMaximum = 15;
                monster.AttackBonus = true;

                Dice dice = new Dice();
                dice.Sides = 12;

                resultLabel.Text = "";
                // Variable initialization:
                int i = 0;
                int round = 1;
                int defend = monster.Health;
                while (defend >= 0)
                {
                    
                    if (i == 0)
                    {
                        // First Round:
                        int bonus = hero.Attack(dice);
                        if (bonus > 7) bonus = 2;
                        else bonus = 1;
                        int attack = hero.Attack(dice);
                        defend = monster.Health - (attack * bonus);

                        DisplayStats(attack, defend , i, bonus, round);
                        monster.Health = defend;
                        i = 1;
                    }
                    else
                    {
                        // Second Round:
                        int bonus = monster.Attack(dice);
                        if (bonus > 7) bonus = 2;
                        else bonus = 1;
                        int attack = monster.Attack(dice);
                        defend = hero.Health - (attack * bonus);

                        DisplayStats(attack, defend, i, bonus, round);
                        hero.Health = defend;
                        i = 0;
                        round++;
                    }
                }
                int heroHealth = hero.Health;
                int monsterHealth = monster.Health;
                displayResult(heroHealth, monsterHealth);
            }
        }

        protected void fightButton_Click(object sender, EventArgs e)
        {
            
        }

        public int DisplayStats(int attack, int defend, int i, int bonus, int round)
        {
            string bonusYN;
            if (bonus == 2) bonusYN = "YES";
            else bonusYN = "NO";

            if (i == 0)
            {
                resultLabel.Text += String.Format("ROUND {0}<br><br>HERO ATTACKS:<br>Manducate's attack: " + attack.ToString() + "<br>Attack bonus: " + bonusYN, round);
                resultLabel.Text += String.Format("<br>Bolus's health: " + defend.ToString() + "<br><br>");
                i = 1;
                return i;
            }
            else
            {
                resultLabel.Text += String.Format("MONSTER ATTACKS:<br>Bolus's attack: " + attack.ToString() + "<br>Attack bonus: " + bonusYN);
                resultLabel.Text += String.Format("<br>Manducate's health: " + defend.ToString() + "<br><br><hr>");
                i = 1;
                return i;
            }
            
        }

        public int displayResult(int heroHealth, int monsterHealth)
        {
            if (heroHealth <= 0 && monsterHealth > 0)
            {
                resultLabel2.Text = String.Format("Bolus the Globular has digested our courageous hero, Manducate!");
                return 0;
            }
            else if (monsterHealth <= 0 && heroHealth > 0)
            {
                resultLabel2.Text = String.Format("Manducate the Iron-Jawed has chewed up the globular monster, Bolus, and spit him out!");
                return 0;
            }
            else if (heroHealth <= 0 && monsterHealth <= 0) resultLabel2.Text = String.Format("THE FICKLE FATES HAVE SPUN A BITERSWEET END: THEY HAVE KILLED EACH OTHER!!");
            return 0;
        }
    }

    class Character
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int DamageMaximum { get; set; }
        public bool AttackBonus { get; set; }

        public int Attack(Dice dice)
        {
            int attack = dice.Roll();
            return attack;
        }

        public int Defend(int damage)
        {
            damage = Health - damage;
            return damage;
        }
    }

    class Dice
    {
        public int Sides { get; set; }
        Random random = new Random();

        public int Roll()
        {
            int roll = random.Next(Sides);
            return roll;
        }
    }
}