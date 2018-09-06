using hbehr.recaptcha;
using IndraPU.Base;
using IndraPU.Domain;
using IndraPU.Logic;
using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Web;
using System.Web.Mvc;

namespace IndraPU.Controllers
{
    public class ContactController : Controller
    {
        private ContactLogic _contactLogic = new ContactLogic();
        // GET: Contact
        [Authorize]
        public ActionResult Index()
        {
            var contacts = _contactLogic.GetAll();
            List<ContactViewModel> results = new List<ContactViewModel>();
            foreach (var item in contacts)
            {
                ContactViewModel result = new ContactViewModel() { Id = item.Id, Address = item.Address, Content = item.Content, Email = item.Email, Name = item.Name, Title = item.Title, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status };
                results.Add(result);
            }
            return View(results);
        }

        public ActionResult Public()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Public(ContactViewModel model)
        {
            string userResponse = HttpContext.Request.Params["g-recaptcha-response"];
            bool validCaptcha = ReCaptcha.ValidateCaptcha(userResponse);
            if (validCaptcha)
            {
                try
                {
                    Contact contact = new Contact() { Address = model.Address, Content = model.Content, Email = model.Email, Name = model.Name, Title = model.Title };
                    var response = _contactLogic.Create(contact);
                    if (response.IsError == true)
                    {
                        foreach (var item in response.ErrorCodes)
                        {
                            ModelState.AddModelError(string.Empty, item);
                        }
                        return View(model);
                    }
                    else
                    {
                        var msg = new MailMessage();
                        msg.To.Add(new MailAddress(ConfigurationManager.AppSettings["AdminEmail"]));
                        msg.Subject = "E-SINERGI Contact - " + model.Title;
                        msg.Body = "Dari: " +model.Email + ", Isi: " + model.Content;

                        using (var client = new SmtpClient() { })
                        {
                            client.Send(msg);
                        }
                    }

                    return RedirectToAction("ThankYouPage");
                }
                catch(Exception ex)
                {
                    return View();
                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Captcha");
                return View();
            }
        }

        public ActionResult ThankYouPage()
        {
            return View();
        }

        // GET: Contact/Details/5
        public ActionResult Details(int id)
        {
            var item = _contactLogic.GetById(id);
            ReplyViewModel result = new ReplyViewModel() { Id = item.Id, Address = item.Address, Content = item.Content, Email = item.Email, Name = item.Name, Title = item.Title, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy"), Status = item.Status, Reply = item.Reply, ReplyDate = item.RepliedDate.HasValue?  item.RepliedDate.Value.ToString("dd-MMM-yyyy hh:mm") : "", ReplyUser = item.RepliedDate.HasValue ? item.ReplyUser.FirstName + " " + item.ReplyUser.LastName : "" };

            return View(result);
        }

        // GET: Contact/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _contactLogic.GetById(id);
            ReplyViewModel result = new ReplyViewModel() { Id = item.Id, Address = item.Address, Content = item.Content, Email = item.Email, Name = item.Name, Title = item.Title, CreatedDate = item.CreatedDate.ToString("dd-MMM-yyyy hh:mm"), Status = item.Status };

            return View(result);
        }

        // POST: Contact/Edit/5
        [HttpPost]
        public ActionResult Edit(ReplyViewModel model)
        {
            try
            {
                var item = _contactLogic.GetById(model.Id);
                item.Reply = model.Reply;
                item.RepliedDate = DateTime.Now;
                item.Status = Constant.ContactStatus.REPLIED;
                var response = _contactLogic.Edit(item);
                if (response.IsError == true)
                {
                    foreach (var error in response.ErrorCodes)
                    {
                        ModelState.AddModelError(string.Empty, error);
                    }
                    return View(model);
                }
                else
                {
                    var msg = new MailMessage();
                    msg.To.Add(new MailAddress(item.Email));
                    msg.Subject = "E-SINERGI Admin";
                    msg.IsBodyHtml = true;
                    msg.Body = "Isi kontak anda: <br />" + model.Content + "<br />Balasan: <br />" + model.Reply;

                    using (var client = new SmtpClient() { })
                    {
                        client.Send(msg);
                    }
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Contact/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Contact/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
