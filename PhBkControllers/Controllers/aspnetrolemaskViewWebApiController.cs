#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinqKit;

using PhBkContext.Auth;
using PhBkViews.Auth;
using PhBkEntity.Auth;

namespace PhBkControllers.Controllers {

//    [RoutePrefix("aspnetrolemaskviewwebapi")]
    [ApiController]
    public class aspnetrolemaskViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly aspnetchckdbcontext db;

        public aspnetrolemaskViewWebApiController(aspnetchckdbcontext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<aspnetrolemaskView>>> getall()
        {
            return await db.aspnetrolemaskDbSet
                    .Select(itm => new aspnetrolemaskView() {
                            RoleDescription = itm.RoleDescription,
                            Mask1 = itm.Mask1,
                            Mask2 = itm.Mask2,
                            Mask3 = itm.Mask3,
                            Mask4 = itm.Mask4,
                            Mask5 = itm.Mask5,
                            ModelPkRef = itm.ModelPkRef,
                            MModelName = itm.AspNetModel.ModelName,
                            RName = itm.RoleName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<aspnetrolemaskViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] modelPkRef, 
            [FromQuery] string[] modelPkRefOprtr,
                
            [FromQuery] System.String[] mModelName, 
            [FromQuery] string[] mModelNameOprtr,
                
            [FromQuery] System.String[] rName, 
            [FromQuery] string[] rNameOprtr,
                 
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
            IQueryable<aspnetrolemask> query = db.aspnetrolemaskDbSet;
            int _modelPkRef = modelPkRef == null ? 0 : modelPkRef.Length;
            if (_modelPkRef > 0) {
                int _modelPkRefOprtr = modelPkRefOprtr == null ? 0 : modelPkRefOprtr.Length;
                for(int i = 0; i < _modelPkRef; i++) {
                    string op_modelPkRefOprtr = (i >= _modelPkRefOprtr) ? "eq" : (modelPkRefOprtr[i] == null) ? "eq" : modelPkRefOprtr[i];
                    var _tmpmodelPkRef = modelPkRef[i];
                    switch(op_modelPkRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.ModelPkRef == _tmpmodelPkRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.ModelPkRef == _tmpmodelPkRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.ModelPkRef >= _tmpmodelPkRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.ModelPkRef <= _tmpmodelPkRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.ModelPkRef != _tmpmodelPkRef));
                            break;
                    }
                }
            }
            int _mModelName = mModelName == null ? 0 : mModelName.Length;
            if (_mModelName > 0) {
                int _mModelNameOprtr = mModelNameOprtr == null ? 0 : mModelNameOprtr.Length;
                for(int i = 0; i < _mModelName; i++) {
                    string op_mModelNameOprtr = (i >= _mModelNameOprtr) ? "eq" : (mModelNameOprtr[i] == null) ? "eq" : mModelNameOprtr[i];
                    var _tmpmModelName = mModelName[i];
                    switch(op_mModelNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.AspNetModel.ModelName.Contains(_tmpmModelName));
                            break;
                        case "lk":
                            query = query.Where(p => p.AspNetModel.ModelName.Contains(_tmpmModelName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.AspNetModel.ModelName.CompareTo(_tmpmModelName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.AspNetModel.ModelName.CompareTo(_tmpmModelName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.AspNetModel.ModelName.CompareTo(_tmpmModelName) != 0));
                            break;
                    }
                }
            }
            int _rName = rName == null ? 0 : rName.Length;
            if (_rName > 0) {
                int _rNameOprtr = rNameOprtr == null ? 0 : rNameOprtr.Length;
                for(int i = 0; i < _rName; i++) {
                    string op_rNameOprtr = (i >= _rNameOprtr) ? "eq" : (rNameOprtr[i] == null) ? "eq" : rNameOprtr[i];
                    var _tmprName = rName[i];
                    switch(op_rNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.RoleName.Contains(_tmprName));
                            break;
                        case "lk":
                            query = query.Where(p => p.RoleName.Contains(_tmprName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.RoleName.CompareTo(_tmprName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.RoleName.CompareTo(_tmprName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.RoleName.CompareTo(_tmprName) != 0));
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
                IOrderedQueryable<aspnetrolemask> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "modelpkref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.ModelPkRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.ModelPkRef);
                                }
                                wasInUseOrderBy.Add("modelpkref");
                                wasInUseOrderBy.Add("-modelpkref");
                                break;
                            case "-modelpkref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.ModelPkRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.ModelPkRef);
                                }
                                wasInUseOrderBy.Add("modelpkref");
                                wasInUseOrderBy.Add("-modelpkref");
                                break;
                            case "mmodelname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.AspNetModel.ModelName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.AspNetModel.ModelName);
                                }
                                wasInUseOrderBy.Add("mmodelname");
                                wasInUseOrderBy.Add("-mmodelname");
                                break;
                            case "-mmodelname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.AspNetModel.ModelName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.AspNetModel.ModelName);
                                }
                                wasInUseOrderBy.Add("mmodelname");
                                wasInUseOrderBy.Add("-mmodelname");
                                break;
                            case "rname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.RoleName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.RoleName);
                                }
                                wasInUseOrderBy.Add("rname");
                                wasInUseOrderBy.Add("-rname");
                                break;
                            case "-rname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.RoleName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.RoleName);
                                }
                                wasInUseOrderBy.Add("rname");
                                wasInUseOrderBy.Add("-rname");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.RoleName);
                } // totals pageCount currentPageSize
                aspnetrolemaskViewPage resultObject = new aspnetrolemaskViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetrolemaskView() {
                            RoleDescription = itm.RoleDescription,
                            Mask1 = itm.Mask1,
                            Mask2 = itm.Mask2,
                            Mask3 = itm.Mask3,
                            Mask4 = itm.Mask4,
                            Mask5 = itm.Mask5,
                            ModelPkRef = itm.ModelPkRef,
                            MModelName = itm.AspNetModel.ModelName,
                            RName = itm.RoleName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<aspnetrolemaskView>> getone(                
             [FromQuery] System.String rName
                
            ,[FromQuery] System.Int32 modelPkRef
                
             )
        {
            aspnetrolemaskView result = await db.aspnetrolemaskDbSet
                    .Where(p => p.RoleName == rName)
                    .Where(p => p.ModelPkRef == modelPkRef)
                    .Select(itm => new aspnetrolemaskView() {
                            RoleDescription = itm.RoleDescription,
                            Mask1 = itm.Mask1,
                            Mask2 = itm.Mask2,
                            Mask3 = itm.Mask3,
                            Mask4 = itm.Mask4,
                            Mask5 = itm.Mask5,
                            ModelPkRef = itm.ModelPkRef,
                            MModelName = itm.AspNetModel.ModelName,
                            RName = itm.RoleName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<aspnetrolemaskViewPage>> getmanybyrepprim(
                
             [FromQuery] System.String[] rName,
             [FromQuery] string[] rNameOprtr,
                
             [FromQuery] System.Int32?[] modelPkRef,
             [FromQuery] string[] modelPkRefOprtr,
            
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

                
            int _rName = rName == null ? 0 : rName.Length;
            int _rNameOprtr = rNameOprtr == null ? 0 : rNameOprtr.Length;
            int _appldrName = 0;
                
            int _modelPkRef = modelPkRef == null ? 0 : modelPkRef.Length;
            int _modelPkRefOprtr = modelPkRefOprtr == null ? 0 : modelPkRefOprtr.Length;
            int _appldmodelPkRef = 0;
                
            IQueryable<aspnetrolemask> query = db.aspnetrolemaskDbSet;
            var _outer = PredicateBuilder.New<aspnetrolemask>(false);
            bool isOuterModified = false;
            if ( _rName > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _rName; i++) {
                    var _inner = PredicateBuilder.New<aspnetrolemask>(true);
                    isLkOp = false;
                    if(i < _rNameOprtr) {
                        isLkOp = rNameOprtr[i] == "lk";
                    }
                
                    if (rName[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmprName = rName[i];
                       
                    if(isLkOp) { _inner = _inner.And(p => p.RoleName.StartsWith(_tmprName)); }
                    else { _inner = _inner.And(p => p.RoleName == _tmprName); }
                    _appldrName++;
                
                    if (_modelPkRef <= i) {
                        _outer = _outer.Or(_inner);
                        isOuterModified = true;
                        continue;
                    }
                    isLkOp = false;
                    if(i < _modelPkRefOprtr) {
                        isLkOp = modelPkRefOprtr[i] == "lk";
                    }
                
                    if (modelPkRef[i] == null) // continue; (required prop == null) returns false
                    {
                        if(i < 1) {
                            _outer = _outer.Or(_inner);
                            isOuterModified = true;
                        }
                        continue;
                    }
                    var _tmpmodelPkRef = modelPkRef[i];
                        
                    _inner = _inner.And(p => p.ModelPkRef == _tmpmodelPkRef);
                    _appldmodelPkRef++;
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            bool isForeignAdded = false;
            var _outerAnd = PredicateBuilder.New<aspnetrolemask>(true);
                
             if(modelPkRef != null) {
                if(modelPkRef.Length > 0) {
                    for(int i = 0; i < modelPkRef.Length; i++) {
                        if(i < _appldmodelPkRef) continue; // skip props which are used by the PrimKey
                
                        if (modelPkRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpmodelPkRef = modelPkRef[i];
                        _outerAnd = _outerAnd.And(p => p.ModelPkRef == _tmpmodelPkRef);
                        isForeignAdded = true;
                    }
                }
             }
                
             if(rName != null) {
                if(rName.Length > 0) {
                    for(int i = 0; i < rName.Length; i++) {
                        if(i < _appldrName) continue; // skip props which are used by the PrimKey
                
                        if (rName[i] == null) continue; // (required prop == null) returns false
                        var _tmprName = rName[i];
                        _outerAnd = _outerAnd.And(p => p.RoleName == _tmprName);
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
            IOrderedQueryable<aspnetrolemask> orderedQuery = null;
            if(!isForeignAdded)
            {

                orderedQuery = query.OrderBy(p => p.RoleName);
                
                orderedQuery = orderedQuery.ThenBy(p => p.ModelPkRef);
              
                query = orderedQuery;
            }  
            aspnetrolemaskViewPage resultObject = new aspnetrolemaskViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetrolemaskView() {
                            RoleDescription = itm.RoleDescription,
                            Mask1 = itm.Mask1,
                            Mask2 = itm.Mask2,
                            Mask3 = itm.Mask3,
                            Mask4 = itm.Mask4,
                            Mask5 = itm.Mask5,
                            ModelPkRef = itm.ModelPkRef,
                            MModelName = itm.AspNetModel.ModelName,
                            RName = itm.RoleName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<aspnetrolemaskView>> updateone([FromBody] aspnetrolemaskView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            aspnetrolemask resultEntity = await db.aspnetrolemaskDbSet
                    .Where(p => p.RoleName == viewToUpdate.RName)
                    .Where(p => p.ModelPkRef == viewToUpdate.ModelPkRef)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.RoleDescription =  viewToUpdate.RoleDescription;
            resultEntity.Mask1 =  viewToUpdate.Mask1;
            resultEntity.Mask2 =  viewToUpdate.Mask2;
            resultEntity.Mask3 =  viewToUpdate.Mask3;
            resultEntity.Mask4 =  viewToUpdate.Mask4;
            resultEntity.Mask5 =  viewToUpdate.Mask5;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            aspnetrolemaskView result = await db.aspnetrolemaskDbSet
                    .Where(p => p.RoleName == viewToUpdate.RName)
                    .Where(p => p.ModelPkRef == viewToUpdate.ModelPkRef)
                    .Select(itm => new aspnetrolemaskView() {
                            RoleDescription = itm.RoleDescription,
                            Mask1 = itm.Mask1,
                            Mask2 = itm.Mask2,
                            Mask3 = itm.Mask3,
                            Mask4 = itm.Mask4,
                            Mask5 = itm.Mask5,
                            ModelPkRef = itm.ModelPkRef,
                            MModelName = itm.AspNetModel.ModelName,
                            RName = itm.RoleName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<aspnetrolemaskView>> addone([FromBody] aspnetrolemaskView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            aspnetrolemask entityToAdd = new aspnetrolemask();
            entityToAdd.RoleDescription =  viewToAdd.RoleDescription;
            entityToAdd.Mask1 =  viewToAdd.Mask1;
            entityToAdd.Mask2 =  viewToAdd.Mask2;
            entityToAdd.Mask3 =  viewToAdd.Mask3;
            entityToAdd.Mask4 =  viewToAdd.Mask4;
            entityToAdd.Mask5 =  viewToAdd.Mask5;
            entityToAdd.ModelPkRef =  viewToAdd.ModelPkRef;
            entityToAdd.RoleName =  viewToAdd.RName;
            db.aspnetrolemaskDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            aspnetrolemaskView result = await db.aspnetrolemaskDbSet
                    .Where(p => p.RoleName == entityToAdd.RoleName)
                    .Where(p => p.ModelPkRef == entityToAdd.ModelPkRef)
                    .Select(itm => new aspnetrolemaskView() {
                            RoleDescription = itm.RoleDescription,
                            Mask1 = itm.Mask1,
                            Mask2 = itm.Mask2,
                            Mask3 = itm.Mask3,
                            Mask4 = itm.Mask4,
                            Mask5 = itm.Mask5,
                            ModelPkRef = itm.ModelPkRef,
                            MModelName = itm.AspNetModel.ModelName,
                            RName = itm.RoleName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<aspnetrolemaskView>> deleteone(                
             [FromQuery] System.String rName
                
            ,[FromQuery] System.Int32 modelPkRef
                
           )
        {

                aspnetrolemaskView result = await db.aspnetrolemaskDbSet
                    .Where(p => p.RoleName == rName)
                    .Where(p => p.ModelPkRef == modelPkRef)
                    .Select(itm => new aspnetrolemaskView() {
                            RoleDescription = itm.RoleDescription,
                            Mask1 = itm.Mask1,
                            Mask2 = itm.Mask2,
                            Mask3 = itm.Mask3,
                            Mask4 = itm.Mask4,
                            Mask5 = itm.Mask5,
                            ModelPkRef = itm.ModelPkRef,
                            MModelName = itm.AspNetModel.ModelName,
                            RName = itm.RoleName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                aspnetrolemask entityToDelete = await db.aspnetrolemaskDbSet
                    .Where(p => p.RoleName == result.RName)
                    .Where(p => p.ModelPkRef == result.ModelPkRef)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.aspnetrolemaskDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

