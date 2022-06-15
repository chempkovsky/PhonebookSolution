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

//    [RoutePrefix("lpdemplastnameviewwebapi")]
    [ApiController]
    public class LpdEmpLastNameViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpEmpPhBkContext db;

        public LpdEmpLastNameViewWebApiController(LpEmpPhBkContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<LpdEmpLastNameView>>> getall()
        {
            return await db.LpdEmpLastNameDbSet
                    .Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LpdEmpLastNameViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] empLastNameId, 
            [FromQuery] string[] empLastNameIdOprtr,
                
            [FromQuery] System.String[] empLastName, 
            [FromQuery] string[] empLastNameOprtr,
                 
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
            IQueryable<LpdEmpLastName> query = db.LpdEmpLastNameDbSet;
            int _empLastNameId = empLastNameId == null ? 0 : empLastNameId.Length;
            if (_empLastNameId > 0) {
                int _empLastNameIdOprtr = empLastNameIdOprtr == null ? 0 : empLastNameIdOprtr.Length;
                for(int i = 0; i < _empLastNameId; i++) {
                    string op_empLastNameIdOprtr = (i >= _empLastNameIdOprtr) ? "eq" : (empLastNameIdOprtr[i] == null) ? "eq" : empLastNameIdOprtr[i];
                    var _tmpempLastNameId = empLastNameId[i];
                    switch(op_empLastNameIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmpLastNameId == _tmpempLastNameId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmpLastNameId == _tmpempLastNameId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpLastNameId >= _tmpempLastNameId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpLastNameId <= _tmpempLastNameId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpLastNameId != _tmpempLastNameId));
                            break;
                    }
                }
            }
            int _empLastName = empLastName == null ? 0 : empLastName.Length;
            if (_empLastName > 0) {
                int _empLastNameOprtr = empLastNameOprtr == null ? 0 : empLastNameOprtr.Length;
                for(int i = 0; i < _empLastName; i++) {
                    string op_empLastNameOprtr = (i >= _empLastNameOprtr) ? "eq" : (empLastNameOprtr[i] == null) ? "eq" : empLastNameOprtr[i];
                    var _tmpempLastName = empLastName[i];
                    switch(op_empLastNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.EmpLastName.Contains(_tmpempLastName));
                            break;
                        case "lk":
                            query = query.Where(p => p.EmpLastName.Contains(_tmpempLastName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpLastName.CompareTo(_tmpempLastName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpLastName.CompareTo(_tmpempLastName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpLastName.CompareTo(_tmpempLastName) != 0));
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
                IOrderedQueryable<LpdEmpLastName> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "emplastnameid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpLastNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpLastNameId);
                                }
                                wasInUseOrderBy.Add("emplastnameid");
                                wasInUseOrderBy.Add("-emplastnameid");
                                break;
                            case "-emplastnameid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpLastNameId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpLastNameId);
                                }
                                wasInUseOrderBy.Add("emplastnameid");
                                wasInUseOrderBy.Add("-emplastnameid");
                                break;
                            case "emplastname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpLastName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpLastName);
                                }
                                wasInUseOrderBy.Add("emplastname");
                                wasInUseOrderBy.Add("-emplastname");
                                break;
                            case "-emplastname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpLastName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpLastName);
                                }
                                wasInUseOrderBy.Add("emplastname");
                                wasInUseOrderBy.Add("-emplastname");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.EmpLastNameId);
                } // totals pageCount currentPageSize
                LpdEmpLastNameViewPage resultObject = new LpdEmpLastNameViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LpdEmpLastNameView>> getone(                
             [FromQuery] System.Int32 empLastNameId
                
             )
        {
            LpdEmpLastNameView result = await db.LpdEmpLastNameDbSet
                    .Where(p => p.EmpLastNameId == empLastNameId)
                    .Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LpdEmpLastNameViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] empLastNameId,
             [FromQuery] string[] empLastNameIdOprtr,
            
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

                
            int _empLastNameId = empLastNameId == null ? 0 : empLastNameId.Length;
            int _empLastNameIdOprtr = empLastNameIdOprtr == null ? 0 : empLastNameIdOprtr.Length;
                
            IQueryable<LpdEmpLastName> query = db.LpdEmpLastNameDbSet;
            var _outer = PredicateBuilder.New<LpdEmpLastName>(false);
            bool isOuterModified = false;
            if ( _empLastNameId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _empLastNameId; i++) {
                    var _inner = PredicateBuilder.New<LpdEmpLastName>(true);
                    isLkOp = false;
                    if(i < _empLastNameIdOprtr) {
                        isLkOp = empLastNameIdOprtr[i] == "lk";
                    }
                
                    if (empLastNameId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpempLastNameId = empLastNameId[i];
                        
                    _inner = _inner.And(p => p.EmpLastNameId == _tmpempLastNameId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdEmpLastName> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EmpLastNameId);
              
                query = orderedQuery;
            }  
            LpdEmpLastNameViewPage resultObject = new LpdEmpLastNameViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                            }).ToListAsync();
            return Ok(resultObject);
        }
        [HttpGet]
        [Route("[controller]/getonebyLpdEmpLastNameUK")]
        public async Task<ActionResult<LpdEmpLastNameView>> getonebyLpdEmpLastNameUK(                
             [FromQuery] System.String empLastName
                
             )
        {
            LpdEmpLastNameView result = await db.LpdEmpLastNameDbSet
                    .Where(p => p.EmpLastName == empLastName)
                    .Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepunqLpdEmpLastNameUK")]
        public async Task<ActionResult<LpdEmpLastNameViewPage>> getmanybyrepunqLpdEmpLastNameUK(
                
             [FromQuery] System.String[] empLastName,
             [FromQuery] string[] empLastNameOprtr,
            
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

                
            int _empLastName = empLastName == null ? 0 : empLastName.Length;
            int _empLastNameOprtr = empLastNameOprtr == null ? 0 : empLastNameOprtr.Length;
                
            IQueryable<LpdEmpLastName> query = db.LpdEmpLastNameDbSet;
            var _outer = PredicateBuilder.New<LpdEmpLastName>(false);
            bool isOuterModified = false;
            if ( _empLastName > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _empLastName; i++) {
                    var _inner = PredicateBuilder.New<LpdEmpLastName>(true);
                    isLkOp = false;
                    if(i < _empLastNameOprtr) {
                        isLkOp = empLastNameOprtr[i] == "lk";
                    }
                
                    if (empLastName[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpempLastName = empLastName[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.EmpLastName.StartsWith(_tmpempLastName)); }
                    else { _inner = _inner.And(p => p.EmpLastName == _tmpempLastName); }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdEmpLastName> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.EmpLastName);
              
                query = orderedQuery;
            }  
            LpdEmpLastNameViewPage resultObject = new LpdEmpLastNameViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LpdEmpLastNameView>> updateone([FromBody] LpdEmpLastNameView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdEmpLastName resultEntity = await db.LpdEmpLastNameDbSet
                    .Where(p => p.EmpLastNameId == viewToUpdate.EmpLastNameId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.EmpLastName =  viewToUpdate.EmpLastName;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LpdEmpLastNameView result = await db.LpdEmpLastNameDbSet
                    .Where(p => p.EmpLastNameId == viewToUpdate.EmpLastNameId)
                    .Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LpdEmpLastNameView>> addone([FromBody] LpdEmpLastNameView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdEmpLastName entityToAdd = new LpdEmpLastName();
            entityToAdd.EmpLastNameId =  viewToAdd.EmpLastNameId;
            entityToAdd.EmpLastName =  viewToAdd.EmpLastName;
            db.LpdEmpLastNameDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LpdEmpLastNameView result = await db.LpdEmpLastNameDbSet
                    .Where(p => p.EmpLastNameId == entityToAdd.EmpLastNameId)
                    .Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LpdEmpLastNameView>> deleteone(                
             [FromQuery] System.Int32 empLastNameId
                
           )
        {

                LpdEmpLastNameView result = await db.LpdEmpLastNameDbSet
                    .Where(p => p.EmpLastNameId == empLastNameId)
                    .Select(itm => new LpdEmpLastNameView() {
                            EmpLastNameId = itm.EmpLastNameId,
                            EmpLastName = itm.EmpLastName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LpdEmpLastName entityToDelete = await db.LpdEmpLastNameDbSet
                    .Where(p => p.EmpLastNameId == result.EmpLastNameId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LpdEmpLastNameDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

