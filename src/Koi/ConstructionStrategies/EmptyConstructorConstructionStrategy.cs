namespace Koi.ConstructionStrategies
{
    using System;

    /// <summary>
    /// The empty constructor construction strategy.
    /// </summary>
    internal class EmptyConstructorConstructionStrategy : IConstructionStrategy
    {
        /// <summary>
        /// The type to instantiate.
        /// </summary>
        private Type typeToInstantiate;

        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object ConstructType()
        {
            return Activator.CreateInstance(this.typeToInstantiate);
        }

        /// <summary>
        /// The set type.
        /// </summary>
        /// <param name="typeToInstantiate">
        /// The type To Instantiate.
        /// </param>
        public void SetType(Type typeToInstantiate)
        {
            this.typeToInstantiate = typeToInstantiate;
        }

        /// <summary>
        /// The can handle.
        /// </summary>
        /// <param name="instantiationStrategy">
        /// The instantiation Strategy.
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
