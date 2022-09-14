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
            containerRegistry.Register<ILpdPhoneViewDatasource, LpdPhoneViewDatasource>();
            ...
        }

*/
namespace ModelServicesPrismModule.Phonebook.LpdPhone {
    public class LpdPhoneViewDatasource: ILpdPhoneViewDatasource
    {
        protected readonly string _CurrentViewName   = "LpdPhoneView";
        protected string _ClientViewName = null;
        protected string _DirectNavigation = null;
        protected bool _IsDefined = false;
        protected IList<string> _CurrentlyDirectMasterNavs = new List<string>();
        protected Dictionary<(string viewNm, string navNm, string propNm), object> _HiddenFilter = new Dictionary<(string viewNm, string navNm, string propNm), object>();
        protected IList<string> _UnderHiddenFilterFields  = new List<string>();
        protected bool _IsNew = true;
        protected string _UIFormChain  = "";
        protected Dictionary<string,object> _Values = new Dictionary<string,object> {
            {"LpdPhoneId", null},  // System.Int32
            {"Phone", null},  // System.String
        };
        protected ILpdPhoneViewService frmRootSrv;
        protected IAppGlblSettingsService appGlblSettings;

        public LpdPhoneViewDatasource(ILpdPhoneViewService frs,
            IAppGlblSettingsService agstt) {
            frmRootSrv = frs;
            appGlblSettings = agstt;
        }
        public void Init(string ClientViewName, 
            string DirectNavigation,
            IList<string> CurrentlyDirectMasterNavs,
            string UIFormChain) {
            if(string.IsNullOrEmpty(ClientViewName)) this._ClientViewName = null;
                else this._ClientViewName = ClientViewName;
            if(string.IsNullOrEmpty(DirectNavigation)) this._DirectNavigation = null;
                else this._DirectNavigation = DirectNavigation;
            if(CurrentlyDirectMasterNavs == null) {
                this._CurrentlyDirectMasterNavs = new List<string>();
            } else {
                this._CurrentlyDirectMasterNavs = CurrentlyDirectMasterNavs;
            }
            this._UIFormChain = UIFormChain;
        }

        public event EventHandler OnDetailChanged;
        public event EventHandler OnMasterChanged;
        public event EventHandler AfterMasterChanged;
        public event EventHandler AfterPropsChanged;
        public event EventHandler OnIsDefinedChanged;
        public event EventHandler OnUpdate;
        public event EventHandler OnAdd;
        public event EventHandler OnDelete;

        public void DoEmitEvent(bool aftrMstrChngd=false) {
            bool isDef = this.CalcIsDefined();
            if(this._IsDefined != isDef) {
                this._IsDefined = isDef;
                this.OnIsDefinedChanged?.Invoke(this,null);
            }
            this.OnDetailChanged?.Invoke(this,null);
            this.OnMasterChanged?.Invoke(this,null);
            if(aftrMstrChngd) this.AfterMasterChanged?.Invoke(this,null);
            this.AfterPropsChanged?.Invoke(this,null);
        }
        public Dictionary<(string viewNm, string navNm, string propNm), object>  getHiddenFilterByRow(ILpdPhoneView rw, string nvNm) {
            return this.frmRootSrv.getHiddenFilterByRow(rw, nvNm);
        }
        public Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilterByFltRslt(IList<IWebServiceFilterRsltInterface> fr) {
            return this.frmRootSrv.getHiddenFilterByFltRslt(fr);
        }
        public bool RefreshIsDefined() {
            this._IsDefined = this.CalcIsDefined();
            return this._IsDefined;
        }
        public bool CalcIsDefined()  {
            var keys = this._Values.Keys.ToList();
            foreach(string i in keys) {
                if((!this.frmRootSrv.dbgeneratedValue(i)) && 
                    this.frmRootSrv.requiredValue(i)) {
                    if(!this.isSetValue(i)) return false;        
                }
            }
            return true;
        }
        public string getUIFormChain() {
            return this._UIFormChain;
        }
        public Dictionary<(string viewNm, string navNm, string propNm), object> getHiddenFilter() {
            return this._HiddenFilter;
        }
        public IList<IWebServiceFilterRsltInterface> getHiddenFilterAsFltRslt() {
            return this.frmRootSrv.getHiddenFilterAsFltRslt(this._HiddenFilter);
        }
        public void setHiddenFilter(Dictionary<(string viewNm, string navNm, string propNm), object> fltr) {
            this._HiddenFilter = fltr;
            this.setUnderHiddenFilterFields();
        }
        public bool getIsTopDetail() {
            return string.IsNullOrEmpty(this._UIFormChain);
        }
        public bool getIsDefined() {
            return this._IsDefined;
        }
        public string getCurrentViewName() {
            return this._CurrentViewName;
        }
        public string getClientViewName() {
            return this._ClientViewName;
        }
        public string getDirectNavigation() {
            return this._DirectNavigation;
        }


