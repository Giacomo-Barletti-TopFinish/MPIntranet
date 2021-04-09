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
    public class ArticoliAdapter: MPIntranetAdapterBase
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

        /***************************************************************

        //excel
        public void Update_EXCEL_Table(CDCDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM $T<{0}>", ds.CDC_EXCEL.TableName);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                try
                {
                    InstallRowUpdatedHandler(a, Update_EXCEL_ElementHandler);
                    a.ContinueUpdateOnError = false;
                    DataTable dt = ds.CDC_EXCEL;
                    DbCommandBuilder cmd = BuildCommandBuilder(a);
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

        private void Update_EXCEL_ElementHandler(object sender, RowUpdatedEventArgs e)
        {
            if ((e.Status == UpdateStatus.Continue) && (e.StatementType == StatementType.Insert))
            {
                //ArticleDS.SPELEMENTIRow row = (ArticleDS.SPELEMENTIRow)e.Row;
                CDCDS.CDC_EXCELRow row = (CDCDS.CDC_EXCELRow)e.Row;

                //ArticleDS.SPELEMENTIDataTable dt = row.Table as ArticleDS.SPELEMENTIDataTable;
                CDCDS.CDC_EXCELDataTable dt = row.Table as CDCDS.CDC_EXCELDataTable;

                //bool isIdentityReadOnly = dt.ID_SPELEMColumn.ReadOnly;
                bool isIdentityReadOnly = dt.IDEXCELColumn.ReadOnly;

                //dt.ID_SPELEMColumn.ReadOnly = false;
                dt.IDEXCELColumn.ReadOnly = false;

                try
                {
                    //row.ID_SPELEM = (long)RetrievePostUpdateID<decimal>(e.Command, row);
                    row.IDEXCEL = (long)RetrievePostUpdateID<decimal>(e.Command, row);
                }
                finally
                {
                    //dt.ID_SPELEMColumn.ReadOnly = isIdentityReadOnly;
                    dt.IDEXCELColumn.ReadOnly = isIdentityReadOnly;
                }
            }

        }
        conformita
        */
    }
}
