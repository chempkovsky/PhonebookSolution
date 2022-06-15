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

//    [RoutePrefix("lprdivision01viewwebapi")]
    [ApiController]
    public class LprDivision01ViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpPhbkDbContext db;

        public LprDivision01ViewWebApiController(LpPhbkDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<LprDivision01View>>> getall()
        {
            return await db.LprDivision01DbSet
                    .Select(itm => new LprDivision01View() {
                            DivisionId = itm.DivisionId,
                            DivisionNameIdRef = itm.DivisionNameIdRef,
                            NDDivisionNameId = itm.DivisionNameIdRef,
                            NDDivisionName = itm.DivisionNameDict.DivisionName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LprDivision01ViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] divisionId, 
            [FromQuery] string[] divisionIdOprtr,
                
            [FromQuery] System.Int32?[] divisionNameIdRef, 
            [FromQuery] string[] divisionNameIdRefOprtr,
                 
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
            IQueryable<LprDivision01> query = db.LprDivision01DbSet;
            int _divisionId = divisionId == null ? 0 : divisionId.Length;
            if (_divisionId > 0) {
                int _divisionIdOprtr = divisionIdOprtr == null ? 0 : divisionIdOprtr.Length;
                for(int i = 0; i < _divisionId; i++) {
                    string op_divisionIdOprtr = (i >= _divisionIdOprtr) ? "eq" : (divisionIdOprtr[i] == null) ? "eq" : divisionIdOprtr[i];
                    var _tmpdivisionId = divisionId[i];
                    switch(op_divisionIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.DivisionId == _tmpdivisionId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.DivisionId == _tmpdivisionId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.DivisionId >= _tmpdivisionId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.DivisionId <= _tmpdivisionId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.DivisionId != _tmpdivisionId));
                            break;
                    }
                }
            }
            int _divisionNameIdRef = divisionNameIdRef == null ? 0 : divisionNameIdRef.Length;
            if (_divisionNameIdRef > 0) {
                int _divisionNameIdRefOprtr = divisionNameIdRefOprtr == null ? 0 : divisionNameIdRefOprtr.Length;
                for(int i = 0; i < _divisionNameIdRef; i++) {
                    string op_divisionNameIdRefOprtr = (i >= _divisionNameIdRefOprtr) ? "eq" : (divisionNameIdRefOprtr[i] == null) ? "eq" : divisionNameIdRefOprtr[i];
                    var _tmpdivisionNameIdRef = divisionNameIdRef[i];
                    switch(op_divisionNameIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.DivisionNameIdRef == _tmpdivisionNameIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.DivisionNameIdRef == _tmpdivisionNameIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.DivisionNameIdRef >= _tmpdivisionNameIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.DivisionNameIdRef <= _tmpdivisionNameIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.DivisionNameIdRef != _tmpdivisionNameIdRef));
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
                IOrderedQueryable<LprDivision01> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "divisionid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.DivisionId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.DivisionId);
                                }
                                wasInUseOrderBy.Add("divisionid");
                                wasInUseOrderBy.Add("-divisionid");
                                break;
                            case "-divisionid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.DivisionId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.DivisionId);
                                }
                                wasInUseOrderBy.Add("divisionid");
                                wasInUseOrderBy.Add("-divisionid");
                                break;
                            case "divisionnameidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.DivisionNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.DivisionNameIdRef);
                                }
                                wasInUseOrderBy.Add("divisionnameidref");
                                wasInUseOrderBy.Add("-divisionnameidref");
                                break;
                            case "-divisionnameidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.DivisionNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.DivisionNameIdRef);
                                }
                                wasInUseOrderBy.Add("divisionnameidref");
                                wasInUseOrderBy.Add("-divisionnameidref");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.DivisionNameIdRef);
                } // totals pageCount currentPageSize
                LprDivision01ViewPage resultObject = new LprDivision01ViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LprDivision01View() {
                            DivisionId = itm.DivisionId,
                            DivisionNameIdRef = itm.DivisionNameIdRef,
                            NDDivisionNameId = itm.DivisionNameIdRef,
                            NDDivisionName = itm.DivisionNameDict.DivisionName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LprDivision01View>> getone(                
             [FromQuery] System.Int32 divisionNameIdRef
                
            ,[FromQuery] System.Int32 divisionId
                
             )
        {
            LprDivision01View result = await db.LprDivision01DbSet
                    .Where(p => p.DivisionNameIdRef == divisionNameIdRef)
                    .Where(p => p.DivisionId == divisionId)
                    .Select(itm => new LprDivision01View() {
                            DivisionId = itm.DivisionId,
                            DivisionNameIdRef = itm.DivisionNameIdRef,
                            NDDivisionNameId = itm.DivisionNameIdRef,
                            NDDivisionName = itm.DivisionNameDict.DivisionName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LprDivision01ViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] divisionNameIdRef,
             [FromQuery] string[] divisionNameIdRefOprtr,
                
             [FromQuery] System.Int32?[] divisionId,
             [FromQuery] string[] divisionIdOprtr,
            
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

                
            int _divisionNameIdRef = divisionNameIdRef == null ? 0 : divisionNameIdRef.Length;
            int _divisionNameIdRefOprtr = divisionNameIdRefOprtr == null ? 0 : divisionNameIdRefOprtr.Length;
            int _applddivisionNameIdRef = 0;
                
            int _divisionId = divisionId == null ? 0 : divisionId.Length;
            int _divisionIdOprtr = divisionIdOprtr == null ? 0 : divisionIdOprtr.Length;
                
            IQueryable<LprDivision01> query = db.LprDivision01DbSet;
            var _outer = PredicateBuilder.New<LprDivision01>(false);
            bool isOuterModified = false;
            if ( _divisionNameIdRef > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _divisionNameIdRef; i++) {
                    var _inner = PredicateBuilder.New<LprDivision01>(true);
                    isLkOp = false;
                    if(i < _divisionNameIdRefOprtr) {
                        isLkOp = divisionNameIdRefOprtr[i] == "lk";
                    }
                
                    if (divisionNameIdRef[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpdivisionNameIdRef = divisionNameIdRef[i];
                        
                    _inner = _inner.And(p => p.DivisionNameIdRef == _tmpdivisionNameIdRef);
                    _applddivisionNameIdRef++;
                
                    if (_divisionId <= i) {
                        _outer = _outer.Or(_inner);
                        isOuterModified = true;
                        continue;
                    }
                    isLkOp = false;
                    if(i < _divisionIdOprtr) {
                        isLkOp = divisionIdOprtr[i] == "lk";
                    }
                
                    if (divisionId[i] == null) // continue; (required prop == null) returns false
                    {
                        if(i < 1) {
                            _outer = _outer.Or(_inner);
                            isOuterModified = true;
                        }
                        continue;
                    }
                    var _tmpdivisionId = divisionId[i];
                        
                    _inner = _inner.And(p => p.DivisionId == _tmpdivisionId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            bool isForeignAdded = false;
            var _outerAnd = PredicateBuilder.New<LprDivision01>(true);
                
             if(divisionNameIdRef != null) {
                if(divisionNameIdRef.Length > 0) {
                    for(int i = 0; i < divisionNameIdRef.Length; i++) {
                        if(i < _applddivisionNameIdRef) continue; // skip props which are used by the PrimKey
                
                        if (divisionNameIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpdivisionNameIdRef = divisionNameIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.DivisionNameIdRef == _tmpdivisionNameIdRef);
                        isForeignAdded = true;
                    }
                }
             }
            if(isForeignAdded) {
                if(isOuterModified) {
                    _outer = _outerAnd.And(_outer);
                } else {
                    _outer = _outerAnd;
                }
                isOuterModified = true;
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LprDivision01> orderedQuery = null;
            if(!isForeignAdded)
            {

                orderedQuery = query.OrderBy(p => p.DivisionNameIdRef);
                
                orderedQuery = orderedQuery.ThenBy(p => p.DivisionId);
              
                query = orderedQuery;
            }  
            LprDivision01ViewPage resultObject = new LprDivision01ViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LprDivision01View() {
                            DivisionId = itm.DivisionId,
                            DivisionNameIdRef = itm.DivisionNameIdRef,
                            NDDivisionNameId = itm.DivisionNameIdRef,
                            NDDivisionName = itm.DivisionNameDict.DivisionName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LprDivision01View>> updateone([FromBody] LprDivision01View viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LprDivision01 resultEntity = await db.LprDivision01DbSet
                    .Where(p => p.DivisionNameIdRef == viewToUpdate.DivisionNameIdRef)
                    .Where(p => p.DivisionId == viewToUpdate.DivisionId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.DivisionNameIdRef =  viewToUpdate.NDDivisionNameId;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LprDivision01View result = await db.LprDivision01DbSet
                    .Where(p => p.DivisionNameIdRef == viewToUpdate.DivisionNameIdRef)
                    .Where(p => p.DivisionId == viewToUpdate.DivisionId)
                    .Select(itm => new LprDivision01View() {
                            DivisionId = itm.DivisionId,
                            DivisionNameIdRef = itm.DivisionNameIdRef,
                            NDDivisionNameId = itm.DivisionNameIdRef,
                            NDDivisionName = itm.DivisionNameDict.DivisionName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LprDivision01View>> addone([FromBody] LprDivision01View viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LprDivision01 entityToAdd = new LprDivision01();
            entityToAdd.DivisionId =  viewToAdd.DivisionId;
            entityToAdd.DivisionNameIdRef =  viewToAdd.DivisionNameIdRef;
            entityToAdd.DivisionNameIdRef =  viewToAdd.NDDivisionNameId;
            db.LprDivision01DbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LprDivision01View result = await db.LprDivision01DbSet
                    .Where(p => p.DivisionNameIdRef == entityToAdd.DivisionNameIdRef)
                    .Where(p => p.DivisionId == entityToAdd.DivisionId)
                    .Select(itm => new LprDivision01View() {
                            DivisionId = itm.DivisionId,
                            DivisionNameIdRef = itm.DivisionNameIdRef,
                            NDDivisionNameId = itm.DivisionNameIdRef,
                            NDDivisionName = itm.DivisionNameDict.DivisionName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LprDivision01View>> deleteone(                
             [FromQuery] System.Int32 divisionNameIdRef
                
            ,[FromQuery] System.Int32 divisionId
                
           )
        {

                LprDivision01View result = await db.LprDivision01DbSet
                    .Where(p => p.DivisionNameIdRef == divisionNameIdRef)
                    .Where(p => p.DivisionId == divisionId)
                    .Select(itm => new LprDivision01View() {
                            DivisionId = itm.DivisionId,
                            DivisionNameIdRef = itm.DivisionNameIdRef,
                            NDDivisionNameId = itm.DivisionNameIdRef,
                            NDDivisionName = itm.DivisionNameDict.DivisionName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LprDivision01 entityToDelete = await db.LprDivision01DbSet
                    .Where(p => p.DivisionNameIdRef == result.DivisionNameIdRef)
                    .Where(p => p.DivisionId == result.DivisionId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LprDivision01DbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

