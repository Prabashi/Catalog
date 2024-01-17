using System;
using Catalog.Dtos;
using Catalog.Entities;
using Catalog.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Controllers
{
	[ApiController]
	[Route("[controller]")] /* [Route("items")] */
    public class ItemsController : ControllerBase

	{
        // Not the ideal way because we're importing it directly
        private readonly IItemsRepository repository;

        public ItemsController(IItemsRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet]
        public IEnumerable<ItemDto> GetItems()
        {
            // Step 1:
            //var items = repository.GetItems();

            //Step 2: Project to ItemDto record type (Using DTOs instead of same record type used for persisting)
            //var items = repository.GetItems().Select(item => new ItemDto
            //{
            //    Id = item.Id,
            //    Name = item.Name,
            //    Price = item.Price,
            //    CreatedDate = item.CreatedDate
            //});

            //Step 3: Use an Extension (So that we don't need to do the mapping each time)
            var items = repository.GetItems().Select(item => item.AsDto());

            return items;
        }

        [HttpGet("{id}")]
        public ActionResult<ItemDto> GetItem(Guid id)
        {
            var item = repository.GetItem(id);

            if (item is null)
            {
                return NotFound();
            }

            return item.AsDto();
        }
    }
}

