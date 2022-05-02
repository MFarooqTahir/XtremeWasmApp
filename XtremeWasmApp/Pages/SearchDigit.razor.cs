using System.Globalization;

namespace XtremeWasmApp.Pages
{
    public partial class SearchDigit
    {
        private string CurrentDigit;
        private int? SearchText;
        private int _dropSel = 1;
        private int SearchLimit = 4;
        private int unDel = 0;
        private bool _limit = true, _demand = false;

        public int DropSel {
            get => _dropSel;
            set {
                _dropSel = value;
                switch (value)
                {
                    case 1:
                        SearchLimit = 4;
                        unDel = 0;
                        CurrentDigit = "";
                        break;

                    case 2:
                        SearchLimit = 1;
                        unDel = 1;
                        CurrentDigit = "X";
                        break;

                    case 3:
                        SearchLimit = 1;
                        unDel = 2;
                        CurrentDigit = "XX";
                        break;

                    case 4:
                        SearchLimit = 1;
                        unDel = 1;
                        CurrentDigit = "XXX";
                        break;

                    case 5:
                        SearchLimit = 2;
                        unDel = 2;
                        CurrentDigit = "X";
                        break;

                    case 6:
                        SearchLimit = 2;
                        unDel = 1;
                        CurrentDigit = "XX";
                        break;

                    case 7:
                        SearchLimit = 3;
                        unDel = 1;
                        CurrentDigit = "X";
                        break;

                    case 8:
                        SearchLimit = 1;
                        unDel = 1;
                        CurrentDigit = "D";
                        break;

                    case 9:
                        SearchLimit = 1;
                        unDel = 1;
                        CurrentDigit = "S";
                        break;

                    default:
                        break;
                }
                string st = SearchText.ToString();
                if (st.Length > SearchLimit)
                {
                    SearchText = int.Parse(st[0..SearchLimit], CultureInfo.InvariantCulture);
                }
            }
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