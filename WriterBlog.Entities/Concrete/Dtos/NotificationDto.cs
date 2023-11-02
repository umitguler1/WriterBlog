﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Core.Entities;

namespace WriterBlog.Entities.Concrete.Dtos
{
    public class NotificationDto : IDto
    {
        public int Id { get; set; }
        public string NotificationType { get; set; }
        public string NotificationTypeSymbol { get; set; }
        public string NotificationDetils { get; set; }
		public string NotificationColor { get; set; }
		public DateTime NotificationDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
