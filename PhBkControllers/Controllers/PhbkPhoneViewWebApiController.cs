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

//    [RoutePrefix("phbkphoneviewwebapi")]
    [ApiController]
    public class PhbkPhoneViewWebApiController: ControllerBase
    {
        private int defaultPageSize = 50;
        private int minPageSize = 5;
        private int maxPageSize = 150;
        private readonly PhbkDbContext db;
        private readonly IPublishEndpoint pe;

        public PhbkPhoneViewWebApiController(PhbkDbContext context, IPublishEndpoint publishEndpoint)
        {
            db = context;
            pe = publishEndpoint;
        }

        [HttpGet]
        [Route("[controller]/getall")]
        
        public async Task<ActionResult<IEnumerable<PhbkPhoneView>>> getall()
        {
            return await db.PhbkPhoneDbSet
                    .Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName

                            }).ToListAsync();;

        } // the end of Get()-method


        [HttpGet]
        [Route("[controller]/getwithfilter")]
        public async Task<ActionResult<PhbkPhoneViewPage>> getwithfilter(                
            [FromQuery] System.Int32?[] phoneId, 
            [FromQuery] string[] phoneIdOprtr,
                
            [FromQuery] System.String[] phone, 
            [FromQuery] string[] phoneOprtr,
                
            [FromQuery] System.Int32?[] phoneTypeIdRef, 
            [FromQuery] string[] phoneTypeIdRefOprtr,
                
            [FromQuery] System.Int32?[] employeeIdRef, 
            [FromQuery] string[] employeeIdRefOprtr,
                 
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
            IQueryable<PhbkPhone> query = db.PhbkPhoneDbSet;
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
            int _phoneTypeIdRef = phoneTypeIdRef == null ? 0 : phoneTypeIdRef.Length;
            if (_phoneTypeIdRef > 0) {
                int _phoneTypeIdRefOprtr = phoneTypeIdRefOprtr == null ? 0 : phoneTypeIdRefOprtr.Length;
                for(int i = 0; i < _phoneTypeIdRef; i++) {
                    string op_phoneTypeIdRefOprtr = (i >= _phoneTypeIdRefOprtr) ? "eq" : (phoneTypeIdRefOprtr[i] == null) ? "eq" : phoneTypeIdRefOprtr[i];
                    var _tmpphoneTypeIdRef = phoneTypeIdRef[i];
                    switch(op_phoneTypeIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.PhoneTypeIdRef == _tmpphoneTypeIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.PhoneTypeIdRef == _tmpphoneTypeIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.PhoneTypeIdRef >= _tmpphoneTypeIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.PhoneTypeIdRef <= _tmpphoneTypeIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.PhoneTypeIdRef != _tmpphoneTypeIdRef));
                            break;
                    }
                }
            }
            int _employeeIdRef = employeeIdRef == null ? 0 : employeeIdRef.Length;
            if (_employeeIdRef > 0) {
                int _employeeIdRefOprtr = employeeIdRefOprtr == null ? 0 : employeeIdRefOprtr.Length;
                for(int i = 0; i < _employeeIdRef; i++) {
                    string op_employeeIdRefOprtr = (i >= _employeeIdRefOprtr) ? "eq" : (employeeIdRefOprtr[i] == null) ? "eq" : employeeIdRefOprtr[i];
                    var _tmpemployeeIdRef = employeeIdRef[i];
                    switch(op_employeeIdRefOprtr) {
                        case "eq": 
                            query = query.Where(p => (p.EmployeeIdRef == _tmpemployeeIdRef));
                            break;
                        case "lk":
                            query = query.Where(p => (p.EmployeeIdRef == _tmpemployeeIdRef));
                            break;
                        case "gt":
                            query = query.Where(p => (p.EmployeeIdRef >= _tmpemployeeIdRef));
                            break;
                        case "lt": 
                            query = query.Where(p => (p.EmployeeIdRef <= _tmpemployeeIdRef));
                            break;
                        case "ne":
                            query = query.Where(p => (p.EmployeeIdRef != _tmpemployeeIdRef));
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
                IOrderedQueryable<PhbkPhone> orderedQuery = null;
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
                            case "phonetypeidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.PhoneTypeIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.PhoneTypeIdRef);
                                }
                                wasInUseOrderBy.Add("phonetypeidref");
                                wasInUseOrderBy.Add("-phonetypeidref");
                                break;
                            case "-phonetypeidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.PhoneTypeIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.PhoneTypeIdRef);
                                }
                                wasInUseOrderBy.Add("phonetypeidref");
                                wasInUseOrderBy.Add("-phonetypeidref");
                                break;
                            case "employeeidref" :
                                if(isFirstTime) { 
                                    orderedQuery = query.OrderBy(p => p.EmployeeIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenBy(p => p.EmployeeIdRef);
                                }
                                wasInUseOrderBy.Add("employeeidref");
                                wasInUseOrderBy.Add("-employeeidref");
                                break;
                            case "-employeeidref" :
                                if(isFirstTime) {
                                    orderedQuery = query.OrderByDescending(p => p.EmployeeIdRef);
                                    isFirstTime = false;
                                } else {
                                    orderedQuery = orderedQuery.ThenByDescending(p => p.EmployeeIdRef);
                                }
                                wasInUseOrderBy.Add("employeeidref");
                                wasInUseOrderBy.Add("-employeeidref");
                                break;
                                default:
                                    break;
                        }
                    }
                }
                if(isFirstTime) {                
                    orderedQuery = query.OrderBy(p => p.PhoneId);
                } // totals pageCount currentPageSize
                PhbkPhoneViewPage resultObject = new PhbkPhoneViewPage() {
                    page = (currentPage > 0) ? (currentPage-1) : currentPage,
                    pagesize = currentPageSize,
                    pagecount = pageCount,
                    total = totals
                };
                resultObject.items = await orderedQuery.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName
                            }).ToListAsync();
                return Ok(resultObject);
        } // the end of GetWithFilter()-method

        [HttpGet]
        [Route("[controller]/getone")]
        public async Task<ActionResult<PhbkPhoneView>> getone(                
             [FromQuery] System.Int32 phoneId
                
             )
        {
            PhbkPhoneView result = await db.PhbkPhoneDbSet
                    .Where(p => p.PhoneId == phoneId)
                    .Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }
            return Ok(result);
        } // the end of public GetOne()-method


        [HttpGet]
        [Route("[controller]/getmanybyrepprim")]
        public async Task<ActionResult<PhbkPhoneViewPage>> getmanybyrepprim(
                
             [FromQuery] System.Int32?[] phoneId,
             [FromQuery] string[] phoneIdOprtr,
                
             [FromQuery] System.Int32?[] phoneTypeIdRef,
             [FromQuery] string[] phoneTypeIdRefOprtr,
                
             [FromQuery] System.Int32?[] employeeIdRef,
             [FromQuery] string[] employeeIdRefOprtr,
            
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

                
            int _phoneId = phoneId == null ? 0 : phoneId.Length;
            int _phoneIdOprtr = phoneIdOprtr == null ? 0 : phoneIdOprtr.Length;
                
            IQueryable<PhbkPhone> query = db.PhbkPhoneDbSet;
            var _outer = PredicateBuilder.New<PhbkPhone>(false);
            bool isOuterModified = false;
            if ( _phoneId > 0 ) {
                bool isLkOp = false;
                for(int i = 0; i < _phoneId; i++) {
                    var _inner = PredicateBuilder.New<PhbkPhone>(true);
                    isLkOp = false;
                    if(i < _phoneIdOprtr) {
                        isLkOp = phoneIdOprtr[i] == "lk";
                    }
                
                    if (phoneId[i] == null) // continue; (required prop == null) returns false
                    {
                        continue;
                    }
                    var _tmpphoneId = phoneId[i];
                        
                    _inner = _inner.And(p => p.PhoneId == _tmpphoneId);
                
                    _outer = _outer.Or(_inner);
                    isOuterModified = true;
                }
            }
            bool isForeignAdded = false;
            var _outerAnd = PredicateBuilder.New<PhbkPhone>(true);
                
             if(phoneTypeIdRef != null) {
                if(phoneTypeIdRef.Length > 0) {
                    for(int i = 0; i < phoneTypeIdRef.Length; i++) {
                
                        if (phoneTypeIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpphoneTypeIdRef = phoneTypeIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.PhoneTypeIdRef == _tmpphoneTypeIdRef);
                        isForeignAdded = true;
                    }
                }
             }
                
             if(employeeIdRef != null) {
                if(employeeIdRef.Length > 0) {
                    for(int i = 0; i < employeeIdRef.Length; i++) {
                
                        if (employeeIdRef[i] == null) continue; // (required prop == null) returns false
                        var _tmpemployeeIdRef = employeeIdRef[i];
                        _outerAnd = _outerAnd.And(p => p.EmployeeIdRef == _tmpemployeeIdRef);
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
            IOrderedQueryable<PhbkPhone> orderedQuery = null;
            if(!isForeignAdded)
            {

                orderedQuery = query.OrderBy(p => p.PhoneId);
              
                query = orderedQuery;
            }  
            PhbkPhoneViewPage resultObject = new PhbkPhoneViewPage() {
                page = (currentPage > 0) ? (currentPage-1) : currentPage,
                pagesize = currentPageSize,
                pagecount = pageCount,
                total = totals
            };
            resultObject.items = await query.Skip((currentPage - 1) * currentPageSize).Take(currentPageSize).Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName
                            }).ToListAsync();
            return Ok(resultObject);
        }

        [HttpPut]
        [Route("[controller]/updateone")]
        public async Task<ActionResult<PhbkPhoneView>> updateone([FromBody] PhbkPhoneView viewToUpdate)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            PhbkPhoneView oldObjVer = await db.PhbkPhoneDbSet
                    .Where(p => p.PhoneId == viewToUpdate.PhoneId)
                    .Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();

            PhbkPhone resultEntity = await db.PhbkPhoneDbSet
                    .Where(p => p.PhoneId == viewToUpdate.PhoneId)
                    .FirstOrDefaultAsync();
            if(resultEntity == null) {
                return NotFound();
            }

            resultEntity.Phone =  viewToUpdate.Phone;
            resultEntity.PhoneTypeIdRef =  viewToUpdate.PhoneTypeIdRef;
            resultEntity.EmployeeIdRef =  viewToUpdate.EmployeeIdRef;
            db.Entry(resultEntity).State = EntityState.Modified;
            await db.SaveChangesAsync();
            PhbkPhoneView result = await db.PhbkPhoneDbSet
                    .Where(p => p.PhoneId == viewToUpdate.PhoneId)
                    .Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }

            IPhbkPhoneViewExtForLkUp newcln = LpPhBkViews.PhBk.PhbkPhoneViewCloneForLkUp.DoClone(result);
            IPhbkPhoneViewExtForLkUp oldcln = LpPhBkViews.PhBk.PhbkPhoneViewCloneForLkUp.DoClone(oldObjVer);
            
            // 
            // Please define additional props of the IPhbkPhoneViewExtForLkUp newcln object before  UpdateForXXX-method calls 
            //
            
            await pe.Publish<IPhbkPhoneViewExtForLkUpMsg>(new
            {
                action = 2,
                OldVals = oldcln,
                NewVals = newcln
            });

            return Ok(result);
        }

        [HttpPost]
        [Route("[controller]/addone")]
        public async Task<ActionResult<PhbkPhoneView>> addone([FromBody] PhbkPhoneView viewToAdd)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            PhbkPhone entityToAdd = new PhbkPhone();
            entityToAdd.PhoneId =  viewToAdd.PhoneId;
            entityToAdd.Phone =  viewToAdd.Phone;
            entityToAdd.PhoneTypeIdRef =  viewToAdd.PhoneTypeIdRef;
            entityToAdd.EmployeeIdRef =  viewToAdd.EmployeeIdRef;
            db.PhbkPhoneDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();

            PhbkPhoneView result = await db.PhbkPhoneDbSet
                    .Where(p => p.PhoneId == entityToAdd.PhoneId)
                    .Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
            if (result == null)
            {
                return NotFound();
            }


            IPhbkPhoneViewExtForLkUp newcln = LpPhBkViews.PhBk.PhbkPhoneViewCloneForLkUp.DoClone(result);
            // 
            // Please define additional props of the IPhbkPhoneViewExtForLkUp newcln object before  UpdateForXXX-method calls 
            //
            await pe.Publish<IPhbkPhoneViewExtForLkUpMsg>(new
            {
                action = 1,
                // OldVals = null,
                NewVals = newcln
            });

            return Ok(result);
        }


        [HttpDelete]
        [Route("[controller]/deleteone")]
        public async Task<ActionResult<PhbkPhoneView>> deleteone(                
             [FromQuery] System.Int32 phoneId
                
           )
        {

                PhbkPhoneView result = await db.PhbkPhoneDbSet
                    .Where(p => p.PhoneId == phoneId)
                    .Select(itm => new PhbkPhoneView() {
                            PhoneId = itm.PhoneId,
                            Phone = itm.Phone,
                            PhoneTypeIdRef = itm.PhoneTypeIdRef,
                            EmployeeIdRef = itm.EmployeeIdRef,
                            PPhoneTypeName = itm.PhoneType.PhoneTypeName,
                            EEmpFirstName = itm.Employee.EmpFirstName,
                            EEmpLastName = itm.Employee.EmpLastName,
                            EEmpSecondName = itm.Employee.EmpSecondName,
                            EDDivisionName = itm.Employee.Division.DivisionName,
                            EDEEntrprsName = itm.Employee.Division.Enterprise.EntrprsName
                    }).FirstOrDefaultAsync();
                if (result == null)
                {
                    return NotFound();
                }

                PhbkPhone entityToDelete = await db.PhbkPhoneDbSet
                    .Where(p => p.PhoneId == result.PhoneId)
                    .FirstOrDefaultAsync();
                if (entityToDelete == null) {
                    return Ok(result);
                }
                db.PhbkPhoneDbSet.Remove(entityToDelete);
                await db.SaveChangesAsync();


            IPhbkPhoneViewExtForLkUp oldcln = LpPhBkViews.PhBk.PhbkPhoneViewCloneForLkUp.DoClone(result);
            // 
            // Please define additional props of the IPhbkPhoneViewExtForLkUp oldcln object before  UpdateForXXX-method calls 
            //

            await pe.Publish<IPhbkPhoneViewExtForLkUpMsg>(new
            {
                action = 3,
                OldVals = oldcln
                // NewVals = null
            });
            return Ok(result);
        }

    }
}

