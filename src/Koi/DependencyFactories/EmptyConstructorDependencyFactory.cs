namespace Koi.DependencyFactories
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.TypeInitialisationStrategies;

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
        /// <exception cref="KoiRegistrationException">
        /// Thrown if a Construction Factory isn't passed through
        /// </exception>
        public IDependency Create(BuilderContext builderContext, ITypeInstantiationStrategy typeInstantiationStrategy, IConstructionStrategy constructionStrategy, Lifetime lifetime, Type type)
        {
            var emptyConstructorConstructionStrategy = constructionStrategy as EmptyConstructorConstructionStrategy;

            if (emptyConstructorConstructionStrategy == null)
            {
                throw new KoiRegistrationException(string.Format("Expected Empty Constructor Construction Strategy but got: {0}", constructionStrategy.GetType().DeclaringType));
            }

            emptyConstructorConstructionStrategy.SetType(type);

            return new Dependency(builderContext, typeInstantiationStrategy, emptyConstructorConstructionStrategy, lifetime, type);
        }
    }
}
