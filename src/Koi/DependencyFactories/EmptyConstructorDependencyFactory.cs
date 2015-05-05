namespace Koi.DependencyFactories
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.InstantiationStrategies;

    /// <summary>
    /// The empty constructor dependency factory.
    /// </summary>
    internal class EmptyConstructorDependencyFactory : IDependencyFactory
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
        /// <exception cref="KoiRegistrationException">
        /// Thrown if a Construction Factory isn't passed through
        /// </exception>
        public IDependency Create(BuilderContext builderContext, IInstantiationStrategy instantiationStrategy, IConstructionStrategy constructionStrategy, Type type)
        {
            var emptyConstructorConstructionStrategy = constructionStrategy as EmptyConstructorConstructionStrategy;

            if (emptyConstructorConstructionStrategy == null)
            {
                throw new KoiRegistrationException(string.Format("Expected Empty Constructor Construction Strategy but got:\n\t {0}", constructionStrategy.GetType().DeclaringType));
            }

            emptyConstructorConstructionStrategy.SetType(type);

            return new Dependency(builderContext, instantiationStrategy, emptyConstructorConstructionStrategy, type);
        }
    }
}
