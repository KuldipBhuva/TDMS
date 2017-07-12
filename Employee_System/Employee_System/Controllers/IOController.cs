using EMSDomain.Model;
using EMSDomain.ViewModel.Vehicle;
using EMSMethods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee_System.Controllers
{
    public class IOController : Controller
    {
        //
        // GET: /IO/
        EmployeeEntities dbContext = new EmployeeEntities();
        IOService objService = new IOService();
        List<TripModel> lstTrip = new List<TripModel>();
        TripModel objModel = new TripModel();
        public ActionResult Index()
        {


            lstTrip = objService.GetALL();
            objModel.ListTrip = new List<TripModel>();
            objModel.ListTrip.AddRange(lstTrip);

            List<VehicleTypeModel> lstVType = new List<VehicleTypeModel>();
            lstVType = objService.getActiveVType();
            objModel.ListVType = new List<VehicleTypeModel>();
            objModel.ListVType.AddRange(lstVType);
            ViewBag.Menuid = Request.QueryString["menuId"];
            return View(objModel);
        }
        [HttpPost]
        public ActionResult Index(TripModel model)
        {
            int uid = 0;
            int cid = 0;
            int bid = 0;
            if (Session["UserId"] != null)
            {
                uid = Convert.ToInt32(Session["UserId"].ToString());
                cid = Convert.ToInt32(Session["CompID"].ToString());
                bid = Convert.ToInt32(Session["BID"].ToString());
            }

            string OINO = null;

            var lst = dbContext.TripMasters.ToList();
            if (lst.Count <= 0)
            {
                //OINO = Convert.ToString(model.Type + "" + model.OIType + "" + System.DateTime.Now.Month.ToString("mm") + "" + System.DateTime.Now.Year.ToString("yy")+""+0001);
                OINO = Convert.ToString(model.Type + "" + model.OIType + "" + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + "" + System.DateTime.Now.ToString("yy") + "" + "1001");
                model.OINo = OINO;
            }
            else
            {
                string code = null;
                int iono = 0;

                //var max = dbContext.TripMasters.LastOrDefault();
                code = dbContext.TripMasters
                           .OrderByDescending(p => p.TID)
                           .Select(r => r.OINo)
                           .First().ToString();

                if (code != null)
                {
                    var last = code.Substring(code.Length - 4);
                    //var first = code.Substring(code.Length + 6);
                    iono = Convert.ToInt32(last) + 1;
                    var first = Convert.ToString(model.Type + "" + model.OIType + "" + System.DateTime.Now.Month.ToString().PadLeft(2, '0') + "" + System.DateTime.Now.ToString("yy"));
                    string final = first + "" + iono;
                    model.OINo = final;
                }
            }
            model.CID = cid;
            model.BID = bid;
            model.CreatedBy = uid;
            model.CreatedDate = System.DateTime.Now;
            model.Status = 1;
            objService.InsertTrip(model);
            return RedirectToAction("Index", new { @menuId = model.Viewbagidformenu });
        }
        public ActionResult Edit(int id)
        {
            objModel = objService.getByID(id);
            List<TripVehicleModel> lstTVehicle = new List<TripVehicleModel>();
            lstTVehicle = objService.getTripVehicleByTID(id);
            objModel.lstTVehicle = new List<TripVehicleModel>();
            objModel.lstTVehicle.AddRange(lstTVehicle);

            List<VehicleTypeModel> lstVType = new List<VehicleTypeModel>();
            lstVType = objService.getActiveVType();
            objModel.ListVType = new List<VehicleTypeModel>();
            objModel.ListVType.AddRange(lstVType);
            ViewBag.Menuid = Request.QueryString["menuId"];
            return View(objModel);
        }
        [HttpPost]
        public ActionResult Edit(TripModel model)
        {
             int uid = 0;
            if (Session["UserId"] != null)
            {
                uid = Convert.ToInt32(Session["UserId"].ToString());
            }
            foreach (var i in model.lstTVehicle)
            {
                int tvid = i.TVID;
                int total = Convert.ToInt32(i.TotalVehicle);
                int? vtid = i.VTID;
                objService.updateTripVhcl(tvid,total,vtid);
            }
            model.UpdatedBy = uid;
            model.UpdatedDate = System.DateTime.Now;
            objService.Update(model);
            return RedirectToAction("Index", new {@menuId = model.Viewbagidformenu });
        }
        public ActionResult getTrip(string date)
        {
            List<TripModel> lstVhcl = new List<TripModel>();
            TripModel objModel = new TripModel();
            DateTime ddt = Convert.ToDateTime(date);

            lstVhcl = objService.getTripByDate(ddt);
            objModel.ListTrip = new List<TripModel>();
            objModel.ListTrip.AddRange(lstVhcl);
            return PartialView("_Trip", objModel.ListTrip);
            //return Json(objModel, JsonRequestBehavior.AllowGet);
        }
        public ActionResult View(int id)
        {
            objModel = objService.getByID(id);
            List<TripVehicleModel> lstTVehicle = new List<TripVehicleModel>();
            lstTVehicle = objService.getTripVehicleByTID(id);
            objModel.lstTVehicle = new List<TripVehicleModel>();
            objModel.lstTVehicle.AddRange(lstTVehicle);

            List<VehicleTypeModel> lstVType = new List<VehicleTypeModel>();
            lstVType = objService.getActiveVType();
            objModel.ListVType = new List<VehicleTypeModel>();
            objModel.ListVType.AddRange(lstVType);
            ViewBag.Menuid = Request.QueryString["menuId"];
            return View(objModel);
        }
        public ActionResult Staff(int id)
        {
            List<TripModel> lstTrip = new List<TripModel>();
            objModel = objService.getByID(id);
            return View(objModel);
        }
        public ActionResult Customer(int id)
        {
            List<TripModel> lstTrip = new List<TripModel>();
            objModel = objService.getByID(id);
            return View(objModel);
        }
        public ActionResult AssignVehicle(int? id)
        {
            List<TripModel> lstTrip = new List<TripModel>();
            objModel = objService.getByID(id);

            List<TripVehicleModel> lstTVhcl = new List<TripVehicleModel>();

            return View(objModel);
        }
        public ActionResult getTripByDate(string date)
        {
            List<TripModel> lstVhcl = new List<TripModel>();
            TripModel objModel = new TripModel();
            DateTime ddt = Convert.ToDateTime(date);

            lstVhcl = objService.getTripToAssignVehicle(ddt);
            objModel.ListTrip = new List<TripModel>();
            objModel.ListTrip.AddRange(lstVhcl);
            return PartialView("_Assign", objModel.ListTrip);
            //return Json(objModel, JsonRequestBehavior.AllowGet);
        }
    }
}
