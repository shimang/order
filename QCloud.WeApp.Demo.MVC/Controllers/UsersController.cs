using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using QCloud.WeApp.Demo.MVC.Models;
using Newtonsoft.Json;
using QCloud.WeApp.SDK.Authorization;
using System.Diagnostics;


namespace QCloud.WeApp.Demo.MVC.Controllers
{
    /// <summary>
    /// GET /user <para/>
    /// 利用建立的会话获取用户信息
    /// </summary>
    public class UsersController : Controller
    {
        private UserDBContext db = new UserDBContext();

        // GET: Users
        public ActionResult Index()
        {
            User user = new User();

            user.ID = 1;
            user.OpenID = "qweradf";
            user.NickName = "shi mang";
            user.IsValid = true;

            db.Users.Add(user);
            db.SaveChanges();
            //return null;

            return View(db.Users.ToList());
            /*try
            {
                // 使用 Request 和 Response 初始化登录服务
                LoginService loginService = new LoginService(Request, Response);

                // 调用检查登录接口，成功后可以获得用户信息，进行正常的业务请求
                UserInfo userInfo = loginService.Check();

                db.Users.Add(user);
                db.SaveChanges();

                Response.AddHeader("Content-Type", "application/json");
                // 获取会话成功，需要返回 HTTP 视图，这里作为示例返回了获得的用户信息
                return Content(JsonConvert.SerializeObject(new
                {
                    code = 0,
                    message = "OK",
                    data = new { userInfo }
                }));
            }
            catch (Exception error)
            {
                // 可以处理登录失败的情况，但是注意此时无需返回 ActionResult，
                // 因为登录失败的时候，登录服务已经输出登录失败的响应
                Debug.WriteLine(error);
                return null;
            }*/
        }

        // GET: Users/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: Users/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Users/Create
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,OpenID,NickName,IsValid")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: Users/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Edit/5
        // 为了防止“过多发布”攻击，请启用要绑定到的特定属性，有关 
        // 详细信息，请参阅 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,OpenID,NickName,IsValid")] User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(user);
        }

        // GET: Users/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User user = db.Users.Find(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = db.Users.Find(id);
            db.Users.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