        public int getLength() {
            return this.frmRootSrv.getLength();
        }
        public Dictionary<string, (string org, string fk, string fkchain , bool isinprimkey, bool isinunqkey, bool required, bool dbgenerated, string dttp)>.KeyCollection getKeys() {
            return this.frmRootSrv.getKeys();
        }
        public string getDtTpValue(string key) {
            return this.frmRootSrv.getDtTpValue(key);
        }
        public object getValue(string key) {
            return this._Values[key];
        }
        public void setValue(string key, object value) {
            if( this.frmRootSrv.getDtTpValue(key) == "boolean" ) {
                if(value == null) { this._Values[key] = false; } else { this._Values[key] = value; }
            } else {
                this._Values[key] = value;
            }
        }
        public object getByOrgValue(string org, string fkchain) {
            string i = this.frmRootSrv.getKeyByOrgValue(org, fkchain);
            if(string.IsNullOrEmpty(i)) return null;
            return this._Values[i];
        }
        public void setByOrgValue(string org, string fkchain, object value)  {
            string i = this.frmRootSrv.getKeyByOrgValue(org, fkchain);
            if(!string.IsNullOrEmpty(i)) this._Values[i] = value; 
        }
        public bool requiredValue(string key) {
            return this.frmRootSrv.requiredValue(key);
        }
        public bool dbgeneratedValue(string key) {
            return this.frmRootSrv.dbgeneratedValue(key);
        }
        public bool isInPrimkeyValue(string key) {
            return this.frmRootSrv.isInPrimkeyValue(key);
        }
        public bool isSetValue(string key) {
            if(!this._Values.ContainsKey(key)) return false;
            object v = this._Values[key];
            if (this.requiredValue(key) && (v == null)) return false;
            return true;
        }
        public void clearValue(string key) {
            if( this.frmRootSrv.getDtTpValue(key) == "boolean" ) {
                this._Values[key] = false;
            } else {
                this._Values[key] = null;
            }
        }
        public bool Clear(bool doNotify = true) {
            bool hasChanged = false;
            var keys = this._Values.Keys.ToList();
            foreach(string i in keys) {
                if( this.frmRootSrv.getDtTpValue(i) == "boolean" ) {
                    if ((bool)this._Values[i] != false) hasChanged = true;
                    this._Values[i] = false;
                } else {
                    if (!(this._Values[i] == null)) hasChanged = true;
                    this._Values[i] = null;
                }
            }
            if(!hasChanged) return hasChanged;
            if(doNotify) this.DoEmitEvent(true);
            return hasChanged;
        }
        public bool isEqual(object src, object dest, string dttp) {
            if (src == null) {
                return dest == null;
            }
            if (dest == null) {
                return false;
            }
            switch(dttp) {
                case "int16":
                    return Convert.ToInt16(src) == Convert.ToInt16(dest);
                case "int32":
                    return Convert.ToInt32(src) == Convert.ToInt32(dest);
                case "int64":
                    return Convert.ToInt64(src) == Convert.ToInt64(dest);
                case "uint16":
                    return Convert.ToUInt16(src) == Convert.ToUInt16(dest);
                case "uint32":
                    return Convert.ToUInt32(src) == Convert.ToUInt32(dest);
                case "uint64":
                    return Convert.ToUInt64(src) == Convert.ToUInt64(dest);
                case "double":
                    return Convert.ToDouble(src) == Convert.ToDouble(dest);
                case "decimal":
                    return Convert.ToDecimal(src) == Convert.ToDecimal(dest);
                case "single":
                    return Convert.ToSingle(src) == Convert.ToSingle(dest);
                case "guid":
                    Guid gs,gd;
                    if (Guid.TryParse(Convert.ToString(src), out gs) && Guid.TryParse(Convert.ToString(dest), out gd)) {
                        return (gs == gd);
                    }
                    return false;
                case "date":
                case "datetime":
                    return Convert.ToDateTime(src) == Convert.ToDateTime(dest);
                default:
                    return Convert.ToString(src) == Convert.ToString(dest);
            }
            //return src.Equals(dest);
        }
        public bool Interface2Values(ILpdPhoneView data, bool doNotify = true) {
            if(data == null) {
                return this.Clear(doNotify);
            }
            bool hasChanged  = false;
            bool aftrMstrChngd = false;
            if(!this.isEqual(this.getValue("LpdPhoneId"), data.LpdPhoneId, "int32")) {
                this.setValue("LpdPhoneId", data.LpdPhoneId);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("Phone"), data.Phone, "string")) {
                this.setValue("Phone", data.Phone);
                hasChanged = true;
            }
            if(!hasChanged) return hasChanged;
            if(doNotify) this.DoEmitEvent(aftrMstrChngd);
            return hasChanged;
        }
        public ILpdPhoneView Values2Interface() {
            object locobjval;

            LpdPhoneView rslt = new LpdPhoneView(); 
            locobjval = this.getValue("LpdPhoneId");
            rslt.LpdPhoneId = Convert.ToInt32(locobjval);
            locobjval = this.getValue("Phone");
            if(locobjval is null) {
                rslt.Phone =  null;
            } else {
                rslt.Phone =  locobjval.ToString();
            }
            return rslt;
        }

