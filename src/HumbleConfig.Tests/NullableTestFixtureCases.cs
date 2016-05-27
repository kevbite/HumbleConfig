using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework.Internal;

namespace HumbleConfig.Tests
{
    public class NullableTestFixtureCases : IEnumerable
    {
        public IEnumerable<Type> GetTypes()
        {  
            yield return typeof(bool?);
            yield return typeof(byte?);
            yield return typeof(char?);
            yield return typeof(decimal?);
            yield return typeof(double?);
            yield return typeof(float?);
            yield return typeof(int?);
            yield return typeof(long?);
            yield return typeof(sbyte?);
            yield return typeof(short?);
            yield return typeof(string);
        }

        public IEnumerator GetEnumerator()
        {
            return GetTypes().Select(type => new TestFixtureParameters(new TypeArgsTestFixtureData(type))).GetEnumerator();
        }
    }
}