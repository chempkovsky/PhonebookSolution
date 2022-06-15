#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using PhBkContext.Auth;
using PhBkViews.Auth;
using PhBkEntity.Auth;

namespace PhBkControllers.Controllers {

    // [RoutePrefix("aspnetuserrolesviewwebapi")]
    public class aspnetuserrolesViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly RoleManager<IdentityRole> _roleManager;
        public RoleManager<IdentityRole> RoleManager
        {
            get
            {
                return _roleManager;
            }
        }
        private readonly UserManager<IdentityUser> _userManager;
        public UserManager<IdentityUser> UserManager
        {
            get
            {
                return _userManager;
            }
        }
        public aspnetuserrolesViewWebApiController(
                    UserManager<IdentityUser> userManager,
                    RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }


        [HttpGet]
        [Route("[controller]/getall")]
        public IQueryable<aspnetuserrolesView> getall()
        {
            return new List<aspnetuserrolesView>().AsQueryable();
        } // the end of Get()-method

        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult> getwithfilter([FromQuery] System.String[] userId 
                  , [FromQuery] string[] userIdOprtr 
                , [FromQuery] System.String[] roleId 
                  , [FromQuery] string[] roleIdOprtr 
                , [FromQuery] System.String[] uUserName 
                  , [FromQuery] string[] uUserNameOprtr 
                , [FromQuery] System.String[] rName 
                  , [FromQuery] string[] rNameOprtr 
                , [FromQuery] string[] orderby = null, [FromQuery] int? page =null, [FromQuery] int? pagesize = null)
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

