using IndraPU.Logic;
using IndraPU.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace IndraPU.Component
{
    public static class OPDFactory
    {
        private static List<OPDViewModel> _opdViewModel = new List<OPDViewModel>();

        public static void InitializeContainers()
        {
            OPDLogic _opdLogic = new OPDLogic();

            var opds = _opdLogic.GetAll();
            foreach (var item in opds)
            {
                _opdViewModel.Add(new OPDViewModel() { Id = item.Id, Title = item.Title, ParentId = item.ParentId });
            }
        }

        public static List<OPDViewModel> GetAllOPDs()
        {
            return _opdViewModel;
        }

        public static List<NodeViewModel> PrepareNodes()
        {

            var opds = _opdViewModel;

            var roots = opds.Where(c => !c.ParentId.HasValue).ToList();


            List<NodeViewModel> nodes = new List<NodeViewModel>();

            foreach (var item in roots)
            {
                CreateNodes(opds, nodes, item);
            }

            return nodes;
        }

        private static void CreateNodes(List<OPDViewModel> opds, List<NodeViewModel> nodes, OPDViewModel item)
        {
            NodeViewModel node = new NodeViewModel();

            node.text = item.Title;
            node.href = "/OPD/View/" + item.Id;
            nodes.Add(node);

            var childs = opds.Where(c => c.ParentId == item.Id).ToList();
            if (childs.Count > 0)
            {
                node.nodes = new List<NodeViewModel>();
                foreach (var child in childs)
                {
                    CreateNodes(opds, node.nodes, child);
                }
            }
        }
    }
}