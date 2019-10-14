using StoreApp.Logic;
using StoreApp.Library.Entities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace StoreApp.Library.Handlers
{
    public class Parser
    {
        //ContextCustomer
        public StoreApp.Logic.Customer ContextCustomerToLogicCustomer(Entities.Customer cust)
        {
            StoreApp.Logic.Customer LogicCustomer = new StoreApp.Logic.Customer();

            LogicCustomer.customerAddress.street = cust.Street;
            LogicCustomer.customerAddress.city = cust.City;
            LogicCustomer.customerAddress.state = cust.State;
            LogicCustomer.customerAddress.zip = cust.Zip;

            LogicCustomer.customerId = cust.CustomerId;
            LogicCustomer.firstName = cust.FirstName;
            LogicCustomer.lastName = cust.LastName;
            LogicCustomer.userName = cust.Username;

            return LogicCustomer;
        }
        public Entities.Customer LogicCustomerToContextCustomer(Logic.Customer cust)
        {
            Entities.Customer ContextCustomer = new Entities.Customer();

            ContextCustomer.Username = cust.userName;
            ContextCustomer.CustomerId = cust.customerId;
            ContextCustomer.FirstName = cust.firstName;
            ContextCustomer.LastName = cust.lastName;

            ContextCustomer.Street = cust.customerAddress.street;
            ContextCustomer.City = cust.customerAddress.city;
            ContextCustomer.State = cust.customerAddress.state;
            ContextCustomer.Zip = cust.customerAddress.zip;
            


            return ContextCustomer;
        }


        //ContextOrder
        public Entities.Orders LogicOrderToContextOrder(Logic.Order LogicOrder)
        {
            Entities.Orders ContextOrder = new Entities.Orders();

            ContextOrder.Ariel = LogicOrder.cartItems.NumberofAriel;
            ContextOrder.Downie = LogicOrder.cartItems.NumberofDownie;
            ContextOrder.Suavitel = LogicOrder.cartItems.NumberofSuavitel;

            ContextOrder.StoreId = LogicOrder.storeLocation.storeId;
            ContextOrder.CustomerId = LogicOrder.customer.customerId;


            return ContextOrder;
        }

        public Order ContextOrderToLogicOrder(Entities.Orders ContextOrder, StoreAppContext context)
        {
            Logic.Order LogicOrder = new Order();

            LogicOrder.orderID = ContextOrder.OrderId;
            LogicOrder.storeLocation.storeId = ContextOrder.StoreId;

            LogicOrder.customer.customerId=ContextOrder.CustomerId;

            LogicOrder.cartItems.NumberofAriel = ContextOrder.Ariel;
            LogicOrder.cartItems.NumberofDownie = ContextOrder.Downie;
            LogicOrder.cartItems.NumberofSuavitel =ContextOrder.Suavitel;

            return LogicOrder;
        }

   

        //ContextManager
        public StoreApp.Logic.Manager ContextManagerToLogicManager(Entities.Manager mang)
        {
            StoreApp.Logic.Manager LogicManager = new StoreApp.Logic.Manager();

            LogicManager.managerID = mang.ManagerId;
            LogicManager.firstName = mang.FirstName;
            LogicManager.lastName = mang.LastName;

            return LogicManager;
        }

        //ContextStore
        public Logic.Store ContextStoreToLogicStore(Entities.Store contextStore) 
        {
           Logic.Store LogicStore = new Logic.Store();

            LogicStore.address.street = contextStore.Street;
            LogicStore.address.city = contextStore.City;
            LogicStore.address.state = contextStore.State;
            LogicStore.address.zip = contextStore.Zip;

            LogicStore.storeInventory.items.NumberofAriel = contextStore.Ariel;
            LogicStore.storeInventory.items.NumberofDownie = contextStore.Downie;
            LogicStore.storeInventory.items.NumberofSuavitel = contextStore.Suavitel;

            LogicStore.storeId = contextStore.StoreId;
            return LogicStore;

        } 
    }
}
