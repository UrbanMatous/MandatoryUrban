using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryUrban.MainClasses;

namespace MandatoryUrban.Actions
{

    /// <summary>
    /// Abstract base class for decorating attack items to enhance or modify their behavior.
    /// </summary>
    public abstract class AttackDecorator : IAttackItem
    {

        /// <summary>
        /// The attack item being wrapped or decorated.
        /// </summary>
        protected IAttackItem _baseItem;

        /// <summary>
        /// Initializes a new decorator around an existing attack item.
        /// </summary>
        /// <param name="baseItem">The item to decorate.</param>
        public AttackDecorator(IAttackItem baseItem)
        {
            _baseItem = baseItem;
        }

        /// <summary>
        /// Gets the hit points of the decorated item.
        /// </summary>
        public virtual int HitPoints => _baseItem.HitPoints;

        /// <summary>
        /// Gets the description of the decorated item.
        /// </summary>
        public virtual string Description => _baseItem.Description;
    }

}
