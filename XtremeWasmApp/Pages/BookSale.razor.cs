
using XtremeWasmApp.Models;

namespace XtremeWasmApp.Pages
{
    public partial class BookSale
    {
        bool initale = true;
        bool isloading;
        List<BookSaleResponse?>? bookSaleResponses { get; set; }
        protected async override Task OnInitializedAsync()
        {
            initale = false;
            isloading = true;
            bookSaleResponses = (await Api.GetBookSale())?.ToList();
            isloading = false;
        }
    }
}