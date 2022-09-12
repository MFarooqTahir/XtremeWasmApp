using Microsoft.AspNetCore.Components.Web;

using System.Data;
using System.Globalization;

using XtremeModels;

using XtremeWasmApp.Helpers;

namespace XtremeWasmApp.Pages
{
    public partial class PartyBill
    {
        private readonly List<DataSet> Inds = new(3) { new(), new(), new() };
        private List<int> Recno = new List<int> { 0, 0, 0, 0, 0 };
        private int xxkey = 0;
        private double s_pamt1, s_pamt2, s_pamt3, s_pamt4, s_pqty;
        private double s_mixamt1, s_mixamt2, s_mixamt3, s_mixamt4, s_mixamt5;
        private double s_pscamt1, s_pscamt2, s_pscamt3, s_pscamt4, s_scpqty, s_pscqty;
        private double s_rscamt1, s_rscamt2, s_rscamt3, s_rscamt4;
        private double s_camt1, s_camt2, s_camt3, s_camt4, s_cqty;
        private double s_tkamt1, s_tkamt2, s_tkamt3, s_tkamt4, s_tkqty;
        private double p_pamt1, p_pamt2, p_pamt3, p_pamt4, p_pqty;
        private double p_mixamt1, p_mixamt2, p_mixamt3, p_mixamt4;
        private double p_pscamt1, p_pscamt2, p_pscamt3, p_pscamt4, p_pscqty;
        private double p_rscamt1, p_rscamt2, p_rscamt3, p_rscamt4, p_scpqty;
        private double p_camt1, p_camt2, p_camt3, p_camt4, p_cqty;
        private double p_tkamt1, p_tkamt2, p_tkamt3, p_tkamt4, p_tkqty;
        private double sm_pscamt1, sm_pscamt2, sm_pscamt3, sm_pscamt4, sm_pscqty;
        private double pm_pscamt1, pm_pscamt2, pm_pscamt3, pm_pscamt4, pm_pscqty;
        private double xsbo1, xsba1, xsbx1, xsbt1, xsbxx1, xsbf1, xsbd1, xsb61, xsbsp, xsbsr, xpbo1, xpba1, xpbx1, xpbt1, xpbxx1, xpbf1, xpbd1, xpb61, xpbsp, xpbsr;
        private string str2 = "";
        private DataTable tab1 = null;
        private Party? party = null;
        private CultureInfo numCulture = new CultureInfo("en-IN");
        private List<string> Errors = new();
        private bool loading = false;

        protected override void OnInitialized()
        {
            numCulture.NumberFormat.CurrencySymbol = string.Empty;
            base.OnInitialized();
        }

