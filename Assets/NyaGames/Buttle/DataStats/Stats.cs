using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace NyaGames
{
    public class Stats
    {
        public Identifier identifier;
        public Power power;
        public Health health;
        public Regeneration regen;
        public Shield shield;
        public Agility agility;
        public Crit crit;
        public Vampire vampire;
        public Poison poison;
        public Characteristics characteristics;
        public Rarity rarity;

        public Data data;

        private Sprite appearance;

        public Sprite Appearance { get => GetSprite(ref appearance, identifier.appearanceName); }

        public string Name { get => identifier.name; }

        public int AttackSpeed { get => agility.attackSpeed / 10; }
        public int Vampire { get => vampire.value; }
        public int Poison { get => poison.value; }
        public int PoisonCountSteps { get => poison.countSteps; }

        public ERarity Rarity { get => rarity.rarity; }

        // Sprites
        private Sprite GetSprite(ref Sprite sprite, string spriteName)
        {
            if (sprite == null)
            {
                sprite = Resources.Load<Sprite>($"Sprites/Enemies/{spriteName}");
            }
            return sprite;
        }

        public Stats()
        {
            identifier = new Identifier();
            power = new Power();
            health = new Health();
            regen = new Regeneration();
            shield = new Shield();
            agility = new Agility();
            crit = new Crit();
            vampire = new Vampire();
            poison = new Poison();
            characteristics = new Characteristics();
            rarity = new Rarity();

            data = new Data();
        }

        public void Add(Stats res)
        {
            power.Add(res.power);
            health.Add(res.health);
            regen.Add(res.regen);
            shield.Add(res.shield);
            agility.Add(res.agility);
            crit.Add(res.crit);
            vampire.Add(res.vampire);
            poison.Add(res.poison);
            characteristics.Add(res.characteristics);
        }
    }
}
