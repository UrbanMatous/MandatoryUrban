/// <summary>
/// Interface for attack items usable by creatures.
/// </summary>

public interface IAttackItem
{
    /// <summary>
    /// The damage this item can deal.
    /// </summary>
    int HitPoints { get; }

    /// <summary>
    /// A short description of the item.
    /// </summary>
    string Description { get; }
}