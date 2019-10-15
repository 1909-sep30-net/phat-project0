using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using StoreApp.Logic;
namespace XStoreAppTesting
{
    public class LogicTesting
    {
        /// <summary>
        /// Testing Address Input
        /// Expected: Boolean Values
        /// </summary>
        /// <param name="street"></param>
        /// <param name="city"></param>
        /// <param name="state"></param>
        /// <param name="zip"></param>
        [Theory]
        [InlineData("123 Main", "Houston", "TX", "132")]
        [InlineData("123 Main St", "Houston", "TX", "77075")]
        [InlineData(null,"Houston","TX",null)] // Testing With Null Params
        public void IsAddressReturnsTrue(string street, string city, string state, string zip)
        {
            Address addr = new Address();
            addr.city = city;
            addr.state = state;
            addr.street = street;
            addr.zip = zip;

            Assert.True(addr.IsAddressNotNull());
        }
        /// <summary>
        /// Testing numbers of Items Input
        /// Expected: Integer values
        /// </summary>
        /// <param name="ariel"></param>
        /// <param name="suavitel"></param>
        /// <param name="downie"></param>
        [Theory]
        [InlineData(2)]
        [InlineData(100)]
        [InlineData(3)]
        public void IsNumbersOfItemTrue(int ariel)
        {
            Product prod = new Product();
            prod.NumberofAriel = ariel;
;
            Assert.Equal( expected: prod.NumberofAriel,actual:ariel);
        }

        /// <summary>
        /// Testing should return null values no matter what inputs are
        /// because of disconnecting to database
        /// expected: NULL 
        /// </summary>
        /// <param name="username"></param>
        [Theory]
        [InlineData("sn")]
        [InlineData("abc")]
        [InlineData("24")]
        public void IsCustomerUsernameCorrect(string username)
        {
            StoreApp.Library.Entities.Customer customer = new StoreApp.Library.Entities.Customer();
            Assert.Equal(expected: customer.Username, actual: username);
        }

        /// <summary>
        /// Testing numbers of Items Non-negative Values
        /// Expected: Boolean Values
        /// </summary>
        /// <param name="ariel"></param>
        /// <param name="suavitel"></param>
        /// <param name="downie"></param>
        [Theory]
        [InlineData(2,3,5)]
        [InlineData(100,200,400)]
        [InlineData(3,2,1)]
        public void IsNumberofItemsNegative(int ariel, int downie, int suavitel)
        {
            Inventory inventory = new Inventory();
            inventory.items.NumberofAriel = ariel;
            inventory.items.NumberofDownie = downie;
            inventory.items.NumberofSuavitel = suavitel;

            Assert.True(inventory.CheckInventoryNotNull());
        }


    }
}
