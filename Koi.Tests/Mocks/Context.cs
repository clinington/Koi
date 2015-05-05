namespace Koi.Tests.Mocks
{
    /// <summary>
    /// The Context interface.
    /// </summary>
    public interface IContext
    {
        /// <summary>
        /// Gets the increments.
        /// </summary>
        int Increments { get; }

        /// <summary>
        /// The increment.
        /// </summary>
        /// <param name="num">
        /// The num.
        /// </param>
        void Increment(int num);
    }

    /// <summary>
    /// The context.
    /// </summary>
    public class Context : IContext
    {
        /// <summary>
        /// Gets the increments.
        /// </summary>
        public int Increments { get; private set; }

        /// <summary>
        /// The increment.
        /// </summary>
        /// <param name="num">
        /// The num.
        /// </param>
        public void Increment(int num)
        {
            this.Increments += num;
        }
    }
}
