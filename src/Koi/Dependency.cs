namespace Koi
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.InstantiationStrategies;

    /// <summary>
    /// The dependency.
    /// </summary>
    internal class Dependency : IDependency
    {
        /// <summary>
        /// Gets or sets the dependencies.
        /// </summary>
        private IDependency[] dependencies;

        /// <summary>
        /// Initializes a new instance of the <see cref="Dependency"/> class.
        /// </summary>
        /// <param name="builderContext">
        /// The builder Context.
        /// </param>
        /// <param name="instantiationStrategy">
        /// The type Initialisation Strategy.
        /// </param>
        /// <param name="constructionStrategy">
        /// The construction Strategy.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <param name="type">
        /// The type.
        /// </param>
        public Dependency(
            BuilderContext builderContext, 
            IInstantiationStrategy instantiationStrategy, 
            IConstructionStrategy constructionStrategy, 
            Type type)
        {
            this.ConstructionStrategy = constructionStrategy;
            this.Type = type;
            this.InstantiationStrategy = instantiationStrategy;
            this.BuilderContext = builderContext;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the koi container.
        /// </summary>
        public BuilderContext BuilderContext { get; private set; }

        /// <summary>
        /// Gets the strategy.
        /// </summary>
        public IInstantiationStrategy InstantiationStrategy { get; private set; }

        /// <summary>
        /// Gets the construction strategy.
        /// </summary>
        public IConstructionStrategy ConstructionStrategy { get; private set; }
    }
}