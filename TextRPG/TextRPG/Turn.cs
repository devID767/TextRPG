using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TextRPG
{

    public class Turn : ContentPage
    {
        private static int turn = 0;
        private static List<Hero> heroes;
        private static Label name;
        private static Label magiceffects;
        public static Hero hero;

        public Turn(List<Hero> heroess)
        {
            heroes = heroess;

            Title = "Turn";

            Hero();

            name = new Label
            {
                Text = $"Turn player {hero.name }",
                FontSize = 25,
                HorizontalOptions = LayoutOptions.Center
            };

            magiceffects = new Label
            {
                Text = "",
            };

            Button ready = new Button
            {
                Text = "Tap to continue"
            };
            ready.Clicked += Ready_Clicked;

            Button message = new Button
            {
                Text = "Check lust action",
                VerticalOptions = LayoutOptions.EndAndExpand,
            };
            message.Clicked += Message_Clicked;

            StackLayout panel = new StackLayout()
            {
                Children = {
                    name,
                    ready,
                    magiceffects,
                    message,
                }
            };
            Content = panel;
        }

        private void Message_Clicked(object sender, EventArgs e)
        {
            if(ChoosePlayer.actiontext != default) { DisplayAlert(ChoosePlayer.act.ToString(), ChoosePlayer.actiontext, "Okay"); }
            else { DisplayAlert("Error", "The lost action is none", "Ok"); }
        }

        public static void NextPlayer()
        {
            turn++;
            Hero();
            name.Text = $"Turn player {hero.name}";
            magiceffects.Text = hero.MagicEffects();
        }

        private static void Hero()
        {
            while (true)
            {
                if (turn == heroes.Count) { turn = 0; } //!!!
                if (!heroes[turn].life)
                {
                    turn++;
                }
                else { break; }
            }

           hero = heroes[turn];
        }

        private bool IsWon()
        {
            int count = 0;
            foreach (var hero in heroes)
            {
                if (hero.life)
                {
                    count++;
                }
            }
            if(count == 1) { return true; }
            else { return false; }
        }

        private async void Ready_Clicked(object sender, EventArgs e)
        {
            if(IsWon())
            {
                await DisplayAlert("Congratulation!", $"{hero.name} is won!", "Ok");
            }
            else
            {
                await Navigation.PushAsync(new Actions(hero, heroes));
            }
        }

        protected override bool OnBackButtonPressed()
        {
            // By returning TRUE and not calling base we cancel the hardware back button :)
            // base.OnBackButtonPressed();
            return false;
        }
    }
}