using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text;
using IndraPU.Models;
using IndraPU.Domain;

namespace IndraPU.Component
{
    public static class HtmlComponent
    {
        public static MvcHtmlString DropDownListSingleLine(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> data, string value, string className = "")
        {
            var result = new StringBuilder();

            if (className != "")
                result.Append("<select class=\"" + className + "\" name=\"" + name + "\" id=\"" + name + "\">");
            else
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

        public static MvcHtmlString DropDownListODPTree(this HtmlHelper htmlHelper, string name, IEnumerable<OPD> data, int? value, string className = "")
        {
            var result = new StringBuilder();

            if (className != "")
                result.Append("<select class=\"" + className + "\" name=\"" + name + "\" id=\"" + name + "\">");
            else
                result.Append("<select name=\"" + name + "\" id=\"" + name + "\">");

            result.Append("<option value=\"\">Select...</option>");

            var parents = data.Where(c => !c.ParentId.HasValue).ToList();

            foreach (var item in parents)
            {
                CreateOption(value, result, item);
                CreateChild(data, value, result, item);
            }
            //foreach (var item in data)
            //{
            //    if (!String.IsNullOrEmpty(value))
            //    {
            //        if (item.Value == value)
            //            result.Append("<option selected = \"selected\" value=\"" + item.Value + "\">" + item.Text + "</option>");
            //        else
            //            result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
            //    }
            //    else
            //        result.Append("<option value=\"" + item.Value + "\">" + item.Text + "</option>");
            //}
            result.Append("</select>");

            return MvcHtmlString.Create(result.ToString());
        }

        private static void CreateChild(IEnumerable<OPD> data, int? value, StringBuilder result, OPD item)
        {
            if (data.Any(c => c.ParentId == item.Id))
            {
                var childs = data.Where(c => c.ParentId == item.Id).ToList();
                foreach (var child in childs)
                {
                    child.Title = "--- " + child.Title;
                    CreateOption(value, result, child);
                }
            }
        }

        private static void CreateOption(int? value, StringBuilder result, OPD item)
        {
            if (value.HasValue)
            {
                if (item.Id == value)
                    result.Append("<option selected = \"selected\" value=\"" + item.Id + "\">" + item.Title + "</option>");
                else
                    result.Append("<option value=\"" + item.Id + "\">" + item.Title + "</option>");
            }
            else
                result.Append("<option value=\"" + item.Id + "\">" + item.Title + "</option>");
        }

        public static MvcHtmlString DropDownListRequired(this HtmlHelper htmlHelper, string name, IEnumerable<SelectListItem> data, string value, string className = "")
        {
            var result = new StringBuilder();
            if (className != "")
                result.Append("<select class=\"" + className + "\" name=\"" + name + "\" id=\"" + name + "\">");
            else
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