namespace Koi
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.DependencyFactories;
    using Koi.TypeInitialisationStrategies;

    /// <summary>
    /// The construction definition.
    /// </summary>
    internal class ConstructionDefinition : IConstructionDefinition
    {
        /// <summary>
        /// The dependency factory.
        /// </summary>
        private readonly IDependencyFactory dependencyFactory;

        /// <summary>
        /// The lifetime.
        /// </summary>
        private readonly Lifetime lifetime;

        /// <summary>
        /// The context.
        /// </summary>
        private readonly BuilderContext context;

        /// <summary>
        /// The construction strategy.
        /// </summary>
        private readonly IConstructionStrategy constructionStrategy;

        /// <summary>
        /// The type initialisation strategy.
        /// </summary>
        private readonly ITypeInstantiationStrategy typeInstantiationStrategy;

        /// <summary>
        /// The type to construct.
        /// </summary>
        private readonly Type typeToConstruct;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConstructionDefinition"/> class.
        /// </summary>
        /// <param name="typeToConstruct">
        /// The type to construct.
        /// </param>
        /// <param name="typeInstantiationStrategy">
        /// The type initialisation strategy.
        /// </param>
        /// <param name="constructionStrategy">
        /// The construction strategy.
        /// </param>
        /// <param name="dependencyFactory">
        /// The dependency factory.
        /// </param>
        /// <param name="lifetime"></param>
        public ConstructionDefinition(
            Type typeToConstruct, 
            ITypeInstantiationStrategy typeInstantiationStrategy, 
            IConstructionStrategy constructionStrategy, 
            IDependencyFactory dependencyFactory, 
            Lifetime lifetime,
            BuilderContext context)
        {
            this.typeToConstruct = typeToConstruct;
            this.typeInstantiationStrategy = typeInstantiationStrategy;
            this.constructionStrategy = constructionStrategy;
            this.dependencyFactory = dependencyFactory;
            this.lifetime = lifetime;
            this.context = context;
        }

        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependency"/>.
        /// </returns>
        public IDependency ConstructType()
        {
            return this.dependencyFactory.Create(
                this.context,
                this.typeInstantiationStrategy,
                this.constructionStrategy,
                this.lifetime,
                this.typeToConstruct);
        }
    }
}