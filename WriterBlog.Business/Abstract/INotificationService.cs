using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Abstract
{
    public interface INotificationService
    {
        Task<bool> AddNotificationAsync(NotificationDto notificationDto);
        Task<bool> UpdateNotificationAsync(NotificationDto notificationDto);
        Task<bool> DeleteNotificationAsync(NotificationDto notificationDto);
        Task<NotificationDto> GetNotificationByIdAsync(int id);
        Task<List<NotificationDto>> GetAllNotificationAsync();
    }
}
