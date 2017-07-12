using AutoMapper;
using EMSDomain.Model;
using EMSDomain.ViewModel.Vehicle;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMSMethods
{
    public class IOService
    {
        EmployeeEntities dbContext = new EmployeeEntities();
        public List<TripModel> GetALL()
        {
            Mapper.CreateMap<TripMaster, TripModel>();
            List<TripMaster> objCompanyMaster = dbContext.TripMasters.OrderByDescending(m => m.DDtTime).ToList();
            List<TripModel> objCompItem = Mapper.Map<List<TripModel>>(objCompanyMaster);
            return objCompItem;
        }
        public List<VehicleTypeModel> getActiveVType()
        {
            Mapper.CreateMap<VehicleTypeMaster, VehicleTypeModel>();
            List<VehicleTypeMaster> objCompanyMaster = dbContext.VehicleTypeMasters.ToList();
            List<VehicleTypeModel> objCompItem = Mapper.Map<List<VehicleTypeModel>>(objCompanyMaster);
            return objCompItem;
        }
        public int InsertTrip(TripModel model)
        {
            Mapper.CreateMap<TripModel, TripMaster>();
            TripMaster objStockItem = Mapper.Map<TripMaster>(model);
            dbContext.TripMasters.Add(objStockItem);
            dbContext.SaveChanges();

            int tid = dbContext.TripMasters.Max(m => m.TID);
            if (model.VTypeModel.VTID != null)
            {
                model.VTypeModel.TID = tid;
                //model.VTypeModel.VTID = model.VTID;
                //model.VTypeModel.TotalVehicle = model.TotalVehicle;
                Mapper.CreateMap<TripVehicleModel, TripVehicle>();
                TripVehicle objPetrol = Mapper.Map<TripVehicle>(model.VTypeModel);
                dbContext.TripVehicles.Add(objPetrol);
                dbContext.SaveChanges();
            }
            if (model.VTypeModel.VTID != null || model.VTypeModel.VTID == null)
            {
                model.VTypeModel.TID = tid;
                model.VTypeModel.VTID = model.VTypeModel.VTID1;
                model.VTypeModel.TotalVehicle = model.VTypeModel.TotalVehicle1;
                Mapper.CreateMap<TripVehicleModel, TripVehicle>();
                TripVehicle objPetrol = Mapper.Map<TripVehicle>(model.VTypeModel);
                dbContext.TripVehicles.Add(objPetrol);
                dbContext.SaveChanges();
            }
            if (model.VTypeModel.VTID != null || model.VTypeModel.VTID == null)
            {
                model.VTypeModel.TID = tid;
                model.VTypeModel.VTID = model.VTypeModel.VTID2;
                model.VTypeModel.TotalVehicle = model.VTypeModel.TotalVehicle2;
                Mapper.CreateMap<TripVehicleModel, TripVehicle>();
                TripVehicle objPetrol = Mapper.Map<TripVehicle>(model.VTypeModel);
                dbContext.TripVehicles.Add(objPetrol);
                dbContext.SaveChanges();
            }
            if (model.VTypeModel.VTID != null || model.VTypeModel.VTID == null)
            {
                model.VTypeModel.TID = tid;
                model.VTypeModel.VTID = model.VTypeModel.VTID3;
                model.VTypeModel.TotalVehicle = model.VTypeModel.TotalVehicle3;
                Mapper.CreateMap<TripVehicleModel, TripVehicle>();
                TripVehicle objPetrol = Mapper.Map<TripVehicle>(model.VTypeModel);
                dbContext.TripVehicles.Add(objPetrol);
                dbContext.SaveChanges();
            }

            return dbContext.SaveChanges();
        }
        //public List<TripModel> getTripByDate(DateTime date)
        //{
        //    Mapper.CreateMap<TripMaster, TripModel>();
        //    //List<TripMaster> objCompanyMaster = dbContext.TripMasters.Where(m => m.Type=="O").ToList();
        //    List<TripMaster> objCompanyMaster = dbContext.TripMasters.Where(m=>m.DDtTime==date && m.OIType=="O").ToList();
        //    List<TripModel> objCompItem = Mapper.Map<List<TripModel>>(objCompanyMaster);
        //    return objCompItem;
        //}
        public List<TripModel> getTripByDate(DateTime ddate)
        {
            //object[] params1 = {
            //    new SqlParameter("@date", date),
            //    new SqlParameter("@action", "TripByDDate")};
            //Get student name of string type
            SqlParameter date = new SqlParameter("@date", ddate);
            SqlParameter action = new SqlParameter("@action", "TripByDDate");
            //var action=new SqlParameter();
            //action.ParameterName="@action";
            //action.SqlDbType=SqlDbType.VarChar;
            //action.SqlValue="TripByDDate";

            //var date=new SqlParameter();
            //date.ParameterName="@date";
            //date.SqlDbType=SqlDbType.Date;
            //date.SqlValue=ddate;
            var tripList = dbContext.Database.SqlQuery<TripModel>
                //("EXEC sp_trip_detail @date,@action", new SqlParameter("date", ddate),new SqlParameter("action",action)).ToList<TripModel>();
            ("EXEC sp_trip_detail @date,@action", date, action).ToList<TripModel>();
            //DbContext.Database.SqlQuery<PayrollItem>("exec PayrollReport", params1).ToList<PayrollItem>();
            return tripList;
        }
        public TripModel getByID(int? id)
        {
            Mapper.CreateMap<TripMaster, TripModel>();
            TripMaster objDep = dbContext.TripMasters.SingleOrDefault(m => m.TID == id);
            TripModel objDepItem = Mapper.Map<TripModel>(objDep);
            return objDepItem;

        }
        public int Update(TripModel model)
        {
            Mapper.CreateMap<TripModel, TripMaster>();
            TripMaster objInsu = dbContext.TripMasters.SingleOrDefault(m => m.TID == model.TID);
            objInsu = Mapper.Map(model, objInsu);
            return dbContext.SaveChanges();
        }
        public int updateTripVhcl(int tvid, int totalvhcl, int? vtid)
        {
            TripVehicle objTVhcl = new TripVehicle();
            objTVhcl = dbContext.TripVehicles.SingleOrDefault(m => m.TVID == tvid);
            objTVhcl.TotalVehicle = totalvhcl;
            objTVhcl.VTID = vtid;
            return dbContext.SaveChanges();
        }
        public List<TripVehicleModel> getTripVehicleByTID(int tid)
        {
            Mapper.CreateMap<TripVehicle, TripVehicleModel>();
            List<TripVehicle> objCompanyMaster = dbContext.TripVehicles.Where(m => m.TID == tid).ToList();
            List<TripVehicleModel> objCompItem = Mapper.Map<List<TripVehicleModel>>(objCompanyMaster);
            return objCompItem;
        }
        public List<TripModel> getTripToAssignVehicle(DateTime date)
        {
            var tripList = dbContext.Database.SqlQuery<TripModel>
                ("EXEC sp_trip_detail @date", new SqlParameter("date", date)).ToList<TripModel>();
            //DbContext.Database.SqlQuery<PayrollItem>("exec PayrollReport", params1).ToList<PayrollItem>();
            return tripList;
        }
    }
}
