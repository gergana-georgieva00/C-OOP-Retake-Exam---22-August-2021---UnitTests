using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;
    private Hero hero;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
        hero = new Hero("name", 3);
    }

    [Test]
    public void CreateHeroWithNullHeroThrows()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }

    [Test]
    public void CreateHeroWithExistentHeroThrows()
    {
        heroRepository.Create(new Hero("name", 3));
        Assert.Throws<InvalidOperationException>(() => heroRepository.Create(new Hero("name", 3)));
    }

    [Test]
    public void RemoveWithNullOrWhitespaceThrows()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Remove(null));
    }

    [Test]
    public void RemoveWorksCorrectly()
    {
        Assert.That(heroRepository.Remove("name"), Is.EqualTo(false));
    }

    [Test]
    public void GetHeroWithHighestLevelWorks()
    {
        heroRepository.Create(hero);
        Assert.That(heroRepository.GetHeroWithHighestLevel(), Is.EqualTo(hero));
    }
}