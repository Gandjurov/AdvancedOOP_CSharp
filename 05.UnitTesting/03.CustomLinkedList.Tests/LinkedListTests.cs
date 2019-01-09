using NUnit.Framework;
using System;
using System.Linq;
using System.Reflection;

[TestFixture]
public class LinkedListTests
{
    private const int InitialCount = 0;

    [Test]
    public void ConstructorShouldSetCountToZero()
    {
        DynamicList<int> list = new DynamicList<int>();

        Assert.That(list.Count, Is.EqualTo(InitialCount));
    }

    [Test]
    public void IndexOperatorShouldReturnValue()
    {
        DynamicList<int> list = new DynamicList<int>();

        list.Add(13);

        int element = list[0];

        Assert.That(element, Is.EqualTo(13));
    }

    [Test]
    public void IndexOperatorShouldSetValue()
    {
        DynamicList<int> list = new DynamicList<int>();

        list.Add(13);

        list[0] = 42;

        Assert.That(list[0], Is.EqualTo(42));
    }

    [Test]
    [TestCase(-1)]
    [TestCase(int.MaxValue)]
    [TestCase(100)]
    public void IndexOperatorShouldThrowExceptionWhenGettingInvalidIndex(int index)
    {
        DynamicList<int> list = new DynamicList<int>();

        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
        }
        int returnValue = 0;

        Assert.Throws<ArgumentOutOfRangeException>(() => returnValue = list[index]);
    }

    [Test]
    [TestCase(-1)]
    [TestCase(int.MaxValue)]
    [TestCase(100)]
    public void IndexOperatorShouldThrowExceptionWhenSettingInvalidIndex(int index)
    {
        DynamicList<int> list = new DynamicList<int>();

        for (int i = 0; i < 100; i++)
        {
            list.Add(i);
        }

        Assert.Throws<ArgumentOutOfRangeException>(() => list[index] = 69, "Index was " + index);

    }
}

