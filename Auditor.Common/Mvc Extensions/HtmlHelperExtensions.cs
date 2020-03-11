using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Html;
using System.Web.Routing;

namespace Auditor.Common.Mvc_Extensions
{
    public static class HtmlHelperExtensions
    {
        /// <summary>
        /// Extension to Mvc HtmlHelper. 
        /// </summary>
        /// <param name="htmlHelper"></param>
        /// <param name="linkText"></param>
        /// <param name="actionName"></param>
        /// <param name="controllerName"></param>
        /// <param name="routeValues"></param>
        /// <param name="anchorHtmlAttributes"></param>
        /// <param name="iconDivHtmlAttributes"></param>
        /// <param name="linktextDivHtmlAttributes"></param>
        /// <returns></returns>
        public static IHtmlString CompositeActionLink(this HtmlHelper htmlHelper, string linkText, string actionName, string controllerName, object routeValues, object anchorHtmlAttributes, object iconDivHtmlAttributes, object linktextDivHtmlAttributes)
        {
            IDictionary<string, object> iconAttributesDictionary = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(iconDivHtmlAttributes);
            IDictionary<string, object> textAttributesDictionary = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(linktextDivHtmlAttributes);

            TagBuilder iconTagbuilder = new TagBuilder("div")
            {
                InnerHtml = string.Empty
            };
            iconTagbuilder.MergeAttributes<string, object>(iconAttributesDictionary);
            string iconHtmlString = iconTagbuilder.ToString(TagRenderMode.Normal);


            TagBuilder textTagbuilder = new TagBuilder("div")
            {
                InnerHtml = !string.IsNullOrEmpty(linkText) ? linkText : string.Empty
            };
            textTagbuilder.MergeAttributes<string, object>(textAttributesDictionary);
            string textHtmlString = textTagbuilder.ToString(TagRenderMode.Normal);

            string anchorInnerHtml = iconHtmlString + textHtmlString;

            // Generate link 
            RouteValueDictionary routeValueDictionary = new RouteValueDictionary((IDictionary<string, object>)HtmlHelper.ObjectToDictionary(routeValues));
            string str = UrlHelper.GenerateUrl(routeName: (string)null, actionName: actionName, controllerName: controllerName, protocol: (string)null, hostName: (string)null, fragment: (string)null, routeValues: routeValueDictionary, routeCollection: htmlHelper.RouteCollection, requestContext: htmlHelper.ViewContext.RequestContext, includeImplicitMvcValues: true);


            IDictionary<string, object> anchorAttributesDictionary = (IDictionary<string, object>)HtmlHelper.AnonymousObjectToHtmlAttributes(anchorHtmlAttributes);
            TagBuilder tagBuilder = new TagBuilder("a")
            {
                InnerHtml = !string.IsNullOrEmpty(anchorInnerHtml) ? anchorInnerHtml : string.Empty
            };

            tagBuilder.MergeAttributes<string, object>(anchorAttributesDictionary);
            tagBuilder.MergeAttribute("href", str);
            HtmlString ret = new HtmlString(tagBuilder.ToString(TagRenderMode.Normal));

            return ret;

            // Generate Link End

        }
    }
}
