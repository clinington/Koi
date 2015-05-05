namespace Koi
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.TypeInitialisationStrategies;

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
        /// Gets the lifetime.
        /// </summary>
        Lifetime Lifetime { get; }

        /// <summary>
        /// Gets the koi container.
        /// </summary>
        BuilderContext BuilderContext { get; }

        /// <summary>
        /// Gets the type instantiation strategy.
        /// </summary>
        ITypeInstantiationStrategy TypeInstantiationStrategy { get; }

        /// <summary>
        /// Gets the construction strategy.
        /// </summary>
        IConstructionStrategy ConstructionStrategy { get; }

        /// <summary>
        /// The instantiate type.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object InstantiateType();
    }
}