﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WriterBlog.Business.Abstract;

namespace WriterBlog.WebUI.Controllers
{
    [Authorize(Roles = "Writer,Admin,Moderator")]
    public class NotificationController : Controller
    {
        private readonly INotificationService _notificationService;

        public NotificationController(INotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> AllNotification()
        {
            var values = await _notificationService.GetAllNotificationAsync();
            return View(values);
        }
       
    }
}
