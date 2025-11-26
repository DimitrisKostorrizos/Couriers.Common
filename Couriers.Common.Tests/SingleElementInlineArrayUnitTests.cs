using Couriers.Common.Types;

using System.Collections;

namespace Couriers.Common.Tests
{
    /// <summary>
    /// Contains the tests regarding the <see cref="SingleElementInlineArray{T}"/>
    /// </summary>
    public sealed class SingleElementInlineArrayUnitTests
    {
        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SingleElementInlineArrayUnitTests"/>
        /// </summary>
        public SingleElementInlineArrayUnitTests() : base()
        {

        }

        #endregion

        #region Public Methods

        #region Test Methods

        /// <summary>
        /// Validates that when <see cref="SingleElementInlineArray{T}"/> constructor is called, 
        /// with a single value, returns the expected result
        /// </summary>
        [Fact]
        public void SingleElementInlineArray_WithSingleValue_ReturnsExpectedResult()
        {
            var array = new SingleElementInlineArray<object>();

            Assert.Null(array[0]);

            Assert.Single(array);

            var value = new object();

            array = new SingleElementInlineArray<object>(value);

            Assert.NotNull(array[0]);

            Assert.Equal(value, array[0]);

            Assert.Single(array);

            array = new SingleElementInlineArray<object>();

            array[0] = value;

            Assert.NotNull(array[0]);

            Assert.Equal(value, array[0]);

            Assert.Single(array);

            var enumerable = (IEnumerable)array;

            AssertEnumerable(enumerable, 1);
        }

        #endregion

        #endregion

        #region Private Methods

        /// <summary>
        /// Asserts whether the <paramref name="enumerable"/> is valid and has a count of elements equal to <paramref name="count"/>
        /// </summary>
        /// <param name="enumerable">The enumerable</param>
        /// <param name="count">The count of elements</param>
        private static void AssertEnumerable(IEnumerable enumerable, int count)
        {
            var index = 0;

            var enumerator = enumerable.GetEnumerator();

            Assert.NotNull(enumerator);

            Assert.Null(enumerator.Current);

            bool hasNextElement;

            while (index != count)
            {
                hasNextElement = enumerator.MoveNext();

                Assert.True(hasNextElement);

                Assert.NotNull(enumerator.Current);

                index++;
            }

            hasNextElement = enumerator.MoveNext();

            Assert.False(hasNextElement);
        }

        #endregion
    }
}