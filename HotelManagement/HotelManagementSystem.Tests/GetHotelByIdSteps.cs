using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class GetHotelByIdSteps
    {
        private int _id;
        private Hotel _hotelInfoById;
        [Given(@"User has provided a valid '(.*)' to check existence")]
        public void GivenUserHasProvidedAValidToCheckExistence(int p0)
        {
            _id = p0;
        }
        
        [When(@"User calss GetHotelByID api")]
        public void WhenUserCalssGetHotelByIDApi()
        {
            _hotelInfoById = HotelsApiCaller.GetHotelById(_id);
        }
        
        [Then(@"User should get the details of hotel id '(.*)' if present")]
        public void ThenUserShouldGetTheDetailsOfHotelIdIfPresent(int p0)
        {
            _hotelInfoById.Id.Should().Be(p0);
        }
    }
}
