using Microsoft.CodeAnalysis.CSharp;
using Terrains_Treasures.Models;
namespace Terrains_Treasures.ViewModels

{
    public class CartViewModel
    {
        public List<CartItemViewModel> Items { get; set; } = new();
        public decimal TotalPrice => Items?.Sum(i=>i.TotalPrice) ?? 0;

    }
}
