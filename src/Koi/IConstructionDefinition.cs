namespace Koi
{
    /// <summary>
    /// The ConstructionDefinition interface.
    /// </summary>
    internal interface IConstructionDefinition
    {
        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="IDependency"/>.
        /// </returns>
        IDependency ConstructType();
    }
}