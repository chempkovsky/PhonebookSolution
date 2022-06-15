#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LinqKit;
using MassTransit;

/*
according to https://masstransit-project.com/usage/configuration.html#configuration
make sure Program.cs file contains the following code:

#region MassTransit config
using MassTransit;
#endregion
...
var builder = WebApplication.CreateBuilder(args);
...


#region MassTransit config
builder.Services.AddMassTransit(x => {
    x.UsingRabbitMq((context, configurator) => {
        configurator.Host("192.168.100.4", "RabbitMq_virtual_host_name", h =>
        {
            h.Username("RabbitMq_admin_name");
            h.Password("RabbitMq_admin_password");
            // 
            // Cluster settings
            //
            // h.UseCluster((configureCluster) =>
            // {
            //   configureCluster.Node("192.168.100.5");
            //   configureCluster.Node("192.168.100.6");
            //   ...
            //   configureCluster.Node("192.168.100.10");
            // });
            // h.PublisherConfirmation = true;
            //h.ConfigureBatchPublish(configure =>
            //{
            //});
        });
        // 
        // Quorum Queue settings
        //
        // configurator.SetQuorumQueue(3);
        //
    });
});
builder.Services.AddOptions<MassTransitHostOptions>()
                .Configure(options =>
                {
                    // if specified, waits until the bus is started before
                    // returning from IHostedService.StartAsync
                    // default is false
                    options.WaitUntilStarted = true;

                    // if specified, limits the wait time when starting the bus
                    options.StartTimeout = TimeSpan.FromSeconds(10);

                    // if specified, limits the wait time when stopping the bus
                    options.StopTimeout = TimeSpan.FromSeconds(30);

                });
#endregion
*/



using PhBkContext.PhBk;
using PhBkViews.PhBk;
using PhBkEntity.PhBk;
using LpPhBkViews.PhBk;


namespace PhBkControllers.Controllers {

//    [RoutePrefix("phbkdivisionviewwebapi")]
    [ApiController]
    public class PhbkDivisionViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly PhbkDbContext db;
        private readonly IPublishEndpoint pe;

