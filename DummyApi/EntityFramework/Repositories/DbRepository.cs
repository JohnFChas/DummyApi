using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using DummyApi.Models.EntityModels;
using DummyApi.EntityFramework.Contexts;

namespace DummyApi.EntityFramework.Repositories
{
    public class DbRepository : IRepository
    {
#if DEBUG
        const string CONNECTION = "ApiContextLocal";
#else
        const string CONNECTION = "ApiContextLive";
#endif

        ApiContext db = new ApiContext(CONNECTION);

        /* ---------------------------------------------
                             POSTS
        --------------------------------------------- */

        public Post GetPost(int id)
        {
            return db.Posts.SingleOrDefault(p => p.Id == id);
        }

        public Post[] GetPosts()
        {
            return db.Posts.ToArray();
        }

        /* ---------------------------------------------
                            MESSAGES
        --------------------------------------------- */

        public Message GetMessage(int id)
        {
            return db.Messages.Include(m => m.Channel).SingleOrDefault(m => m.Id == id);
        }

        public Message[] GetMessages()
        {
            if (db.Messages.Count() == 0)
                return null;

            return db.Messages.Include(m => m.Channel).ToArray();
        }

        public bool CreateMessage(Message newMessage)
        {
            if (db.Messages.Add(newMessage) != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteMessage(int id)
        {
            var message = db.Messages.SingleOrDefault(m => m.Id == id);

            if (message != null && db.Messages.Remove(message) != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /* ---------------------------------------------
                            CHANNELS
        --------------------------------------------- */

        public Channel GetChannel(int id)
        {
            return db.Channels.Include(c => c.Messages).SingleOrDefault(c => c.Id == id);
        }

        public Channel[] GetChannels()
        {
            return db.Channels.Include(c => c.Messages).ToArray();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}