using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

using ModelInterfacesClassLibrary.Phonebook.LpdPhone;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.Classes;

/*
    In the file of IModule-class of the project for the current service the following lines of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            containerRegistry.Register<ILpdPhoneViewService, LpdPhoneViewService>();
            ...
        }

*/
namespace ModelServicesPrismModule.Phonebook.LpdPhone {
    public class LpdPhoneViewService: ILpdPhoneViewService
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
        public LpdPhoneViewService(IAppGlblSettingsService agstt) {
            this.appGlblSettings = agstt;
            this.serviceUrl = this.appGlblSettings.GetWebApiPrefix("LpdPhoneView") + "lpdphoneviewwebapi";
            this.client = this.appGlblSettings.Client;
        }

        protected Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>  _Values =
            new Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>() {
      {"LpdPhoneId", ("LpdPhoneId", "", "", true, false, true, true, "int32")},  // System.Int32
      {"Phone", ("Phone", "", "", false, true, true, false, "string")},  // System.String
            };


    //
    // first key is Master View Name, 
    // second key is Direct Navigation Name, 
    // third key is Master View Property Name, 
    // value is a  Client View Property Name, i.e. Property Name of the Current View 
    protected Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> _M2cKeyfm =
        new Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)>() {
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
    public Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByRow(ILpdPhoneView rw, string nvNm) {
        Dictionary<(string viewNm, string navNm, string propNm), object> rslt = new Dictionary<(string viewNm, string navNm, string propNm), object>();
        if( (rw is null) || string.IsNullOrEmpty(nvNm) ) return rslt;
        foreach(string i in this._Values.Keys) {
            if(this.isInPrimkeyValue(i) || this.IsInUnkKeyValue(i)) {
                rslt[("LpdPhoneView",nvNm,i)] = rw.GetType().GetProperty(i).GetValue(rw);
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
    {("LprPhone01View", "PhoneDict", "LpdPhoneIdRef"), "LpdPhoneId"},
    {("LprPhone02View", "PhoneDict", "LpdPhoneIdRef"), "LpdPhoneId"},
    {("LprPhone03View", "PhoneDict", "LpdPhoneIdRef"), "LpdPhoneId"},
    {("LprPhone04View", "PhoneDict", "LpdPhoneIdRef"), "LpdPhoneId"},
    };
    public Dictionary<(string viewNm, string navNm, string propNm), string> getC2mfm() {
        return this._C2mfm;
    }



        public async Task<IList<ILpdPhoneView>> getall() {
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getall");
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return new List<ILpdPhoneView>( JsonConvert.DeserializeObject<IList<LpdPhoneView>>(responseBody) );
            } 
            catch(Exception e)
            {
                string exceptionMsg = "LpdPhoneViewService.getall : " + e.Message;
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
        public async Task<ILpdPhoneViewPage> getwithfilter(ILpdPhoneViewFilter filter) {
            string prms = null;
            if(filter != null) {
                if (filter.LpdPhoneId != null) {
                    foreach(var val in filter.LpdPhoneId) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("lpdPhoneId") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("lpdPhoneId") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if (filter.Phone != null) {
                    foreach(var val in filter.Phone) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phone") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phone") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phone") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phone") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
                if(filter.lpdPhoneIdOprtr != null) {
                    foreach(var val in filter.lpdPhoneIdOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" + Uri.EscapeDataString("eq");
                        }
                    }
                }
                if(filter.phoneOprtr != null) {
                    foreach(var val in filter.phoneOprtr) {
                        if(val != null) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phoneOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phoneOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                        } else {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phoneOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                                prms = "?" + Uri.EscapeDataString("phoneOprtr") + "=" +  Uri.EscapeDataString("eq");
                            else 
                                //prms += "&" + Uri.EscapeDataString("phoneOprtr") + "[]=" + Uri.EscapeDataString("eq");
                                prms += "&" + Uri.EscapeDataString("phoneOprtr") + "=" + Uri.EscapeDataString("eq");
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
                return  JsonConvert.DeserializeObject<LpdPhoneViewPage>(responseBody) ;
            } 
            catch(Exception e)
            {
                string exceptionMsg = "LpdPhoneViewService.getwithfilter : " + e.Message;
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
    //    // handling value of type ILpdPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    public async Task<ILpdPhoneView> getone(
        System.Int32 LpdPhoneId 
        ) {
            string prms = null;
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("lpdPhoneId") + "=" +  Uri.EscapeDataString(LpdPhoneId.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("lpdPhoneId") + "=" + Uri.EscapeDataString(LpdPhoneId.ToString());
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getone" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LpdPhoneView>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LpdPhoneViewService.getone : " + e.Message;
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


    public async Task<ILpdPhoneViewPage> getmanybyrepprim(ILpdPhoneViewFilter filter) {
        string prms = null;
        if(filter != null) {
                if (filter.LpdPhoneId != null) {
                    foreach(var val in filter.LpdPhoneId) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("lpdPhoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("lpdPhoneId") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("lpdPhoneId") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("lpdPhoneId") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
            if(filter.lpdPhoneIdOprtr != null) {
                foreach(var val in filter.lpdPhoneIdOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("lpdPhoneIdOprtr") + "=" + Uri.EscapeDataString("eq");
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
            return  JsonConvert.DeserializeObject<LpdPhoneViewPage>(responseBody) ;
        } 
        catch(Exception e)
        {
            string exceptionMsg = "LpdPhoneViewService.getmanybyrepprim : " + e.Message;
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
    // this.serviceRefInYourCode.getonebyLpdPhoneUK(prm1, prm2, ..., prmN ).subscibe(value =>{
    //    // handling value of type ILpdPhoneView
    // },
    // error => {
    //    // handling error 
    // });
    // 
    public async Task<ILpdPhoneView> getonebyLpdPhoneUK(
        System.String Phone 
        ) {
            string prms = null;
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("phone") + "=" +  Uri.EscapeDataString(Phone.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("phone") + "=" + Uri.EscapeDataString(Phone.ToString());
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getone" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LpdPhoneView>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LpdPhoneViewService.getone : " + e.Message;
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


    public async Task<ILpdPhoneViewPage> getmanybyrepunqLpdPhoneUK(ILpdPhoneViewFilter filter) {
        string prms = null;
        if(filter != null) {
                if (filter.Phone != null) {
                    foreach(var val in filter.Phone) {
                            if(prms == null)
                                //prms = "?" + Uri.EscapeDataString("phone") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms = "?" + Uri.EscapeDataString("phone") + "=" + Uri.EscapeDataString(val.ToString());
                            else 
                                //prms += "&" + Uri.EscapeDataString("phone") + "[]=" + Uri.EscapeDataString(val.ToString());
                                prms += "&" + Uri.EscapeDataString("phone") + "=" + Uri.EscapeDataString(val.ToString());
                    }
                }
            if(filter.phoneOprtr != null) {
                foreach(var val in filter.phoneOprtr) {
                    if(val != null) {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("phoneOprtr") + "[]=" +  Uri.EscapeDataString(val.ToString());
                            prms = "?" + Uri.EscapeDataString("phoneOprtr") + "=" +  Uri.EscapeDataString(val.ToString());
                        else 
                            //prms += "&" + Uri.EscapeDataString("phoneOprtr") + "[]=" + Uri.EscapeDataString(val.ToString());
                            prms += "&" + Uri.EscapeDataString("phoneOprtr") + "=" + Uri.EscapeDataString(val.ToString());
                    } else {
                        if(prms == null)
                            //prms = "?" + Uri.EscapeDataString("phoneOprtr") + "[]=" +  Uri.EscapeDataString("eq");
                            prms = "?" + Uri.EscapeDataString("phoneOprtr") + "=" +  Uri.EscapeDataString("eq");
                        else 
                            //prms += "&" + Uri.EscapeDataString("phoneOprtr") + "[]=" + Uri.EscapeDataString("eq");
                            prms += "&" + Uri.EscapeDataString("phoneOprtr") + "=" + Uri.EscapeDataString("eq");
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
            HttpResponseMessage response = await client.GetAsync(serviceUrl + "/" + "getmanybyrepunqLpdPhoneUK" + prms);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();
            return  JsonConvert.DeserializeObject<LpdPhoneViewPage>(responseBody) ;
        } 
        catch(Exception e)
        {
            string exceptionMsg = "LpdPhoneViewService.getmanybyrepunqLpdPhoneUK : " + e.Message;
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


        public async Task<ILpdPhoneView> updateone(ILpdPhoneView item) {
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
                return  JsonConvert.DeserializeObject<LpdPhoneView>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LpdPhoneViewService.updateone : " + e.Message;
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
        public async Task<ILpdPhoneView> addone(ILpdPhoneView item) {
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
                return  JsonConvert.DeserializeObject<LpdPhoneView>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LpdPhoneViewService.addone : " + e.Message;
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
        public async Task<ILpdPhoneView> deleteone(System.Int32 LpdPhoneId ) {
            string prms = null;
                if(prms == null)
                    prms = "?" + Uri.EscapeDataString("lpdPhoneId") + "=" +  Uri.EscapeDataString(LpdPhoneId.ToString());
                else 
                    prms += "&" + Uri.EscapeDataString("lpdPhoneId") + "=" + Uri.EscapeDataString(LpdPhoneId.ToString());
            if(prms == null) prms = "";
            try
            {
                HttpResponseMessage response = await client.DeleteAsync(serviceUrl + "/" + "deleteone" + prms);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return  JsonConvert.DeserializeObject<LpdPhoneView>(responseBody) ;
            } 
            catch(Exception e) 
            {
                string exceptionMsg = "LpdPhoneViewService.deleteone : " + e.Message;
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
        public ILpdPhoneViewNotify CopyToModelNotify(ILpdPhoneView  src, ILpdPhoneViewNotify dest = null) {
            if(dest == null) dest = new LpdPhoneViewNotify();
            if(src == null) return dest;
            dest.LpdPhoneId = src.LpdPhoneId;
            dest.Phone = src.Phone;
            return dest;
        }
        public ILpdPhoneView CopyToModel(ILpdPhoneView  src, ILpdPhoneView dest = null) {
            if(dest == null) dest = new LpdPhoneView();
            if(src == null) return dest;
            dest.LpdPhoneId = src.LpdPhoneId;
            dest.Phone = src.Phone;
            return dest;
        }

        public ILpdPhoneViewFilter GetFilter() {
            return new LpdPhoneViewFilter();
        }

        public IList<IWebServiceFilterRsltInterface> Row2FilterRslt(ILpdPhoneView r) {
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
        public IList<IWebServiceFilterRsltInterface> RowPrim2FilterRslt(ILpdPhoneView r) {
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

        
        public ILpdPhoneViewFilter FilterRslt2Filter(IWebServiceFilterRsltInterface e, ILpdPhoneViewFilter dest) {
            ILpdPhoneViewFilter flt = dest;
            if(dest is null) {
                flt = GetFilter();
            }
            if(e is null) return flt;
            if((!string.IsNullOrEmpty(e.fltrError)) || string.IsNullOrEmpty(e.fltrName)) return flt;
            switch(e.fltrName) {
                case "LpdPhoneId":
                    if (flt.LpdPhoneId == null) flt.LpdPhoneId = new List<System.Int32>();
                    flt.LpdPhoneId.Add((System.Int32)e.fltrValue);
                    if (flt.lpdPhoneIdOprtr == null) flt.lpdPhoneIdOprtr = new List<string>();
                    flt.lpdPhoneIdOprtr.Add(e.fltrOperator);
                    break;
                case "Phone":
                    if (flt.Phone == null) flt.Phone = new List<System.String>();
                    flt.Phone.Add((System.String)e.fltrValue);
                    if (flt.phoneOprtr == null) flt.phoneOprtr = new List<string>();
                    flt.phoneOprtr.Add(e.fltrOperator);
                    break;
                default: break;
            }
            return flt;
        }
        public ILpdPhoneViewFilter FilterRslt2Filter(IList<IWebServiceFilterRsltInterface> src, ILpdPhoneViewFilter dest) {
            ILpdPhoneViewFilter rslt = dest;
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

