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

//    [RoutePrefix("lpdphoneviewwebapi")]
    [ApiController]
    public class LpdPhoneViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpPhnPhBkContext db;

        public LpdPhoneViewWebApiController(LpPhnPhBkContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<LpdPhoneView>>> getall()
        {
            return await db.LpdPhoneDbSet
                    .Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LpdPhoneViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] lpdPhoneId, 
            [FromQuery] string[] lpdPhoneIdOprtr,
                
            [FromQuery] System.String[] phone, 
            [FromQuery] string[] phoneOprtr,
                 
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
            IQueryable<LpdPhone> query = db.LpdPhoneDbSet;
            int _lpdPhoneId = lpdPhoneId == null ? 0 : lpdPhoneId.Length;
            if (_lpdPhoneId > 0) {
                int _lpdPhoneIdOprtr = lpdPhoneIdOprtr == null ? 0 : lpdPhoneIdOprtr.Length;
                for(int i = 0; i < _lpdPhoneId; i++) {
                    string op_lpdPhoneIdOprtr = (i >= _lpdPhoneIdOprtr) ? "eq" : (lpdPhoneIdOprtr[i] == null) ? "eq" : lpdPhoneIdOprtr[i];
                    var _tmplpdPhoneId = lpdPhoneId[i];
                    switch(op_lpdPhoneIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.LpdPhoneId == _tmplpdPhoneId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.LpdPhoneId == _tmplpdPhoneId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.LpdPhoneId >= _tmplpdPhoneId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.LpdPhoneId <= _tmplpdPhoneId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.LpdPhoneId != _tmplpdPhoneId));
                            break;
                    }
                }
            }
            int _phone = phone == null ? 0 : phone.Length;
            if (_phone > 0) {
                int _phoneOprtr = phoneOprtr == null ? 0 : phoneOprtr.Length;
                for(int i = 0; i < _phone; i++) {
                    string op_phoneOprtr = (i >= _phoneOprtr) ? "eq" : (phoneOprtr[i] == null) ? "eq" : phoneOprtr[i];
                    var _tmpphone = phone[i];
                    switch(op_phoneOprtr) {
                        case "eq": 
                            query = query.Where(p => p.Phone.Contains(_tmpphone));
                            break;
                        case "lk":
                            query = query.Where(p => p.Phone.Contains(_tmpphone));
                            break;
                        case "gt":
                            query = query.Where(p => (p.Phone.CompareTo(_tmpphone) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.Phone.CompareTo(_tmpphone) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.Phone.CompareTo(_tmpphone) != 0));
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
                IOrderedQueryable<LpdPhone> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "lpdphoneid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.LpdPhoneId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.LpdPhoneId);
                                }
                                wasInUseOrderBy.Add("lpdphoneid");
                                wasInUseOrderBy.Add("-lpdphoneid");
                                break;
                            case "-lpdphoneid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.LpdPhoneId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.LpdPhoneId);
                                }
                                wasInUseOrderBy.Add("lpdphoneid");
                                wasInUseOrderBy.Add("-lpdphoneid");
                                break;
                            case "phone" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.Phone);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.Phone);
                                }
                                wasInUseOrderBy.Add("phone");
                                wasInUseOrderBy.Add("-phone");
                                break;
                            case "-phone" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.Phone);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.Phone);
                                }
                                wasInUseOrderBy.Add("phone");
                                wasInUseOrderBy.Add("-phone");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.LpdPhoneId);
                } // totals pageCount currentPageSize
                LpdPhoneViewPage resultObject = new LpdPhoneViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LpdPhoneView>> getone(                
             [FromQuery] System.Int32 lpdPhoneId
                
             )
        {
            LpdPhoneView result = await db.LpdPhoneDbSet
                    .Where(p => p.LpdPhoneId == lpdPhoneId)
                    .Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LpdPhoneViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] lpdPhoneId,
             [FromQuery] string[] lpdPhoneIdOprtr,
            
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

                
            int _lpdPhoneId = lpdPhoneId == null ? 0 : lpdPhoneId.Length;
            int _lpdPhoneIdOprtr = lpdPhoneIdOprtr == null ? 0 : lpdPhoneIdOprtr.Length;
                
            IQueryable<LpdPhone> query = db.LpdPhoneDbSet;
            var _outer = PredicateBuilder.New<LpdPhone>(false);
            bool isOuterModified = false;
            if ( _lpdPhoneId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _lpdPhoneId; i++) {
                    var _inner = PredicateBuilder.New<LpdPhone>(true);
                    isLkOp = false;
                    if(i < _lpdPhoneIdOprtr) {
                        isLkOp = lpdPhoneIdOprtr[i] == "lk";
                    }
                
                    if (lpdPhoneId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmplpdPhoneId = lpdPhoneId[i];
                        
                    _inner = _inner.And(p => p.LpdPhoneId == _tmplpdPhoneId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdPhone> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.LpdPhoneId);
              
                query = orderedQuery;
            }  
            LpdPhoneViewPage resultObject = new LpdPhoneViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                            }).ToListAsync();
            return Ok(resultObject);
        }
        [HttpGet]
        [Route("[controller]/getonebyLpdPhoneUK")]
        public async Task<ActionResult<LpdPhoneView>> getonebyLpdPhoneUK(                
             [FromQuery] System.String phone
                
             )
        {
            LpdPhoneView result = await db.LpdPhoneDbSet
                    .Where(p => p.Phone == phone)
                    .Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepunqLpdPhoneUK")]
        public async Task<ActionResult<LpdPhoneViewPage>> getmanybyrepunqLpdPhoneUK(
                
             [FromQuery] System.String[] phone,
             [FromQuery] string[] phoneOprtr,
            
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

                
            int _phone = phone == null ? 0 : phone.Length;
            int _phoneOprtr = phoneOprtr == null ? 0 : phoneOprtr.Length;
                
            IQueryable<LpdPhone> query = db.LpdPhoneDbSet;
            var _outer = PredicateBuilder.New<LpdPhone>(false);
            bool isOuterModified = false;
            if ( _phone > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _phone; i++) {
                    var _inner = PredicateBuilder.New<LpdPhone>(true);
                    isLkOp = false;
                    if(i < _phoneOprtr) {
                        isLkOp = phoneOprtr[i] == "lk";
                    }
                
                    if (phone[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpphone = phone[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.Phone.StartsWith(_tmpphone)); }
                    else { _inner = _inner.And(p => p.Phone == _tmpphone); }
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<LpdPhone> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.Phone);
              
                query = orderedQuery;
            }  
            LpdPhoneViewPage resultObject = new LpdPhoneViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LpdPhoneView>> updateone([FromBody] LpdPhoneView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdPhone resultEntity = await db.LpdPhoneDbSet
                    .Where(p => p.LpdPhoneId == viewToUpdate.LpdPhoneId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.Phone =  viewToUpdate.Phone;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LpdPhoneView result = await db.LpdPhoneDbSet
                    .Where(p => p.LpdPhoneId == viewToUpdate.LpdPhoneId)
                    .Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LpdPhoneView>> addone([FromBody] LpdPhoneView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LpdPhone entityToAdd = new LpdPhone();
            entityToAdd.LpdPhoneId =  viewToAdd.LpdPhoneId;
            entityToAdd.Phone =  viewToAdd.Phone;
            db.LpdPhoneDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LpdPhoneView result = await db.LpdPhoneDbSet
                    .Where(p => p.LpdPhoneId == entityToAdd.LpdPhoneId)
                    .Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LpdPhoneView>> deleteone(                
             [FromQuery] System.Int32 lpdPhoneId
                
           )
        {

                LpdPhoneView result = await db.LpdPhoneDbSet
                    .Where(p => p.LpdPhoneId == lpdPhoneId)
                    .Select(itm => new LpdPhoneView() {
                            LpdPhoneId = itm.LpdPhoneId,
                            Phone = itm.Phone
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LpdPhone entityToDelete = await db.LpdPhoneDbSet
                    .Where(p => p.LpdPhoneId == result.LpdPhoneId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LpdPhoneDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

