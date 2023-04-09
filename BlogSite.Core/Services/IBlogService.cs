using BlogSite.Core.DTOs.Transaction;
using BlogSite.Core.Entities.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Core.Services
{
    public interface IBlogService : IService<TBlog, TBlogDto>
    {
    }
}
