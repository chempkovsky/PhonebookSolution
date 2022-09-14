using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

using ModelInterfacesClassLibrary.Phonebook.LprPhone04;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.Classes;

/*
    In the file of IModule-class of the project for the current service the following lines of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            containerRegistry.Register<ILprPhone04ViewService, LprPhone04ViewService>();
            ...
        }

*/
namespace ModelServicesPrismModule.Phonebook.LprPhone04 {
    public class LprPhone04ViewService: ILprPhone04ViewService
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
        public LprPhone04ViewService(IAppGlblSettingsService agstt) {
            this.appGlblSettings = agstt;
            this.serviceUrl = this.appGlblSettings.GetWebApiPrefix("LprPhone04View") + "lprphone04viewwebapi";
            this.client = this.appGlblSettings.Client;
        }

        protected Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>  _Values =
            new Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>() {
      {"PhoneId", ("PhoneId", "", "", true, false, true, true, "int32")},  // System.Int32
      {"LpdPhoneIdRef", ("LpdPhoneIdRef", "", "", true, false, true, true, "int32")},  // System.Int32
      {"EmployeeIdRef", ("EmployeeIdRef", "", "", true, false, true, false, "int32")},  // System.Int32
      {"PhoneTypeIdRef", ("PhoneTypeIdRef", "", "", true, false, true, false, "int32")},  // System.Int32
            };


