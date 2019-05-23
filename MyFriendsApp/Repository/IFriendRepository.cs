using MyFriendsApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyFriendsApp.Repository
{
    public interface IFriendRepository
    {
        Task Add(Friend friend);
        Task<Friend> Find(int id);
        Task<List<Friend>> GetAll();
        Task Remove(int id);
        Task Update(Friend friend);
        Task<List<Friend>> GetPage(int currentPage, int pageSize);
        Task<List<Friend>> GetPage(int currentPage, int pageSize, string sortBy);
        Task<int> GetCount();
    }
}
