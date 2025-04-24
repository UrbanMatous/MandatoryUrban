/// <summary>
/// Observer that logs when creatures are hit.
/// </summary>

public class HitTracker : ICreatureObserver
{

    /// <summary>
    /// Called when a creature is hit. Logs the hit event.
    /// </summary>
    /// <param name="creature">The creature that was hit.</param>
    public void OnCreatureHit(Creature creature)
    {
        GameLogger.Log($"\"Observer: {creature.Name} was hit!\"");
    }
}
