using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinterBlog.DataAccess.Abstract;
using WinterBlog.DataAccess.Concrete;
using WriterBlog.Core.DataAccess.EntityFremawork;
using WriterBlog.Entities.Concrete;

namespace WinterBlog.DataAccess.Repositories
{
    public class Message2Dal : RepositoryBase<Message2>, IMessage2Dal
    {
        public Message2Dal(Context context) : base(context)
        {

        }
        public async Task<List<Message2>> GetInBoxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
                List<Message2> message2s = await c.Message2s.Include(x => x.SenderUser).Where(x=>x.ReceiverId == id).ToListAsync();
                return message2s;
            }
        }

        public async Task<List<Message2>> GetSendBoxWithMessageByWriter(int id)
        {
            using (var c = new Context())
            {
             List<Message2> message2s=   await c.Message2s.Include(x => x.ReceiverUser).Where(x => x.SenderId == id).ToListAsync();
                return message2s;
            }
        }
    }
}
