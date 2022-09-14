using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

using ModelInterfacesClassLibrary.Phonebook.LprEmployee01;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.Classes;

/*
    In the file of IModule-class of the project for the current service the following lines of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            containerRegistry.Register<ILprEmployee01ViewService, LprEmployee01ViewService>();
            ...
        }

*/
namespace ModelServicesPrismModule.Phonebook.LprEmployee01 {
    public class LprEmployee01ViewService: ILprEmployee01ViewService
    {
        public Dictionary<(string viewNm, string navNm, string propNm), object> Dict2Tuple(Dictionary<string, object> src) {
            Dictionary<(string viewNm, string navNm, string propNm), object> dest = new Dictionary<(string viewNm, string navNm, string propNm), object>();
            if(src == null) return dest;
            var keys = src.Keys.ToList();
            foreach(var key in keys) {
                string[] vnp = key.Split(new char[] { '.' });
                dest[(vnp[0],vnp[1],vnp[2])] = src[key];
            }
            return dest;
        }
        public Dictionary<string, object> Tuple2Dict(Dictionary<(string viewNm, string navNm, string propNm), object> src) {
            Dictionary<string, object> dest = new Dictionary<string, object>();
            if(src == null) return dest;
            var keys = src.Keys.ToList();
            foreach(var key in keys) {
                dest[key.viewNm + "." + key.navNm + "." + key.propNm] = src[key];
            }
            return dest;
        }


        protected IAppGlblSettingsService appGlblSettings = null;
        protected string serviceUrl = null;
        protected HttpClient client = null;
        public LprEmployee01ViewService(IAppGlblSettingsService agstt) {
            this.appGlblSettings = agstt;
            this.serviceUrl = this.appGlblSettings.GetWebApiPrefix("LprEmployee01View") + "lpremployee01viewwebapi";
            this.client = this.appGlblSettings.Client;
        }

        protected Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>  _Values =
            new Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>() {
      {"EmployeeId", ("EmployeeId", "", "", true, false, true, false, "int32")},  // System.Int32
      {"EmpLastNameIdRef", ("EmpLastNameIdRef", "", "", true, false, true, false, "int32")},  // System.Int32
      {"EmpFirstNameIdRef", ("EmpFirstNameIdRef", "", "", true, false, true, false, "int32")},  // System.Int32
      {"EmpSecondNameIdRef", ("EmpSecondNameIdRef", "", "", true, false, true, false, "int32")},  // System.Int32
            };


    //
    // first key is Master View Name, 
    // second key is Direct Navigation Name, 
    // third key is Master View Property Name, 
    // value is a  Client View Property Name, i.e. Property Name of the Current View 
    protected Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> _M2cKeyfm =
        new Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)>() {
                    {("PhbkEmployeeView", "Employee", "EmployeeId"), (true, "EmployeeId")},
                    {("LpdEmpLastNameView", "EmpLastNameDict", "EmpLastNameId"), (true, "EmpLastNameIdRef")},
                    {("LpdEmpFirstNameView", "EmpFirstNameDict", "EmpFirstNameId"), (true, "EmpFirstNameIdRef")},
                    {("LpdEmpSecondNameView", "EmpSecondNameDict", "EmpSecondNameId"), (true, "EmpSecondNameIdRef")},
    }; 
    public Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> getM2cKeyfm()  {
        return this._M2cKeyfm;
    }
    //
    // first key is Master View Name, 
    // second key is Direct Navigation Name, 
    // third key is Master View Property Name, 
    // value is a  Client View Property Name, i.e. Property Name of the Current View 
    protected Dictionary<(string viewNm, string navNm, string propNm), string> _M2cfm = 
        new Dictionary<(string viewNm, string navNm, string propNm), string>() {
    };
    public Dictionary<(string viewNm, string navNm, string propNm), string> getM2cfm() {
        return this._M2cfm;
    }





