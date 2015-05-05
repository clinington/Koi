namespace Koi.TypeInitialisationStrategies
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The transient type initialisation strategy.
    /// </summary>
    internal class PerResolveTypeInstantiationStrategy : ITypeInstantiationStrategy
    {
        /// <summary>
        /// The initialise type.
        /// </summary>
        /// <param name="dependency">
        /// The dependency.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object InstantiateType(IDependency dependency)
        {
            var ctor = dependency
                            .Type
                            .GetTypeInfo()
                            .DeclaredConstructors
                            .Where(c => c.IsStatic == false && c.IsPublic)
                            .OrderByDescending(c => c.GetParameters().Length)
                            .FirstOrDefault();

            if (ctor == null || ctor.GetParameters().Length == 0)
            {
                return dependency.ConstructionStrategy.ConstructType(); 
            }

            var initialisedTypes = ctor
                                    .GetParameters()
                                    .Select(x => dependency
                                                        .BuilderContext
                                                        .BuildType(x.ParameterType));

            return ctor.Invoke(initialisedTypes.ToArray());
        }

        /// <summary>
        /// The can handle.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanHandle(Lifetime lifetime)
        {
            return lifetime == Lifetime.PerResolve;
        }
    }
}