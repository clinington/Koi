namespace Koi.Tests.Mocks
{
    /// <summary>
    /// The test query handler decorator.
    /// </summary>
    public class TestQueryHandlerDecorator : IQueryHandler<TestQuery, string>
    {
        /// <summary>
        /// The inner.
        /// </summary>
        private readonly IQueryHandler<TestQuery, string> inner;

        /// <summary>
        /// Initializes a new instance of the <see cref="TestQueryHandlerDecorator"/> class.
        /// </summary>
        /// <param name="inner">
        /// The inner.
        /// </param>
        public TestQueryHandlerDecorator(
            IQueryHandler<TestQuery, string> inner)
        {
            this.inner = inner;
        }

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
            var res = this.inner.Handle(request);

            return string.Format("{0} there", res);
        }
    }
}