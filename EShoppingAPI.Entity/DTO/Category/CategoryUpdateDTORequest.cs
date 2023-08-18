using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShoppingAPI.Entity.DTO.Category
{
    public class CategoryUpdateDTORequest
    {
        public CategoryUpdateDTORequest()
        {
            this.GUID = Guid.NewGuid();
        }

        public string Name { get; set; }
        public Guid GUID { get; set; }
        public bool? IsActive { get; set; }
    }
}