            bool hasNo = true;
            System.String UserId = null;
            if(userId != null) {
                if(userId.Length > 0) {
                    int filterCnt = userId.Length;
                    for(int i = 0; i < filterCnt; i++) {
                        if(  string.IsNullOrEmpty(userId[i]) ) continue;
                        UserId = userId[i];
                        hasNo = false;
                        break;
                    }

                }
            }
            aspnetuserrolesViewPage resultObject = new aspnetuserrolesViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = 0,
                total = 0,
                items = new List<aspnetuserrolesView>()
            };

            if (hasNo) {
                return Ok(resultObject);
            }
            IdentityUser usr = await UserManager.FindByIdAsync(UserId);
            if(usr == null) {
                return Ok(resultObject);
            }
            
            IList<string> rls = await UserManager.GetRolesAsync(usr);
            hasNo = (rls == null);
            hasNo = hasNo ? hasNo : (rls.Count < 1);
            if (hasNo) {
                return Ok(resultObject);
            }
            List<IdentityRole> usrRls = RoleManager.Roles.Where(r => rls.Contains( r.Name )).OrderBy(r => r.Name).ToList();
            hasNo = (usrRls == null);
            hasNo = hasNo ? hasNo : (usrRls.Count < 1);
            if (hasNo) {
                return Ok(resultObject);
            }
            resultObject.pagecount = 1;
            resultObject.total = usrRls.Count;
            foreach(IdentityRole usrRl in usrRls) {
                resultObject.items.Add(new aspnetuserrolesView() {
                    UserId = usr.Id,
                    RoleId = usrRl.Id,
                    ULockoutEnd = usr.LockoutEnd,
                    UUserName = usr.UserName,
                    RName = usrRl.Name
                });
            }
            return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult> getone([FromQuery] System.String userId
                , [FromQuery] System.String roleId
                )
        {
            bool hasNoUserId = true;
            bool hasNoRoleId = true;

            System.String UserId = null;
            if(!string.IsNullOrEmpty(userId) ) {
                UserId = userId;
                hasNoUserId = false;
            }
            System.String RoleId = null;
            if(!string.IsNullOrEmpty(roleId) ) {
                RoleId = roleId;
                hasNoRoleId = false;
            }
            if (hasNoUserId || hasNoRoleId) {
                return NotFound();
            }
            IdentityUser usr = await UserManager.FindByIdAsync(UserId);
            if(usr == null) {
                return NotFound();
            }
            IdentityRole usrRl = await RoleManager.FindByIdAsync(RoleId);
            if(usrRl == null) {
                return NotFound();
            }
            bool IsInRole = await UserManager.IsInRoleAsync(usr, usrRl.Name);
            if(!IsInRole) {
                return NotFound();
            }
            aspnetuserrolesView result = new aspnetuserrolesView() {

                    UserId = usr.Id,
                    RoleId = usrRl.Id,
                    ULockoutEnd = usr.LockoutEnd,
                    UUserName = usr.UserName,
                    RName = usrRl.Name
            };
            return Ok(result);
        } // the end of public GetOne()-method

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult> updateone([FromBody] aspnetuserrolesView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool hasNoUserId = true;
            bool hasNoRoleId = true;


            System.String UserId = null;
            if(! string.IsNullOrEmpty(viewToUpdate.UserId) ) {
                UserId = viewToUpdate.UserId;
                hasNoUserId =  false;
            }
            System.String RoleId = null;
             if(! string.IsNullOrEmpty(viewToUpdate.RoleId) ) {
                RoleId = viewToUpdate.RoleId;
                hasNoRoleId =  false;
             }
            if (hasNoUserId || hasNoRoleId) {
                return NotFound();
            }
            IdentityUser usr = await UserManager.FindByIdAsync(UserId);
            if(usr == null) {
                return NotFound();
            }
            IdentityRole usrRl = await RoleManager.FindByIdAsync(RoleId);
            if(usrRl == null) {
                return NotFound();
            }
            bool IsInRole = await UserManager.IsInRoleAsync(usr, usrRl.Name);
            if(!IsInRole) {
                return NotFound();
            }
            aspnetuserrolesView result = new aspnetuserrolesView() {

                    UserId = usr.Id,
                    RoleId = usrRl.Id,
                    ULockoutEnd = usr.LockoutEnd,
                    UUserName = usr.UserName,
                    RName = usrRl.Name
            };
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult> addone([FromBody] aspnetuserrolesView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool hasNoUserId = true;
            bool hasNoRoleId = true;

            System.String UserId = null;
            if(! string.IsNullOrEmpty(viewToAdd.UserId) ) {
                UserId = viewToAdd.UserId;
                hasNoUserId =  false;
            }
            System.String RoleId = null;
             if(! string.IsNullOrEmpty(viewToAdd.RoleId) ) {
                RoleId = viewToAdd.RoleId;
                hasNoRoleId =  false;
             }
            if (hasNoUserId || hasNoRoleId) {
                return NotFound();
            }
            IdentityUser usr = await UserManager.FindByIdAsync(UserId);
            if(usr == null) {
                return NotFound();
            }
            IdentityRole usrRl = await RoleManager.FindByIdAsync(RoleId);
            if(usrRl == null) {
                return NotFound();
            }
            bool IsInRole = await UserManager.IsInRoleAsync(usr, usrRl.Name);
            if(!IsInRole) {
                IdentityResult rslt = await UserManager.AddToRoleAsync(usr, usrRl.Name);
                if (!rslt.Succeeded)
                {
                    return BadRequest(rslt);;
                }
            }
            aspnetuserrolesView result = new aspnetuserrolesView() {

                    UserId = usr.Id,
                    RoleId = usrRl.Id,
                    ULockoutEnd = usr.LockoutEnd,
                    UUserName = usr.UserName,
                    RName = usrRl.Name
            };
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult> deleteone([FromQuery] System.String userId
                , [FromQuery] System.String roleId
                )
        {
            bool hasNoUserId = true;
            bool hasNoRoleId = true;



            System.String UserId = null;
            if(!string.IsNullOrEmpty(userId) ) {
                UserId = userId;
                hasNoUserId = false;
            }
            System.String RoleId = null;
            if(!string.IsNullOrEmpty(roleId) ) {
                RoleId = roleId;
                hasNoRoleId = false;
            }
            if (hasNoUserId || hasNoRoleId) {
                return NotFound();
            }
            IdentityUser usr = await UserManager.FindByIdAsync(UserId);
            if(usr == null) {
                return NotFound();
            }
            IdentityRole usrRl = await RoleManager.FindByIdAsync(RoleId);
            if(usrRl == null) {
                return NotFound();
            }
            bool IsInRole = await UserManager.IsInRoleAsync(usr, usrRl.Name);
            if(IsInRole) {
                IdentityResult rslt = await UserManager.RemoveFromRoleAsync(usr, usrRl.Name);
                if (!rslt.Succeeded)
                {
                    return BadRequest(rslt);
                }
            }
            aspnetuserrolesView result = new aspnetuserrolesView() {

                    UserId = usr.Id,
                    RoleId = usrRl.Id,
                    ULockoutEnd = usr.LockoutEnd,
                    UUserName = usr.UserName,
                    RName = usrRl.Name
            };
            return Ok(result);
        }

    }
}

