using System;
using MovieStoreUI.DbOperations;
using MovieStoreUI.Entities;

namespace MovieStore.UnitTests.TestSetup
{
    public static class Orders
    {
        public static void AddOrders(this MovieStoreDbContext context)
        {
            context.AddRange(
                new Order{ MovieId = 1, CustomerId = 1, OrderDate = new DateTime(2019, 10, 10), OrderPrice = 23.28},
                new Order{ MovieId = 4, CustomerId = 3, OrderDate = new DateTime(2020, 06, 05), OrderPrice = 28.28},
                new Order{ MovieId = 2, CustomerId = 3, OrderDate = new DateTime(2020, 06, 05), OrderPrice = 78.28}
            );
        }
    }
}