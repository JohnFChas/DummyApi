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
            if (db.Posts.Count() == 0)
                return null;

            return db.Posts.SingleOrDefault(p => p.Id == id);
        }

        public Post[] GetPosts()
        {
            if (db.Posts.Count() == 0)
                return null;

            return db.Posts.ToArray();
        }

        public bool CreatePost(Post newPost)
        {
            newPost.PostDate = DateTime.Now;

            if (db.Posts.Add(newPost) != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeletePost(int id)
        {
            var post = db.Posts.SingleOrDefault(p => p.Id == id);

            if (post != null && db.Posts.Remove(post) != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        /* ---------------------------------------------
                            MESSAGES
        --------------------------------------------- */

        public Message GetMessage(int id)
        {
            if (db.Messages.Count() == 0)
                return null;

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
            var channel = db.Channels.SingleOrDefault(c => c.Id == newMessage.ChannelId);
            if (channel == null)
                newMessage.ChannelId = 1;

            newMessage.TimeSent = DateTime.Now;

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
            if (db.Channels.Count() == 0)
                return null;

            return db.Channels.Include(c => c.Messages).SingleOrDefault(c => c.Id == id);
        }

        public Channel[] GetChannels()
        {
            if (db.Channels.Count() == 0)
                return null;

            return db.Channels.Include(c => c.Messages).ToArray();
        }

        public bool CreateChannel(Channel newChannel)
        {
            if (db.Channels.Add(newChannel) != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public bool DeleteChannel(int id)
        {
            var channel = db.Channels.SingleOrDefault(m => m.Id == id);

            if (channel != null && db.Channels.Remove(channel) != null)
            {
                db.SaveChanges();
                return true;
            }

            return false;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}