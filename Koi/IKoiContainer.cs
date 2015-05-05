namespace Koi
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The KoiContainer interface.
    /// </summary>
    public interface IKoiContainer : IDisposable
    {
        /// <summary>
        /// The register instance.
        /// </summary>
        /// <param name="factory">
        /// The factory.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        void RegisterInstance<TConcrete>(Func<object> factory, Lifetime lifetime);

        /// <summary>
        /// The register type.
        /// </summary>
        /// <param name="from">
        /// The from.
        /// </param>
        /// <param name="to">
        /// The to.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        void RegisterType(Type from, Type to, Lifetime lifetime);

        /// <summary>
        /// The resolve.
        /// </summary>
        /// <param name="dependency">
        /// The dependency.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        object Resolve(Type dependency);

        /// <summary>
        /// The resolve all.
        /// </summary>
        /// <param name="dependency">
        ///     The dependency.
        /// </param>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        IEnumerable<object> ResolveAll(Type dependency);
    }
}