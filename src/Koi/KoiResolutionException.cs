namespace Koi
{
    using System;

    /// <summary>
    /// The koi resolution exception.
    /// </summary>
    internal class KoiResolutionException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KoiResolutionException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public KoiResolutionException(string message)
            : base(message)
        {
        }
    }
}