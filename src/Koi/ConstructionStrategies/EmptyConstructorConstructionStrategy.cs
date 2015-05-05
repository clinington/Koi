namespace Koi.ConstructionStrategies
{
    using System;

    /// <summary>
    /// The empty constructor construction strategy.
    /// </summary>
    internal class EmptyConstructorConstructionStrategy : IConstructionStrategy
    {
        /// <summary>
        /// The type to initialise.
        /// </summary>
        private Type typeToInitialise;

        /// <summary>
        /// The construct type.
        /// </summary>
        /// <returns>
        /// The <see cref="object"/>.
        /// </returns>
        public object ConstructType()
        {
            return Activator.CreateInstance(this.typeToInitialise);
        }

        /// <summary>
        /// The set type.
        /// </summary>
        /// <param name="typeToInitialise">
        /// The type to initialise.
        /// </param>
        public void SetType(Type typeToInitialise)
        {
            this.typeToInitialise = typeToInitialise;
        }

        /// <summary>
        /// The can handle.
        /// </summary>
        /// <param name="initialisationStrategy">
        /// The initialisation strategy.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool CanHandle(InitialisationStrategy initialisationStrategy)
        {
            return initialisationStrategy == InitialisationStrategy.LifetimeControlled;
        }
    }
}
