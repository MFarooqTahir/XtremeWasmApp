using System.Data;
using System.Globalization;

using XtremeModels;

namespace XtremeWasmApp.Pages
{
    public partial class PartyBill
    {


        readonly List<DataSet> Inds = new(3) { new(), new(), new() };
        List<int> Recno = new List<int> { 0, 0, 0, 0, 0 };
        int xxkey = 0;
        double s_pamt1, s_pamt2, s_pamt3, s_pamt4, s_pqty;
        double s_mixamt1, s_mixamt2, s_mixamt3, s_mixamt4, s_mixamt5;
        double s_pscamt1, s_pscamt2, s_pscamt3, s_pscamt4, s_scpqty, s_pscqty;
        double s_rscamt1, s_rscamt2, s_rscamt3, s_rscamt4;
        double s_camt1, s_camt2, s_camt3, s_camt4, s_cqty;
        double s_tkamt1, s_tkamt2, s_tkamt3, s_tkamt4, s_tkqty;
        double p_pamt1, p_pamt2, p_pamt3, p_pamt4, p_pqty;
        double p_mixamt1, p_mixamt2, p_mixamt3, p_mixamt4;
        double p_pscamt1, p_pscamt2, p_pscamt3, p_pscamt4, p_pscqty;
        double p_rscamt1, p_rscamt2, p_rscamt3, p_rscamt4, p_scpqty;
        double p_camt1, p_camt2, p_camt3, p_camt4, p_cqty;
        double p_tkamt1, p_tkamt2, p_tkamt3, p_tkamt4, p_tkqty;
        double sm_pscamt1, sm_pscamt2, sm_pscamt3, sm_pscamt4, sm_pscqty;
        double pm_pscamt1, pm_pscamt2, pm_pscamt3, pm_pscamt4, pm_pscqty;
        double xsbo1, xsba1, xsbx1, xsbt1, xsbxx1, xsbf1, xsbd1, xsb61, xsbsp, xsbsr, xpbo1, xpba1, xpbx1, xpbt1, xpbxx1, xpbf1, xpbd1, xpb61, xpbsp, xpbsr;
        string str2 = "";
        DataTable tab1 = new DataTable("New Data");
        Party party;
        CultureInfo numCulture = new CultureInfo("en-IN");
        protected override void OnInitialized()
        {
            numCulture.NumberFormat.CurrencySymbol = string.Empty;
            base.OnInitialized();
        }
        public async Task report()
        {
            tab1.Columns.Add("PID");
            tab1.Columns.Add("TG");

            tab1.Columns.Add("H2");
            tab1.Columns.Add("H3");
            tab1.Columns.Add("H4");
            tab1.Columns.Add("H5");
            tab1.Columns.Add("H6");
            tab1.Columns.Add("H7");
            tab1.Columns.Add("H8");
            tab1.Columns.Add("H9");
            tab1.Columns.Add("H10");

            tab1.Columns.Add("H11");
            tab1.Columns.Add("H12");
            tab1.Columns.Add("H13");
            tab1.Columns.Add("H14");
            tab1.Columns.Add("H15");
            tab1.Columns.Add("H16");
            tab1.Columns.Add("H17");
            tab1.Columns.Add("H18");
            tab1.Columns.Add("H19");
            tab1.Columns.Add("H20");

            tab1.Columns.Add("H21");
            tab1.Columns.Add("H22");
            tab1.Columns.Add("H23");
            tab1.Columns.Add("H24");
            tab1.Columns.Add("H25");
            tab1.Columns.Add("H26");
            tab1.Columns.Add("H27");
            tab1.Columns.Add("H28");
            tab1.Columns.Add("H29");
            tab1.Columns.Add("H30");

            tab1.Columns.Add("H31");
            tab1.Columns.Add("H32");
            tab1.Columns.Add("H33");
            tab1.Columns.Add("H34");
            tab1.Columns.Add("H35");
            tab1.Columns.Add("H36");
            tab1.Columns.Add("H37");
            tab1.Columns.Add("H38");
            tab1.Columns.Add("H39");
            tab1.Columns.Add("H40");

            tab1.Columns.Add("H41");
            tab1.Columns.Add("H42");
            tab1.Columns.Add("H43");
            tab1.Columns.Add("H44");
            tab1.Columns.Add("H45");
            tab1.Columns.Add("H46");
            tab1.Columns.Add("H47");
            tab1.Columns.Add("H48");
            tab1.Columns.Add("H49");
            tab1.Columns.Add("H50");

            tab1.Columns.Add("H51");
            tab1.Columns.Add("H52");
            tab1.Columns.Add("H53");
            tab1.Columns.Add("H54");
            tab1.Columns.Add("H55");
            tab1.Columns.Add("H56");
            tab1.Columns.Add("H57");
            tab1.Columns.Add("H58");
            tab1.Columns.Add("H59");
            tab1.Columns.Add("H60");

            tab1.Columns.Add("H61");
            tab1.Columns.Add("H62");
            tab1.Columns.Add("H63");
            tab1.Columns.Add("H64");
            tab1.Columns.Add("H65");
            tab1.Columns.Add("H66");
            tab1.Columns.Add("H67");
            tab1.Columns.Add("H68");
            tab1.Columns.Add("H69");
            tab1.Columns.Add("H70");

            tab1.Columns.Add("H71");
            tab1.Columns.Add("H72");
            tab1.Columns.Add("H73");
            tab1.Columns.Add("H74");
            tab1.Columns.Add("H75");
            tab1.Columns.Add("H76");
            tab1.Columns.Add("H77");
            tab1.Columns.Add("H78");
            tab1.Columns.Add("H79");
            tab1.Columns.Add("H80");

            tab1.Columns.Add("H81");
            tab1.Columns.Add("H82");
            tab1.Columns.Add("H83");
            tab1.Columns.Add("H84");
            tab1.Columns.Add("H85");
            tab1.Columns.Add("H86");
            tab1.Columns.Add("H87");
            tab1.Columns.Add("H88");
            tab1.Columns.Add("H89");
            tab1.Columns.Add("H90");

            tab1.Columns.Add("H91");
            tab1.Columns.Add("H92");
            tab1.Columns.Add("H93");
            tab1.Columns.Add("H94");
            tab1.Columns.Add("H95");
            tab1.Columns.Add("H96");
            tab1.Columns.Add("H97");
            tab1.Columns.Add("H98");
            tab1.Columns.Add("H99");
            tab1.Columns.Add("CTIT");

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

            // Main.Ltitle.Text = "Fetching Mix Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"


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

            // Main.Ltitle.Text = "Fetching Mix-Scheme Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"


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

            // Main.Ltitle.Text = "Fetching Scheme Packet Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"

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

            // Main.Ltitle.Text = "Fetching Chart Sale ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"

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
                tab1.Rows[^1].ItemArray[30] = "⁞⁞ Total Sale";


                str2 = Rs(Math.Ceiling(s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[31] = str2.Trim();


                }

                str2 = Rs0((s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1) - (s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[32] = str2.Trim();


                }

                str2 = Rs(Math.Ceiling(s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[33] = str2.Trim();


                }

                str2 = Rs(Math.Round(s_pamt3 + s_camt3 + s_tkamt3 + s_mixamt3 + s_pscamt3 + s_rscamt3 + sm_pscamt3));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[34] = str2.Trim();

                }

                str2 = Rs(Math.Ceiling(s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[35] = str2.Trim();

                }
            }

            // *********************************************************************************************************************

            // Main.Ltitle.Text = "Fetching % Packet Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"

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

            // Main.Ltitle.Text = "Fetching Mix Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"

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

            // Main.Ltitle.Text = "Fetching Mix-Scheme Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"

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

            // Main.Ltitle.Text = "Fetching Scheme Packet Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"

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

            // Main.Ltitle.Text = "Fetching Tukra Purchase ( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1)) + " )"

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
                tab1.Rows[^1].ItemArray[30] = "⁞⁞ Total Purchase";

                str2 = Rs(Math.Ceiling(p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[31] = str2.Trim();


                }

                str2 = Rs0((p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1) - (p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[32] = str2.Trim();


                }

                str2 = Rs(Math.Ceiling(p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[33] = str2.Trim();


                }

                str2 = Rs(Math.Round(p_pamt3 + p_tkamt3 + p_mixamt3 + p_pscamt3 + p_rscamt3 + pm_pscamt3));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[34] = str2.Trim();


                }

                str2 = Rs(Math.Ceiling(p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt4));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[35] = str2.Trim();


                }
            }

            // Net Amount 

            if ((s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + s_pamt3 + s_camt3 + s_tkamt3 + s_mixamt3 + s_pscamt3 + s_rscamt3 + p_pamt3 + p_tkamt3 + p_mixamt3 + p_pscamt3 + p_rscamt3 + s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt1 + pm_pscamt2 + pm_pscamt3 + pm_pscamt4 + sm_pscamt1 + sm_pscamt2 + sm_pscamt3 + sm_pscamt4) != 0)
            {
                str2 = Rs(Math.Round((s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1) - (p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1)));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[41] = str2.Trim();


                }

                str2 = Rs(Math.Round(((s_pamt1 + s_camt1 + s_tkamt1 + s_mixamt1 + s_pscamt1 + s_rscamt1 + sm_pscamt1) - (p_pamt1 + p_tkamt1 + p_mixamt1 + p_pscamt1 + p_rscamt1 + pm_pscamt1)) - ((s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2) - (p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2))));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[42] = str2.Trim();


                }

                str2 = Rs(Math.Round((s_pamt2 + s_camt2 + s_tkamt2 + s_mixamt2 + s_pscamt2 + s_rscamt2 + sm_pscamt2) - (p_pamt2 + p_tkamt2 + p_mixamt2 + p_pscamt2 + p_rscamt2 + pm_pscamt2)));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[43] = str2.Trim();


                }

                str2 = Rs(Math.Round((s_pamt3 + s_camt3 + s_tkamt3 + s_mixamt3 + s_pscamt3 + s_rscamt3 + sm_pscamt3) - (p_pamt3 + p_tkamt3 + p_mixamt3 + p_pscamt3 + p_rscamt3 + pm_pscamt3)));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[44] = str2.Trim();

                }

