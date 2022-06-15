#nullable disable
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;


using LpPhBkContext.PhBk;
using PhBkViews.PhBk;
using LpPhBkViews.PhBk;


using LpPhBkEntity.PhBk;


namespace LpPhBkControllers.Helpers {


    public static class M2mUpdaterPhbkDivisionView {
        public static async Task<LpdDivision> SelDictItemForLpdDivisionView(LpPhbkDbContext db, IPhbkDivisionViewExtForLkUp vm) {
            IQueryable<LpdDivision> query = db.LpdDivisionDbSet;
// "It Skipped" Info: for scalar prop = [DivisionNameId] of searchVM = [LpdDivisionView] could not find mapped Unique Key property of the Entity = [LpdDivision]
            // maybe it requires additional code related to nullable values
            query = query.Where(p => p.DivisionName == vm.DivisionName);
            LpdDivision rslt = await query.FirstOrDefaultAsync();
            if(rslt != null) db.Entry(rslt).State = EntityState.Detached;
            return rslt;
        }
        public static async Task<LpdDivision> InsDictItemForLpdDivisionView(LpPhbkDbContext db, IPhbkDivisionViewExtForLkUp vm) {
            LpdDivision entityToAdd = new LpdDivision();
// "It Skipped" Info: scalar prop = [DivisionNameId] of searchVM = [LpdDivisionView] is in primary key. Pay special attention if it should be defined with your special value. For instance, Guid.NewGuid().ToString("N");
//         entityToAdd.DivisionNameId = // Guid.NewGuid().ToString("N");
            entityToAdd.DivisionName = vm.DivisionName; // scalar prop names are identical
// pay special attention to primKey values

            db.LpdDivisionDbSet.Add(entityToAdd);
            await db.SaveChangesAsync();
            db.Entry(entityToAdd).State = EntityState.Detached;
            return entityToAdd;
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprDivision01View(LpPhbkDbContext db, int action, IPhbkDivisionViewExtForLkUp oldObj, IPhbkDivisionViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprDivision01 LprDivision01ViewupdDelTmp = new LprDivision01() {
                    DivisionId = oldObj.DivisionId
                }; // LprDivision01ViewupdDelTmp
                if(readyToDel) {
                    LpdDivision LpdDivisionViewupdDelTmp = await SelDictItemForLpdDivisionView(db, oldObj);
                    readyToDel = LpdDivisionViewupdDelTmp == null;
                    if(readyToDel) {
                    LprDivision01ViewupdDelTmp.DivisionNameIdRef = LpdDivisionViewupdDelTmp.DivisionNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprDivision01> m2mDelQuery = db.LprDivision01DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.DivisionId == LprDivision01ViewupdDelTmp.DivisionId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.DivisionNameIdRef == LprDivision01ViewupdDelTmp.DivisionNameIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprDivision01DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprDivision01 LprDivision01ViewInsTmp = new LprDivision01() {
                    DivisionId = newObj.DivisionId
                }; // LprDivision01ViewInsTmp
                LpdDivision LpdDivisionViewInsTmp = await SelDictItemForLpdDivisionView(db, newObj);
                if(LpdDivisionViewInsTmp == null) {
                    LpdDivisionViewInsTmp = await InsDictItemForLpdDivisionView(db, newObj);
                }
                LprDivision01ViewInsTmp.DivisionNameIdRef = LpdDivisionViewInsTmp.DivisionNameId;
                IQueryable<LprDivision01> m2mInsQuery = db.LprDivision01DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.DivisionId == LprDivision01ViewInsTmp.DivisionId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.DivisionNameIdRef == LprDivision01ViewInsTmp.DivisionNameIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprDivision01DbSet.Add(LprDivision01ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprDivision01ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForLprDivision02View(LpPhbkDbContext db, int action, IPhbkDivisionViewExtForLkUp oldObj, IPhbkDivisionViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 2 - update; 3 - delete
            if ((action == 2) || (action == 3)) {
                bool readyToDel = true;

                LprDivision02 LprDivision02ViewupdDelTmp = new LprDivision02() {
                    DivisionId = oldObj.DivisionId,
                    EntrprsIdRef = oldObj.EntrprsIdRef,
                }; // LprDivision02ViewupdDelTmp
                if(readyToDel) {
                    LpdDivision LpdDivisionViewupdDelTmp = await SelDictItemForLpdDivisionView(db, oldObj);
                    readyToDel = LpdDivisionViewupdDelTmp == null;
                    if(readyToDel) {
                    LprDivision02ViewupdDelTmp.DivisionNameIdRef = LpdDivisionViewupdDelTmp.DivisionNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprDivision02> m2mDelQuery = db.LprDivision02DbSet;
                    m2mDelQuery = m2mDelQuery.Where(p=> p.DivisionId == LprDivision02ViewupdDelTmp.DivisionId);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.EntrprsIdRef == LprDivision02ViewupdDelTmp.EntrprsIdRef);
                    m2mDelQuery = m2mDelQuery.Where(p=> p.DivisionNameIdRef == LprDivision02ViewupdDelTmp.DivisionNameIdRef);
                
                    var delM2mRslt = await m2mDelQuery.FirstOrDefaultAsync();
                    if(delM2mRslt != null) {
                        db.LprDivision02DbSet.Remove(delM2mRslt);
                        db.SaveChanges();
                        db.Entry(delM2mRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update;
            if ((action == 1) || (action == 2)) {
                LprDivision02 LprDivision02ViewInsTmp = new LprDivision02() {
                    DivisionId = newObj.DivisionId,
                    EntrprsIdRef = newObj.EntrprsIdRef,
                }; // LprDivision02ViewInsTmp
                LpdDivision LpdDivisionViewInsTmp = await SelDictItemForLpdDivisionView(db, newObj);
                if(LpdDivisionViewInsTmp == null) {
                    LpdDivisionViewInsTmp = await InsDictItemForLpdDivisionView(db, newObj);
                }
                LprDivision02ViewInsTmp.DivisionNameIdRef = LpdDivisionViewInsTmp.DivisionNameId;
                IQueryable<LprDivision02> m2mInsQuery = db.LprDivision02DbSet;
                m2mInsQuery = m2mInsQuery.Where(p=> p.DivisionId == LprDivision02ViewInsTmp.DivisionId);
                m2mInsQuery = m2mInsQuery.Where(p=> p.EntrprsIdRef == LprDivision02ViewInsTmp.EntrprsIdRef);
                m2mInsQuery = m2mInsQuery.Where(p=> p.DivisionNameIdRef == LprDivision02ViewInsTmp.DivisionNameIdRef);
                
                var insM2mRslt = await m2mInsQuery.FirstOrDefaultAsync();
                if(insM2mRslt != null) return;
                db.LprDivision02DbSet.Add(LprDivision02ViewInsTmp);
                await db.SaveChangesAsync();
                db.Entry(LprDivision02ViewInsTmp).State = EntityState.Detached;
                return;
            }
        }
        // action: 1 - insert; 2 - update; 3 - delete
        public static async Task UpdateForPhbkDivisionView(LpPhbkDbContext db, int action, IPhbkDivisionViewExtForLkUp oldObj, IPhbkDivisionViewExtForLkUp newObj) {
            if ( (action < 1)   || (action > 3)) return; // or throw exception
            if ( ((action == 2) || (action == 3)) && (oldObj == null) ) return; // or throw exception
            if ( ((action == 1) || (action == 2)) && (newObj == null) ) return; // or throw exception
            // 3 - delete; 2 - update
            if ((action == 3) || (action == 2)) {
                bool readyToDel = true;
                LprDivision01 LprDivision01ViewupdDelTmp = new LprDivision01() {
                    DivisionId = oldObj.DivisionId
                }; // LprDivision01ViewupdDelTmp
                LpdDivision LpdDivisionViewdelTmp = await SelDictItemForLpdDivisionView(db, oldObj);
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdDivisionViewdelTmp != null;

                    if(readyToDel) {
                        LprDivision01ViewupdDelTmp.DivisionNameIdRef = LpdDivisionViewdelTmp.DivisionNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprDivision01> LprDivision01ViewDelQuery = db.LprDivision01DbSet;
                    LprDivision01ViewDelQuery = LprDivision01ViewDelQuery.Where(p=> p.DivisionId == LprDivision01ViewupdDelTmp.DivisionId);
                    LprDivision01ViewDelQuery = LprDivision01ViewDelQuery.Where(p=> p.DivisionNameIdRef == LprDivision01ViewupdDelTmp.DivisionNameIdRef);
                
                    var LprDivision01ViewDelRslt = await LprDivision01ViewDelQuery.FirstOrDefaultAsync();
                    if(LprDivision01ViewDelRslt != null) {
                        db.LprDivision01DbSet.Remove(LprDivision01ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprDivision01ViewDelRslt).State = EntityState.Detached;
                    }
                }
                LprDivision02 LprDivision02ViewupdDelTmp = new LprDivision02() {
                    DivisionId = oldObj.DivisionId,
                    EntrprsIdRef = oldObj.EntrprsIdRef,
                }; // LprDivision02ViewupdDelTmp
                readyToDel = true;
                if (readyToDel) {
                    readyToDel = LpdDivisionViewdelTmp != null;

                    if(readyToDel) {
                        LprDivision02ViewupdDelTmp.DivisionNameIdRef = LpdDivisionViewdelTmp.DivisionNameId;
                    }
                }
                if(readyToDel) {
                    IQueryable<LprDivision02> LprDivision02ViewDelQuery = db.LprDivision02DbSet;
                    LprDivision02ViewDelQuery = LprDivision02ViewDelQuery.Where(p=> p.DivisionId == LprDivision02ViewupdDelTmp.DivisionId);
                    LprDivision02ViewDelQuery = LprDivision02ViewDelQuery.Where(p=> p.EntrprsIdRef == LprDivision02ViewupdDelTmp.EntrprsIdRef);
                    LprDivision02ViewDelQuery = LprDivision02ViewDelQuery.Where(p=> p.DivisionNameIdRef == LprDivision02ViewupdDelTmp.DivisionNameIdRef);
                
                    var LprDivision02ViewDelRslt = await LprDivision02ViewDelQuery.FirstOrDefaultAsync();
                    if(LprDivision02ViewDelRslt != null) {
                        db.LprDivision02DbSet.Remove(LprDivision02ViewDelRslt);
                        db.SaveChanges();
                        db.Entry(LprDivision02ViewDelRslt).State = EntityState.Detached;
                    }
                }
            }
            // 1 - insert; 2 - update
            if ((action == 1) || (action == 2)) {
                LprDivision01 LprDivision01ViewInsTmp = new LprDivision01() {
                    DivisionId = newObj.DivisionId
                }; // LprDivision01ViewInsTmp
                LpdDivision LpdDivisionViewInsTmp = await SelDictItemForLpdDivisionView(db, newObj);
                if(LpdDivisionViewInsTmp == null) {
                    LpdDivisionViewInsTmp = await InsDictItemForLpdDivisionView(db, newObj);
                }
                LprDivision01ViewInsTmp.DivisionNameIdRef = LpdDivisionViewInsTmp.DivisionNameId;
                IQueryable<LprDivision01>  LprDivision01ViewInsQuery = db.LprDivision01DbSet;
                LprDivision01ViewInsQuery = LprDivision01ViewInsQuery.Where(p=> p.DivisionId == LprDivision01ViewInsTmp.DivisionId);
                LprDivision01ViewInsQuery = LprDivision01ViewInsQuery.Where(p=> p.DivisionNameIdRef == LprDivision01ViewInsTmp.DivisionNameIdRef);
                
                var LprDivision01ViewinsRslt = await LprDivision01ViewInsQuery.FirstOrDefaultAsync();
                if(LprDivision01ViewinsRslt == null) {
                    db.LprDivision01DbSet.Add(LprDivision01ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprDivision01ViewInsTmp).State = EntityState.Detached;
                }
                LprDivision02 LprDivision02ViewInsTmp = new LprDivision02() {
                    DivisionId = newObj.DivisionId,
                    EntrprsIdRef = newObj.EntrprsIdRef,
                }; // LprDivision02ViewInsTmp
                LprDivision02ViewInsTmp.DivisionNameIdRef = LpdDivisionViewInsTmp.DivisionNameId;
                IQueryable<LprDivision02>  LprDivision02ViewInsQuery = db.LprDivision02DbSet;
                LprDivision02ViewInsQuery = LprDivision02ViewInsQuery.Where(p=> p.DivisionId == LprDivision02ViewInsTmp.DivisionId);
                LprDivision02ViewInsQuery = LprDivision02ViewInsQuery.Where(p=> p.EntrprsIdRef == LprDivision02ViewInsTmp.EntrprsIdRef);
                LprDivision02ViewInsQuery = LprDivision02ViewInsQuery.Where(p=> p.DivisionNameIdRef == LprDivision02ViewInsTmp.DivisionNameIdRef);
                
                var LprDivision02ViewinsRslt = await LprDivision02ViewInsQuery.FirstOrDefaultAsync();
                if(LprDivision02ViewinsRslt == null) {
                    db.LprDivision02DbSet.Add(LprDivision02ViewInsTmp);
                    await db.SaveChangesAsync();
                    db.Entry(LprDivision02ViewInsTmp).State = EntityState.Detached;
                }
            }
        }
    }
}

