using Couriers.Common.Extensions;
using Couriers.Common.ResultTypes;

using System;

namespace Couriers.Common.Tests
{
    /// <summary>
    /// Contains the tests regarding the <see cref="HttpRequestResultExtensions"/>
    /// </summary>
    public sealed class HttpRequestResultExtensionsUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="HttpRequestResultExtensionsUnitTests"/>
        /// </summary>
        public HttpRequestResultExtensionsUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="HttpRequestResultExtensions.ToUnsuccessfulHttpRequestResult{TResult}(IHttpRequestResult, string?)"/> method is called, 
        /// with <see langword="null"/> result, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void ToUnsuccessfulHttpRequestResult_WithNullResult_ThrowsException()
        {
            var httpRequestResult = default(HttpRequestResult?);

            var genericHttpRequestResult = default(HttpRequestResult<int>?);

            Assert.ThrowsAny<Exception>(() => httpRequestResult!.ToUnsuccessfulHttpRequestResult<object>());

            Assert.ThrowsAny<Exception>(() => genericHttpRequestResult!.ToUnsuccessfulHttpRequestResult<object>());
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResultExtensions.ToUnsuccessfulHttpRequestResult{TResult}(IHttpRequestResult, string?)"/> method is called, 
        /// with successful result, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void ToUnsuccessfulHttpRequestResult_WithSuccessfulResult_ThrowsException()
        {
            var requestPayload = TestHelpers.GenerateRandomString(10);

            var responsePayload = TestHelpers.GenerateRandomString(10);

            var httpRequestResult = new HttpRequestResult(requestPayload, responsePayload);

            var genericHttpRequestResult = new HttpRequestResult<int>(0, requestPayload, responsePayload);

            Assert.ThrowsAny<Exception>(() => httpRequestResult.ToUnsuccessfulHttpRequestResult<object>());

            Assert.ThrowsAny<Exception>(() => genericHttpRequestResult.ToUnsuccessfulHttpRequestResult<object>());
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResultExtensions.ToUnsuccessfulHttpRequestResult{TResult}(IHttpRequestResult, string?)"/> method is called, 
        /// with unsuccessful result, the result returned has the same error message
        /// </summary>
        [Fact]
        public void ToUnsuccessfulHttpRequestResult_WithUnsuccessfulResult_TheErrorMessagePersists()
        {
            var exception = new InvalidOperationException("An error occurred.");

            var requestPayload = TestHelpers.GenerateRandomString(10);

            var responsePayload = TestHelpers.GenerateRandomString(10);

            var httpRequestResult = new HttpRequestResult(exception, requestPayload, responsePayload);

            var genericHttpRequestResult = new HttpRequestResult<int>(exception, requestPayload, responsePayload);

            var returnedHttpRequestResult = httpRequestResult.ToUnsuccessfulHttpRequestResult<object>();

            var returnedGenericHttpRequestResult = genericHttpRequestResult.ToUnsuccessfulHttpRequestResult<object>();

            Assert.Equal(returnedHttpRequestResult.ErrorMessage, httpRequestResult.ErrorMessage);

            Assert.Equal(returnedHttpRequestResult.RequestPayload, httpRequestResult.RequestPayload);

            Assert.Equal(returnedHttpRequestResult.ResponsePayload, httpRequestResult.ResponsePayload);

            Assert.Equal(returnedGenericHttpRequestResult.ErrorMessage, genericHttpRequestResult.ErrorMessage);

            Assert.Equal(returnedGenericHttpRequestResult.RequestPayload, genericHttpRequestResult.RequestPayload);

            Assert.Equal(returnedGenericHttpRequestResult.ResponsePayload, genericHttpRequestResult.ResponsePayload);
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResultExtensions.ToUnsuccessfulHttpRequestResult{TResult}(IHttpRequestResult, string?)"/> method is called, 
        /// with unsuccessful result, the result returned has the requested error message
        /// </summary>
        [Fact]
        public void ToUnsuccessfulHttpRequestResult_WithUnsuccessfulResult_TheNewErrorMessageIsUsed()
        {
            var exception = new InvalidOperationException("An error occurred.");

            var requestPayload = TestHelpers.GenerateRandomString(10);

            var responsePayload = TestHelpers.GenerateRandomString(10);

            var newErrorMessage = TestHelpers.GenerateRandomString(10);

            var httpRequestResult = new HttpRequestResult(exception, requestPayload, responsePayload);

            var genericHttpRequestResult = new HttpRequestResult<int>(exception, requestPayload, responsePayload);

            var returnedHttpRequestResult = httpRequestResult.ToUnsuccessfulHttpRequestResult<object>(newErrorMessage);

            var returnedGenericHttpRequestResult = genericHttpRequestResult.ToUnsuccessfulHttpRequestResult<object>(newErrorMessage);

            Assert.Equal(returnedHttpRequestResult.ErrorMessage, newErrorMessage);

            Assert.Equal(returnedHttpRequestResult.RequestPayload, httpRequestResult.RequestPayload);

            Assert.Equal(returnedHttpRequestResult.ResponsePayload, httpRequestResult.ResponsePayload);

            Assert.Equal(returnedGenericHttpRequestResult.ErrorMessage, newErrorMessage);

            Assert.Equal(returnedGenericHttpRequestResult.RequestPayload, genericHttpRequestResult.RequestPayload);

            Assert.Equal(returnedGenericHttpRequestResult.ResponsePayload, genericHttpRequestResult.ResponsePayload);
        }

        #endregion

        #endregion
    }
}