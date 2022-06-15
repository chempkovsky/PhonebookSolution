#nullable disable
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


using LpPhBkContext.PhBk;
using PhBkViews.PhBk;
using LpPhBkViews.PhBk;


using LpPhBkEntity.PhBk;


namespace LpPhBkControllers.Helpers {


    public static class M2mUpdaterPhbkEmployeeView {
        public static async Task<LpdEmpLastName> SelDictItemForLpdEmpLastNameView(LpEmpPhBkContext db, IPhbkEmployeeViewExtForLkUp vm) {
            IQueryable<LpdEmpLastName> query = db.LpdEmpLastNameDbSet;
// "It Skipped" Info: for scalar prop = [EmpLastNameId] of searchVM = [LpdEmpLastNameView] could not find mapped Unique Key property of the Entity = [LpdEmpLastName]
            // maybe it requires additional code related to nullable values
            query = query.Where(p => p.EmpLastName == vm.EmpLastName);
            LpdEmpLastName rslt = await query.FirstOrDefaultAsync();
            if(rslt != null) db.Entry(rslt).State = EntityState.Detached;
            return rslt;
        }
        public static async Task<LpdEmpLastName> InsDictItemForLpdEmpLastNameView(LpEmpPhBkContext db, IPhbkEmployeeViewExtForLkUp vm) {
            LpdEmpLastName entityToAdd = new LpdEmpLastName();
// "It Skipped" Info: scalar prop = [EmpLastNameId] of searchVM = [LpdEmpLastNameView] is in primary key. Pay special attention if it should be defined with your special value. For instance, Guid.NewGuid().ToString("N");
//         entityToAdd.EmpLastNameId = // Guid.NewGuid().ToString("N");
            entityToAdd.EmpLastName = vm.EmpLastName; // scalar prop names are identical
// pay special attention to primKey values

            db.LpdEmpLastNameDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();
            db.Entry(entityToAdd).State = EntityState.Detached;
            return entityToAdd;
        }
        public static async Task<LpdEmpFirstName> SelDictItemForLpdEmpFirstNameView(LpEmpPhBkContext db, IPhbkEmployeeViewExtForLkUp vm) {
            IQueryable<LpdEmpFirstName> query = db.LpdEmpFirstNameDbSet;
// "It Skipped" Info: for scalar prop = [EmpFirstNameId] of searchVM = [LpdEmpFirstNameView] could not find mapped Unique Key property of the Entity = [LpdEmpFirstName]
            // maybe it requires additional code related to nullable values
            query = query.Where(p => p.EmpFirstName == vm.EmpFirstName);
            LpdEmpFirstName rslt = await query.FirstOrDefaultAsync();
            if(rslt != null) db.Entry(rslt).State = EntityState.Detached;
            return rslt;
        }
        public static async Task<LpdEmpFirstName> InsDictItemForLpdEmpFirstNameView(LpEmpPhBkContext db, IPhbkEmployeeViewExtForLkUp vm) {
            LpdEmpFirstName entityToAdd = new LpdEmpFirstName();
// "It Skipped" Info: scalar prop = [EmpFirstNameId] of searchVM = [LpdEmpFirstNameView] is in primary key. Pay special attention if it should be defined with your special value. For instance, Guid.NewGuid().ToString("N");
//         entityToAdd.EmpFirstNameId = // Guid.NewGuid().ToString("N");
            entityToAdd.EmpFirstName = vm.EmpFirstName; // scalar prop names are identical
// pay special attention to primKey values

            db.LpdEmpFirstNameDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();
            db.Entry(entityToAdd).State = EntityState.Detached;
            return entityToAdd;
        }
        public static async Task<LpdEmpSecondName> SelDictItemForLpdEmpSecondNameView(LpEmpPhBkContext db, IPhbkEmployeeViewExtForLkUp vm) {
            IQueryable<LpdEmpSecondName> query = db.LpdEmpSecondNameDbSet;
// "It Skipped" Info: for scalar prop = [EmpSecondNameId] of searchVM = [LpdEmpSecondNameView] could not find mapped Unique Key property of the Entity = [LpdEmpSecondName]
            // maybe it requires additional code related to nullable values
            query = query.Where(p => p.EmpSecondName == vm.EmpSecondName);
            LpdEmpSecondName rslt = await query.FirstOrDefaultAsync();
            if(rslt != null) db.Entry(rslt).State = EntityState.Detached;
            return rslt;
        }
        public static async Task<LpdEmpSecondName> InsDictItemForLpdEmpSecondNameView(LpEmpPhBkContext db, IPhbkEmployeeViewExtForLkUp vm) {
            LpdEmpSecondName entityToAdd = new LpdEmpSecondName();
// "It Skipped" Info: scalar prop = [EmpSecondNameId] of searchVM = [LpdEmpSecondNameView] is in primary key. Pay special attention if it should be defined with your special value. For instance, Guid.NewGuid().ToString("N");
//         entityToAdd.EmpSecondNameId = // Guid.NewGuid().ToString("N");
            entityToAdd.EmpSecondName = vm.EmpSecondName; // scalar prop names are identical
// pay special attention to primKey values

            db.LpdEmpSecondNameDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();
            db.Entry(entityToAdd).State = EntityState.Detached;
            return entityToAdd;
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprEmployee01View(LpEmpPhBkContext db, int action, IPhbkEmployeeViewExtForLkUp oldObj, IPhbkEmployeeViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprEmployee01 LprEmployee01ViewupdDelTmp = new LprEmployee01() {
                    EmployeeId = oldObj.EmployeeId
                }; // LprEmployee01ViewupdDelTmp
                if(readyToDel) {
                    LpdEmpLastName LpdEmpLastNameViewupdDelTmp = await SelDictItemForLpdEmpLastNameView(db, oldObj);
                    readyToDel = LpdEmpLastNameViewupdDelTmp == null;
                    if(readyToDel) {
                    LprEmployee01ViewupdDelTmp.EmpLastNameIdRef = LpdEmpLastNameViewupdDelTmp.EmpLastNameId;
                    }
                }
                if(readyToDel) {
                    LpdEmpFirstName LpdEmpFirstNameViewupdDelTmp = await SelDictItemForLpdEmpFirstNameView(db, oldObj);
                    readyToDel = LpdEmpFirstNameViewupdDelTmp == null;
                    if(readyToDel) {
                    LprEmployee01ViewupdDelTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewupdDelTmp.EmpFirstNameId;
                    }
                }
                if(readyToDel) {
                    LpdEmpSecondName LpdEmpSecondNameViewupdDelTmp = await SelDictItemForLpdEmpSecondNameView(db, oldObj);
                    readyToDel = LpdEmpSecondNameViewupdDelTmp == null;
                    if(readyToDel) {
                    LprEmployee01ViewupdDelTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewupdDelTmp.EmpSecondNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprEmployee01> m2mDelQuery = db.LprEmployee01DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmployeeId == LprEmployee01ViewupdDelTmp.EmployeeId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee01ViewupdDelTmp.EmpLastNameIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee01ViewupdDelTmp.EmpFirstNameIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee01ViewupdDelTmp.EmpSecondNameIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprEmployee01DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprEmployee01 LprEmployee01ViewInsTmp = new LprEmployee01() {
                    EmployeeId = newObj.EmployeeId
                }; // LprEmployee01ViewInsTmp
                LpdEmpLastName LpdEmpLastNameViewInsTmp = await SelDictItemForLpdEmpLastNameView(db, newObj);
                if(LpdEmpLastNameViewInsTmp == null) {
                    LpdEmpLastNameViewInsTmp = await InsDictItemForLpdEmpLastNameView(db, newObj);
                }
                LprEmployee01ViewInsTmp.EmpLastNameIdRef = LpdEmpLastNameViewInsTmp.EmpLastNameId;
                LpdEmpFirstName LpdEmpFirstNameViewInsTmp = await SelDictItemForLpdEmpFirstNameView(db, newObj);
                if(LpdEmpFirstNameViewInsTmp == null) {
                    LpdEmpFirstNameViewInsTmp = await InsDictItemForLpdEmpFirstNameView(db, newObj);
                }
                LprEmployee01ViewInsTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewInsTmp.EmpFirstNameId;
                LpdEmpSecondName LpdEmpSecondNameViewInsTmp = await SelDictItemForLpdEmpSecondNameView(db, newObj);
                if(LpdEmpSecondNameViewInsTmp == null) {
                    LpdEmpSecondNameViewInsTmp = await InsDictItemForLpdEmpSecondNameView(db, newObj);
                }
                LprEmployee01ViewInsTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewInsTmp.EmpSecondNameId;
                IQueryable<LprEmployee01> m2mInsQuery = db.LprEmployee01DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmployeeId == LprEmployee01ViewInsTmp.EmployeeId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee01ViewInsTmp.EmpLastNameIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee01ViewInsTmp.EmpFirstNameIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee01ViewInsTmp.EmpSecondNameIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprEmployee01DbSet.Add(LprEmployee01ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprEmployee01ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprEmployee02View(LpEmpPhBkContext db, int action, IPhbkEmployeeViewExtForLkUp oldObj, IPhbkEmployeeViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprEmployee02 LprEmployee02ViewupdDelTmp = new LprEmployee02() {
                    EmployeeId = oldObj.EmployeeId,
                    DivisionIdRef = oldObj.DivisionIdRef,
                }; // LprEmployee02ViewupdDelTmp
                if(readyToDel) {
                    LpdEmpLastName LpdEmpLastNameViewupdDelTmp = await SelDictItemForLpdEmpLastNameView(db, oldObj);
                    readyToDel = LpdEmpLastNameViewupdDelTmp == null;
                    if(readyToDel) {
                    LprEmployee02ViewupdDelTmp.EmpLastNameIdRef = LpdEmpLastNameViewupdDelTmp.EmpLastNameId;
                    }
                }
                if(readyToDel) {
                    LpdEmpFirstName LpdEmpFirstNameViewupdDelTmp = await SelDictItemForLpdEmpFirstNameView(db, oldObj);
                    readyToDel = LpdEmpFirstNameViewupdDelTmp == null;
                    if(readyToDel) {
                    LprEmployee02ViewupdDelTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewupdDelTmp.EmpFirstNameId;
                    }
                }
                if(readyToDel) {
                    LpdEmpSecondName LpdEmpSecondNameViewupdDelTmp = await SelDictItemForLpdEmpSecondNameView(db, oldObj);
                    readyToDel = LpdEmpSecondNameViewupdDelTmp == null;
                    if(readyToDel) {
                    LprEmployee02ViewupdDelTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewupdDelTmp.EmpSecondNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprEmployee02> m2mDelQuery = db.LprEmployee02DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmployeeId == LprEmployee02ViewupdDelTmp.EmployeeId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee02ViewupdDelTmp.EmpLastNameIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee02ViewupdDelTmp.EmpFirstNameIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee02ViewupdDelTmp.EmpSecondNameIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.DivisionIdRef == LprEmployee02ViewupdDelTmp.DivisionIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprEmployee02DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprEmployee02 LprEmployee02ViewInsTmp = new LprEmployee02() {
                    EmployeeId = newObj.EmployeeId,
                    DivisionIdRef = newObj.DivisionIdRef,
                }; // LprEmployee02ViewInsTmp
                LpdEmpLastName LpdEmpLastNameViewInsTmp = await SelDictItemForLpdEmpLastNameView(db, newObj);
                if(LpdEmpLastNameViewInsTmp == null) {
                    LpdEmpLastNameViewInsTmp = await InsDictItemForLpdEmpLastNameView(db, newObj);
                }
                LprEmployee02ViewInsTmp.EmpLastNameIdRef = LpdEmpLastNameViewInsTmp.EmpLastNameId;
                LpdEmpFirstName LpdEmpFirstNameViewInsTmp = await SelDictItemForLpdEmpFirstNameView(db, newObj);
                if(LpdEmpFirstNameViewInsTmp == null) {
                    LpdEmpFirstNameViewInsTmp = await InsDictItemForLpdEmpFirstNameView(db, newObj);
                }
                LprEmployee02ViewInsTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewInsTmp.EmpFirstNameId;
                LpdEmpSecondName LpdEmpSecondNameViewInsTmp = await SelDictItemForLpdEmpSecondNameView(db, newObj);
                if(LpdEmpSecondNameViewInsTmp == null) {
                    LpdEmpSecondNameViewInsTmp = await InsDictItemForLpdEmpSecondNameView(db, newObj);
                }
                LprEmployee02ViewInsTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewInsTmp.EmpSecondNameId;
                IQueryable<LprEmployee02> m2mInsQuery = db.LprEmployee02DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmployeeId == LprEmployee02ViewInsTmp.EmployeeId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee02ViewInsTmp.EmpLastNameIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee02ViewInsTmp.EmpFirstNameIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee02ViewInsTmp.EmpSecondNameIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.DivisionIdRef == LprEmployee02ViewInsTmp.DivisionIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprEmployee02DbSet.Add(LprEmployee02ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprEmployee02ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForPhbkEmployeeView(LpEmpPhBkContext db, int action, IPhbkEmployeeViewExtForLkUp oldObj, IPhbkEmployeeViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 3 - delete; 2 - update
            if ((action == 3) || (action == 2)) {
                bool readyToDel = true;
                LprEmployee01 LprEmployee01ViewupdDelTmp = new LprEmployee01() {
                    EmployeeId = oldObj.EmployeeId
                }; // LprEmployee01ViewupdDelTmp
                LpdEmpLastName LpdEmpLastNameViewdelTmp = await SelDictItemForLpdEmpLastNameView(db, oldObj);
                LpdEmpFirstName LpdEmpFirstNameViewdelTmp = await SelDictItemForLpdEmpFirstNameView(db, oldObj);
                LpdEmpSecondName LpdEmpSecondNameViewdelTmp = await SelDictItemForLpdEmpSecondNameView(db, oldObj);
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdEmpLastNameViewdelTmp != null;

                    if(readyToDel) {
                        LprEmployee01ViewupdDelTmp.EmpLastNameIdRef = LpdEmpLastNameViewdelTmp.EmpLastNameId;
                    }
                }
                if (readyToDel) {
                    readyToDel = LpdEmpFirstNameViewdelTmp != null;

                    if(readyToDel) {
                        LprEmployee01ViewupdDelTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewdelTmp.EmpFirstNameId;
                    }
                }
                if (readyToDel) {
                    readyToDel = LpdEmpSecondNameViewdelTmp != null;

                    if(readyToDel) {
                        LprEmployee01ViewupdDelTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewdelTmp.EmpSecondNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprEmployee01> LprEmployee01ViewDelQuery = db.LprEmployee01DbSet;
                    LprEmployee01ViewDelQuery = LprEmployee01ViewDelQuery.Where(p=> p.EmployeeId == LprEmployee01ViewupdDelTmp.EmployeeId);
                    LprEmployee01ViewDelQuery = LprEmployee01ViewDelQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee01ViewupdDelTmp.EmpLastNameIdRef);
                    LprEmployee01ViewDelQuery = LprEmployee01ViewDelQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee01ViewupdDelTmp.EmpFirstNameIdRef);
                    LprEmployee01ViewDelQuery = LprEmployee01ViewDelQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee01ViewupdDelTmp.EmpSecondNameIdRef);
                
                    var LprEmployee01ViewDelRslt = await LprEmployee01ViewDelQuery.FirstOrDefaultAsync();
                    if(LprEmployee01ViewDelRslt != null) {
                        db.LprEmployee01DbSet.Remove(LprEmployee01ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprEmployee01ViewDelRslt).State = EntityState.Detached;
                    }
                }
                LprEmployee02 LprEmployee02ViewupdDelTmp = new LprEmployee02() {
                    EmployeeId = oldObj.EmployeeId,
                    DivisionIdRef = oldObj.DivisionIdRef,
                }; // LprEmployee02ViewupdDelTmp
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdEmpLastNameViewdelTmp != null;

                    if(readyToDel) {
                        LprEmployee02ViewupdDelTmp.EmpLastNameIdRef = LpdEmpLastNameViewdelTmp.EmpLastNameId;
                    }
                }
                if (readyToDel) {
                    readyToDel = LpdEmpFirstNameViewdelTmp != null;

                    if(readyToDel) {
                        LprEmployee02ViewupdDelTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewdelTmp.EmpFirstNameId;
                    }
                }
                if (readyToDel) {
                    readyToDel = LpdEmpSecondNameViewdelTmp != null;

                    if(readyToDel) {
                        LprEmployee02ViewupdDelTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewdelTmp.EmpSecondNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprEmployee02> LprEmployee02ViewDelQuery = db.LprEmployee02DbSet;
                    LprEmployee02ViewDelQuery = LprEmployee02ViewDelQuery.Where(p=> p.EmployeeId == LprEmployee02ViewupdDelTmp.EmployeeId);
                    LprEmployee02ViewDelQuery = LprEmployee02ViewDelQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee02ViewupdDelTmp.EmpLastNameIdRef);
                    LprEmployee02ViewDelQuery = LprEmployee02ViewDelQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee02ViewupdDelTmp.EmpFirstNameIdRef);
                    LprEmployee02ViewDelQuery = LprEmployee02ViewDelQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee02ViewupdDelTmp.EmpSecondNameIdRef);
                    LprEmployee02ViewDelQuery = LprEmployee02ViewDelQuery.Where(p=> p.DivisionIdRef == LprEmployee02ViewupdDelTmp.DivisionIdRef);
                
                    var LprEmployee02ViewDelRslt = await LprEmployee02ViewDelQuery.FirstOrDefaultAsync();
                    if(LprEmployee02ViewDelRslt != null) {
                        db.LprEmployee02DbSet.Remove(LprEmployee02ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprEmployee02ViewDelRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update
            if ((action == 1) || (action == 2)) {
                LprEmployee01 LprEmployee01ViewInsTmp = new LprEmployee01() {
                    EmployeeId = newObj.EmployeeId
                }; // LprEmployee01ViewInsTmp
                LpdEmpLastName LpdEmpLastNameViewInsTmp = await SelDictItemForLpdEmpLastNameView(db, newObj);
                if(LpdEmpLastNameViewInsTmp == null) {
                    LpdEmpLastNameViewInsTmp = await InsDictItemForLpdEmpLastNameView(db, newObj);
                }
                LprEmployee01ViewInsTmp.EmpLastNameIdRef = LpdEmpLastNameViewInsTmp.EmpLastNameId;
                LpdEmpFirstName LpdEmpFirstNameViewInsTmp = await SelDictItemForLpdEmpFirstNameView(db, newObj);
                if(LpdEmpFirstNameViewInsTmp == null) {
                    LpdEmpFirstNameViewInsTmp = await InsDictItemForLpdEmpFirstNameView(db, newObj);
                }
                LprEmployee01ViewInsTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewInsTmp.EmpFirstNameId;
                LpdEmpSecondName LpdEmpSecondNameViewInsTmp = await SelDictItemForLpdEmpSecondNameView(db, newObj);
                if(LpdEmpSecondNameViewInsTmp == null) {
                    LpdEmpSecondNameViewInsTmp = await InsDictItemForLpdEmpSecondNameView(db, newObj);
                }
                LprEmployee01ViewInsTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewInsTmp.EmpSecondNameId;
                IQueryable<LprEmployee01>  LprEmployee01ViewInsQuery = db.LprEmployee01DbSet;
                LprEmployee01ViewInsQuery = LprEmployee01ViewInsQuery.Where(p=> p.EmployeeId == LprEmployee01ViewInsTmp.EmployeeId);
                LprEmployee01ViewInsQuery = LprEmployee01ViewInsQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee01ViewInsTmp.EmpLastNameIdRef);
                LprEmployee01ViewInsQuery = LprEmployee01ViewInsQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee01ViewInsTmp.EmpFirstNameIdRef);
                LprEmployee01ViewInsQuery = LprEmployee01ViewInsQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee01ViewInsTmp.EmpSecondNameIdRef);
                
                var LprEmployee01ViewinsRslt = await LprEmployee01ViewInsQuery.FirstOrDefaultAsync();
                if(LprEmployee01ViewinsRslt == null) {
                    db.LprEmployee01DbSet.Add(LprEmployee01ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprEmployee01ViewInsTmp).State = EntityState.Detached;
                }
                LprEmployee02 LprEmployee02ViewInsTmp = new LprEmployee02() {
                    EmployeeId = newObj.EmployeeId,
                    DivisionIdRef = newObj.DivisionIdRef,
                }; // LprEmployee02ViewInsTmp
                LprEmployee02ViewInsTmp.EmpLastNameIdRef = LpdEmpLastNameViewInsTmp.EmpLastNameId;
                LprEmployee02ViewInsTmp.EmpFirstNameIdRef = LpdEmpFirstNameViewInsTmp.EmpFirstNameId;
                LprEmployee02ViewInsTmp.EmpSecondNameIdRef = LpdEmpSecondNameViewInsTmp.EmpSecondNameId;
                IQueryable<LprEmployee02>  LprEmployee02ViewInsQuery = db.LprEmployee02DbSet;
                LprEmployee02ViewInsQuery = LprEmployee02ViewInsQuery.Where(p=> p.EmployeeId == LprEmployee02ViewInsTmp.EmployeeId);
                LprEmployee02ViewInsQuery = LprEmployee02ViewInsQuery.Where(p=> p.EmpLastNameIdRef == LprEmployee02ViewInsTmp.EmpLastNameIdRef);
                LprEmployee02ViewInsQuery = LprEmployee02ViewInsQuery.Where(p=> p.EmpFirstNameIdRef == LprEmployee02ViewInsTmp.EmpFirstNameIdRef);
                LprEmployee02ViewInsQuery = LprEmployee02ViewInsQuery.Where(p=> p.EmpSecondNameIdRef == LprEmployee02ViewInsTmp.EmpSecondNameIdRef);
                LprEmployee02ViewInsQuery = LprEmployee02ViewInsQuery.Where(p=> p.DivisionIdRef == LprEmployee02ViewInsTmp.DivisionIdRef);
                
                var LprEmployee02ViewinsRslt = await LprEmployee02ViewInsQuery.FirstOrDefaultAsync();
                if(LprEmployee02ViewinsRslt == null) {
                    db.LprEmployee02DbSet.Add(LprEmployee02ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprEmployee02ViewInsTmp).State = EntityState.Detached;
                }
            }
        }
    }
}

