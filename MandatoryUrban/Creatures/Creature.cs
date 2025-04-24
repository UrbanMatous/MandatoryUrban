using System.Collections.Generic;
using System.Linq;
using MandatoryUrban.Items;
using MandatoryUrban.MainClasses;

public abstract class Creature
{
    public IAttackStrategy AttackStrategy { get; set; } = new NormalAttackStrategy();
    public string Name { get; set; }
    public int HitPoints { get; set; }
    public List<IAttackItem> Attacks { get; set; } = new();
    public List<DefenseItem> Defenses { get; set; } = new();

    public bool IsAlive => HitPoints >= 0;

    private List<ICreatureObserver> observers = new();

    public int X { get; set; }
    public int Y { get; set; }

    public void Move(int deltaX, int deltaY)
    {
        X += deltaX;
        Y += deltaY;
        GameLogger.Log($"{Name} moved to ({X}, {Y})");
    }

    /// <summary>
    /// Attacks another creature using defined logic.
    /// </summary>
    public void Attack(Creature target)
    {
        int totalDamage = CalculateDamage();
        GameLogger.Log($"\"{Name} attacks {target.Name} for {totalDamage} HP.\"");
        target.ReceiveHit(totalDamage);
    }

    /// <summary>
    /// Hook for subclasses to define damage logic.
    /// </summary>
    protected abstract int CalculateDamage();

    /// <summary>
    /// Called when creature receives a hit.
    /// </summary>
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

    protected virtual void OnHit()
    {
        foreach (var o in observers)
            o.OnCreatureHit(this);
    }

    public void Attach(ICreatureObserver observer) => observers.Add(observer);

    public static Creature operator +(Creature c, WorldObject obj)
    {
        c.Loot(obj);
        return c;
    }

    public void Loot(WorldObject obj)
    {
        GameLogger.Log($"\"{Name} loots {obj.Description}\"");
        // Add logic to actually equip/consume/etc.
    }
}