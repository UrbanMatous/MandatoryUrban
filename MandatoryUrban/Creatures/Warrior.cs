using System.Linq;

/// <summary>
/// A concrete implementation of a creature with basic attack logic.
/// </summary>
public class Warrior : Creature
{

    /// <summary>
    /// Calculates the total damage based on all equipped attack items.
    /// </summary>
    /// <returns>Total damage dealt.</returns>
    protected override int CalculateDamage()
    {
        return AttackStrategy.CalculateDamage(this); // LINQ used
    }
}