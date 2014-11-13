using PhotoSchool.Data;
using PhotoSchool.ViewModels.Actions;
using PhotoSchool.ViewModels.PhotoContest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PhotoSchool.Controllers
{
    public class PhotoContestController : BaseController
    {
        public PhotoContestController(IPhotoSchoolData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult AllContests()
        {
            var contests = this.Data.PhotoContests.All().Select(x => new PhotoContestViewModel
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                Start = x.Start,
                Finish = x.Finish,
                Participants = x.Participants,
                Photos = x.Photos
            }).OrderBy(x => x.Start);
            ;
            return View(contests);
        }

        public ActionResult ContestDetails(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var contest = this.Data.PhotoContests.GetById(id);

            var contestModel = new PhotoContestViewModel
            {
                Id = contest.Id,
                Title = contest.Title,
                Description = contest.Description,
                Start = contest.Start,
                Finish = contest.Finish,
                Participants = contest.Participants,
                Photos = contest.Photos
            };

            if (this.CurrentUser != null)
            {
                var canJoin = !contest.Participants.Any(x => x.Id == this.CurrentUser.Id);
                ViewBag.CanJoin = canJoin;
            }
            else
            {
                ViewBag.CanJoin = false;
            }

            if (contest == null)
            {
                return HttpNotFound();
            }

            return View(contestModel);
        }

        public ActionResult Join(int id)
        {
            var contest = this.Data.PhotoContests.GetById(id);

            var canJoin = !contest.Participants.Any(x => x.Id == this.CurrentUser.Id);

            if (canJoin)
            {
                contest.Participants.Add(this.CurrentUser);

                this.Data.SaveChanges();
            }

            return PartialView("_ContestParticipantsPartial", this.CurrentUser);
        }
    }
}