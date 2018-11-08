using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using RestaurantManagement.Models;

namespace RestaurantManagement.Controllers
{
    public class ReservationController : Controller
    {
        // GET: Reservation
        public ActionResult TableDetailsShow()
        {

            RestaurantEntities db = new RestaurantEntities();
            List<Table_Details> table_details = db.Table_Details.ToList();

            List<TableDetails> list = table_details.Select(x => new TableDetails
            {
                Table_Id = x.Table_Id,
                Capacity = x.Capacity

            }).ToList();

            return View(list);
        }

        public ActionResult ViewTableCart()
        {
            return View("TableCart");
        }

        public ActionResult TableCart(int Id)
        {
           // int Id = Int32.Parse(id);
            RestaurantEntities db = new RestaurantEntities();

            if (Session["table"] == null)
            {
                Table_Details item = db.Table_Details.SingleOrDefault(x => x.Table_Id == Id);
                List<TableCartCreateViewModel> list = new List<TableCartCreateViewModel>();

                list.Add(new TableCartCreateViewModel { Table_Id=item.Table_Id, Capacity=item.Capacity });
                Session["table"] = list;

            }
            else
            {
                List<TableCartCreateViewModel> list = (List<TableCartCreateViewModel>)Session["table"];
                bool f = true;
                foreach(var item in list)
                {
                    if(item.Table_Id==Id)
                    {
                        f = false;
                        break;
                    }
                }

                if(f==true)
                {
                    Table_Details item = db.Table_Details.SingleOrDefault(x => x.Table_Id == Id);
                    list.Add(new TableCartCreateViewModel { Table_Id = item.Table_Id, Capacity = item.Capacity });
                    Session["table"] = list;
                }
            }

                return View();
        }



        public ActionResult DeleteCartTableItem(int id)
        {
            int indx = 0;
            List<TableCartCreateViewModel> list = (List<TableCartCreateViewModel>)Session["table"];

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].Table_Id == id)
                {
                    indx = i;
                    break;
                }
            }

            list.RemoveAt(indx);

            int sz = list.Count;


            if (sz > 0)
            {
                Session["table"] = list;
            }
            else
            {
                Session["table"] = null;

            }
            return View("TableCart");
        }

        public ActionResult MakeReservation(string date, string Stime, string Etime)
        {

            if (Session["UserId"] == null)
            {
                return View("~/Views/HomePage/Login.cshtml");

            }
            else if(Session["table"] != null && date!="" && Stime!="" && Etime!="" && date!=null)
            {
                RestaurantEntities db = new RestaurantEntities();
                List<TableCartCreateViewModel> list = (List<TableCartCreateViewModel>)Session["table"];

                Table_Cart_Make tc = new Table_Cart_Make();
                tc.Customer_Id = (int)Session["UserId"];
                tc.Status = "Pending";
                tc.Date = date;
                tc.Start_time = Stime;
                tc.End_Time = Etime;

                db.Table_Cart_Make.Add(tc);
                db.SaveChanges();

                int TableCartId = db.Table_Cart_Make.Max(x => x.Table_Cart_Id);

                foreach(var item in list)
                {
                    Table_Reservation tr = new Table_Reservation();
                    tr.Table_Cart_id = TableCartId;
                    tr.Table_Id = item.Table_Id;

                    db.Table_Reservation.Add(tr);
                    db.SaveChanges();

                }

                Session["table"] = null;

            }

            List<ReservationOverViewModel> list2 = getAllReservation();

            //return View("~/Views/HomePage/Index.cshtml");
            return View("ShowAllReservation",list2);
        }


        public ActionResult ShowAllReservation()
        {

            if (Session["UserId"] == null)
            {
                return View("~/Views/HomePage/Login.cshtml");

            }

            List<ReservationOverViewModel> list = getAllReservation();



            return View(list);
        }

        public ActionResult ReservationDetails(int Id)
        {
            if (Session["UserId"] == null)
            {
                return View("~/Views/HomePage/Login.cshtml");

            }

            RestaurantEntities db = new RestaurantEntities();

            int cuId = (int)Session["UserId"];
            List<Table_Reservation> tableRelist = db.Table_Reservation.ToList();
            

            List<TableReservationDetailsViewModel> list = tableRelist.Where(x => x.Table_Cart_id == Id).Select(x => new TableReservationDetailsViewModel
            {
                Reservation_id =x.Reservation_id,
                Table_Cart_id=x.Table_Cart_id,
                Table_Id = x.Table_Id,
                Capacity = db.Table_Details.SingleOrDefault(xx => xx.Table_Id == x.Table_Id).Capacity
            }).ToList();

            return View(list);
        }

        public List<ReservationOverViewModel> getAllReservation()
        {
           // List<ReservationOverViewModel> list = new List<ReservationOverViewModel>();

            RestaurantEntities db = new RestaurantEntities();

            int cuId = (int)Session["UserId"];
            List<Table_Cart_Make> tablecartList = db.Table_Cart_Make.ToList();

            List<ReservationOverViewModel> list = tablecartList.Where(x => x.Customer_Id == cuId).Select(x => new ReservationOverViewModel
            {
                Table_Cart_Id = x.Table_Cart_Id,
                Customer_Id=cuId,
                Status= x.Status,
                Date = x.Date,
                Start_time=x.Start_time,
                End_Time = x.End_Time

            }).ToList();

            return list;
        }





        public ActionResult SiteMenuTest()
        {
            return View();
        }




    }

}