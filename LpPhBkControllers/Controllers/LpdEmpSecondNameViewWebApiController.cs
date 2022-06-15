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

//    [RoutePrefix("lpdempsecondnameviewwebapi")]
    [ApiController]
    public class LpdEmpSecondNameViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpEmpPhBkContext db;

        public LpdEmpSecondNameViewWebApiController(LpEmpPhBkContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<LpdEmpSecondNameView>>> getall()
        {
            return await db.LpdEmpSecondNameDbSet
                    .Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LpdEmpSecondNameViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] empSecondNameId, 
            [FromQuery] string[] empSecondNameIdOprtr,
                
            [FromQuery] System.String[] empSecondName, 
            [FromQuery] string[] empSecondNameOprtr,
                 
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
            IQueryable<LpdEmpSecondName> query = db.LpdEmpSecondNameDbSet;
            int _empSecondNameId = empSecondNameId == null ? 0 : empSecondNameId.Length;
            if (_empSecondNameId > 0) {
                int _empSecondNameIdOprtr = empSecondNameIdOprtr == null ? 0 : empSecondNameIdOprtr.Length;
                for(int i = 0; i < _empSecondNameId; i++) {
                    string op_empSecondNameIdOprtr = (i >= _empSecondNameIdOprtr) ? "eq" : (empSecondNameIdOprtr[i] == null) ? "eq" : empSecondNameIdOprtr[i];
                    var _tmpempSecondNameId = empSecondNameId[i];
                    switch(op_empSecondNameIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmpSecondNameId == _tmpempSecondNameId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmpSecondNameId == _tmpempSecondNameId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpSecondNameId >= _tmpempSecondNameId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpSecondNameId <= _tmpempSecondNameId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpSecondNameId != _tmpempSecondNameId));
                            break;
                    }
                }
            }
            int _empSecondName = empSecondName == null ? 0 : empSecondName.Length;
            if (_empSecondName > 0) {
                int _empSecondNameOprtr = empSecondNameOprtr == null ? 0 : empSecondNameOprtr.Length;
                for(int i = 0; i < _empSecondName; i++) {
                    string op_empSecondNameOprtr = (i >= _empSecondNameOprtr) ? "eq" : (empSecondNameOprtr[i] == null) ? "eq" : empSecondNameOprtr[i];
                    var _tmpempSecondName = empSecondName[i];
                    switch(op_empSecondNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.EmpSecondName.Contains(_tmpempSecondName));
                            break;
                        case "lk":
                            query = query.Where(p => p.EmpSecondName.Contains(_tmpempSecondName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpSecondName.CompareTo(_tmpempSecondName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpSecondName.CompareTo(_tmpempSecondName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpSecondName.CompareTo(_tmpempSecondName) != 0));
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
                IOrderedQueryable<LpdEmpSecondName> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "empsecondnameid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpSecondNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpSecondNameId);
                                }
                                wasInUseOrderBy.Add("empsecondnameid");
                                wasInUseOrderBy.Add("-empsecondnameid");
                                break;
                            case "-empsecondnameid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpSecondNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpSecondNameId);
                                }
                                wasInUseOrderBy.Add("empsecondnameid");
                                wasInUseOrderBy.Add("-empsecondnameid");
                                break;
                            case "empsecondname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpSecondName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpSecondName);
                                }
                                wasInUseOrderBy.Add("empsecondname");
                                wasInUseOrderBy.Add("-empsecondname");
                                break;
                            case "-empsecondname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpSecondName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpSecondName);
                                }
                                wasInUseOrderBy.Add("empsecondname");
                                wasInUseOrderBy.Add("-empsecondname");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.EmpSecondNameId);
                } // totals pageCount currentPageSize
                LpdEmpSecondNameViewPage resultObject = new LpdEmpSecondNameViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LpdEmpSecondNameView>> getone(                
             [FromQuery] System.Int32 empSecondNameId
                
             )
        {
            LpdEmpSecondNameView result = await db.LpdEmpSecondNameDbSet
                    .Where(p => p.EmpSecondNameId == empSecondNameId)
                    .Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LpdEmpSecondNameViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] empSecondNameId,
             [FromQuery] string[] empSecondNameIdOprtr,
            
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

                
            int _empSecondNameId = empSecondNameId == null ? 0 : empSecondNameId.Length;
            int _empSecondNameIdOprtr = empSecondNameIdOprtr == null ? 0 : empSecondNameIdOprtr.Length;
                
            IQueryable<LpdEmpSecondName> query = db.LpdEmpSecondNameDbSet;
            var _outer = PredicateBuilder.New<LpdEmpSecondName>(false);
            bool isOuterModified = false;
            if ( _empSecondNameId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _empSecondNameId; i++) {
                    var _inner = PredicateBuilder.New<LpdEmpSecondName>(true);
                    isLkOp = false;
                    if(i < _empSecondNameIdOprtr) {
                        isLkOp = empSecondNameIdOprtr[i] == "lk";
                    }
                
                    if (empSecondNameId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpempSecondNameId = empSecondNameId[i];
                        
                    _inner = _inner.And(p => p.EmpSecondNameId == _tmpempSecondNameId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdEmpSecondName> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EmpSecondNameId);
              
                query = orderedQuery;
            }  
            LpdEmpSecondNameViewPage resultObject = new LpdEmpSecondNameViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                            }).ToListAsync();
            return Ok(resultObject);
        }
        [HttpGet]
        [Route("[controller]/getonebyLpdEmpSecondNameUK")]
        public async Task<ActionResult<LpdEmpSecondNameView>> getonebyLpdEmpSecondNameUK(                
             [FromQuery] System.String empSecondName
                
             )
        {
            LpdEmpSecondNameView result = await db.LpdEmpSecondNameDbSet
                    .Where(p => p.EmpSecondName == empSecondName)
                    .Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepunqLpdEmpSecondNameUK")]
        public async Task<ActionResult<LpdEmpSecondNameViewPage>> getmanybyrepunqLpdEmpSecondNameUK(
                
             [FromQuery] System.String[] empSecondName,
             [FromQuery] string[] empSecondNameOprtr,
            
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

                
            int _empSecondName = empSecondName == null ? 0 : empSecondName.Length;
            int _empSecondNameOprtr = empSecondNameOprtr == null ? 0 : empSecondNameOprtr.Length;
                
            IQueryable<LpdEmpSecondName> query = db.LpdEmpSecondNameDbSet;
            var _outer = PredicateBuilder.New<LpdEmpSecondName>(false);
            bool isOuterModified = false;
            if ( _empSecondName > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _empSecondName; i++) {
                    var _inner = PredicateBuilder.New<LpdEmpSecondName>(true);
                    isLkOp = false;
                    if(i < _empSecondNameOprtr) {
                        isLkOp = empSecondNameOprtr[i] == "lk";
                    }
                
                    if (empSecondName[i] == null) {
                        _inner = _inner.And(p => p.EmpSecondName == null);
                    } else {
                        var _tmpempSecondName = empSecondName[i];
                       
                        if(isLkOp) { _inner = _inner.And(p => p.EmpSecondName.StartsWith(_tmpempSecondName)); }
                        else { _inner = _inner.And(p => p.EmpSecondName == _tmpempSecondName); }
                        
                    }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdEmpSecondName> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EmpSecondName);
              
                query = orderedQuery;
            }  
            LpdEmpSecondNameViewPage resultObject = new LpdEmpSecondNameViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LpdEmpSecondNameView>> updateone([FromBody] LpdEmpSecondNameView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdEmpSecondName resultEntity = await db.LpdEmpSecondNameDbSet
                    .Where(p => p.EmpSecondNameId == viewToUpdate.EmpSecondNameId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.EmpSecondName =  viewToUpdate.EmpSecondName;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LpdEmpSecondNameView result = await db.LpdEmpSecondNameDbSet
                    .Where(p => p.EmpSecondNameId == viewToUpdate.EmpSecondNameId)
                    .Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LpdEmpSecondNameView>> addone([FromBody] LpdEmpSecondNameView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdEmpSecondName entityToAdd = new LpdEmpSecondName();
            entityToAdd.EmpSecondNameId =  viewToAdd.EmpSecondNameId;
            entityToAdd.EmpSecondName =  viewToAdd.EmpSecondName;
            db.LpdEmpSecondNameDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LpdEmpSecondNameView result = await db.LpdEmpSecondNameDbSet
                    .Where(p => p.EmpSecondNameId == entityToAdd.EmpSecondNameId)
                    .Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LpdEmpSecondNameView>> deleteone(                
             [FromQuery] System.Int32 empSecondNameId
                
           )
        {

                LpdEmpSecondNameView result = await db.LpdEmpSecondNameDbSet
                    .Where(p => p.EmpSecondNameId == empSecondNameId)
                    .Select(itm => new LpdEmpSecondNameView() {
                            EmpSecondNameId = itm.EmpSecondNameId,
                            EmpSecondName = itm.EmpSecondName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LpdEmpSecondName entityToDelete = await db.LpdEmpSecondNameDbSet
                    .Where(p => p.EmpSecondNameId == result.EmpSecondNameId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LpdEmpSecondNameDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

