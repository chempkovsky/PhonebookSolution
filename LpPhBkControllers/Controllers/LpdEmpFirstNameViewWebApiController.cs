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

namespace LpPhBkControllers.Controllers {

//    [RoutePrefix("lpdempfirstnameviewwebapi")]
    [ApiController]
    public class LpdEmpFirstNameViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpEmpPhBkContext db;

        public LpdEmpFirstNameViewWebApiController(LpEmpPhBkContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<LpdEmpFirstNameView>>> getall()
        {
            return await db.LpdEmpFirstNameDbSet
                    .Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LpdEmpFirstNameViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] empFirstNameId, 
            [FromQuery] string[] empFirstNameIdOprtr,
                
            [FromQuery] System.String[] empFirstName, 
            [FromQuery] string[] empFirstNameOprtr,
                 
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
            IQueryable<LpdEmpFirstName> query = db.LpdEmpFirstNameDbSet;
            int _empFirstNameId = empFirstNameId == null ? 0 : empFirstNameId.Length;
            if (_empFirstNameId > 0) {
                int _empFirstNameIdOprtr = empFirstNameIdOprtr == null ? 0 : empFirstNameIdOprtr.Length;
                for(int i = 0; i < _empFirstNameId; i++) {
                    string op_empFirstNameIdOprtr = (i >= _empFirstNameIdOprtr) ? "eq" : (empFirstNameIdOprtr[i] == null) ? "eq" : empFirstNameIdOprtr[i];
                    var _tmpempFirstNameId = empFirstNameId[i];
                    switch(op_empFirstNameIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmpFirstNameId == _tmpempFirstNameId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmpFirstNameId == _tmpempFirstNameId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpFirstNameId >= _tmpempFirstNameId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpFirstNameId <= _tmpempFirstNameId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpFirstNameId != _tmpempFirstNameId));
                            break;
                    }
                }
            }
            int _empFirstName = empFirstName == null ? 0 : empFirstName.Length;
            if (_empFirstName > 0) {
                int _empFirstNameOprtr = empFirstNameOprtr == null ? 0 : empFirstNameOprtr.Length;
                for(int i = 0; i < _empFirstName; i++) {
                    string op_empFirstNameOprtr = (i >= _empFirstNameOprtr) ? "eq" : (empFirstNameOprtr[i] == null) ? "eq" : empFirstNameOprtr[i];
                    var _tmpempFirstName = empFirstName[i];
                    switch(op_empFirstNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.EmpFirstName.Contains(_tmpempFirstName));
                            break;
                        case "lk":
                            query = query.Where(p => p.EmpFirstName.Contains(_tmpempFirstName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpFirstName.CompareTo(_tmpempFirstName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpFirstName.CompareTo(_tmpempFirstName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpFirstName.CompareTo(_tmpempFirstName) != 0));
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
                IOrderedQueryable<LpdEmpFirstName> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "empfirstnameid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpFirstNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpFirstNameId);
                                }
                                wasInUseOrderBy.Add("empfirstnameid");
                                wasInUseOrderBy.Add("-empfirstnameid");
                                break;
                            case "-empfirstnameid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpFirstNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpFirstNameId);
                                }
                                wasInUseOrderBy.Add("empfirstnameid");
                                wasInUseOrderBy.Add("-empfirstnameid");
                                break;
                            case "empfirstname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpFirstName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpFirstName);
                                }
                                wasInUseOrderBy.Add("empfirstname");
                                wasInUseOrderBy.Add("-empfirstname");
                                break;
                            case "-empfirstname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpFirstName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpFirstName);
                                }
                                wasInUseOrderBy.Add("empfirstname");
                                wasInUseOrderBy.Add("-empfirstname");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.EmpFirstNameId);
                } // totals pageCount currentPageSize
                LpdEmpFirstNameViewPage resultObject = new LpdEmpFirstNameViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LpdEmpFirstNameView>> getone(                
             [FromQuery] System.Int32 empFirstNameId
                
             )
        {
            LpdEmpFirstNameView result = await db.LpdEmpFirstNameDbSet
                    .Where(p => p.EmpFirstNameId == empFirstNameId)
                    .Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LpdEmpFirstNameViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] empFirstNameId,
             [FromQuery] string[] empFirstNameIdOprtr,
            
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

                
            int _empFirstNameId = empFirstNameId == null ? 0 : empFirstNameId.Length;
            int _empFirstNameIdOprtr = empFirstNameIdOprtr == null ? 0 : empFirstNameIdOprtr.Length;
                
            IQueryable<LpdEmpFirstName> query = db.LpdEmpFirstNameDbSet;
            var _outer = PredicateBuilder.New<LpdEmpFirstName>(false);
            bool isOuterModified = false;
            if ( _empFirstNameId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _empFirstNameId; i++) {
                    var _inner = PredicateBuilder.New<LpdEmpFirstName>(true);
                    isLkOp = false;
                    if(i < _empFirstNameIdOprtr) {
                        isLkOp = empFirstNameIdOprtr[i] == "lk";
                    }
                
                    if (empFirstNameId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpempFirstNameId = empFirstNameId[i];
                        
                    _inner = _inner.And(p => p.EmpFirstNameId == _tmpempFirstNameId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdEmpFirstName> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EmpFirstNameId);
              
                query = orderedQuery;
            }  
            LpdEmpFirstNameViewPage resultObject = new LpdEmpFirstNameViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                            }).ToListAsync();
            return Ok(resultObject);
        }
        [HttpGet]
        [Route("[controller]/getonebyLpdEmpFirstNameUK")]
        public async Task<ActionResult<LpdEmpFirstNameView>> getonebyLpdEmpFirstNameUK(                
             [FromQuery] System.String empFirstName
                
             )
        {
            LpdEmpFirstNameView result = await db.LpdEmpFirstNameDbSet
                    .Where(p => p.EmpFirstName == empFirstName)
                    .Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepunqLpdEmpFirstNameUK")]
        public async Task<ActionResult<LpdEmpFirstNameViewPage>> getmanybyrepunqLpdEmpFirstNameUK(
                
             [FromQuery] System.String[] empFirstName,
             [FromQuery] string[] empFirstNameOprtr,
            
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

                
            int _empFirstName = empFirstName == null ? 0 : empFirstName.Length;
            int _empFirstNameOprtr = empFirstNameOprtr == null ? 0 : empFirstNameOprtr.Length;
                
            IQueryable<LpdEmpFirstName> query = db.LpdEmpFirstNameDbSet;
            var _outer = PredicateBuilder.New<LpdEmpFirstName>(false);
            bool isOuterModified = false;
            if ( _empFirstName > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _empFirstName; i++) {
                    var _inner = PredicateBuilder.New<LpdEmpFirstName>(true);
                    isLkOp = false;
                    if(i < _empFirstNameOprtr) {
                        isLkOp = empFirstNameOprtr[i] == "lk";
                    }
                
                    if (empFirstName[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpempFirstName = empFirstName[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.EmpFirstName.StartsWith(_tmpempFirstName)); }
                    else { _inner = _inner.And(p => p.EmpFirstName == _tmpempFirstName); }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdEmpFirstName> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EmpFirstName);
              
                query = orderedQuery;
            }  
            LpdEmpFirstNameViewPage resultObject = new LpdEmpFirstNameViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LpdEmpFirstNameView>> updateone([FromBody] LpdEmpFirstNameView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdEmpFirstName resultEntity = await db.LpdEmpFirstNameDbSet
                    .Where(p => p.EmpFirstNameId == viewToUpdate.EmpFirstNameId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.EmpFirstName =  viewToUpdate.EmpFirstName;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LpdEmpFirstNameView result = await db.LpdEmpFirstNameDbSet
                    .Where(p => p.EmpFirstNameId == viewToUpdate.EmpFirstNameId)
                    .Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LpdEmpFirstNameView>> addone([FromBody] LpdEmpFirstNameView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdEmpFirstName entityToAdd = new LpdEmpFirstName();
            entityToAdd.EmpFirstNameId =  viewToAdd.EmpFirstNameId;
            entityToAdd.EmpFirstName =  viewToAdd.EmpFirstName;
            db.LpdEmpFirstNameDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LpdEmpFirstNameView result = await db.LpdEmpFirstNameDbSet
                    .Where(p => p.EmpFirstNameId == entityToAdd.EmpFirstNameId)
                    .Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LpdEmpFirstNameView>> deleteone(                
             [FromQuery] System.Int32 empFirstNameId
                
           )
        {

                LpdEmpFirstNameView result = await db.LpdEmpFirstNameDbSet
                    .Where(p => p.EmpFirstNameId == empFirstNameId)
                    .Select(itm => new LpdEmpFirstNameView() {
                            EmpFirstNameId = itm.EmpFirstNameId,
                            EmpFirstName = itm.EmpFirstName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LpdEmpFirstName entityToDelete = await db.LpdEmpFirstNameDbSet
                    .Where(p => p.EmpFirstNameId == result.EmpFirstNameId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LpdEmpFirstNameDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

