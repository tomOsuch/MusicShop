using MusicShop.DAL;
using MusicShop.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicShop.Infrastructure
{
    public class ProduktListDynamicNodeProvider:DynamicNodeProviderBase
    {

        private StoreContext db = new StoreContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returnValue = new List<DynamicNode>();
            
            foreach(Genre genre in db.Genres)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = genre.Name;
                dynamicNode.Key = "Genre_" + genre.GenreId;
                dynamicNode.RouteValues.Add("genrename", genre.Name);
                returnValue.Add(dynamicNode);
            }

            return returnValue;
        }
    }
}