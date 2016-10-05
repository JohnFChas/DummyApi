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
        Post CreatePost(Post newPost);
        Post UpdatePost(Post post);
        bool DeletePost(int id);
        Post UpvotePost(int id);
        Post DownvotePost(int id);

        /* ---------------------------------------------
                            MESSAGES
        --------------------------------------------- */

        Message GetMessage(int id);
        Message[] GetMessages();
        Message CreateMessage(Message newMessage);
        bool DeleteMessage(int id);

        /* ---------------------------------------------
                            CHANNELS
        --------------------------------------------- */

        Channel GetChannel(int id);
        Channel[] GetChannels();
        Channel CreateChannel(Channel newChannel);
        bool DeleteChannel(int id);
    }
}