                str2 = Rs(Math.Round((s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4) - (p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt4)));
                var str2x = (Math.Round((s_pamt4 + s_camt4 + s_tkamt4 + s_mixamt4 + s_pscamt4 + s_rscamt4 + sm_pscamt4) - (p_pamt4 + p_tkamt4 + p_mixamt4 + p_pscamt4 + p_rscamt4 + pm_pscamt4)));

                if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
                {
                    tab1.Rows[^1].ItemArray[45] = str2.Trim();
                    //if (rlist > 0 & Main.account && bool.Parse(Inds[0].Tables[0].Rows[Recno[0]]["actac"].ToString()) && !bool.Parse(Inds[0].Tables[0].Rows[Recno[0]]["acind"].ToString()))
                    //{
                    //    // Dim xx = Mid(MainMenu.Ld3.Text, 4, 2)
                    //    DateTime xdate = (Right(MainMenu.Ld3.Text, 4) + "-" + Mid(MainMenu.Ld3.Text, 4, 2) + "-" + Left(MainMenu.Ld3.Text, 2));
                    //    string xxdate = (Left(MainMenu.Ld3.Text, 2) + "-" + Mid(MainMenu.Ld3.Text, 4, 2) + "-" + Right(MainMenu.Ld3.Text, 4));
                    //    string xdes = "Rs. " + Trim(MainMenu.Ld1.Text) + " - " + Trim(MainMenu.Ld2.Text) + "  " + Trim(MainMenu.Ld2c.Text) + IIf(MainMenu.Ld2c.Text == "", "", "  ") + Trim(xxdate) + "  " + Trim(MainMenu.Ld4.Text);
                    //    var xxxxr = await ApiLink.GetRequestAsync<bool>($"api/Data/TransdtlIns/{-1}/D/{Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray["Code"))}/{xdes}/{"0"}/{xdate}/{"0"}/{IIf(int.Parse(str2,CultureInfo.InvariantCulture) < 0, Math.Abs(int.Parse(str2,CultureInfo.InvariantCulture)), 0)}/{IIf(int.Parse(str2,CultureInfo.InvariantCulture) > 0, int.Parse(str2,CultureInfo.InvariantCulture), 0)}/{true}", Config.BaseURLD);
                    //}

                }
            }

