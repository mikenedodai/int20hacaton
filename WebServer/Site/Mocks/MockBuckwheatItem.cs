using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Site.Interfaces;
using Site.Models;

namespace Site.Mocks
{
    public class MockBuckwheatItem : IBuckwheat
    {
        public IEnumerable<BuckwheatItem> BuckwheatItems 
        {
            get
            {
                return new List<BuckwheatItem>
                {
                    new BuckwheatItem { name = "Гречка 1", price = 19.99f, shopName = "Магаз1", imgUrl = "https://kubnews.ru/upload/medialibrary/2f7/2f7c58202f263a175d3e09dd0527abc6.jpg", date = DateTime.Now  },
                    new BuckwheatItem { name = "Гречка 2", price = 19.99f, shopName = "Магаз2", imgUrl = "https://kubnews.ru/upload/medialibrary/2f7/2f7c58202f263a175d3e09dd0527abc6.jpg", date = DateTime.Now  },
                    new BuckwheatItem { name = "Гречка 3", price = 19.99f, shopName = "Магаз3", imgUrl = "https://kubnews.ru/upload/medialibrary/2f7/2f7c58202f263a175d3e09dd0527abc6.jpg", date = DateTime.Now  }
                };
            }
        }
    }
}
