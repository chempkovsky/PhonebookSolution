using System;
using System.Text;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Linq;

using ModelInterfacesClassLibrary.Phonebook.PhbkPhone;
using CommonInterfacesClassLibrary.AppGlblSettingsSrvc;
using CommonInterfacesClassLibrary.Interfaces;
using CommonUserControlLibrary.Classes;

/*
    In the file of IModule-class of the project for the current service the following lines of code must be inserted:

        public void RegisterTypes(IContainerRegistry containerRegistry)
        {
            ...
            containerRegistry.Register<IPhbkPhoneViewDatasource, PhbkPhoneViewDatasource>();
            ...
        }

*/
namespace ModelServicesPrismModule.Phonebook.PhbkPhone {
    public class PhbkPhoneViewDatasource: IPhbkPhoneViewDatasource
    {
        protected readonly string _CurrentViewName   = "PhbkPhoneView";
        protected string _ClientViewName = null;
        protected string _DirectNavigation = null;
        protected bool _IsDefined = false;
        protected IList<string> _CurrentlyDirectMasterNavs = new List<string>();
        protected Dictionary<(string viewNm, string navNm, string propNm), object> _HiddenFilter = new Dictionary<(string viewNm, string navNm, string propNm), object>();
        protected IList<string> _UnderHiddenFilterFields  = new List<string>();
        protected bool _IsNew = true;
        protected string _UIFormChain  = "";
        protected Dictionary<string,object> _Values = new Dictionary<string,object> {
            {"PhoneId", null},  // System.Int32
            {"Phone", null},  // System.String
            {"PhoneTypeIdRef", null},  // System.Int32
            {"EmployeeIdRef", null},  // System.Int32
            {"PPhoneTypeName", null},  // System.String
            {"EEmpFirstName", null},  // System.String
            {"EEmpLastName", null},  // System.String
            {"EEmpSecondName", null},  // System.String
            {"EDDivisionName", null},  // System.String
            {"EDEEntrprsName", null},  // System.String
        };
        protected IPhbkPhoneViewService frmRootSrv;
        protected IAppGlblSettingsService appGlblSettings;

