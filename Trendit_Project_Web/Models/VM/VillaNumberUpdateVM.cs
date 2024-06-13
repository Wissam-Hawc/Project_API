using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using Microsoft.AspNetCore.Mvc.Rendering;
using Trendit_Project_Web.Models.Dto;

namespace Trendit_Project_Web.Models.VM
{
    public class VillaNumberUpdateVM
    {
        public VillaNumberUpdateVM()
        {
            VillaNumber = new VillaNumberUpdateDTO();
        }
        public VillaNumberUpdateDTO VillaNumber { get; set; }
        [ValidateNever]
        public IEnumerable<SelectListItem> VillaList { get; set; }
    }
}
