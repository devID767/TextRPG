using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TextRPG
{
    public enum Act
    {
        None,
        Attack,
        MagicAttack,
        Heal,
        UpDamage,
        UpArmor,
        Recover,
        Characters,
    }
    public class Actions : ContentPage
    {
        private Hero hero;
        private List<Hero> heroes;

        public Actions(Hero hero, List<Hero> heroes)
        {
            this.hero = hero;
            this.heroes = heroes;

            NavigationPage.SetHasBackButton(this, false);

            Title = $"Action {hero.name}";

            Button exit = new Button
            {
                Text = "Finish turn",
                VerticalOptions = LayoutOptions.EndAndExpand,
            };
            exit.Clicked += Exit_Clicked;

            Button attack = new Button
            {
                Text = "Attack"
            };
            attack.Clicked += Attack_Clicked;

            Button magicattack= new Button
            {
                Text = "Magic attack"
            };
            magicattack.Clicked += Magicattack_Clicked;

            Button heal = new Button
            {
                Text = "Heal"
            };
            heal.Clicked += Heal_Clicked;

            Button UpDamage = new Button
            {
                Text = "Up damage"
            };
            UpDamage.Clicked += UpDamage_Clicked;

            Button UpArmor = new Button
            {
                Text = "Up armor"
            };
            UpArmor.Clicked += UpArmor_Clicked;

            Button recover = new Button
            {
                Text = "Recover"
            };
            recover.Clicked += Recover_Clicked;

            Button characters = new Button
            {
                Text = "Characters"
            };
            characters.Clicked += Characters_Clicked;

            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Choose the action" },
                    attack,
                    magicattack,
                    heal,
                    UpDamage,
                    UpArmor,
                    recover,
                    characters,
                    exit,
                }
            };
        }

        private void Magicattack_Clicked(object sender, EventArgs e)
        {
            if (Settings.onmagic)
            {
                NextStep(Act.MagicAttack);
            }
            else
            {
                DisplayAlert("Error", "The  magic is off", "Ok");
            }
        }

        private void Characters_Clicked(object sender, EventArgs e)
        {
            NextStep(Act.Characters);
        }

        private void Recover_Clicked(object sender, EventArgs e)
        {
            NextStep(Act.Recover);
        }

        private void UpArmor_Clicked(object sender, EventArgs e)
        {
            NextStep(Act.UpArmor);
        }

        private void UpDamage_Clicked(object sender, EventArgs e)
        {
            NextStep(Act.UpDamage);
        }

        private void Heal_Clicked(object sender, EventArgs e)
        {
            NextStep(Act.Heal);
        }

        private void Attack_Clicked(object sender, EventArgs e)
        {
            NextStep(Act.Attack);
        }

        private async void NextStep(Act action)
        {
            if (!Stoned(action))
            {
                await DisplayAlert("Error", "You are stoned", "Okay");
            }
            else
            {
                await Navigation.PushAsync(new ChoosePlayer(heroes, hero, action));
            }
        }

        private bool Stoned(Act act)
        {
            if (hero.stoned)
            {
                switch (act)
                {
                    case Act.Attack:
                        return false;
                    case Act.MagicAttack:
                        return false;
                    case Act.Heal:
                        return true;
                    case Act.UpDamage:
                        return true;
                    case Act.UpArmor:
                        return true;
                    case Act.Recover:
                        return false;
                    case Act.Characters:
                        return true;
                    default:
                        return false;
                }
            }
            else
            {
                return true;
            }
        }

        private async void Exit_Clicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
            Turn.NextPlayer();
        }
    }
}
   