    // master name, navigation name, master filed, master filed value
    public Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprEmployee01View rw, string nvNm) {
        Dictionary<(string viewNm, string navNm, string propNm), object> rslt = new Dictionary<(string viewNm, string navNm, string propNm), object>();
        if( (rw is null) || string.IsNullOrEmpty(nvNm) ) return rslt;
        foreach(string i in this._Values.Keys) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                rslt[("LprEmployee01View",nvNm,i)] = rw.GetType().GetProperty(i).GetValue(rw);
            }
        }
        return rslt;
    }
    public int getLength()  {
        return this._Values.Count;
    }
    public Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>.KeyCollection getKeys() {
        return this._Values.Keys;
    }
    public string getDtTpValue(string key) {
        return this._Values[key].dttp;
    }
    public string getFkValue(string key)  {
        return this._Values[key].fk;
    }
    public bool requiredValue(string key) {
        return this._Values[key].required;
    }
    public bool dbgeneratedValue(string key)  {
        return this._Values[key].dbgenerated;
    }
    public bool isInPrimkeyValue(string key)  {
        return this._Values[key].isinprimkey;
    }
    public bool IsInUnkKeyValue(string key)  {
        return this._Values[key].isinunqkey;
    }
    public string getKeyByOrgValue(string org, string fkchain) {
        foreach(string i in this._Values.Keys)
        {
            if(this._Values[i].org == org && this._Values[i].fkchain == fkchain) return i;
        }
        return null;
    }
    public IList<IWebServiceFilterRsltInterface> getHiddenFilterAsFltRslt(Dictionary<(string viewNm, string navNm, string propNm), object> HiddenFilter)  {
        IList<IWebServiceFilterRsltInterface> rslt = new List<IWebServiceFilterRsltInterface>();
        if(HiddenFilter is null) return rslt;
        Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> M2cKeyfm = this.getM2cKeyfm();
        foreach(var k in HiddenFilter.Keys) {
            if(HiddenFilter[k] != null) {
                if (M2cKeyfm.ContainsKey(k)) {
                    rslt.Add(
                        new WebServiceFilterRslt() {
                            fltrName = M2cKeyfm[k].propNm,
                            fltrDataType = this.getDtTpValue(M2cKeyfm[k].propNm),
                            fltrOperator = "eq",
                            fltrValue = HiddenFilter[k],
                            fltrError = null,
                            IsDestroyed = false
                        }
                    );
                }
            }
        }
        return rslt;
    }
    public Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByFltRslt(IList<IWebServiceFilterRsltInterface> fr) {
        Dictionary<(string viewNm, string navNm, string propNm), object> rslt = new Dictionary<(string viewNm, string navNm, string propNm), object>();
        if (fr == null) return rslt;
        foreach(var k in this._M2cKeyfm.Keys)
        {
            var fld = this._M2cKeyfm[k];
            var frItm = fr.Where(e => (e.fltrName == fld.propNm)).FirstOrDefault();
            if(frItm != null) {
                rslt[k] = frItm.fltrValue;
            }
        }
        return rslt;
    }



    // first key is Client View Name, 
    // second key is Direct Navigation Name, 
    // third key is Client View Property Name, 
    // value is a Master View Property Name, i.e. Property Name of the Current View 
    protected  Dictionary<(string viewNm, string navNm, string propNm), string> _C2mfm = 
        new Dictionary<(string viewNm, string navNm, string propNm), string>() {
    };
    public Dictionary<(string viewNm, string navNm, string propNm), string> getC2mfm() {
        return this._C2mfm;
    }



        public async Task<IList<ILprEmployee01View>> getall() {
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getall");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return new List<ILprEmployee01View>( JsonConvert.DeserializeObject<IList<LprEmployee01View>>(responseBody) );
            } 
            catch(Exception e)
            {
                string exceptionMsg = "LprEmployee01ViewService.getall : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                appGlblSettings.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }
        public async Task<ILprEmployee01ViewPage> getwithfilter(ILprEmployee01ViewFilter filter) {
            string prms = null;
            if(filter != null) {
                if (filter.EmployeeId != null) {
                    foreach(var val in filter.EmployeeId) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("employeeId") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("employeeId") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmpLastNameIdRef != null) {
                    foreach(var val in filter.EmpLastNameIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empLastNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empLastNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empLastNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empLastNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmpFirstNameIdRef != null) {
                    foreach(var val in filter.EmpFirstNameIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empFirstNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empFirstNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empFirstNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empFirstNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmpSecondNameIdRef != null) {
                    foreach(var val in filter.EmpSecondNameIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empSecondNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empSecondNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empSecondNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empSecondNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if(filter.employeeIdOprtr != null) {
                    foreach(var val in filter.employeeIdOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.empLastNameIdRefOprtr != null) {
                    foreach(var val in filter.empLastNameIdRefOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.empFirstNameIdRefOprtr != null) {
                    foreach(var val in filter.empFirstNameIdRefOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.empSecondNameIdRefOprtr != null) {
                    foreach(var val in filter.empSecondNameIdRefOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.orderby != null) {
                    foreach(var ordb in filter.orderby) {
                        if( !string.IsNullOrEmpty(ordb) ) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("orderby") + "[]=" +  Uri.EscapeDataString(ordb);
                                prms = "?" + Uri.EscapeDataString("orderby") + "=" +  Uri.EscapeDataString(ordb);
                            else 
                                //prms += "&" + Uri.EscapeDataString("orderby") + "[]=" + Uri.EscapeDataString(ordb);
                                prms += "&" + Uri.EscapeDataString("orderby") + "=" + Uri.EscapeDataString(ordb);
                        }
                    }
                }
                if(filter.page.HasValue) {
                    if(prms == null)
                        prms = "?" + Uri.EscapeDataString("page") + "=" +  Uri.EscapeDataString(filter.page.Value.ToString());
                    else 
                        prms += "&" + Uri.EscapeDataString("page") + "=" + Uri.EscapeDataString(filter.page.Value.ToString());
                }
                if(filter.pagesize.HasValue) {
                    if(prms == null)
                        prms = "?" + Uri.EscapeDataString("pagesize") + "=" +  Uri.EscapeDataString(filter.pagesize.Value.ToString());
                    else 
                        prms += "&" + Uri.EscapeDataString("pagesize") + "=" + Uri.EscapeDataString(filter.pagesize.Value.ToString());
                }
            }
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getwithfilter" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LprEmployee01ViewPage>(responseBody) ;
            } 
            catch(Exception e)
            {
                string exceptionMsg = "LprEmployee01ViewService.getwithfilter : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                appGlblSettings.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }

    // 
    // HowTo: {prm1, prm2, ..., prmN} -- primary/unique key
    //
    // this.serviceRefInYourCode.getone(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILprEmployee01View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    public async Task<ILprEmployee01View> getone(
        System.Int32 EmpLastNameIdRef 
        , System.Int32 EmpFirstNameIdRef 
        , System.Int32 EmpSecondNameIdRef 
        , System.Int32 EmployeeId 
        ) {
            string prms = null;
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("employeeId") + "=" +  Uri.EscapeDataString(EmployeeId.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("employeeId") + "=" + Uri.EscapeDataString(EmployeeId.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("empLastNameIdRef") + "=" +  Uri.EscapeDataString(EmpLastNameIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("empLastNameIdRef") + "=" + Uri.EscapeDataString(EmpLastNameIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("empFirstNameIdRef") + "=" +  Uri.EscapeDataString(EmpFirstNameIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("empFirstNameIdRef") + "=" + Uri.EscapeDataString(EmpFirstNameIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("empSecondNameIdRef") + "=" +  Uri.EscapeDataString(EmpSecondNameIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("empSecondNameIdRef") + "=" + Uri.EscapeDataString(EmpSecondNameIdRef.ToString());
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getone" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LprEmployee01View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprEmployee01ViewService.getone : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                appGlblSettings.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }


    public async Task<ILprEmployee01ViewPage> getmanybyrepprim(ILprEmployee01ViewFilter filter) {
        string prms = null;
        if(filter != null) {
                if (filter.EmployeeId != null) {
                    foreach(var val in filter.EmployeeId) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("employeeId") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("employeeId") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmpLastNameIdRef != null) {
                    foreach(var val in filter.EmpLastNameIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empLastNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empLastNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empLastNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empLastNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmpFirstNameIdRef != null) {
                    foreach(var val in filter.EmpFirstNameIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empFirstNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empFirstNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empFirstNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empFirstNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmpSecondNameIdRef != null) {
                    foreach(var val in filter.EmpSecondNameIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("empSecondNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("empSecondNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("empSecondNameIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("empSecondNameIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
            if(filter.employeeIdOprtr != null) {
                foreach(var val in filter.employeeIdOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("employeeIdOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("employeeIdOprtr") + "=" + Uri.EscapeDataString("eq");
                    }
                }
            }
            if(filter.empLastNameIdRefOprtr != null) {
                foreach(var val in filter.empLastNameIdRefOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("empLastNameIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                    }
                }
            }
            if(filter.empFirstNameIdRefOprtr != null) {
                foreach(var val in filter.empFirstNameIdRefOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("empFirstNameIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                    }
                }
            }
            if(filter.empSecondNameIdRefOprtr != null) {
                foreach(var val in filter.empSecondNameIdRefOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("empSecondNameIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                    }
                }
            }
            if(filter.orderby != null) {
                foreach(var ordb in filter.orderby) {
                    if( !string.IsNullOrEmpty(ordb) ) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("orderby") + "[]=" +  Uri.EscapeDataString(ordb);
                            prms = "?" + Uri.EscapeDataString("orderby") + "=" +  Uri.EscapeDataString(ordb);
                        else 
                            //prms += "&" + Uri.EscapeDataString("orderby") + "[]=" + Uri.EscapeDataString(ordb);
                            prms += "&" + Uri.EscapeDataString("orderby") + "=" + Uri.EscapeDataString(ordb);
                    }
                }
            }
            if(filter.page.HasValue) {
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("page") + "=" +  Uri.EscapeDataString(filter.page.Value.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("page") + "=" + Uri.EscapeDataString(filter.page.Value.ToString());
            }
            if(filter.pagesize.HasValue) {
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("pagesize") + "=" +  Uri.EscapeDataString(filter.pagesize.Value.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("pagesize") + "=" + Uri.EscapeDataString(filter.pagesize.Value.ToString());
            }
        } // the end of if(filter != null) {...}
        if(prms == null) prms = "";
        try
        {
            HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getmanybyrepprim" + prms);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<LprEmployee01ViewPage>(responseBody) ;
        } 
        catch(Exception e)
        {
            string exceptionMsg = "LprEmployee01ViewService.getmanybyrepprim : " + e.Message;
            Exception inner = e.InnerException;
            while (inner != null)
            {
                exceptionMsg = exceptionMsg + ": " + inner.Message;
                inner = inner.InnerException;
            }
            appGlblSettings.ShowErrorMessage("http", exceptionMsg);
            return null;
        }
    }


        public async Task<ILprEmployee01View> updateone(ILprEmployee01View item) {
            if(item == null) {
                appGlblSettings.ShowErrorMessage("http", "Input item is not defined");
                return null;
            }
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PutAsync(serviceUrl + "/" + "updateone", stringContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LprEmployee01View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprEmployee01ViewService.updateone : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                appGlblSettings.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }
        public async Task<ILprEmployee01View> addone(ILprEmployee01View item) {
            if(item == null) {
                appGlblSettings.ShowErrorMessage("http", "Input item is not defined");
                return null;
            }
            try
            {
                var stringContent = new StringContent(JsonConvert.SerializeObject(item), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await client.PostAsync(serviceUrl + "/" + "addone", stringContent);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LprEmployee01View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprEmployee01ViewService.addone : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                appGlblSettings.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }
        public async Task<ILprEmployee01View> deleteone(System.Int32 EmpLastNameIdRef , System.Int32 EmpFirstNameIdRef , System.Int32 EmpSecondNameIdRef , System.Int32 EmployeeId ) {
            string prms = null;
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("employeeId") + "=" +  Uri.EscapeDataString(EmployeeId.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("employeeId") + "=" + Uri.EscapeDataString(EmployeeId.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("empLastNameIdRef") + "=" +  Uri.EscapeDataString(EmpLastNameIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("empLastNameIdRef") + "=" + Uri.EscapeDataString(EmpLastNameIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("empFirstNameIdRef") + "=" +  Uri.EscapeDataString(EmpFirstNameIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("empFirstNameIdRef") + "=" + Uri.EscapeDataString(EmpFirstNameIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("empSecondNameIdRef") + "=" +  Uri.EscapeDataString(EmpSecondNameIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("empSecondNameIdRef") + "=" + Uri.EscapeDataString(EmpSecondNameIdRef.ToString());
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(serviceUrl + "/" + "deleteone" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LprEmployee01View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprEmployee01ViewService.deleteone : " + e.Message;
                Exception inner = e.InnerException;
                while (inner != null)
                {
                    exceptionMsg = exceptionMsg + ": " + inner.Message;
                    inner = inner.InnerException;
                }
                appGlblSettings.ShowErrorMessage("http", exceptionMsg);
                return null;
            }
        }
        public ILprEmployee01ViewNotify CopyToModelNotify(ILprEmployee01View  src, ILprEmployee01ViewNotify dest = null) {
            if(dest == null) dest = new LprEmployee01ViewNotify();
            if(src == null) return dest;
            dest.EmployeeId = src.EmployeeId;
            dest.EmpLastNameIdRef = src.EmpLastNameIdRef;
            dest.EmpFirstNameIdRef = src.EmpFirstNameIdRef;
            dest.EmpSecondNameIdRef = src.EmpSecondNameIdRef;
            return dest;
        }
        public ILprEmployee01View CopyToModel(ILprEmployee01View  src, ILprEmployee01View dest = null) {
            if(dest == null) dest = new LprEmployee01View();
            if(src == null) return dest;
            dest.EmployeeId = src.EmployeeId;
            dest.EmpLastNameIdRef = src.EmpLastNameIdRef;
            dest.EmpFirstNameIdRef = src.EmpFirstNameIdRef;
            dest.EmpSecondNameIdRef = src.EmpSecondNameIdRef;
            return dest;
        }

        public ILprEmployee01ViewFilter GetFilter() {
            return new LprEmployee01ViewFilter();
        }

        public IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprEmployee01View r) {
            IList<IWebServiceFilterRsltInterface> rslt = new List<IWebServiceFilterRsltInterface>();
            if (r == null) return rslt;
            foreach(string i in this._Values.Keys) {
                if (!(r.GetType().GetProperty(i).GetValue(r) is null)) {
                    rslt.Add(new WebServiceFilterRslt{
                        fltrName = i,
                        fltrDataType = this._Values[i].dttp,
                        fltrOperator = "eq",
                        fltrValue = r.GetType().GetProperty(i).GetValue(r)
                    });
                }
            }
            return rslt;
        }
        public IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprEmployee01View r) {
            IList<IWebServiceFilterRsltInterface> rslt = new List<IWebServiceFilterRsltInterface>();
            if (r == null) return rslt;
            foreach(string i in this._Values.Keys) {
                if(this._Values[i].isinprimkey) {
                    if (!(r.GetType().GetProperty(i).GetValue(r) is null)) {
                        rslt.Add(new WebServiceFilterRslt{
                            fltrName = i,
                            fltrDataType = this._Values[i].dttp,
                            fltrOperator = "eq",
                            fltrValue = r.GetType().GetProperty(i).GetValue(r)
                        });
                    }
                }
            }
            return rslt;
        }

        
        public ILprEmployee01ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprEmployee01ViewFilter dest) {
            ILprEmployee01ViewFilter flt = dest;
            if(dest is null) {
                flt = GetFilter();
            }
            if(e is null) return flt;
            if((!string.IsNullOrEmpty(e.fltrError)) || string.IsNullOrEmpty(e.fltrName)) return flt;
            switch(e.fltrName) {
                case "EmployeeId":
                    if (flt.EmployeeId == null) flt.EmployeeId = new List<System.Int32>();
                    flt.EmployeeId.Add((System.Int32)e.fltrValue);
                    if (flt.employeeIdOprtr == null) flt.employeeIdOprtr = new List<string>();
                    flt.employeeIdOprtr.Add(e.fltrOperator);
                    break;
                case "EmpLastNameIdRef":
                    if (flt.EmpLastNameIdRef == null) flt.EmpLastNameIdRef = new List<System.Int32>();
                    flt.EmpLastNameIdRef.Add((System.Int32)e.fltrValue);
                    if (flt.empLastNameIdRefOprtr == null) flt.empLastNameIdRefOprtr = new List<string>();
                    flt.empLastNameIdRefOprtr.Add(e.fltrOperator);
                    break;
                case "EmpFirstNameIdRef":
                    if (flt.EmpFirstNameIdRef == null) flt.EmpFirstNameIdRef = new List<System.Int32>();
                    flt.EmpFirstNameIdRef.Add((System.Int32)e.fltrValue);
                    if (flt.empFirstNameIdRefOprtr == null) flt.empFirstNameIdRefOprtr = new List<string>();
                    flt.empFirstNameIdRefOprtr.Add(e.fltrOperator);
                    break;
                case "EmpSecondNameIdRef":
                    if (flt.EmpSecondNameIdRef == null) flt.EmpSecondNameIdRef = new List<System.Int32>();
                    flt.EmpSecondNameIdRef.Add((System.Int32)e.fltrValue);
                    if (flt.empSecondNameIdRefOprtr == null) flt.empSecondNameIdRefOprtr = new List<string>();
                    flt.empSecondNameIdRefOprtr.Add(e.fltrOperator);
                    break;
                default: break;
            }
            return flt;
        }
        public ILprEmployee01ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprEmployee01ViewFilter dest) {
            ILprEmployee01ViewFilter rslt = dest;
            if(dest is null) {
                rslt = GetFilter();
            }
            if(src is null) return rslt;
            foreach(IWebServiceFilterRsltInterface e in src) {
                FilterRslt2Filter(e, rslt);
            }
            return rslt;
        }

    }
}

