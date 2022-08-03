using Catalog.Models;
using Catalog.Settings;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace Catalog.Repository
{
    public class ItemDbContext : DbContext
    {
        public ItemDbContext(DbContextOptions<ItemDbContext> options) : base(options)
        {

        }

        public DbSet<Item> Items { get; set; }
    }

    public class SqlServerDbItemsRepository : IItemsRepository
    {
        public ItemDbContext _db;
        public SqlServerDbItemsRepository(ItemDbContext db)
        {
            _db = db;
        }

        public void CreateItem(Item item)
        {
            _db.Items.Add(item);
            _db.SaveChanges();
        }

        public void DeleteItem(Guid id)
        {
            var item = _db.Items.Where(x => x.Id == id).SingleOrDefault();
            _db.Items.Remove(item);
            _db.SaveChanges();
        }

        public Item GetItem(Guid id)
        {
            var item = _db.Items.Where(x => x.Id == id).SingleOrDefault();
            return item;
        }

        public IEnumerable<Item> GetItems()
        {
            return _db.Items;
        }

        public void UpdateItem(Item item)
        {
            var currentItem = _db.Items.Where(x => x.Id == item.Id).SingleOrDefault();
            _db.Entry(currentItem).CurrentValues.SetValues(item);
            _db.SaveChanges();
        }
    }
}
