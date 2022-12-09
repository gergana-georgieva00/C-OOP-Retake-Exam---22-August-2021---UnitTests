using System;
using NUnit.Framework;

public class HeroRepositoryTests
{
    private HeroRepository heroRepository;

    [SetUp]
    public void SetUp()
    {
        heroRepository = new HeroRepository();
    }

    [Test]
    public void CreateHeroWithNullHeroThrows()
    {
        Assert.Throws<ArgumentNullException>(() => heroRepository.Create(null));
    }
}