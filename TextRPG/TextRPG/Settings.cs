using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TextRPG
{
    public class Settings : ContentPage
    {
        public static CharactersofHero Archer = new CharactersofHero(ClassHero.Archer);
        public static CharactersofHero Warrior = new CharactersofHero(ClassHero.Warrior);
        public static CharactersofHero Wizard = new CharactersofHero(ClassHero.Wizard);

        public static bool onmagic = true; 
        Label Magic;

        public Settings()
        {
            Title = "Settings";

            Magic = new Label
            {
                Text = "Magic on",
                HorizontalOptions = LayoutOptions.Center,
            };

            Switch MagicSwitch = new Switch
            {
                IsToggled = true,
                HorizontalOptions = LayoutOptions.Center,
            };
            MagicSwitch.Toggled += MagicSwitch_Toggled;

            Label settings = new Label
            {
                Text = "Choose a settings"
            };

            Button classhero = new Button
            {
                Text = "Characters of persons"
            };
            classhero.Clicked += Classhero_Clicked;

            Content = new StackLayout
            {
                Children = {
                    settings,
                    classhero,
                    Magic, MagicSwitch,
                }
            };
        }

        private void MagicSwitch_Toggled(object sender, ToggledEventArgs e)
        {
            if(e.Value == false)
            {
                Magic.Text = "Magic off";
                onmagic = false;
            }
            else
            {
                Magic.Text = "Magic on";
                onmagic = true;
            }
        }

        private async void Classhero_Clicked(object sender, EventArgs e)
        {
            var action = await DisplayActionSheet("Select person", "Cancel", null, "Archer", "Warrior", "Wizzard");

            switch (action)
            {
                case "Archer":
                    await Navigation.PushAsync(Archer);
                    break;
                case "Warrior":
                    await Navigation.PushAsync(Warrior);
                    break;
                case "Wizzard":
                    await Navigation.PushAsync(Wizard);
                    break;
            }
        }
    }


}