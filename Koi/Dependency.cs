namespace Koi
{
    using System;

    using Koi.ConstructionStrategies;
    using Koi.TypeInitialisationStrategies;

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
        /// <param name="typeInstantiationStrategy">
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
            ITypeInstantiationStrategy typeInstantiationStrategy, 
            IConstructionStrategy constructionStrategy, 
            Lifetime lifetime, 
            Type type)
        {
            this.ConstructionStrategy = constructionStrategy;
            this.Lifetime = lifetime;
            this.Type = type;
            this.TypeInstantiationStrategy = typeInstantiationStrategy;
            this.BuilderContext = builderContext;
        }

        /// <summary>
        /// Gets the type.
        /// </summary>
        public Type Type { get; private set; }

        /// <summary>
        /// Gets the lifetime.
        /// </summary>
        public Lifetime Lifetime { get; private set; }

        /// <summary>
        /// Gets the koi container.
        /// </summary>
        public BuilderContext BuilderContext { get; private set; }

        /// <summary>
        /// Gets the strategy.
        /// </summary>
        public ITypeInstantiationStrategy TypeInstantiationStrategy { get; private set; }

        /// <summary>
        /// Gets the construction strategy.
        /// </summary>
        public IConstructionStrategy ConstructionStrategy { get; private set; }

        /// <summary>
        /// The initialise type.
        /// </summary>
        /// <param name="strategy">
        /// The strategy.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object InstantiateType()
        {
            object intialisedType = null;

            try
            {
                intialisedType = this.TypeInstantiationStrategy.InstantiateType(this);
            }
            catch (Exception ex)
            {
                
            }

            return intialisedType;
        }
    }
}