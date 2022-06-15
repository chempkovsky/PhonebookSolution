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

//    [RoutePrefix("lpremployee01viewwebapi")]
    [ApiController]
    public class LprEmployee01ViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly LpEmpPhBkContext db;

        public LprEmployee01ViewWebApiController(LpEmpPhBkContext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<LprEmployee01View>>> getall()
        {
            return await db.LprEmployee01DbSet
                    .Select(itm => new LprEmployee01View() {
                            EmployeeId = itm.EmployeeId,
                            EmpLastNameIdRef = itm.EmpLastNameIdRef,
                            EmpFirstNameIdRef = itm.EmpFirstNameIdRef,
                            EmpSecondNameIdRef = itm.EmpSecondNameIdRef

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<LprEmployee01ViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] employeeId, 
            [FromQuery] string[] employeeIdOprtr,
                
            [FromQuery] System.Int32?[] empLastNameIdRef, 
            [FromQuery] string[] empLastNameIdRefOprtr,
                
            [FromQuery] System.Int32?[] empFirstNameIdRef, 
            [FromQuery] string[] empFirstNameIdRefOprtr,
                
            [FromQuery] System.Int32?[] empSecondNameIdRef, 
            [FromQuery] string[] empSecondNameIdRefOprtr,
                 
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
            IQueryable<LprEmployee01> query = db.LprEmployee01DbSet;
            int _employeeId = employeeId == null ? 0 : employeeId.Length;
            if (_employeeId > 0) {
                int _employeeIdOprtr = employeeIdOprtr == null ? 0 : employeeIdOprtr.Length;
                for(int i = 0; i < _employeeId; i++) {
                    string op_employeeIdOprtr = (i >= _employeeIdOprtr) ? "eq" : (employeeIdOprtr[i] == null) ? "eq" : employeeIdOprtr[i];
                    var _tmpemployeeId = employeeId[i];
                    switch(op_employeeIdOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmployeeId == _tmpemployeeId));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmployeeId == _tmpemployeeId));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmployeeId >= _tmpemployeeId));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmployeeId <= _tmpemployeeId));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmployeeId != _tmpemployeeId));
                            break;
                    }
                }
            }
            int _empLastNameIdRef = empLastNameIdRef == null ? 0 : empLastNameIdRef.Length;
            if (_empLastNameIdRef > 0) {
                int _empLastNameIdRefOprtr = empLastNameIdRefOprtr == null ? 0 : empLastNameIdRefOprtr.Length;
                for(int i = 0; i < _empLastNameIdRef; i++) {
                    string op_empLastNameIdRefOprtr = (i >= _empLastNameIdRefOprtr) ? "eq" : (empLastNameIdRefOprtr[i] == null) ? "eq" : empLastNameIdRefOprtr[i];
                    var _tmpempLastNameIdRef = empLastNameIdRef[i];
                    switch(op_empLastNameIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmpLastNameIdRef == _tmpempLastNameIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmpLastNameIdRef == _tmpempLastNameIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpLastNameIdRef >= _tmpempLastNameIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpLastNameIdRef <= _tmpempLastNameIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpLastNameIdRef != _tmpempLastNameIdRef));
                            break;
                    }
                }
            }
            int _empFirstNameIdRef = empFirstNameIdRef == null ? 0 : empFirstNameIdRef.Length;
            if (_empFirstNameIdRef > 0) {
                int _empFirstNameIdRefOprtr = empFirstNameIdRefOprtr == null ? 0 : empFirstNameIdRefOprtr.Length;
                for(int i = 0; i < _empFirstNameIdRef; i++) {
                    string op_empFirstNameIdRefOprtr = (i >= _empFirstNameIdRefOprtr) ? "eq" : (empFirstNameIdRefOprtr[i] == null) ? "eq" : empFirstNameIdRefOprtr[i];
                    var _tmpempFirstNameIdRef = empFirstNameIdRef[i];
                    switch(op_empFirstNameIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmpFirstNameIdRef == _tmpempFirstNameIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmpFirstNameIdRef == _tmpempFirstNameIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpFirstNameIdRef >= _tmpempFirstNameIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpFirstNameIdRef <= _tmpempFirstNameIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpFirstNameIdRef != _tmpempFirstNameIdRef));
                            break;
                    }
                }
            }
            int _empSecondNameIdRef = empSecondNameIdRef == null ? 0 : empSecondNameIdRef.Length;
            if (_empSecondNameIdRef > 0) {
                int _empSecondNameIdRefOprtr = empSecondNameIdRefOprtr == null ? 0 : empSecondNameIdRefOprtr.Length;
                for(int i = 0; i < _empSecondNameIdRef; i++) {
                    string op_empSecondNameIdRefOprtr = (i >= _empSecondNameIdRefOprtr) ? "eq" : (empSecondNameIdRefOprtr[i] == null) ? "eq" : empSecondNameIdRefOprtr[i];
                    var _tmpempSecondNameIdRef = empSecondNameIdRef[i];
                    switch(op_empSecondNameIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmpSecondNameIdRef == _tmpempSecondNameIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmpSecondNameIdRef == _tmpempSecondNameIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpSecondNameIdRef >= _tmpempSecondNameIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpSecondNameIdRef <= _tmpempSecondNameIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpSecondNameIdRef != _tmpempSecondNameIdRef));
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
                IOrderedQueryable<LprEmployee01> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "employeeid" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmployeeId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmployeeId);
                                }
                                wasInUseOrderBy.Add("employeeid");
                                wasInUseOrderBy.Add("-employeeid");
                                break;
                            case "-employeeid" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmployeeId);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmployeeId);
                                }
                                wasInUseOrderBy.Add("employeeid");
                                wasInUseOrderBy.Add("-employeeid");
                                break;
                            case "emplastnameidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpLastNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpLastNameIdRef);
                                }
                                wasInUseOrderBy.Add("emplastnameidref");
                                wasInUseOrderBy.Add("-emplastnameidref");
                                break;
                            case "-emplastnameidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpLastNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpLastNameIdRef);
                                }
                                wasInUseOrderBy.Add("emplastnameidref");
                                wasInUseOrderBy.Add("-emplastnameidref");
                                break;
                            case "empfirstnameidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpFirstNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpFirstNameIdRef);
                                }
                                wasInUseOrderBy.Add("empfirstnameidref");
                                wasInUseOrderBy.Add("-empfirstnameidref");
                                break;
                            case "-empfirstnameidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpFirstNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpFirstNameIdRef);
                                }
                                wasInUseOrderBy.Add("empfirstnameidref");
                                wasInUseOrderBy.Add("-empfirstnameidref");
                                break;
                            case "empsecondnameidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpSecondNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpSecondNameIdRef);
                                }
                                wasInUseOrderBy.Add("empsecondnameidref");
                                wasInUseOrderBy.Add("-empsecondnameidref");
                                break;
                            case "-empsecondnameidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpSecondNameIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpSecondNameIdRef);
                                }
                                wasInUseOrderBy.Add("empsecondnameidref");
                                wasInUseOrderBy.Add("-empsecondnameidref");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.EmpLastNameIdRef);
                } // totals pageCount currentPageSize
                LprEmployee01ViewPage resultObject = new LprEmployee01ViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LprEmployee01View() {
                            EmployeeId = itm.EmployeeId,
                            EmpLastNameIdRef = itm.EmpLastNameIdRef,
                            EmpFirstNameIdRef = itm.EmpFirstNameIdRef,
                            EmpSecondNameIdRef = itm.EmpSecondNameIdRef
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<LprEmployee01View>> getone(                
             [FromQuery] System.Int32 empLastNameIdRef
                
            ,[FromQuery] System.Int32 empFirstNameIdRef
                
            ,[FromQuery] System.Int32 empSecondNameIdRef
                
            ,[FromQuery] System.Int32 employeeId
                
             )
        {
            LprEmployee01View result = await db.LprEmployee01DbSet
                    .Where(p => p.EmpLastNameIdRef == empLastNameIdRef)
                    .Where(p => p.EmpFirstNameIdRef == empFirstNameIdRef)
                    .Where(p => p.EmpSecondNameIdRef == empSecondNameIdRef)
                    .Where(p => p.EmployeeId == employeeId)
                    .Select(itm => new LprEmployee01View() {
                            EmployeeId = itm.EmployeeId,
                            EmpLastNameIdRef = itm.EmpLastNameIdRef,
                            EmpFirstNameIdRef = itm.EmpFirstNameIdRef,
                            EmpSecondNameIdRef = itm.EmpSecondNameIdRef
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<LprEmployee01ViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] empLastNameIdRef,
             [FromQuery] string[] empLastNameIdRefOprtr,
                
             [FromQuery] System.Int32?[] empFirstNameIdRef,
             [FromQuery] string[] empFirstNameIdRefOprtr,
                
             [FromQuery] System.Int32?[] empSecondNameIdRef,
             [FromQuery] string[] empSecondNameIdRefOprtr,
                
             [FromQuery] System.Int32?[] employeeId,
             [FromQuery] string[] employeeIdOprtr,
            
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

                
            int _empLastNameIdRef = empLastNameIdRef == null ? 0 : empLastNameIdRef.Length;
            int _empLastNameIdRefOprtr = empLastNameIdRefOprtr == null ? 0 : empLastNameIdRefOprtr.Length;
            int _appldempLastNameIdRef = 0;
                
            int _empFirstNameIdRef = empFirstNameIdRef == null ? 0 : empFirstNameIdRef.Length;
            int _empFirstNameIdRefOprtr = empFirstNameIdRefOprtr == null ? 0 : empFirstNameIdRefOprtr.Length;
            int _appldempFirstNameIdRef = 0;
                
            int _empSecondNameIdRef = empSecondNameIdRef == null ? 0 : empSecondNameIdRef.Length;
            int _empSecondNameIdRefOprtr = empSecondNameIdRefOprtr == null ? 0 : empSecondNameIdRefOprtr.Length;
            int _appldempSecondNameIdRef = 0;
                
            int _employeeId = employeeId == null ? 0 : employeeId.Length;
            int _employeeIdOprtr = employeeIdOprtr == null ? 0 : employeeIdOprtr.Length;
                
            IQueryable<LprEmployee01> query = db.LprEmployee01DbSet;
            var _outer = PredicateBuilder.New<LprEmployee01>(false);
            bool isOuterModified = false;
            if ( _empLastNameIdRef > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _empLastNameIdRef; i++) {
                    var _inner = PredicateBuilder.New<LprEmployee01>(true);
                    isLkOp = false;
                    if(i < _empLastNameIdRefOprtr) {
                        isLkOp = empLastNameIdRefOprtr[i] == "lk";
                    }
                
                    if (empLastNameIdRef[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpempLastNameIdRef = empLastNameIdRef[i];
                        
                    _inner = _inner.And(p => p.EmpLastNameIdRef == _tmpempLastNameIdRef);
                    _appldempLastNameIdRef++;
                
                    if (_empFirstNameIdRef <= i) {
                        _outer = _outer.Or(_inner);
                        isOuterModified = true;
                        continue;
                    }
                    isLkOp = false;
                    if(i < _empFirstNameIdRefOprtr) {
                        isLkOp = empFirstNameIdRefOprtr[i] == "lk";
                    }
                
                    if (empFirstNameIdRef[i] == null) // continue; (required prop == null) returns false
                    {
                        if(i < 1) {
                            _outer = _outer.Or(_inner);
                            isOuterModified = true;
                        }
                        continue;
                    }
                    var _tmpempFirstNameIdRef = empFirstNameIdRef[i];
                        
                    _inner = _inner.And(p => p.EmpFirstNameIdRef == _tmpempFirstNameIdRef);
                    _appldempFirstNameIdRef++;
                
                    if (_empSecondNameIdRef <= i) {
                        _outer = _outer.Or(_inner);
                        isOuterModified = true;
                        continue;
                    }
                    isLkOp = false;
                    if(i < _empSecondNameIdRefOprtr) {
                        isLkOp = empSecondNameIdRefOprtr[i] == "lk";
                    }
                
                    if (empSecondNameIdRef[i] == null) // continue; (required prop == null) returns false
                    {
                        if(i < 1) {
                            _outer = _outer.Or(_inner);
                            isOuterModified = true;
                        }
                        continue;
                    }
                    var _tmpempSecondNameIdRef = empSecondNameIdRef[i];
                        
                    _inner = _inner.And(p => p.EmpSecondNameIdRef == _tmpempSecondNameIdRef);
                    _appldempSecondNameIdRef++;
                
                    if (_employeeId <= i) {
                        _outer = _outer.Or(_inner);
                        isOuterModified = true;
                        continue;
                    }
                    isLkOp = false;
                    if(i < _employeeIdOprtr) {
                        isLkOp = employeeIdOprtr[i] == "lk";
                    }
                
                    if (employeeId[i] == null) // continue; (required prop == null) returns false
                    {
                        if(i < 1) {
                            _outer = _outer.Or(_inner);
                            isOuterModified = true;
                        }
                        continue;
                    }
                    var _tmpemployeeId = employeeId[i];
                        
                    _inner = _inner.And(p => p.EmployeeId == _tmpemployeeId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            bool isForeignAdded = false;
            var _outerAnd = PredicateBuilder.New<LprEmployee01>(true);
                
             if(empLastNameIdRef != null) {
                if(empLastNameIdRef.Length > 0) {
                    for(int i = 0; i < empLastNameIdRef.Length; i++) {
                        if(i < _appldempLastNameIdRef) continue; // skip props which are used by the PrimKey
                
                        if (empLastNameIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpempLastNameIdRef = empLastNameIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.EmpLastNameIdRef == _tmpempLastNameIdRef);
                        isForeignAdded = true;
                    }
                }
             }
                
             if(empFirstNameIdRef != null) {
                if(empFirstNameIdRef.Length > 0) {
                    for(int i = 0; i < empFirstNameIdRef.Length; i++) {
                        if(i < _appldempFirstNameIdRef) continue; // skip props which are used by the PrimKey
                
                        if (empFirstNameIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpempFirstNameIdRef = empFirstNameIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.EmpFirstNameIdRef == _tmpempFirstNameIdRef);
                        isForeignAdded = true;
                    }
                }
             }
                
             if(empSecondNameIdRef != null) {
                if(empSecondNameIdRef.Length > 0) {
                    for(int i = 0; i < empSecondNameIdRef.Length; i++) {
                        if(i < _appldempSecondNameIdRef) continue; // skip props which are used by the PrimKey
                
                        if (empSecondNameIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpempSecondNameIdRef = empSecondNameIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.EmpSecondNameIdRef == _tmpempSecondNameIdRef);
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
            IOrderedQueryable<LprEmployee01> orderedQuery = null;
            if(!isForeignAdded)
            {

                orderedQuery = query.OrderBy(p => p.EmpLastNameIdRef);
                
                orderedQuery = orderedQuery.ThenBy(p => p.EmpFirstNameIdRef);
                
                orderedQuery = orderedQuery.ThenBy(p => p.EmpSecondNameIdRef);
                
                orderedQuery = orderedQuery.ThenBy(p => p.EmployeeId);
              
                query = orderedQuery;
            }  
            LprEmployee01ViewPage resultObject = new LprEmployee01ViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new LprEmployee01View() {
                            EmployeeId = itm.EmployeeId,
                            EmpLastNameIdRef = itm.EmpLastNameIdRef,
                            EmpFirstNameIdRef = itm.EmpFirstNameIdRef,
                            EmpSecondNameIdRef = itm.EmpSecondNameIdRef
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<LprEmployee01View>> updateone([FromBody] LprEmployee01View viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LprEmployee01 resultEntity = await db.LprEmployee01DbSet
                    .Where(p => p.EmpLastNameIdRef == viewToUpdate.EmpLastNameIdRef)
                    .Where(p => p.EmpFirstNameIdRef == viewToUpdate.EmpFirstNameIdRef)
                    .Where(p => p.EmpSecondNameIdRef == viewToUpdate.EmpSecondNameIdRef)
                    .Where(p => p.EmployeeId == viewToUpdate.EmployeeId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            LprEmployee01View result = await db.LprEmployee01DbSet
                    .Where(p => p.EmpLastNameIdRef == viewToUpdate.EmpLastNameIdRef)
                    .Where(p => p.EmpFirstNameIdRef == viewToUpdate.EmpFirstNameIdRef)
                    .Where(p => p.EmpSecondNameIdRef == viewToUpdate.EmpSecondNameIdRef)
                    .Where(p => p.EmployeeId == viewToUpdate.EmployeeId)
                    .Select(itm => new LprEmployee01View() {
                            EmployeeId = itm.EmployeeId,
                            EmpLastNameIdRef = itm.EmpLastNameIdRef,
                            EmpFirstNameIdRef = itm.EmpFirstNameIdRef,
                            EmpSecondNameIdRef = itm.EmpSecondNameIdRef
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<LprEmployee01View>> addone([FromBody] LprEmployee01View viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            LprEmployee01 entityToAdd = new LprEmployee01();
            entityToAdd.EmployeeId =  viewToAdd.EmployeeId;
            entityToAdd.EmpLastNameIdRef =  viewToAdd.EmpLastNameIdRef;
            entityToAdd.EmpFirstNameIdRef =  viewToAdd.EmpFirstNameIdRef;
            entityToAdd.EmpSecondNameIdRef =  viewToAdd.EmpSecondNameIdRef;
            db.LprEmployee01DbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            LprEmployee01View result = await db.LprEmployee01DbSet
                    .Where(p => p.EmpLastNameIdRef == entityToAdd.EmpLastNameIdRef)
                    .Where(p => p.EmpFirstNameIdRef == entityToAdd.EmpFirstNameIdRef)
                    .Where(p => p.EmpSecondNameIdRef == entityToAdd.EmpSecondNameIdRef)
                    .Where(p => p.EmployeeId == entityToAdd.EmployeeId)
                    .Select(itm => new LprEmployee01View() {
                            EmployeeId = itm.EmployeeId,
                            EmpLastNameIdRef = itm.EmpLastNameIdRef,
                            EmpFirstNameIdRef = itm.EmpFirstNameIdRef,
                            EmpSecondNameIdRef = itm.EmpSecondNameIdRef
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<LprEmployee01View>> deleteone(                
             [FromQuery] System.Int32 empLastNameIdRef
                
            ,[FromQuery] System.Int32 empFirstNameIdRef
                
            ,[FromQuery] System.Int32 empSecondNameIdRef
                
            ,[FromQuery] System.Int32 employeeId
                
           )
        {

                LprEmployee01View result = await db.LprEmployee01DbSet
                    .Where(p => p.EmpLastNameIdRef == empLastNameIdRef)
                    .Where(p => p.EmpFirstNameIdRef == empFirstNameIdRef)
                    .Where(p => p.EmpSecondNameIdRef == empSecondNameIdRef)
                    .Where(p => p.EmployeeId == employeeId)
                    .Select(itm => new LprEmployee01View() {
                            EmployeeId = itm.EmployeeId,
                            EmpLastNameIdRef = itm.EmpLastNameIdRef,
                            EmpFirstNameIdRef = itm.EmpFirstNameIdRef,
                            EmpSecondNameIdRef = itm.EmpSecondNameIdRef
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                LprEmployee01 entityToDelete = await db.LprEmployee01DbSet
                    .Where(p => p.EmpLastNameIdRef == result.EmpLastNameIdRef)
                    .Where(p => p.EmpFirstNameIdRef == result.EmpFirstNameIdRef)
                    .Where(p => p.EmpSecondNameIdRef == result.EmpSecondNameIdRef)
                    .Where(p => p.EmployeeId == result.EmployeeId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.LprEmployee01DbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

