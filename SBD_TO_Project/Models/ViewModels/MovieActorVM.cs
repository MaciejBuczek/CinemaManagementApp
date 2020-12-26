using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SBD_TO_Project.Models.ViewModels
{
    public class MovieActorVM
    {
        public int IdMovie { get; set; }

        public List<CheckBoxItem> ActorCheckBoxList { get; set; }
    }
}
