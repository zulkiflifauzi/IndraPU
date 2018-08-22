using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;

namespace IndraPU.Component
{
    public static class HtmlComponent
    {
        public static MvcHtmlString DropDownListSingleLine(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> data, string value)
        {
            var result = new StringBuilder();

            result.Append("<select name=\"" + name + "\" id=\"" + name + "\">");

            result.Append("<option value=\"\">Select...</option>");
            foreach (var item in data)
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (item.Value == value)
                        result.Append("<option selected = \"selected\" value=\"" + item.Value + "\">" + item.Text + "</option>");
                    else
                        result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
                }
                else
                    result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
            }
            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        public static MvcHtmlString DropDownListRequired(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> data, string value)
        {
            var result = new StringBuilder();
            result.Append("<select name=\"" + name + "\" id=\"" + name + "\">");
            foreach (var item in data)
            {
                if (!String.IsNullOrEmpty(value))
                {
                    if (item.Value == value)
                        result.Append("<option selected = \"selected\" value=\"" + item.Value + "\">" + item.Text + "</option>");
                    else
                        result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
                }
                else
                    result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
            }
            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }
    }
}