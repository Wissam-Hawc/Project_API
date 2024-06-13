using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trendit_Project_Web.Models.Dto;

namespace Trendit_Project_Web.Models.VM
{
    public class VillaNumberDeleteVM
    {
        public VillaNumberDeleteVM()
        {
            VillaNumber = new VillaNumberDTO();
        }
        public VillaNumberDTO VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; }
    }
}
