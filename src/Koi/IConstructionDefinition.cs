namespace Koi
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The ConstructionDefinition interface.
    /// </summary>
    internal interface IConstructionDefinition
    {
        /// <summary>
        /// Gets or sets the types.
        /// </summary>
        List<Type> Decorators { get; set; }

        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependency"/>.
        /// </returns>
        object ConstructType();
    }
}