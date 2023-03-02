using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Mission09_jnw53.Models.ViewModels;

namespace Mission09_jnw53.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        //Dynamically cerate the page links
        private IUrlHelperFactory uhf;

        public PaginationTagHelper (IUrlHelperFactory temp)
        {
            uhf = temp;
        }

        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext vc { get; set; }

        public string PageAction { get; set; }
        public PageInfo PageModel { get; set; }
        public bool PageClassesEnabled { get; set; } = false;
        public string PageClass { get; set; }
        public string PageClassNormal { get; set; }
        public string PageClassSelected { get; set; }

        //Create the page tags
        public override void Process (TagHelperContext thc, TagHelperOutput tho)
        {
            IUrlHelper uh = uhf.GetUrlHelper(vc);

            TagBuilder final = new TagBuilder("div");

            for (int i = 1; i <= PageModel.TotalPages; i++)
            {
                TagBuilder tb = new TagBuilder("a");

                tb.Attributes["href"] = uh.Action(PageAction, new { pageNum = i });
                if (PageClassesEnabled)
                {
                    tb.AddCssClass(PageClass);
                    tb.AddCssClass(i == PageModel.CurrentPage
                        ? PageClassSelected : PageClassNormal);
                }
                tb.InnerHtml.Append(i.ToString());

                final.InnerHtml.AppendHtml(tb);
            }

            tho.Content.AppendHtml(final.InnerHtml);

        }
    }
}
