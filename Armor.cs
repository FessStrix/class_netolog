using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace class_netolog
{
 internal class Armor
    {
        private float armorIndex;
        private Helm _helm = new Helm();
        private Shell _shell = new Shell();
        private Boots _boots = new Boots();

        public float ArmorIndex => _helm.IndexArmorHelm + _shell.IndexArmorShell + _boots.IndexArmorBoots;



        public Armor(float helmIndex, float shellIndex, float bootsIndex)
        {

            _helm.IndexArmorHelm = helmIndex;
            _shell.IndexArmorShell = shellIndex;
            _boots.IndexArmorBoots = bootsIndex;

        }

        public Armor()
        {
            armorIndex = _helm.IndexArmorHelm + _shell.IndexArmorShell + _boots.IndexArmorBoots;

        }



        public class Helm
        {
            private string _helmName = "Helm";
            private float _indexArmorHelm;

            public string HelmName { get; }
            public float IndexArmorHelm
            {
                get { return this._indexArmorHelm; }

                set
                {
                    if (value <= 0)
                    {
                        value = 0;
                    }

                    if (value >= 1)
                    {
                        value = 1;
                    }

                    this._indexArmorHelm = value;

                }
            }


            Helm(string name)
            {
                HelmName = name;
            }
            public Helm() : this("Helm") { }

        }

        public class Shell
        {
            private string _helmName = "Shell";
            private float _indexArmorShell;

            public string HelmName { get; }
            public float IndexArmorShell
            {
                get { return this._indexArmorShell; }

                set
                {
                    if (value <= 0)

                    { value = 0; }

                    if (value >= 1)
                    {
                        value = 1;
                    }
                    this._indexArmorShell = value;
                }
            }

            Shell(string name)
            {
                HelmName = name;
            }

            public Shell() : this("Shell") { }
        }
        public class Boots
        {
            private string _helmName = "Boots";
            private float _indexArmorBoots;

            public string BootsName { get; }
            public float IndexArmorBoots
            {
                get { return this._indexArmorBoots; }

                set
                {
                    if (value <= 0)

                    { value = 0; }

                    if (value >= 1)
                    {
                        value = 1;
                    }
                    this._indexArmorBoots = value;
                }
            }


            Boots(string name)
            {
                BootsName = name;
            }


            public Boots() : this("Boots") { }
        }


    }

internal class Weapon
{
    public string Name { get; }

    public float MinDamage { get; private set; }
    public float MaxDamage { get; private set; }
    public float Damage { get; set; }

    public Weapon(string name)
    {
        Name = name;
    }

    public Weapon(string name, float minDamage, float maxDamge) : this("Unknow")
    {
        Name = name;
        SetDamageParams(minDamage, maxDamge);

    }

    public void SetDamageParams(float min, float max)
    {
        if (min < 1)
        {
            Console.WriteLine("Минимальное значение урона не должно быть меньше 1");
            MinDamage = 1;
            Console.WriteLine($"Минимальный урон равен {MinDamage}");
        }

        if (max < 20)
        {
            Console.WriteLine("Максимальное значение урона не должно быть меньше 20");
            MaxDamage = 20;
            Console.WriteLine($"Минимальный урон равен {MaxDamage}");
        }


        if (min >= max)
        {
            Console.WriteLine("Минимальное значение не должно быть больше максимального");
            MinDamage = max;
            MaxDamage = min;

            Console.WriteLine($"Минимальный урон равен {MaxDamage}, максимальный{MaxDamage}");
        }

        MaxDamage = max;
        MinDamage = min;
    }

    public float GetDamage()
    {
        return (MaxDamage + MinDamage) / 2;

    }


}
}
