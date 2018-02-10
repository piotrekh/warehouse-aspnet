using Effort;
using NUnit.Framework;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Warehouse.DataAccess;
using Warehouse.Domain.Common.Models;
using Warehouse.Domain.Warehouses.Models;
using Warehouse.Domain.Warehouses.Queries;
using Warehouse.Domain.Warehouses.QueryHandlers;
using Warehouse.UnitTests.TestDoubles;

namespace Warehouse.UnitTests.DomainTests.Warehouses
{
    [TestFixture]
    public class GetAllWarehousesTests
    {
        [Test]
        public async Task GetAllWarehouses_Should_ReturnAllWarehouses_When_DbTableNotEmpty()
        {
            #region Arrange

            var connection = DbConnectionFactory.CreateTransient();
            var dbContext = new WarehouseDbContext(connection);            
            var mapper = MapperFactory.CreateMapper();

            var query = new GetAllWarehouses();
            var handler = new GetAllWarehousesHandler(dbContext, mapper);

            //insert some objects to the database
            dbContext.Warehouses.Add(new DataAccess.Entities.Warehouse()
            {
                Address = new DataAccess.Entities.Address()
                {
                    City = "Warsaw",
                    Country = "Poland",
                    Id = 1,
                    PostalCode = "12345",
                    Street = "Test 1/2"
                },
                AddressId = 1,
                HazardousProducts = true,
                Id = 1,
                Name = "Warehouse 1",
                Size = 200
            });
            dbContext.Warehouses.Add(new DataAccess.Entities.Warehouse()
            {
                Address = new DataAccess.Entities.Address()
                {
                    City = "London",
                    Country = "UK",
                    Id = 2,
                    PostalCode = "23456",
                    Street = "Test 2/3"
                },
                AddressId = 2,
                HazardousProducts = false,
                Id = 2,
                Name = "Warehouse 2",
                Size = 150
            });
            dbContext.Warehouses.Add(new DataAccess.Entities.Warehouse()
            {
                Address = new DataAccess.Entities.Address()
                {
                    City = "Oslo",
                    Country = "Norway",
                    Id = 3,
                    PostalCode = "34567",
                    Street = "Test 3/4"
                },
                AddressId = 3,
                HazardousProducts = true,
                Id = 3,
                Name = "Warehouse 3",
                Size = 300
            });
            dbContext.SaveChanges();

            #endregion

            #region Act

            ItemsResult<WarehouseInfo> result = await handler.Handle(query, CancellationToken.None);

            #endregion

            #region Assert

            result.ShouldNotBeNull();
            result.Items.ShouldNotBeEmpty();
            result.Items.Count.ShouldBe(3);

            #endregion
        }
    }
}
