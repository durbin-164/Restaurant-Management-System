using RestaurantManagement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RestaurantManagement.Controllers
{
    public class HomePageController : Controller
    {
        // GET: HomePage
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult SideMenu()
        {
            /* List<CategoryViewModel> list = new List<CategoryViewModel>();
             list.Add(new CategoryViewModel { Id=1,Name="Sweet"});
             list.Add(new CategoryViewModel { Id = 1, Name = "Cake" });
             list.Add(new CategoryViewModel { Id = 1, Name = "Birany" });
             list.Add(new CategoryViewModel { Id = 1, Name = "Pizza" });
             list.Add(new CategoryViewModel { Id = 1, Name = "Sup" });
             list.Add(new CategoryViewModel { Id = 1, Name = "Bargur" });*/

            RestaurantEntities db = new RestaurantEntities();
            List<Category> catlist = db.Categories.ToList();
            CategoryViewModel catVM = new CategoryViewModel();

            List<CategoryViewModel> list = catlist.Select(x => new CategoryViewModel
            {
                Id=x.Id,
                Name=x.Name

            }).ToList();


            return PartialView("SideMenu",list);
        }

        public ActionResult RightSideMenu()
        {

            return PartialView("RightSideMenu");
        }

        public ActionResult Category()
        {
            RestaurantEntities db = new RestaurantEntities();
            List<Category> catlist = db.Categories.ToList();
            CategoryViewModel catVM = new CategoryViewModel();

            List<CategoryViewModel> list = catlist.Select(x => new CategoryViewModel
            {
                Id = x.Id,
                Name = x.Name,
                image=x.image
                

            }).ToList();
            return View(list);
        }

        public ActionResult CatShow( int id)
        {
           // Console.Write(id);

            RestaurantEntities db = new RestaurantEntities();
            List<Item> catlist = db.Items.ToList();
            CategoryViewModel catVM = new CategoryViewModel();

            List<ItemViewModel> list = catlist.Where(x=>x.CatId==id).Select(x => new ItemViewModel
            {
                Id = x.Id,
                CatId=x.CatId,
                Name = x.Name,
                Price=x.Price,
                Description=x.Description,
                image=x.image
                

            }).ToList();


            return View(list);
        }

        public ActionResult DetailsItem( int id)
        {
            RestaurantEntities db = new RestaurantEntities();
            Item item = db.Items.SingleOrDefault(x => x.Id == id);
            ItemViewModel itemVM = new ItemViewModel();
            
            itemVM.Id = item.Id;
            itemVM.CatId = item.CatId;
            itemVM.Name = item.Name;
            itemVM.Price = item.Price;
            itemVM.Description = item.Description;
            itemVM.image = item.image;

            return View(itemVM);
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public JsonResult LoginCustomer(RegistrationViewModel model)
        {
            RestaurantEntities db = new RestaurantEntities();
            Customer cu = db.Customers.SingleOrDefault(x => x.Email == model.Email && x.Password == model.Password);
            String result = "fail";
            if(cu!=null)
            {
                Session["UserId"] = cu.Id;
                Session["UserName"] = cu.Name;
                result = "Success";

            }
           

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public ActionResult LogOut()
        {
            //Session.Clear();
            //Session.Abandon();
            Session.Remove("UserId");
            Session.Remove("UserName");

            return RedirectToAction("Login");
        }

        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistrationCustomer(RegistrationViewModel model)
        {
            RestaurantEntities db = new RestaurantEntities();

            Customer cu = new Customer();
            cu.Name = model.Name;
            cu.Password = model.Password;
            cu.Email = model.Email;
            cu.Phone = model.Phone;
            cu.Address = model.Address;

            db.Customers.Add(cu);
            db.SaveChanges();

            if (model !=null)
            {
                int CId = db.Customers.Max(x => x.Id);
                Customer custo = db.Customers.SingleOrDefault(x => x.Id == CId);
                Session["UserId"] = custo.Id;
                Session["UserName"] = custo.Name;
                

            }


            return View("Index");
        }

        public ActionResult ShopingCartView()
        {
            return View("ShopingCart");
        }

        public ActionResult ShopingCart(string quentity, string Id)
        {
            if (quentity == null|| quentity=="") quentity = "1";
            RestaurantEntities db = new RestaurantEntities();
            try
            {
                int itemId = Int32.Parse(Id);
                int Qnty = Int32.Parse(quentity);
                Item item = db.Items.SingleOrDefault(x => x.Id == itemId);
                ItemViewModel itemVM = new ItemViewModel();
                itemVM.Id = item.Id;
                itemVM.Name = item.Name;
                itemVM.Price = item.Price;
                itemVM.CatId = item.CatId;
                itemVM.Description = item.Description;

                if (Session["cart"] == null)
                {
                    List<CartCreateViewModel> list = new List<CartCreateViewModel>();

                    list.Add(new CartCreateViewModel { ItemId = item.Id, ItemName = item.Name, Quentity = Qnty, Tot_price = item.Price * Qnty });
                    Session["cart"] = list;

                }
                else
                {
                    List<CartCreateViewModel> list = (List<CartCreateViewModel>)Session["cart"];

                    int sz = list.Count;

                    int flag = 0;
                    int indx = 0;
                    for (int i = 0; i < sz; i++)
                    {
                        if (list[i].ItemId == item.Id)
                        {
                            flag = 1;
                            indx = i;
                            break;
                        }
                    }

                    if (flag == 1)
                    {
                        list[indx].Quentity += Qnty;
                        list[indx].Tot_price = item.Price * list[indx].Quentity;
                    }
                    else
                    {
                        list.Add(new CartCreateViewModel { ItemId = item.Id, ItemName = item.Name, Quentity = Qnty, Tot_price = item.Price * Qnty });
                    }


                    Session["cart"] = list;

                }

            }catch(Exception ex)
            {
               
            }
            


            return View();
        }

        public ActionResult DeleteCartItem(int id)
        {

            int indx=0;
            List<CartCreateViewModel> list = (List<CartCreateViewModel>)Session["cart"];

            for(int i=0;i<list.Count;i++)
            {
                if(list[i].ItemId==id)
                {
                    indx = i;
                    break;
                }
            }

            list.RemoveAt(indx);

            int sz = list.Count;


            if (sz > 0)
            {
                Session["cart"] = list;
            }
            else
            {
                Session["cart"] = null;

            }
            



            return View("ShopingCart");
        }

        public ActionResult LogInValidityChacek()
        {
            if(Session["UserId"]==null)
            {
                return View("Login");

            }

            return View();
        }



        [HttpPost]
        public ActionResult MakeOrder( CartModel model)
        {
            String place = model.online_Onplase;
            

            if (Session["UserId"] == null)
            {
                return View("Login");

            }

            if (Session["cart"] != null)
            {
                RestaurantEntities db = new RestaurantEntities();
                List<CartCreateViewModel> list = (List<CartCreateViewModel>)Session["cart"];

                String Address = model.Address;

                if(Address=="" || Address==null)
                {
                    int cuId = (int)Session["UserId"];
                    Customer cust = db.Customers.SingleOrDefault(x => x.Id == cuId);
                    Address = cust.Address;
                }
               
                
                decimal totalPrice = 0;
                foreach( var item in list)
                {
                    totalPrice += item.Tot_price;

                }

                Cart cc = new Cart();
                cc.Cu_id = (int)Session["UserId"];
                cc.Tot_price = totalPrice;
                cc.Status = "Pending";
                cc.online_Onplase = place;
                cc.Address = Address;
                cc.Date = DateTime.Now;
               // cc.Time= DateTime.Now;

                db.Carts.Add(cc);
                db.SaveChanges();
                int lstCId = db.Carts.Max(x => x.Cart_id);


                foreach (var item in list)
                {

                   
                    Order_Details or = new Order_Details();

                    or.Cart_id = lstCId;
                    or.Item_id = item.ItemId;
                    or.Quentity = item.Quentity;
                    or.Price = item.Tot_price;

                    db.Order_Details.Add(or);
                    db.SaveChanges();

                }

                Session["cart"] = null;



            }

            List<CartViewModel> listOrder = getAllOrderCart();



            return View("ShowAllOrder",listOrder);
        }


        public ActionResult ShowAllOrder()
        {
            if (Session["UserId"] == null)
            {
                return View("Login");

            }

            

            List<CartViewModel> list = getAllOrderCart();


           /* RestaurantEntities db = new RestaurantEntities();
            List<Order_Details> ordertList = db.Order_Details.ToList();
            List<OrderShowViewModel> list = new List<OrderShowViewModel>();

            foreach(var item in Cu_cartList)
            {
                List<Order_Details> Olist = ordertList.Where(x => x.Cart_id == item.Cart_id).Select(x => new Order_Details
                {
                    Order_id=x.Order_id,
                    Cart_id=x.Cart_id,
                    Item_id=x.Item_id,
                    Quentity=x.Quentity,
                    Price=x.Price

                }
                ).ToList();

                foreach( var itm in Olist)
                {
                    Item itttm = db.Items.SingleOrDefault(x => x.Id == itm.Item_id);
                    list.Add(new OrderShowViewModel
                    {
                        Item_id=itm.Item_id,
                        Item_name=itttm.Name,
                        Quentity=itm.Quentity,
                        Price=itm.Price,
                        Status=item.Status,
                        online_Onplase=item.online_Onplase,
                        Date=item.Date
                    });
                    
                }
            }*/




            return View(list);
        }

        public ActionResult ShowOneOrderDeatails(int Id)
        {
            if (Session["UserId"] == null)
            {
                return View("Login");

            }

            RestaurantEntities db = new RestaurantEntities();
            List<Order_Details> ordertList = db.Order_Details.ToList();
            //List<OrderShowViewModel> list = new List<OrderShowViewModel>();
            Cart cart = db.Carts.SingleOrDefault(x => x.Cart_id == Id);
            

            List<OrderShowViewModel> list = ordertList.Where(x => x.Cart_id == Id).Select(x => new OrderShowViewModel
            {
               Oder_id=x.Order_id,
               Item_id=x.Item_id,
               Item_name=db.Items.SingleOrDefault(xx => xx.Id == x.Item_id).Name,
               Quentity=x.Quentity,
               Address=cart.Address,
               Price=x.Price,
               Date= db.Carts.SingleOrDefault(xx => xx.Cart_id == Id).Date

            }).ToList();



            return View(list);
        }



        public List<CartViewModel> getAllOrderCart()
        {
            
            RestaurantEntities db = new RestaurantEntities();

            int cuId = (int)Session["UserId"];
            List<Cart> cartList = db.Carts.ToList();

            List<CartViewModel> list = cartList.Where(x => x.Cu_id == cuId).Select(x => new CartViewModel
            {
                Cart_id = x.Cart_id,
                Cu_id = x.Cu_id,
                Tot_price = x.Tot_price,
                Status = x.Status,
                online_Onplase = x.online_Onplase,
                Date = x.Date,
                Time = x.Time

            }).ToList();


            return list;
        }




        public ActionResult AboutUS()
        {
            return View();
        }

        public ActionResult ContactUS()
        {
            return View();
        }




        public ActionResult TestCat()
        {
            return View();
        }

       /* public JsonResult GetCategory()
        {
            RestaurantEntities db = new RestaurantEntities();

            var cat = db.Categories.FirstOrDefault();
            return Json(cat, JsonRequestBehavior.AllowGet);
        }*/


        public ActionResult SiteMenuTest()
        {
            return View();
        }

        public ActionResult TestDifferentThing( string txtName,string Id)
        {
            //ViewBag.Name = txtName;
            return View();
        }



    }
}