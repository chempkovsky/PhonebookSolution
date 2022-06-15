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

//    [RoutePrefix("phbkemployeeviewwebapi")]
    [ApiController]
    public class PhbkEmployeeViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly PhbkDbContext db;
        private readonly IPublishEndpoint pe;

        public PhbkEmployeeViewWebApiController(PhbkDbContext context, IPublishEndpoint publishEndpoint)
        {
            db = context;
            pe = publishEndpoint;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<PhbkEmployeeView>>> getall()
        {
            return await db.PhbkEmployeeDbSet
                    .Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<PhbkEmployeeViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] employeeId, 
            [FromQuery] string[] employeeIdOprtr,
                
            [FromQuery] System.String[] empFirstName, 
            [FromQuery] string[] empFirstNameOprtr,
                
            [FromQuery] System.String[] empLastName, 
            [FromQuery] string[] empLastNameOprtr,
                
            [FromQuery] System.Int32?[] divisionIdRef, 
            [FromQuery] string[] divisionIdRefOprtr,
                 
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
            IQueryable<PhbkEmployee> query = db.PhbkEmployeeDbSet;
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
            int _empFirstName = empFirstName == null ? 0 : empFirstName.Length;
            if (_empFirstName > 0) {
                int _empFirstNameOprtr = empFirstNameOprtr == null ? 0 : empFirstNameOprtr.Length;
                for(int i = 0; i < _empFirstName; i++) {
                    string op_empFirstNameOprtr = (i >= _empFirstNameOprtr) ? "eq" : (empFirstNameOprtr[i] == null) ? "eq" : empFirstNameOprtr[i];
                    var _tmpempFirstName = empFirstName[i];
                    switch(op_empFirstNameOprtr) {
                        case "eq": 
                            query = query.Where(p => p.EmpFirstName.Contains(_tmpempFirstName));
                            break;
                        case "lk":
                            query = query.Where(p => p.EmpFirstName.Contains(_tmpempFirstName));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmpFirstName.CompareTo(_tmpempFirstName) >= 0));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmpFirstName.CompareTo(_tmpempFirstName) <= 0));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmpFirstName.CompareTo(_tmpempFirstName) != 0));
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
            int _divisionIdRef = divisionIdRef == null ? 0 : divisionIdRef.Length;
            if (_divisionIdRef > 0) {
                int _divisionIdRefOprtr = divisionIdRefOprtr == null ? 0 : divisionIdRefOprtr.Length;
                for(int i = 0; i < _divisionIdRef; i++) {
                    string op_divisionIdRefOprtr = (i >= _divisionIdRefOprtr) ? "eq" : (divisionIdRefOprtr[i] == null) ? "eq" : divisionIdRefOprtr[i];
                    var _tmpdivisionIdRef = divisionIdRef[i];
                    switch(op_divisionIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.DivisionIdRef == _tmpdivisionIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.DivisionIdRef == _tmpdivisionIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.DivisionIdRef >= _tmpdivisionIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.DivisionIdRef <= _tmpdivisionIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.DivisionIdRef != _tmpdivisionIdRef));
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
                IOrderedQueryable<PhbkEmployee> orderedQuery = null;
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
                            case "empfirstname" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmpFirstName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmpFirstName);
                                }
                                wasInUseOrderBy.Add("empfirstname");
                                wasInUseOrderBy.Add("-empfirstname");
                                break;
                            case "-empfirstname" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmpFirstName);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmpFirstName);
                                }
                                wasInUseOrderBy.Add("empfirstname");
                                wasInUseOrderBy.Add("-empfirstname");
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
                            case "divisionidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.DivisionIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.DivisionIdRef);
                                }
                                wasInUseOrderBy.Add("divisionidref");
                                wasInUseOrderBy.Add("-divisionidref");
                                break;
                            case "-divisionidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.DivisionIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.DivisionIdRef);
                                }
                                wasInUseOrderBy.Add("divisionidref");
                                wasInUseOrderBy.Add("-divisionidref");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.EmployeeId);
                } // totals pageCount currentPageSize
                PhbkEmployeeViewPage resultObject = new PhbkEmployeeViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<PhbkEmployeeView>> getone(                
             [FromQuery] System.Int32 employeeId
                
             )
        {
            PhbkEmployeeView result = await db.PhbkEmployeeDbSet
                    .Where(p => p.EmployeeId == employeeId)
                    .Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<PhbkEmployeeViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] employeeId,
             [FromQuery] string[] employeeIdOprtr,
                
             [FromQuery] System.Int32?[] divisionIdRef,
             [FromQuery] string[] divisionIdRefOprtr,
            
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

                
            int _employeeId = employeeId == null ? 0 : employeeId.Length;
            int _employeeIdOprtr = employeeIdOprtr == null ? 0 : employeeIdOprtr.Length;
                
            IQueryable<PhbkEmployee> query = db.PhbkEmployeeDbSet;
            var _outer = PredicateBuilder.New<PhbkEmployee>(false);
            bool isOuterModified = false;
            if ( _employeeId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _employeeId; i++) {
                    var _inner = PredicateBuilder.New<PhbkEmployee>(true);
                    isLkOp = false;
                    if(i < _employeeIdOprtr) {
                        isLkOp = employeeIdOprtr[i] == "lk";
                    }
                
                    if (employeeId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpemployeeId = employeeId[i];
                        
                    _inner = _inner.And(p => p.EmployeeId == _tmpemployeeId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            bool isForeignAdded = false;
            var _outerAnd = PredicateBuilder.New<PhbkEmployee>(true);
                
             if(divisionIdRef != null) {
                if(divisionIdRef.Length > 0) {
                    for(int i = 0; i < divisionIdRef.Length; i++) {
                
                        if (divisionIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpdivisionIdRef = divisionIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.DivisionIdRef == _tmpdivisionIdRef);
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
            IOrderedQueryable<PhbkEmployee> orderedQuery = null;
            if(!isForeignAdded)
            {

                orderedQuery = query.OrderBy(p => p.EmployeeId);
              
                query = orderedQuery;
            }  
            PhbkEmployeeViewPage resultObject = new PhbkEmployeeViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<PhbkEmployeeView>> updateone([FromBody] PhbkEmployeeView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PhbkEmployeeView oldObjVer = await db.PhbkEmployeeDbSet
                    .Where(p => p.EmployeeId == viewToUpdate.EmployeeId)
                    .Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();

            PhbkEmployee resultEntity = await db.PhbkEmployeeDbSet
                    .Where(p => p.EmployeeId == viewToUpdate.EmployeeId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.EmpFirstName =  viewToUpdate.EmpFirstName;
            resultEntity.EmpLastName =  viewToUpdate.EmpLastName;
            resultEntity.EmpSecondName =  viewToUpdate.EmpSecondName;
            resultEntity.DivisionIdRef =  viewToUpdate.DivisionIdRef;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            PhbkEmployeeView result = await db.PhbkEmployeeDbSet
                    .Where(p => p.EmployeeId == viewToUpdate.EmployeeId)
                    .Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }

            IPhbkEmployeeViewExtForLkUp newcln = LpPhBkViews.PhBk.PhbkEmployeeViewCloneForLkUp.DoClone(result);
            IPhbkEmployeeViewExtForLkUp oldcln = LpPhBkViews.PhBk.PhbkEmployeeViewCloneForLkUp.DoClone(oldObjVer);
            
            // 
            // Please define additional props of the IPhbkEmployeeViewExtForLkUp newcln object before  UpdateForXXX-method calls 
            //
            
            await pe.Publish<IPhbkEmployeeViewExtForLkUpMsg>(new
            {
                action = 2,
                OldVals = oldcln,
                NewVals = newcln
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<PhbkEmployeeView>> addone([FromBody] PhbkEmployeeView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PhbkEmployee entityToAdd = new PhbkEmployee();
            entityToAdd.EmployeeId =  viewToAdd.EmployeeId;
            entityToAdd.EmpFirstName =  viewToAdd.EmpFirstName;
            entityToAdd.EmpLastName =  viewToAdd.EmpLastName;
            entityToAdd.EmpSecondName =  viewToAdd.EmpSecondName;
            entityToAdd.DivisionIdRef =  viewToAdd.DivisionIdRef;
            db.PhbkEmployeeDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            PhbkEmployeeView result = await db.PhbkEmployeeDbSet
                    .Where(p => p.EmployeeId == entityToAdd.EmployeeId)
                    .Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }


            IPhbkEmployeeViewExtForLkUp newcln = LpPhBkViews.PhBk.PhbkEmployeeViewCloneForLkUp.DoClone(result);
            // 
            // Please define additional props of the IPhbkEmployeeViewExtForLkUp newcln object before  UpdateForXXX-method calls 
            //
            await pe.Publish<IPhbkEmployeeViewExtForLkUpMsg>(new
            {
                action = 1,
                // OldVals = null,
                NewVals = newcln
            });

            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<PhbkEmployeeView>> deleteone(                
             [FromQuery] System.Int32 employeeId
                
           )
        {

                PhbkEmployeeView result = await db.PhbkEmployeeDbSet
                    .Where(p => p.EmployeeId == employeeId)
                    .Select(itm => new PhbkEmployeeView() {
                            EmployeeId = itm.EmployeeId,
                            EmpFirstName = itm.EmpFirstName,
                            EmpLastName = itm.EmpLastName,
                            EmpSecondName = itm.EmpSecondName,
                            DivisionIdRef = itm.DivisionIdRef,
                            DDivisionName = itm.Division.DivisionName,
                            DEEntrprsName = itm.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                PhbkEmployee entityToDelete = await db.PhbkEmployeeDbSet
                    .Where(p => p.EmployeeId == result.EmployeeId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.PhbkEmployeeDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();


            IPhbkEmployeeViewExtForLkUp oldcln = LpPhBkViews.PhBk.PhbkEmployeeViewCloneForLkUp.DoClone(result);
            // 
            // Please define additional props of the IPhbkEmployeeViewExtForLkUp oldcln object before  UpdateForXXX-method calls 
            //

            await pe.Publish<IPhbkEmployeeViewExtForLkUpMsg>(new
            {
                action = 3,
                OldVals = oldcln
                // NewVals = null
            });
            return Ok(result);
        }

    }
}

