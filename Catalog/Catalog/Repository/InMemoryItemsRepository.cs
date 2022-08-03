using Catalog.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Catalog.Repository
{
    public class InMemoryItemsRepository : IItemsRepository
    {
        private readonly List<Item> items = new List<Item>()
        {
            new Item() { Id = Guid.NewGuid(), Name = "Potion", Price = 9, CreateTime = DateTime.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Sword", Price = 15, CreateTime = DateTime.UtcNow },
            new Item() { Id = Guid.NewGuid(), Name = "Shield", Price = 10, CreateTime = DateTime.UtcNow }
        };

        public IEnumerable<Item> GetItems()
        {
            return items;
        }

        public Item GetItem(Guid Id)
        {
            return items.Where(item => item.Id == Id).SingleOrDefault();
        }

        public void CreateItem(Item item)
        {
            items.Add(item);
        }

        public void UpdateItem(Item item)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == item.Id);
            items[index] = item;
        }

        public void DeleteItem(Guid id)
        {
            var index = items.FindIndex(existingItem => existingItem.Id == id);
            items.RemoveAt(index);
        }

    }
}
