using Microsoft.AspNetCore.Components;

using System.Globalization;

using XtremeModels;

using XtremeWasmApp.Services;

namespace XtremeWasmApp.Pages
{
    public partial class SearchDigit
    {
        [Inject]
        private IWebApiService _api { get; set; }

        private IEnumerable<TransSearch> TransListMixSale { get; set; }
        private IEnumerable<TransSearch> TransListMixSchemeSale { get; set; }
        private IEnumerable<TransSearch> TransListMixSchemePercSale { get; set; }
        private IEnumerable<TransSearch> TransListMixPurc { get; set; }
        private IEnumerable<TransSearch> TransListMixSchemePurc { get; set; }
        private IEnumerable<TransSearch> TransListMixSchemePercPurc { get; set; }
        private CultureInfo Curr = new CultureInfo("hi-IN");
        private NumberFormatInfo numberFormat { get; set; }
        private bool ResultNotFound = false;
        private string CurrentDigit;
        private string? SearchText;
        private int _dropSel = 1;
        private int SearchLimit = 4;
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
                if (SearchText?.Length > SearchLimit)
                {
                    SearchText = SearchText[0..SearchLimit];
                }
            }
        }

        protected override void OnInitialized()
        {
            numberFormat = Curr.NumberFormat;

            numberFormat.CurrencySymbol = "";
            base.OnInitialized();
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

            var transSearches = await _api.GetTransSearch(CurrentDigit + SearchText, LimDemVal);
            loading = false;
            if (transSearches is not null)
            {
                var TransListPurchase = transSearches.Where(x => x.Type == PrizeType.P);
                var TransListSale = transSearches.Where(x => x.Type == PrizeType.S);

                TransListMixSale = TransListSale.Where(x => string.Equals(x.Vid, "S Mix", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemeSale = TransListSale.Where(x => string.Equals(x.Vid, "S M.Sc", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemePercSale = TransListSale.Where(x => string.Equals(x.Vid, "S P.Sc", StringComparison.OrdinalIgnoreCase));

                TransListMixPurc = TransListPurchase.Where(x => string.Equals(x.Vid, "P Mix", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemePurc = TransListPurchase.Where(x => string.Equals(x.Vid, "P M.Sc", StringComparison.OrdinalIgnoreCase));
                TransListMixSchemePercPurc = TransListPurchase.Where(x => string.Equals(x.Vid, "P P.Sc", StringComparison.OrdinalIgnoreCase));
                Anypurchase = TransListPurchase.Any();
                AnySale = TransListSale.Any();
                ResultNotFound = !Anypurchase && !AnySale;

                duplicate();
            }
            else
            {
                ResultNotFound = true;
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

        private void duplicate()
        {
            AnySale = true;
            Anypurchase = true;
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());
            TransListMixSale = TransListMixSale.Append(TransListMixSale.First());

            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());
            TransListMixSchemeSale = TransListMixSchemeSale.Append(TransListMixSchemeSale.First());

            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());
            TransListMixSchemePercSale = TransListMixSchemePercSale.Append(TransListMixSchemePercSale.First());

            TransListMixPurc = TransListMixPurc.Append(TransListMixSale.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());
            TransListMixPurc = TransListMixPurc.Append(TransListMixPurc.First());

            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSale.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());
            TransListMixSchemePurc = TransListMixSchemePurc.Append(TransListMixSchemePurc.First());

            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSale.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
            TransListMixSchemePercPurc = TransListMixSchemePercPurc.Append(TransListMixSchemePercPurc.First());
        }
    }
}