using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace MandatoryUrban.Items
{

    /// <summary>
    /// Represents an object in the game world that can be picked up or interacted with.
    /// </summary>
    public class WorldObject
    {
        public string Description { get; set; }
        public bool IsRemovable { get; set; } = true;
        public int? BonusHitPoints { get; set; } = null;
        public AttackItem ContainedAttackItem { get; set; }
        public DefenseItem ContainedDefenseItem { get; set; }

        /// <summary>
        /// Initializes a new world object with a description.
        /// </summary>
        /// <param name="description"></param>
        public WorldObject(string description)
        {
            Description = description;
        }

        /// <summary>
        /// Applies the benefits or effects of the object to a creature.
        /// </summary>  

        public void ApplyTo(Creature creature)
        {
            if (BonusHitPoints.HasValue)
            {
                creature.HitPoints += BonusHitPoints.Value;
                GameLogger.Log($"{creature.Name} gains {BonusHitPoints.Value} hit points.");
            }

            if (ContainedAttackItem != null)
            {
                creature.Attacks.Add(ContainedAttackItem);
                GameLogger.Log($"{creature.Name} picked up attack item: {ContainedAttackItem.Description}");
            }

            if (ContainedDefenseItem != null)
            {
                creature.Defenses.Add(ContainedDefenseItem);
                GameLogger.Log($"{creature.Name} picked up defense item: {ContainedDefenseItem.Description}");
            }
        }
    }


}
