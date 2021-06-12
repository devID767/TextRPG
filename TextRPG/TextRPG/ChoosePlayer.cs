using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TextRPG
{
    public class ChoosePlayer : ContentPage
    {
        private Hero aim;
        private Hero hero;
        private StackLayout content;
        private Button scip;
        public static string actiontext;
        public static Act act;
        public static CharactersofHero characters;
        private Magicka magic;


        public ChoosePlayer(List<Hero> heroes, Hero hero, Act acts)
        {
            this.hero = hero;
            act = acts;

            if (act == Act.MagicAttack) { CurrentMagic(); }

            Title = $"{act}";

            scip = new Button
            {
                Text = "",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand,
            };
            scip.Clicked += Scip_Clicked;


            content = new StackLayout();

            EnterPlayers(heroes);

            Content = content;
        }

        private void EnterPlayers(List<Hero> heroes)
        {
            Button player = default;

            Label person = new Label
            {
                Text = "Choose the player:"
            };

            foreach (var emini in heroes)
            {
                if (act == Act.Attack || act == Act.MagicAttack)
                {
                    if (hero != emini && emini.life)
                    {
                        player = new Button
                        {
                            Text = $"{emini.name}",
                            BindingContext = emini
                        };
                        content.Children.Add(person);
                        content.Children.Add(player);
                        player.Clicked += Player_Clicked;
                    }
                }
                else if (act == Act.Recover)
                {
                    if (hero != emini)
                    {
                        player = new Button
                        {
                            Text = $"{emini.name}",
                            BindingContext = emini
                        };
                        content.Children.Add(person);
                        content.Children.Add(player);
                        player.Clicked += Player_Clicked;
                    }
                }
                else if (act == Act.Heal)
                {
                    if (emini.life)
                    {
                        player = new Button
                        {
                            Text = $"{emini.name}",
                            BindingContext = emini
                        };
                        content.Children.Add(person);
                        content.Children.Add(player);
                        player.Clicked += Player_Clicked;
                    }
                }
                else
                {
                    scip.Text = "Enter to continue";
                    content.Children.Add(scip);
                }

            }
        }

        private async void NextStep(bool scip)
        {
            if (scip)
            {
                await Navigation.PopAsync();
            }
            else
            {
                Turn.NextPlayer();
                await Navigation.PopToRootAsync();
            }
        }

        private void Scip_Clicked(object sender, EventArgs e) => Move();

        private void Player_Clicked(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            aim = (Hero)button.BindingContext;

            if (aim.magic != Magicka.None && act == Act.MagicAttack)
            {
                DisplayAlert("Error", $"{aim.name} already below magic", "Okay");
            }
            else
            {
                Move();
            }
            
        }

        private void CurrentClass()
        {
            switch (hero.classhero)
            {
                case ClassHero.Archer:
                    characters = Settings.Archer;
                    break;
                case ClassHero.Warrior:
                    characters = Settings.Warrior;
                    break;
                case ClassHero.Wizard:
                    characters = Settings.Wizard;
                    break;
            }
        }

        private bool Chance(int persentage)
        {
            var rand = new Random();
            int iscritical = rand.Next(0, 100);
            if (iscritical < persentage) { return true; }
            else { return false; }
        }

        private async void CurrentMagic()
        {
            var action = await DisplayActionSheet("Select magic", "Cancel", null, "Fire", "Ice", "Shock");

            switch (action)
            {
                case "Fire":
                    magic = Magicka.Fire;
                    break;
                case "Ice":
                    magic = Magicka.Ice;
                    break;
                case "Shock":
                    magic = Magicka.Shock;
                    break;
                default:
                    magic = Magicka.None;
                    break;
            }
        }

        private void Move()
        {
            CurrentClass();
            bool scip = false;
            bool iscritical = Chance(characters.criticalchance);
            bool dodge = Chance(characters.dodge);
            int value = 0;
            var rand = new Random();
            switch (act)
            {
                case Act.Attack:
                    value = rand.Next(hero.damage - characters.raznica, hero.damage + 1);
                    if (iscritical) { value = Convert.ToInt32(Math.Round(value * characters.critical)); }
                    if (!dodge) { aim.Attack(value); }
                    break;
                case Act.MagicAttack:
                    value = hero.magicdamage;
                    if (iscritical) { value = Convert.ToInt32(Math.Round(value * characters.critical)); }
                    if (!dodge) { aim.Attack(value, magic, characters, false); }
                    break;
                case Act.Heal:
                    value = rand.Next(characters.minimumheal, characters.heal + 1);
                    aim.Healing(value);
                    break;
                case Act.UpDamage:
                    value = rand.Next(characters.minimumupdamage, characters.updamage + 1);
                    hero.Damage(value);
                    break;
                case Act.UpArmor:
                    value = rand.Next(characters.minimumuparmor, characters.uparmor + 1);
                    hero.Armor(value);
                    break;
                case Act.Recover:
                    value = 50;
                    if (hero.health > 50)
                    {
                        aim.Recover();
                        hero.SetHealth(value);
                    }
                    break;
                case Act.Characters:
                    value = 0;
                    scip = true;
                    break;
            }

            actiontext = ActionText(value, iscritical, dodge);
            Message();
            NextStep(scip);
        }

        private string ActionText(int value, bool iscritical, bool dodge)
        {
            switch (act)
            {
                case Act.Attack:
                    if (!aim.life)
                    {
                        return $"{hero.name} attack {aim.name} on {value} damage \n" +
                               $"{aim.name} have {aim.health} health \n" +
                               $"{aim.name} is die";
                    }
                    else
                    {
                        if (iscritical)
                        {
                            return $"{hero.name} attack {aim.name} on {value} critical damage \n" +
                                   $"{aim.name} have {aim.health} health";
                        }
                        else if (dodge)
                        {
                            return $"{hero.name} attack {aim.name}, but " +
                                   $"{aim.name} dodged damage";
                        }
                        else
                        {
                            return $"{hero.name} attack {aim.name} on {value} damage \n" +
                                   $"{aim.name} have {aim.health} health";
                        }
                    }
                case Act.MagicAttack:
                    if (!aim.life)
                    {
                        return $"{hero.name} attack {aim.name} on {value} damage by {magic} magic \n" +
                               $"{aim.name} have {aim.health} health \n" +
                               $"{aim.name} is die";
                    }
                    else
                    {
                        if (iscritical)
                        {
                            return $"{hero.name} attack {aim.name} on {value} critical damage \n" +
                                   $"{aim.name} have {aim.health} health";
                        }
                        else if (dodge)
                        {
                            return $"{hero.name} attack {aim.name}, but " +
                                   $"{aim.name} dodged damage";
                        }
                        else
                        {
                            return $"{hero.name} attack {aim.name} on {value} damage by {magic} magic\n" +
                                   $"{aim.name} have {aim.health} health";
                        }
                    }

                case Act.Heal:
                    return $"{hero.name} heal {aim.name} on {value} hp \n" +
                           $"{aim.name} have {aim.health} health";

                case Act.UpDamage:
                    return $"{hero.name} up our damage on {value} points\n";

                case Act.UpArmor:
                    return $"{hero.name} up our armor on {value} points\n";

                case Act.Recover:
                    return $"{hero.name} recover {aim.name} and lost {value} hp \n" +
                           $"{hero.name} have {hero.health} health \n" +
                           $"{aim.name} have {aim.health} health";
                case Act.Characters:
                    return $"name: {hero.name} \n" +
                           $"class: {characters.classhero} \n" +
                           $"health = {hero.health}\n" +
                           $"damage = {hero.damage}\n" +
                           $"critical = {characters.critical}\n" +
                           $"critical chance = {characters.criticalchance}%\n" +
                           $"dodge chance = {characters.dodge}%\n" +
                           $"armor = {hero.armor}\n" +
                           $"magicdamage = {hero.magicdamage}\n" +
                           $"is under magic = {hero.magic} during {hero.magiccount}\n";
                default:
                    return "Error";
            }
        }

        private void Message() => DisplayAlert(act.ToString(), actiontext, "Okay");
    }
}