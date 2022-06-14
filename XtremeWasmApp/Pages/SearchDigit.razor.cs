using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.JSInterop;

using System.Globalization;

using XtremeModels;

using XtremeWasmApp.Services;

namespace XtremeWasmApp.Pages
{
    public partial class SearchDigit
    {
        [Inject]
        private WebApiService _api { get; set; }

        [Inject]
        private IJSRuntime Js { get; set; }

        private IEnumerable<TransSearch>? TransListSale { get; set; }
        private IEnumerable<TransSearch>? TransListPurchase { get; set; }
        private IEnumerable<TransSearch>? TransListMixSale { get; set; }
        private IEnumerable<TransSearch>? TransListMixSchemeSale { get; set; }
        private IEnumerable<TransSearch>? TransListMixSchemePercSale { get; set; }
        private IEnumerable<TransSearch>? TransListMixPurc { get; set; }
        private IEnumerable<TransSearch>? TransListMixSchemePurc { get; set; }
        private IEnumerable<TransSearch>? TransListMixSchemePercPurc { get; set; }
        private CultureInfo Curr = new CultureInfo("hi-IN");
        private NumberFormatInfo numberFormat { get; set; }
        private bool ResultNotFound = false;
        private string CurrentDigit;
        private string? SearchText;
        private int _dropSel = 1;
        private int SearchLimit = 4;
        private bool SearchingDisabled => DropSel == 1 ? SearchText?.Length == 0 : SearchText?.Length < SearchLimit;
        private bool _limit = true, _demand = false, loading = false, AnySale = false, Anypurchase = false;
        private LimDem LimDemVal => CalculateLimDem();

        public int DropSel {
            get => _dropSel;
            set {
                _dropSel = value;
                switch (value)
                {
                    case 1:
                        SearchLimit = 4;
                        CurrentDigit = "";
                        break;

                    case 2:
                        SearchLimit = 1;
                        CurrentDigit = "X";
                        break;

                    case 3:
                        SearchLimit = 1;
                        CurrentDigit = "XX";
                        break;

                    case 4:
                        SearchLimit = 1;
                        CurrentDigit = "XXX";
                        break;

                    case 5:
                        SearchLimit = 2;
                        CurrentDigit = "X";
                        break;

                    case 6:
                        SearchLimit = 2;
                        CurrentDigit = "XX";
                        break;

                    case 7:
                        SearchLimit = 3;
                        CurrentDigit = "X";
                        break;

                    case 8:
                        SearchLimit = 1;
                        CurrentDigit = "D";
                        break;

                    case 9:
                        SearchLimit = 1;
                        CurrentDigit = "S";
                        break;

                    default:
                        break;
                }
                SearchText = "";
            }
        }

        protected override async Task OnInitializedAsync()
        {
            numberFormat = Curr.NumberFormat;

            numberFormat.CurrencySymbol = "";
            //await Js.InvokeVoidAsync("focusInput", "srchInput");
        }

        private async Task OnKeyDownSearch(KeyboardEventArgs args)
        {
            if (args.Key == "Enter")
            {
                await OnSearchClick();
            }
        }

        private async Task OnSearchClick()
        {
            //        { "1SL", "S Mix" },
            //        { "2PR", "P Mix" },
            //        { "1PS", "S P.Sc" },
            //        { "2PS", "P P.Sc" },
            //        { "1RS", "S R.Sc" },
            //        { "2RS", "P R.Sc" },
            //        { "1SM", "S M.Sc" },
            //        { "2SM", "P M.Sc" },

            loading = true;
            TransListPurchase = null;
            TransListSale = null;
            TransListMixSchemeSale = null;
            TransListMixSchemePercSale = null;
            TransListMixPurc = null;
            TransListMixSale = null;
            TransListMixSchemePurc = null;

            TransListMixSchemePercPurc = null;

            var transSearches = await _api.GetTransSearch(CurrentDigit + SearchText, LimDemVal);
            loading = false;
            if (transSearches is not null)
            {
                TransListPurchase = transSearches.Where(x => x.Type == PrizeType.P);
                TransListSale = transSearches.Where(x => x.Type == PrizeType.S);

                TransListMixSale = TransListSale.Where(x => string.Equals(x.Vid, "S Mix", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemeSale = TransListSale.Where(x => string.Equals(x.Vid, "S M.Sc", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemePercSale = TransListSale.Where(x => string.Equals(x.Vid, "S P.Sc", StringComparison.OrdinalIgnoreCase));

                TransListMixPurc = TransListPurchase.Where(x => string.Equals(x.Vid, "P Mix", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemePurc = TransListPurchase.Where(x => string.Equals(x.Vid, "P M.Sc", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemePercPurc = TransListPurchase.Where(x => string.Equals(x.Vid, "P P.Sc", StringComparison.OrdinalIgnoreCase));
                Anypurchase = TransListPurchase.Any();
                AnySale = TransListSale.Any();
                ResultNotFound = !Anypurchase && !AnySale;
            }
            else
            {
                ResultNotFound = true;
            }
        }

        private void OnValueChange(ChangeEventArgs args)
        {
            if (args.Value is string str)
            {
                SearchText = str;
            }
        }

        private LimDem CalculateLimDem()
        {
            if (Limit && Demand)
            {
                return LimDem.M;
            }

            if (Limit)
            {
                return LimDem.L;
            }
            return LimDem.D;
        }

        public bool Limit {
            get => _limit;
            set {
                if (!value && !Demand)
                {
                    Demand = true;
                }

                _limit = value;
            }
        }

        public bool Demand {
            get => _demand;
            set {
                if (!value && !Limit)
                {
                    Limit = true;
                }

                _demand = value;
            }
        }
    }
}