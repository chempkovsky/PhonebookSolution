#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinqKit;

using LpPhBkContext.PhBk;
using LpPhBkViews.PhBk;
using LpPhBkEntity.PhBk;
using Microsoft.AspNetCore.Authorization;

namespace LpPhBkControllers.Controllers {

//    [RoutePrefix("lpddivisionviewwebapi")]
    [ApiController]
    public class LpdDivisionViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpPhbkDbContext db;

        public LpdDivisionViewWebApiController(LpPhbkDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        public async Task<ActionResult<IEnumerable<LpdDivisionView>>> getall()
        {
            return await db.LpdDivisionDbSet
                    .Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LpdDivisionViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] divisionNameId, 
            [FromQuery] string[] divisionNameIdOprtr,
                
            [FromQuery] System.String[] divisionName, 
            [FromQuery] string[] divisionNameOprtr,
                 
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
            IQueryable<LpdDivision> query = db.LpdDivisionDbSet;
            int _divisionNameId = divisionNameId == null ? 0 : divisionNameId.Length;
            if (_divisionNameId > 0) {
                int _divisionNameIdOprtr = divisionNameIdOprtr == null ? 0 : divisionNameIdOprtr.Length;
                for(int i = 0; i < _divisionNameId; i++) {
                    string op_divisionNameIdOprtr = (i >= _divisionNameIdOprtr) ? "eq" : (divisionNameIdOprtr[i] == null) ? "eq" : divisionNameIdOprtr[i];
                    var _tmpdivisionNameId = divisionNameId[i];
                    switch(op_divisionNameIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.DivisionNameId == _tmpdivisionNameId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.DivisionNameId == _tmpdivisionNameId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.DivisionNameId >= _tmpdivisionNameId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.DivisionNameId <= _tmpdivisionNameId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.DivisionNameId != _tmpdivisionNameId));
                            break;
                    }
                }
            }
            int _divisionName = divisionName == null ? 0 : divisionName.Length;
            if (_divisionName > 0) {
                int _divisionNameOprtr = divisionNameOprtr == null ? 0 : divisionNameOprtr.Length;
                for(int i = 0; i < _divisionName; i++) {
                    string op_divisionNameOprtr = (i >= _divisionNameOprtr) ? "eq" : (divisionNameOprtr[i] == null) ? "eq" : divisionNameOprtr[i];
                    var _tmpdivisionName = divisionName[i];
                    switch(op_divisionNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.DivisionName.Contains(_tmpdivisionName));
                            break;
                        case "lk":
                            query = query.Where(p => p.DivisionName.Contains(_tmpdivisionName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.DivisionName.CompareTo(_tmpdivisionName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.DivisionName.CompareTo(_tmpdivisionName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.DivisionName.CompareTo(_tmpdivisionName) != 0));
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
                IOrderedQueryable<LpdDivision> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "divisionnameid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.DivisionNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.DivisionNameId);
                                }
                                wasInUseOrderBy.Add("divisionnameid");
                                wasInUseOrderBy.Add("-divisionnameid");
                                break;
                            case "-divisionnameid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.DivisionNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.DivisionNameId);
                                }
                                wasInUseOrderBy.Add("divisionnameid");
                                wasInUseOrderBy.Add("-divisionnameid");
                                break;
                            case "divisionname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.DivisionName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.DivisionName);
                                }
                                wasInUseOrderBy.Add("divisionname");
                                wasInUseOrderBy.Add("-divisionname");
                                break;
                            case "-divisionname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.DivisionName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.DivisionName);
                                }
                                wasInUseOrderBy.Add("divisionname");
                                wasInUseOrderBy.Add("-divisionname");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.DivisionNameId);
                } // totals pageCount currentPageSize
                LpdDivisionViewPage resultObject = new LpdDivisionViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LpdDivisionView>> getone(                
             [FromQuery] System.Int32 divisionNameId
                
             )
        {
            LpdDivisionView result = await db.LpdDivisionDbSet
                    .Where(p => p.DivisionNameId == divisionNameId)
                    .Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LpdDivisionViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] divisionNameId,
             [FromQuery] string[] divisionNameIdOprtr,
            
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

                
            int _divisionNameId = divisionNameId == null ? 0 : divisionNameId.Length;
            int _divisionNameIdOprtr = divisionNameIdOprtr == null ? 0 : divisionNameIdOprtr.Length;
                
            IQueryable<LpdDivision> query = db.LpdDivisionDbSet;
            var _outer = PredicateBuilder.New<LpdDivision>(false);
            bool isOuterModified = false;
            if ( _divisionNameId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _divisionNameId; i++) {
                    var _inner = PredicateBuilder.New<LpdDivision>(true);
                    isLkOp = false;
                    if(i < _divisionNameIdOprtr) {
                        isLkOp = divisionNameIdOprtr[i] == "lk";
                    }
                
                    if (divisionNameId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpdivisionNameId = divisionNameId[i];
                        
                    _inner = _inner.And(p => p.DivisionNameId == _tmpdivisionNameId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdDivision> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.DivisionNameId);
              
                query = orderedQuery;
            }  
            LpdDivisionViewPage resultObject = new LpdDivisionViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                            }).ToListAsync();
            return Ok(resultObject);
        }
        [HttpGet]
        [Route("[controller]/getonebyLpdDivisionNameUk")]
        public async Task<ActionResult<LpdDivisionView>> getonebyLpdDivisionNameUk(                
             [FromQuery] System.String divisionName
                
             )
        {
            LpdDivisionView result = await db.LpdDivisionDbSet
                    .Where(p => p.DivisionName == divisionName)
                    .Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepunqLpdDivisionNameUk")]
        public async Task<ActionResult<LpdDivisionViewPage>> getmanybyrepunqLpdDivisionNameUk(
                
             [FromQuery] System.String[] divisionName,
             [FromQuery] string[] divisionNameOprtr,
            
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

                
            int _divisionName = divisionName == null ? 0 : divisionName.Length;
            int _divisionNameOprtr = divisionNameOprtr == null ? 0 : divisionNameOprtr.Length;
                
            IQueryable<LpdDivision> query = db.LpdDivisionDbSet;
            var _outer = PredicateBuilder.New<LpdDivision>(false);
            bool isOuterModified = false;
            if ( _divisionName > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _divisionName; i++) {
                    var _inner = PredicateBuilder.New<LpdDivision>(true);
                    isLkOp = false;
                    if(i < _divisionNameOprtr) {
                        isLkOp = divisionNameOprtr[i] == "lk";
                    }
                
                    if (divisionName[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpdivisionName = divisionName[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.DivisionName.StartsWith(_tmpdivisionName)); }
                    else { _inner = _inner.And(p => p.DivisionName == _tmpdivisionName); }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdDivision> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.DivisionName);
              
                query = orderedQuery;
            }  
            LpdDivisionViewPage resultObject = new LpdDivisionViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LpdDivisionView>> updateone([FromBody] LpdDivisionView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdDivision resultEntity = await db.LpdDivisionDbSet
                    .Where(p => p.DivisionNameId == viewToUpdate.DivisionNameId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.DivisionName =  viewToUpdate.DivisionName;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LpdDivisionView result = await db.LpdDivisionDbSet
                    .Where(p => p.DivisionNameId == viewToUpdate.DivisionNameId)
                    .Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LpdDivisionView>> addone([FromBody] LpdDivisionView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdDivision entityToAdd = new LpdDivision();
            entityToAdd.DivisionNameId =  viewToAdd.DivisionNameId;
            entityToAdd.DivisionName =  viewToAdd.DivisionName;
            db.LpdDivisionDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LpdDivisionView result = await db.LpdDivisionDbSet
                    .Where(p => p.DivisionNameId == entityToAdd.DivisionNameId)
                    .Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LpdDivisionView>> deleteone(                
             [FromQuery] System.Int32 divisionNameId
                
           )
        {

                LpdDivisionView result = await db.LpdDivisionDbSet
                    .Where(p => p.DivisionNameId == divisionNameId)
                    .Select(itm => new LpdDivisionView() {
                            DivisionNameId = itm.DivisionNameId,
                            DivisionName = itm.DivisionName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LpdDivision entityToDelete = await db.LpdDivisionDbSet
                    .Where(p => p.DivisionNameId == result.DivisionNameId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LpdDivisionDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

