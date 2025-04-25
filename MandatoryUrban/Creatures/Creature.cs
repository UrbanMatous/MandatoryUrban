using System.Collections.Generic;
using System.Linq;
using MandatoryUrban.Items;
using MandatoryUrban.MainClasses;

/// <summary>
/// Represents a generic creature in the game world.
/// Supports movement, combat, attack strategies, defense, and observers.
/// </summary>
public abstract class Creature
{
    /// <summary>
    /// Strategy used to calculate damage during attacks.
    /// </summary>
    public IAttackStrategy AttackStrategy { get; set; } = new NormalAttackStrategy();
    /// <summary>
    /// The name of the creature.
    /// </summary>
    public string Name { get; set; }
    /// <summary>
    /// The creature's current hit points (health).
    /// </summary>
    public int HitPoints { get; set; }
    /// <summary>
    /// A list of attack items currently equipped by the creature.
    /// </summary>
    public List<IAttackItem> Attacks { get; set; } = new();

    /// <summary>
    /// A list of defense items currently equipped by the creature.
    /// </summary>
    public List<DefenseItem> Defenses { get; set; } = new();

    /// <summary>
    /// Whether the creature is still alive.
    /// </summary>

    public bool IsAlive => HitPoints >= 0;

    private List<ICreatureObserver> observers = new();

    /// <summary>
    /// The X position of the creature in the world.
    /// </summary>
    public int X { get; set; }
    /// <summary>
    /// The Y position of the creature in the world.
    /// </summary>
    public int Y { get; set; }

    /// <summary>
    /// Moves the creature to a new position by applying deltas.
    /// </summary>
    /// <param name="deltaX">Change in X position.</param>
    /// <param name="deltaY">Change in Y position.</param>
    public void Move(int deltaX, int deltaY)
    {
        X += deltaX;
        Y += deltaY;
        GameLogger.Log($"{Name} moved to ({X}, {Y})");
    }
    /// <summary>
    /// Attacks another creature using the selected attack strategy.
    /// </summary>
    /// <param name="target">The target creature being attacked.</param>
    public void Attack(Creature target)
    {
        int totalDamage = CalculateDamage();
        GameLogger.Log($"\"{Name} attacks {target.Name} for {totalDamage} HP.\"");
        target.ReceiveHit(totalDamage);
    }

    /// <summary>
    /// Hook for subclasses to define how attack damage is calculated.
    /// This is usually overridden to call the attack strategy.
    /// </summary>
    /// <returns>Total calculated attack damage.</returns>
    protected abstract int CalculateDamage();

    /// <summary>
    /// Called when the creature receives incoming damage.
    /// Applies defense reduction and updates health.
    /// </summary>
    /// <param name="damage">Raw damage dealt before defense.</param>
    public void ReceiveHit(int damage)
    {
        int totalDefense = Defenses.Sum(d => d.Protection);
        int effectiveDamage = Math.Max(damage - totalDefense, 0);

        GameLogger.Log($"{Name} blocks {totalDefense} damage with defense items.");
        GameLogger.Log($"\"{Name} receives {effectiveDamage} damage. Remaining HP: {HitPoints - effectiveDamage}\"");

        HitPoints -= effectiveDamage;
        OnHit();

        if (!IsAlive)
        {
            GameLogger.Log($"{Name} has died.");
            
        }
    }

    /// <summary>
    /// Called whenever the creature is hit, triggering observers.
    /// </summary>
    protected virtual void OnHit()
    {
        foreach (var o in observers)
            o.OnCreatureHit(this);
    }

    /// <summary>
    /// Subscribes an observer to this creature's hit events.
    /// </summary>
    /// <param name="observer">The observer to attach.</param>
    public void Attach(ICreatureObserver observer) => observers.Add(observer);

    /// <summary>
    /// Operator overload to allow looting via 'creature + object' syntax.
    /// </summary>
    /// <param name="c">The creature performing the loot.</param>
    /// <param name="obj">The world object to be looted.</param>
    /// <returns>The creature after looting.</returns>
    public static Creature operator +(Creature c, WorldObject obj)
    {
        c.Loot(obj);
        return c;
    }

    /// <summary>
    /// Applies the effects of a world object to the creature (items, health bonus, etc.).
    /// </summary>
    /// <param name="obj">The world object to loot.</param>
    public void Loot(WorldObject obj)
    {
        GameLogger.Log($"\"{Name} loots {obj.Description}\"");
        obj.ApplyTo(this);
    }
}