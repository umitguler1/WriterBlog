using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WriterBlog.Business.Abstract;
using WriterBlog.Entities.Concrete;
using WriterBlog.Entities.Concrete.Dtos;

namespace WriterBlog.Business.Concrete
{
    public class NotificationMenager : INotificationService
    {
        private readonly INotificationDal _notificationDal;
        private readonly IMapper _mapper;
        public NotificationMenager(INotificationDal notificationDal, IMapper mapper)
        {
            _notificationDal = notificationDal;
            _mapper = mapper;
        }

        public async Task<bool> AddNotificationAsync(NotificationDto notificationDto)
        {
            Notification notification = DtoConvert(notificationDto);
            int reponse = await _notificationDal.AddAsync(notification);
            return reponse == 0 ? false : true;
        }

        public async Task<bool> DeleteNotificationAsync(NotificationDto notificationDto)
        {
            Notification notification = DtoConvert(notificationDto);
            int response = await _notificationDal.DeleteAsync(notification);
            return response == 0 ? false : true;
        }

        public async Task<List<NotificationDto>> GetAllNotificationAsync()
        {
            List<Notification> notifications = await _notificationDal.GetAllAsync();
            List<NotificationDto> notificationDtos = new List<NotificationDto>();
            foreach (Notification item in notifications)
            {
                NotificationDto notificationDto= _mapper.Map<NotificationDto>(item);
                notificationDtos.Add(notificationDto);
            }
            return notificationDtos;

        }

        public async Task<NotificationDto> GetNotificationByIdAsync(int id)
        {
            Notification notification = await _notificationDal.GetAsync(x => x.Id == id);
            return _mapper.Map<NotificationDto>(notification);
        }

        public async Task<bool> UpdateNotificationAsync(NotificationDto notificationDto)
        {
            Notification notification = _mapper.Map<Notification>(notificationDto);
            int response = await _notificationDal.UpdateAsync(notification);
            return response > 0;
        }
        public Notification DtoConvert(NotificationDto notificationDto)
        {
            return _mapper.Map<Notification>(notificationDto);
        }
    }
}
