using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TextRPG
{
    public class Players : ContentPage
    {
        List<string> names = new List<string>();
        List<string> chosenclasses = new List<string>();
        string chosenclass;
        Entry entry;
        Label entrynames;
        Label header;
        Picker pickerclasshero;
        ClassHero classhero = ClassHero.None;
        List<ClassHero> classheroes = new List<ClassHero>(); 

        public Players()
        {
            Title = "Add Players";
            Button add = new Button
            {
                Text = "Add player",
            };
            add.Clicked += Add_Clicked;

            Button remove = new Button
            {
                Text = "Remove player",
            };
            remove.Clicked += Remove_Clicked;

            entry = new Entry
            {
                Placeholder = "name",
                Keyboard = Keyboard.Text
            };

            header = new Label
            {
                Text = "Choose class",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };

            pickerclasshero = new Picker
            {
                Title = "Class"
            };

            pickerclasshero.Items.Add("Archer");
            pickerclasshero.Items.Add("Warrior");
            pickerclasshero.Items.Add("Wizard");

            pickerclasshero.SelectedIndexChanged += Enterclasshero_SelectedIndexChanged;

            entrynames = new Label
            {
                FontSize = 25,
                TextColor = Color.Green
            };

            Button continuegame = new Button
            {
                Text = "Finish",
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            continuegame.Clicked += Continue_Clicked;

            StackLayout stackLayout = new StackLayout
            {
                Children = {

                    new Label { Text = "Enter a new players" },
                    entry,
                    header,
                    pickerclasshero,
                    add,
                    remove,
                    entrynames,
                    continuegame,
                }
            };

            var scroll = new ScrollView();
            scroll.Content = stackLayout;
            this.Content = scroll;
        }

        private void Enterclasshero_SelectedIndexChanged(object sender, EventArgs e)
        {
            chosenclass = pickerclasshero.Items[pickerclasshero.SelectedIndex];
            header.Text = $"Your class is {chosenclass}";

            switch (chosenclass)
            {
                case "Archer":
                    classhero = ClassHero.Archer;
                    break;
                case "Warrior":
                    classhero = ClassHero.Warrior;
                    break;
                case "Wizard":
                    classhero = ClassHero.Wizard;
                    break;
            }
        }

        private void Remove_Clicked(object sender, EventArgs e)
        {
            if (names.Count != 0)
            {
                names.Remove(names[names.Count - 1]);
                chosenclasses.Remove(chosenclasses[chosenclasses.Count - 1]);
                classheroes.Remove(classheroes[classheroes.Count - 1]);
            }
            AddTextPlayer();
        }

        private void Add_Clicked(object sender, EventArgs e)
        {
            if(entry.Text != String.Empty && classhero != ClassHero.None)
            {
                classheroes.Add(classhero);
                chosenclasses.Add(chosenclass);
                names.Add(entry.Text);
                entry.Text = String.Empty;
                AddTextPlayer();
            }
            else
            {
                DisplayAlert("Error", "Enter the all parameters", "Cancel");
            }
        }

        private void AddTextPlayer()
        {
            entrynames.Text = "";
            for (int i = 0; i < names.Count; i++)
            {
                entrynames.Text += $"{names[i]} - {chosenclasses[i]} \n";

            }
        }

        private List<Hero> AddPlayer()
        {
            List<Hero> heroes = new List<Hero>();

            for (int i = 0; i < names.Count; i++)
            {
                heroes.Add(new Hero(name: names[i],
                                    classHero: classheroes[i]));
            }
            return heroes;
        }

        private void Continue_Clicked(object sender, EventArgs e)
        {
            var players = AddPlayer();

            if (players.Count > 1)
            {
                Application.Current.MainPage = new NavigationPage(new Turn(players));
            }
            else
            {
                DisplayAlert("Error", "Enter more player", "Cancel");
            }

        }
    }
}