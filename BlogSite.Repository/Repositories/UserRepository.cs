using BlogSite.Core.Entities.UserBase;
using BlogSite.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogSite.Repository.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(BlogSiteContext context) : base(context)
        {
        }
    }
}
