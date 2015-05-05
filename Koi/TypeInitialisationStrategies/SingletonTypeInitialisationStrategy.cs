namespace Koi.TypeInitialisationStrategies
{
    /// <summary>
    /// The singleton type initialisation strategy.
    /// </summary>
    internal class SingletonTypeInstantiationStrategy : ITypeInstantiationStrategy
    {
        /// <summary>
        /// The initialised type.
        /// </summary>
        private object initialisedType;

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
            if (this.initialisedType == null)
            {
                this.initialisedType = new PerResolveTypeInstantiationStrategy().InstantiateType(dependency);
            }

            return this.initialisedType;
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
            return lifetime == Lifetime.Singleton;
        }
    }
}