namespace Koi.DependencyFactories
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.TypeInitialisationStrategies;

    /// <summary>
    /// The factory instance dependency factory.
    /// </summary>
    internal class FactoryInstanceDependencyFactory : IDependencyFactory
    {
        /// <summary>
        /// Gets or sets the construction factory.
        /// </summary>
        public Func<object> ConstructionFactory { get; set; }

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
        /// Thrown if Construction factory isn't of type FactoryConstructionStrategy
        /// </exception>
        public IDependency Create(BuilderContext builderContext, ITypeInstantiationStrategy typeInstantiationStrategy, IConstructionStrategy constructionStrategy, Lifetime lifetime, Type type)
        {
            var factoryConstructionStrategy = constructionStrategy as FactoryConstructionStrategy;

            if (factoryConstructionStrategy == null)
            {
                throw new KoiRegistrationException(string.Format("Expected Factory Construction Strategy but got: {0}", constructionStrategy.GetType().DeclaringType));
            }

            factoryConstructionStrategy.SetFactoryFunction(this.ConstructionFactory);

            return new Dependency(builderContext, typeInstantiationStrategy, factoryConstructionStrategy, lifetime, type);
        }
    }
}
