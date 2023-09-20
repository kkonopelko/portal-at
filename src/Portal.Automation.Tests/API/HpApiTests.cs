using FluentAssertions;
using NUnit.Framework;
using Portal.Automation.Api.Clients;
using Portal.Automation.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Portal.Automation.Tests.API
{
    [TestFixture]
    [Category("API")]
    public class HpApiTests
    {
        private HpClient _hpClient;

        [Test]
        [Description("GET /api/characters")]
        public async Task GetAllCharactersAsync_ShouldReturn_200()
        {
            var response = await HpClient.GetAllCharactersAsync();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNullOrEmpty();
            response.Data.Count.Should().NotBe(0);
            response.Data.Should().BeOfType<List<Character>>();
        }

        [Test]
        [Description("GET /api/character/{id}")]
        public async Task GetCharacterByIdAsync_ShouldReturn_200()
        {
            // arrange
            var existingCharacter = new Character
            {
                Id = Guid.Parse("9e3f7ce4-b9a7-4244-b709-dae5c1f1d4a8"),
                Name = "Harry Potter",
                Actor = "Daniel Radcliffe"
            };

            // act
            var response = await HpClient.GetCharacterByIdAsync(existingCharacter.Id);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNullOrEmpty();
            response.Data.FirstOrDefault().Name.Should().Be(existingCharacter.Name);
        }

        [Test]
        [Description("GET /api/character/{id}")]
        public async Task GetCharacterByIdAsync_ShouldReturn_200_IfIdDoesNotExist()
        {
            // arrange
            var notExistingId = Guid.NewGuid();

            // act
            var response = await HpClient.GetCharacterByIdAsync(notExistingId);

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Data.Count.Should().Be(0);
        }

        [Test]
        [Description("GET /api/character/spells")]
        public async Task GetSpellsAsync_ShouldReturn_200()
        {
            // arrange
            var expectedSpell = new Spell
            {
                Id = Guid.Parse("f08c17fa-7bf9-49bf-9fba-a7806815bc80"),
                Name = "Capacious Extremis",
                Description = "Known as the Extension Charm, it's a complicated spell that can greatly expand or extend the capacity of an object or space without affecting it externally"
            };

            // act
            var response = await HpClient.GetSpellsAsync();

            //assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.Content.Should().NotBeNullOrEmpty();
            response.Data.Should().ContainEquivalentOf(expectedSpell);
        }

        private HpClient HpClient => _hpClient ??= new HpClient();
    }
}