        public async Task report(MouseEventArgs args)
        {
            loading = true;
            tab1 = new DataTable("New Data");
            tab1.Columns.Add("PID", typeof(string));
            tab1.Columns.Add("TG", typeof(string));

            tab1.Columns.Add("H2", typeof(string));
            tab1.Columns.Add("H3", typeof(string));
            tab1.Columns.Add("H4", typeof(string));
            tab1.Columns.Add("H5", typeof(string));
            tab1.Columns.Add("H6", typeof(string));
            tab1.Columns.Add("H7", typeof(string));
            tab1.Columns.Add("H8", typeof(string));
            tab1.Columns.Add("H9", typeof(string));
            tab1.Columns.Add("H10", typeof(string));

            tab1.Columns.Add("H11", typeof(string));
            tab1.Columns.Add("H12", typeof(string));
            tab1.Columns.Add("H13", typeof(string));
            tab1.Columns.Add("H14", typeof(string));
            tab1.Columns.Add("H15", typeof(string));
            tab1.Columns.Add("H16", typeof(string));
            tab1.Columns.Add("H17", typeof(string));
            tab1.Columns.Add("H18", typeof(string));
            tab1.Columns.Add("H19", typeof(string));
            tab1.Columns.Add("H20", typeof(string));

            tab1.Columns.Add("H21", typeof(string));
            tab1.Columns.Add("H22", typeof(string));
            tab1.Columns.Add("H23", typeof(string));
            tab1.Columns.Add("H24", typeof(string));
            tab1.Columns.Add("H25", typeof(string));
            tab1.Columns.Add("H26", typeof(string));
            tab1.Columns.Add("H27", typeof(string));
            tab1.Columns.Add("H28", typeof(string));
            tab1.Columns.Add("H29", typeof(string));
            tab1.Columns.Add("H30", typeof(string));

            tab1.Columns.Add("H31", typeof(string));
            tab1.Columns.Add("H32", typeof(string));
            tab1.Columns.Add("H33", typeof(string));
            tab1.Columns.Add("H34", typeof(string));
            tab1.Columns.Add("H35", typeof(string));
            tab1.Columns.Add("H36", typeof(string));
            tab1.Columns.Add("H37", typeof(string));
            tab1.Columns.Add("H38", typeof(string));
            tab1.Columns.Add("H39", typeof(string));
            tab1.Columns.Add("H40", typeof(string));

            tab1.Columns.Add("H41", typeof(string));
            tab1.Columns.Add("H42", typeof(string));
            tab1.Columns.Add("H43", typeof(string));
            tab1.Columns.Add("H44", typeof(string));
            tab1.Columns.Add("H45", typeof(string));
            tab1.Columns.Add("H46", typeof(string));
            tab1.Columns.Add("H47", typeof(string));
            tab1.Columns.Add("H48", typeof(string));
            tab1.Columns.Add("H49", typeof(string));

            tab1.Columns.Add("H50", typeof(string));
            tab1.Columns.Add("H51", typeof(string));
            tab1.Columns.Add("H52", typeof(string));
            tab1.Columns.Add("H53", typeof(string));
            tab1.Columns.Add("H54", typeof(string));
            tab1.Columns.Add("H55", typeof(string));
            tab1.Columns.Add("H56", typeof(string));
            tab1.Columns.Add("H57", typeof(string));
            tab1.Columns.Add("H58", typeof(string));
            tab1.Columns.Add("H59", typeof(string));
            tab1.Columns.Add("H60", typeof(string));

            tab1.Columns.Add("H61", typeof(string));
            tab1.Columns.Add("H62", typeof(string));
            tab1.Columns.Add("H63", typeof(string));
            tab1.Columns.Add("H64", typeof(string));
            tab1.Columns.Add("H65", typeof(string));
            tab1.Columns.Add("H66", typeof(string));
            tab1.Columns.Add("H67", typeof(string));
            tab1.Columns.Add("H68", typeof(string));
            tab1.Columns.Add("H69", typeof(string));
            tab1.Columns.Add("H70", typeof(string));

            tab1.Columns.Add("H71", typeof(string));
            tab1.Columns.Add("H72", typeof(string));
            tab1.Columns.Add("H73", typeof(string));
            tab1.Columns.Add("H74", typeof(string));
            tab1.Columns.Add("H75", typeof(string));
            tab1.Columns.Add("H76", typeof(string));
            tab1.Columns.Add("H77", typeof(string));
            tab1.Columns.Add("H78", typeof(string));
            tab1.Columns.Add("H79", typeof(string));
            tab1.Columns.Add("H80", typeof(string));

            tab1.Columns.Add("H81", typeof(string));
            tab1.Columns.Add("H82", typeof(string));
            tab1.Columns.Add("H83", typeof(string));
            tab1.Columns.Add("H84", typeof(string));
            tab1.Columns.Add("H85", typeof(string));
            tab1.Columns.Add("H86", typeof(string));
            tab1.Columns.Add("H87", typeof(string));
            tab1.Columns.Add("H88", typeof(string));
            tab1.Columns.Add("H89", typeof(string));
            tab1.Columns.Add("H90", typeof(string));

            tab1.Columns.Add("H91", typeof(string));
            tab1.Columns.Add("H92", typeof(string));
            tab1.Columns.Add("H93", typeof(string));
            tab1.Columns.Add("H94", typeof(string));
            tab1.Columns.Add("H95", typeof(string));
            tab1.Columns.Add("H96", typeof(string));
            tab1.Columns.Add("H97", typeof(string));
            tab1.Columns.Add("H98", typeof(string));
            tab1.Columns.Add("H99", typeof(string));
            tab1.Columns.Add("CTIT", typeof(string));

            xsbo1 = 0;
            xsba1 = 0;
            xsbx1 = 0;
            xsbt1 = 0;
            xsbxx1 = 0;
            xsbf1 = 0;
            xsbd1 = 0;
            xsb61 = 0;
            xsbsp = 0;
            xsbsr = 0;

            xpbo1 = 0;
            xpba1 = 0;
            xpbx1 = 0;
            xpbt1 = 0;
            xpbxx1 = 0;
            xpbf1 = 0;
            xpbd1 = 0;
            xpb61 = 0;
            xpbsp = 0;
            xpbsr = 0;

            Recno[0] = 0;

            s_pamt1 = 0;
            s_pamt2 = 0;
            s_pamt3 = 0;
            s_pamt4 = 0;
            s_pqty = 0;

            s_mixamt1 = 0;
            s_mixamt2 = 0;
            s_mixamt3 = 0;
            s_mixamt4 = 0;
            s_mixamt5 = 0;

            s_pscamt1 = 0;
            s_pscamt2 = 0;
            s_pscamt3 = 0;
            s_pscamt4 = 0;
            s_scpqty = 0;

            s_rscamt1 = 0;
            s_rscamt2 = 0;
            s_rscamt3 = 0;
            s_rscamt4 = 0;

            s_camt1 = 0;
            s_camt2 = 0;
            s_camt3 = 0;
            s_camt4 = 0;
            s_cqty = 0;

            s_tkamt1 = 0;
            s_tkamt2 = 0;
            s_tkamt3 = 0;
            s_tkamt4 = 0;
            s_tkqty = 0;

            p_pamt1 = 0;
            p_pamt2 = 0;
            p_pamt3 = 0;
            p_pamt4 = 0;
            p_pqty = 0;

            p_mixamt1 = 0;
            p_mixamt2 = 0;
            p_mixamt3 = 0;
            p_mixamt4 = 0;

            p_pscamt1 = 0;
            p_pscamt2 = 0;
            p_pscamt3 = 0;
            p_pscamt4 = 0;

            p_rscamt1 = 0;
            p_rscamt2 = 0;
            p_rscamt3 = 0;
            p_rscamt4 = 0;
            p_scpqty = 0;

            p_camt1 = 0;
            p_camt2 = 0;
            p_camt3 = 0;
            p_camt4 = 0;
            p_cqty = 0;

            p_tkamt1 = 0;
            p_tkamt2 = 0;
            p_tkamt3 = 0;
            p_tkamt4 = 0;
            p_tkqty = 0;

            sm_pscamt1 = 0;
            sm_pscamt2 = 0;
            sm_pscamt3 = 0;
            sm_pscamt4 = 0;
            sm_pscqty = 0;

            pm_pscamt1 = 0;
            pm_pscamt2 = 0;
            pm_pscamt3 = 0;
            pm_pscamt4 = 0;
            pm_pscqty = 0;

            xsbo1 = 0;
            xsba1 = 0;
            xsbx1 = 0;
            xsbt1 = 0;
            xsbxx1 = 0;
            xsbf1 = 0;
            xsbd1 = 0;
            xsb61 = 0;
            xsbsp = 0;
            xsbsr = 0;

            xpbo1 = 0;
            xpba1 = 0;
            xpbx1 = 0;
            xpbt1 = 0;
            xpbxx1 = 0;
            xpbf1 = 0;
            xpbd1 = 0;
            xpb61 = 0;
            xpbsp = 0;
            xpbsr = 0;
            party = await Api.GetParty().ConfigureAwait(false);

            var dt = await Api.BillGenerate(0, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                pktsale();
            }

            // '************************************************************************************************************

            // Main.Ltitle.Text = "Fetching Mix Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(1, party.Code).ConfigureAwait(false);
            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                mixsale();
            }

            // '***************************************************************************************************************

            // Main.Ltitle.Text = "Fetching Mix-Scheme Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(2, party.Code).ConfigureAwait(false);
            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                mixschemesale();
            }

            // '**************************************************************************************************************

