using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;
using class_netolog;
using static class_netolog.Armor;
using static class_netolog.Weapon;


namespace class_netolog
{

    internal class Unit
    {
        private Weapon weapon;
        private Armor armor;
        private Armor.Helm helm = new Helm();
        private Armor.Shell shell = new Shell();
        private Armor.Boots boots = new Boots();
        private const float baseDamage = 5;

        public string UnitName { get; }
        public float Health { get; private set; }

        public float Damage
        {
            get
            {
                if (weapon != null)
                {
                    return weapon.Damage + baseDamage;
                }
                else
                    return baseDamage;
            }
        }

        public float Armor => (float)Math.Round(armor.ArmorIndex, 2);
        public Unit(string name, Armor armor, float health)
        {
            UnitName = name;
            this.armor = armor;
            Health = health;
        }
        public Unit() : this("Unknown Unit") { }
        public Unit(string name)
        {
            this.UnitName = name;
        }

        public float RealHealth()
        {
            float realHealth = Health * (1f + Armor);
            return (float)Math.Round(realHealth, 2);
        }

        public bool SetDamage(float value)
        {
            bool isDead = false;
            Health = Health - value * Armor;
            if (Health <= 0)
            {
                isDead = true;
            }
            else
            {
                isDead = false;
            }
            return isDead;
        }

        public void EquipWeapn(Weapon newWeapn)
        {
            weapon = newWeapn;
        }



        public void EquipShell(Armor.Shell newShell)
        {
            shell = newShell;
        }

        public void EquipBoots(Armor.Boots newBoots)
        {
            if (boots != null)
            {
                boots = newBoots;
            }


        }








        static void Main(string[] args)
        {     

            Console.WriteLine("Введите имя бойца:");
            string unitName = Console.ReadLine();

            Console.WriteLine("Введите начальное здоровье бойца (10-100):");
            float startHealthIndex;
            if (float.TryParse(Console.ReadLine(), out startHealthIndex))
            {
                if (startHealthIndex < 10 || startHealthIndex > 100)
                {
                    Console.WriteLine("Некоректное значение");
                    Console.ReadKey();
                    return;
                }
            }
            float helm;
            Console.WriteLine("Введите значение брони шлема от 0, до 1:");
            if (float.TryParse(Console.ReadLine(), out helm)) ;

            float shell;
            Console.WriteLine("Введите значение брони кирасы от 0, до 1:");
            if (float.TryParse(Console.ReadLine(), out shell)) ;

            float boots;
            Console.WriteLine("Введите значение брони сапог от 0, до 1:");
            if (float.TryParse(Console.ReadLine(), out boots)) ;

            var armor = new Armor(helm, shell, boots);
            Console.WriteLine("Суммарный индекс брони равен:" + armor.ArmorIndex);

            Console.WriteLine("Какое оружие в руке?");
            string WeaponName = Console.ReadLine();
            if (WeaponName == null || WeaponName == "")
            {
                Console.WriteLine("Ввод пустой!");
            }

            float minDamage;
            Console.WriteLine("Укажите минимальный урон от оружия (0-20):");
            if (float.TryParse(Console.ReadLine(), out minDamage)) ;

            float maxDamage;
            Console.WriteLine("Укажите максимальный урон от оружия (20-40):");
            if (float.TryParse(Console.ReadLine(), out maxDamage)) ;

            var weapon = new Weapon(WeaponName, minDamage, maxDamage);
            var unit = new Unit(unitName, armor, startHealthIndex);

            Console.WriteLine("Общий показатель брони равен: :" + unit.Armor);
            Console.WriteLine("Фактическое значение здоровья равно: :" + unit.RealHealth());


            Console.WriteLine("У вас в руке:" + weapon.Name);
            Console.WriteLine("Вы нанесли:" + weapon.GetDamage() + "ед.урона");

            Console.ReadLine();
        }
    }
}




          