        public PhbkPhoneViewDatasource(IPhbkPhoneViewService frs,
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
        public Dictionary<(string viewNm, string navNm, string propNm), object>  getHiddenFilterByRow(IPhbkPhoneView rw, string nvNm) {
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
        public bool Interface2Values(IPhbkPhoneView data, bool doNotify = true) {
            if(data == null) {
                return this.Clear(doNotify);
            }
            bool hasChanged  = false;
            bool aftrMstrChngd = false;
            if(!this.isEqual(this.getValue("PhoneId"), data.PhoneId, "int32")) {
                this.setValue("PhoneId", data.PhoneId);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("Phone"), data.Phone, "string")) {
                this.setValue("Phone", data.Phone);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("PhoneTypeIdRef"), data.PhoneTypeIdRef, "int32")) {
                this.setValue("PhoneTypeIdRef", data.PhoneTypeIdRef);
                aftrMstrChngd = (this._CurrentlyDirectMasterNavs.IndexOf("PhoneType") >= 0) || aftrMstrChngd;
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("EmployeeIdRef"), data.EmployeeIdRef, "int32")) {
                this.setValue("EmployeeIdRef", data.EmployeeIdRef);
                aftrMstrChngd = (this._CurrentlyDirectMasterNavs.IndexOf("Employee") >= 0) || aftrMstrChngd;
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("PPhoneTypeName"), data.PPhoneTypeName, "string")) {
                this.setValue("PPhoneTypeName", data.PPhoneTypeName);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("EEmpFirstName"), data.EEmpFirstName, "string")) {
                this.setValue("EEmpFirstName", data.EEmpFirstName);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("EEmpLastName"), data.EEmpLastName, "string")) {
                this.setValue("EEmpLastName", data.EEmpLastName);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("EEmpSecondName"), data.EEmpSecondName, "string")) {
                this.setValue("EEmpSecondName", data.EEmpSecondName);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("EDDivisionName"), data.EDDivisionName, "string")) {
                this.setValue("EDDivisionName", data.EDDivisionName);
                hasChanged = true;
            }
            if(!this.isEqual(this.getValue("EDEEntrprsName"), data.EDEEntrprsName, "string")) {
                this.setValue("EDEEntrprsName", data.EDEEntrprsName);
                hasChanged = true;
            }
            if(!hasChanged) return hasChanged;
            if(doNotify) this.DoEmitEvent(aftrMstrChngd);
            return hasChanged;
        }
        public IPhbkPhoneView Values2Interface() {
            object locobjval;

            PhbkPhoneView rslt = new PhbkPhoneView(); 
            locobjval = this.getValue("PhoneId");
            rslt.PhoneId = Convert.ToInt32(locobjval);
            locobjval = this.getValue("Phone");
            if(locobjval is null) {
                rslt.Phone =  null;
            } else {
                rslt.Phone =  locobjval.ToString();
            }
            locobjval = this.getValue("PhoneTypeIdRef");
            rslt.PhoneTypeIdRef = Convert.ToInt32(locobjval);
            locobjval = this.getValue("EmployeeIdRef");
            rslt.EmployeeIdRef = Convert.ToInt32(locobjval);
            locobjval = this.getValue("PPhoneTypeName");
            if(locobjval is null) {
                rslt.PPhoneTypeName =  null;
            } else {
                rslt.PPhoneTypeName =  locobjval.ToString();
            }
            locobjval = this.getValue("EEmpFirstName");
            if(locobjval is null) {
                rslt.EEmpFirstName =  null;
            } else {
                rslt.EEmpFirstName =  locobjval.ToString();
            }
            locobjval = this.getValue("EEmpLastName");
            if(locobjval is null) {
                rslt.EEmpLastName =  null;
            } else {
                rslt.EEmpLastName =  locobjval.ToString();
            }
            locobjval = this.getValue("EEmpSecondName");
            if(locobjval is null) {
                rslt.EEmpSecondName =  null;
            } else {
                rslt.EEmpSecondName =  locobjval.ToString();
            }
            locobjval = this.getValue("EDDivisionName");
            if(locobjval is null) {
                rslt.EDDivisionName =  null;
            } else {
                rslt.EDDivisionName =  locobjval.ToString();
            }
            locobjval = this.getValue("EDEEntrprsName");
            if(locobjval is null) {
                rslt.EDEEntrprsName =  null;
            } else {
                rslt.EDEEntrprsName =  locobjval.ToString();
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
                if (this._DirectNavigation == "Phone") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("PhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locPhoneId;
                    locobjval = this.getValue("PhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locPhoneId = Convert.ToInt32(locobjval);
                    }
                        IPhbkPhoneView data = await this.frmRootSrv.getone(
                         locPhoneId
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
                if (this._DirectNavigation == "Phone") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("PhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locPhoneId;
                    locobjval = this.getValue("PhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locPhoneId = Convert.ToInt32(locobjval);
                    }
                        IPhbkPhoneView data = await this.frmRootSrv.getone(
                         locPhoneId
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
                if (this._DirectNavigation == "Phone") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("PhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locPhoneId;
                    locobjval = this.getValue("PhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locPhoneId = Convert.ToInt32(locobjval);
                    }
                        IPhbkPhoneView data = await this.frmRootSrv.getone(
                         locPhoneId
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
                if (this._DirectNavigation == "Phone") {
                    bool isKeyCrrct = true;
                    object dtFrTst;
                    if(isKeyCrrct) {
                        dtFrTst = this.getValue("PhoneId");
                        if (dtFrTst == null) {
                            isKeyCrrct = false;
                        }
                    }
                    if(isKeyCrrct) {
                        object locobjval;
  

  
                    System.Int32  locPhoneId;
                    locobjval = this.getValue("PhoneId"); 
                    if(locobjval is null) {
                        appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                        return;
                    } else {
                        locPhoneId = Convert.ToInt32(locobjval);
                    }
                        IPhbkPhoneView data = await this.frmRootSrv.getone(
                         locPhoneId
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
            if(!this.isUnderHiddenFilterFields("PhoneId")) {
                if(this.isSetValue("PhoneId")) {
                    this.clearValue("PhoneId");
                    hasChanged = true;
                }
            }
            if(!this.isUnderHiddenFilterFields("Phone")) {
                if(this.isSetValue("Phone")) {
                    this.clearValue("Phone");
                    hasChanged = true;
                }
            }
            if(!this.isUnderHiddenFilterFields("PhoneTypeIdRef")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf("PhoneType") < 0) {
                    if(this.isSetValue("PhoneTypeIdRef")) {
                        this.clearValue("PhoneTypeIdRef");
                        hasChanged = true;
                    }
                }
            }
            if(!this.isUnderHiddenFilterFields("EmployeeIdRef")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf("Employee") < 0) {
                    if(this.isSetValue("EmployeeIdRef")) {
                        this.clearValue("EmployeeIdRef");
                        hasChanged = true;
                    }
                }
            }
            if(!this.isUnderHiddenFilterFields("PPhoneTypeName")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf(this.frmRootSrv.getFkValue("PPhoneTypeName")) < 0) {
                    if(this.isSetValue("PPhoneTypeName")) {
                        this.clearValue("PPhoneTypeName");
                        hasChanged = true;
                    }
                }
            }
            if(!this.isUnderHiddenFilterFields("EEmpFirstName")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf(this.frmRootSrv.getFkValue("EEmpFirstName")) < 0) {
                    if(this.isSetValue("EEmpFirstName")) {
                        this.clearValue("EEmpFirstName");
                        hasChanged = true;
                    }
                }
            }
            if(!this.isUnderHiddenFilterFields("EEmpLastName")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf(this.frmRootSrv.getFkValue("EEmpLastName")) < 0) {
                    if(this.isSetValue("EEmpLastName")) {
                        this.clearValue("EEmpLastName");
                        hasChanged = true;
                    }
                }
            }
            if(!this.isUnderHiddenFilterFields("EEmpSecondName")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf(this.frmRootSrv.getFkValue("EEmpSecondName")) < 0) {
                    if(this.isSetValue("EEmpSecondName")) {
                        this.clearValue("EEmpSecondName");
                        hasChanged = true;
                    }
                }
            }
            if(!this.isUnderHiddenFilterFields("EDDivisionName")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf(this.frmRootSrv.getFkValue("EDDivisionName")) < 0) {
                    if(this.isSetValue("EDDivisionName")) {
                        this.clearValue("EDDivisionName");
                        hasChanged = true;
                    }
                }
            }
            if(!this.isUnderHiddenFilterFields("EDEEntrprsName")) {
                if(this._CurrentlyDirectMasterNavs.IndexOf(this.frmRootSrv.getFkValue("EDEEntrprsName")) < 0) {
                    if(this.isSetValue("EDEEntrprsName")) {
                        this.clearValue("EDEEntrprsName");
                        hasChanged = true;
                    }
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
        protected IPhbkPhoneViewFilter DefineFilterOneProp(IPhbkPhoneViewFilter flt, string propNm, object value, string Oprtr) {
            if(flt == null) flt = new PhbkPhoneViewFilter(); 
            if (string.IsNullOrEmpty(propNm)) return flt;
            if(string.IsNullOrEmpty(Oprtr)) Oprtr = "eq";
            switch(propNm) {
                case "PhoneId":
                    if (value is null) break;
                    if(flt.PhoneId == null) flt.PhoneId = new List<System.Int32>();
                    if(flt.phoneIdOprtr == null) flt.phoneIdOprtr = new List< string > ();
                    flt.phoneIdOprtr.Add(Oprtr);
                    flt.PhoneId.Add(Convert.ToInt32(value));
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
                case "PhoneTypeIdRef":
                    if (value is null) break;
                    if(flt.PhoneTypeIdRef == null) flt.PhoneTypeIdRef = new List<System.Int32>();
                    if(flt.phoneTypeIdRefOprtr == null) flt.phoneTypeIdRefOprtr = new List< string > ();
                    flt.phoneTypeIdRefOprtr.Add(Oprtr);
                    flt.PhoneTypeIdRef.Add(Convert.ToInt32(value));
                    break;
                case "EmployeeIdRef":
                    if (value is null) break;
                    if(flt.EmployeeIdRef == null) flt.EmployeeIdRef = new List<System.Int32>();
                    if(flt.employeeIdRefOprtr == null) flt.employeeIdRefOprtr = new List< string > ();
                    flt.employeeIdRefOprtr.Add(Oprtr);
                    flt.EmployeeIdRef.Add(Convert.ToInt32(value));
                    break;
            }
            return flt;
        }
        protected IPhbkPhoneViewFilter GetFilterByCurrDirMstrs() {
            IPhbkPhoneViewFilter flt = new PhbkPhoneViewFilter(); 
            Dictionary<(string viewNm, string navNm, string propNm), (bool isMstrReq, string propNm)> M2cKeyfm = this.frmRootSrv.getM2cKeyfm();
            foreach(var lkey in M2cKeyfm.Keys) {
                if (this.isSetValue(M2cKeyfm[lkey].propNm)) {
                    this.DefineFilterOneProp(flt, M2cKeyfm[lkey].propNm, this.getValue(M2cKeyfm[lkey].propNm), "eq");
                }
            }
            return flt;
        }

        // add input string to define flt.orderby prop
        public async Task<IList<IPhbkPhoneView>> GetClActionByCurrDirMstrs() {
            if (!this.IsSetFilterByCurrDirMstrs()) {
                return new List<IPhbkPhoneView>();
            }
            IPhbkPhoneViewPage prslt = await this.frmRootSrv.getwithfilter(this.GetFilterByCurrDirMstrs());
            if(prslt == null) {
                return new List<IPhbkPhoneView>();
            }
            if(prslt.items == null) {
                return new List<IPhbkPhoneView>();
            }
            return prslt.items;
        }



        public async Task<IList<IPhbkPhoneView>> GetClActionByFldFilter(string fldName, object fldVal) {
            if((fldVal == null) || (string.IsNullOrEmpty(fldName))) {
                return await this.GetClActionByCurrDirMstrs();
            }
            if (!this.IsSetFilterByCurrDirMstrs()) {
                return new List<IPhbkPhoneView>();
            }
            IPhbkPhoneViewFilter flt = this.GetFilterByCurrDirMstrs();
            this.DefineFilterOneProp(flt, fldName, fldVal, "lk");
            if (flt.orderby == null) flt.orderby = new List<string>();
            flt.orderby.Add(fldName);
            IPhbkPhoneViewPage prslt = await this.frmRootSrv.getwithfilter(flt);
            if(prslt == null) {
                return new List<IPhbkPhoneView>();
            }
            if(prslt.items == null) {
                return new List<IPhbkPhoneView>();
            }
            return prslt.items;
        }





        public async Task getone(
                  System.Int32 PhoneId
        ) {
            IPhbkPhoneView data = await this.frmRootSrv.getone(
                  PhoneId
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
                    this.isSetValue("PhoneId")
            ) {
  
                System.Int32  locPhoneId;
                locobjval = this.getValue("PhoneId"); 
                if(locobjval is null) {
                    appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                    return;
                } else {
                    locPhoneId = Convert.ToInt32(locobjval);
                }
                await this.getone(
                      locPhoneId
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
            IPhbkPhoneView itm = this.Values2Interface();
            IPhbkPhoneView data = await this.frmRootSrv.updateone(itm);
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
            IPhbkPhoneView itm = this.Values2Interface();
            IPhbkPhoneView data = await this.frmRootSrv.addone(itm);
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
  
            System.Int32  locPhoneId;
            locobjval = this.getValue("PhoneId"); 
            if(locobjval is null) {
                appGlblSettings.ShowErrorMessage("http", "Not all propertes are correctly defined");
                return;
            } else {
                locPhoneId = Convert.ToInt32(locobjval);
            }

            IPhbkPhoneView data = await this.frmRootSrv.deleteone(  locPhoneId );
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


