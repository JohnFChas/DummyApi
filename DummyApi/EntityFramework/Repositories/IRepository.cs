using DummyApi.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyApi.EntityFramework.Repositories
{
    public interface IRepository : IDisposable
    {
        /* ---------------------------------------------
                             POSTS
        --------------------------------------------- */

        Post GetPost(int id);
        Post[] GetPosts();
        bool CreatePost(Post newPost);
        bool DeletePost(int id);

        /* ---------------------------------------------
                            MESSAGES
        --------------------------------------------- */

        Message GetMessage(int id);
        Message[] GetMessages();
        bool CreateMessage(Message newMessage);
        bool DeleteMessage(int id);

        /* ---------------------------------------------
                            CHANNELS
        --------------------------------------------- */

        Channel GetChannel(int id);
        Channel[] GetChannels();
        bool CreateChannel(Channel newChannel);
        bool DeleteChannel(int id);
    }
}
