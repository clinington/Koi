namespace Koi.Tests.Mocks
{
    /// <summary>
    /// The QueryHandler interface.
    /// </summary>
    /// <typeparam name="TRequest">
    /// The Request
    /// </typeparam>
    /// <typeparam name="TResponse">
    /// The Response
    /// </typeparam>
    public interface IQueryHandler<TRequest, TResponse>
        where TRequest : IQuery<TResponse>
    {
        /// <summary>
        /// The handle.
        /// </summary>
        /// <param name="request">
        /// The request.
        /// </param>
        /// <returns>
        /// The <see cref="TResponse"/>.
        /// </returns>
        TResponse Handle(TRequest request);
    }
}