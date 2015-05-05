namespace Koi.TypeInitialisationStrategies
{
    /// <summary>
    /// The TypeInstantiationStrategy interface.
    /// </summary>
    internal interface ITypeInstantiationStrategy
    {
        /// <summary>
        /// The type instantiation method.
        /// </summary>
        /// <param name="dependency">
        /// The dependency.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object InstantiateType(IDependency dependency);

        /// <summary>
        /// The can handle.
        /// </summary>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CanHandle(Lifetime lifetime);
    }
}