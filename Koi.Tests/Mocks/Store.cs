namespace Koi.Tests.Mocks
{
    /// <summary>
    /// The Store interface.
    /// </summary>
    public interface IStore
    {
        /// <summary>
        /// Gets the id.
        /// </summary>
        int Id { get; }

        /// <summary>
        /// The set id.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        void SetId(int value);
    }

    /// <summary>
    /// The store.
    /// </summary>
    public class Store : IStore
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Store"/> class.
        /// </summary>
        public Store()
        {
            this.Id = 10;
        }

        /// <summary>
        /// Gets the id.
        /// </summary>
        public int Id { get; private set; }

        /// <summary>
        /// The set id.
        /// </summary>
        /// <param name="value">
        /// The value.
        /// </param>
        public void SetId(int value)
        {
            this.Id = value;
        }
    }
}
