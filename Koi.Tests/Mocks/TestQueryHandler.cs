namespace Koi.Tests.Mocks
{
    /// <summary>
    /// The test query handler.
    /// </summary>
    public class TestQueryHandler : IQueryHandler<TestQuery, string>
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="string"/>.
        /// </returns>
        public string Handle(TestQuery request)
        {
            return "Hey";
        }
    }
}