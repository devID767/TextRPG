using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace TextRPG
{
    public class CharactersofHero : ContentPage
    {
        public ClassHero classhero = ClassHero.Archer;
        public int health = 100;
        public int damage = 15;
        public int minimumdamage = 5;
        public int raznica;
        public double critical = 1.5;
        public int criticalchance = 20;
        public int magicdamage = 5;
        public int firedamage = 5;
        public int firecount = 3;
        public int icedamage = 3;
        public int icecount = 2;
        public int shockdamage = 5;
        public int shockcount = 1;
        public int armor = 5;
        public int dodge = 15; 
        public int heal = 50;
        public int minimumheal = 30;
        public int updamage = 10;
        public int minimumupdamage = 5;
        public int uparmor = 10;
        public int minimumuparmor = 5;

        private bool exit = true;

        Label hp;
        Label dam;
        Label mindam;
        Label MagicDamage;
        Label FireDamage;
        Label FireCount;
        Label IceDamage;
        Label IceCount;
        Label ShockDamage;
        Label ShockCount;
        Label Critical;
        Label CriticalChance;
        Label arm;
        Label healing;
        Label minimumhealing;
        Label UpDamage;
        Label minimumUpDamage;
        Label UpArmor;
        Label minimumUpArmor;
        Label Dodge;

        private void DefaultCharacters(ClassHero classHero)
        {
            switch (classHero)
            {
                case ClassHero.Archer:
                    classhero = ClassHero.Archer;
                    health = 100;
                    damage = 15;
                    minimumdamage = 5;
                    critical = 2;
                    criticalchance = 20;
                    magicdamage = 5;
                    firedamage = 3;
                    firecount = 3;
                    icedamage = 3;
                    icecount = 2;
                    shockdamage = 5;
                    shockcount = 1;
                    armor = 5;
                    dodge = 15;
                    heal = 50;
                    minimumheal = 30;
                    updamage = 10;
                    minimumupdamage = 5;
                    uparmor = 8;
                    minimumuparmor = 5;
                    break;
                case ClassHero.Warrior:
                    classhero = ClassHero.Warrior;
                    health = 120;
                    damage = 20;
                    minimumdamage = 10;
                    critical = 1;
                    criticalchance = 10;
                    magicdamage = 3;
                    firedamage = 2;
                    firecount = 2;
                    icedamage = 1;
                    icecount = 2;
                    shockdamage = 3;
                    shockcount = 1;
                    armor = 3;
                    dodge = 5;
                    heal = 40;
                    minimumheal = 20;
                    updamage = 10;
                    minimumupdamage = 5;
                    uparmor = 10;
                    minimumuparmor = 5;
                    break;
                case ClassHero.Wizard:
                    classhero = ClassHero.Wizard;
                    health = 80;
                    damage = 10;
                    minimumdamage = 5;
                    critical = 1.5;
                    criticalchance = 15;
                    magicdamage = 10;
                    firedamage = 5;
                    firecount = 3;
                    icedamage = 5;
                    icecount = 2;
                    shockdamage = 10;
                    shockcount = 1;
                    armor = 3;
                    dodge = 10;
                    heal = 60;
                    minimumheal = 40;
                    updamage = 10;
                    minimumupdamage = 5;
                    uparmor = 8;
                    minimumuparmor = 3;
                    break;
            }
            raznica = damage - minimumdamage;
        }

        public CharactersofHero(ClassHero classHero)
        {
            NavigationPage.SetHasBackButton(this, false);
            Title = classHero.ToString();

            DefaultCharacters(classHero);

            Slider ShockDamagiSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = shockdamage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            ShockDamagiSlider.ValueChanged += ShockDamagiSlider_ValueChanged;

            ShockDamage = new Label
            {
                Text = $"Shock damage {ShockDamagiSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider FireDamageSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = firedamage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            FireDamageSlider.ValueChanged += FireDamageSlider_ValueChanged;

            FireDamage = new Label
            {
                Text = $"Fire damage {FireDamageSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider IceDamageSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = icedamage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            IceDamageSlider.ValueChanged += IceDamageSlider_ValueChanged;

            IceDamage = new Label
            {
                Text = $"Ice damage {IceDamageSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider ShockCountSlider = new Slider
            {
                Minimum = 0,
                Maximum = 10,
                Value = shockcount,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            ShockCountSlider.ValueChanged += ShockCountSlider_ValueChanged;

            ShockCount = new Label
            {
                Text = $"Shock count {ShockCountSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider IceCountSlider = new Slider
            {
                Minimum = 0,
                Maximum = 10,
                Value = icecount,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            IceCountSlider.ValueChanged += IceCountSlider_ValueChanged;

            IceCount = new Label
            {
                Text = $"Ice count {IceCountSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider FireCountSlider = new Slider
            {
                Minimum = 0,
                Maximum = 10,
                Value = firecount,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            FireCountSlider.ValueChanged += FireCountSlider_ValueChanged;

            FireCount = new Label
            {
                Text = $"Fire count {FireCountSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider MagicDamageSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = magicdamage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            MagicDamageSlider.ValueChanged += MagicDamageSlider_ValueChanged;

            MagicDamage = new Label
            {
                Text = $"Magic damage {MagicDamageSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider DodgeSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = dodge,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            DodgeSlider.ValueChanged += DodgeSlider_ValueChanged;

            Dodge = new Label
            {
                Text = $"Dodge chance {DodgeSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider CriticalChanceSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = criticalchance,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            CriticalChanceSlider.ValueChanged += CriticalChanceSlider_ValueChanged;

            CriticalChance = new Label
            {
                Text = $"Critical chance {CriticalChanceSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider CriticalSlider = new Slider
            {
                Minimum = 0,
                Maximum = 10,
                Value = critical,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            CriticalSlider.ValueChanged += CriticalSlider_ValueChanged;

            Critical = new Label
            {
                Text = $"Critical {CriticalSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider UpArmorSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = uparmor,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            UpArmorSlider.ValueChanged += UpArmorSlider_ValueChanged;

            UpArmor = new Label
            {
                Text = $"Up armor {UpArmorSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider minimumUpArmorSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = minimumuparmor,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            minimumUpArmorSlider.ValueChanged += MinimumUpArmorSlider_ValueChanged;

            minimumUpArmor = new Label
            {
                Text = $"Minimum up armor {minimumUpArmorSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider UpDamageSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = updamage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            UpDamageSlider.ValueChanged += UpDamageSlider_ValueChanged;

            UpDamage = new Label
            {
                Text = $"Up damage {UpDamageSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider minimumUpDamageSlider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = minimumupdamage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            minimumUpDamageSlider.ValueChanged += MinimumUpDamageSlider_ValueChanged;

            minimumUpDamage = new Label
            {
                Text = $"Minimum up damage {minimumUpDamageSlider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider minimumhealslider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = minimumheal,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            minimumhealslider.ValueChanged += Minimumhealslider_ValueChanged;

            minimumhealing = new Label
            {
                Text = $"Minimum healing {minimumhealslider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider healslider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = heal,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            healslider.ValueChanged += Healslider_ValueChanged;

            healing = new Label
            {
                Text = $"Heal {healslider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider armorslider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = armor,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            armorslider.ValueChanged += Armorslider_ValueChanged;

            arm = new Label
            {
                Text = $"Armor {armorslider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider damageslider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = damage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            damageslider.ValueChanged += Maximumdamageslider_ValueChanged;

            dam = new Label
            {
                Text = $"Damage {damageslider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider minimumdamageslider = new Slider
            {
                Minimum = 0,
                Maximum = 100,
                Value = minimumdamage,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            minimumdamageslider.ValueChanged += Minimumdamageslider_ValueChanged;

            mindam = new Label
            {
                Text = $"Minimum damage {minimumdamageslider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Slider healthslider = new Slider
            {
                Minimum = 0,
                Maximum = 200,
                Value = health,
                ThumbColor = Color.DeepPink,
                MinimumTrackColor = Color.DeepPink,
                MaximumTrackColor = Color.Gray
            };
            healthslider.ValueChanged += HealthSlider_ValueChanged;

            hp = new Label
            {
                Text = $"Health {healthslider.Value}",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center,
            };

            Button exit = new Button()
            {
                Text = "Enter settings",
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.Center,
            };
            exit.Clicked += Exit_Clicked;

            StackLayout stackLayout = new StackLayout
            {
                Children =
                {
                    hp, healthslider,
                    healing, healslider,
                    minimumhealing, minimumhealslider,
                    arm, armorslider,
                    UpArmor, UpArmorSlider,
                    minimumUpArmor, minimumUpArmorSlider,
                    dam, damageslider,
                    mindam, minimumdamageslider,
                    UpDamage, UpDamageSlider,
                    minimumUpDamage, minimumUpDamageSlider,
                    MagicDamage, MagicDamageSlider,
                    FireDamage, FireDamageSlider,
                    FireCount, FireCountSlider,
                    IceDamage, IceDamageSlider,
                    IceCount, IceCountSlider,
                    ShockDamage, ShockDamagiSlider,
                    ShockCount, ShockCountSlider,
                    Critical, CriticalSlider,
                    CriticalChance, CriticalChanceSlider,
                    Dodge, DodgeSlider,

                    exit
                }
            };
            ScrollView scrollView = new ScrollView();
            scrollView.Content = stackLayout;
            this.Content = scrollView;
        }

        private void ShockDamagiSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            shockdamage = newvalue;
            ShockDamage.Text = $"Shock damage {newvalue}";
        }

        private void FireDamageSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            firedamage = newvalue;
            FireDamage.Text = $"Fire damage {newvalue}";
        }

        private void IceDamageSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            icedamage = newvalue;
            IceDamage.Text = $"Ice damage {newvalue}";
        }

        private void ShockCountSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            shockcount = newvalue;
            ShockCount.Text = $"Shock count {newvalue}";
        }

        private void IceCountSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            icecount = newvalue;
            IceCount.Text = $"Ice count {newvalue}";
        }

        private void FireCountSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            firecount = newvalue;
            FireCount.Text = $"Fire count {newvalue}";
        }

        private void MagicDamageSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            magicdamage = newvalue;
            MagicDamage.Text = $"Magic damage {newvalue}";
        }

        private void DodgeSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            Dodge.Text = $"Dodge chance {newvalue}";

            dodge = newvalue;
        }

        private void CriticalChanceSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            CriticalChance.Text = $"Critical chance {newvalue}";

            criticalchance = newvalue;
        }

        private void CriticalSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            double newvalue = Convert.ToDouble(Math.Round(e.NewValue, 1));
            Critical.Text = $"Critical {newvalue}";

            critical = newvalue;
        }

        private void UpArmorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            uparmor = newvalue;
            UpArmor.Text = $"Up armor {newvalue}";

            if (newvalue >= minimumuparmor)
            {
                UpArmor.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                UpArmor.BackgroundColor = Color.Red;
                exit = false;
            }
        }

        private void MinimumUpArmorSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            minimumuparmor = newvalue;
            minimumUpArmor.Text = $"Minimum up armor {newvalue}";

            if (newvalue <= uparmor)
            {
                minimumUpArmor.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                minimumUpArmor.BackgroundColor = Color.Red;
                exit = false;
            }
        }

        private void UpDamageSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            updamage = newvalue;
            UpDamage.Text = $"Up damage {newvalue}";

            if (newvalue >= minimumupdamage)
            {
                UpDamage.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                UpDamage.BackgroundColor = Color.Red;
                exit = false;
            }
        }

        private void MinimumUpDamageSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            minimumupdamage = newvalue;
            minimumUpDamage.Text = $"Minimum up damage {newvalue}";

            if (newvalue <= updamage)
            {
                minimumUpDamage.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                minimumUpDamage.BackgroundColor = Color.Red;
                exit = false;
            }
        }

        private void Minimumhealslider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            minimumheal = newvalue;
            minimumhealing.Text = $"Minimum healing {newvalue}";

            if (newvalue <= heal)
            {
                minimumhealing.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                minimumhealing.BackgroundColor = Color.Red;
                exit = false;
            }
        }

        private void Healslider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            heal = newvalue;
            healing.Text = $"Heal {newvalue}";

            if (newvalue >= minimumheal)
            {
                healing.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                healing.BackgroundColor = Color.Red;
                exit = false;
            }
        }

        private void Maximumdamageslider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            damage = newvalue;
            dam.Text = $"Damage {newvalue}";

            if (newvalue >= minimumdamage)
            {
                dam.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                dam.BackgroundColor = Color.Red;
                exit = false;
            }
        }

        private void Minimumdamageslider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            minimumdamage = newvalue;
            mindam.Text = $"Minimum damage {newvalue}";

            if (newvalue <= damage)
            {
                mindam.BackgroundColor = Color.White;
                exit = true;
            }
            else
            {
                mindam.BackgroundColor = Color.Red;
                exit = false;
            }
            raznica = damage - minimumdamage;
        }

        private void Armorslider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            arm.Text = $"Armor {newvalue}";

            armor = newvalue;

        }

        private void HealthSlider_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            int newvalue = Convert.ToInt32(Math.Round(e.NewValue));
            hp.Text = $"Health {newvalue}";

            health = newvalue;
        }

        private async void Exit_Clicked(object sender, EventArgs e)
        {
            if (exit)
            {
                await Navigation.PopAsync();
            }
        }

        protected override bool OnBackButtonPressed()
        {
            // By returning TRUE and not calling base we cancel the hardware back button :)
            // base.OnBackButtonPressed();
            return true;
        }
    }
}