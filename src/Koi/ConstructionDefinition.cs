namespace Koi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Koi.ConstructionStrategies;
    using Koi.DependencyFactories;
    using Koi.InstantiationStrategies;

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
        /// The context.
        /// </summary>
        private readonly BuilderContext context;

        /// <summary>
        /// The construction strategy.
        /// </summary>
        private readonly IConstructionStrategy constructionStrategy;

        /// <summary>
        /// The instantiation strategy.
        /// </summary>
        private readonly IInstantiationStrategy instantiationStrategy;

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
        /// <param name="instantiationStrategy">
        /// The instantiation strategy.
        /// </param>
        /// <param name="constructionStrategy">
        /// The construction strategy.
        /// </param>
        /// <param name="dependencyFactory">
        /// The dependency factory.
        /// </param>
        /// <param name="context">
        /// The context.
        /// </param>
        public ConstructionDefinition(
            Type typeToConstruct, 
            IInstantiationStrategy instantiationStrategy, 
            IConstructionStrategy constructionStrategy, 
            IDependencyFactory dependencyFactory, 
            BuilderContext context)
        {
            this.typeToConstruct = typeToConstruct;
            this.instantiationStrategy = instantiationStrategy;
            this.constructionStrategy = constructionStrategy;
            this.dependencyFactory = dependencyFactory;
            this.context = context;
        }

        /// <summary>
        /// Gets or sets the decorators.
        /// </summary>
        public List<Type> Decorators { get; set; }

        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependency"/>.
        /// </returns>
        public object ConstructType()
        {
            var dependency = this.dependencyFactory.Create(
                    this.context,
                    this.instantiationStrategy,
                    this.constructionStrategy,
                    this.typeToConstruct);

            var instantiatedType = dependency.InstantiationStrategy.InstantiateType(dependency);

            if (this.Decorators == null || !this.Decorators.Any())
            {
                return instantiatedType;
            }

            foreach (var decorator in this.Decorators)
            {
                var constructionStrat = new DecoratorConstructionStrategy
                                            {
                                                DecoratedInstance = instantiatedType,
                                                Dependency = new Dependency(
                                                    this.context,
                                                    null,
                                                    null,
                                                    decorator)
                                            };

                instantiatedType = constructionStrat.ConstructType();    
            }

            return instantiatedType;
        }
    }
}