using System.Linq;

/// <summary>
/// A more aggressive strategy that increases damage output.
/// </summary>
public class AggressiveStrategy : IAttackStrategy
{

    /// <summary>
    /// Calculates damage by adding a bonus to the total from all attack items.
    /// </summary>
    /// <param name="creature">The attacking creature.</param>
    /// <returns>Total damage with aggression bonus.</returns>
    public int CalculateDamage(Creature creature) =>
        creature.Attacks.Sum(a => a.HitPoints) + 5;
}