using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyFriendsApp.Models;
using MyFriendsApp.Repository;
using MyFriendsApp.ViewModels;

namespace MyFriendsApp.Controllers
{
    [Route("[controller]")]
    [Route("")]
    public class FriendsController : Controller
    {
        public IFriendRepository FriendRepo { get; set; }

        public FriendsController(IFriendRepository _friendRepo)
        {
            FriendRepo = _friendRepo;
        }

        [HttpGet]
        [Route("")]
        [Route("Index/{currentpage}/{sortby}")]
        public async Task<IActionResult> Index(string firstName, string lastName, string pseudonym, string telephone, 
            string email, string address, string city, string postalCode, int currentPage = 1, string sortBy = "Id")
        {
            List<Friend> friendList = await FriendRepo.GetPage(currentPage, 5, sortBy);

            if (!string.IsNullOrEmpty(firstName))
                friendList = friendList.Where(f => f.FirstName.Contains(firstName)).ToList();

            if (!string.IsNullOrEmpty(lastName))
                friendList = friendList.Where(l => l.LastName.Contains(lastName)).ToList();

            if (!string.IsNullOrEmpty(pseudonym))
                friendList = friendList.Where(p => p.Pseudonym.Contains(pseudonym)).ToList();

            if (!string.IsNullOrEmpty(telephone))
                friendList = friendList.Where(t => t.Telephone.Contains(telephone)).ToList();

            if (!string.IsNullOrEmpty(email))
                friendList = friendList.Where(e => e.Email.Contains(email)).ToList();

            if (!string.IsNullOrEmpty(address))
                friendList = friendList.Where(a => a.Address.Contains(address)).ToList();

            if (!string.IsNullOrEmpty(city))
                friendList = friendList.Where(c => c.City.Contains(city)).ToList();

            if (!string.IsNullOrEmpty(postalCode))
                friendList = friendList.Where(p => p.PostalCode.Contains(postalCode)).ToList();

            FriendIndexViewModel friendIndexViewModel = new FriendIndexViewModel()
            {
                Friends = friendList,
                Count = await FriendRepo.GetCount(),
                SortBy = sortBy
            };

            return View(friendIndexViewModel);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Details(int id)
        {
            Friend item = await FriendRepo.Find(id);
            if (item == null)
                return RedirectToAction("Index");

            return View(item);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Create(Friend item)
        {
            if (item != null && ModelState.IsValid)
            {
                await FriendRepo.Add(item);
                return RedirectToAction("Details", new { id = item.Id });
            }

            return View();
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            Friend model = await FriendRepo.Find(id);

            if (model == null)
                return RedirectToAction("Index");

            return View(model);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public async Task<IActionResult> Edit(int id, Friend item)
        {
            Friend friend = await FriendRepo.Find(id);

            if (friend != null && ModelState.IsValid)
            {
                await FriendRepo.Update(item);
                return RedirectToAction("Details", new { id = friend.Id });
            }

            return View(friend);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Friend friend = await FriendRepo.Find(id);

            if (friend == null)
                return RedirectToAction("Index");

            return View(friend);
        }

        [HttpPost]
        [Route("Delete/{id}")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Friend friend = await FriendRepo.Find(id);

            if (friend == null)
                return RedirectToAction("Index");

            await FriendRepo.Remove(id);
            return RedirectToAction("Index");
        }
    }
}