namespace Koi.ConstructionStrategies
{
    /// <summary>
    /// The ConstructionStrategy interface.
    /// </summary>
    internal interface IConstructionStrategy
    {
        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object ConstructType();

        /// <summary>
        /// The can handle.
        /// </summary>
        /// <param name="instantiationStrategy">
        /// The instantiation Strategy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        bool CanHandle(InstantiationStrategy instantiationStrategy);
    }
}
