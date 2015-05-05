namespace Koi.Tests.Mocks
{
    /// <summary>
    /// The mad query handler.
    /// </summary>
    public class MadQueryHandler : IQueryHandler<MadQuery, int>
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int Handle(MadQuery request)
        {
            return 0;
        }
    }
}