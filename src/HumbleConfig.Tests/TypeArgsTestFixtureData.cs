using System;
using NUnit.Framework.Interfaces;
using NUnit.Framework.Internal;

namespace HumbleConfig.Tests
{
    public class TypeArgsTestFixtureData : ITestFixtureData
    {
        public TypeArgsTestFixtureData(params Type[] typeArgs)
        {
            TypeArgs = typeArgs;
        }

        public string TestName { get; } = null;

        public RunState RunState { get; } = RunState.Runnable;
        
        public object[] Arguments { get; } = {};

        public IPropertyBag Properties { get; } = new PropertyBag();

        public Type[] TypeArgs { get; }
    }
}