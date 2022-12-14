using System;
using System.Collections.Generic;
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
        var hero2 = new Hero("otherName", 5);
        heroRepository.Create(hero);
        heroRepository.Create(hero2);

        Assert.That(heroRepository.GetHeroWithHighestLevel(), Is.EqualTo(hero2));
    }

    [Test]
    public void GetHeroWorks()
    {
        heroRepository.Create(hero);
        Assert.That(heroRepository.GetHero("name"), Is.EqualTo(hero));
    }

    [Test]
    public void HeroesGetterWorks()
    {
        var collection = new List<Hero>() { hero };
        heroRepository.Create(hero);
        Assert.That(heroRepository.Heroes, Is.EqualTo(collection));
    }
}