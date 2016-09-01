using DummyApi.Models.EntityModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DummyApi.EntityFramework.Repositories
{
    public interface IRepository
    {
        /* ---------------------------------------------
                             POSTS
        --------------------------------------------- */

        Post[] GetPosts();
        Post GetPost(int id);
    }
}
