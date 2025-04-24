using MandatoryUrban.Actions;

/// <summary>
/// Decorator that increases attack damage when the creature's health is low.
/// </summary>
public class LowHealthBoostDecorator : AttackDecorator
{
    private readonly Creature _owner;


    /// <summary>
    /// Initializes the decorator with the item to enhance and the owning creature.
    /// </summary>
    /// <param name="baseItem">The base attack item to decorate.</param>
    /// <param name="owner">The creature using the item.</param>
    public LowHealthBoostDecorator(IAttackItem baseItem, Creature owner) : base(baseItem)
    {
        _owner = owner;
    }

    /// <summary>
    /// Calculates the boosted hit points based on the owner's current health.
    /// Adds +5 if health is below 25.
    /// </summary>

    public override int HitPoints
    {
        get
        {
            if (_owner.HitPoints < 25)
                return base.HitPoints + 5;
            return base.HitPoints;
        }
    }
}