        public PhbkDivisionViewWebApiController(PhbkDbContext context, IPublishEndpoint publishEndpoint)
        {
            db = context;
            pe = publishEndpoint;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<PhbkDivisionView>>> getall()
        {
            return await db.PhbkDivisionDbSet
                    .Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<PhbkDivisionViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] divisionId, 
            [FromQuery] string[] divisionIdOprtr,
                
            [FromQuery] System.String[] divisionName, 
            [FromQuery] string[] divisionNameOprtr,
                
            [FromQuery] System.Int32?[] entrprsIdRef, 
            [FromQuery] string[] entrprsIdRefOprtr,
                 
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
            IQueryable<PhbkDivision> query = db.PhbkDivisionDbSet;
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
            int _divisionName = divisionName == null ? 0 : divisionName.Length;
            if (_divisionName > 0) {
                int _divisionNameOprtr = divisionNameOprtr == null ? 0 : divisionNameOprtr.Length;
                for(int i = 0; i < _divisionName; i++) {
                    string op_divisionNameOprtr = (i >= _divisionNameOprtr) ? "eq" : (divisionNameOprtr[i] == null) ? "eq" : divisionNameOprtr[i];
                    var _tmpdivisionName = divisionName[i];
                    switch(op_divisionNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.DivisionName.Contains(_tmpdivisionName));
                            break;
                        case "lk":
                            query = query.Where(p => p.DivisionName.Contains(_tmpdivisionName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.DivisionName.CompareTo(_tmpdivisionName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.DivisionName.CompareTo(_tmpdivisionName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.DivisionName.CompareTo(_tmpdivisionName) != 0));
                            break;
                    }
                }
            }
            int _entrprsIdRef = entrprsIdRef == null ? 0 : entrprsIdRef.Length;
            if (_entrprsIdRef > 0) {
                int _entrprsIdRefOprtr = entrprsIdRefOprtr == null ? 0 : entrprsIdRefOprtr.Length;
                for(int i = 0; i < _entrprsIdRef; i++) {
                    string op_entrprsIdRefOprtr = (i >= _entrprsIdRefOprtr) ? "eq" : (entrprsIdRefOprtr[i] == null) ? "eq" : entrprsIdRefOprtr[i];
                    var _tmpentrprsIdRef = entrprsIdRef[i];
                    switch(op_entrprsIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EntrprsIdRef == _tmpentrprsIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EntrprsIdRef == _tmpentrprsIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EntrprsIdRef >= _tmpentrprsIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EntrprsIdRef <= _tmpentrprsIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EntrprsIdRef != _tmpentrprsIdRef));
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
                IOrderedQueryable<PhbkDivision> orderedQuery = null;
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
                            case "divisionname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.DivisionName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.DivisionName);
                                }
                                wasInUseOrderBy.Add("divisionname");
                                wasInUseOrderBy.Add("-divisionname");
                                break;
                            case "-divisionname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.DivisionName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.DivisionName);
                                }
                                wasInUseOrderBy.Add("divisionname");
                                wasInUseOrderBy.Add("-divisionname");
                                break;
                            case "entrprsidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EntrprsIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EntrprsIdRef);
                                }
                                wasInUseOrderBy.Add("entrprsidref");
                                wasInUseOrderBy.Add("-entrprsidref");
                                break;
                            case "-entrprsidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EntrprsIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EntrprsIdRef);
                                }
                                wasInUseOrderBy.Add("entrprsidref");
                                wasInUseOrderBy.Add("-entrprsidref");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.DivisionId);
                } // totals pageCount currentPageSize
                PhbkDivisionViewPage resultObject = new PhbkDivisionViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<PhbkDivisionView>> getone(                
             [FromQuery] System.Int32 divisionId
                
             )
        {
            PhbkDivisionView result = await db.PhbkDivisionDbSet
                    .Where(p => p.DivisionId == divisionId)
                    .Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<PhbkDivisionViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] divisionId,
             [FromQuery] string[] divisionIdOprtr,
                
             [FromQuery] System.Int32?[] entrprsIdRef,
             [FromQuery] string[] entrprsIdRefOprtr,
            
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

                
            int _divisionId = divisionId == null ? 0 : divisionId.Length;
            int _divisionIdOprtr = divisionIdOprtr == null ? 0 : divisionIdOprtr.Length;
                
            IQueryable<PhbkDivision> query = db.PhbkDivisionDbSet;
            var _outer = PredicateBuilder.New<PhbkDivision>(false);
            bool isOuterModified = false;
            if ( _divisionId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _divisionId; i++) {
                    var _inner = PredicateBuilder.New<PhbkDivision>(true);
                    isLkOp = false;
                    if(i < _divisionIdOprtr) {
                        isLkOp = divisionIdOprtr[i] == "lk";
                    }
                
                    if (divisionId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpdivisionId = divisionId[i];
                        
                    _inner = _inner.And(p => p.DivisionId == _tmpdivisionId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            bool isForeignAdded = false;
            var _outerAnd = PredicateBuilder.New<PhbkDivision>(true);
                
             if(entrprsIdRef != null) {
                if(entrprsIdRef.Length > 0) {
                    for(int i = 0; i < entrprsIdRef.Length; i++) {
                
                        if (entrprsIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpentrprsIdRef = entrprsIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.EntrprsIdRef == _tmpentrprsIdRef);
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
            IOrderedQueryable<PhbkDivision> orderedQuery = null;
            if(!isForeignAdded)
            {

                orderedQuery = query.OrderBy(p => p.DivisionId);
              
                query = orderedQuery;
            }  
            PhbkDivisionViewPage resultObject = new PhbkDivisionViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<PhbkDivisionView>> updateone([FromBody] PhbkDivisionView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PhbkDivisionView oldObjVer = await db.PhbkDivisionDbSet
                    .Where(p => p.DivisionId == viewToUpdate.DivisionId)
                    .Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();

            PhbkDivision resultEntity = await db.PhbkDivisionDbSet
                    .Where(p => p.DivisionId == viewToUpdate.DivisionId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.DivisionName =  viewToUpdate.DivisionName;
            resultEntity.DivisionDesc =  viewToUpdate.DivisionDesc;
            resultEntity.EntrprsIdRef =  viewToUpdate.EntrprsIdRef;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            PhbkDivisionView result = await db.PhbkDivisionDbSet
                    .Where(p => p.DivisionId == viewToUpdate.DivisionId)
                    .Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }

            IPhbkDivisionViewExtForLkUp newcln = LpPhBkViews.PhBk.PhbkDivisionViewCloneForLkUp.DoClone(result);
            IPhbkDivisionViewExtForLkUp oldcln = LpPhBkViews.PhBk.PhbkDivisionViewCloneForLkUp.DoClone(oldObjVer);
            
            // 
            // Please define additional props of the IPhbkDivisionViewExtForLkUp newcln object before  UpdateForXXX-method calls 
            //
            
            await pe.Publish<IPhbkDivisionViewExtForLkUpMsg>(new
            {
                action = 2,
                OldVals = oldcln,
                NewVals = newcln
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<PhbkDivisionView>> addone([FromBody] PhbkDivisionView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PhbkDivision entityToAdd = new PhbkDivision();
            entityToAdd.DivisionId =  viewToAdd.DivisionId;
            entityToAdd.DivisionName =  viewToAdd.DivisionName;
            entityToAdd.DivisionDesc =  viewToAdd.DivisionDesc;
            entityToAdd.EntrprsIdRef =  viewToAdd.EntrprsIdRef;
            db.PhbkDivisionDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            PhbkDivisionView result = await db.PhbkDivisionDbSet
                    .Where(p => p.DivisionId == entityToAdd.DivisionId)
                    .Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }


            IPhbkDivisionViewExtForLkUp newcln = LpPhBkViews.PhBk.PhbkDivisionViewCloneForLkUp.DoClone(result);
            // 
            // Please define additional props of the IPhbkDivisionViewExtForLkUp newcln object before  UpdateForXXX-method calls 
            //
            await pe.Publish<IPhbkDivisionViewExtForLkUpMsg>(new
            {
                action = 1,
                // OldVals = null,
                NewVals = newcln
            });

            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<PhbkDivisionView>> deleteone(                
             [FromQuery] System.Int32 divisionId
                
           )
        {

                PhbkDivisionView result = await db.PhbkDivisionDbSet
                    .Where(p => p.DivisionId == divisionId)
                    .Select(itm => new PhbkDivisionView() {
                            DivisionId = itm.DivisionId,
                            DivisionName = itm.DivisionName,
                            DivisionDesc = itm.DivisionDesc,
                            EntrprsIdRef = itm.EntrprsIdRef,
                            EEntrprsName = itm.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                PhbkDivision entityToDelete = await db.PhbkDivisionDbSet
                    .Where(p => p.DivisionId == result.DivisionId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.PhbkDivisionDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();


            IPhbkDivisionViewExtForLkUp oldcln = LpPhBkViews.PhBk.PhbkDivisionViewCloneForLkUp.DoClone(result);
            // 
            // Please define additional props of the IPhbkDivisionViewExtForLkUp oldcln object before  UpdateForXXX-method calls 
            //

            await pe.Publish<IPhbkDivisionViewExtForLkUpMsg>(new
            {
                action = 3,
                OldVals = oldcln
                // NewVals = null
            });
            return Ok(result);
        }

    }
}

