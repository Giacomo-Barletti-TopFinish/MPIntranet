using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articoli
{
    public class ArticoliAdapter : MPIntranetAdapterBase
    {
        public ArticoliAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
          base(connection, transaction)
        { }

        public void FillArticoli(ArticoliDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM ARTICOLI WHERE IDARTICOLO >=0 ";
            if (soloNonCancellati)
                select += "AND CANCELLATO = 0 ";

            select += "ORDER BY DESCRIZIONE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.ARTICOLI);
            }
        }

        public void GetDistintaBase(ArticoliDS ds, int idDiba)
        {
            string select = @"SELECT * FROM DIBA WHERE IDDIBA = $P<IDDIBA>";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDDIBA", DbType.Int32, idDiba);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.DIBA);
            }
        }

        public void FillFASIDIBA(ArticoliDS ds, int idDiba)
        {
            string select = @"SELECT * FROM FASIDIBA WHERE IDDIBA = $P<IDDIBA> AND CANCELLATO = 0 ";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDDIBA", DbType.Int32, idDiba);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.FASIDIBA);
            }
        }

        public void FillDistintaBase(ArticoliDS ds, int idArticolo, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM DIBA WHERE IDARTICOLO = $P<IDARTICOLO> ";
            if (soloNonCancellati)
                select += "AND CANCELLATO = 0 ";
            select += " ORDER BY IDTIPODIBA,VERSIONE ";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDARTICOLO", DbType.Int32, idArticolo);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.DIBA);
            }
        }

        public void FillArticoli(string anagrafica, ArticoliDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM ARTICOLI WHERE IDARTICOLO >=0 AND ANAGRAFICA = $P<ANAGRAFICA>";
            if (soloNonCancellati)
                select += "AND CANCELLATO = 0 ";

            select += " ORDER BY DESCRIZIONE";

            ParamSet ps = new ParamSet();
            ps.AddParam("ANAGRAFICA", DbType.String, anagrafica);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ARTICOLI);
            }
        }

        public void FillTask(ArticoliDS ds)
        {
            string select = @"SELECT * FROM Task";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.Task);
            }
        }

        public void FillItems(ArticoliDS ds)
        {
            string select = @"SELECT * FROM Items";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.Items);
            }
        }
        public void FillAreeProduzione(ArticoliDS ds)
        {
            string select = @"SELECT * FROM AreeProduzione";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.AreeProduzione);
            }
        }

        public void FillBrand(ArticoliDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM BRANDS ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 0 ";

            select += " ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BRANDS);
            }
        }

        public void FillTipiDistinta(ArticoliDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM TIPIDIBA ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 0 ";

            select += " ORDER BY TIPODIBA ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TIPIDIBA);
            }
        }
        public void GetArticolo(ArticoliDS ds, int idArticolo)
        {
            string select = @"SELECT * FROM ARTICOLI WHERE IDARTICOLO = $P<IDARTICOLO>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDARTICOLO", DbType.Int32, idArticolo);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ARTICOLI);
            }
        }
        public void TrovaArticoli(ArticoliDS ds, bool soloNonCancellati, int idBrand, string anagrafica, string descrizione, string codiceCliente, string colore)
        {
            ParamSet ps = new ParamSet();

            string query = @"SELECT * FROM ARTICOLI ";
            string where = " WHERE 1=1 ";

            if (soloNonCancellati)
                where += "AND CANCELLATO = 0 ";

            AddConditionAndParam(ref where, "ANAGRAFICA", "an1", anagrafica.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "DESCRIZIONE", "d1", descrizione.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "CODICECLIENTE", "cc1", codiceCliente.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "COLORE", "co1", colore.ToUpper(), ps, true);
            if (idBrand > 0)
                AddConditionAndParam(ref where, "IDBRAND", "b1", idBrand.ToString().ToUpper(), ps, false);

            string select = $"{query}{where}";
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.ARTICOLI);
            }
        }

        public void UpdateTable(string tablename, ArticoliDS ds)
        {
            string tablenameDB = tablename;

            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tablenameDB);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                try
                {
                    a.ContinueUpdateOnError = false;
                    DataTable dt = ds.Tables[tablename];
                    DbCommandBuilder cmd = BuildCommandBuilder(a);
                    a.AcceptChangesDuringFill = true;
                    a.UpdateCommand = cmd.GetUpdateCommand();
                    a.DeleteCommand = cmd.GetDeleteCommand();
                    a.InsertCommand = cmd.GetInsertCommand();

                    a.Update(dt);
                }
                catch (DBConcurrencyException ex)
                {

                }
                catch
                {
                    throw;
                }
            }
        }

        public void UpdateDistintaBaseTable(ArticoliDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", ds.DIBA.TableName);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                InstallRowUpdatedHandler(a, UpdateDistintaBaseHander);
                a.ContinueUpdateOnError = false;
                DataTable dt = ds.DIBA;
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.AcceptChangesDuringFill = true;
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();

                a.Update(dt);
            }
        }
        private void UpdateDistintaBaseHander(object sender, RowUpdatedEventArgs e)
        {
            if ((e.Status == UpdateStatus.Continue) && (e.StatementType == StatementType.Insert))
            {
                ArticoliDS.DIBARow row = (ArticoliDS.DIBARow)e.Row;
                ArticoliDS.DIBADataTable dt = row.Table as ArticoliDS.DIBADataTable;

                bool isIdentityReadOnly = dt.IDDIBAColumn.ReadOnly;
                dt.IDDIBAColumn.ReadOnly = false;
                try
                {
                    row.IDDIBA = (int)RetrievePostUpdateID<decimal>(e.Command, row);
                }
                finally
                {
                    dt.IDDIBAColumn.ReadOnly = isIdentityReadOnly;
                }
            }
        }

        public void UpdateFaseDistintaBaseTable(ArticoliDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", ds.FASIDIBA.TableName);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                InstallRowUpdatedHandler(a, UpdateFaseDistintaBaseHander);
                a.ContinueUpdateOnError = false;
                DataTable dt = ds.FASIDIBA;
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.AcceptChangesDuringFill = true;
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();

                a.Update(dt);
            }
        }
        private void UpdateFaseDistintaBaseHander(object sender, RowUpdatedEventArgs e)
        {
            if ((e.Status == UpdateStatus.Continue) && (e.StatementType == StatementType.Insert))
            {
                ArticoliDS.FASIDIBARow row = (ArticoliDS.FASIDIBARow)e.Row;
                ArticoliDS.FASIDIBADataTable dt = row.Table as ArticoliDS.FASIDIBADataTable;

                bool isIdentityReadOnly = dt.IDDIBAColumn.ReadOnly;
                dt.IDFASEDIBAColumn.ReadOnly = false;
                try
                {
                    row.IDFASEDIBA = (int)RetrievePostUpdateID<decimal>(e.Command, row);
                }
                finally
                {
                    dt.IDFASEDIBAColumn.ReadOnly = isIdentityReadOnly;
                }
            }
        }

    }
}
