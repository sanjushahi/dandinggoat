﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace DancingGoat.Areas.Admin.Models
{
    public class ProjectIdViewModel
    {
        [Display(Name = "Custom project ID")]
        public string OwnProjectId { get; set; }
    }
}