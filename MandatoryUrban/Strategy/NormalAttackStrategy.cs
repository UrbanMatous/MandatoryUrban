using System.Linq;

/// <summary>
/// A basic attack strategy that sums all attack item damage normally.
/// </summary>
public class NormalAttackStrategy : IAttackStrategy
{

    /// <summary>
    /// Calculates total damage by summing all attack items.
    /// </summary>
    /// <param name="creature">The attacking creature.</param>
    /// <returns>Total attack damage.</returns>
    public int CalculateDamage(Creature creature) => creature.Attacks.Sum(a => a.HitPoints);
}