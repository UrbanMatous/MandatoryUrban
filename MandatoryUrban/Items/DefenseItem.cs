using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// <summary>
/// Represents a defense item that can reduce damage received.
/// </summary>

namespace MandatoryUrban.Items
{
    public class DefenseItem:IDefenseItem
    {

        /// <summary>
        /// The amount of damage reduction provided by the defense item.
        /// </summary>
        public virtual int Protection { get; set; }

        /// <summary>
        /// The description of the defense item.
        /// </summary>
        public virtual string Description { get; set; }
    }

    /// <summary>
    /// Decorator that adds bonus protection to an existing defense item.
    /// Useful for effects like "Reinforced", "Blessed", or custom upgrades.
    /// </summary>
    public class BonusDefenseDecorator : DefenseItem
    {
        private readonly DefenseItem _baseItem;
        private readonly int _bonus;

        /// <summary>
        /// Creates a decorated defense item with added protection.
        /// </summary>
        /// <param name="baseItem">The original defense item to decorate.</param>
        /// <param name="bonus">The additional protection to apply.</param>
        /// <param name="label">Optional label describing the source of the bonus (e.g. "Steel", "Blessed").</param>
        public BonusDefenseDecorator(DefenseItem baseItem, int bonus)
        {
            _baseItem = baseItem;
            _bonus = bonus;
        }

        /// <summary>
        /// Gets the total protection value, including the bonus.
        /// </summary>
        public override int Protection => _baseItem.Protection + _bonus;

        /// <summary>
        /// Returns the description with the bonus label.
        /// </summary>
        public override string Description => $"{_baseItem.Description} + Bonus Protection ({_bonus})";
    }
}