            // Main.Ltitle.Text = "Fetching Scheme Packet Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(3, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                schemepacketsale();
            }

            // ********************************************************************************************************

            // Main.Ltitle.Text = "Fetching Chart Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(4, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                var dt2 = await Api.BillGenerate(41, party.Code).ConfigureAwait(false);

                Inds[2].Clear();
                Inds[2].Tables.Clear();
                dt2.TableName = "0";
                Inds[2].Tables.Add(dt2);

                chartsale();
            }

            // '******************************************************************************************************

            // Waitdisplay()

            dt.Clear();
            dt = await Api.BillGenerate(5, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                tukrasale();
            }

            // ***********************************************************************************************************
            // Main.Ltitle.Text = "Sale Calculation"
            // Total Sale

            if ((s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1 + s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2 + s_pamt3 + s_camt3 + s_tkamt3 + s_mixamt3 + s_pscamt3 + s_rscamt3 + sm_pscamt3 + s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4) != 0)
            {
                tab1.Rows[^1][30] = "⁞⁞ Total Sale";
                var str2num = Math.Ceiling(s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][31] = str2.Trim();
                }
                str2num = s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1 - (s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2);
                str2 = Rs0(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][32] = str2.Trim();
                }
                str2num = Math.Ceiling(s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][33] = str2.Trim();
                }
                str2num = Math.Round(s_pamt3 + s_camt3 + s_tkamt3 + s_mixamt3 + s_pscamt3 + s_rscamt3 + sm_pscamt3);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][34] = str2.Trim();
                }
                str2num = Math.Ceiling(s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][35] = str2.Trim();
                }
            }

            // *********************************************************************************************************************

            // Main.Ltitle.Text = "Fetching % Packet Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(6, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                pktpurchase();
            }

            // '***********************************************************************************************************

            // Main.Ltitle.Text = "Fetching Mix Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(7, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                mixpurchase();
            }

            // ************************************************************************************************************

            // Main.Ltitle.Text = "Fetching Mix-Scheme Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(8, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                mixschemepurchase();
            }

            // '**************************************************************************************************************

            // Main.Ltitle.Text = "Fetching Scheme Packet Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(9, party.Code).ConfigureAwait(false);
            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                schemepacketpurchase();
            }

            // ******************************************************************************************************

            // Main.Ltitle.Text = "Fetching Tukra Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]][1)) + " )"

            dt.Clear();
            dt = await Api.BillGenerate(10, party.Code).ConfigureAwait(false);

            Inds[1].Clear();
            Inds[1].Tables.Clear();
            dt.TableName = "0";
            Inds[1].Tables.Add(dt);

            if (Inds[1].Tables[0].Rows.Count > 0)
            {
                tukrapurchase();
            }

            // ***********************************************************************************************************
            // Main.Ltitle.Text = "Purchas Calculation"
            // Total Purchase

            if ((p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + p_pamt2 + p_tkamt1 + pm_pscamt1 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2 + p_pamt3 + p_tkamt1 + p_mixamt3 + p_pscamt3 + p_rscamt3 + pm_pscamt3 + p_pamt4 + p_tkamt1 + pm_pscamt4) != 0)
            {
                tab1.Rows[^1][30] = "⁞⁞ Total Purchase";
                var str2num = Math.Ceiling(p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][31] = str2.Trim();
                }
                str2num = p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1 - (p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2);
                str2 = Rs0(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][32] = str2.Trim();
                }
                str2num = Math.Ceiling(p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][33] = str2.Trim();
                }
                str2num = Math.Round(p_pamt3 + p_tkamt3 + p_mixamt3 + p_pscamt3 + p_rscamt3 + pm_pscamt3);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][34] = str2.Trim();
                }
                str2num = Math.Ceiling(p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt4);
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][35] = str2.Trim();
                }
            }

            // Net Amount

            if ((s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + s_pamt3 + s_camt3 + s_tkamt3 + s_mixamt3 + s_pscamt3 + s_rscamt3 + p_pamt3 + p_tkamt3 + p_mixamt3 + p_pscamt3 + p_rscamt3 + s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt1 + pm_pscamt2 + pm_pscamt3 + pm_pscamt4 + sm_pscamt1 + sm_pscamt2 + sm_pscamt3 + sm_pscamt4) != 0)
            {
                var str2num = Math.Round(s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1 - (p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1));
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][41] = str2.Trim();
                }
                str2num = Math.Round(s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1 - (p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1) - (s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2 - (p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2)));
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][42] = str2.Trim();
                }
                str2num = Math.Round(s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2 - (p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2));
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][43] = str2.Trim();
                }
                str2num = Math.Round(s_pamt3 + s_camt3 + s_tkamt3 + s_mixamt3 + s_pscamt3 + s_rscamt3 + sm_pscamt3 - (p_pamt3 + p_tkamt3 + p_mixamt3 + p_pscamt3 + p_rscamt3 + pm_pscamt3));
                str2 = Rs(str2num);

                if (str2num != 0)
                {
                    tab1.Rows[^1][44] = str2.Trim();
                }
                str2num = Math.Round(s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4 - (p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt4));
                str2 = Rs(str2num);
                var str2x = Math.Round(s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4 - (p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt4));

                if (str2num != 0)
                {
                    tab1.Rows[^1][45] = str2.Trim();
                    //if (rlist > 0 & Main.account && bool.Parse(Inds[0].Tables[0].Rows[Recno[0]]["actac"].ToString()) && !bool.Parse(Inds[0].Tables[0].Rows[Recno[0]]["acind"].ToString()))
                    //{
                    //    // Dim xx = Mid(MainMenu.Ld3.Text, 4, 2)
                    //    DateTime xdate = (Right(MainMenu.Ld3.Text, 4) + "-" + Mid(MainMenu.Ld3.Text, 4, 2) + "-" + Left(MainMenu.Ld3.Text, 2));
                    //    string xxdate = (Left(MainMenu.Ld3.Text, 2) + "-" + Mid(MainMenu.Ld3.Text, 4, 2) + "-" + Right(MainMenu.Ld3.Text, 4));
                    //    string xdes = "Rs. " + Trim(MainMenu.Ld1.Text) + " - " + Trim(MainMenu.Ld2.Text) + "  " + Trim(MainMenu.Ld2c.Text) + IIf(MainMenu.Ld2c.Text == "", "", "  ") + Trim(xxdate) + "  " + Trim(MainMenu.Ld4.Text);
                    //    var xxxxr = await ApiLink.GetRequestAsync<bool>($"api/Data/TransdtlIns/{-1}/D/{Val(Inds[0].Tables[0].Rows[Recno[0]]["Code"))}/{xdes}/{"0"}/{xdate}/{"0"}/{IIf(int.Parse(str2,CultureInfo.InvariantCulture) < 0, Math.Abs(int.Parse(str2,CultureInfo.InvariantCulture)), 0)}/{IIf(int.Parse(str2,CultureInfo.InvariantCulture) > 0, int.Parse(str2,CultureInfo.InvariantCulture), 0)}/{true}", Config.BaseURLD);
                    //}
                }
            }

            str2 = Rs(xsbo1);

            if (xsbo1 != 0)
            {
                tab1.Rows[^1][61] = str2.Trim();
            }

            str2 = Rs(xsba1);

            if (xsba1 != 0)
            {
                tab1.Rows[^1][62] = str2.Trim();
            }

            str2 = Rs(xsbx1);

            if (xsbx1 != 0)
            {
                tab1.Rows[^1][63] = str2.Trim();
            }

            str2 = Rs(xsbt1);

            if (xsbt1 != 0)
            {
                tab1.Rows[^1][64] = str2.Trim();
            }

            str2 = Rs(xsbxx1);

            if (xsbxx1 != 0)
            {
                tab1.Rows[^1][65] = str2.Trim();
            }

            str2 = Rs(xsbf1);

            if (xsbf1 != 0)
            {
                tab1.Rows[^1][66] = str2.Trim();
            }

            str2 = Rs(xsbd1);

            if (xsbd1 != 0)
            {
                tab1.Rows[^1][67] = str2.Trim();
            }

            str2 = Rs(xsb61);

            if (xsb61 != 0)
            {
                tab1.Rows[^1][68] = str2.Trim();
            }

            str2 = Rs(xsbsp);

            if (xsbsp != 0)
            {
                tab1.Rows[^1][69] = str2.Trim();
            }

            str2 = Rs(xsbsr);

            if (xsbsr != 0)
            {
                tab1.Rows[^1][70] = str2.Trim();
            }

            str2 = Rs(xpbo1);

            if (xpbo1 != 0)
            {
                tab1.Rows[^1][71] = str2.Trim();
            }

            str2 = Rs(xpba1);

            if (xpba1 != 0)
            {
                tab1.Rows[^1][72] = str2.Trim();
            }

            str2 = Rs(xpbx1);

            if (xpbx1 != 0)
            {
                tab1.Rows[^1][73] = str2.Trim();
            }

            str2 = Rs(xpbt1);

            if (xpbt1 != 0)
            {
                tab1.Rows[^1][74] = str2.Trim();
            }

            str2 = Rs(xpbxx1);

            if (xpbxx1 != 0)
            {
                tab1.Rows[^1][75] = str2.Trim();
            }

            str2 = Rs(xpbf1);

            if (xpbf1 != 0)
            {
                tab1.Rows[^1][76] = str2.Trim();
            }

            str2 = Rs(xpbd1);

            if (xpbd1 != 0)
            {
                tab1.Rows[^1][77] = str2.Trim();
            }

            str2 = Rs(xpb61);

            if (xpb61 != 0)
            {
                tab1.Rows[^1][78] = str2.Trim();
            }

            str2 = Rs(xpbsp);

            if (xpbsp != 0)
            {
                tab1.Rows[^1][79] = str2.Trim();
            }

            str2 = Rs(xpbsr);

            if (xpbsr != 0)
            {
                tab1.Rows[^1][80] = str2.Trim();
            }

            var XDATE = await Api.GetDateTime().ConfigureAwait(false);
            var sch = await Api.GetSch().ConfigureAwait(false);
            var Ld1 = sch.DId.ToString(CultureInfo.InvariantCulture);
            var Ld2 = sch.BId;
            var fileName = Trim(party.Code) + " = Party Bill " + Trim(Ld1) + " - " + Trim(Ld2) + " Rs. " + Trim(Rs(Math.Round(s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4 - (p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt4)))) + ".pdf";

            var resultingReport = await Api.GetPartyBillReport(tab1, fileName, XDATE).ConfigureAwait(false);
            Recno[0]++;
            if (resultingReport is not null)
            {
                if (resultingReport.File is null && resultingReport?.FileName?.Contains("error", StringComparison.CurrentCultureIgnoreCase) == true)
                {
                    Errors = new() { "There was an error in server" };
                }
                else
                {
                    await Js.SaveAs(resultingReport.FileName, resultingReport.File).ConfigureAwait(false);
                    loading = false;
                }
            }
        }

        private string Rs(double input)
        {
            return input.ToString("C0", numCulture);
        }

        private string Rs0(double input)
        {
            return input.ToString("C2", numCulture);
        }

        private string Trim(object? obj)
        {
            return obj?.ToString()?.Trim() ?? "";
        }

        private string Str(double val)
        {
            return val.ToString();
        }

        private double Val(object? ob)
        {
            return double.Parse(ob?.ToString() ?? "0", CultureInfo.InvariantCulture);
        }

        private short ValS(object? ob)
        {
            return short.Parse(ob?.ToString() ?? "0", CultureInfo.InvariantCulture);
        }

        public string Left(string input, int count)
        {
            return input.Substring(0, Math.Min(input.Length, count));
        }

        public string Right(string input, int count)
        {
            return input.Substring(Math.Max(input.Length - count, 0), Math.Min(count, input.Length));
        }

        public string Format(double val, string format)
        {
            return string.Format(CultureInfo.InvariantCulture, format, val);
        }

        public void tukrapurchase()
        {
            Recno[1] = 0;

            double MQTY = 0;
            double WAMT = 0;
            Int16 MVNO = 0;
            double MCH_PER = 0;
            var mchl = "";
            double MRATE = 0;
            var cat = "";

            p_tkamt1 = 0;
            p_tkamt2 = 0;
            p_tkamt3 = 0;
            p_tkamt4 = 0;
            p_tkqty = 0;

            // 0      1        2       3    4      5     6
            // Mkey, ch_per, pkt_rate, chl, cat, win_amt, dlk

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                mchl = Trim(Inds[1].Tables[0].Rows[Recno[1]][3]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]][1]);
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]][2]);
                if (Trim(Inds[1].Tables[0].Rows[Recno[1]][4]) == "Scheme")
                {
                    cat = "Scheme";
                }
                else
                {
                    cat = "";
                }

                MQTY = 0;
                WAMT = 0;

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    MQTY += 1;
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]][5]);

                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                    else if (Val(mchl) != Val(Inds[1].Tables[0].Rows[Recno[1]][3]))
                    {
                        break;
                    }
                }

                p_tkqty += MQTY;
                p_tkamt1 += MQTY * MRATE;
                p_tkamt2 += MQTY * MRATE;
                p_tkamt3 += WAMT;
                p_tkamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                tab1.Rows[^1][100] = "(( Tukra Purchase ))";
                tab1.Rows[^1][2] = Right("00000" + Trim(Str(Val(mchl))), 5);
                tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][6] = Trim(str2);
                    tab1.Rows[^1][10] = Trim(str2);
                }

                if (cat == "" & MCH_PER == 0.25)
                {
                    tab1.Rows[^1][7] = "¼ %";
                }

                if (cat == "" & MCH_PER == 0.5)
                {
                    tab1.Rows[^1][7] = "½ %";
                }

                if (cat == "" & MCH_PER >= 1)
                {
                    tab1.Rows[^1][7] = Trim(Str(MCH_PER)) + " %";
                }

                if (cat == "Scheme")
                {
                    tab1.Rows[^1][7] = "Scheme";
                }

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][11] = Trim(str2);
                }

                str2 = Rs0((MQTY * MRATE) - WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][12] = Trim(str2);
                }

                if (p_tkqty > 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(p_tkqty))), "########"));
                }

                str2 = Rs(p_tkamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs(p_tkamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(p_tkamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(p_tkamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                tab1.Rows[^1][51] = "Qty";
                tab1.Rows[^1][52] = "Tukra Rate";
                tab1.Rows[^1][53] = "Less Comm %";
            }
        }

        public void schemepacketpurchase()
        {
            Recno[1] = 0;

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                Inds[1].Tables[0].Rows[Recno[1]][8] = "";
                Recno[1] += 1;
            }

            Recno[1] = 0;

            double WAMT = 0;
            Int16 MVNO = 0;
            var MREF = "";

            Int16 mqty = 0;

            p_pscamt1 = 0;
            p_pscamt2 = 0;
            p_pscamt3 = 0;
            p_pscamt4 = 0;
            p_pscqty = 0;

            double xxsc = 0;
            double mper = 0;

            // 0    1    2    3    4      5     6      7      8
            // Mkey, Vid, Vno, Ref, pid, sc_rate, pr, win_amt, dlk

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                xxsc = 0;
                mper = Val(Inds[1].Tables[0].Rows[Recno[1]][6]);
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Val(Inds[1].Tables[0].Rows[Recno[2]][6]) == mper & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]][8] = "D";

                        mqty += 1;
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][7]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbsp += xxsc * mqty;

                if (mqty > 0)
                {
                    p_pscqty += mqty;
                    p_pscamt1 += mqty * xxsc;
                    p_pscamt2 += mqty * xxsc;
                    p_pscamt3 += WAMT;
                    p_pscamt4 += (mqty * xxsc) - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Scheme Packet Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1][5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00"));

                    str2 = Rs(xxsc * mqty);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    // If xxsc > 0 Then
                    tab1.Rows[^1][7] = Trim(Format(double.Parse(Trim(Str(mper))), "########.00")) + " %";
                    // End If

                    str2 = Rs(mqty * xxsc);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0((mqty * xxsc) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Qty";
                    tab1.Rows[^1][52] = "Sch . Rate";
                    tab1.Rows[^1][53] = "Packet (Per %)";
                }

                if (Val(pm_pscqty) != 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(p_pscqty))), "########"));
                }

                str2 = Rs(p_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs0(p_pscamt1 - s_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][23] = Trim(str2);
                }

                str2 = Rs(p_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(p_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(p_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        break;
                    }
                    else
                    {
                        Recno[1] += 1;
                    }

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
            }
        }

        public void mixschemepurchase()
        {
            Recno[1] = 0;

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                Inds[1].Tables[0].Rows[Recno[1]][8] = "";
                Recno[1] += 1;
            }

            Recno[1] = 0;

            double WAMT = 0;
            Int16 MVNO = 0;
            var MREF = "";

            Int16 mqty = 0;
            double mrate = 0;
            double mrate1 = 0;

            pm_pscamt1 = 0;
            pm_pscamt2 = 0;
            pm_pscamt3 = 0;
            pm_pscamt4 = 0;
            pm_pscqty = 0;
            double xxsc = 0;
            double ms_com = 0;

            // 0    1     2   3    4      5       6        7      8     9      10     11
            // Mkey, Vid, Vno, Ref, pid, sc_rate, sc_com, win_amt, dlk, mrate, mrate1, Qty

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();

                // ***************************** Ring *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                mrate = 0;
                mrate1 = 0;
                xxsc = 0;
                ms_com = 0;
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "3" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]][8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]][11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]][9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]][10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]][6]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbsr += mrate;

                if (mrate > 0)
                {
                    pm_pscqty += mqty;
                    pm_pscamt1 += mrate;
                    pm_pscamt2 += mrate1;
                    pm_pscamt3 += WAMT;
                    pm_pscamt4 += mrate1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Scheme Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1][5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-R";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if ((mrate / 100 * ms_com) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mrate / 100 * ms_com))), "########.00"));
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Qty";
                    tab1.Rows[^1][52] = "Pkt / Ring";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];

                while (Recno[2] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]) & Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        break;
                    }
                    else
                    {
                        Recno[2] += 1;
                    }

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        Recno[2] = Recno[1];
                        xxsc = 0;
                        break;
                    }
                }

                mqty = 0;
                WAMT = 0;
                mrate = 0;
                mrate1 = 0;
                ms_com = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]][8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]][11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]][9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]][10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]][6]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbsp += mrate;

                if (mrate > 0)
                {
                    pm_pscqty += mqty;
                    pm_pscamt1 += mrate;
                    pm_pscamt2 += mrate1;
                    pm_pscamt3 += WAMT;
                    pm_pscamt4 += mrate1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Scheme Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1][5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-P";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if ((mrate / 100 * ms_com) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mrate / 100 * ms_com))), "########.00"));
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Qty";
                    tab1.Rows[^1][52] = "Pkt / Ring";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Val(pm_pscqty) != 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(pm_pscqty))), "########"));
                }

                str2 = Rs(pm_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs0(pm_pscamt1 - pm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][23] = Trim(str2);
                }

                str2 = Rs(pm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(pm_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(pm_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        break;
                    }
                    else
                    {
                        Recno[1] += 1;
                    }

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
            }
        }

        public void mixpurchase()
        {
            Recno[1] = 0;

            double WAMT = 0;
            Int16 MVNO = 0;
            var MREF = "";
            double mprize = 0;
            double mcom1 = 0;
            double mcom2 = 0;
            double mcom3 = 0;
            double mcom4 = 0;
            double mcom5 = 0;
            double mcom6 = 0;
            double mcom7 = 0;
            double mcom8 = 0;
            double Xmprize = 0;
            double Xwamt = 0;

            p_mixamt1 = 0;
            p_mixamt2 = 0;
            p_mixamt3 = 0;
            p_mixamt4 = 0;

            // 0    1     2   3    4      5       6       7       8       9        10      11      12       13       14        15       16
            // Mkey, Vid, Vno, Ref, pid, Op_com, Ak_com, Td_com, Fc_com, Dot_com, D6_com, Xak_com, Xtd_com, Sc_own, s_prize1, s_prize2, win_amt

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();
                mcom1 = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);
                mcom2 = Val(Inds[1].Tables[0].Rows[Recno[1]][6]);
                mcom3 = Val(Inds[1].Tables[0].Rows[Recno[1]][7]);
                mcom4 = Val(Inds[1].Tables[0].Rows[Recno[1]][8]);
                mcom5 = Val(Inds[1].Tables[0].Rows[Recno[1]][9]);
                mcom6 = Val(Inds[1].Tables[0].Rows[Recno[1]][11]);
                mcom7 = Val(Inds[1].Tables[0].Rows[Recno[1]][12]);
                mcom8 = Val(Inds[1].Tables[0].Rows[Recno[1]][10]);

                // ***************************** Open *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 11)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbo1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Op";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Op";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Close *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 12)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbo1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Cz";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Cz";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Center *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 13)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbo1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Cnt";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Cnt";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Center *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 14)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbo1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XOp";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XOp";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Akara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 22)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpba1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom2;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom2 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Ak";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom2 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom2))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom2) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom2))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom2);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom2 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom2);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom2) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Ak";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom2) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom2)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom2)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom2)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom2));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom2) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** XAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 23)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbx1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom6;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom6 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom6) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom6))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom6);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom6) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom6)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom6)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom6)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** XXAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 24)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbx1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom6;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom6 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XXAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom6) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom6))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom6);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XXAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom6) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom6)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom6)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom6)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Tandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 33)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbt1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom3;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom3 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Td";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom3 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom3))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom3) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom3))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom3);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom3 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom3);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom3) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Td";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom3) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom3)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom3)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom3)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom3));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom3) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** XTandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 34)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xpbxx1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom7;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom7 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XTd";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom7 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom7))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom7) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom7))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom7);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom7 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom7);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom7) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XTd";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom7) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom7)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom7)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom7)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom7));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom7) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Fourcast *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 44)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbf1 += mprize + Xmprize;

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom4;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom4 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Fc";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom4 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom4))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom4) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom4))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom4);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom4 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom4);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom4) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Fc";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom4) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom4)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom4)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom4)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom4));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom4) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Five - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 52)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbd1 += mprize + Xmprize;

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom5;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom5 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "5D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom5 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom5))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom5) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom5))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom5);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom5 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom5);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom5) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "5D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom5) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom5)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom5)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom5)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom5));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom5) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Six - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 62)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpb61 += mprize + Xmprize;

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - mprize / 100 * mcom8;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += mprize - mprize / 100 * mcom8 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "6D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom8 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom8))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom8) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom8))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom8);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom8 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom8);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom8) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                    tab1.Rows[^1][100] = "(( Mix Purchase ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "6D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom8) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom8)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom8)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom8)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom8));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom8) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                str2 = Rs(p_mixamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs0(p_mixamt1 - p_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][23] = Trim(str2);
                }

                str2 = Rs(p_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(p_mixamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(p_mixamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]][2]))
                    {
                        Recno[1] += 1;
                    }
                    else
                    {
                        break;
                    }

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
            }
        }

        public void pktpurchase()
        {
            Recno[1] = 0;

            double MQTY = 0;
            double WAMT = 0;
            Int16 MVNO = 0;
            double MCH_PER = 0;
            var MREF = "";
            double MRATE = 0;

            p_pamt1 = 0;
            p_pamt2 = 0;
            p_pamt3 = 0;
            p_pamt4 = 0;
            p_pqty = 0;

            // 0     1    2    3     4        5       6
            // Mkey, Vid, Vno, Ref, ch_per, pkt_rate, WAMT

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]][4]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);
                Recno[2] = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]][2]))
                {
                    MQTY += 1;
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]][6]);
                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                p_pqty += MQTY;
                p_pamt1 += MQTY * MRATE;
                p_pamt2 += MQTY * MRATE;
                p_pamt3 += WAMT;
                p_pamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "P");
                tab1.Rows[^1][100] = "(( % Packet Purchase ))";
                tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                tab1.Rows[^1][3] = Trim(MREF);
                tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][6] = Trim(str2);
                    tab1.Rows[^1][10] = Trim(str2);
                }

                tab1.Rows[^1][7] = Trim(Str(MCH_PER)) + " %";

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][11] = Trim(str2);
                }

                str2 = Rs0((MQTY * MRATE) - WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][12] = Trim(str2);
                }

                if (s_pqty > 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(p_pqty))), "########"));
                }

                str2 = Rs(p_pamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs(p_pamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(p_pamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(p_pamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                tab1.Rows[^1][51] = "Qty";
                tab1.Rows[^1][52] = "Pkt . Rate";
                tab1.Rows[^1][53] = "Packet (Per %)";
            }
        }

        public void tukrasale()
        {
            Recno[1] = 0;

            double MQTY = 0;
            double WAMT = 0;
            Int16 MVNO = 0;
            double MCH_PER = 0;
            var mchl = "";
            double MRATE = 0;
            var cat = "";

            s_tkamt1 = 0;
            s_tkamt2 = 0;
            s_tkamt3 = 0;
            s_tkamt4 = 0;
            s_tkqty = 0;

            // 0      1        2       3    4      5     6
            // Mkey, ch_per, pkt_rate, chl, cat, win_amt, dlk

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                mchl = Trim(Inds[1].Tables[0].Rows[Recno[1]][3]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]][1]);
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]][2]);
                if (Trim(Inds[1].Tables[0].Rows[Recno[1]][4]) == "Scheme")
                {
                    cat = "Scheme";
                }
                else
                {
                    cat = "";
                }

                MQTY = 0;
                WAMT = 0;

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    MQTY += 1;
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]][5]);

                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                    else if (Val(mchl) != Val(Inds[1].Tables[0].Rows[Recno[1]][3]))
                    {
                        break;
                    }
                }

                s_tkqty += MQTY;
                s_tkamt1 += MQTY * MRATE;
                s_tkamt2 += MQTY * MRATE;
                s_tkamt3 += WAMT;
                s_tkamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                tab1.Rows[^1][100] = "(( Tukra Sale ))";
                tab1.Rows[^1][2] = Right("00000" + Trim(Str(Val(mchl))), 5);
                tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][6] = Trim(str2);
                    tab1.Rows[^1][10] = Trim(str2);
                }

                if (cat == "" & MCH_PER == 0.25)
                {
                    tab1.Rows[^1][7] = "¼ %";
                }

                if (cat == "" & MCH_PER == 0.5)
                {
                    tab1.Rows[^1][7] = "½ %";
                }

                if (cat == "" & MCH_PER >= 1)
                {
                    tab1.Rows[^1][7] = Trim(Str(MCH_PER)) + " %";
                }

                if (cat == "Scheme")
                {
                    tab1.Rows[^1][7] = "Scheme";
                }

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][11] = Trim(str2);
                }

                str2 = Rs0((MQTY * MRATE) - WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][12] = Trim(str2);
                }

                if (s_tkqty > 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(s_tkqty))), "########"));
                }

                str2 = Rs(s_tkamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs(s_tkamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(s_tkamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(s_tkamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                tab1.Rows[^1][51] = "Qty";
                tab1.Rows[^1][52] = "Tukra Rate";
                tab1.Rows[^1][53] = "Less Comm %";
            }
        }

        public void chartsale()
        {
            Recno[1] = 0;

            double MQTY = 0;
            double WAMT = 0;
            Int16 MVNO = 0;
            double MCH_PER = 0;
            var mchl = "";
            double MRATE = 0;

            s_camt1 = 0;
            s_camt2 = 0;
            s_camt3 = 0;
            s_camt4 = 0;
            s_cqty = 0;

            // 0      1        2       3     4       5     6
            // Mkey, ch_per, pkt_rate, chl, ctype, ch_no1, dlk

            // 0      1      2        3
            // Mkey, CType, ch_no1, win_amt

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                mchl = Trim(Inds[1].Tables[0].Rows[Recno[1]][3]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]][1]);
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MQTY = 0;
                WAMT = 0;

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    MQTY += 1;
                    Recno[2] = 0;

                    while (Recno[2] < Inds[2].Tables[0].Rows.Count)
                    {
                        if (Trim(Trim(Inds[1].Tables[0].Rows[Recno[1]][4])) == Trim(Trim(Inds[2].Tables[0].Rows[Recno[2]][1])) & Val(Inds[1].Tables[0].Rows[Recno[1]][5]) == Val(Inds[2].Tables[0].Rows[Recno[2]][2]))
                        {
                            WAMT += Val(Inds[2].Tables[0].Rows[Recno[2]][3]);
                        }

                        Recno[2] += 1;
                    }

                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                    else if (Val(mchl) != Val(Inds[1].Tables[0].Rows[Recno[1]][3]))
                    {
                        break;
                    }
                }

                s_cqty += MQTY;
                s_camt1 += MQTY * MRATE;
                s_camt2 += MQTY * MRATE;
                s_camt3 += WAMT;
                s_camt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                tab1.Rows[^1][100] = "(( Chart Sale ))";
                tab1.Rows[^1][2] = Right("00000" + Trim(Str(Val(mchl))), 5);
                tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][6] = Trim(str2);
                    tab1.Rows[^1][10] = Trim(str2);
                }

                if (MCH_PER == 0.25)
                {
                    tab1.Rows[^1][7] = "¼ %";
                }

                if (MCH_PER == 0.5)
                {
                    tab1.Rows[^1][7] = "½ %";
                }

                if (MCH_PER >= 1)
                {
                    tab1.Rows[^1][7] = Trim(Str(MCH_PER)) + " %";
                }

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][11] = Trim(str2);
                }

                str2 = Rs0((MQTY * MRATE) - WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][12] = Trim(str2);
                }

                if (s_cqty > 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(s_cqty))), "########"));
                }

                str2 = Rs(s_camt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs(s_camt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(s_camt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(s_camt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                tab1.Rows[^1][51] = "Qty";
                tab1.Rows[^1][52] = "Chart Rate";
                tab1.Rows[^1][53] = "Type / Com%";
            }
        }

        public void schemepacketsale()
        {
            Recno[1] = 0;

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                Inds[1].Tables[0].Rows[Recno[1]][8] = "";
                Recno[1] += 1;
            }

            Recno[1] = 0;

            double WAMT = 0;
            Int16 MVNO = 0;
            var MREF = "";

            Int16 mqty = 0;

            s_pscamt1 = 0;
            s_pscamt2 = 0;
            s_pscamt3 = 0;
            s_pscamt4 = 0;
            s_pscqty = 0;

            double xxsc = 0;
            double mper = 0;

            // 0    1    2    3    4      5     6      7      8
            // Mkey, Vid, Vno, Ref, pid, sc_rate, pr, win_amt, dlk

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                xxsc = 0;
                mper = Val(Inds[1].Tables[0].Rows[Recno[1]][6]);
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Val(Inds[1].Tables[0].Rows[Recno[2]][6]) == mper & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]][8] = "D";

                        mqty += 1;
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][7]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbsp += (xxsc * mqty);
                if (mqty > 0)
                {
                    s_pscqty += mqty;
                    s_pscamt1 += mqty * xxsc;
                    s_pscamt2 += mqty * xxsc;
                    s_pscamt3 += WAMT;
                    s_pscamt4 += (mqty * xxsc) - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Scheme Packet Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1][5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00"));

                    str2 = Rs(xxsc * mqty);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    // If xxsc > 0 Then
                    tab1.Rows[^1][7] = Trim(Format(double.Parse(Trim(Str(mper))), "########.00")) + " %";
                    // End If

                    str2 = Rs(mqty * xxsc);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0((mqty * xxsc) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Qty";
                    tab1.Rows[^1][52] = "Sch . Rate";
                    tab1.Rows[^1][53] = "Packet (Per %)";
                }

                if (Val(sm_pscqty) != 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(s_pscqty))), "########"));
                }

                str2 = Rs(s_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs0(s_pscamt1 - s_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][23] = Trim(str2);
                }

                str2 = Rs(s_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(s_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(s_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        break;
                    }
                    else
                    {
                        Recno[1] += 1;
                    }

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
            }
        }

        public void mixschemesale()
        {
            Recno[1] = 0;

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                Inds[1].Tables[0].Rows[Recno[1]][8] = "";
                Recno[1] += 1;
            }

            Recno[1] = 0;

            double WAMT = 0;
            Int16 MVNO = 0;
            var MREF = "";

            Int16 mqty = 0;
            double mrate = 0;
            double mrate1 = 0;

            sm_pscamt1 = 0;
            sm_pscamt2 = 0;
            sm_pscamt3 = 0;
            sm_pscamt4 = 0;
            sm_pscqty = 0;
            double xxsc = 0;
            double ms_com = 0;

            // 0    1     2   3    4      5       6        7      8     9      10     11
            // Mkey, Vid, Vno, Ref, pid, sc_rate, sc_com, win_amt, dlk, mrate, mrate1, Qty

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();

                // ***************************** Ring *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                mrate = 0;
                mrate1 = 0;
                xxsc = 0;
                ms_com = 0;
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "3" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]][8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]][11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]][9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]][10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]][6]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbsr += mrate;
                if (mrate > 0)
                {
                    sm_pscqty += mqty;
                    sm_pscamt1 += mrate;
                    sm_pscamt2 += mrate1;
                    sm_pscamt3 += WAMT;
                    sm_pscamt4 += mrate1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Scheme Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1][5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-R";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if ((mrate / 100 * ms_com) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mrate / 100 * ms_com))), "########.00"));
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Qty";
                    tab1.Rows[^1][52] = "Pkt / Ring";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];

                while (Recno[2] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]) & Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        break;
                    }
                    else
                    {
                        Recno[2] += 1;
                    }

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        Recno[2] = Recno[1];
                        xxsc = 0;
                        break;
                    }
                }

                mqty = 0;
                WAMT = 0;
                mrate = 0;
                mrate1 = 0;
                ms_com = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]][4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]][5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]][8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]][11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]][9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]][10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]][6]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbsp += mrate;
                if (mrate > 0)
                {
                    sm_pscqty += mqty;
                    sm_pscamt1 += mrate;
                    sm_pscamt2 += mrate1;
                    sm_pscamt3 += WAMT;
                    sm_pscamt4 += mrate1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Scheme Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1][5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-P";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if ((mrate / 100 * ms_com) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mrate / 100 * ms_com))), "########.00"));
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mrate - mrate / 100 * ms_com - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Qty";
                    tab1.Rows[^1][52] = "Pkt / Ring";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Val(sm_pscqty) != 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(sm_pscqty))), "########"));
                }

                str2 = Rs(sm_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs0(sm_pscamt1 - sm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][23] = Trim(str2);
                }

                str2 = Rs(sm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(sm_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(sm_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]][8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        break;
                    }
                    else
                    {
                        Recno[1] += 1;
                    }

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
            }
        }

        public void mixsale()
        {
            Recno[1] = 0;

            double WAMT = 0;
            Int16 MVNO = 0;
            var MREF = "";
            double mprize = 0;
            double mcom1 = 0;
            double mcom2 = 0;
            double mcom3 = 0;
            double mcom4 = 0;
            double mcom5 = 0;
            double mcom6 = 0;
            double mcom7 = 0;
            double mcom8 = 0;
            double Xmprize = 0;
            double Xwamt = 0;

            s_mixamt1 = 0;
            s_mixamt2 = 0;
            s_mixamt3 = 0;
            s_mixamt4 = 0;
            s_mixamt5 = 0;

            // 0    1     2   3    4      5       6       7       8       9        10      11      12       13       14        15       16
            // Mkey, Vid, Vno, Ref, pid, Op_com, Ak_com, Td_com, Fc_com, Dot_com, D6_com, Xak_com, Xtd_com, Sc_own, s_prize1, s_prize2, win_amt

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();
                mcom1 = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);
                mcom2 = Val(Inds[1].Tables[0].Rows[Recno[1]][6]);
                mcom3 = Val(Inds[1].Tables[0].Rows[Recno[1]][7]);
                mcom4 = Val(Inds[1].Tables[0].Rows[Recno[1]][8]);
                mcom5 = Val(Inds[1].Tables[0].Rows[Recno[1]][9]);
                mcom6 = Val(Inds[1].Tables[0].Rows[Recno[1]][11]);
                mcom7 = Val(Inds[1].Tables[0].Rows[Recno[1]][12]);
                mcom8 = Val(Inds[1].Tables[0].Rows[Recno[1]][10]);

                // ***************************** Open *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 11)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbo1 += mprize + Xmprize;
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom1;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Op";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Op";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Close *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 12)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbo1 += mprize + Xmprize;
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom1;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Cz";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Cz";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Center *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 13)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbo1 += mprize + Xmprize;
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100 * mcom1);
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Cnt";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Cnt";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** XOpen *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 14)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbo1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom1;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom1 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XOp";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom1) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom1))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom1 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom1);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XOp";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom1) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom1)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom1)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom1)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom1) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Akara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 22)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsba1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom2;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom2 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Ak";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom2 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom2))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom2) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom2))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom2);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom2 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom2);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom2) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Ak";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom2) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom2)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom2)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom2)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom2));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom2) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** XAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 23)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbx1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom6;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom6 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom6) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom6))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom6);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom6) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom6)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom6)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom6)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** XXAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 24)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbx1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom6;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom6 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XXAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom6) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom6))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom6 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom6);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XXAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom6) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom6)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom6)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom6)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom6) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Tandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 33)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbt1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom3;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom3 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Td";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom3 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom3))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom3) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom3))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom3);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom3 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom3);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom3) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Td";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom3) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom3)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom3)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom3)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom3));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom3) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** XTandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 34)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbxx1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom7;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom7 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "XTd";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom7 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom7))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom7) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom7))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom7);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom7 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom7);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom7) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "XTd";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom7) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom7)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom7)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom7)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom7));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom7) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Fourcast *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 44)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbf1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom4;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom4 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "Fc";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom4 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom4))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom4) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom4))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom4);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom4 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom4);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom4) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "Fc";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom4) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom4)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom4)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom4)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom4));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom4) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Five - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 52)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsbd1 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom5;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom5 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "5D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom5 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom5))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom5) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom5))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom5);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom5 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom5);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom5) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "5D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom5) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom5)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom5)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom5)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom5));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom5) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                // ***************************** Six - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]][2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]][4]) == 62)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]][6]) != 88)
                        {
                            mprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                        else
                        {
                            Xmprize += Val(Inds[1].Tables[0].Rows[Recno[2]][14]) + Val(Inds[1].Tables[0].Rows[Recno[2]][15]);
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]][16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                xsb61 += (mprize + Xmprize);
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - mprize / 100 * mcom8;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += mprize - mprize / 100 * mcom8 - WAMT;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = Trim(MREF);
                    tab1.Rows[^1][4] = "6D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (mcom8 > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(mcom8))), "########.00")) + "%";
                    }

                    if ((mprize / 100 * mcom8) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(mprize / 100 * mcom8))), "########.00"));
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom8);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(mprize - mprize / 100 * mcom8 - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - Xmprize / 100 * Val(mcom8);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += Xmprize - Xmprize / 100 * Val(mcom8) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                    tab1.Rows[^1][100] = "(( Mix Sale ))";
                    tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1][3] = "Diversion";
                    tab1.Rows[^1][4] = "6D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][6] = Trim(str2);
                    }

                    if (Val(mcom8) > 0)
                    {
                        tab1.Rows[^1][8] = Trim(Format(double.Parse(Trim(Str(Val(mcom8)))), "########.00")) + "%";
                    }

                    if ((Xmprize / 100 * Val(mcom8)) != 0)
                    {
                        tab1.Rows[^1][9] = Trim(Format(double.Parse(Trim(Str(Xmprize / 100 * Val(mcom8)))), "########.00"));
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom8));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][11] = Trim(str2);
                    }

                    str2 = Rs0(Xmprize - Xmprize / 100 * Val(mcom8) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1][12] = Trim(str2);
                    }

                    tab1.Rows[^1][51] = "Digit";
                    tab1.Rows[^1][53] = "Less Comm %";
                }

                str2 = Rs(s_mixamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs0(s_mixamt1 - s_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][23] = Trim(str2);
                }

                str2 = Rs(s_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(s_mixamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(s_mixamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]][2]))
                    {
                        Recno[1] += 1;
                    }
                    else
                    {
                        break;
                    }

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
            }
        }

        public void pktsale()
        {
            Recno[1] = 0;

            double MQTY = 0;
            double WAMT = 0;
            Int16 MVNO = 0;
            double MCH_PER = 0;
            var MREF = "";
            double MRATE = 0;

            s_pamt1 = 0;
            s_pamt2 = 0;
            s_pamt3 = 0;
            s_pamt4 = 0;
            s_pqty = 0;

            // 0     1    2    3     4        5       6
            // Mkey, Vid, Vno, Ref, ch_per, pkt_rate, WAMT

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]][2]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]][4]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]][3].ToString();
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]][5]);
                Recno[2] = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]][2]))
                {
                    MQTY += 1;
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]][6]);
                    Recno[1] += 1;
                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                s_pqty += MQTY;
                s_pamt1 += MQTY * MRATE;
                s_pamt2 += MQTY * MRATE;
                s_pamt3 += WAMT;
                s_pamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(party.Code) + " - " + Trim(party.Name) + " )))", "S");
                tab1.Rows[^1][100] = "(( % Packet Sale ))";
                tab1.Rows[^1][2] = Right("00000" + Trim(Str(MVNO)), 5);
                tab1.Rows[^1][3] = Trim(MREF);
                tab1.Rows[^1][4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][6] = Trim(str2);
                    tab1.Rows[^1][10] = Trim(str2);
                }

                tab1.Rows[^1][7] = Trim(Str(MCH_PER)) + " %";

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][11] = Trim(str2);
                }

                str2 = Rs0((MQTY * MRATE) - WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][12] = Trim(str2);
                }

                if (s_pqty > 0)
                {
                    tab1.Rows[^1][21] = Trim(Format(double.Parse(Trim(Str(s_pqty))), "########"));
                }

                str2 = Rs(s_pamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][22] = Trim(str2);
                }

                str2 = Rs(s_pamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][24] = Trim(str2);
                }

                str2 = Rs(s_pamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][25] = Trim(str2);
                }

                str2 = Rs(s_pamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1][26] = Trim(str2);
                }

                tab1.Rows[^1][51] = "Qty";
                tab1.Rows[^1][52] = "Pkt . Rate";
                tab1.Rows[^1][53] = "Packet (Per %)";
            }
        }
    }
}