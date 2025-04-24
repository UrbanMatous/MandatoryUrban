using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MandatoryUrban.Items;

namespace MandatoryUrban.MainClasses
{


    /// <summary>
    /// Represents the 2D game world which holds creatures and world objects.
    /// </summary>
    public class World
    {

        /// <summary>
        /// Width of the game world.
        /// </summary>
        public int MaxX { get; set; }

        /// <summary>
        /// Height of the game world.
        /// </summary>
        public int MaxY { get; set; }

        /// <summary>
        /// All creatures currently present in the world.
        /// </summary>
        public List<Creature> Creatures { get; } = new List<Creature>();

        /// <summary>
        /// All world objects (loot, obstacles, etc.) in the world.
        /// </summary>
        public List<WorldObject> Objects { get; } = new List<WorldObject>();

        /// <summary>
        /// Initializes a new instance of the World class with specified width and height.
        /// </summary>

        public World(int maxX, int maxY)
        {
            MaxX = maxX;
            MaxY = maxY;
        }


        /// <summary>
        /// Adds a creature to the world.
        /// </summary>
        /// <param name="creature">The creature to add.</param>
        public void AddCreature(Creature creature)
        {
            Creatures.Add(creature);
        }

        /// <summary>
        /// Adds a world object to the world.
        /// </summary>
        /// <param name="obj">The object to add.</param>
        public void AddObject(WorldObject obj)
        {
            Objects.Add(obj);
        }

        /// <summary>
        /// Removes a creature from the world.
        /// </summary>
        /// <param name="creature">The creature to remove.</param>
        public void RemoveCreature(Creature creature)
        {
            Creatures.Remove(creature);
        }

        /// <summary>
        /// Removes an object from the world.
        /// </summary>
        /// <param name="obj">The object to remove.</param>
        public void RemoveObject(WorldObject obj)
        {
            Objects.Remove(obj);
        }
    }
}
