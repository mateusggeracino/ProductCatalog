using System;

namespace Swiks.API.ViewModels.Response
{
    public class ProductResponseViewModel
    {
        public Guid UniqueKey { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
    }
}
