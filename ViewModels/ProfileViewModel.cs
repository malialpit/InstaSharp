using InstaSharp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InstaSharp.ViewModels
{
    public class ProfileViewModel
    {
        public ApplicationUser User { get; set; }

        public int PostCount { get; set; }

        public int FollowerCount { get; set; }

        public int FollowingCount { get; set; }

        public bool Following { get; set; }

        public bool OwnProfile { get; set; }

    }
}