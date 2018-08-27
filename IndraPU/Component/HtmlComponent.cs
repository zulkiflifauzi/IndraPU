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

        public static MvcHtmlString OPDMenu(this HtmlHelper htmlHelper)
        {

            var opds = OPDFactory.GetAllOPDs();

            var roots = opds.Where(c => !c.ParentId.HasValue).ToList();

            List<NodeViewModel> nodes = new List<NodeViewModel>();
            var result = new StringBuilder();

            foreach (var item in roots)
            {
                CreateNodes(opds, nodes, item, result);
            }

            return MvcHtmlString.Create(result.ToString());
        }

        private static void CreateNodes(List<OPDViewModel> opds, List<NodeViewModel> nodes, OPDViewModel item, StringBuilder result)
        {
            NodeViewModel node = new NodeViewModel();

            node.text = item.Title;
            node.href = "/OPD/View/" + item.Id;
            nodes.Add(node);

            //if (item.nodes.Count > 0)
            //{
            //    result.Append("<li>");
            //    result.Append("<a href='" + item.href + "'>" + item.text + "</a><span class='caret'></span>");
            //    result.Append("<ul class='dropdown-menu'>");
            //    CreateSubNodes(item, result);
            //    result.Append("</ul>");
            //    result.Append("</li>");
            //}
            //else
            //    result.Append("<li><a href='" + item.href + "'>" + item.text + "</a></li>");

            var childs = opds.Where(c => c.ParentId == item.Id).ToList();
            if (childs.Count > 0)
            {
                result.Append("<li>");
                result.Append("<a href='" + node.href + "'>" + node.text + "<span class='caret'></span></a>");
                result.Append("<ul class='dropdown-menu'>");
                node.nodes = new List<NodeViewModel>();
                foreach (var child in childs)
                {
                    CreateNodes(opds, node.nodes, child, result);
                }

                result.Append("</ul>");
                result.Append("</li>");
            }
            else
                result.Append("<li><a href='" + node.href + "'>" + node.text + "</a></li>");
        }

        //public static MvcHtmlString OPDMenu(this HtmlHelper htmlHelper)
        //{
        //    var result = new StringBuilder();
        //    foreach (var item in OPDFactory.PrepareNodes().Where())
        //    {
        //        if (item.nodes.Count > 0)
        //        {
        //            result.Append("<li>");
        //            result.Append("<a href='" + item.href + "'>" + item.text + "</a><span class='caret'></span>");
        //            result.Append("<ul class='dropdown-menu'>");
        //            CreateSubNodes(item, result);
        //            result.Append("</ul>");
        //            result.Append("</li>"); 
        //        }
        //        else
        //            result.Append("<li><a href='" + item.href + "'>" + item.text + "</a></li>");
        //    }

        //    return MvcHtmlString.Create(result.ToString());
        //}

        //private static void CreateSubNodes(NodeViewModel node, StringBuilder result)
        //{
        //    if (node.nodes.Count > 0)
        //    {
        //        result.Append("<li>");
        //        result.Append("<a href='" + node.href + "'>" + node.text + "</a><span class='caret'></span>");
        //        result.Append("<ul class='dropdown-menu'>");
        //        CreateSubNodes(node, result);
        //        result.Append("</ul>");
        //        result.Append("</li>");
        //    }
        //    else
        //        result.Append("<li><a href='" + node.href + "'>" + node.text + "</a></li>");
        //}
    }
}