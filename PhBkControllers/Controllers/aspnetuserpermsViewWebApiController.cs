#nullable disable
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;

using PhBkContext.Auth;
using PhBkViews.Auth;
using PhBkEntity.Auth;

namespace PhBkControllers.Controllers {

//    [RoutePrefix("aspnetuserpermsviewwebapi")]
    [ApiController]
    public class aspnetuserpermsViewWebApiController: ControllerBase
    {
        private readonly aspnetchckdbcontext db;

        private readonly IHttpContextAccessor _httpContextAccessor;
        public IHttpContextAccessor HttpContextAccessor
        {
            get
            {
                return _httpContextAccessor;
            }
        }

        public aspnetuserpermsViewWebApiController(
                    aspnetchckdbcontext context,
                    IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            db = context;
        }

        [HttpGet]
        [Route("api/[controller]/getall")]
        public async Task<ActionResult<IEnumerable<aspnetuserpermsView>>> getall()
        {
            string[] roles = _httpContextAccessor?.HttpContext?.User?.Claims.Where(c => c.Type == ClaimTypes.Role).Select(cl => cl.Value).ToArray();
            if(roles == null) return new List<aspnetuserpermsView>();
            return  await db.aspnetrolemaskDbSet.Where(u=> roles.Contains( u.RoleName))
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
                  (o, i) => new aspnetuserpermsView
                  {
                      ModelName = i.ModelName,
                      UserPerms = (o.Mask1 ? 1 : 0) + (o.Mask2 ? 2 : 0) + (o.Mask3 ? 4 : 0) + (o.Mask4 ? 8 : 0) + (o.Mask5 ? 16 : 0)
                  })
                .ToListAsync();
        } // the end of GetWithFilter()-method
    }
}

