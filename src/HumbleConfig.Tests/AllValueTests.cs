using NUnit.Framework;

namespace HumbleConfig.Tests
{
    [TestFixture(typeof (bool))]
    [TestFixture(typeof (byte))]
    [TestFixture(typeof (char))]
    [TestFixture(typeof (decimal))]
    [TestFixture(typeof (double))]
    [TestFixture(typeof (float))]
    [TestFixture(typeof (int))]
    [TestFixture(typeof (long))]
    [TestFixture(typeof (sbyte))]
    [TestFixture(typeof (short))]
    [TestFixture(typeof(bool?))]
    [TestFixture(typeof(byte?))]
    [TestFixture(typeof(char?))]
    [TestFixture(typeof(decimal?))]
    [TestFixture(typeof(double?))]
    [TestFixture(typeof(float?))]
    [TestFixture(typeof(int?))]
    [TestFixture(typeof(long?))]
    [TestFixture(typeof(sbyte?))]
    [TestFixture(typeof(short?))]
    [TestFixture(typeof(string))]
    public abstract class AllValueTests<TValue>
    {
        
    }
}