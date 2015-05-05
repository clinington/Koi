namespace Koi
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.InstantiationStrategies;

    /// <summary>
    /// The Dependency interface.
    /// </summary>
    internal interface IDependency
    {
        /// <summary>
        /// Gets the type.
        /// </summary>
        Type Type { get; }

        /// <summary>
        /// Gets the koi container.
        /// </summary>
        BuilderContext BuilderContext { get; }

        /// <summary>
        /// Gets the type instantiation strategy.
        /// </summary>
        IInstantiationStrategy InstantiationStrategy { get; }

        /// <summary>
        /// Gets the construction strategy.
        /// </summary>
        IConstructionStrategy ConstructionStrategy { get; }
    }
}