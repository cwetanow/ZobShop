﻿using System.Linq;
using WebFormsMvp;
using ZobShop.Orders.Contracts;

namespace ZobShop.ModelViewPresenter.ShoppingCart.Summary
{
    public class CartSummaryPresenter : Presenter<ICartSummaryView>
    {
        private readonly IShoppingCart cart;
        private readonly IViewModelFactory factory;

        public CartSummaryPresenter(ICartSummaryView view, IShoppingCart cart, IViewModelFactory factory)
            : base(view)
        {
            this.cart = cart;
            this.factory = factory;

            this.View.MyInit += View_MyInit;
        }

        private void View_MyInit(object sender, System.EventArgs e)
        {
            var products = this.cart.CartLines
                .Select(this.GetCartLineViewModel);

            this.View.Model.Products = products;
        }

        private CartLineViewModel GetCartLineViewModel(ICartLine line)
        {
            var quantity = line.Quantity;
            var product = line.Product;

            var productDetails = this.factory.CreateProductDetailsViewModel(product.ProductId,
                product.Name,
                product.Category.Name,
                product.Price,
                product.Volume,
                product.Maker,
                product.ImageMimeType,
                product.ImageBuffer);

            var result = this.factory.CreateCartLineViewModel(productDetails, quantity);

            return result;
        }
    }
}