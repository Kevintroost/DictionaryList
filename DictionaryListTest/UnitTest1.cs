using FluentAssertions;

[TestFixture]
public class DictionaryTests
{
    private Dictionary<string, int> ages;

    [SetUp]
    public void Setup()
    {
        ages = new Dictionary<string, int>
        {
            { "Alice", 25 },
            { "Bob", 30 },
            { "Charlie", 35 }
        };
    }

    [Test]
    public void Dictionary_ShouldContain_AddedValues()
    {
        ages.Should().ContainKey("Alice").And.ContainValue(25);
        ages.Should().ContainKey("Bob").And.ContainValue(30);
        ages.Should().ContainKey("Charlie").And.ContainValue(35);
    }

    [Test]
    public void AccessingExistingKey_ShouldReturnCorrectValue()
    {
        ages["Alice"].Should().Be(25);
    }

    [Test]
    public void ContainsKey_ShouldReturnTrueForExistingKey()
    {
        ages.ContainsKey("Bob").Should().BeTrue();
    }

    [Test]
    public void ContainsKey_ShouldReturnFalseForNonExistentKey()
    {
        ages.ContainsKey("David").Should().BeFalse();
    }

    [Test]
    public void RemovingKey_ShouldReduceCount()
    {
        ages.Remove("Charlie");
        ages.Should().NotContainKey("Charlie");
        ages.Count.Should().Be(2);
    }

    [Test]
    public void IteratingDictionary_ShouldContainExpectedPairs()
    {
        var expectedEntries = new Dictionary<string, int>
        {
            { "Alice", 25 },
            { "Bob", 30 },
            { "Charlie", 35 }
        };

        ages.Should().BeEquivalentTo(expectedEntries);
    }

    [Test]
    public void AddingDuplicateKey_ShouldThrowException()
    {
        Action act = () => ages.Add("Alice", 40);
        act.Should().Throw<ArgumentException>().WithMessage("*An item with the same key has already been added*");
    }
}