using Autofac;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WinterBlog.DataAccess.Repositories;
using WriterBlog.Business.Abstract;
using WriterBlog.Business.Concrete;

namespace WriterBlog.Business.DependencyResolvers
{
	public class BusinessModule : Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterType<AboutMenager>().As<IAboutService>();
			builder.RegisterType<BlogMenager>().As<IBlogService>();
			builder.RegisterType<CategoryMenager>().As<ICategoryService>();
			builder.RegisterType<CommentMenager>().As<ICommentService>();
			builder.RegisterType<ContactMenager>().As<IContactService>();
			builder.RegisterType<WriterMenager>().As<IWriterService>();
			builder.RegisterType<NewsLetterManager>().As<INewsLetterService>();
			builder.RegisterType<NotificationMenager>().As<INotificationService>();
			builder.RegisterType<MessageMenager>().As<IMessageService>();
			builder.RegisterType<Message2Menager>().As<IMessage2Service>();
			builder.RegisterType<AuthMenager>().As<IAuthService>();
			builder.RegisterType<UserMenager>().As<IUserService>();

			builder.RegisterType<AboutDal>().As<IAboutDal>();
			builder.RegisterType<BlogDal>().As<IBlogDal>();
			builder.RegisterType<CategoryDal>().As<ICategoryDal>();
			builder.RegisterType<CommentDal>().As<ICommentDal>();
			builder.RegisterType<ContactDal>().As<IContactDal>();
			builder.RegisterType<WriterDal>().As<IWriterDal>();
			builder.RegisterType<NewsLetterDal>().As<INewsLetterDal>();
			builder.RegisterType<NotificationDal>().As<INotificationDal>();
			builder.RegisterType<MessageDal>().As<IMessageDal>();
			builder.RegisterType<Message2Dal>().As<IMessage2Dal>();
			builder.RegisterType<UserDal>().As<IUserDal>();
			base.Load(builder);
		}
	}
}
