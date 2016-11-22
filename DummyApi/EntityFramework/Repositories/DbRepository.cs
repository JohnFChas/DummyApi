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

        #region POSTS
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

        public Post CreatePost(Post newPost)
        {
            newPost.PostDate = DateTime.Now;
            var post = db.Posts.Add(newPost);

            if (post != null)
                db.SaveChanges();

            return post;
        }

        public Post UpdatePost(Post post)
        {
            db.Posts.Attach(post);
            var postEntry = db.Entry(post);
            postEntry.State = EntityState.Modified;
            db.SaveChanges();
            return post;
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

        public Post UpvotePost(int id)
        {
            var post = db.Posts.SingleOrDefault(p => p.Id == id);
            
            if (post != null)
            {
                post.Upvotes += 1;
                db.SaveChanges();
            }

            return post;
        }

        public Post DownvotePost(int id)
        {
            var post = db.Posts.SingleOrDefault(p => p.Id == id);

            if (post != null)
            {
                post.Downvotes += 1;
                db.SaveChanges();
            }

            return post;
        }
        #endregion

        #region THREADS
        /* ---------------------------------------------
                            THREADS
        --------------------------------------------- */

        public Thread GetThread(int id)
        {
            return db.Threads.SingleOrDefault(t => t.Id == id);
        }

        public Thread[] GetThreads()
        {
            return db.Threads.ToArray();
        }

        public Thread CreateThread(Thread newThread)
        {
            var thread = db.Threads.Add(newThread);

            if (thread != null)
                db.SaveChanges();

            thread.Posts = new List<Post>();

            return thread;
        }

        public bool DeleteThread(int id)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region MESSAGES
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

        public Message CreateMessage(Message newMessage)
        {
            var channel = db.Channels.SingleOrDefault(c => c.Id == newMessage.ChannelId);
            if (channel == null)
                newMessage.ChannelId = 1;

            newMessage.TimeSent = DateTime.Now;

            var message = db.Messages.Add(newMessage);

            if (message != null)
                db.SaveChanges();

            return message;
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
        #endregion

        #region CHANNELS
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

        public Channel CreateChannel(Channel newChannel)
        {
            var channel = db.Channels.Add(newChannel);

            if (channel != null)
                db.SaveChanges();

            channel.Messages = new List<Message>();

            return channel;
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
        #endregion

        public void Dispose()
        {
            db.Dispose();
        }
    }
}