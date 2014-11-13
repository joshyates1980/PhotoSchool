namespace PhotoSchool.Controllers
{
    using Microsoft.AspNet.Identity;
    using PhotoSchool.Data;
    using PhotoSchool.Models;
    using System;
    using System.Web.Mvc;

    public abstract class BaseController : Controller
    {
        private ApplicationUser currentUser;

        public BaseController(IPhotoSchoolData data)
        {
            this.Data = data;
        }

        protected IPhotoSchoolData Data { get; set; }

        public ApplicationUser CurrentUser
        {
            get
            {
                if (this.currentUser == null)
                {
                    var userId = User.Identity.GetUserId();
                    var user = this.Data.Users.GetById(int.Parse(userId));
                    this.currentUser = user;
                }

                return this.currentUser;
            }
            set
            {
                this.currentUser = value;
            }
        }
    }
}