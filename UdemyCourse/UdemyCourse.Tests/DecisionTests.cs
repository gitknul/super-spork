using System;
using UdemyCourse.Collections;
using Xunit;

namespace UdemyCourse.Tests;

public class DecisionTests
{
    [Fact]
    public void Test_Create_WithNull_ThrowsException()
    {
        Assert.Throws<ArgumentNullException>(() => new Decision<object>(null));
    }
}