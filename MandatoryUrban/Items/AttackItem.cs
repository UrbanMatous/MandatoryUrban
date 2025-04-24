
using MandatoryUrban.Actions;


/// <summary>
/// Represents an attack item that can be used by a creature.
/// </summary>

public class AttackItem : IAttackItem
{
    /// <summary>
    /// The hit points or damage this item can deal.
    /// </summary>
    public virtual int HitPoints { get; set; }

    /// <summary>
    /// The description of the attack item.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Decorator that adds flat bonus damage to an existing attack item.
    /// Useful for applying named effects like "Rust", "Fire", or "Poison".
    /// </summary>

}
public class BonusDamageDecorator : AttackDecorator
{
    private readonly int _bonus;
    private readonly string _label;

    /// <summary>
    /// Creates a decorated attack item that adds a fixed damage bonus.
    /// </summary>
    /// <param name="baseItem">The base attack item to decorate.</param>
    /// <param name="bonus">The amount of bonus damage to add.</param>
    /// <param name="label">A label to describe the source of the bonus (e.g. "Fire", "Poison").</param>
    public BonusDamageDecorator(IAttackItem baseItem, int bonus, string label = "Bonus")
        : base(baseItem)
    {
        _bonus = bonus;
        _label = label;
    }


    /// <summary>
    /// Gets the total hit points, including the bonus.
    /// </summary>
    public override int HitPoints => base.HitPoints + _bonus;

    /// <summary>
    /// Returns the description with the bonus label.
    /// </summary>
    public override string Description => $"{base.Description} + {_label} ({_bonus})";
}