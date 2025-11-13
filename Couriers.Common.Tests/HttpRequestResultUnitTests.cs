using Couriers.Common.ResultTypes;

using System;
using System.Collections.Generic;

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

#pragma warning disable CA1707 // Identifiers should not contain underscores

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with empty error message, an <see cref="Exception"/> is thrown
        /// </summary>
        /// <param name="value">The error message</param>
        [Theory]
        [MemberData(nameof(TestConstants.EmptyStringValues), MemberType = typeof(TestConstants))]
        public void HttpRequestResult_WithEmptyErrorMessage_AnExceptionIsThrown(string? value)
        {
            var errorMessage = value!;

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult(errorMessage));

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult<object>(errorMessage));
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with a valid exception, the <see cref="HttpRequestResult"/> is unsuccessful
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithErrorMessage_IsUnsuccessful()
        {
            var errorMessage = "An error occurred.";

            var result = new HttpRequestResult(errorMessage);

            Assert.False(result.IsSuccessful);

            Assert.False(string.IsNullOrWhiteSpace(result.ErrorMessage));

            var genericResult = new HttpRequestResult<object>(errorMessage);

            Assert.False(genericResult.IsSuccessful);

            Assert.False(string.IsNullOrWhiteSpace(genericResult.ErrorMessage));

            Assert.ThrowsAny<Exception>(() => genericResult.Result);
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with <see langword="null"/> exception, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithNullException_AnExceptionIsThrown()
        {
            var exception = default(Exception?)!;

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult(exception, null, null));

            Assert.ThrowsAny<Exception>(() => new HttpRequestResult<object>(exception, null, null));
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult"/> constructor is called, 
        /// with a valid exception, the <see cref="HttpRequestResult"/> is unsuccessful
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithAnException_IsUnsuccessful()
        {
            var exception = new InvalidCastException();

            var result = new HttpRequestResult(exception, null, null);

            Assert.False(result.IsSuccessful);

            Assert.False(string.IsNullOrWhiteSpace(result.ErrorMessage));

            var genericResult = new HttpRequestResult<object>(exception, null, null);

            Assert.False(genericResult.IsSuccessful);

            Assert.False(string.IsNullOrWhiteSpace(genericResult.ErrorMessage));

            Assert.ThrowsAny<Exception>(() => genericResult.Result);
        }

        /// <summary>
        /// Validates that when <see cref="HttpRequestResult{T}"/> constructor is called, 
        /// with a valid result, the <see cref="HttpRequestResult"/> is unsuccessful
        /// </summary>
        [Fact]
        public void HttpRequestResult_WithResult_IsSuccessful()
        {
            var testString = "Test";

            var result = new object();

            var genericResult = new HttpRequestResult<object>(result, testString, testString);

            Assert.True(genericResult.IsSuccessful);

            Assert.True(string.IsNullOrWhiteSpace(genericResult.ErrorMessage));

            Assert.True(result == genericResult.Result);
        }

#pragma warning restore CA1707 // Identifiers should not contain underscores

        #endregion

        #endregion
    }
}