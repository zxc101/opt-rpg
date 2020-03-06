using UnityEngine;

using NyaGames.Statistics;

namespace NyaGames.Equipment
{
    [CreateAssetMenu(fileName = "NewEquipStats", menuName = "NyaGames/Stats/EquipStats")]
    public class SoEquipment : ScriptableObject
    {
        public EEquipmentType type;
        public Identifier identifier;
        public Power power;
        public Health health;
        public Regeneration regen;
        public Agility agility;
        public Shield shield;
        public Crit crit;
        public Vampire vampire;
        public Poison poison;
        public Characteristics characteristics;
        public Rarity rarity;

        public SoEquipment()
        {
            type = new EEquipmentType();
            identifier = new Identifier();
            power = new Power();
            health = new Health();
            regen = new Regeneration();
            agility = new Agility();
            shield = new Shield();
            crit = new Crit();
            vampire = new Vampire();
            poison = new Poison();
            characteristics = new Characteristics();
            rarity = new Rarity();
        }

        public void Add(SoEquipment res)
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
