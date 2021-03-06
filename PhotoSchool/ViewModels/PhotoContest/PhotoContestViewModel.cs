﻿namespace PhotoSchool.ViewModels.PhotoContest
{
    using PhotoSchool.Web.Infrastructure.Mapping;
    using PhotoSchool.Models;
    using System;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class PhotoContestViewModel: IMapFrom<PhotoContest>
    {
        [HiddenInput(DisplayValue = false)]
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime? Start { get; set; }

        public DateTime? Finish { get; set; }

        public virtual ICollection<Photo> Photos { get; set; }

        public virtual ICollection<ApplicationUser> Participants { get; set; } 
    }
}