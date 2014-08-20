using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Umbraco.Core.Models;
using Umbraco.Web.Editors;
using Umbraco.Web.Mvc;

namespace NorthernGround.uContentDropdown
{
    [PluginController("uContentDropdown")]
    public class uContentDropdownController : UmbracoAuthorizedJsonController
    {

        [System.Web.Http.AcceptVerbs("GET")]
        public IEnumerable<ContentListItem> Content(string xpath)
        {

            List<ContentListItem> contentList = new List<ContentListItem>();

            var contentResult = Umbraco.TypedContentAtXPath(xpath);

            foreach (IPublishedContent content in contentResult)
            {
                // I know this is flip flopped, but not sure why I can't get the binding to select the correct value if its the correct way - guess I'm too much of an angular rookie
                contentList.Add(new ContentListItem()
                {
                    Id = content.Name,
                    Name = content.Id.ToString()
                });
            }

            return contentList;

        }

    }
}