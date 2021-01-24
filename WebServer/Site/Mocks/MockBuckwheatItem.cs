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
        public IEnumerable<BuckwheatItem> BuckwheatItems { get; set; }
    }
}
