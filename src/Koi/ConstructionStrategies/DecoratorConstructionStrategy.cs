namespace Koi.ConstructionStrategies
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The decorator instantiation strategy.
    /// </summary>
    internal class DecoratorConstructionStrategy : IConstructionStrategy
    {
        /// <summary>
        /// Gets or sets the decorated type, i.e. the one that is going to get pass through the constructor.
        /// </summary>
        public object DecoratedInstance { get; set; }

        /// <summary>
        /// Gets or sets the dependency.
        /// </summary>
        public IDependency Dependency { get; set; }

        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object ConstructType()
        {
            var ctor = this.Dependency
                            .Type
                            .GetTypeInfo()
                            .DeclaredConstructors
                            .Where(c => c.IsStatic == false && c.IsPublic)
                            .OrderByDescending(c => c.GetParameters().Length)
                            .FirstOrDefault();

            if (ctor == null || ctor.GetParameters().Length == 0)
            {
                throw new KoiResolutionException("Cannot use decorator that doesn't accept at least the decorated class as a constructor argument");
            }

            // check they share the same type
            var dependencyType = this.Dependency.Type.GetInterfaces().First();

            var decoratorType = this.DecoratedInstance.GetType().GetInterfaces().First();

            if (dependencyType != decoratorType)
            {
                throw new KoiResolutionException("Decorator and decorated types must share the same interface. If the interface is a closed generic type - they must also be shared.");
            }

            var instantiatedTypes = ctor
                                    .GetParameters()
                                    .Skip(1)
                                    .Select(x => this.Dependency
                                                        .BuilderContext
                                                        .BuildType(x.ParameterType));

            var instantiatedTypesArray = instantiatedTypes.ToArray(); // prevents multiple enumeration... possibly

            var instantiatedTypesList = instantiatedTypesArray.Reverse().ToList();

            instantiatedTypesList.Add(this.DecoratedInstance);
            instantiatedTypesList.Reverse();

            return ctor.Invoke(instantiatedTypesList.ToArray());
        }

        /// <summary>
        /// The can handle.
        /// </summary>
        /// <param name="instantiationStrategy">
        /// The instantiation strategy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanHandle(InstantiationStrategy instantiationStrategy)
        {
            return instantiationStrategy == InstantiationStrategy.LifetimeControlled;
        }
    }
}
