namespace Koi
{
    using System;

    /// <summary>
    /// The koi registration exception.
    /// </summary>
    public class KoiRegistrationException : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="KoiRegistrationException"/> class.
        /// </summary>
        /// <param name="message">
        /// The message.
        /// </param>
        public KoiRegistrationException(string message)
            : base(message)
        {
        }
    }
}