        public async void SubmitOnDetailChanged(object sender, EventArgs e)  {
            await this.DoSubmitOnDetailChanged(sender);
        }

        public async Task DoSubmitOnDetailChanged(object sender)  {
            IViewModelDataSourceInterface v = sender as IViewModelDataSourceInterface;
            if ((this._ClientViewName == null) || (this._DirectNavigation == null) || (v == null)) return;
            if(v.getCurrentViewName() != this._ClientViewName) return;
            bool clntNtChngd = true;
            Dictionary<(string viewNm, string navNm, string propNm), string> C2mfm = this.frmRootSrv.getC2mfm();
            foreach(var lkey in C2mfm.Keys) {
                if ((lkey.viewNm != this._ClientViewName) || (lkey.navNm != this._DirectNavigation)) continue;
                object src = v.getValue(lkey.propNm);
                object dst = this.getValue(C2mfm[lkey]);
                if (this.isEqual(src, dst, frmRootSrv.getDtTpValue(C2mfm[lkey]))) continue;
                clntNtChngd = false;
                this.setValue(C2mfm[lkey], src);
            }
            if (clntNtChngd) return;
            if (this._ClientViewName == "LprPhone01View") {
                if (this._DirectNavigation == "PhoneDict") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("LpdPhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locLpdPhoneId;
                    locobjval = this.getValue("LpdPhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locLpdPhoneId = Convert.ToInt32(locobjval);
                    }
                        ILpdPhoneView data = await this.frmRootSrv.getone(
                         locLpdPhoneId
                        );
                        if(data == null) {
                            this.Clear(true);
                        } else {
                            this.Interface2Values(data, true);
                        }
                    } else {
                        this.Clear(true);
                    }
                }
            }
            else if (this._ClientViewName == "LprPhone02View") {
                if (this._DirectNavigation == "PhoneDict") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("LpdPhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locLpdPhoneId;
                    locobjval = this.getValue("LpdPhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locLpdPhoneId = Convert.ToInt32(locobjval);
                    }
                        ILpdPhoneView data = await this.frmRootSrv.getone(
                         locLpdPhoneId
                        );
                        if(data == null) {
                            this.Clear(true);
                        } else {
                            this.Interface2Values(data, true);
                        }
                    } else {
                        this.Clear(true);
                    }
                }
            }
            else if (this._ClientViewName == "LprPhone03View") {
                if (this._DirectNavigation == "PhoneDict") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("LpdPhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locLpdPhoneId;
                    locobjval = this.getValue("LpdPhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locLpdPhoneId = Convert.ToInt32(locobjval);
                    }
                        ILpdPhoneView data = await this.frmRootSrv.getone(
                         locLpdPhoneId
                        );
                        if(data == null) {
                            this.Clear(true);
                        } else {
                            this.Interface2Values(data, true);
                        }
                    } else {
                        this.Clear(true);
                    }
                }
            }
            else if (this._ClientViewName == "LprPhone04View") {
                if (this._DirectNavigation == "PhoneDict") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("LpdPhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locLpdPhoneId;
                    locobjval = this.getValue("LpdPhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locLpdPhoneId = Convert.ToInt32(locobjval);
                    }
                        ILpdPhoneView data = await this.frmRootSrv.getone(
                         locLpdPhoneId
                        );
                        if(data == null) {
                            this.Clear(true);
                        } else {
                            this.Interface2Values(data, true);
                        }
                    } else {
                        this.Clear(true);
                    }
                }
            }
        }


        public bool ClearPartially(bool doNotify)  {
            bool hasChanged = false;
            if(!this.isUnderHiddenFilterFields("LpdPhoneId")) {
                if(this.isSetValue("LpdPhoneId")) {
                    this.clearValue("LpdPhoneId");
                    hasChanged = true;
                }
            }
            if(!this.isUnderHiddenFilterFields("Phone")) {
                if(this.isSetValue("Phone")) {
                    this.clearValue("Phone");
                    hasChanged = true;
                }
            }
            if(!hasChanged) return hasChanged;
            if(doNotify) this.DoEmitEvent(false);
            return hasChanged;
        }

        public void SubmitOnMasterChanged(object sender, EventArgs e) {
            this.DoSubmitOnMasterChanged(sender);
        }

        public void DoSubmitOnMasterChanged(object sender) {
            IViewModelDataSourceInterface v = sender as IViewModelDataSourceInterface;
            if(v == null) return;
            string masterDirNav = v.getDirectNavigation();
            string masterClnt = v.getClientViewName();
            if ((masterDirNav == null) || (masterClnt == null)) return;
            if (masterClnt != this.getCurrentViewName()) return;
            bool clntNtChngd = true;
            string masterVw = v.getCurrentViewName();
            Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> M2cKeyfm = this.frmRootSrv.getM2cKeyfm();
            Dictionary<(string viewNm, string navNm, string propNm), string> M2cfm = this.frmRootSrv.getM2cfm();
            foreach(var lkey in M2cKeyfm.Keys) {
                if ((lkey.viewNm != masterVw) || (lkey.navNm != masterDirNav)) continue;
                object src = v.getValue(lkey.propNm);
                object dst = this.getValue(M2cKeyfm[lkey].propNm);
                if (this.isEqual(src, dst, frmRootSrv.getDtTpValue(M2cKeyfm[lkey].propNm))) continue;
                clntNtChngd = false;
                this.setValue(M2cKeyfm[lkey].propNm, src);
            }

            foreach(var kkey in M2cfm.Keys) {
                if ((kkey.viewNm != masterVw) || (kkey.navNm != masterDirNav)) continue;
                object ksrc = v.getValue(kkey.propNm);
                object kdst = this.getValue(M2cfm[kkey]);
                if (this.isEqual(ksrc, kdst, frmRootSrv.getDtTpValue(M2cfm[kkey]))) continue;
                clntNtChngd = false;
                this.setValue(M2cfm[kkey], ksrc);
            }
            if (clntNtChngd) return;
            // clear primary and unique key props of the current ViewModel. Eliminate those associated with the current direct master props.
            if(!this.getIsTopDetail()) {
                this.ClearPartially(false);
            }
            this.DoEmitEvent(true);
        }
        public bool IsSetFilterByCurrDirMstrs()  {
            Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> M2cKeyfm = this.frmRootSrv.getM2cKeyfm();
            foreach(var lkey in M2cKeyfm.Keys) {
                if (M2cKeyfm[lkey].isMstrReq && (!this.isSetValue(M2cKeyfm[lkey].propNm))) return false; 
            }
            return true;
        }
        public IList<IWebServiceFilterRsltInterface> GetWSFltrRsltByCurrDirMstrs() {
            IList<IWebServiceFilterRsltInterface> rslt = new List<IWebServiceFilterRsltInterface>();
            Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> M2cKeyfm = this.frmRootSrv.getM2cKeyfm();
            foreach(var lkey in M2cKeyfm.Keys) {
                if(this._CurrentlyDirectMasterNavs.IndexOf(lkey.propNm) < 0) continue;
                if (this.isSetValue(M2cKeyfm[lkey].propNm)) {
                    rslt.Add(new WebServiceFilterRslt{
                        fltrName = M2cKeyfm[lkey].propNm,
                        fltrDataType = this.getDtTpValue(M2cKeyfm[lkey].propNm),
                        fltrOperator = "eq",
                        fltrValue = this.getValue(M2cKeyfm[lkey].propNm)
                    });

                }
            }
            return rslt;
        }
        protected ILpdPhoneViewFilter DefineFilterOneProp(ILpdPhoneViewFilter flt, string propNm, object value, string Oprtr) {
            if(flt == null) flt = new LpdPhoneViewFilter(); 
            if (string.IsNullOrEmpty(propNm)) return flt;
            if(string.IsNullOrEmpty(Oprtr)) Oprtr = "eq";
            switch(propNm) {
                case "LpdPhoneId":
                    if (value is null) break;
                    if(flt.LpdPhoneId == null) flt.LpdPhoneId = new List<System.Int32>();
                    if(flt.lpdPhoneIdOprtr == null) flt.lpdPhoneIdOprtr = new List< string > ();
                    flt.lpdPhoneIdOprtr.Add(Oprtr);
                    flt.LpdPhoneId.Add(Convert.ToInt32(value));
                    break;
                case "Phone":
                    if(flt.Phone == null) flt.Phone = new List<System.String>();
                    if(flt.phoneOprtr == null) flt.phoneOprtr = new List< string > ();
                    flt.phoneOprtr.Add(Oprtr);
                    if (value is null) {
                        flt.Phone.Add(null);
                    } else {
                        flt.Phone.Add(value.ToString());
                    }
                    break;
            }
            return flt;
        }
        protected ILpdPhoneViewFilter GetFilterByCurrDirMstrs() {
            ILpdPhoneViewFilter flt = new LpdPhoneViewFilter(); 
            Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> M2cKeyfm = this.frmRootSrv.getM2cKeyfm();
            foreach(var lkey in M2cKeyfm.Keys) {
                if (this.isSetValue(M2cKeyfm[lkey].propNm)) {
                    this.DefineFilterOneProp(flt, M2cKeyfm[lkey].propNm, this.getValue(M2cKeyfm[lkey].propNm), "eq");
                }
            }
            return flt;
        }

        // add input string to define flt.orderby prop
        public async Task<IList<ILpdPhoneView>> GetClActionByCurrDirMstrs() {
            if (!this.IsSetFilterByCurrDirMstrs()) {
                return new List<ILpdPhoneView>();
            }
            ILpdPhoneViewPage prslt = await this.frmRootSrv.getwithfilter(this.GetFilterByCurrDirMstrs());
            if(prslt == null) {
                return new List<ILpdPhoneView>();
            }
            if(prslt.items == null) {
                return new List<ILpdPhoneView>();
            }
            return prslt.items;
        }



        public async Task<IList<ILpdPhoneView>> GetClActionByFldFilter(string fldName, object fldVal) {
            if((fldVal == null) || (string.IsNullOrEmpty(fldName))) {
                return await this.GetClActionByCurrDirMstrs();
            }
            if (!this.IsSetFilterByCurrDirMstrs()) {
                return new List<ILpdPhoneView>();
            }
            ILpdPhoneViewFilter flt = this.GetFilterByCurrDirMstrs();
            this.DefineFilterOneProp(flt, fldName, fldVal, "lk");
            if (flt.orderby == null) flt.orderby = new List<string>();
            flt.orderby.Add(fldName);
            ILpdPhoneViewPage prslt = await this.frmRootSrv.getwithfilter(flt);
            if(prslt == null) {
                return new List<ILpdPhoneView>();
            }
            if(prslt.items == null) {
                return new List<ILpdPhoneView>();
            }
            return prslt.items;
        }





        public async Task getone(
                  System.Int32 LpdPhoneId
        ) {
            ILpdPhoneView data = await this.frmRootSrv.getone(
                  LpdPhoneId
            );
            if(data != null) {
                if(!this.Interface2Values(data, true)) {
                    this.DoEmitEvent(true);
                }
            }
        }
        public async Task getonebyLpdPhoneUK(
                  System.String Phone
        ) {
            ILpdPhoneView data = await this.frmRootSrv.getonebyLpdPhoneUK(
                  Phone
            );
            if(data != null) {
                if(!this.Interface2Values(data, true)) {
                    this.DoEmitEvent(true);
                }
            }
        }


        public async Task Refresh() {
            object locobjval;
            if (
                    this.isSetValue("LpdPhoneId")
            ) {
  
                System.Int32  locLpdPhoneId;
                locobjval = this.getValue("LpdPhoneId"); 
                if(locobjval is null) {
                    appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                    return;
                } else {
                    locLpdPhoneId = Convert.ToInt32(locobjval);
                }
                await this.getone(
                      locLpdPhoneId
                );
                return;
            }
            if (
                    this.isSetValue("Phone")
            ) {
  
                System.String  locPhone;
                locobjval = this.getValue("Phone"); 
                if(locobjval is null) {
                    appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                    return;
                } else {
                    locPhone = locobjval.ToString();
                }
                await this.getonebyLpdPhoneUK(
                      locPhone
                );
                return;
            }
            appGlblSettings.ShowErrorMessage("http", "Not all Unique or Primary key properties are defined to call Refresh-method");
        }

        public async Task updateone() {
            if(!this.getIsDefined()) {
                appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                return;
            }
            ILpdPhoneView itm = this.Values2Interface();
            ILpdPhoneView data = await this.frmRootSrv.updateone(itm);
            if(data != null) {
                this.Interface2Values(data, false);
                this.OnUpdate?.Invoke(this,new EventArgs());
            }
        }




        public async Task addone() {
            if(!this.getIsDefined()) {
                appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                return;
            }
            ILpdPhoneView itm = this.Values2Interface();
            ILpdPhoneView data = await this.frmRootSrv.addone(itm);
            if(data != null) {
                this.Interface2Values(data, false);
                this.OnAdd?.Invoke(this,new EventArgs());
            }
        }




        public async Task deleteone() {
            if(!this.getIsDefined()) {
                appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                return;
            }
            object locobjval;
  
            System.Int32  locLpdPhoneId;
            locobjval = this.getValue("LpdPhoneId"); 
            if(locobjval is null) {
                appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                return;
            } else {
                locLpdPhoneId = Convert.ToInt32(locobjval);
            }

            ILpdPhoneView data = await this.frmRootSrv.deleteone(  locLpdPhoneId );
            if(data != null) {
                this.Interface2Values(data, false);
                this.OnDelete?.Invoke(this,new EventArgs());
            }


        }
        protected void setUnderHiddenFilterFields() {
            this._UnderHiddenFilterFields = new List<string>();
            Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)>  M2cKeyfm = this.frmRootSrv.getM2cKeyfm();
            Dictionary<(string viewNm, string navNm, string propNm), string> M2cfm = this.frmRootSrv.getM2cfm();
            if(this._HiddenFilter == null) return;
            foreach(var hkey in this._HiddenFilter.Keys) {
                foreach(var kkey in M2cKeyfm.Keys) {
                    if ((hkey.viewNm == kkey.viewNm) && (hkey.navNm == kkey.navNm)) {
                        string pNm = M2cKeyfm[kkey].propNm;
                        if(!this._UnderHiddenFilterFields.Any(s => s == pNm))
                            this._UnderHiddenFilterFields.Add(pNm);
                    }
                }
                foreach(var fkey in M2cfm.Keys) {
                    if ((hkey.viewNm == fkey.viewNm) && (hkey.navNm == fkey.navNm)) {
                        string pNm = M2cfm[fkey];
                        if(!this._UnderHiddenFilterFields.Any(s => s == pNm))
                            this._UnderHiddenFilterFields.Add(pNm);
                    }
                }
            }
        }
        public bool isUnderHiddenFilterFields(string fld) {
            if(string.IsNullOrEmpty(fld)) return false;
            return this._UnderHiddenFilterFields.IndexOf(fld) > -1;
        }
        public bool UpdateByHiddenFilterFields(bool doNotify = true) {
            bool hasChanged = false;
            bool aftrMstrChngd = false;
            if(this._HiddenFilter == null) return hasChanged;
            Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> M2cKeyfm = this.frmRootSrv.getM2cKeyfm();
            foreach(var hkey in this._HiddenFilter.Keys) {
                if(M2cKeyfm.ContainsKey(hkey)) {
                    object src = this._HiddenFilter[hkey];
                    object dest = this.getValue(M2cKeyfm[hkey].propNm);
                    if (!this.isEqual(src, dest, frmRootSrv.getDtTpValue(M2cKeyfm[hkey].propNm))) {
                        this.setValue(M2cKeyfm[hkey].propNm, src);
                        aftrMstrChngd = (this._CurrentlyDirectMasterNavs.IndexOf(hkey.navNm) >= 0) || aftrMstrChngd;
                        hasChanged = true;
                    }
                }
            }
            if(!hasChanged) return hasChanged;
            if(doNotify) this.DoEmitEvent(aftrMstrChngd);
            return hasChanged;
        }
        public bool getIsNew() {
            return this._IsNew;
        }
        public void setIsNew(bool v) {
            this._IsNew = v;
        }
        public bool isReadonlyValue(string key) {
            bool rslt = this.dbgeneratedValue(key);
            if(!rslt) rslt = this.isUnderHiddenFilterFields(key);
            if ((!rslt) && (!this.getIsNew())) {
                rslt = this.frmRootSrv.isInPrimkeyValue(key);
            }
            return rslt;
        }


    }
}


