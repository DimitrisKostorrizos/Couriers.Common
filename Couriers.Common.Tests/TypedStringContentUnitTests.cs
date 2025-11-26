using System;

namespace Couriers.Common.Tests
{
    /// <summary>
    /// Contains the tests regarding the <see cref="TypedStringContent"/>
    /// </summary>
    public sealed class TypedStringContentUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="TypedStringContentUnitTests"/>
        /// </summary>
        public TypedStringContentUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="TypedStringContent{TRequest, TResponse}"/> constructors are called, 
        /// with <see langword="null"/> content, an <see cref="Exception"/> is thrown
        /// </summary>
        [Fact]
        public void TypedStringContent_WithNullContent_ThrowsException()
        {
            Assert.ThrowsAny<Exception>(() => new TypedStringContent<int, bool>(null!));

            Assert.ThrowsAny<Exception>(() => new TypedStringContent<int, bool>(null!, encoding: default));

            Assert.ThrowsAny<Exception>(() => new TypedStringContent<int, bool>(null!, encoding: null, mediaType: default));
        }

        /// <summary>
        /// Validates that when <see cref="TypedStringContent{TRequest, TResponse}"/> constructors are called, 
        /// with valid content, request and response types , an expected result is returned
        /// </summary>
        [Fact]
        public void TypedStringContent_WithSuccessfulResult_ThrowsException()
        {
            var stringContent = new TypedStringContent<int, bool>(string.Empty);

            Assert.Equal(typeof(int), stringContent.RequestType);

            Assert.Equal(typeof(bool), stringContent.ResponseType);

            stringContent = new TypedStringContent<int, bool>(string.Empty, encoding: default);

            Assert.Equal(typeof(int), stringContent.RequestType);

            Assert.Equal(typeof(bool), stringContent.ResponseType);

            stringContent = new TypedStringContent<int, bool>(string.Empty, encoding: null, mediaType: default);

            Assert.Equal(typeof(int), stringContent.RequestType);

            Assert.Equal(typeof(bool), stringContent.ResponseType);
        }

        #endregion

        #endregion
    }
}