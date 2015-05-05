namespace Koi
{
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// The koi container extensions.
    /// </summary>
    public static class KoiContainerExtensions
    {
        /// <summary>
        /// The register types from assembly.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="containingAssembly">
        /// The containing assembly.
        /// </param>
        public static void RegisterTypesFromAssembly(this IKoiContainer container, Assembly containingAssembly)
        {
            var classes = containingAssembly
                            .GetTypes()
                            .Where(x => x.IsClass && x.GetInterfaces().Any());

            classes.ToList().ForEach(x => container.RegisterType(x.GetInterfaces().First(), x, Lifetime.PerResolve));
        }


        /// <summary>
        /// The register type.
        /// </summary>
        /// <param name="container">
        /// The container.
        /// </param>
        /// <param name="lifetime">
        /// The lifetime.
        /// </param>
        /// <typeparam name="TInteface">
        /// Type to bound from
        /// </typeparam>
        /// <typeparam name="TConcrete">
        /// Type to bind
        /// </typeparam>
        public static void RegisterType<TInteface, TConcrete>(this IKoiContainer container, Lifetime lifetime) where TConcrete : class, TInteface
        {
            container.RegisterType(typeof(TInteface), typeof(TConcrete), lifetime);
        }

    }
}