            str2 = Rs(xsbo1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[61] = str2.Trim();
            }

            str2 = Rs(xsba1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[62] = str2.Trim();
            }

            str2 = Rs(xsbx1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[63] = str2.Trim();
            }

            str2 = Rs(xsbt1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[64] = str2.Trim();
            }

            str2 = Rs(xsbxx1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[65] = str2.Trim();
            }

            str2 = Rs(xsbf1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[66] = str2.Trim();
            }

            str2 = Rs(xsbd1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[67] = str2.Trim();
            }

            str2 = Rs(xsb61);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[68] = str2.Trim();
            }

            str2 = Rs(xsbsp);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[69] = str2.Trim();
            }

            str2 = Rs(xsbsr);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[70] = str2.Trim();
            }

            str2 = Rs(xpbo1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[71] = str2.Trim();
            }

            str2 = Rs(xpba1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[72] = str2.Trim();
            }

            str2 = Rs(xpbx1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[73] = str2.Trim();
            }

            str2 = Rs(xpbt1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[74] = str2.Trim();
            }

            str2 = Rs(xpbxx1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[75] = str2.Trim();
            }

            str2 = Rs(xpbf1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[76] = str2.Trim();
            }

            str2 = Rs(xpbd1);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[77] = str2.Trim();
            }

            str2 = Rs(xpb61);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[78] = str2.Trim();
            }

            str2 = Rs(xpbsp);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[79] = str2.Trim();
            }

            str2 = Rs(xpbsr);

            if (int.Parse(str2, CultureInfo.InvariantCulture) != 0)
            {
                tab1.Rows[^1].ItemArray[80] = str2.Trim();
            }

            var XDATE = await Api.GetDateTime().ConfigureAwait(false);

















            tab1.Clear();
            Recno[0] += 1;
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
                mchl = Trim(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[1]);
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                if (Trim(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[4]) == "Scheme")
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
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);

                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                    else if (Val(mchl) != Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3]))
                    {
                        break;
                    }
                }

                p_tkqty += MQTY;
                p_tkamt1 += MQTY * MRATE;
                p_tkamt2 += MQTY * MRATE;
                p_tkamt3 += WAMT;
                p_tkamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                tab1.Rows[^1].ItemArray[100] = "(( Tukra Purchase ))";
                tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(Val(mchl))), 5);
                tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    tab1.Rows[^1].ItemArray[10] = Trim(str2);
                }


                if (cat == "" & MCH_PER == 0.25)
                {
                    tab1.Rows[^1].ItemArray[7] = "¼ %";
                }

                if (cat == "" & MCH_PER == 0.5)
                {
                    tab1.Rows[^1].ItemArray[7] = "½ %";
                }

                if (cat == "" & MCH_PER >= 1)
                {
                    tab1.Rows[^1].ItemArray[7] = Trim(Str(MCH_PER)) + " %";
                }

                if (cat == "Scheme")
                {
                    tab1.Rows[^1].ItemArray[7] = "Scheme";
                }

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[11] = Trim(str2);
                }

                str2 = Rs0(((MQTY * MRATE) - WAMT));

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[12] = Trim(str2);
                }

                if (p_tkqty > 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(p_tkqty))), "########"));
                }

                str2 = Rs(p_tkamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs(p_tkamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(p_tkamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(p_tkamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                tab1.Rows[^1].ItemArray[51] = "Qty";
                tab1.Rows[^1].ItemArray[52] = "Tukra Rate";
                tab1.Rows[^1].ItemArray[53] = "Less Comm %";
            }
        }

        public void schemepacketpurchase()
        {
            Recno[1] = 0;

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] = "";
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                xxsc = 0;
                mper = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[6]);
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) == mper & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] = "D";

                        mqty += 1;
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[7]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbsp += (xxsc * mqty);

                if (mqty > 0)
                {
                    p_pscqty += mqty;
                    p_pscamt1 += mqty * xxsc;
                    p_pscamt2 += mqty * xxsc;
                    p_pscamt3 += WAMT;
                    p_pscamt4 += (mqty * xxsc) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Scheme Packet Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1].ItemArray[5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00"));

                    str2 = Rs(xxsc * mqty);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    // If xxsc > 0 Then
                    tab1.Rows[^1].ItemArray[7] = Trim(Format(double.Parse(Trim(Str(mper))), "########.00")) + " %";
                    // End If

                    str2 = Rs((mqty * xxsc));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mqty * xxsc) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Qty";
                    tab1.Rows[^1].ItemArray[52] = "Sch . Rate";
                    tab1.Rows[^1].ItemArray[53] = "Packet (Per %)";
                }

                if (Val(pm_pscqty) != 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(p_pscqty))), "########"));
                }

                str2 = Rs(p_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs0(p_pscamt1 - s_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[23] = Trim(str2);
                }

                str2 = Rs(p_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(p_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(p_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
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
                Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] = "";
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();

                // ***************************** Ring *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                mrate = 0;
                mrate1 = 0;
                xxsc = 0;
                ms_com = 0;
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "3" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]);
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
                    pm_pscamt4 += (mrate1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Scheme Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1].ItemArray[5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-R";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if (((mrate / 100) * ms_com) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mrate / 100) * ms_com)))), "########.00"));
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Qty";
                    tab1.Rows[^1].ItemArray[52] = "Pkt / Ring";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];

                while (Recno[2] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]) & Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
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

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]);
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
                    pm_pscamt4 += (mrate1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Scheme Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1].ItemArray[5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-P";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if (((mrate / 100) * ms_com) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mrate / 100) * ms_com)))), "########.00"));
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Qty";
                    tab1.Rows[^1].ItemArray[52] = "Pkt / Ring";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                if (Val(pm_pscqty) != 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(pm_pscqty))), "########"));
                }

                str2 = Rs(pm_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs0(pm_pscamt1 - pm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[23] = Trim(str2);
                }

                str2 = Rs(pm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(pm_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(pm_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();
                mcom1 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);
                mcom2 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[6]);
                mcom3 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[7]);
                mcom4 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8]);
                mcom5 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[9]);
                mcom6 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[11]);
                mcom7 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[12]);
                mcom8 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[10]);

                // ***************************** Open *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 11)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Op";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Op";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Close *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 12)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Cz";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Cz";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Center *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 13)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }


                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Cnt";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Cnt";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Center *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 14)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }


                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom1;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XOp";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XOp";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Akara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 22)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom2;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom2) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Ak";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom2 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom2))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom2)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom2));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom2) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Ak";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** XAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 23)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom6;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom6) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom6) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom6)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** XXAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 24)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom6;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom6) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XXAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom6) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom6)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XXAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Tandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 33)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom3;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom3) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Td";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom3 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom3))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom3) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom3)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom3));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom3) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Td";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** XTandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 34)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }



                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom7;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom7) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XTd";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom7 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom7))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom7) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom7)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom7));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom7) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XTd";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Fourcast *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 44)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbf1 += (mprize + Xmprize);

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom4;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom4) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Fc";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom4 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom4))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom4) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom4)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom4));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom4) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Fc";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Five - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 52)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpbd1 += (mprize + Xmprize);

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom5;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom5) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "5D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom5 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom5))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom5) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom5)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom5));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom5) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "5D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Six - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 62)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                xpb61 += (mprize + Xmprize);

                if (mprize != 0)
                {
                    p_mixamt1 += mprize;
                    p_mixamt2 += mprize - (mprize / 100) * mcom8;
                    p_mixamt3 += WAMT;
                    p_mixamt4 += (mprize - (mprize / 100) * mcom8) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "6D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom8 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom8))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom8) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom8)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom8));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom8) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    p_mixamt1 += Xmprize;
                    p_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13]);
                    p_mixamt3 += Xwamt;
                    p_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Purchase ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "6D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                str2 = Rs(p_mixamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs0(p_mixamt1 - p_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[23] = Trim(str2);
                }

                str2 = Rs(p_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(p_mixamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(p_mixamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]))
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[4]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);
                Recno[2] = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]))
                {
                    MQTY += 1;
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[6]);
                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                p_pqty += MQTY;
                p_pamt1 += (MQTY * MRATE);
                p_pamt2 += (MQTY * MRATE);
                p_pamt3 += WAMT;
                p_pamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "P");
                tab1.Rows[^1].ItemArray[100] = "(( % Packet Purchase ))";
                tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    tab1.Rows[^1].ItemArray[10] = Trim(str2);
                }

                tab1.Rows[^1].ItemArray[7] = Trim(Str(MCH_PER)) + " %";

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[11] = Trim(str2);
                }

                str2 = Rs0(((MQTY * MRATE) - WAMT));

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[12] = Trim(str2);
                }

                if (s_pqty > 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(p_pqty))), "########"));
                }

                str2 = Rs(p_pamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs(p_pamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(p_pamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(p_pamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                tab1.Rows[^1].ItemArray[51] = "Qty";
                tab1.Rows[^1].ItemArray[52] = "Pkt . Rate";
                tab1.Rows[^1].ItemArray[53] = "Packet (Per %)";
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
                mchl = Trim(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[1]);
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                if (Trim(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[4]) == "Scheme")
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
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);

                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                    else if (Val(mchl) != Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3]))
                    {
                        break;
                    }
                }

                s_tkqty += MQTY;
                s_tkamt1 += MQTY * MRATE;
                s_tkamt2 += MQTY * MRATE;
                s_tkamt3 += WAMT;
                s_tkamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                tab1.Rows[^1].ItemArray[100] = "(( Tukra Sale ))";
                tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(Val(mchl))), 5);
                tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    tab1.Rows[^1].ItemArray[10] = Trim(str2);
                }


                if (cat == "" & MCH_PER == 0.25)
                {
                    tab1.Rows[^1].ItemArray[7] = "¼ %";
                }

                if (cat == "" & MCH_PER == 0.5)
                {
                    tab1.Rows[^1].ItemArray[7] = "½ %";
                }

                if (cat == "" & MCH_PER >= 1)
                {
                    tab1.Rows[^1].ItemArray[7] = Trim(Str(MCH_PER)) + " %";
                }

                if (cat == "Scheme")
                {
                    tab1.Rows[^1].ItemArray[7] = "Scheme";
                }

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[11] = Trim(str2);
                }

                str2 = Rs0(((MQTY * MRATE) - WAMT));

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[12] = Trim(str2);
                }

                if (s_tkqty > 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(s_tkqty))), "########"));
                }

                str2 = Rs(s_tkamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs(s_tkamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(s_tkamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(s_tkamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                tab1.Rows[^1].ItemArray[51] = "Qty";
                tab1.Rows[^1].ItemArray[52] = "Tukra Rate";
                tab1.Rows[^1].ItemArray[53] = "Less Comm %";
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
                mchl = Trim(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[1]);
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MQTY = 0;
                WAMT = 0;

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    MQTY += 1;
                    Recno[2] = 0;

                    while (Recno[2] < Inds[2].Tables[0].Rows.Count)
                    {
                        if (Trim(Trim(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[4])) == Trim(Trim(Inds[2].Tables[0].Rows[Recno[2]].ItemArray[1])) & Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]) == Val(Inds[2].Tables[0].Rows[Recno[2]].ItemArray[2]))
                        {
                            WAMT += Val(Inds[2].Tables[0].Rows[Recno[2]].ItemArray[3]);
                        }

                        Recno[2] += 1;
                    }

                    Recno[1] += 1;

                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                    else if (Val(mchl) != Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3]))
                    {
                        break;
                    }
                }

                s_cqty += MQTY;
                s_camt1 += MQTY * MRATE;
                s_camt2 += MQTY * MRATE;
                s_camt3 += WAMT;
                s_camt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                tab1.Rows[^1].ItemArray[100] = "(( Chart Sale ))";
                tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(Val(mchl))), 5);
                tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    tab1.Rows[^1].ItemArray[10] = Trim(str2);
                }

                if (MCH_PER == 0.25)
                {
                    tab1.Rows[^1].ItemArray[7] = "¼ %";
                }

                if (MCH_PER == 0.5)
                {
                    tab1.Rows[^1].ItemArray[7] = "½ %";
                }

                if (MCH_PER >= 1)
                {
                    tab1.Rows[^1].ItemArray[7] = Trim(Str(MCH_PER)) + " %";
                }

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[11] = Trim(str2);
                }

                str2 = Rs0(((MQTY * MRATE) - WAMT));

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[12] = Trim(str2);
                }

                if (s_cqty > 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(s_cqty))), "########"));
                }

                str2 = Rs(s_camt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs(s_camt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(s_camt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(s_camt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                tab1.Rows[^1].ItemArray[51] = "Qty";
                tab1.Rows[^1].ItemArray[52] = "Chart Rate";
                tab1.Rows[^1].ItemArray[53] = "Type / Com%";
            }
        }

        public void schemepacketsale()
        {
            Recno[1] = 0;

            while (Recno[1] < Inds[1].Tables[0].Rows.Count)
            {
                Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] = "";
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                xxsc = 0;
                mper = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[6]);
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) == mper & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] = "D";

                        mqty += 1;
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[7]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mqty > 0)
                {
                    s_pscqty += mqty;
                    s_pscamt1 += mqty * xxsc;
                    s_pscamt2 += mqty * xxsc;
                    s_pscamt3 += WAMT;
                    s_pscamt4 += (mqty * xxsc) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Scheme Packet Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1].ItemArray[5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00"));

                    str2 = Rs(xxsc * mqty);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    // If xxsc > 0 Then
                    tab1.Rows[^1].ItemArray[7] = Trim(Format(double.Parse(Trim(Str(mper))), "########.00")) + " %";
                    // End If

                    str2 = Rs((mqty * xxsc));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mqty * xxsc) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Qty";
                    tab1.Rows[^1].ItemArray[52] = "Sch . Rate";
                    tab1.Rows[^1].ItemArray[53] = "Packet (Per %)";
                }

                if (Val(sm_pscqty) != 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(s_pscqty))), "########"));
                }

                str2 = Rs(s_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs0(s_pscamt1 - s_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[23] = Trim(str2);
                }

                str2 = Rs(s_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(s_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(s_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
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
                Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] = "";
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();

                // ***************************** Ring *********************************************

                Recno[2] = Recno[1];
                mqty = 0;
                WAMT = 0;
                mrate = 0;
                mrate1 = 0;
                xxsc = 0;
                ms_com = 0;
                xxsc = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "3" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }


                if (mrate > 0)
                {
                    sm_pscqty += mqty;
                    sm_pscamt1 += mrate;
                    sm_pscamt2 += mrate1;
                    sm_pscamt3 += WAMT;
                    sm_pscamt4 += (mrate1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Scheme Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1].ItemArray[5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-R";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if (((mrate / 100) * ms_com) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mrate / 100) * ms_com)))), "########.00"));
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Qty";
                    tab1.Rows[^1].ItemArray[52] = "Pkt / Ring";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Packet *********************************************

                Recno[2] = Recno[1];

                while (Recno[2] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]) & Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
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

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Trim(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == "4" & Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[5]) == xxsc & Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
                    {
                        Inds[1].Tables[0].Rows[Recno[2]].ItemArray[8] = "D";

                        mqty += ValS(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[11]);
                        WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[7]);
                        mrate += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[9]);
                        mrate1 += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[10]);
                        ms_com = Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]);
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mrate > 0)
                {
                    sm_pscqty += mqty;
                    sm_pscamt1 += mrate;
                    sm_pscamt2 += mrate1;
                    sm_pscamt3 += WAMT;
                    sm_pscamt4 += (mrate1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Scheme Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(mqty))), "########"));

                    tab1.Rows[^1].ItemArray[5] = Trim(Format(double.Parse(Trim(Str(xxsc))), "########.00")) + "-P";

                    str2 = Rs(mrate);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (ms_com > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(ms_com))), "########.00")) + "%";
                    }

                    if (((mrate / 100) * ms_com) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mrate / 100) * ms_com)))), "########.00"));
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mrate - (mrate / 100) * ms_com) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Qty";
                    tab1.Rows[^1].ItemArray[52] = "Pkt / Ring";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                if (Val(sm_pscqty) != 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(sm_pscqty))), "########"));
                }

                str2 = Rs(sm_pscamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs0(sm_pscamt1 - sm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[23] = Trim(str2);
                }

                str2 = Rs(sm_pscamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(sm_pscamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(sm_pscamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8] == null/* TODO Change to default(_) if this is not a reference type */ )
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();
                mcom1 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);
                mcom2 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[6]);
                mcom3 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[7]);
                mcom4 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[8]);
                mcom5 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[9]);
                mcom6 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[11]);
                mcom7 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[12]);
                mcom8 = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[10]);


                // ***************************** Open *********************************************


                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 11)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom1;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Op";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Op";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Close *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 12)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom1;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Cz";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Cz";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Center *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 13)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom1;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Cnt";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Cnt";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** XOpen *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 14)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom1;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom1) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XOp";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom1 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom1))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom1) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom1)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom1) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XOp";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[6])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                // ***************************** Akara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 22)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }


                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom2;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom2) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Ak";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom2 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom2))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom2)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom2));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom2) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Ak";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[7])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** XAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 23)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }


                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom6;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom6) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom6) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom6)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** XXAkara *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 24)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom6;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom6) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XXAk";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom6 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom6))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom6) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom6)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom6) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XXAk";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[8])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Tandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 33)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom3;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom3) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Td";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom3 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom3))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom3) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom3)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom3));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom3) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Td";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[9])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** XTandela *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 34)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }
                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom7;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom7) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "XTd";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom7 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom7))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom7) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom7)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom7));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom7) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "XTd";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[10])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Fourcast *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 44)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom4;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom4) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "Fc";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom4 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom4))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom4) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom4)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom4));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom4) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "Fc";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[11])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Five - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 52)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom5;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom5) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "5D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom5 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom5))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom5) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom5)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom5));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom5) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "5D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[12])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }

                // ***************************** Six - Dot *********************************************

                Recno[2] = Recno[1];

                mprize = 0;
                WAMT = 0;
                Xmprize = 0;
                Xwamt = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[2]))
                {
                    if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[4]) == 62)
                    {
                        if (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[6]) != 88)
                        {
                            mprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            WAMT += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                        else
                        {
                            Xmprize += (Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[14]) + Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[15]));
                            Xwamt += Val(Inds[1].Tables[0].Rows[Recno[2]].ItemArray[16]);
                        }
                    }

                    Recno[2] += 1;

                    if (Recno[2] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                if (mprize != 0)
                {
                    s_mixamt1 += mprize;
                    s_mixamt2 += mprize - (mprize / 100) * mcom8;
                    s_mixamt3 += WAMT;
                    s_mixamt4 += (mprize - (mprize / 100) * mcom8) - WAMT;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                    tab1.Rows[^1].ItemArray[4] = "6D";

                    str2 = Rs(mprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (mcom8 > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(mcom8))), "########.00")) + "%";
                    }

                    if (((mprize / 100) * mcom8) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((mprize / 100) * mcom8)))), "########.00"));
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom8));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((mprize - (mprize / 100) * mcom8) - WAMT);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                if (Xmprize != 0)
                {
                    s_mixamt1 += Xmprize;
                    s_mixamt2 += Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13]);
                    s_mixamt3 += Xwamt;
                    s_mixamt4 += (Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])) - Xwamt;

                    tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                    tab1.Rows[^1].ItemArray[100] = "(( Mix Sale ))";
                    tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                    tab1.Rows[^1].ItemArray[3] = "Diversion";
                    tab1.Rows[^1].ItemArray[4] = "6D";

                    str2 = Rs(Xmprize);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    }

                    if (Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13]) > 0)
                    {
                        tab1.Rows[^1].ItemArray[8] = Trim(Format(double.Parse(Trim(Str(Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])))), "########.00")) + "%";
                    }

                    if (((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])) != 0)
                    {
                        tab1.Rows[^1].ItemArray[9] = Trim(Format(double.Parse(Trim(Str(((Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13]))))), "########.00"));
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])));

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[10] = Trim(str2);
                    }

                    str2 = Rs(Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[11] = Trim(str2);
                    }

                    str2 = Rs0((Xmprize - (Xmprize / 100) * Val(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[13])) - Xwamt);

                    if (Val(str2) != 0)
                    {
                        tab1.Rows[^1].ItemArray[12] = Trim(str2);
                    }

                    tab1.Rows[^1].ItemArray[51] = "Digit";
                    tab1.Rows[^1].ItemArray[53] = "Less Comm %";
                }


                str2 = Rs(s_mixamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs0(s_mixamt1 - s_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[23] = Trim(str2);
                }

                str2 = Rs(s_mixamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(s_mixamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(s_mixamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                while (Recno[1] < Inds[1].Tables[0].Rows.Count)
                {
                    if (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]))
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
                MVNO = ValS(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]);
                MCH_PER = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[4]);
                MREF = Inds[1].Tables[0].Rows[Recno[1]].ItemArray[3].ToString();
                MRATE = Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[5]);
                Recno[2] = 0;

                while (MVNO == Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[2]))
                {
                    MQTY += 1;
                    WAMT += Val(Inds[1].Tables[0].Rows[Recno[1]].ItemArray[6]);
                    Recno[1] += 1;
                    if (Recno[1] >= Inds[1].Tables[0].Rows.Count)
                    {
                        break;
                    }
                }

                s_pqty += MQTY;
                s_pamt1 += (MQTY * MRATE);
                s_pamt2 += (MQTY * MRATE);
                s_pamt3 += WAMT;
                s_pamt4 += (MQTY * MRATE) - WAMT;

                tab1.Rows.Add("((( " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[1]) + " - " + Trim(Inds[0].Tables[0].Rows[Recno[0]].ItemArray[2]) + " )))", "S");
                tab1.Rows[^1].ItemArray[100] = "(( % Packet Sale ))";
                tab1.Rows[^1].ItemArray[2] = Right("00000" + Trim(Str(MVNO)), 5);
                tab1.Rows[^1].ItemArray[3] = Trim(MREF);
                tab1.Rows[^1].ItemArray[4] = Trim(Format(double.Parse(Trim(Str(MQTY))), "########"));

                str2 = Rs0(MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[5] = Trim(str2);
                }

                str2 = Rs(MQTY * MRATE);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[6] = Trim(str2);
                    tab1.Rows[^1].ItemArray[10] = Trim(str2);
                }

                tab1.Rows[^1].ItemArray[7] = Trim(Str(MCH_PER)) + " %";

                str2 = Rs(WAMT);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[11] = Trim(str2);
                }

                str2 = Rs0(((MQTY * MRATE) - WAMT));

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[12] = Trim(str2);
                }

                if (s_pqty > 0)
                {
                    tab1.Rows[^1].ItemArray[21] = Trim(Format(double.Parse(Trim(Str(s_pqty))), "########"));
                }

                str2 = Rs(s_pamt1);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[22] = Trim(str2);
                }

                str2 = Rs(s_pamt2);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[24] = Trim(str2);
                }

                str2 = Rs(s_pamt3);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[25] = Trim(str2);
                }

                str2 = Rs(s_pamt4);

                if (Val(str2) != 0)
                {
                    tab1.Rows[^1].ItemArray[26] = Trim(str2);
                }

                tab1.Rows[^1].ItemArray[51] = "Qty";
                tab1.Rows[^1].ItemArray[52] = "Pkt . Rate";
                tab1.Rows[^1].ItemArray[53] = "Packet (Per %)";
            }
        }

    }
}