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

//    [RoutePrefix("aspnetmodelviewwebapi")]
    [ApiController]
    public class aspnetmodelViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly aspnetchckdbcontext db;

        public aspnetmodelViewWebApiController(aspnetchckdbcontext context)
        {
            db = context;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<aspnetmodelView>>> getall()
        {
            return await db.aspnetmodellDbSet
                    .Select(itm => new aspnetmodelView() {
                            ModelPk = itm.ModelPk,
                            ModelName = itm.ModelName,
                            ModelDescription = itm.ModelDescription

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<aspnetmodelViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] modelPk, 
            [FromQuery] string[] modelPkOprtr,
                
            [FromQuery] System.String[] modelName, 
            [FromQuery] string[] modelNameOprtr,
                 
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
            IQueryable<aspnetmodel> query = db.aspnetmodellDbSet;
            int _modelPk = modelPk == null ? 0 : modelPk.Length;
            if (_modelPk > 0) {
                int _modelPkOprtr = modelPkOprtr == null ? 0 : modelPkOprtr.Length;
                for(int i = 0; i < _modelPk; i++) {
                    string op_modelPkOprtr = (i >= _modelPkOprtr) ? "eq" : (modelPkOprtr[i] == null) ? "eq" : modelPkOprtr[i];
                    var _tmpmodelPk = modelPk[i];
                    switch(op_modelPkOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.ModelPk == _tmpmodelPk));
                            break;
                        case "lk":
                            query = query.Where(p => (p.ModelPk == _tmpmodelPk));
                            break;
                        case "gt":
                            query = query.Where(p => (p.ModelPk >= _tmpmodelPk));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.ModelPk <= _tmpmodelPk));
                            break;
                        case "ne":
                            query = query.Where(p => (p.ModelPk != _tmpmodelPk));
                            break;
                    }
                }
            }
            int _modelName = modelName == null ? 0 : modelName.Length;
            if (_modelName > 0) {
                int _modelNameOprtr = modelNameOprtr == null ? 0 : modelNameOprtr.Length;
                for(int i = 0; i < _modelName; i++) {
                    string op_modelNameOprtr = (i >= _modelNameOprtr) ? "eq" : (modelNameOprtr[i] == null) ? "eq" : modelNameOprtr[i];
                    var _tmpmodelName = modelName[i];
                    switch(op_modelNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.ModelName.Contains(_tmpmodelName));
                            break;
                        case "lk":
                            query = query.Where(p => p.ModelName.Contains(_tmpmodelName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.ModelName.CompareTo(_tmpmodelName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.ModelName.CompareTo(_tmpmodelName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.ModelName.CompareTo(_tmpmodelName) != 0));
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
                IOrderedQueryable<aspnetmodel> orderedQuery = null;
                if(currentOrderBy != null) {
                    List<string> wasInUseOrderBy = new List<string>();
                    foreach(string propName in currentOrderBy) {
                        string lowerCaseStr = propName.ToLower();
                        if (wasInUseOrderBy.Contains(lowerCaseStr)) {
                            continue;
                        }
                        switch(lowerCaseStr) {
                            case "modelpk" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.ModelPk);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.ModelPk);
                                }
                                wasInUseOrderBy.Add("modelpk");
                                wasInUseOrderBy.Add("-modelpk");
                                break;
                            case "-modelpk" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.ModelPk);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.ModelPk);
                                }
                                wasInUseOrderBy.Add("modelpk");
                                wasInUseOrderBy.Add("-modelpk");
                                break;
                            case "modelname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.ModelName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.ModelName);
                                }
                                wasInUseOrderBy.Add("modelname");
                                wasInUseOrderBy.Add("-modelname");
                                break;
                            case "-modelname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.ModelName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.ModelName);
                                }
                                wasInUseOrderBy.Add("modelname");
                                wasInUseOrderBy.Add("-modelname");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.ModelPk);
                } // totals pageCount currentPageSize
                aspnetmodelViewPage resultObject = new aspnetmodelViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetmodelView() {
                            ModelPk = itm.ModelPk,
                            ModelName = itm.ModelName,
                            ModelDescription = itm.ModelDescription
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<aspnetmodelView>> getone(                
             [FromQuery] System.Int32 modelPk
                
             )
        {
            aspnetmodelView result = await db.aspnetmodellDbSet
                    .Where(p => p.ModelPk == modelPk)
                    .Select(itm => new aspnetmodelView() {
                            ModelPk = itm.ModelPk,
                            ModelName = itm.ModelName,
                            ModelDescription = itm.ModelDescription
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<aspnetmodelViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] modelPk,
             [FromQuery] string[] modelPkOprtr,
            
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

                
            int _modelPk = modelPk == null ? 0 : modelPk.Length;
            int _modelPkOprtr = modelPkOprtr == null ? 0 : modelPkOprtr.Length;
                
            IQueryable<aspnetmodel> query = db.aspnetmodellDbSet;
            var _outer = PredicateBuilder.New<aspnetmodel>(false);
            bool isOuterModified = false;
            if ( _modelPk > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _modelPk; i++) {
                    var _inner = PredicateBuilder.New<aspnetmodel>(true);
                    isLkOp = false;
                    if(i < _modelPkOprtr) {
                        isLkOp = modelPkOprtr[i] == "lk";
                    }
                
                    if (modelPk[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpmodelPk = modelPk[i];
                        
                    _inner = _inner.And(p => p.ModelPk == _tmpmodelPk);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            if(isOuterModified) {
                query = query.AsExpandable().Where(_outer); 
            }

            int totals = await query.CountAsync();
            int pageCount = ((totals > 0) ? ((int)Math.Ceiling((double)totals / (double)currentPageSize)) : 0);
            IOrderedQueryable<aspnetmodel> orderedQuery = null;
            {

                orderedQuery = query.OrderBy(p => p.ModelPk);
              
                query = orderedQuery;
            }  
            aspnetmodelViewPage resultObject = new aspnetmodelViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new aspnetmodelView() {
                            ModelPk = itm.ModelPk,
                            ModelName = itm.ModelName,
                            ModelDescription = itm.ModelDescription
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<aspnetmodelView>> updateone([FromBody] aspnetmodelView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            aspnetmodel resultEntity = await db.aspnetmodellDbSet
                    .Where(p => p.ModelPk == viewToUpdate.ModelPk)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.ModelName =  viewToUpdate.ModelName;
            resultEntity.ModelDescription =  viewToUpdate.ModelDescription;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            aspnetmodelView result = await db.aspnetmodellDbSet
                    .Where(p => p.ModelPk == viewToUpdate.ModelPk)
                    .Select(itm => new aspnetmodelView() {
                            ModelPk = itm.ModelPk,
                            ModelName = itm.ModelName,
                            ModelDescription = itm.ModelDescription
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<aspnetmodelView>> addone([FromBody] aspnetmodelView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            aspnetmodel entityToAdd = new aspnetmodel();
            entityToAdd.ModelPk =  viewToAdd.ModelPk;
            entityToAdd.ModelName =  viewToAdd.ModelName;
            entityToAdd.ModelDescription =  viewToAdd.ModelDescription;
            db.aspnetmodellDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            aspnetmodelView result = await db.aspnetmodellDbSet
                    .Where(p => p.ModelPk == entityToAdd.ModelPk)
                    .Select(itm => new aspnetmodelView() {
                            ModelPk = itm.ModelPk,
                            ModelName = itm.ModelName,
                            ModelDescription = itm.ModelDescription
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<aspnetmodelView>> deleteone(                
             [FromQuery] System.Int32 modelPk
                
           )
        {

                aspnetmodelView result = await db.aspnetmodellDbSet
                    .Where(p => p.ModelPk == modelPk)
                    .Select(itm => new aspnetmodelView() {
                            ModelPk = itm.ModelPk,
                            ModelName = itm.ModelName,
                            ModelDescription = itm.ModelDescription
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                aspnetmodel entityToDelete = await db.aspnetmodellDbSet
                    .Where(p => p.ModelPk == result.ModelPk)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.aspnetmodellDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();
                return Ok(result);
        }

    }
}

