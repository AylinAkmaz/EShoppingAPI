using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Entity.DTO.Category
{
    public class CategoryDTOResponse : CategoryDTOBase
    {
        public CategoryDTOResponse()
        {
            this.GUID = Guid.NewGuid();
        }

        public Guid GUID { get; set; }
        public bool? IsActive { get; set; }

    }
}
