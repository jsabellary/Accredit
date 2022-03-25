using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accredit.Models
{    public class Repo
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Uri Url { get; set; }
        public int stargazers_count { get; set; }
    }
}