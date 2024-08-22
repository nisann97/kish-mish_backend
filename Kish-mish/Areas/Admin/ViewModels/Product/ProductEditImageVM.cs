using System;
namespace Kish_mish.Areas.Admin.ViewModels.Product
{
    public class ProductEditImageVM
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string Name { get; set; }
        public bool IsMain { get; set; }
    }


}