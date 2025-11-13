using System;
using System.Collections.Generic;
using System.Text;

namespace Couriers.Common.Tests
{
    /// <summary>
    /// Contains the constants used accross the tests
    /// </summary>
    public static class TestConstants
    {
        #region Public Fields

        /// <summary>
        /// The empty values for a <see cref="string"/>
        /// </summary>
        public static readonly IEnumerable<TheoryDataRow<string?>> EmptyStringValues =
        [
            new TheoryDataRow<string?>(null),
            new TheoryDataRow<string?>(string.Empty),
            new TheoryDataRow<string?>("  ")
        ];

        #endregion
    }
}
