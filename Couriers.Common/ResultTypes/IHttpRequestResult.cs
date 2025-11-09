using System.Diagnostics.CodeAnalysis;

namespace Couriers.Common.ResultTypes
{
    /// <summary>
    /// Provides abstraction for the result of a HTTP request
    /// </summary>
    public interface IHttpRequestResult
    {
        #region Properties

        /// <summary>
        /// The error message
        /// </summary>
        string? ErrorMessage { get; }

        /// <summary>
        /// A flag indicating whether the operation was successful
        /// </summary>
        [MemberNotNullWhen(false, nameof(ErrorMessage))]
        bool IsSuccessful { get; }

        /// <summary>
        /// The request payload
        /// </summary>
        string? RequestPayload { get; }

        /// <summary>
        /// The response payload
        /// </summary>
        string? ResponsePayload { get; }

        #endregion
    }

    /// <summary>
    /// Provides abstraction for the result of a HTTP request that returns a <typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The result of the operation</typeparam>
    public interface IHttpRequestResult<out T> : IHttpRequestResult
    {
        #region Properties

        /// <summary>
        /// The result of the operation
        /// </summary>
        public T Result { get; }

        #endregion
    }
}