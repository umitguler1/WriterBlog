using Autofac;
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

			builder.RegisterType<AboutDal>().As<IAboutDal>();
			builder.RegisterType<BlogDal>().As<IBlogDal>();
			builder.RegisterType<CategoryDal>().As<ICategoryDal>();
			builder.RegisterType<CommentDal>().As<ICommentDal>();
			builder.RegisterType<ContactDal>().As<IContactDal>();
			builder.RegisterType<WriterDal>().As<IWriterDal>();
			builder.RegisterType<NewsLetterDal>().As<INewsLetterDal>();
			base.Load(builder);
		}
	}
}
