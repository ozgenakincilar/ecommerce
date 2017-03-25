using System.Collections.Generic;
using System.Web.Mvc;

namespace NS.Business.Helpers.ListHelpers
{
    public interface IListHelper
    {
        IEnumerable<SelectListItem> Get(string[] selectedValues); 
    }
}
