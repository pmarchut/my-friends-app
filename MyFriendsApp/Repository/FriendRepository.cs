using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using MyFriendsApp.Contexts;
using MyFriendsApp.Models;
using System.Linq.Dynamic.Core;

namespace MyFriendsApp.Repository
{
    public class FriendRepository : IFriendRepository
    {
        public IConfiguration _config;

        MyFriendsContext _context;

        public FriendRepository(IConfiguration config, MyFriendsContext context)
        {
            _config = config;
            _context = context;
        }

        public async Task Add(Friend friend)
        {
            await _context.Friends.AddAsync(friend);
            await _context.SaveChangesAsync();
        }

        public async Task<Friend> Find(int id)
        {
            return await _context.Friends
                 .Where(f => f.Id == id)
                 .SingleOrDefaultAsync();
        }

        public async Task<List<Friend>> GetAll()
        {
            return await _context.Friends.ToListAsync();
        }

        public async Task<int> GetCount()
        {
            List<Friend> data = await GetAll();
            return data.Count;
        }

        public async Task<List<Friend>> GetPage(int currentPage, int pageSize)
        {
            List<Friend> data = await GetAll();
            return data.OrderBy(d => d.Id).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task<List<Friend>> GetPage(int currentPage, int pageSize, string sortBy)
        {
            List<Friend> data = await GetAll();
            return data.AsQueryable().OrderBy(sortBy).Skip((currentPage - 1) * pageSize).Take(pageSize).ToList();
        }

        public async Task Remove(int id)
        {
            Friend friendToRemove = await _context.Friends.SingleOrDefaultAsync(f => f.Id == id);
            if (friendToRemove != null)
            {
                _context.Friends.Remove(friendToRemove);
                await _context.SaveChangesAsync();
            }
        }

        public async Task Update(Friend friend)
        {
            Friend friendToUpdate = await _context.Friends.SingleOrDefaultAsync(f => f.Id == friend.Id);
            if (friendToUpdate != null)
            {
                friendToUpdate.FirstName = friend.FirstName;
                friendToUpdate.LastName = friend.LastName;
                friendToUpdate.Pseudonym = friend.Pseudonym;
                friendToUpdate.Telephone = friend.Telephone;
                friendToUpdate.Email = friend.Email;
                friendToUpdate.Address = friend.Address;
                friendToUpdate.City = friend.City;
                friendToUpdate.PostalCode = friend.PostalCode;
                friendToUpdate.Notes = friend.Notes;
                await _context.SaveChangesAsync();
            }
        }
    }
}
