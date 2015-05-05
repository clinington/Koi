namespace Koi.DependencyFactories
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.InstantiationStrategies;

    /// <summary>
    /// The DependencyBuilder interface.
    /// </summary>
    internal interface IDependencyFactory
    {
        /// <summary>
        /// The create.
        /// </summary>
        /// <param name="builderContext">
        /// The builder context.
        /// </param>
        /// <param name="instantiationStrategy">
        /// The type instantiation strategy.
        /// </param>
        /// <param name="constructionStrategy">
        /// The construction strategy.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IDependency"/>.
        /// </returns>
        IDependency Create(
            BuilderContext builderContext, 
            IInstantiationStrategy instantiationStrategy, 
            IConstructionStrategy constructionStrategy, 
            Type type);
    }
}
