using System;
using System.Collections;
using System.Collections.Generic;
using Moq;
using NUnit.Framework;

namespace toy
{
    [TestFixture]
    public class RandomTests
    {
        [Test]
        public void ShouldBeAbleToAccessFieldsOfAnonymousType()
        {
            var fish = new { Likes = "Plankton" };
            Assert.That(fish.Likes, Is.EqualTo("Plankton"));
        }

        [Test]
        public void ShouldBeAbleToAccessFieldsOfAnonymousWithoutTypeInfo()
        {
            var fish = new { Likes = "Plankton" };
            Assert.That(fish.GetType().GetProperty("Likes").GetValue(fish, null), Is.EqualTo("Plankton"));
        }

        [Test]
        public void ShouldBeAbleToVerifyParameter()
        {
            var mock = new Mock<IList>();
            var list = mock.Object;
            list.Add("Salt");

            mock.Verify(obj => obj.Add("Salt"));
        }

        [Test]
        public void ShouldBeAbleToVerifyAnonymousTypeParameter()
        {
            var mock = new Mock<IList>();
            var list = mock.Object;
            list.Add(new {Buy = "Pepper"});

            mock.Verify(obj => obj.Add(ToStringContaining("Pepper")));
        }

        private object ToStringContaining(string subString)
        {
            return Match<object>.Create(o => o.ToString().Contains(subString));
        }
    }
}
