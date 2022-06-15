#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LinqKit;


using PhBkContext.Auth;
using PhBkViews.Auth;
using PhBkEntity.Auth;

namespace PhBkControllers.Controllers {

    // [RoutePrefix("aspnetuserviewwebapi")]
    public class aspnetuserViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly UserManager<IdentityUser> _userManager;
        public UserManager<IdentityUser> UserManager
        {
            get
            {
                return _userManager;
            }
        }
        public aspnetuserViewWebApiController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        public IQueryable<aspnetuserView> getall()
        {
            return UserManager.Users
                    .Select(itm => new aspnetuserView() {
                            Id = itm.Id,
                            Email = itm.Email,
                            EmailConfirmed = itm.EmailConfirmed,
                            PhoneNumber = itm.PhoneNumber,
                            PhoneNumberConfirmed = itm.PhoneNumberConfirmed,
                            TwoFactorEnabled = itm.TwoFactorEnabled,
                            LockoutEnd = itm.LockoutEnd,
                            LockoutEnabled = itm.LockoutEnabled,
                            AccessFailedCount = itm.AccessFailedCount,
                            UserName = itm.UserName
                            });

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public ActionResult<aspnetuserViewPage> getwithfilter(                
            [FromQuery] System.String[] id, 
            [FromQuery] string[] idOprtr,
                
            [FromQuery] System.String[] email, 
            [FromQuery] string[] emailOprtr,
                
            [FromQuery] System.String[] phoneNumber, 
            [FromQuery] string[] phoneNumberOprtr,
                
            [FromQuery] System.String[] userName, 
            [FromQuery] string[] userNameOprtr,
                 
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
            IQueryable<IdentityUser> query = UserManager.Users;
            int _id = id == null ? 0 : id.Length;
            if (_id > 0) {
                int _idOprtr = idOprtr == null ? 0 : idOprtr.Length;
                for(int i = 0; i < _id; i++) {
                    string op_idOprtr = (i >= _idOprtr) ? "eq" : (idOprtr[i] == null) ? "eq" : idOprtr[i];
                    var _tmpid = id[i];
                    switch(op_idOprtr) {
                        case "eq": 
                            query = query.Where(p => p.Id.Contains(_tmpid));
                            break;
                        case "lk":
                            query = query.Where(p => p.Id.Contains(_tmpid));
                            break;
                        case "gt":
                            query = query.Where(p => (p.Id.CompareTo(_tmpid) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.Id.CompareTo(_tmpid) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.Id.CompareTo(_tmpid) != 0));
                            break;
                    }
                }
            }
            int _email = email == null ? 0 : email.Length;
            if (_email > 0) {
                int _emailOprtr = emailOprtr == null ? 0 : emailOprtr.Length;
                for(int i = 0; i < _email; i++) {
                    string op_emailOprtr = (i >= _emailOprtr) ? "eq" : (emailOprtr[i] == null) ? "eq" : emailOprtr[i];
                    var _tmpemail = email[i];
                    switch(op_emailOprtr) {
                        case "eq": 
                            query = query.Where(p => p.Email.Contains(_tmpemail));
                            break;
                        case "lk":
                            query = query.Where(p => p.Email.Contains(_tmpemail));
                            break;
                        case "gt":
                            query = query.Where(p => (p.Email.CompareTo(_tmpemail) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.Email.CompareTo(_tmpemail) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.Email.CompareTo(_tmpemail) != 0));
                            break;
                    }
                }
            }
            int _phoneNumber = phoneNumber == null ? 0 : phoneNumber.Length;
            if (_phoneNumber > 0) {
                int _phoneNumberOprtr = phoneNumberOprtr == null ? 0 : phoneNumberOprtr.Length;
                for(int i = 0; i < _phoneNumber; i++) {
                    string op_phoneNumberOprtr = (i >= _phoneNumberOprtr) ? "eq" : (phoneNumberOprtr[i] == null) ? "eq" : phoneNumberOprtr[i];
                    var _tmpphoneNumber = phoneNumber[i];
                    switch(op_phoneNumberOprtr) {
                        case "eq": 
                            query = query.Where(p => p.PhoneNumber.Contains(_tmpphoneNumber));
                            break;
                        case "lk":
                            query = query.Where(p => p.PhoneNumber.Contains(_tmpphoneNumber));
                            break;
                        case "gt":
                            query = query.Where(p => (p.PhoneNumber.CompareTo(_tmpphoneNumber) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.PhoneNumber.CompareTo(_tmpphoneNumber) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.PhoneNumber.CompareTo(_tmpphoneNumber) != 0));
                            break;
                    }
                }
            }
            int _userName = userName == null ? 0 : userName.Length;
            if (_userName > 0) {
                int _userNameOprtr = userNameOprtr == null ? 0 : userNameOprtr.Length;
                for(int i = 0; i < _userName; i++) {
                    string op_userNameOprtr = (i >= _userNameOprtr) ? "eq" : (userNameOprtr[i] == null) ? "eq" : userNameOprtr[i];
                    var _tmpuserName = userName[i];
                    switch(op_userNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.UserName.Contains(_tmpuserName));
                            break;
                        case "lk":
                            query = query.Where(p => p.UserName.Contains(_tmpuserName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.UserName.CompareTo(_tmpuserName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.UserName.CompareTo(_tmpuserName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.UserName.CompareTo(_tmpuserName) != 0));
                            break;
                    }
                }
            }
                int totals = query.Count();
                int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
                List<string> currentOrderBy = null;
                if (orderby != null) {
                    if (orderby.Length > 0) {
                        currentOrderBy = orderby.Where(s => (!string.IsNullOrEmpty(s))).ToList();
                    }
                }   
                bool isFirstTime = true; 
                IOrderedQueryable<IdentityUser> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "id" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.Id);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.Id);
                                }
                                wasInUseOrderBy.Add("id");
                                wasInUseOrderBy.Add("-id");
                                break;
                            case "-id" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.Id);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.Id);
                                }
                                wasInUseOrderBy.Add("id");
                                wasInUseOrderBy.Add("-id");
                                break;
                            case "email" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.Email);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.Email);
                                }
                                wasInUseOrderBy.Add("email");
                                wasInUseOrderBy.Add("-email");
                                break;
                            case "-email" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.Email);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.Email);
                                }
                                wasInUseOrderBy.Add("email");
                                wasInUseOrderBy.Add("-email");
                                break;
                            case "phonenumber" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.PhoneNumber);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.PhoneNumber);
                                }
                                wasInUseOrderBy.Add("phonenumber");
                                wasInUseOrderBy.Add("-phonenumber");
                                break;
                            case "-phonenumber" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.PhoneNumber);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.PhoneNumber);
                                }
                                wasInUseOrderBy.Add("phonenumber");
                                wasInUseOrderBy.Add("-phonenumber");
                                break;
                            case "username" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.UserName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.UserName);
                                }
                                wasInUseOrderBy.Add("username");
                                wasInUseOrderBy.Add("-username");
                                break;
                            case "-username" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.UserName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.UserName);
                                }
                                wasInUseOrderBy.Add("username");
                                wasInUseOrderBy.Add("-username");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.Id);
                } // totals pageCount currentPageSize
                aspnetuserViewPage resultObject = new aspnetuserViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetuserView() {
                            Id = itm.Id,
                            Email = itm.Email,
                            EmailConfirmed = itm.EmailConfirmed,
                            PhoneNumber = itm.PhoneNumber,
                            PhoneNumberConfirmed = itm.PhoneNumberConfirmed,
                            TwoFactorEnabled = itm.TwoFactorEnabled,
                            LockoutEnd = itm.LockoutEnd,
                            LockoutEnabled = itm.LockoutEnabled,
                            AccessFailedCount = itm.AccessFailedCount,
                            UserName = itm.UserName
                            }).ToList();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public ActionResult<aspnetuserView> getone(                
             [FromQuery] System.String id
                
             )
        {
            aspnetuserView result = UserManager.Users
                    .Where(p => p.Id == id)
                    .Select(itm => new aspnetuserView() {
                            Id = itm.Id,
                            Email = itm.Email,
                            EmailConfirmed = itm.EmailConfirmed,
                            PhoneNumber = itm.PhoneNumber,
                            PhoneNumberConfirmed = itm.PhoneNumberConfirmed,
                            TwoFactorEnabled = itm.TwoFactorEnabled,
                            LockoutEnd = itm.LockoutEnd,
                            LockoutEnabled = itm.LockoutEnabled,
                            AccessFailedCount = itm.AccessFailedCount,
                            UserName = itm.UserName
                    }).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public ActionResult<aspnetuserViewPage> getmanybyrepprim(
                
             [FromQuery] System.String[] id,
             [FromQuery] string[] idOprtr,
            
            [FromQuery] string[] orderby = null, 
            [FromQuery] int? page =null, 
            [FromQuery] int? pagesize = null)
        {
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

                
            int _id = id == null ? 0 : id.Length;
            int _idOprtr = idOprtr == null ? 0 : idOprtr.Length;
                
            IQueryable<IdentityUser> query = UserManager.Users;
            var _outer = PredicateBuilder.New<IdentityUser>(false);
            bool isOuterModified = false;
            if ( _id > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _id; i++) {
                    var _inner = PredicateBuilder.New<IdentityUser>(true);
                    isLkOp = false;
                    if(i < _idOprtr) {
                        isLkOp = idOprtr[i] == "lk";
                    }
                
                    if (id[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpid = id[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.Id.StartsWith(_tmpid)); }
                    else { _inner = _inner.And(p => p.Id == _tmpid); }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = query.Count();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<IdentityUser> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.Id);
              
                query = orderedQuery;
            }  
            aspnetuserViewPage resultObject = new aspnetuserViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetuserView() {
                            Id = itm.Id,
                            Email = itm.Email,
                            EmailConfirmed = itm.EmailConfirmed,
                            PhoneNumber = itm.PhoneNumber,
                            PhoneNumberConfirmed = itm.PhoneNumberConfirmed,
                            TwoFactorEnabled = itm.TwoFactorEnabled,
                            LockoutEnd = itm.LockoutEnd,
                            LockoutEnabled = itm.LockoutEnabled,
                            AccessFailedCount = itm.AccessFailedCount,
                            UserName = itm.UserName
                            }).ToList();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult> updateone([FromBody] aspnetuserView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            IdentityUser iu = await UserManager.FindByIdAsync(viewToUpdate.Id);
            if(iu == null)
            {
                return NotFound();
            }
            iu.Email =  viewToUpdate.Email;
            iu.EmailConfirmed =  viewToUpdate.EmailConfirmed;
            iu.PhoneNumber =  viewToUpdate.PhoneNumber;
            iu.PhoneNumberConfirmed =  viewToUpdate.PhoneNumberConfirmed;
            iu.TwoFactorEnabled =  viewToUpdate.TwoFactorEnabled;
            iu.LockoutEnd =  viewToUpdate.LockoutEnd;
            iu.LockoutEnabled =  viewToUpdate.LockoutEnabled;
            iu.AccessFailedCount =  viewToUpdate.AccessFailedCount;
            iu.UserName =  viewToUpdate.UserName;
            IdentityResult rslt = await UserManager.UpdateAsync(iu);
            if (!rslt.Succeeded)
            {
                return BadRequest(rslt);
            }
            iu = await UserManager.FindByIdAsync(viewToUpdate.Id);
            if(iu == null)
            {
                return NotFound();
            }
            aspnetuserView result = new aspnetuserView() {
                            Id = iu.Id,
                            Email = iu.Email,
                            EmailConfirmed = iu.EmailConfirmed,
                            PhoneNumber = iu.PhoneNumber,
                            PhoneNumberConfirmed = iu.PhoneNumberConfirmed,
                            TwoFactorEnabled = iu.TwoFactorEnabled,
                            LockoutEnd = iu.LockoutEnd,
                            LockoutEnabled = iu.LockoutEnabled,
                            AccessFailedCount = iu.AccessFailedCount,
                            UserName = iu.UserName
                    };

            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult> addone([FromBody] aspnetuserView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityUser entityToAdd = new IdentityUser()  { UserName = viewToAdd.Email, Email = viewToAdd.Email, SecurityStamp = Guid.NewGuid().ToString() };
/*
            entityToAdd.Id =  viewToAdd.Id;
            entityToAdd.Email =  viewToAdd.Email;
            entityToAdd.EmailConfirmed =  viewToAdd.EmailConfirmed;
            entityToAdd.PhoneNumber =  viewToAdd.PhoneNumber;
            entityToAdd.PhoneNumberConfirmed =  viewToAdd.PhoneNumberConfirmed;
            entityToAdd.TwoFactorEnabled =  viewToAdd.TwoFactorEnabled;
            entityToAdd.LockoutEnd =  viewToAdd.LockoutEnd;
            entityToAdd.LockoutEnabled =  viewToAdd.LockoutEnabled;
            entityToAdd.AccessFailedCount =  viewToAdd.AccessFailedCount;
            entityToAdd.UserName =  viewToAdd.UserName;
*/
            IdentityResult rslt = await UserManager.CreateAsync(entityToAdd, "Qqw?123");
            if (!rslt.Succeeded)
            {
                return BadRequest(rslt);
            }
            IdentityUser iu = await UserManager.FindByNameAsync(viewToAdd.Email);
            if(iu == null)
            {
                return NotFound();
            }

            aspnetuserView result = new aspnetuserView() {
                            Id = iu.Id,
                            Email = iu.Email,
                            EmailConfirmed = iu.EmailConfirmed,
                            PhoneNumber = iu.PhoneNumber,
                            PhoneNumberConfirmed = iu.PhoneNumberConfirmed,
                            TwoFactorEnabled = iu.TwoFactorEnabled,
                            LockoutEnd = iu.LockoutEnd,
                            LockoutEnabled = iu.LockoutEnabled,
                            AccessFailedCount = iu.AccessFailedCount,
                            UserName = iu.UserName
                    };
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult> deleteone([FromQuery] System.String id
                )
        {

            IdentityUser iu = await UserManager.FindByIdAsync(id);
            if(iu == null)
            {
                return NotFound();
            }
            if(iu == null)
            {
                return NotFound();
            }
            aspnetuserView result = new aspnetuserView() {
                            Id = iu.Id,
                            Email = iu.Email,
                            EmailConfirmed = iu.EmailConfirmed,
                            PhoneNumber = iu.PhoneNumber,
                            PhoneNumberConfirmed = iu.PhoneNumberConfirmed,
                            TwoFactorEnabled = iu.TwoFactorEnabled,
                            LockoutEnd = iu.LockoutEnd,
                            LockoutEnabled = iu.LockoutEnabled,
                            AccessFailedCount = iu.AccessFailedCount,
                            UserName = iu.UserName
                    };
            return Ok(result);
        }


    }
}

