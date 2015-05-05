namespace Koi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Koi.ConstructionStrategies;
    using Koi.DependencyFactories;
    using Koi.TypeInitialisationStrategies;

    /// <summary>
    /// The builder context.
    /// </summary>
    internal class BuilderContext
    {
        /// <summary>
        /// The construction mappings.
        /// </summary>
        private readonly Dictionary<Type, ICollection<IConstructionDefinition>> constructionMappings;

        /// <summary>
        /// Initializes a new instance of the <see cref="BuilderContext"/> class.
        /// </summary>
        public BuilderContext()
        {
            this.constructionMappings = new Dictionary<Type, ICollection<IConstructionDefinition>>();
        }

        /// <summary>
        /// The add construction.
        /// </summary>
        /// <param name="typeInstantiationStrategy">
        /// The type initialisation strategy.
        /// </param>
        /// <param name="constructionStrategy">
        /// The construction strategy.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <param name="typeToConstruct">
        /// The type to construct.
        /// </param>
        /// <param name="key"></param>
        /// <param name="dependencyFactory">
        /// The dependency factory.
        /// </param>
        /// <exception cref="KoiRegistrationException">
        /// Thrown if two types are trying to be registered.
        /// </exception>
        public void AddConstruction(
            ITypeInstantiationStrategy typeInstantiationStrategy,
            IConstructionStrategy constructionStrategy,
            Lifetime lifetime,
            Type typeToConstruct,
            Type key,
            IDependencyFactory dependencyFactory)
        {
            if (!this.constructionMappings.ContainsKey(key))
            {
                this.constructionMappings.Add(key, new List<IConstructionDefinition>());
            }

            this.constructionMappings[key].Add(
                new ConstructionDefinition(
                    typeToConstruct,
                    typeInstantiationStrategy,
                    constructionStrategy,
                    dependencyFactory,
                    lifetime,
                    this));
        }

        /// <summary>
        /// The build type.
        /// </summary>
        /// <param name="typeToConstruct">
        /// The type to construct.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object BuildType(Type typeToConstruct)
        {
            var constructionDefinition = this.constructionMappings[typeToConstruct].FirstOrDefault();

            if (constructionDefinition == null)
            {
                return null;
            }

            return constructionDefinition.ConstructType().InstantiateType();
        }

        /// <summary>
        /// The build type.
        /// </summary>
        /// <param name="typeToConstruct">
        /// The type to construct.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public IEnumerable<object> BuildTypes(Type typeToConstruct)
        {
            if (typeToConstruct.IsGenericTypeDefinition)
            {
                // this is an open generic
                var genericTypes = this.constructionMappings.Keys.Where(
                    x => x.IsGenericType && x.GetGenericTypeDefinition() == typeToConstruct);

                var typesToResolve = this.constructionMappings.Where(x => genericTypes.Any(y => x.Key == y)).SelectMany(x => x.Value);

                return typesToResolve.Select(x => x.ConstructType().InstantiateType());
            }

            return this.constructionMappings[typeToConstruct].Select(x => x.ConstructType().InstantiateType());
        }

        public void DecorateConstruction(Type typeToDecorate, List<Type> decoratingTypes)
        {
            var constructionDefinition = this.constructionMappings[typeToDecorate];

            constructionDefinition.
        }
    }
}
