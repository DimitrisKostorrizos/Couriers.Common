using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Couriers.Common.Types
{
    /// <summary>
    /// Represents an inline array containing only a single element of type<typeparamref name="T"/>
    /// </summary>
    /// <typeparam name="T">The type of the element</typeparam>
    [InlineArray(1)]
    public struct SingleElementInlineArray<T> : IEnumerable<T>
    {
        #region Private Fields

        /// <summary>
        /// The element
        /// </summary>
#pragma warning disable S2933 // Fields that are only assigned in the constructor should be "readonly"
        private T _element;
#pragma warning restore S2933 // Fields that are only assigned in the constructor should be "readonly"

        #endregion

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="SingleElementInlineArray{T}"/>
        /// </summary>
        /// <param name="element">The element</param>
        public SingleElementInlineArray(T element)
        {
            _element = element;
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        public readonly IEnumerator<T> GetEnumerator()
        {
            yield return _element;
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>
        readonly IEnumerator IEnumerable.GetEnumerator() 
            => GetEnumerator();

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <returns></returns>c
        [ExcludeFromCodeCoverage]
        public override readonly string ToString()
        {
            if (_element is null)
                return string.Empty;

            var stringRespresentation = _element.ToString();

            if (string.IsNullOrWhiteSpace(stringRespresentation))
                return string.Empty;

            return stringRespresentation;
        }

        #endregion
    }
}