using AuctioNUS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuctioNUS.Domain.Abstract
{
    public interface IDealRepository
    {
        IQueryable<Deal> Deals { get; }
        void saveDeal(Deal deal);
        void deleteDeal(Deal deal);
    }

    public interface IBidRepository
    {
        IQueryable<Bid> Bids { get; }
        void saveBid(Bid bid);
    }

    public interface IModuleRepository
    {
        IQueryable<Module> Modules { get; }
        void saveModule(Module module);
    }

    public interface ISettingRepository
    {
        IQueryable<Setting> Settings { get; }
        void saveSetting(Setting setting);
    }

    public interface IUserRepository
    {
        IQueryable<User> Users { get; }
        void saveUser(User user);
    }
}
