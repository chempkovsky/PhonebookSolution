#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinqKit;

using PhBkContext.PhBk;
using PhBkViews.PhBk;
using PhBkEntity.PhBk;

namespace PhBkControllers.Controllers {

//    [RoutePrefix("phbkenterpriseviewwebapi")]
    [ApiController]
    public class PhbkEnterpriseViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly PhbkDbContext db;

        public PhbkEnterpriseViewWebApiController(PhbkDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<PhbkEnterpriseView>>> getall()
        {
            return await db.PhbkEnterpriseDbSet
                    .Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<PhbkEnterpriseViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] entrprsId, 
            [FromQuery] string[] entrprsIdOprtr,
                
            [FromQuery] System.String[] entrprsName, 
            [FromQuery] string[] entrprsNameOprtr,
                 
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
            IQueryable<PhbkEnterprise> query = db.PhbkEnterpriseDbSet;
            int _entrprsId = entrprsId == null ? 0 : entrprsId.Length;
            if (_entrprsId > 0) {
                int _entrprsIdOprtr = entrprsIdOprtr == null ? 0 : entrprsIdOprtr.Length;
                for(int i = 0; i < _entrprsId; i++) {
                    string op_entrprsIdOprtr = (i >= _entrprsIdOprtr) ? "eq" : (entrprsIdOprtr[i] == null) ? "eq" : entrprsIdOprtr[i];
                    var _tmpentrprsId = entrprsId[i];
                    switch(op_entrprsIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EntrprsId == _tmpentrprsId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EntrprsId == _tmpentrprsId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EntrprsId >= _tmpentrprsId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EntrprsId <= _tmpentrprsId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EntrprsId != _tmpentrprsId));
                            break;
                    }
                }
            }
            int _entrprsName = entrprsName == null ? 0 : entrprsName.Length;
            if (_entrprsName > 0) {
                int _entrprsNameOprtr = entrprsNameOprtr == null ? 0 : entrprsNameOprtr.Length;
                for(int i = 0; i < _entrprsName; i++) {
                    string op_entrprsNameOprtr = (i >= _entrprsNameOprtr) ? "eq" : (entrprsNameOprtr[i] == null) ? "eq" : entrprsNameOprtr[i];
                    var _tmpentrprsName = entrprsName[i];
                    switch(op_entrprsNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.EntrprsName.Contains(_tmpentrprsName));
                            break;
                        case "lk":
                            query = query.Where(p => p.EntrprsName.Contains(_tmpentrprsName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EntrprsName.CompareTo(_tmpentrprsName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EntrprsName.CompareTo(_tmpentrprsName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EntrprsName.CompareTo(_tmpentrprsName) != 0));
                            break;
                    }
                }
            }
                int totals = await query.CountAsync();
                int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
                List<string> currentOrderBy = null;
                if (orderby != null) {
                    if (orderby.Length > 0) {
                        currentOrderBy = orderby.Where(s => (!string.IsNullOrEmpty(s))).ToList();
                    }
                }   
                bool isFirstTime = true; 
                IOrderedQueryable<PhbkEnterprise> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "entrprsid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EntrprsId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EntrprsId);
                                }
                                wasInUseOrderBy.Add("entrprsid");
                                wasInUseOrderBy.Add("-entrprsid");
                                break;
                            case "-entrprsid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EntrprsId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EntrprsId);
                                }
                                wasInUseOrderBy.Add("entrprsid");
                                wasInUseOrderBy.Add("-entrprsid");
                                break;
                            case "entrprsname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EntrprsName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EntrprsName);
                                }
                                wasInUseOrderBy.Add("entrprsname");
                                wasInUseOrderBy.Add("-entrprsname");
                                break;
                            case "-entrprsname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EntrprsName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EntrprsName);
                                }
                                wasInUseOrderBy.Add("entrprsname");
                                wasInUseOrderBy.Add("-entrprsname");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.EntrprsId);
                } // totals pageCount currentPageSize
                PhbkEnterpriseViewPage resultObject = new PhbkEnterpriseViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<PhbkEnterpriseView>> getone(                
             [FromQuery] System.Int32 entrprsId
                
             )
        {
            PhbkEnterpriseView result = await db.PhbkEnterpriseDbSet
                    .Where(p => p.EntrprsId == entrprsId)
                    .Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<PhbkEnterpriseViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] entrprsId,
             [FromQuery] string[] entrprsIdOprtr,
            
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

                
            int _entrprsId = entrprsId == null ? 0 : entrprsId.Length;
            int _entrprsIdOprtr = entrprsIdOprtr == null ? 0 : entrprsIdOprtr.Length;
                
            IQueryable<PhbkEnterprise> query = db.PhbkEnterpriseDbSet;
            var _outer = PredicateBuilder.New<PhbkEnterprise>(false);
            bool isOuterModified = false;
            if ( _entrprsId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _entrprsId; i++) {
                    var _inner = PredicateBuilder.New<PhbkEnterprise>(true);
                    isLkOp = false;
                    if(i < _entrprsIdOprtr) {
                        isLkOp = entrprsIdOprtr[i] == "lk";
                    }
                
                    if (entrprsId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpentrprsId = entrprsId[i];
                        
                    _inner = _inner.And(p => p.EntrprsId == _tmpentrprsId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<PhbkEnterprise> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EntrprsId);
              
                query = orderedQuery;
            }  
            PhbkEnterpriseViewPage resultObject = new PhbkEnterpriseViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                            }).ToListAsync();
            return Ok(resultObject);
        }
        [HttpGet]
        [Route("[controller]/getonebyEntrprsNameUK")]
        public async Task<ActionResult<PhbkEnterpriseView>> getonebyEntrprsNameUK(                
             [FromQuery] System.String entrprsName
                
             )
        {
            PhbkEnterpriseView result = await db.PhbkEnterpriseDbSet
                    .Where(p => p.EntrprsName == entrprsName)
                    .Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepunqEntrprsNameUK")]
        public async Task<ActionResult<PhbkEnterpriseViewPage>> getmanybyrepunqEntrprsNameUK(
                
             [FromQuery] System.String[] entrprsName,
             [FromQuery] string[] entrprsNameOprtr,
            
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

                
            int _entrprsName = entrprsName == null ? 0 : entrprsName.Length;
            int _entrprsNameOprtr = entrprsNameOprtr == null ? 0 : entrprsNameOprtr.Length;
                
            IQueryable<PhbkEnterprise> query = db.PhbkEnterpriseDbSet;
            var _outer = PredicateBuilder.New<PhbkEnterprise>(false);
            bool isOuterModified = false;
            if ( _entrprsName > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _entrprsName; i++) {
                    var _inner = PredicateBuilder.New<PhbkEnterprise>(true);
                    isLkOp = false;
                    if(i < _entrprsNameOprtr) {
                        isLkOp = entrprsNameOprtr[i] == "lk";
                    }
                
                    if (entrprsName[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpentrprsName = entrprsName[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.EntrprsName.StartsWith(_tmpentrprsName)); }
                    else { _inner = _inner.And(p => p.EntrprsName == _tmpentrprsName); }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<PhbkEnterprise> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EntrprsName);
              
                query = orderedQuery;
            }  
            PhbkEnterpriseViewPage resultObject = new PhbkEnterpriseViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<PhbkEnterpriseView>> updateone([FromBody] PhbkEnterpriseView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PhbkEnterprise resultEntity = await db.PhbkEnterpriseDbSet
                    .Where(p => p.EntrprsId == viewToUpdate.EntrprsId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.EntrprsName =  viewToUpdate.EntrprsName;
            resultEntity.EntrprsDesc =  viewToUpdate.EntrprsDesc;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            PhbkEnterpriseView result = await db.PhbkEnterpriseDbSet
                    .Where(p => p.EntrprsId == viewToUpdate.EntrprsId)
                    .Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<PhbkEnterpriseView>> addone([FromBody] PhbkEnterpriseView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PhbkEnterprise entityToAdd = new PhbkEnterprise();
            entityToAdd.EntrprsId =  viewToAdd.EntrprsId;
            entityToAdd.EntrprsName =  viewToAdd.EntrprsName;
            entityToAdd.EntrprsDesc =  viewToAdd.EntrprsDesc;
            db.PhbkEnterpriseDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            PhbkEnterpriseView result = await db.PhbkEnterpriseDbSet
                    .Where(p => p.EntrprsId == entityToAdd.EntrprsId)
                    .Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<PhbkEnterpriseView>> deleteone(                
             [FromQuery] System.Int32 entrprsId
                
           )
        {

                PhbkEnterpriseView result = await db.PhbkEnterpriseDbSet
                    .Where(p => p.EntrprsId == entrprsId)
                    .Select(itm => new PhbkEnterpriseView() {
                            EntrprsId = itm.EntrprsId,
                            EntrprsName = itm.EntrprsName,
                            EntrprsDesc = itm.EntrprsDesc
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                PhbkEnterprise entityToDelete = await db.PhbkEnterpriseDbSet
                    .Where(p => p.EntrprsId == result.EntrprsId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.PhbkEnterpriseDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

