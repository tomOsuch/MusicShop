using MusicShop.DAL;
using MusicShop.Models;
using MvcSiteMapProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MusicShop.Infrastructure
{
    public class ProductDetailsDynamicNodeProvider:DynamicNodeProviderBase
    {

        private StoreContext db = new StoreContext();

        public override IEnumerable<DynamicNode> GetDynamicNodeCollection(ISiteMapNode node)
        {
            var returneValue = new List<DynamicNode>();

            foreach(Album album in db.Albums)
            {
                DynamicNode dynamicNode = new DynamicNode();
                dynamicNode.Title = album.AlbumTitle;
                dynamicNode.Key = "Album_" + album.AlbumId;
                dynamicNode.ParentKey = "Genre_" + album.GenreId;
                dynamicNode.RouteValues.Add("id", album.AlbumId);
                returneValue.Add(dynamicNode);
            }

            return returneValue;
        }
    }
}