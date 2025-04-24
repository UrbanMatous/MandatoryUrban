using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MandatoryUrban.Items
{

    /// <summary>
    /// Interface for defense items that can reduce incoming damage.
    /// </summary>
    internal interface IDefenseItem
    {

        /// <summary>
        /// Gets the amount of damage reduction this item provides.
        /// </summary>
        int Protection { get;}


        /// <summary>
        /// Gets the description of the defense item.
        /// </summary>
        string Description { get;}
    }
}
