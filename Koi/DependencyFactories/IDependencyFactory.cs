namespace Koi.DependencyFactories
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.TypeInitialisationStrategies;

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
        /// <param name="typeInstantiationStrategy">
        /// The type instantiation strategy.
        /// </param>
        /// <param name="constructionStrategy">
        /// The construction strategy.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        /// <returns>
        /// The <see cref="IDependency"/>.
        /// </returns>
        IDependency Create(
            BuilderContext builderContext, 
            ITypeInstantiationStrategy typeInstantiationStrategy, 
            IConstructionStrategy constructionStrategy, 
            Lifetime lifetime, 
            Type type);
    }
}
