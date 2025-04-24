/// Interface for observing when a creature is hit.
/// </summary>
public interface ICreatureObserver
{
    /// <summary>
    /// Called when a creature is hit.
    /// </summary>
    void OnCreatureHit(Creature creature);
}