#nullable disable
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


using LpPhBkContext.PhBk;
using PhBkViews.PhBk;
using LpPhBkViews.PhBk;


using LpPhBkEntity.PhBk;


namespace LpPhBkControllers.Helpers {


    public static class M2mUpdaterPhbkPhoneView {
        public static async Task<LpdPhone> SelDictItemForLpdPhoneView(LpPhnPhBkContext db, IPhbkPhoneViewExtForLkUp vm) {
            IQueryable<LpdPhone> query = db.LpdPhoneDbSet;
// "It Skipped" Info: for scalar prop = [LpdPhoneId] of searchVM = [LpdPhoneView] could not find mapped Unique Key property of the Entity = [LpdPhone]
            // maybe it requires additional code related to nullable values
            query = query.Where(p => p.Phone == vm.Phone);
            LpdPhone rslt = await query.FirstOrDefaultAsync();
            if(rslt != null) db.Entry(rslt).State = EntityState.Detached;
            return rslt;
        }
        public static async Task<LpdPhone> InsDictItemForLpdPhoneView(LpPhnPhBkContext db, IPhbkPhoneViewExtForLkUp vm) {
            LpdPhone entityToAdd = new LpdPhone();
// "It Skipped" Info: scalar prop = [LpdPhoneId] of searchVM = [LpdPhoneView] is in primary key. Pay special attention if it should be defined with your special value. For instance, Guid.NewGuid().ToString("N");
//         entityToAdd.LpdPhoneId = // Guid.NewGuid().ToString("N");
            entityToAdd.Phone = vm.Phone; // scalar prop names are identical
// pay special attention to primKey values

            db.LpdPhoneDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();
            db.Entry(entityToAdd).State = EntityState.Detached;
            return entityToAdd;
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprPhone01View(LpPhnPhBkContext db, int action, IPhbkPhoneViewExtForLkUp oldObj, IPhbkPhoneViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprPhone01 LprPhone01ViewupdDelTmp = new LprPhone01() {
                    PhoneId = oldObj.PhoneId
                }; // LprPhone01ViewupdDelTmp
                if(readyToDel) {
                    LpdPhone LpdPhoneViewupdDelTmp = await SelDictItemForLpdPhoneView(db, oldObj);
                    readyToDel = LpdPhoneViewupdDelTmp == null;
                    if(readyToDel) {
                    LprPhone01ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewupdDelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone01> m2mDelQuery = db.LprPhone01DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.PhoneId == LprPhone01ViewupdDelTmp.PhoneId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone01ViewupdDelTmp.LpdPhoneIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprPhone01DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprPhone01 LprPhone01ViewInsTmp = new LprPhone01() {
                    PhoneId = newObj.PhoneId
                }; // LprPhone01ViewInsTmp
                LpdPhone LpdPhoneViewInsTmp = await SelDictItemForLpdPhoneView(db, newObj);
                if(LpdPhoneViewInsTmp == null) {
                    LpdPhoneViewInsTmp = await InsDictItemForLpdPhoneView(db, newObj);
                }
                LprPhone01ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone01> m2mInsQuery = db.LprPhone01DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.PhoneId == LprPhone01ViewInsTmp.PhoneId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone01ViewInsTmp.LpdPhoneIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprPhone01DbSet.Add(LprPhone01ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprPhone01ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprPhone02View(LpPhnPhBkContext db, int action, IPhbkPhoneViewExtForLkUp oldObj, IPhbkPhoneViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprPhone02 LprPhone02ViewupdDelTmp = new LprPhone02() {
                    PhoneId = oldObj.PhoneId,
                    EmployeeIdRef = oldObj.EmployeeIdRef,
                }; // LprPhone02ViewupdDelTmp
                if(readyToDel) {
                    LpdPhone LpdPhoneViewupdDelTmp = await SelDictItemForLpdPhoneView(db, oldObj);
                    readyToDel = LpdPhoneViewupdDelTmp == null;
                    if(readyToDel) {
                    LprPhone02ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewupdDelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone02> m2mDelQuery = db.LprPhone02DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.PhoneId == LprPhone02ViewupdDelTmp.PhoneId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone02ViewupdDelTmp.LpdPhoneIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmployeeIdRef == LprPhone02ViewupdDelTmp.EmployeeIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprPhone02DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprPhone02 LprPhone02ViewInsTmp = new LprPhone02() {
                    PhoneId = newObj.PhoneId,
                    EmployeeIdRef = newObj.EmployeeIdRef,
                }; // LprPhone02ViewInsTmp
                LpdPhone LpdPhoneViewInsTmp = await SelDictItemForLpdPhoneView(db, newObj);
                if(LpdPhoneViewInsTmp == null) {
                    LpdPhoneViewInsTmp = await InsDictItemForLpdPhoneView(db, newObj);
                }
                LprPhone02ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone02> m2mInsQuery = db.LprPhone02DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.PhoneId == LprPhone02ViewInsTmp.PhoneId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone02ViewInsTmp.LpdPhoneIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmployeeIdRef == LprPhone02ViewInsTmp.EmployeeIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprPhone02DbSet.Add(LprPhone02ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprPhone02ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprPhone03View(LpPhnPhBkContext db, int action, IPhbkPhoneViewExtForLkUp oldObj, IPhbkPhoneViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprPhone03 LprPhone03ViewupdDelTmp = new LprPhone03() {
                    PhoneId = oldObj.PhoneId,
                    PhoneTypeIdRef = oldObj.PhoneTypeIdRef,
                }; // LprPhone03ViewupdDelTmp
                if(readyToDel) {
                    LpdPhone LpdPhoneViewupdDelTmp = await SelDictItemForLpdPhoneView(db, oldObj);
                    readyToDel = LpdPhoneViewupdDelTmp == null;
                    if(readyToDel) {
                    LprPhone03ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewupdDelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone03> m2mDelQuery = db.LprPhone03DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.PhoneId == LprPhone03ViewupdDelTmp.PhoneId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone03ViewupdDelTmp.LpdPhoneIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.PhoneTypeIdRef == LprPhone03ViewupdDelTmp.PhoneTypeIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprPhone03DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprPhone03 LprPhone03ViewInsTmp = new LprPhone03() {
                    PhoneId = newObj.PhoneId,
                    PhoneTypeIdRef = newObj.PhoneTypeIdRef,
                }; // LprPhone03ViewInsTmp
                LpdPhone LpdPhoneViewInsTmp = await SelDictItemForLpdPhoneView(db, newObj);
                if(LpdPhoneViewInsTmp == null) {
                    LpdPhoneViewInsTmp = await InsDictItemForLpdPhoneView(db, newObj);
                }
                LprPhone03ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone03> m2mInsQuery = db.LprPhone03DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.PhoneId == LprPhone03ViewInsTmp.PhoneId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone03ViewInsTmp.LpdPhoneIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.PhoneTypeIdRef == LprPhone03ViewInsTmp.PhoneTypeIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprPhone03DbSet.Add(LprPhone03ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprPhone03ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprPhone04View(LpPhnPhBkContext db, int action, IPhbkPhoneViewExtForLkUp oldObj, IPhbkPhoneViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprPhone04 LprPhone04ViewupdDelTmp = new LprPhone04() {
                    PhoneId = oldObj.PhoneId,
                    EmployeeIdRef = oldObj.EmployeeIdRef,
                    PhoneTypeIdRef = oldObj.PhoneTypeIdRef,
                }; // LprPhone04ViewupdDelTmp
                if(readyToDel) {
                    LpdPhone LpdPhoneViewupdDelTmp = await SelDictItemForLpdPhoneView(db, oldObj);
                    readyToDel = LpdPhoneViewupdDelTmp == null;
                    if(readyToDel) {
                    LprPhone04ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewupdDelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone04> m2mDelQuery = db.LprPhone04DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.PhoneId == LprPhone04ViewupdDelTmp.PhoneId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone04ViewupdDelTmp.LpdPhoneIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmployeeIdRef == LprPhone04ViewupdDelTmp.EmployeeIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.PhoneTypeIdRef == LprPhone04ViewupdDelTmp.PhoneTypeIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprPhone04DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprPhone04 LprPhone04ViewInsTmp = new LprPhone04() {
                    PhoneId = newObj.PhoneId,
                    EmployeeIdRef = newObj.EmployeeIdRef,
                    PhoneTypeIdRef = newObj.PhoneTypeIdRef,
                }; // LprPhone04ViewInsTmp
                LpdPhone LpdPhoneViewInsTmp = await SelDictItemForLpdPhoneView(db, newObj);
                if(LpdPhoneViewInsTmp == null) {
                    LpdPhoneViewInsTmp = await InsDictItemForLpdPhoneView(db, newObj);
                }
                LprPhone04ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone04> m2mInsQuery = db.LprPhone04DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.PhoneId == LprPhone04ViewInsTmp.PhoneId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone04ViewInsTmp.LpdPhoneIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmployeeIdRef == LprPhone04ViewInsTmp.EmployeeIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.PhoneTypeIdRef == LprPhone04ViewInsTmp.PhoneTypeIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprPhone04DbSet.Add(LprPhone04ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprPhone04ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForPhbkPhoneView(LpPhnPhBkContext db, int action, IPhbkPhoneViewExtForLkUp oldObj, IPhbkPhoneViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 3 - delete; 2 - update
            if ((action == 3) || (action == 2)) {
                bool readyToDel = true;
                LprPhone01 LprPhone01ViewupdDelTmp = new LprPhone01() {
                    PhoneId = oldObj.PhoneId
                }; // LprPhone01ViewupdDelTmp
                LpdPhone LpdPhoneViewdelTmp = await SelDictItemForLpdPhoneView(db, oldObj);
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdPhoneViewdelTmp != null;

                    if(readyToDel) {
                        LprPhone01ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewdelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone01> LprPhone01ViewDelQuery = db.LprPhone01DbSet;
                    LprPhone01ViewDelQuery = LprPhone01ViewDelQuery.Where(p=> p.PhoneId == LprPhone01ViewupdDelTmp.PhoneId);
                    LprPhone01ViewDelQuery = LprPhone01ViewDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone01ViewupdDelTmp.LpdPhoneIdRef);
                
                    var LprPhone01ViewDelRslt = await LprPhone01ViewDelQuery.FirstOrDefaultAsync();
                    if(LprPhone01ViewDelRslt != null) {
                        db.LprPhone01DbSet.Remove(LprPhone01ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprPhone01ViewDelRslt).State = EntityState.Detached;
                    }
                }
                LprPhone02 LprPhone02ViewupdDelTmp = new LprPhone02() {
                    PhoneId = oldObj.PhoneId,
                    EmployeeIdRef = oldObj.EmployeeIdRef,
                }; // LprPhone02ViewupdDelTmp
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdPhoneViewdelTmp != null;

                    if(readyToDel) {
                        LprPhone02ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewdelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone02> LprPhone02ViewDelQuery = db.LprPhone02DbSet;
                    LprPhone02ViewDelQuery = LprPhone02ViewDelQuery.Where(p=> p.PhoneId == LprPhone02ViewupdDelTmp.PhoneId);
                    LprPhone02ViewDelQuery = LprPhone02ViewDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone02ViewupdDelTmp.LpdPhoneIdRef);
                    LprPhone02ViewDelQuery = LprPhone02ViewDelQuery.Where(p=> p.EmployeeIdRef == LprPhone02ViewupdDelTmp.EmployeeIdRef);
                
                    var LprPhone02ViewDelRslt = await LprPhone02ViewDelQuery.FirstOrDefaultAsync();
                    if(LprPhone02ViewDelRslt != null) {
                        db.LprPhone02DbSet.Remove(LprPhone02ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprPhone02ViewDelRslt).State = EntityState.Detached;
                    }
                }
                LprPhone03 LprPhone03ViewupdDelTmp = new LprPhone03() {
                    PhoneId = oldObj.PhoneId,
                    PhoneTypeIdRef = oldObj.PhoneTypeIdRef,
                }; // LprPhone03ViewupdDelTmp
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdPhoneViewdelTmp != null;

                    if(readyToDel) {
                        LprPhone03ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewdelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone03> LprPhone03ViewDelQuery = db.LprPhone03DbSet;
                    LprPhone03ViewDelQuery = LprPhone03ViewDelQuery.Where(p=> p.PhoneId == LprPhone03ViewupdDelTmp.PhoneId);
                    LprPhone03ViewDelQuery = LprPhone03ViewDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone03ViewupdDelTmp.LpdPhoneIdRef);
                    LprPhone03ViewDelQuery = LprPhone03ViewDelQuery.Where(p=> p.PhoneTypeIdRef == LprPhone03ViewupdDelTmp.PhoneTypeIdRef);
                
                    var LprPhone03ViewDelRslt = await LprPhone03ViewDelQuery.FirstOrDefaultAsync();
                    if(LprPhone03ViewDelRslt != null) {
                        db.LprPhone03DbSet.Remove(LprPhone03ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprPhone03ViewDelRslt).State = EntityState.Detached;
                    }
                }
                LprPhone04 LprPhone04ViewupdDelTmp = new LprPhone04() {
                    PhoneId = oldObj.PhoneId,
                    EmployeeIdRef = oldObj.EmployeeIdRef,
                    PhoneTypeIdRef = oldObj.PhoneTypeIdRef,
                }; // LprPhone04ViewupdDelTmp
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdPhoneViewdelTmp != null;

                    if(readyToDel) {
                        LprPhone04ViewupdDelTmp.LpdPhoneIdRef = LpdPhoneViewdelTmp.LpdPhoneId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprPhone04> LprPhone04ViewDelQuery = db.LprPhone04DbSet;
                    LprPhone04ViewDelQuery = LprPhone04ViewDelQuery.Where(p=> p.PhoneId == LprPhone04ViewupdDelTmp.PhoneId);
                    LprPhone04ViewDelQuery = LprPhone04ViewDelQuery.Where(p=> p.LpdPhoneIdRef == LprPhone04ViewupdDelTmp.LpdPhoneIdRef);
                    LprPhone04ViewDelQuery = LprPhone04ViewDelQuery.Where(p=> p.EmployeeIdRef == LprPhone04ViewupdDelTmp.EmployeeIdRef);
                    LprPhone04ViewDelQuery = LprPhone04ViewDelQuery.Where(p=> p.PhoneTypeIdRef == LprPhone04ViewupdDelTmp.PhoneTypeIdRef);
                
                    var LprPhone04ViewDelRslt = await LprPhone04ViewDelQuery.FirstOrDefaultAsync();
                    if(LprPhone04ViewDelRslt != null) {
                        db.LprPhone04DbSet.Remove(LprPhone04ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprPhone04ViewDelRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update
            if ((action == 1) || (action == 2)) {
                LprPhone01 LprPhone01ViewInsTmp = new LprPhone01() {
                    PhoneId = newObj.PhoneId
                }; // LprPhone01ViewInsTmp
                LpdPhone LpdPhoneViewInsTmp = await SelDictItemForLpdPhoneView(db, newObj);
                if(LpdPhoneViewInsTmp == null) {
                    LpdPhoneViewInsTmp = await InsDictItemForLpdPhoneView(db, newObj);
                }
                LprPhone01ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone01>  LprPhone01ViewInsQuery = db.LprPhone01DbSet;
                LprPhone01ViewInsQuery = LprPhone01ViewInsQuery.Where(p=> p.PhoneId == LprPhone01ViewInsTmp.PhoneId);
                LprPhone01ViewInsQuery = LprPhone01ViewInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone01ViewInsTmp.LpdPhoneIdRef);
                
                var LprPhone01ViewinsRslt = await LprPhone01ViewInsQuery.FirstOrDefaultAsync();
                if(LprPhone01ViewinsRslt == null) {
                    db.LprPhone01DbSet.Add(LprPhone01ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprPhone01ViewInsTmp).State = EntityState.Detached;
                }
                LprPhone02 LprPhone02ViewInsTmp = new LprPhone02() {
                    PhoneId = newObj.PhoneId,
                    EmployeeIdRef = newObj.EmployeeIdRef,
                }; // LprPhone02ViewInsTmp
                LprPhone02ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone02>  LprPhone02ViewInsQuery = db.LprPhone02DbSet;
                LprPhone02ViewInsQuery = LprPhone02ViewInsQuery.Where(p=> p.PhoneId == LprPhone02ViewInsTmp.PhoneId);
                LprPhone02ViewInsQuery = LprPhone02ViewInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone02ViewInsTmp.LpdPhoneIdRef);
                LprPhone02ViewInsQuery = LprPhone02ViewInsQuery.Where(p=> p.EmployeeIdRef == LprPhone02ViewInsTmp.EmployeeIdRef);
                
                var LprPhone02ViewinsRslt = await LprPhone02ViewInsQuery.FirstOrDefaultAsync();
                if(LprPhone02ViewinsRslt == null) {
                    db.LprPhone02DbSet.Add(LprPhone02ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprPhone02ViewInsTmp).State = EntityState.Detached;
                }
                LprPhone03 LprPhone03ViewInsTmp = new LprPhone03() {
                    PhoneId = newObj.PhoneId,
                    PhoneTypeIdRef = newObj.PhoneTypeIdRef,
                }; // LprPhone03ViewInsTmp
                LprPhone03ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone03>  LprPhone03ViewInsQuery = db.LprPhone03DbSet;
                LprPhone03ViewInsQuery = LprPhone03ViewInsQuery.Where(p=> p.PhoneId == LprPhone03ViewInsTmp.PhoneId);
                LprPhone03ViewInsQuery = LprPhone03ViewInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone03ViewInsTmp.LpdPhoneIdRef);
                LprPhone03ViewInsQuery = LprPhone03ViewInsQuery.Where(p=> p.PhoneTypeIdRef == LprPhone03ViewInsTmp.PhoneTypeIdRef);
                
                var LprPhone03ViewinsRslt = await LprPhone03ViewInsQuery.FirstOrDefaultAsync();
                if(LprPhone03ViewinsRslt == null) {
                    db.LprPhone03DbSet.Add(LprPhone03ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprPhone03ViewInsTmp).State = EntityState.Detached;
                }
                LprPhone04 LprPhone04ViewInsTmp = new LprPhone04() {
                    PhoneId = newObj.PhoneId,
                    EmployeeIdRef = newObj.EmployeeIdRef,
                    PhoneTypeIdRef = newObj.PhoneTypeIdRef,
                }; // LprPhone04ViewInsTmp
                LprPhone04ViewInsTmp.LpdPhoneIdRef = LpdPhoneViewInsTmp.LpdPhoneId;
                IQueryable<LprPhone04>  LprPhone04ViewInsQuery = db.LprPhone04DbSet;
                LprPhone04ViewInsQuery = LprPhone04ViewInsQuery.Where(p=> p.PhoneId == LprPhone04ViewInsTmp.PhoneId);
                LprPhone04ViewInsQuery = LprPhone04ViewInsQuery.Where(p=> p.LpdPhoneIdRef == LprPhone04ViewInsTmp.LpdPhoneIdRef);
                LprPhone04ViewInsQuery = LprPhone04ViewInsQuery.Where(p=> p.EmployeeIdRef == LprPhone04ViewInsTmp.EmployeeIdRef);
                LprPhone04ViewInsQuery = LprPhone04ViewInsQuery.Where(p=> p.PhoneTypeIdRef == LprPhone04ViewInsTmp.PhoneTypeIdRef);
                
                var LprPhone04ViewinsRslt = await LprPhone04ViewInsQuery.FirstOrDefaultAsync();
                if(LprPhone04ViewinsRslt == null) {
                    db.LprPhone04DbSet.Add(LprPhone04ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprPhone04ViewInsTmp).State = EntityState.Detached;
                }
            }
        }
    }
}

