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

//    [RoutePrefix("phbkphonetypeviewwebapi")]
    [ApiController]
    public class PhbkPhoneTypeViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly PhbkDbContext db;

        public PhbkPhoneTypeViewWebApiController(PhbkDbContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<PhbkPhoneTypeView>>> getall()
        {
            return await db.PhbkPhoneTypeDbSet
                    .Select(itm => new PhbkPhoneTypeView() {
                            PhoneTypeId = itm.PhoneTypeId,
                            PhoneTypeName = itm.PhoneTypeName,
                            PhoneTypeDesc = itm.PhoneTypeDesc

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<PhbkPhoneTypeViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] phoneTypeId, 
            [FromQuery] string[] phoneTypeIdOprtr,
                
            [FromQuery] System.String[] phoneTypeName, 
            [FromQuery] string[] phoneTypeNameOprtr,
                 
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
            IQueryable<PhbkPhoneType> query = db.PhbkPhoneTypeDbSet;
            int _phoneTypeId = phoneTypeId == null ? 0 : phoneTypeId.Length;
            if (_phoneTypeId > 0) {
                int _phoneTypeIdOprtr = phoneTypeIdOprtr == null ? 0 : phoneTypeIdOprtr.Length;
                for(int i = 0; i < _phoneTypeId; i++) {
                    string op_phoneTypeIdOprtr = (i >= _phoneTypeIdOprtr) ? "eq" : (phoneTypeIdOprtr[i] == null) ? "eq" : phoneTypeIdOprtr[i];
                    var _tmpphoneTypeId = phoneTypeId[i];
                    switch(op_phoneTypeIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.PhoneTypeId == _tmpphoneTypeId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.PhoneTypeId == _tmpphoneTypeId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.PhoneTypeId >= _tmpphoneTypeId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.PhoneTypeId <= _tmpphoneTypeId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.PhoneTypeId != _tmpphoneTypeId));
                            break;
                    }
                }
            }
            int _phoneTypeName = phoneTypeName == null ? 0 : phoneTypeName.Length;
            if (_phoneTypeName > 0) {
                int _phoneTypeNameOprtr = phoneTypeNameOprtr == null ? 0 : phoneTypeNameOprtr.Length;
                for(int i = 0; i < _phoneTypeName; i++) {
                    string op_phoneTypeNameOprtr = (i >= _phoneTypeNameOprtr) ? "eq" : (phoneTypeNameOprtr[i] == null) ? "eq" : phoneTypeNameOprtr[i];
                    var _tmpphoneTypeName = phoneTypeName[i];
                    switch(op_phoneTypeNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.PhoneTypeName.Contains(_tmpphoneTypeName));
                            break;
                        case "lk":
                            query = query.Where(p => p.PhoneTypeName.Contains(_tmpphoneTypeName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.PhoneTypeName.CompareTo(_tmpphoneTypeName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.PhoneTypeName.CompareTo(_tmpphoneTypeName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.PhoneTypeName.CompareTo(_tmpphoneTypeName) != 0));
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
                IOrderedQueryable<PhbkPhoneType> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "phonetypeid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.PhoneTypeId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.PhoneTypeId);
                                }
                                wasInUseOrderBy.Add("phonetypeid");
                                wasInUseOrderBy.Add("-phonetypeid");
                                break;
                            case "-phonetypeid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.PhoneTypeId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.PhoneTypeId);
                                }
                                wasInUseOrderBy.Add("phonetypeid");
                                wasInUseOrderBy.Add("-phonetypeid");
                                break;
                            case "phonetypename" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.PhoneTypeName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.PhoneTypeName);
                                }
                                wasInUseOrderBy.Add("phonetypename");
                                wasInUseOrderBy.Add("-phonetypename");
                                break;
                            case "-phonetypename" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.PhoneTypeName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.PhoneTypeName);
                                }
                                wasInUseOrderBy.Add("phonetypename");
                                wasInUseOrderBy.Add("-phonetypename");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.PhoneTypeId);
                } // totals pageCount currentPageSize
                PhbkPhoneTypeViewPage resultObject = new PhbkPhoneTypeViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkPhoneTypeView() {
                            PhoneTypeId = itm.PhoneTypeId,
                            PhoneTypeName = itm.PhoneTypeName,
                            PhoneTypeDesc = itm.PhoneTypeDesc
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<PhbkPhoneTypeView>> getone(                
             [FromQuery] System.Int32 phoneTypeId
                
             )
        {
            PhbkPhoneTypeView result = await db.PhbkPhoneTypeDbSet
                    .Where(p => p.PhoneTypeId == phoneTypeId)
                    .Select(itm => new PhbkPhoneTypeView() {
                            PhoneTypeId = itm.PhoneTypeId,
                            PhoneTypeName = itm.PhoneTypeName,
                            PhoneTypeDesc = itm.PhoneTypeDesc
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<PhbkPhoneTypeViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] phoneTypeId,
             [FromQuery] string[] phoneTypeIdOprtr,
            
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

                
            int _phoneTypeId = phoneTypeId == null ? 0 : phoneTypeId.Length;
            int _phoneTypeIdOprtr = phoneTypeIdOprtr == null ? 0 : phoneTypeIdOprtr.Length;
                
            IQueryable<PhbkPhoneType> query = db.PhbkPhoneTypeDbSet;
            var _outer = PredicateBuilder.New<PhbkPhoneType>(false);
            bool isOuterModified = false;
            if ( _phoneTypeId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _phoneTypeId; i++) {
                    var _inner = PredicateBuilder.New<PhbkPhoneType>(true);
                    isLkOp = false;
                    if(i < _phoneTypeIdOprtr) {
                        isLkOp = phoneTypeIdOprtr[i] == "lk";
                    }
                
                    if (phoneTypeId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpphoneTypeId = phoneTypeId[i];
                        
                    _inner = _inner.And(p => p.PhoneTypeId == _tmpphoneTypeId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<PhbkPhoneType> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.PhoneTypeId);
              
                query = orderedQuery;
            }  
            PhbkPhoneTypeViewPage resultObject = new PhbkPhoneTypeViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkPhoneTypeView() {
                            PhoneTypeId = itm.PhoneTypeId,
                            PhoneTypeName = itm.PhoneTypeName,
                            PhoneTypeDesc = itm.PhoneTypeDesc
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<PhbkPhoneTypeView>> updateone([FromBody] PhbkPhoneTypeView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PhbkPhoneType resultEntity = await db.PhbkPhoneTypeDbSet
                    .Where(p => p.PhoneTypeId == viewToUpdate.PhoneTypeId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.PhoneTypeName =  viewToUpdate.PhoneTypeName;
            resultEntity.PhoneTypeDesc =  viewToUpdate.PhoneTypeDesc;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            PhbkPhoneTypeView result = await db.PhbkPhoneTypeDbSet
                    .Where(p => p.PhoneTypeId == viewToUpdate.PhoneTypeId)
                    .Select(itm => new PhbkPhoneTypeView() {
                            PhoneTypeId = itm.PhoneTypeId,
                            PhoneTypeName = itm.PhoneTypeName,
                            PhoneTypeDesc = itm.PhoneTypeDesc
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<PhbkPhoneTypeView>> addone([FromBody] PhbkPhoneTypeView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PhbkPhoneType entityToAdd = new PhbkPhoneType();
            entityToAdd.PhoneTypeId =  viewToAdd.PhoneTypeId;
            entityToAdd.PhoneTypeName =  viewToAdd.PhoneTypeName;
            entityToAdd.PhoneTypeDesc =  viewToAdd.PhoneTypeDesc;
            db.PhbkPhoneTypeDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            PhbkPhoneTypeView result = await db.PhbkPhoneTypeDbSet
                    .Where(p => p.PhoneTypeId == entityToAdd.PhoneTypeId)
                    .Select(itm => new PhbkPhoneTypeView() {
                            PhoneTypeId = itm.PhoneTypeId,
                            PhoneTypeName = itm.PhoneTypeName,
                            PhoneTypeDesc = itm.PhoneTypeDesc
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<PhbkPhoneTypeView>> deleteone(                
             [FromQuery] System.Int32 phoneTypeId
                
           )
        {

                PhbkPhoneTypeView result = await db.PhbkPhoneTypeDbSet
                    .Where(p => p.PhoneTypeId == phoneTypeId)
                    .Select(itm => new PhbkPhoneTypeView() {
                            PhoneTypeId = itm.PhoneTypeId,
                            PhoneTypeName = itm.PhoneTypeName,
                            PhoneTypeDesc = itm.PhoneTypeDesc
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                PhbkPhoneType entityToDelete = await db.PhbkPhoneTypeDbSet
                    .Where(p => p.PhoneTypeId == result.PhoneTypeId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.PhbkPhoneTypeDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

