using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Accredit.Models
{
    public class User
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public Uri avatar_url { get; set; }
        public Uri repos_url { get; set; }
        public List<Repo> Repos { get; set; }
    }

}