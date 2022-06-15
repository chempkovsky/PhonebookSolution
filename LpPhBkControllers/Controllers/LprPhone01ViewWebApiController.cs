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

//    [RoutePrefix("lprphone01viewwebapi")]
    [ApiController]
    public class LprPhone01ViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpPhnPhBkContext db;

        public LprPhone01ViewWebApiController(LpPhnPhBkContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<LprPhone01View>>> getall()
        {
            return await db.LprPhone01DbSet
                    .Select(itm => new LprPhone01View() {
                            PhoneId = itm.PhoneId,
                            LpdPhoneIdRef = itm.LpdPhoneIdRef

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LprPhone01ViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] phoneId, 
            [FromQuery] string[] phoneIdOprtr,
                
            [FromQuery] System.Int32?[] lpdPhoneIdRef, 
            [FromQuery] string[] lpdPhoneIdRefOprtr,
                 
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
            IQueryable<LprPhone01> query = db.LprPhone01DbSet;
            int _phoneId = phoneId == null ? 0 : phoneId.Length;
            if (_phoneId > 0) {
                int _phoneIdOprtr = phoneIdOprtr == null ? 0 : phoneIdOprtr.Length;
                for(int i = 0; i < _phoneId; i++) {
                    string op_phoneIdOprtr = (i >= _phoneIdOprtr) ? "eq" : (phoneIdOprtr[i] == null) ? "eq" : phoneIdOprtr[i];
                    var _tmpphoneId = phoneId[i];
                    switch(op_phoneIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.PhoneId == _tmpphoneId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.PhoneId == _tmpphoneId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.PhoneId >= _tmpphoneId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.PhoneId <= _tmpphoneId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.PhoneId != _tmpphoneId));
                            break;
                    }
                }
            }
            int _lpdPhoneIdRef = lpdPhoneIdRef == null ? 0 : lpdPhoneIdRef.Length;
            if (_lpdPhoneIdRef > 0) {
                int _lpdPhoneIdRefOprtr = lpdPhoneIdRefOprtr == null ? 0 : lpdPhoneIdRefOprtr.Length;
                for(int i = 0; i < _lpdPhoneIdRef; i++) {
                    string op_lpdPhoneIdRefOprtr = (i >= _lpdPhoneIdRefOprtr) ? "eq" : (lpdPhoneIdRefOprtr[i] == null) ? "eq" : lpdPhoneIdRefOprtr[i];
                    var _tmplpdPhoneIdRef = lpdPhoneIdRef[i];
                    switch(op_lpdPhoneIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.LpdPhoneIdRef == _tmplpdPhoneIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.LpdPhoneIdRef == _tmplpdPhoneIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.LpdPhoneIdRef >= _tmplpdPhoneIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.LpdPhoneIdRef <= _tmplpdPhoneIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.LpdPhoneIdRef != _tmplpdPhoneIdRef));
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
                IOrderedQueryable<LprPhone01> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "phoneid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.PhoneId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.PhoneId);
                                }
                                wasInUseOrderBy.Add("phoneid");
                                wasInUseOrderBy.Add("-phoneid");
                                break;
                            case "-phoneid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.PhoneId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.PhoneId);
                                }
                                wasInUseOrderBy.Add("phoneid");
                                wasInUseOrderBy.Add("-phoneid");
                                break;
                            case "lpdphoneidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.LpdPhoneIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.LpdPhoneIdRef);
                                }
                                wasInUseOrderBy.Add("lpdphoneidref");
                                wasInUseOrderBy.Add("-lpdphoneidref");
                                break;
                            case "-lpdphoneidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.LpdPhoneIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.LpdPhoneIdRef);
                                }
                                wasInUseOrderBy.Add("lpdphoneidref");
                                wasInUseOrderBy.Add("-lpdphoneidref");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.LpdPhoneIdRef);
                } // totals pageCount currentPageSize
                LprPhone01ViewPage resultObject = new LprPhone01ViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LprPhone01View() {
                            PhoneId = itm.PhoneId,
                            LpdPhoneIdRef = itm.LpdPhoneIdRef
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LprPhone01View>> getone(                
             [FromQuery] System.Int32 lpdPhoneIdRef
                
            ,[FromQuery] System.Int32 phoneId
                
             )
        {
            LprPhone01View result = await db.LprPhone01DbSet
                    .Where(p => p.LpdPhoneIdRef == lpdPhoneIdRef)
                    .Where(p => p.PhoneId == phoneId)
                    .Select(itm => new LprPhone01View() {
                            PhoneId = itm.PhoneId,
                            LpdPhoneIdRef = itm.LpdPhoneIdRef
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LprPhone01ViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] lpdPhoneIdRef,
             [FromQuery] string[] lpdPhoneIdRefOprtr,
                
             [FromQuery] System.Int32?[] phoneId,
             [FromQuery] string[] phoneIdOprtr,
            
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

                
            int _lpdPhoneIdRef = lpdPhoneIdRef == null ? 0 : lpdPhoneIdRef.Length;
            int _lpdPhoneIdRefOprtr = lpdPhoneIdRefOprtr == null ? 0 : lpdPhoneIdRefOprtr.Length;
            int _appldlpdPhoneIdRef = 0;
                
            int _phoneId = phoneId == null ? 0 : phoneId.Length;
            int _phoneIdOprtr = phoneIdOprtr == null ? 0 : phoneIdOprtr.Length;
                
            IQueryable<LprPhone01> query = db.LprPhone01DbSet;
            var _outer = PredicateBuilder.New<LprPhone01>(false);
            bool isOuterModified = false;
            if ( _lpdPhoneIdRef > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _lpdPhoneIdRef; i++) {
                    var _inner = PredicateBuilder.New<LprPhone01>(true);
                    isLkOp = false;
                    if(i < _lpdPhoneIdRefOprtr) {
                        isLkOp = lpdPhoneIdRefOprtr[i] == "lk";
                    }
                
                    if (lpdPhoneIdRef[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmplpdPhoneIdRef = lpdPhoneIdRef[i];
                        
                    _inner = _inner.And(p => p.LpdPhoneIdRef == _tmplpdPhoneIdRef);
                    _appldlpdPhoneIdRef++;
                
                    if (_phoneId <= i) {
                        _outer = _outer.Or(_inner);
                        isOuterModified = true;
                        continue;
                    }
                    isLkOp = false;
                    if(i < _phoneIdOprtr) {
                        isLkOp = phoneIdOprtr[i] == "lk";
                    }
                
                    if (phoneId[i] == null) // continue; (required prop == null) returns false
                    {
                        if(i < 1) {
                            _outer = _outer.Or(_inner);
                            isOuterModified = true;
                        }
                        continue;
                    }
                    var _tmpphoneId = phoneId[i];
                        
                    _inner = _inner.And(p => p.PhoneId == _tmpphoneId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            bool isForeignAdded = false;
            var _outerAnd = PredicateBuilder.New<LprPhone01>(true);
                
             if(lpdPhoneIdRef != null) {
                if(lpdPhoneIdRef.Length > 0) {
                    for(int i = 0; i < lpdPhoneIdRef.Length; i++) {
                        if(i < _appldlpdPhoneIdRef) continue; // skip props which are used by the PrimKey
                
                        if (lpdPhoneIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmplpdPhoneIdRef = lpdPhoneIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.LpdPhoneIdRef == _tmplpdPhoneIdRef);
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
            IOrderedQueryable<LprPhone01> orderedQuery = null;
            if(!isForeignAdded)
            {

                orderedQuery = query.OrderBy(p => p.LpdPhoneIdRef);
                
                orderedQuery = orderedQuery.ThenBy(p => p.PhoneId);
              
                query = orderedQuery;
            }  
            LprPhone01ViewPage resultObject = new LprPhone01ViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LprPhone01View() {
                            PhoneId = itm.PhoneId,
                            LpdPhoneIdRef = itm.LpdPhoneIdRef
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LprPhone01View>> updateone([FromBody] LprPhone01View viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LprPhone01 resultEntity = await db.LprPhone01DbSet
                    .Where(p => p.LpdPhoneIdRef == viewToUpdate.LpdPhoneIdRef)
                    .Where(p => p.PhoneId == viewToUpdate.PhoneId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LprPhone01View result = await db.LprPhone01DbSet
                    .Where(p => p.LpdPhoneIdRef == viewToUpdate.LpdPhoneIdRef)
                    .Where(p => p.PhoneId == viewToUpdate.PhoneId)
                    .Select(itm => new LprPhone01View() {
                            PhoneId = itm.PhoneId,
                            LpdPhoneIdRef = itm.LpdPhoneIdRef
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LprPhone01View>> addone([FromBody] LprPhone01View viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LprPhone01 entityToAdd = new LprPhone01();
            entityToAdd.PhoneId =  viewToAdd.PhoneId;
            entityToAdd.LpdPhoneIdRef =  viewToAdd.LpdPhoneIdRef;
            db.LprPhone01DbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LprPhone01View result = await db.LprPhone01DbSet
                    .Where(p => p.LpdPhoneIdRef == entityToAdd.LpdPhoneIdRef)
                    .Where(p => p.PhoneId == entityToAdd.PhoneId)
                    .Select(itm => new LprPhone01View() {
                            PhoneId = itm.PhoneId,
                            LpdPhoneIdRef = itm.LpdPhoneIdRef
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LprPhone01View>> deleteone(                
             [FromQuery] System.Int32 lpdPhoneIdRef
                
            ,[FromQuery] System.Int32 phoneId
                
           )
        {

                LprPhone01View result = await db.LprPhone01DbSet
                    .Where(p => p.LpdPhoneIdRef == lpdPhoneIdRef)
                    .Where(p => p.PhoneId == phoneId)
                    .Select(itm => new LprPhone01View() {
                            PhoneId = itm.PhoneId,
                            LpdPhoneIdRef = itm.LpdPhoneIdRef
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LprPhone01 entityToDelete = await db.LprPhone01DbSet
                    .Where(p => p.LpdPhoneIdRef == result.LpdPhoneIdRef)
                    .Where(p => p.PhoneId == result.PhoneId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LprPhone01DbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

