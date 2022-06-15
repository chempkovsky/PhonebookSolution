#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using PhBkContext.Auth;
using PhBkViews.Auth;
using PhBkEntity.Auth;

namespace PhBkControllers.Controllers {

//    [RoutePrefix("aspnetusermaskviewwebapi")]
    [ApiController]
    public class aspnetusermaskViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly aspnetchckdbcontext db;


        private readonly UserManager<IdentityUser> _userManager;
        public UserManager<IdentityUser> UserManager
        {
            get
            {
                return _userManager;
            }
        }

        public aspnetusermaskViewWebApiController(
                    aspnetchckdbcontext context,
                    UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<aspnetusermaskViewPage>> getwithfilter(                
            [FromQuery] System.String[] userId, 
            [FromQuery] string[] userIdOprtr,
                 
            [FromQuery] string[] orderby = null, 
            [FromQuery] int? page =null, 
            [FromQuery] int? pagesize = null)
        {

            string[] EqualOperators = { "eq", "lk" };
            string[] ExpectedOperators = { "eq", "lk", "gt", "lt", "ne" };

            int currentPageSize = this.defaultPageSize;
            int currentPage = 1;
            if (pagesize.HasValue) {
                currentPageSize = pagesize.Value;
                if ((currentPageSize < this.minPageSize) || (currentPageSize > this.maxPageSize)) {
                    currentPageSize = defaultPageSize;
                }
            }
            if (page.HasValue) {
                currentPage = page.Value+1;
                if (currentPage < 1) {
                    currentPage = 1;
                }
            }
            aspnetusermaskViewPage resultObject = new aspnetusermaskViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = 0,
                total = 0
            };
            if(userId == null) return resultObject;
            if (userId.Length <1) return resultObject;
            var user = await UserManager.FindByIdAsync(userId[0]);
            if(user == null) return resultObject;
            IList<string> rls = await UserManager.GetRolesAsync(user);
            if(rls == null) return resultObject;
            if(rls.Count < 1) return resultObject;

            resultObject.items = await db.aspnetrolemaskDbSet.Where(u=> rls.ToArray().Contains( u.RoleName))
                .GroupBy(u => u.ModelPkRef)
                .Select(g => new {
                    ModelPkRef = g.Key,
                    Mask1 = g.Sum(g => g.Mask1 ? 1 : 0) > 0,
                    Mask2 = g.Sum(g => g.Mask2 ? 1 : 0) > 0,
                    Mask3 = g.Sum(g => g.Mask3 ? 1 : 0) > 0,
                    Mask4 = g.Sum(g => g.Mask4 ? 1 : 0) > 0,
                    Mask5 = g.Sum(g => g.Mask5 ? 1 : 0) > 0
                }).Join(db.aspnetmodellDbSet,
                 o => o.ModelPkRef,
                 i => i.ModelPk,
                  (o, i) => new aspnetusermaskView
                  {
                      UserId = userId[0],
                      ModelPkRef = o.ModelPkRef,
                      Mask1 = o.Mask1,
                      Mask2 = o.Mask2,
                      Mask3 = o.Mask3,
                      Mask4 = o.Mask4,
                      Mask5 = o.Mask5,
                      MModelName = i.ModelName,
                      UEmail = user.Email,
                      UUserName = user.UserName,
                  })
                .ToListAsync();
            resultObject.total = resultObject.items.Count();
            return Ok(resultObject);


        } // the end of GetWithFilter()-method





    }
}

