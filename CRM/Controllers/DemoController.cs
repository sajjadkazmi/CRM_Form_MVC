using CRM.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CRM.Controllers
{
    public class DemoController : Controller
    {
        // GET: Demo

        CRMEntities db = new CRMEntities();
        [HttpGet]
        public ActionResult Index()
        {
            List<ADM_DEF_BUS_TYPE> BussTypeList = db.ADM_DEF_BUS_TYPE.ToList();
            ViewBag.busstypelist = new SelectList(BussTypeList, "CODE", "DESC");

            List<ADM_DEF_BRANCH> BranchList = db.ADM_DEF_BRANCH.ToList();
            ViewBag.branhlist = new SelectList(BranchList, "CODE", "DESC");

            List<ADM_DEF_CLIENT_TYPE> ClientTypeList = db.ADM_DEF_CLIENT_TYPE.ToList();
            ViewBag.clientypelist = new SelectList(ClientTypeList, "CODE", "DESC");

            List<ADM_DEF_ACC_MGR> AccManagrList = db.ADM_DEF_ACC_MGR.ToList();
            ViewBag.AccManagerlist = new SelectList(AccManagrList, "CODE", "NAME");
            

            return View();
        }
        [HttpPost]
        public ActionResult Index(ADM_CLIENT adm)
        {
            List<ADM_DEF_BUS_TYPE> BussTypeList = db.ADM_DEF_BUS_TYPE.ToList();
            ViewBag.busstypelist = new SelectList(BussTypeList, "CODE", "DESC");

            List<ADM_DEF_BRANCH> BranchList = db.ADM_DEF_BRANCH.ToList();
            ViewBag.branhlist = new SelectList(BranchList, "CODE", "DESC");

            List<ADM_DEF_CLIENT_TYPE> ClientTypeList = db.ADM_DEF_CLIENT_TYPE.ToList();
            ViewBag.clientypelist = new SelectList(ClientTypeList, "CODE", "DESC");

            List<ADM_DEF_ACC_MGR> AccManagrList = db.ADM_DEF_ACC_MGR.ToList();
            ViewBag.AccManagerlist = new SelectList(AccManagrList, "CODE", "NAME");

            string connetionString = "Data Source=DESKTOP-CIU4K2F;Initial Catalog=CRM;Integrated Security=True;MultipleActiveResultSets=True";
     
            using (SqlConnection con = new SqlConnection(connetionString))
            {
                string query = "  insert into ADM_CLIENT (TRAN_CODE,TRAN_DATE,NAME,ADDRESS,EMAIL,PHONE,CNIC,BUS_TYPE,CLIENT_TYPE,BRANCH,MARKET_MANAGER)  values ('2',@TRAN_DATE,@Name,@ADDRESS,@EMAIL,@PHONE,@CNIC,@BUS_TYPE,@CLIENT_TYPE,@BRANCH,@MARKET_MANAGER)";
                query += " SELECT SCOPE_IDENTITY()";
                using (SqlCommand cmd = new SqlCommand(query))
                {
                    cmd.Connection = con;
                    con.Open();
                    cmd.Parameters.AddWithValue("@TRAN_DATE", adm.TRAN_DATE);
                    cmd.Parameters.AddWithValue("@Name", adm.NAME);
                    cmd.Parameters.AddWithValue("@ADDRESS", adm.ADDRESS);
                    cmd.Parameters.AddWithValue("@EMAIL", adm.EMAIL);
                    cmd.Parameters.AddWithValue("@PHONE", adm.PHONE);
                    cmd.Parameters.AddWithValue("@CNIC", adm.CNIC);

                    cmd.Parameters.AddWithValue("@BUS_TYPE", adm.BUS_TYPE);
                    cmd.Parameters.AddWithValue("@CLIENT_TYPE", adm.CLIENT_TYPE);
                    cmd.Parameters.AddWithValue("@BRANCH", adm.BRANCH);
                    cmd.Parameters.AddWithValue("@MARKET_MANAGER", adm.MARKET_MANAGER);

                    //cmd.Parameters.AddWithValue("@TRAN_CODE", 4);

                    //adm.TRAN_CODE= Convert.ToInt32(cmd.ExecuteScalar());
                    cmd.ExecuteScalar();


                    con.Close();
                }
            }
            return View();
            //List<ADM_DEF_BUS_TYPE> BussTypeList = db.ADM_DEF_BUS_TYPE.ToList();
            //ViewBag.busstypelist = new SelectList(BussTypeList, "CODE", "DESC");

            //List<ADM_DEF_BRANCH> BranchList = db.ADM_DEF_BRANCH.ToList();
            //ViewBag.branhlist = new SelectList(BranchList, "CODE", "DESC");

            //List<ADM_DEF_CLIENT_TYPE> ClientTypeList = db.ADM_DEF_CLIENT_TYPE.ToList();
            //ViewBag.clientypelist = new SelectList(ClientTypeList, "CODE", "DESC");

            //List<ADM_DEF_ACC_MGR> AccManagrList = db.ADM_DEF_ACC_MGR.ToList();
            //ViewBag.AccManagerlist = new SelectList(AccManagrList, "CODE", "NAME");


            //ADM_CLIENT Client = new ADM_CLIENT();
            //Client.NAME = adm.NAME;
            //Client.ADDRESS = adm.ADDRESS;
            //Client.TRAN_DATE = System.DateTime.Now;
            //Client.PHONE = adm.PHONE;
            //Client.EMAIL = adm.EMAIL;
            //Client.CNIC = adm.CNIC;

            //db.ADM_CLIENT.Add(Client);
            //db.SaveChanges();


        }
    }
}