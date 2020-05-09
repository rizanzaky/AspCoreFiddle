using System;
using System.Threading;
using CafeFurz.Core.Enums;

namespace CafeFurz.Core.Models
{
    public class Restaurant
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public CousineType Cousine { get; set; }
    }
}
