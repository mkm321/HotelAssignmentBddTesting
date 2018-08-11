using FluentAssertions;
using HotelManagementSystem.Models;
using System;
using System.Collections.Generic;
using TechTalk.SpecFlow;

namespace HotelManagementSystem.Tests
{
    [Binding]
    public class AddHotelSteps
    {
        private Hotel hotel = new Hotel();
        private Hotel addHotelResponse;
        private List<Hotel> hotels = new List<Hotel>();
        private List<Hotel> _getHotels = new List<Hotel>();
        [Given(@"User provided valid Id '(.*)'  and '(.*)' for hotel")]
        [Given(@"User provided valid Id '(.*)'  and '(.*)'for hotel")]
        public void GivenUserProvidedValidIdAndForHotel(int id, string name)
        {
            hotel.Id = id;
            hotel.Name = name;
        }

        [Given(@"Use has added required details for hotel")]
        public void GivenUseHasAddedRequiredDetailsForHotel()
        {
            SetHotelBasicDetails();
        }
        [Given(@"User calls AddHotel api")]
        [When(@"User calls AddHotel api")]
        public void WhenUserCallsAddHotelApi()
        {
            hotels = HotelsApiCaller.AddHotel(hotel);
        }

        [Then(@"Hotel with name '(.*)' should be present in the response")]
        public void ThenHotelWithNameShouldBePresentInTheResponse(string name)
        {
            hotel = hotels.Find(htl => htl.Name.ToLower().Equals(name.ToLower()));
            hotel.Should().NotBeNull(string.Format("Hotel with name {0} not found in response",name));
        }


        private void SetHotelBasicDetails()
        {
            hotel.ImageURLs = new List<string>() { "image1", "image2" };
            hotel.LocationCode = "Location";
            hotel.Rooms = new List<Room>() { new Room() { NoOfRoomsAvailable = 10, RoomType = "delux" } };
            hotel.Address = "Address1";
            hotel.Amenities = new List<string>() { "swimming pool", "gymnasium" };
        }
        [When(@"User calls GetHotels api")]
        public void WhenUserCallsGetHotelsApi()
        {
            _getHotels = HotelsApiCaller.GetAllHotels();
        }
        [Then(@"User should get the details of hotel with id (.*)")]
        public void ThenUserShouldGetTheDetailsOfHotelWithId(string ids)
        {
            int[] data = Array.ConvertAll<string, int>(ids.Split(','), delegate (string s) { return Int32.Parse(s); });
            foreach (int id in data)
            {
                hotel = _getHotels.Find(htl => htl.Id == id);
                hotel.Should().NotBeNull(string.Format("Hotel with id {0} not found in response", id));
            }
        }

    }
}
