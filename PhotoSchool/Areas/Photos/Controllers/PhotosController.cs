﻿namespace PhotoSchool.Web.Areas.Photos.Controllers
{
    using PhotoSchool.Data.Contracts.Repository;
    using PhotoSchool.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using AutoMapper.QueryableExtensions;
    using PhotoSchool.Data;
    using System.Net;
    using PhotoSchool.Areas.Photos.ViewModels.Actions;
    using PhotoSchool.Areas.Photos.ViewModels.Comment;
    using PhotoSchool.Areas.Photos.ViewModels.Photo;
    using PhotoSchool.Web.Controllers;
    using Microsoft.AspNet.Identity;
    using PhotoSchool.Controllers;

    public class PhotosController : BaseController
    {
        private const int PageSize = 9;

        public PhotosController(IPhotoSchoolData data)
            : base(data)
        {
        }

        public ActionResult AllPhotos(int? id)
        {
            int pageNumber = id.GetValueOrDefault(1);
            var allPhotos = this.Data.Photos.All().Select(x => new PhotoViewModel
            {
                Id = x.Id,
                ShortDescription = x.ShortDescription,
                ImageUrl = x.ImageUrl
            }).OrderBy(x => x.Id);

            var photos = allPhotos.Skip((pageNumber - 1) * PageSize).Take(PageSize);
            ViewBag.Pages = Math.Ceiling((double)allPhotos.Count() / PageSize);
            //.AsQueryable().Project().To<PhotoViewModel>();
            return View(photos);
        }

        public ActionResult PhotoDetails(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var photo = this.Data.Photos.GetById(id);

            this.IncreaseViewCount(photo);
            this.Data.SaveChanges();

            var comments = photo.Comments.Select(x => new CommentViewModel
            {
                AuthorUsername = x.Author.UserName,
                CreatedOn = x.CreatedOn,
                Text = x.Text
            }).ToList();

            var actions = photo.Actions.AsQueryable().Project().To<ActionViewModel>().ToList();

            var photoModel = new PhotoViewModel
            {
                Id = photo.Id,
                ShortDescription = photo.ShortDescription,
                ImageUrl = photo.ImageUrl,
                Actions = actions,
                Comments = comments,
                Likes = photo.Likes,
                ViewCount = photo.ViewCount
            };

            var canLike = !photo.Likes.Any(x => x.AuthorId == this.CurrentUser.Id);
            ViewBag.CanLike = canLike;

            if (photo == null)
            {
                return HttpNotFound();
            }
            return View(photoModel);
        }

        
        [Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult PostComment(SubmitCommentViewModel commentModel)
        {
            if (ModelState.IsValid)
            {
                var username = this.User.Identity.GetUserName();
                var userId = this.User.Identity.GetUserId();
                var comment = new Comment()
                {
                    AuthorId = userId,
                    Text = commentModel.Comment,
                    PhotoId = commentModel.PhotoId,
                    CreatedOn = DateTime.Now
                };

                this.Data.Comments.Add(comment);
                this.Data.SaveChanges();

                var viewModel = new CommentViewModel { AuthorUsername = username, Text = comment.Text, CreatedOn = comment.CreatedOn };
                return PartialView("_CommentPartial", viewModel);
            }
            return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest, ModelState.Values.First().ToString());
        }

        public ActionResult Upvote(int id)
        {
            var userId = User.Identity.GetUserId();
            var canVote = !this.Data.Likes.All().Any(x => x.PhotoId == id && x.AuthorId == userId);
            if (canVote)
            {
                this.Data.Photos.GetById(id).Likes.Add(new Like
                {
                    PhotoId = id,
                    AuthorId = userId,
                    IsPositive = true
                });
                this.Data.SaveChanges();
            }
            var votes = this.Data.Photos.GetById(id).Likes.Where(x => x.IsPositive).Count();
            return Content(votes.ToString());
        }

        //public ActionResult Search(SubmitSearchModel submitModel)
        //{
        // var result = this.Data.Laptops.All();
        // if (!string.IsNullOrEmpty(submitModel.ModelSearch))
        // {
        // result = result.Where(x => x.Model.ToLower().Contains(submitModel.ModelSearch.ToLower()));
        // }
        // if (submitModel.ManufSearch != "All")
        // {
        // result = result.Where(x => x.Manufacturer.Name == submitModel.ManufSearch);
        // }
        // if (submitModel.PriceSearch != 0)
        // {
        // result = result.Where(x => x.Price < submitModel.PriceSearch);
        // }
        // var endResult = result.Select(x => new LaptopViewModel
        // {
        // Id = x.Id,
        // Model = x.Model,
        // Manufacturer = x.Manufacturer.Name,
        // ImageUrl = x.ImageUrl,
        // Price = x.Price
        // });
        // return View(endResult);
        //}

        private void IncreaseViewCount(Photo photo)
        {
            if (Request.Cookies["ViewedPhoto"] != null)
            {
                if (Request.Cookies["ViewedPhoto"][string.Format("rId_{0}", photo.Id)] == null)
                {
                    HttpCookie cookie = Request.Cookies["ViewedPhoto"];
                    cookie[string.Format("rId_{0}", photo.Id)] = "1";
                    cookie.Expires = DateTime.Now.AddDays(1);
                    Response.Cookies.Add(cookie);
                    photo.ViewCount += 1;
                }
            }
            else
            {
                HttpCookie cookie = new HttpCookie("ViewedPhoto");
                cookie[string.Format("rId_{0}", photo.Id)] = "1";
                cookie.Expires = DateTime.Now.AddDays(1);
                Response.Cookies.Add(cookie);
                photo.ViewCount += 1;
            }
        }
    }
}