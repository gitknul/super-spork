using System;
using System.Drawing;
using UdemyCourse.Collections;
using UdemyCourse.Tests.Models;
using Xunit;

namespace UdemyCourse.Tests;

public class DecisionTreeTests
{
    Func<Fruit, bool> colorFunc = (fruit) => fruit.Color == KnownColor.Green || fruit.Color == KnownColor.Red; 
    Func<Fruit, bool> shapeFunc = (fruit) => fruit.Shape == Shape.Round; 
    Func<Fruit, bool> hardNessFunc = (fruit) => fruit.Hardness == Hardness.Hard;

    static readonly Fruit apple = new ()
    {
        Color = KnownColor.Green,
        Shape = Shape.Round,
        Hardness = Hardness.Hard
    };

    static readonly Fruit banana = new ()
    {
        Color = KnownColor.Yellow,
        Shape = Shape.Rectangle,
        Hardness = Hardness.Soft
    };

    static readonly Fruit nonRipeBanana = new ()
    {
        Color = KnownColor.Green,
        Shape = Shape.Rectangle,
        Hardness = Hardness.Soft
    };

    [InlineData(false)]
    [InlineData(true)]
    [Theory]
    public void Test_Evaluate_Constant(bool value)
    {
        DecisionTree<Fruit> isAppleTree = new(new Decision<Fruit>(_ => value));
        
        Assert.Equal(value, isAppleTree.Evaluate(new Fruit()));
    }
    
    [Fact]
    public void Test_Evaluate_ThreeLevels_ShouldBeTrue()
    {
        DecisionTree<Fruit> isAppleTree = new(
            new Decision<Fruit>(colorFunc, 
                new Decision<Fruit>(shapeFunc,
                    new Decision<Fruit>(hardNessFunc)))
            );
        
        Assert.True(isAppleTree.Evaluate(apple));
    }
    
    [Fact]
    public void Test_Evaluate_ThreeLevels_ShouldBeFalse()
    {
        DecisionTree<Fruit> isAppleTree = new(
            new Decision<Fruit>(colorFunc, 
                new Decision<Fruit>(shapeFunc,
                    new Decision<Fruit>(hardNessFunc)))
            );
        
        Assert.False(isAppleTree.Evaluate(banana));
    }
    
    [Fact]
    public void Test_Evaluate_ThreeLevels_FailsOnSecondLevel_ShouldBeFalse()
    {
        DecisionTree<Fruit> isAppleTree = new(
            new Decision<Fruit>(colorFunc, 
                new Decision<Fruit>(shapeFunc,
                    new Decision<Fruit>(hardNessFunc)))
            );
        
        Assert.False(isAppleTree.Evaluate(nonRipeBanana));
    }

    [Fact]
    public void Test_CreateWithNull_ThrowsArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new DecisionTree<object>(null));
    }
}