using AuctioNUS.Domain.Abstract;
using AuctioNUS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;

namespace AuctioNUS.Domain.Concrete
{
    class EFDbContext : DbContext
    {
        public DbSet<Deal> Deals { get; set; }
        public DbSet<Bid> Bids { get; set; }
        public DbSet<Module> Modules { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<User> Users { get; set; }
    }

    public class EFDealRepository : IDealRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Deal> Deals
        {
            get { return context.Deals; }
        }

        public void saveDeal(Deal deal)
        {
            if (deal.DealID == 0)
            {
                context.Deals.Add(deal);
                context.SaveChanges();
            }
            else
            {
                context.Entry(deal).State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void deleteDeal(Deal deal)
        {
            context.Deals.Remove(deal);
            context.SaveChanges();
        }
    }

    public class EFBidRepository : IBidRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Bid> Bids
        {
            get { return context.Bids; }
        }

        public void saveBid(Bid bid)
        {
            if (bid.BidID == 0)
            {
                context.Bids.Add(bid);
                context.SaveChanges();
            }
        }
    }

    public class EFModuleRepository : IModuleRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Module> Modules
        {
            get { return context.Modules; }
        }

        public void saveModule(Module module)
        {
            if (module.ModuleID == 0)
            {
                context.Modules.Add(module);
                context.SaveChanges();
            }
        }
    }

    public class EFSettingRepository : ISettingRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<Setting> Settings
        {
            get { return context.Settings; }
        }

        public void saveSetting(Setting setting)
        {
            if (setting.SettingID == 0)
            {
                context.Settings.Add(setting);
                context.SaveChanges();
            }
        }
    }

    public class EFUserRepository : IUserRepository
    {
        private EFDbContext context = new EFDbContext();
        public IQueryable<User> Users
        {
            get { return context.Users; }
        }

        public void saveUser(User user)
        {
            if (user.UserID == 0)
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