    //
    // first key is Master View Name, 
    // second key is Direct Navigation Name, 
    // third key is Master View Property Name, 
    // value is a  Client View Property Name, i.e. Property Name of the Current View 
    protected Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> _M2cKeyfm =
        new Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)>() {
                    {("LpdPhoneView", "PhoneDict", "LpdPhoneId"), (true, "LpdPhoneIdRef")},
                    {("PhbkPhoneView", "Phone", "PhoneId"), (true, "PhoneId")},
                    {("PhbkEmployeeView", "Employee", "EmployeeId"), (true, "EmployeeIdRef")},
                    {("PhbkPhoneTypeView", "PhoneType", "PhoneTypeId"), (true, "PhoneTypeIdRef")},
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
    public Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILprPhone04View rw, string nvNm) {
        Dictionary<(string viewNm, string navNm, string propNm), object> rslt = new Dictionary<(string viewNm, string navNm, string propNm), object>();
        if( (rw is null) || string.IsNullOrEmpty(nvNm) ) return rslt;
        foreach(string i in this._Values.Keys) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                rslt[("LprPhone04View",nvNm,i)] = rw.GetType().GetProperty(i).GetValue(rw);
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



        public async Task<IList<ILprPhone04View>> getall() {
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getall");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return new List<ILprPhone04View>( JsonConvert.DeserializeObject<IList<LprPhone04View>>(responseBody) );
            } 
            catch(Exception e)
            {
                string exceptionMsg = "LprPhone04ViewService.getall : " + e.Message;
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
        public async Task<ILprPhone04ViewPage> getwithfilter(ILprPhone04ViewFilter filter) {
            string prms = null;
            if(filter != null) {
                if (filter.PhoneId != null) {
                    foreach(var val in filter.PhoneId) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phoneId") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phoneId") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.LpdPhoneIdRef != null) {
                    foreach(var val in filter.LpdPhoneIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmployeeIdRef != null) {
                    foreach(var val in filter.EmployeeIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("employeeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("employeeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.PhoneTypeIdRef != null) {
                    foreach(var val in filter.PhoneTypeIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneTypeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phoneTypeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneTypeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phoneTypeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if(filter.phoneIdOprtr != null) {
                    foreach(var val in filter.phoneIdOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.lpdPhoneIdRefOprtr != null) {
                    foreach(var val in filter.lpdPhoneIdRefOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.employeeIdRefOprtr != null) {
                    foreach(var val in filter.employeeIdRefOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.phoneTypeIdRefOprtr != null) {
                    foreach(var val in filter.phoneTypeIdRefOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
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
                return  JsonConvert.DeserializeObject<LprPhone04ViewPage>(responseBody) ;
            } 
            catch(Exception e)
            {
                string exceptionMsg = "LprPhone04ViewService.getwithfilter : " + e.Message;
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
    //    // handling value of type ILprPhone04View
    // },
    // error => {
    //    // handling error 
    // });
    // 
    public async Task<ILprPhone04View> getone(
        System.Int32 EmployeeIdRef 
        , System.Int32 PhoneTypeIdRef 
        , System.Int32 LpdPhoneIdRef 
        , System.Int32 PhoneId 
        ) {
            string prms = null;
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("phoneId") + "=" +  Uri.EscapeDataString(PhoneId.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("phoneId") + "=" + Uri.EscapeDataString(PhoneId.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" +  Uri.EscapeDataString(LpdPhoneIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" + Uri.EscapeDataString(LpdPhoneIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("employeeIdRef") + "=" +  Uri.EscapeDataString(EmployeeIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("employeeIdRef") + "=" + Uri.EscapeDataString(EmployeeIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("phoneTypeIdRef") + "=" +  Uri.EscapeDataString(PhoneTypeIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("phoneTypeIdRef") + "=" + Uri.EscapeDataString(PhoneTypeIdRef.ToString());
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getone" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LprPhone04View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprPhone04ViewService.getone : " + e.Message;
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


    public async Task<ILprPhone04ViewPage> getmanybyrepprim(ILprPhone04ViewFilter filter) {
        string prms = null;
        if(filter != null) {
                if (filter.PhoneId != null) {
                    foreach(var val in filter.PhoneId) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phoneId") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phoneId") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.LpdPhoneIdRef != null) {
                    foreach(var val in filter.LpdPhoneIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.EmployeeIdRef != null) {
                    foreach(var val in filter.EmployeeIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("employeeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("employeeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("employeeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("employeeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.PhoneTypeIdRef != null) {
                    foreach(var val in filter.PhoneTypeIdRef) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneTypeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phoneTypeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneTypeIdRef") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phoneTypeIdRef") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
            if(filter.phoneIdOprtr != null) {
                foreach(var val in filter.phoneIdOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("phoneIdOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("phoneIdOprtr") + "=" + Uri.EscapeDataString("eq");
                    }
                }
            }
            if(filter.lpdPhoneIdRefOprtr != null) {
                foreach(var val in filter.lpdPhoneIdRefOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("lpdPhoneIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                    }
                }
            }
            if(filter.employeeIdRefOprtr != null) {
                foreach(var val in filter.employeeIdRefOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("employeeIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
                    }
                }
            }
            if(filter.phoneTypeIdRefOprtr != null) {
                foreach(var val in filter.phoneTypeIdRefOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("phoneTypeIdRefOprtr") + "=" + Uri.EscapeDataString("eq");
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
            return  JsonConvert.DeserializeObject<LprPhone04ViewPage>(responseBody) ;
        } 
        catch(Exception e)
        {
            string exceptionMsg = "LprPhone04ViewService.getmanybyrepprim : " + e.Message;
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


        public async Task<ILprPhone04View> updateone(ILprPhone04View item) {
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
                return  JsonConvert.DeserializeObject<LprPhone04View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprPhone04ViewService.updateone : " + e.Message;
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
        public async Task<ILprPhone04View> addone(ILprPhone04View item) {
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
                return  JsonConvert.DeserializeObject<LprPhone04View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprPhone04ViewService.addone : " + e.Message;
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
        public async Task<ILprPhone04View> deleteone(System.Int32 EmployeeIdRef , System.Int32 PhoneTypeIdRef , System.Int32 LpdPhoneIdRef , System.Int32 PhoneId ) {
            string prms = null;
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("phoneId") + "=" +  Uri.EscapeDataString(PhoneId.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("phoneId") + "=" + Uri.EscapeDataString(PhoneId.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" +  Uri.EscapeDataString(LpdPhoneIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("lpdPhoneIdRef") + "=" + Uri.EscapeDataString(LpdPhoneIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("employeeIdRef") + "=" +  Uri.EscapeDataString(EmployeeIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("employeeIdRef") + "=" + Uri.EscapeDataString(EmployeeIdRef.ToString());
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("phoneTypeIdRef") + "=" +  Uri.EscapeDataString(PhoneTypeIdRef.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("phoneTypeIdRef") + "=" + Uri.EscapeDataString(PhoneTypeIdRef.ToString());
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(serviceUrl + "/" + "deleteone" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LprPhone04View>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LprPhone04ViewService.deleteone : " + e.Message;
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
        public ILprPhone04ViewNotify CopyToModelNotify(ILprPhone04View  src, ILprPhone04ViewNotify dest = null) {
            if(dest == null) dest = new LprPhone04ViewNotify();
            if(src == null) return dest;
            dest.PhoneId = src.PhoneId;
            dest.LpdPhoneIdRef = src.LpdPhoneIdRef;
            dest.EmployeeIdRef = src.EmployeeIdRef;
            dest.PhoneTypeIdRef = src.PhoneTypeIdRef;
            return dest;
        }
        public ILprPhone04View CopyToModel(ILprPhone04View  src, ILprPhone04View dest = null) {
            if(dest == null) dest = new LprPhone04View();
            if(src == null) return dest;
            dest.PhoneId = src.PhoneId;
            dest.LpdPhoneIdRef = src.LpdPhoneIdRef;
            dest.EmployeeIdRef = src.EmployeeIdRef;
            dest.PhoneTypeIdRef = src.PhoneTypeIdRef;
            return dest;
        }

        public ILprPhone04ViewFilter GetFilter() {
            return new LprPhone04ViewFilter();
        }

        public IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILprPhone04View r) {
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
        public IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILprPhone04View r) {
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

        
        public ILprPhone04ViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILprPhone04ViewFilter dest) {
            ILprPhone04ViewFilter flt = dest;
            if(dest is null) {
                flt = GetFilter();
            }
            if(e is null) return flt;
            if((!string.IsNullOrEmpty(e.fltrError)) || string.IsNullOrEmpty(e.fltrName)) return flt;
            switch(e.fltrName) {
                case "PhoneId":
                    if (flt.PhoneId == null) flt.PhoneId = new List<System.Int32>();
                    flt.PhoneId.Add((System.Int32)e.fltrValue);
                    if (flt.phoneIdOprtr == null) flt.phoneIdOprtr = new List<string>();
                    flt.phoneIdOprtr.Add(e.fltrOperator);
                    break;
                case "LpdPhoneIdRef":
                    if (flt.LpdPhoneIdRef == null) flt.LpdPhoneIdRef = new List<System.Int32>();
                    flt.LpdPhoneIdRef.Add((System.Int32)e.fltrValue);
                    if (flt.lpdPhoneIdRefOprtr == null) flt.lpdPhoneIdRefOprtr = new List<string>();
                    flt.lpdPhoneIdRefOprtr.Add(e.fltrOperator);
                    break;
                case "EmployeeIdRef":
                    if (flt.EmployeeIdRef == null) flt.EmployeeIdRef = new List<System.Int32>();
                    flt.EmployeeIdRef.Add((System.Int32)e.fltrValue);
                    if (flt.employeeIdRefOprtr == null) flt.employeeIdRefOprtr = new List<string>();
                    flt.employeeIdRefOprtr.Add(e.fltrOperator);
                    break;
                case "PhoneTypeIdRef":
                    if (flt.PhoneTypeIdRef == null) flt.PhoneTypeIdRef = new List<System.Int32>();
                    flt.PhoneTypeIdRef.Add((System.Int32)e.fltrValue);
                    if (flt.phoneTypeIdRefOprtr == null) flt.phoneTypeIdRefOprtr = new List<string>();
                    flt.phoneTypeIdRefOprtr.Add(e.fltrOperator);
                    break;
                default: break;
            }
            return flt;
        }
        public ILprPhone04ViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILprPhone04ViewFilter dest) {
            ILprPhone04ViewFilter rslt = dest;
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

