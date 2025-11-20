using Couriers.Common.ResultTypes;

using System;
using System.Globalization;

namespace Couriers.Common.Tests
{
    /// <summary>
    /// Contains the tests regarding the <see cref="HttpRequestResult"/>
    /// </summary>
    public class HttpRequestResultUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="HttpRequestResultUnitTests"/>
        /// </summary>
        public HttpRequestResultUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with empty error message, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The error message</param>
        [Theory]
        [MemberData(nameof(TestConstants.EmptyStringValues), MemberType = typeof(TestConstants))]
        public void HttpRequestResult_WithEmptyErrorMessage_ThrowsException(string? value)
        {
            var errorMessage = value!;

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult(errorMessage, null, null));

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult<int>(errorMessage, null, null));
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with a valid exception, the <see cref="HttpRequestResult"/> is unsuccessful
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithErrorMessage_IsUnsuccessful()
        {
            var errorMessage = "An error occurred.";

            var requestPayload = TestHelpers.GenerateRandomString(10);

            var responsePayload = TestHelpers.GenerateRandomString(10);

            var result = new HttpRequestResult(errorMessage, requestPayload, responsePayload);

            Assert.False(result.IsSuccessful);

            Assert.Equal(errorMessage, result.ErrorMessage);

            Assert.Equal(requestPayload, result.RequestPayload);

            Assert.Equal(responsePayload, result.ResponsePayload);

            var toStringRepresentation = result.ToString();

            Assert.Equal(errorMessage, toStringRepresentation);

            var genericResult = new HttpRequestResult<object>(errorMessage, requestPayload, responsePayload);

            Assert.False(genericResult.IsSuccessful);

            Assert.Equal(errorMessage, genericResult.ErrorMessage);

            Assert.Equal(requestPayload, genericResult.RequestPayload);

            Assert.Equal(responsePayload, genericResult.ResponsePayload);

            Assert.ThrowsAny<Exception>(() => genericResult.Result);

            toStringRepresentation = genericResult.ToString();

            Assert.Equal(errorMessage, toStringRepresentation);
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with <see langword="null"/> exception, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithNullException_ThrowsException()
        {
            var exception = default(Exception?)!;

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult(exception, null, null));

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult<int>(exception, null, null));
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with a valid exception, the <see cref="HttpRequestResult"/> is unsuccessful
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithAnException_IsUnsuccessful()
        {
            var errorMessage = "An error occurred.";

            var requestPayload = TestHelpers.GenerateRandomString(10);

            var responsePayload = TestHelpers.GenerateRandomString(10);

            var exception = new InvalidCastException(errorMessage);

            var result = new HttpRequestResult(exception, requestPayload, responsePayload);

            Assert.False(result.IsSuccessful);

            Assert.Equal(errorMessage, result.ErrorMessage);

            Assert.Equal(requestPayload, result.RequestPayload);

            Assert.Equal(responsePayload, result.ResponsePayload);

            var toStringRepresentation = result.ToString();

            Assert.Equal(errorMessage, toStringRepresentation);

            var genericResult = new HttpRequestResult<int>(exception, requestPayload, responsePayload);

            Assert.False(genericResult.IsSuccessful);

            Assert.Equal(errorMessage, result.ErrorMessage);

            Assert.Equal(requestPayload, result.RequestPayload);

            Assert.Equal(responsePayload, result.ResponsePayload);

            Assert.ThrowsAny<Exception>(() => genericResult.Result);

            toStringRepresentation = genericResult.ToString();

            Assert.Equal(errorMessage, toStringRepresentation);
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult{T}"/> constructor is called, 
        /// with a valid result, the <see cref="HttpRequestResult"/> is unsuccessful
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithResult_IsSuccessful()
        {
            var requestPayload = TestHelpers.GenerateRandomString(10);

            var responsePayload = TestHelpers.GenerateRandomString(10);

            var value = 5;

            var result = new HttpRequestResult(requestPayload, responsePayload);

            Assert.True(result.IsSuccessful);

            Assert.True(string.IsNullOrWhiteSpace(result.ErrorMessage));

            Assert.Equal(requestPayload, result.RequestPayload);

            Assert.Equal(responsePayload, result.ResponsePayload);

            var toStringRepresentation = result.ToString();

            Assert.Equal(HttpRequestResult.SuccessfulMessage, toStringRepresentation);

            var genericResult = new HttpRequestResult<int>(value, requestPayload, responsePayload);

            Assert.True(genericResult.IsSuccessful);

            Assert.True(string.IsNullOrWhiteSpace(genericResult.ErrorMessage));

            Assert.Equal(requestPayload, genericResult.RequestPayload);

            Assert.Equal(responsePayload, genericResult.ResponsePayload);

            Assert.True(value == genericResult.Result);

            toStringRepresentation = genericResult.ToString();

            Assert.Equal(genericResult.Result.ToString(CultureInfo.InvariantCulture), toStringRepresentation);
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult.FromResult{T}(T, string?, string?)"/> method is called, 
        /// with a valid result, the <see cref="HttpRequestResult"/> is unsuccessful
        /// </summary>
        [Fact]
        public void FromResult_WithResult_IsSuccessful()
        {
            var requestPayload = TestHelpers.GenerateRandomString(10);

            var responsePayload = TestHelpers.GenerateRandomString(10);

            var value = 5;

            var genericResult = HttpRequestResult.FromResult(value, requestPayload, responsePayload);

            Assert.True(genericResult.IsSuccessful);

            Assert.True(string.IsNullOrWhiteSpace(genericResult.ErrorMessage));

            Assert.Equal(requestPayload, genericResult.RequestPayload);

            Assert.Equal(responsePayload, genericResult.ResponsePayload);

            Assert.True(value == genericResult.Result);

            var toStringRepresentation = genericResult.ToString();

            Assert.Equal(genericResult.Result.ToString(CultureInfo.InvariantCulture), toStringRepresentation);
        }

        #endregion

        #endregion
    }
}