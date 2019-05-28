using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IGI_5.Helpers
{
    public class OrderTagHelper : TagHelper
    {
        private const string address = "/Home/Order";
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "a";                                      
            output.Attributes.SetAttribute("href", address);
            output.Content.SetContent("Orders");
        }
    }
}
