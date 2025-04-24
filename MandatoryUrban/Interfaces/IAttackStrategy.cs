/// <summary>
/// Interface for defining how a creature calculates its attack damage.
/// </summary>
public interface IAttackStrategy
{

    /// <summary>
    /// Calculates the damage dealt by a creature.
    /// </summary>
    int CalculateDamage(Creature creature);
}