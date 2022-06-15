#nullable disable
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using LinqKit;

using PhBkContext.Auth;
using PhBkViews.Auth;
using PhBkEntity.Auth;

namespace PhBkControllers.Controllers {

    // [RoutePrefix("aspnetroleviewwebapi")]
    public class aspnetroleViewWebApiController: ControllerBase
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
        public aspnetroleViewWebApiController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        public IQueryable<aspnetroleView> getall()
        {
            return RoleManager.Roles
                    .Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                            });

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public ActionResult<aspnetroleViewPage> getwithfilter(                
            [FromQuery] System.String[] id, 
            [FromQuery] string[] idOprtr,
                
            [FromQuery] System.String[] name, 
            [FromQuery] string[] nameOprtr,
                 
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
            IQueryable<IdentityRole> query = RoleManager.Roles;
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
            int _name = name == null ? 0 : name.Length;
            if (_name > 0) {
                int _nameOprtr = nameOprtr == null ? 0 : nameOprtr.Length;
                for(int i = 0; i < _name; i++) {
                    string op_nameOprtr = (i >= _nameOprtr) ? "eq" : (nameOprtr[i] == null) ? "eq" : nameOprtr[i];
                    var _tmpname = name[i];
                    switch(op_nameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.Name.Contains(_tmpname));
                            break;
                        case "lk":
                            query = query.Where(p => p.Name.Contains(_tmpname));
                            break;
                        case "gt":
                            query = query.Where(p => (p.Name.CompareTo(_tmpname) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.Name.CompareTo(_tmpname) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.Name.CompareTo(_tmpname) != 0));
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
                IOrderedQueryable<IdentityRole> orderedQuery = null;
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
                            case "name" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.Name);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.Name);
                                }
                                wasInUseOrderBy.Add("name");
                                wasInUseOrderBy.Add("-name");
                                break;
                            case "-name" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.Name);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.Name);
                                }
                                wasInUseOrderBy.Add("name");
                                wasInUseOrderBy.Add("-name");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.Id);
                } // totals pageCount currentPageSize
                aspnetroleViewPage resultObject = new aspnetroleViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                            }).ToList();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public ActionResult<aspnetroleView> getone(                
             [FromQuery] System.String id
                
             )
        {
            aspnetroleView result = RoleManager.Roles
                    .Where(p => p.Id == id)
                    .Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                    }).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public ActionResult<aspnetroleViewPage> getmanybyrepprim(
                
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
                
            IQueryable<IdentityRole> query = RoleManager.Roles;
            var _outer = PredicateBuilder.New<IdentityRole>(false);
            bool isOuterModified = false;
            if ( _id > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _id; i++) {
                    var _inner = PredicateBuilder.New<IdentityRole>(true);
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
            IOrderedQueryable<IdentityRole> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.Id);
              
                query = orderedQuery;
            }  
            aspnetroleViewPage resultObject = new aspnetroleViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                            }).ToList();
            return Ok(resultObject);
        }
        [HttpGet]
        [Route("[controller]/getonebyUnqName")]
        public ActionResult<aspnetroleView> getonebyUnqName(                
             [FromQuery] System.String name
                
             )
        {
            aspnetroleView result = RoleManager.Roles
                    .Where(p => p.Name == name)
                    .Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                    }).FirstOrDefault();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepunqUnqName")]
        public ActionResult<aspnetroleViewPage> getmanybyrepunqUnqName(
                
             [FromQuery] System.String[] name,
             [FromQuery] string[] nameOprtr,
            
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

                
            int _name = name == null ? 0 : name.Length;
            int _nameOprtr = nameOprtr == null ? 0 : nameOprtr.Length;
                
            IQueryable<IdentityRole> query = RoleManager.Roles;
            var _outer = PredicateBuilder.New<IdentityRole>(false);
            bool isOuterModified = false;
            if ( _name > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _name; i++) {
                    var _inner = PredicateBuilder.New<IdentityRole>(true);
                    isLkOp = false;
                    if(i < _nameOprtr) {
                        isLkOp = nameOprtr[i] == "lk";
                    }
                
                    if (name[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpname = name[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.Name.StartsWith(_tmpname)); }
                    else { _inner = _inner.And(p => p.Name == _tmpname); }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = query.Count();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<IdentityRole> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.Name);
              
                query = orderedQuery;
            }  
            aspnetroleViewPage resultObject = new aspnetroleViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                            }).ToList();
            return Ok(resultObject);
        }




        [HttpPost]
        [Route("addone")]
        public async Task<ActionResult<aspnetroleView>> addone([FromBody] aspnetroleView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            IdentityRole entityToAdd = new IdentityRole()  { Name = viewToAdd.Name };
            IdentityResult rslt = await RoleManager.CreateAsync(entityToAdd);
            if (!rslt.Succeeded)
            {
                return BadRequest(rslt);
            }


                aspnetroleView result = RoleManager.Roles
                    .Where(p => p.Id == entityToAdd.Id)
                    .Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                    }).FirstOrDefault();
                if (result == null)
                {
                    return NotFound();
                }
                return Ok(result);
        }



        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult> deleteone([FromQuery] System.String id
                )
        {

                aspnetroleView result = RoleManager.Roles
                    .Where(p => p.Id == id)
                    .Select(itm => new aspnetroleView() {
                            Id = itm.Id,
                            Name = itm.Name
                    }).FirstOrDefault();
                if (result == null)
                {
                    return NotFound();
                }

                IdentityRole entityToDelete = RoleManager.Roles
                    .Where(p => p.Id == result.Id)
                    .FirstOrDefault();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                IdentityResult rslt = await RoleManager.DeleteAsync(entityToDelete);
                if (!rslt.Succeeded)
                {
                    return BadRequest(rslt);
                }
                return Ok(result);
        }

    }
}

