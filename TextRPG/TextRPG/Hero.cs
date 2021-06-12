using System;
using System.Collections.Generic;
using System.Text;

namespace TextRPG
{
    public enum ClassHero
    {
        None,
        Archer,
        Warrior,
        Wizard
    }

    public enum Magicka
    {
        None,
        Fire,
        Ice,
        Shock,
    }

    public class Hero
    {
        public string name { get; }
        public int health { get; private set; }
        public bool life { get; private set; }
        public int damage { get; private set; }
        public int magicdamage { get; private set; }
        public int firedamage { get; private set; }
        public int firecount { get; private set; }
        public int icedamage { get; private set; }
        public int icecount { get; private set; }
        public int shockdamage { get; private set; }
        public int shockcount { get; private set; }
        public int magiccount { get; private set; }
        public Magicka magic { get; set; }
        public ClassHero classhero { get; private set; }
        public CharactersofHero characters { get; private set; }
        public bool stoned { get; set; }
        public int armor { get; private set; }

        public void Charactors()
        {
            switch (classhero)
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

        public Hero(string name, ClassHero classHero)
        {
            classhero = classHero;
            Charactors();

            life = true;
            this.name = name;
            health = characters.health;
            damage = characters.damage;
            armor = characters.armor;
            magicdamage = characters.magicdamage;
            magiccount = 0;
            magic = Magicka.None;
        }

        public void SetHealth(int hp)
        {
            if(hp > 0 && hp <= characters.health) { health = hp; }
        }

        private void Death()
        {
            life = false;
            Console.WriteLine($"{name} is die");
        }

        public void Attack(int damage, Magicka magic = Magicka.None, CharactersofHero charactersof = default, bool magica = false)
        {

            if (damage > armor & magic == Magicka.None)
            {
                damage -= armor;
                MagicCount(true);
            }
            else if (magic != Magicka.None && magica == false)
            {
                this.magic = magic;
                firedamage = charactersof.firedamage;
                firecount = charactersof.firecount;
                icedamage = charactersof.icedamage;
                icecount = charactersof.icecount;
                shockdamage = charactersof.shockdamage;
                shockcount = charactersof.shockcount;
            }
            else
            {
                damage = 0;
            }
            health = health - damage;
            if (health <= 0)
            {
                health = 0;
                Death();
            }
        }

        public void Healing(int heal)
        {
            MagicCount(true);
            health = health + heal;

            int maxhealth = characters.health;
            
            if (health >= maxhealth) { health = maxhealth; };
        }

        public void Damage(int damage)
        {
            this.damage += damage;
            if (this.damage >= 100) { this.damage = 100; };
        }

        public void UpMagicDamage(int magicdamage)
        {
            this.magicdamage += magicdamage;
            if (this.magicdamage > 100) { this.magicdamage = 100; };
        }

        public string MagicEffects()
        {
            string result = String.Empty;
            switch (magic)
            {
                case Magicka.Fire:
                    Attack(firedamage, Magicka.Fire, default, true);
                    if (firecount - magiccount != 0)
                    {
                        result = $"{name} is fire and will lost {firedamage} damage for {firecount - magiccount} rounds";
                    }
                    break;
                case Magicka.Ice:
                    stoned = true;
                    Attack(icedamage, Magicka.Ice, default, true);
                    if (icecount - magiccount != 0)
                    {
                        result = $"{name} is frize and will lost {icedamage} damage for {icecount - magiccount} rounds";
                    }
                    break;
                case Magicka.Shock:
                    stoned = true;
                    Attack(shockdamage, Magicka.Shock, default, true);
                    if (shockcount - magiccount != 0)
                    {
                        result = $"{name} is shoked and will lost {shockdamage} damage for {shockcount - magiccount} rounds";
                    }
                    break;
                default:
                    break;
            }
            if (magic != Magicka.None)
            {
                MagicCount();
            }
            
            return result;
        }

        public void MagicCount(bool reset = false)
        {
            int maxcount = 0;
            switch (magic)
            {
                case Magicka.Fire:
                    maxcount = firecount;
                    break;
                case Magicka.Ice:
                    maxcount = icecount;
                    break;
                case Magicka.Shock:
                    maxcount = shockcount;
                    break;
            }
            if (reset || magiccount >= maxcount && maxcount != 0)
            {
                magiccount = 0;
                stoned = false;
                magic = Magicka.None;
            }
            else
            {
                magiccount++;
            }
        }

        public void Armor(int armor)
        {
            this.armor += armor;
            if (this.armor > 75) { this.armor = 75; };
        }

        public void Recover()
        {
            health = 75;
            life = true;
            Console.WriteLine($"{name} is recover!");
        }
    }
}
