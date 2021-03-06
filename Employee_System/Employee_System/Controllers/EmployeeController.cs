﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EMSDomain.Model;
using EMSDomain.ViewModel;
using EMSDomain.ViewModel.Branch;
using EMSDomain.ViewModel.Company;
using EMSDomain.ViewModel.Employee;
using EMSMethods;

namespace Employee_System.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeEntities db = new EmployeeEntities();
        public ActionResult IDCard(int id)
        {
            EmployeeService objmethod = new EmployeeService();
            EmployeeItem objmaster = new EmployeeItem();
            objmaster = objmethod.getEmpByID(id);
            return View(objmaster);
        }
        public ActionResult getData(int id)
        {
            EmployeeService objmethod = new EmployeeService();
            EmployeeItem objmaster = new EmployeeItem();
            objmaster = objmethod.GetById(id);

            List<EmployeeItem> lstmasterp = new List<EmployeeItem>();
            objmaster.EmployeeList = new List<EmployeeItem>();
            objmaster.EmployeeList.AddRange(lstmasterp);

            List<CompanyItem> objCompany = new List<CompanyItem>();
            CompanyService objListCompany = new CompanyService();

            objCompany = objListCompany.GetALL();

            EmployeeItem objEmpItem = new EmployeeItem();
            objEmpItem.CompanyList = new List<CompanyItem>();
            objEmpItem.CompanyList.AddRange(objCompany);
            ViewBag.data = objEmpItem;
            return PartialView("_DataList", objmaster.EmployeeList);

        }
        public ActionResult GetBranch(int compid)
        {
            var cities = db.Branch_master.Where(c => c.CompID == compid);
            return Json(cities, JsonRequestBehavior.AllowGet);
        }


        //
        // GET: /Employee/

        // For Details Contacts
        public ActionResult EmpContactIndex()
        {
            return View();
        }

        //This is the default index controller in which we can return all employees
        public ActionResult Index(EmpAllItem model)
        {

            EmpAllItem objAllItem = new EmpAllItem();
            EmployeeService objclsmethod = new EmployeeService();
            //int mid = Convert.ToInt32(Request.QueryString["Compid"]);
            int cid = 0;
            if (model.EmployeeItem == null)
            {
                int id = 0;
                if (Url.RequestContext.RouteData.Values["id"] != null)
                {
                    id = Convert.ToInt32(Url.RequestContext.RouteData.Values["id"].ToString());
                    ViewBag.Empid = id;
                }
                
                if (Session["CompID"] != null)
                {
                    cid = Convert.ToInt32(Session["CompID"].ToString());
                }
                List<EmployeeItem> objMaster = objclsmethod.GetALL(cid);
                List<EmpAllItem> ObjEmpAllItem = objclsmethod.GetALLDetails(0,cid);

                List<CompanyItem> objCompany = new List<CompanyItem>();
                CompanyService objListCompany = new CompanyService();
                objCompany = objListCompany.GetALL();

                EmployeeItem objEmpItem = new EmployeeItem();
                objEmpItem.CompanyList = new List<CompanyItem>();
                objEmpItem.CompanyList.AddRange(objCompany);

                //Added by Kuldip Patel @07-06-2016
                #region Bind RDB Working Status
                List<clsMasterData> lstMasters1 = new List<clsMasterData>();
                EmployeeService objclsmethod1 = new EmployeeService();
                lstMasters1 = objclsmethod1.GetWorkingStatus();

                EmployeeItem objItem = new EmployeeItem();
                objEmpItem.listMasterWS = new List<clsMasterData>();
                objEmpItem.listMasterWS.AddRange(lstMasters1);

                #endregion


                objAllItem.EmployeeItem = objEmpItem;
                objAllItem.EmployeeALLDetails = new List<EmpAllItem>();
                objAllItem.EmployeeALLDetails.AddRange(ObjEmpAllItem);
                

                return View(objAllItem);
            }
            else if (model.EmployeeItem != null)
            {
                if (model.EmployeeItem.Compid != null)
                {
                    int i = Convert.ToInt32(model.EmployeeItem.Compid);
                    List<EmpAllItem> objEmAll = new List<EmpAllItem>();
                    objEmAll = objclsmethod.GetALLDetails(0,cid);

                    List<CompanyItem> objCompany = new List<CompanyItem>();
                    CompanyService objListCompany = new CompanyService();
                    objCompany = objListCompany.GetALL();

                    EmployeeItem objEmpItem = new EmployeeItem();
                    objEmpItem.CompanyList = new List<CompanyItem>();
                    objEmpItem.CompanyList.AddRange(objCompany);

                    //Added by Kuldip Patel @07-06-2016
                    #region Bind RDB Working Status
                    List<clsMasterData> lstMasters1 = new List<clsMasterData>();
                    EmployeeService objclsmethod1 = new EmployeeService();
                    lstMasters1 = objclsmethod1.GetWorkingStatus();

                    EmployeeItem objItem = new EmployeeItem();
                    objEmpItem.listMasterWS = new List<clsMasterData>();
                    objEmpItem.listMasterWS.AddRange(lstMasters1);

                    #endregion

                    objAllItem.EmployeeItem = objEmpItem;
                    objAllItem.EmployeeALLDetails = new List<EmpAllItem>();
                    objAllItem.EmployeeALLDetails.AddRange(objEmAll);                   
                    return View(objAllItem);
                }


            }
           
            return RedirectToAction("Index");

        }

        //public ActionResult Index(int employeeId) 
        //{
        //    //Using this parameter we have to use employee id instead of session to remove concurrency conflict because for each update of details route will be lie
        //    // ConterollerName/ActionName/EmployeeId 
        //    //Any question?
        //    return new RedirectResult("DashboardController/{EmployeeId}");

        //}

        public ActionResult Create()
        {
            // For Bind Company 
            #region Company Bind
            List<CompanyItem> objCompany = new List<CompanyItem>();
            CompanyService objListCompany = new CompanyService();
            objCompany = objListCompany.GetALL();

            EmployeeItem objEmpItem = new EmployeeItem();
            objEmpItem.CompanyList = new List<CompanyItem>();
            objEmpItem.CompanyList.AddRange(objCompany);

            #endregion

            //For Bind Branch 
            #region  Bind Branch
            List<BranchItem> objbranchitm = new List<BranchItem>();
            BranchService objbranchservice = new BranchService();
            objbranchitm = objbranchservice.GetAll();

            //objEmpItem = new EmployeeItem();
            objEmpItem.BranchList = new List<BranchItem>();
            objEmpItem.BranchList.AddRange(objbranchitm);

            EmpAllItem objAllItem = new EmpAllItem();
            objAllItem.EmployeeItem = objEmpItem;
            #endregion
            //var tuple = new Tuple<EmployeeItem, EmpRelativeItem>(objEmpItem, new EmpRelativeItem());

            //For Bind CountryList
            EmpContactItem objContact = new EmpContactItem();
            EmployeeService objServiceEmp = new EmployeeService();
            #region Country Bind
            List<CountryItem> objCountry = new List<CountryItem>();
            objServiceEmp = new EmployeeService();
            objCountry = objServiceEmp.CountryList();
            objContact = new EmpContactItem();
            objContact.CountryList = new List<CountryItem>();
            objContact.CountryList.AddRange(objCountry);
            objAllItem.EmpContactItem = objContact;
            #endregion


            //bind Jobtitle
            #region Bind DropDown Jobtitle
            List<clsMasterData> lstMasters1 = new List<clsMasterData>();
            EmployeeService objclsmethod = new EmployeeService();
            lstMasters1 = objclsmethod.GetJobTitle();

            EmployeeItem objItem = new EmployeeItem();
            objAllItem.listMaster = new List<clsMasterData>();
            objAllItem.listMaster.AddRange(lstMasters1);

            #endregion
            // For bind Relation
            #region Relation Bind
            //objContact = new EmpContactItem();
            //objServiceEmp = new EmployeeService();
            //List<MasterDataItem> objMasterDataListR = new List<MasterDataItem>();
            //objMasterDataListR = objServiceEmp.GetMasterData(35);

            #endregion


            return View(objAllItem);
        }



        [HttpPost]
        public ActionResult Create(EmpAllItem model)
        {

            EmployeeService objEmpService = new EmployeeService();
            model.EmployeeItem.WorkingStatus = 96;
            if (model.EmployeeItem.Branchid == null)
            {
                model.EmployeeItem.Branchid = 0;
            }
            if (model.EmployeeItem != null)
            {
                HttpPostedFileBase file = Request.Files["file"];
                var fileName = Path.GetFileName(file.FileName);
                if (fileName != "")
                {
                    var path = Path.Combine(Server.MapPath("../PhotoUpload"), fileName);
                    file.SaveAs(path);
                    model.EmployeeItem.Photo = fileName;
                }
            }
            string uid = null;
            if (Session["UserId"] != null)
            {
                uid = Session["UserId"].ToString();
            }
            model.EmployeeItem.CreatedDate = System.DateTime.Now;
            model.EmployeeItem.CreatedBy = uid;
            int cid = 0;
            if (Session["CompID"] != null)
            {
                cid = Convert.ToInt32(Session["CompID"].ToString());
            }
            if (model.EmployeeItem.Compid == null)
            {
                model.EmployeeItem.Compid = cid;
            }
            int p = objEmpService.Insert(model);


            return RedirectToAction("Index", "Employee");

            //ModelState.AddModelError("", "");
            //  return RedirectToAction("Create", "Employee");



        }
        //[HttpPost]
        //public ActionResult Create(EmployeeItem model)
        //{
        //    if (model.Empname != null)
        //    {
        //        EmployeeService objEmpService = new EmployeeService();

        //        HttpPostedFileBase file = Request.Files["file"];
        //        var fileName = Path.GetFileName(file.FileName);
        //        var path = Path.Combine(Server.MapPath("../PhotoUpload"), fileName);
        //        file.SaveAs(path);
        //        model.Photo = fileName;
        //        model.CreatedDate = System.DateTime.Now;
        //        int p = objEmpService.Insert(model);

        //        return RedirectToAction("Create", "Employee");
        //    }
        //    else
        //    {
        //        ModelState.AddModelError("", "");
        //        return RedirectToAction("Create", "Employee");
        //    }


        //}
        public ActionResult View(int id)
        {
            EmployeeService objmethod = new EmployeeService();
            EmployeeItem objmaster = new EmployeeItem();
            objmaster = objmethod.GetById(id);

            Session["PhotoId"] = objmaster.Photo;

            List<EmployeeItem> lstmasterp = new List<EmployeeItem>();
            objmaster.EmployeeList = new List<EmployeeItem>();
            objmaster.EmployeeList.AddRange(lstmasterp);

            //Added by Kuldip Patel @07-06-2016
            #region Bind RDB Working Status
            List<clsMasterData> lstMasters1 = new List<clsMasterData>();
            EmployeeService objclsmethod = new EmployeeService();
            lstMasters1 = objclsmethod.GetWorkingStatus();

            EmployeeItem objItem = new EmployeeItem();
            objmaster.listMasterWS = new List<clsMasterData>();
            objmaster.listMasterWS.AddRange(lstMasters1);

            #endregion
            #region Company Bind
            List<CompanyItem> objCompany = new List<CompanyItem>();
            CompanyService objListCompany = new CompanyService();
            objCompany = objListCompany.GetALL();


            objmaster.CompanyList = new List<CompanyItem>();
            objmaster.CompanyList.AddRange(objCompany);

            #endregion
            //For Bind Branch 
            #region  Bind Branch
            List<BranchItem> objbranchitm = new List<BranchItem>();
            BranchService objbranchservice = new BranchService();
            objbranchitm = objbranchservice.GetAll();

            //objEmpItem = new EmployeeItem();
            objmaster.BranchList = new List<BranchItem>();
            objmaster.BranchList.AddRange(objbranchitm);
            #endregion
            //ViewBag.EmpId = id;
            //EmployeeService objEMP = new EmployeeService();
            //string s;
            //s = objEMP.getEMP(id);

            //ViewBag.EmpName = s;

            EmpAllItem objAllItem = new EmpAllItem();
            objAllItem.EmployeeItem = objmaster;
            return View(objAllItem);

        }

        public ActionResult Edit(int id)
        {
            EmployeeService objmethod = new EmployeeService();
            EmployeeItem objmaster = new EmployeeItem();
            objmaster = objmethod.GetById(id);

            Session["PhotoId"] = objmaster.Photo;

            List<EmployeeItem> lstmasterp = new List<EmployeeItem>();
            objmaster.EmployeeList = new List<EmployeeItem>();
            objmaster.EmployeeList.AddRange(lstmasterp);


            #region Company Bind
            List<CompanyItem> objCompany = new List<CompanyItem>();
            CompanyService objListCompany = new CompanyService();
            objCompany = objListCompany.GetALL();


            objmaster.CompanyList = new List<CompanyItem>();
            objmaster.CompanyList.AddRange(objCompany);

            #endregion
            #region Bind RDB Working Status
            List<clsMasterData> lstMasters1 = new List<clsMasterData>();
            EmployeeService objclsmethod = new EmployeeService();
            lstMasters1 = objclsmethod.GetWorkingStatus();

            EmployeeItem objItem = new EmployeeItem();
            objmaster.listMasterWS = new List<clsMasterData>();
            objmaster.listMasterWS.AddRange(lstMasters1);

            #endregion
            #region Bind DropDown Jobtitle
            List<clsMasterData> lstMasters2 = new List<clsMasterData>();
            EmployeeService objclsmethod2 = new EmployeeService();
            lstMasters2 = objclsmethod2.GetJobTitle();


            objmaster.listMaster = new List<clsMasterData>();
            objmaster.listMaster.AddRange(lstMasters2);

            #endregion
            //For Bind Branch 
            #region  Bind Branch
            List<BranchItem> objbranchitm = new List<BranchItem>();
            BranchService objbranchservice = new BranchService();
            objbranchitm = objbranchservice.GetAll();

            //objEmpItem = new EmployeeItem();
            objmaster.BranchList = new List<BranchItem>();
            objmaster.BranchList.AddRange(objbranchitm);
            #endregion
            //ViewBag.EmpId = id;
            //EmployeeService objEMP = new EmployeeService();
            //string s;
            //s = objEMP.getEMP(id);

            //ViewBag.EmpName = s;

            EmpAllItem objAllItem = new EmpAllItem();
            objAllItem.EmployeeItem = objmaster;
            return View(objAllItem);

        }

        [HttpPost]
        public ActionResult Edit(EmpAllItem model)
        {
            EmployeeItem objmasterp = new EmployeeItem();
            EmployeeService objmasterme = new EmployeeService();

            HttpPostedFileBase file = Request.Files["file"];
            var fileName = Path.GetFileName(file.FileName);

            if (fileName != "")
            {
                var path = Path.Combine(Server.MapPath("/PhotoUpload"), fileName);
                file.SaveAs(path);
                model.EmployeeItem.Photo = fileName;
            }
            else
            {
                //if (fileName == "")
                //{
                if (Session["PhotoId"] != null)
                {
                    fileName = Session["PhotoId"].ToString();
                }

                //    var path = Path.Combine(Server.MapPath("/PhotoUpload"), fileName);
                //    file.SaveAs(path);
                    model.EmployeeItem.Photo = fileName;
                //}
            }
            string uid = null;
            if (Session["UserId"] != null)
            {
                uid = Session["UserId"].ToString();
            }
            model.EmployeeItem.UpdatedBy = uid;
            model.EmployeeItem.UpdatedDate = System.DateTime.Now;
            objmasterme.Update(model);
            //return RedirectToAction("Create");
            return RedirectToAction("Index", "Employee");

        }

        public List<EmployeeItem> BindGrid()
        {
            EmployeeService objclsmethod = new EmployeeService();
            int cid = 0;
            if (Session["CompID"] != null)
            {
                cid = Convert.ToInt32(Session["CompID"].ToString());
            }
            List<EmployeeItem> objMaster = objclsmethod.GetALL(cid);
            return objMaster;
        }
        public ActionResult FillBranch(int Compid)
        {
            //string strCompCode = Convert.ToString(Compid);
            List<BranchItem> lstBranch = new List<BranchItem>();
            BranchItem objBranchItem = new BranchItem();
            BranchService objBranchS = new BranchService();
            lstBranch = objBranchS.GetBranchByComp(Compid);
            objBranchItem.ListBranch = new List<BranchItem>();
            //objBranchItem.ListBranch.Add(new BranchItem { id = 0, BranchName = "--Select Branch--" });
            objBranchItem.ListBranch.AddRange(lstBranch);
            //var e = new { BranchItem = objBranchItem.ListBranch, EmployeeItem = objBranchItem.ListBranch };
            return Json(objBranchItem.ListBranch, JsonRequestBehavior.AllowGet);
        }
        public ActionResult FillDisCon(int FID)
        {
            //string strCompCode = Convert.ToString(Compid);
            List<EmpAllItem> lstEmp = new List<EmpAllItem>();
            EmpAllItem objEmpItem = new EmpAllItem();
            EmployeeService objEmp = new EmployeeService();
            int cid = 0;
            if (Session["CompID"] != null)
            {
                cid = Convert.ToInt32(Session["CompID"].ToString());
            }
            lstEmp = objEmp.GetALLDetails(FID,cid);
            objEmpItem.EmployeeALLDetails = new List<EmpAllItem>();
            //objBranchItem.ListBranch.Add(new BranchItem { id = 0, BranchName = "--Select Branch--" });
            objEmpItem.EmployeeALLDetails.AddRange(lstEmp);
            //var e = new { BranchItem = objBranchItem.ListBranch, EmployeeItem = objBranchItem.ListBranch };
            //return Json(objEmpItem.EmployeeALLDetails, JsonRequestBehavior.AllowGet);
            return PartialView("_ListEmp", objEmpItem.EmployeeALLDetails);
        }        
        public object masterdataItem { get; set; }
    }
}
