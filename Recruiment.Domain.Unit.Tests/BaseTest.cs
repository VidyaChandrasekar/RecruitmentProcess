using Moq;
using System;
using Xunit;

namespace Recruiment.Domain.Unit.Tests
{
    public class BaseTest
    {
        public BaseTest ()
        {
            MockRepository = new MockRepository(MockBehavior.Strict);
        }
       public MockRepository MockRepository { get; set; }
    }
}
