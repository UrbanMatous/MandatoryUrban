using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryUrban.Items
{

    /// <summary>
    /// Represents a group of attack items that can be used as a single composite attack.
    /// </summary>
    public class AttackGroup : IAttackItem



    {
        private List<IAttackItem> _items = new();

    /// <summary>
    /// Adds an attack item to the group.
    /// </summary>
    /// <param name="item">The attack item to add.</param>
        public void Add(IAttackItem item) => _items.Add(item);

        /// <summary>
        /// Gets the total hit points by summing all attack items in the group.
        /// </summary>
        public int HitPoints => _items.Sum(i => i.HitPoints);

        public string Description => $"Group of {_items.Count} attack items";
    }
}
