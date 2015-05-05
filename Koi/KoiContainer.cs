namespace Koi
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Koi.ConstructionStrategies;
    using Koi.DependencyFactories;
    using Koi.TypeInitialisationStrategies;

    /// <summary>
    /// The koi container.
    /// </summary>
    public class KoiContainer : IKoiContainer
    {
        /// <summary>
        /// The type dictionary.
        /// </summary>
        private readonly Dictionary<Type, ICollection<Type>> typeDictionary;

        /// <summary>
        /// The strategies.
        /// </summary>
        private readonly List<ITypeInstantiationStrategy> typeInitialisationStrategies;

        /// <summary>
        /// The construction stategies.
        /// </summary>
        private readonly List<IConstructionStrategy> constructionStategies;

        /// <summary>
        /// The builder context.
        /// </summary>
        private readonly BuilderContext builderContext;

        /// <summary>
        /// Initializes a new instance of the <see cref="KoiContainer"/> class.
        /// </summary>
        public KoiContainer()
        {
            this.typeInitialisationStrategies = new List<ITypeInstantiationStrategy>
                                            {
                                                new SingletonTypeInstantiationStrategy(),
                                                new PerResolveTypeInstantiationStrategy()
                                            };

            this.constructionStategies = new List<IConstructionStrategy>
                                            {
                                                new EmptyConstructorConstructionStrategy(),
                                                new FactoryConstructionStrategy()
                                            };

            this.typeDictionary = new Dictionary<Type, ICollection<Type>>();

            this.builderContext = new BuilderContext();
        }

        /// <summary>
        /// The register instance.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <typeparam name="TConcrete">
        /// Concrete instance to be returned
        /// </typeparam>
        public void RegisterInstance<TConcrete>(Func<object> factory, Lifetime lifetime)
        {
            var typeInitialisationStrategy = this.typeInitialisationStrategies.First(x => x.CanHandle(lifetime));
            var constructionStrategy = this.constructionStategies.First(x => x.CanHandle(InitialisationStrategy.FactoryControlled));

            var factoryInstanceDependencyFactory = new FactoryInstanceDependencyFactory
                                                       {
                                                           ConstructionFactory = factory
                                                       };

            var type = typeof(TConcrete);

            this.builderContext.AddConstruction(
                typeInitialisationStrategy,
                constructionStrategy,
                lifetime,
                type,
                type,
                factoryInstanceDependencyFactory);

            this.CreateTypeMapping(type, type);
        }

        /// <summary>
        /// The register type.
        /// </summary>
        /// <param name="typeFrom">
        /// The type From.
        /// </param>
        /// <param name="typeTo">
        /// The type To.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        public void RegisterType(Type typeFrom, Type typeTo, Lifetime lifetime)
        {
            if (typeFrom != null)
            {
                if (typeTo != null)
                {
                    // here we will be register the from to the to
                    if (!typeFrom.IsInterface)
                    {
                        throw new KoiRegistrationException("Registration from type isn't an interface");
                    }

                    if (!typeTo.GetInterfaces().Contains(typeFrom))
                    {
                        throw new KoiRegistrationException("Registration type to doesn't implement type from");
                    }
                }
                else
                {
                    // register the type against itself 
                    typeTo = typeFrom;
                }

                var typeInitialisationStrategy = this.typeInitialisationStrategies.First(x => x.CanHandle(lifetime));
                var constructionStrategy = this.constructionStategies.First(x => x.CanHandle(InitialisationStrategy.LifetimeControlled));

                var emptyConstructorDependencyFactory = new EmptyConstructorDependencyFactory();

                this.builderContext.AddConstruction(
                    typeInitialisationStrategy,
                    constructionStrategy,
                    lifetime,
                    typeTo, 
                    typeFrom,
                    emptyConstructorDependencyFactory);

                this.CreateTypeMapping(typeFrom, typeTo);
            }
            else
            {
                throw new KoiRegistrationException("Can't register from a null type");
            }
        }

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <param name="dependency">
        /// The dependency.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object Resolve(Type dependency)
        {
            return this.builderContext.BuildType(dependency);
        }

        /// <summary>
        /// The resolve all.
        /// </summary>
        /// <param name="dependency">
        ///     The dependency.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public IEnumerable<object> ResolveAll(Type dependency)
        {
            return this.builderContext.BuildTypes(dependency);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        /// <summary>
        /// The dispose.
        /// </summary>
        /// <param name="disposing">
        /// The disposing.
        /// </param>
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
            }
        }

        /// <summary>
        /// The create type mapping.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        private void CreateTypeMapping(Type from, Type to)
        {
            if (!this.typeDictionary.ContainsKey(from))
            {
                this.typeDictionary.Add(from, new List<Type>());
            }

            this.typeDictionary[from].Add(to);
        }

        public void RegisterDecorators(Type typeToDecorate, List<Type> decoratingTypes)
        {
            this.builderContext.DecorateConstruction(typeToDecorate, decoratingTypes);
        }
    }
}
