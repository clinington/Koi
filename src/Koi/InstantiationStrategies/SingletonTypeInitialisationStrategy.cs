namespace Koi.InstantiationStrategies
{
    /// <summary>
    /// The singleton instantiation strategy.
    /// </summary>
    internal class SingletonInstantiationStrategy : IInstantiationStrategy
    {
        /// <summary>
        /// The instantiated type.
        /// </summary>
        private object instantiatedType;

        /// <summary>
        /// The instantiate type.
        /// </summary>
        /// <param name="dependency">
        /// The dependency.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object InstantiateType(IDependency dependency)
        {
            if (this.instantiatedType == null)
            {
                this.instantiatedType = new PerResolveInstantiationStrategy().InstantiateType(dependency);
            }

            return this.instantiatedType;
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