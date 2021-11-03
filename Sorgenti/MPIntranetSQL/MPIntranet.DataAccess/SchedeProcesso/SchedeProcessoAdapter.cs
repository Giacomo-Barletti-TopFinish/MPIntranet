using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.SchedeProcesso
{
    public class SchedeProcessoAdapter : MPIntranetAdapterBase
    {
        public SchedeProcessoAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
        base(connection, transaction)
        { }

        public void FillSPMaster(SchedeProcessoDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPMASTERS ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 0 ";

            select += "ORDER BY CODICE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPMASTERS);
            }
        }
        public void FillSPMaster(string areaProduzione, string task, SchedeProcessoDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPMASTERS WHERE AREAPRODUZIONE=$P<AREAPRODUZIONE> AND TASK=$P<TASK> ";
            if (soloNonCancellati)
                select += "AND CANCELLATO = 0 ";

            select += "ORDER BY CODICE";

            ParamSet ps = new ParamSet();
            ps.AddParam("AREAPRODUZIONE", DbType.String, areaProduzione);
            ps.AddParam("TASK", DbType.String, task);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPMASTERS);
            }
        }
        public void FillSPScheda(SchedeProcessoDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPSCHEDE ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 0 ";

            select += "ORDER BY CODICE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPSCHEDE);
            }
        }
        public void TrovaScheda(string Codice, string descrizione, int idBrand, string anagrafica, SchedeProcessoDS ds, bool soloNonCancellati)
        {
            ParamSet ps = new ParamSet();

            string query = @"SELECT * FROM SPSCHEDE ";
            string where = " WHERE 1=1 ";

            if (soloNonCancellati)
                where += "AND CANCELLATO = 0 ";

            AddConditionAndParam(ref where, "ANAGRAFICA", "an1", anagrafica.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "DESCRIZIONE", "d1", descrizione.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "CODICE", "co1", Codice.ToUpper(), ps, true);
            if (idBrand > 0)
                AddConditionAndParam(ref where, "IDBRAND", "b1", idBrand.ToString().ToUpper(), ps, false);

            string select = $"{query}{where}";
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPSCHEDE);
            }
        }
        public void FillSPScheda(string IDSPMaster, SchedeProcessoDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPSCHEDE WHERE IDSPMASTER=$P<IDSPMASTER> ";
            if (soloNonCancellati)
                select += "AND CANCELLATO = 0 ";

            select += "ORDER BY CODICE";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPMASTER", DbType.String, IDSPMaster);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPSCHEDE);
            }
        }

        public void GetSPScheda(int IDScheda, SchedeProcessoDS ds)
        {
            string select = @"SELECT * FROM SPSCHEDE WHERE IDSPSCHEDA=$P<IDSPSCHEDA> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPSCHEDA", DbType.Int32, IDScheda);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPSCHEDE);
            }
        }

        public void FillSPControlli(SchedeProcessoDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPCONTROLLI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 0 ";

            select += "ORDER BY CODICE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.SPCONTROLLI);
            }
        }

     
        public void GetControllo(SchedeProcessoDS ds, int idSPControllo)
        {
            string select = @"SELECT * FROM SPCONTROLLI WHERE IDSPCONTROLLO = $P<IDCONTROLLO>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDCONTROLLO", DbType.Int32, idSPControllo);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPCONTROLLI);
            }
        }

        public void GetSPMaster(SchedeProcessoDS ds, int idSPMaster)
        {
            string select = @"SELECT * FROM SPMASTERS WHERE IDSPMASTER = $P<IDSPMASTER>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPMASTER", DbType.Int32, idSPMaster);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPMASTERS);
            }
        }

        public int GetMaxIDSPMaster()
        {
            string select = @"SELECT MAX(IDSPMASTER) FROM SPMASTERS ";

            using (DbCommand co = BuildCommand(select))
            {
                object o = co.ExecuteScalar();
                return (int)o;
            }
        }
        public void FillElementi(SchedeProcessoDS ds, int idSPMaster, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPELEMENTI WHERE IDSPMASTER = $P<IDSPMASTER>";
            if (soloNonCancellati)
                select += " AND CANCELLATO = 0 ";

            select += " ORDER BY SEQUENZA";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPMASTER", DbType.Int32, idSPMaster);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPELEMENTI);
            }
        }

        public void FillValoriSchede(SchedeProcessoDS ds, int idSPScheda, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPVALORISCHEDE WHERE IDSPSCHEDA = $P<IDSPSCHEDA>";
            if (soloNonCancellati)
                select += " AND CANCELLATO = 0 ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPSCHEDA", DbType.Int32, idSPScheda);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPVALORISCHEDE);
            }
        }
        public void GetElemento(SchedeProcessoDS ds, int idSPElemento)
        {
            string select = @"SELECT * FROM SPELEMENTI WHERE IDSPELEMENTO = $P<IDSPELEMENTO>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPELEMENTO", DbType.Int32, idSPElemento);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPELEMENTI);
            }
        }
        public void GetValoreScheda(SchedeProcessoDS ds, int idSPValoreScheda)
        {
            string select = @"SELECT * FROM SPVALORISCHEDE WHERE IDSPVALORESCHEDA = $P<IDSPVALORESCHEDA>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPVALORESCHEDA", DbType.Int32, idSPValoreScheda);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPVALORISCHEDE);
            }
        }
        public void FillElementiLista(SchedeProcessoDS ds, int idSPControllo, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM SPELEMENTILISTA WHERE IDSPCONTROLLO = $P<IDCONTROLLO>";
            if (soloNonCancellati)
                select += " AND CANCELLATO = 0 ";
            ParamSet ps = new ParamSet();
            ps.AddParam("IDCONTROLLO", DbType.Int32, idSPControllo);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPELEMENTILISTA);
            }
        }

        public void GetElementoLista(SchedeProcessoDS ds, int idElementoLista)
        {
            string select = @"SELECT * FROM SPELEMENTILISTA WHERE IDSPELEMENTOLISTA = $P<IDSPELEMENTOLISTA>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDSPELEMENTOLISTA", DbType.Int32, idElementoLista);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.SPELEMENTILISTA);
            }
        }
        public void UpdateTable(string tablename, SchedeProcessoDS ds)
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

        public void UpdateTableSPScheda(SchedeProcessoDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", ds.SPSCHEDE.TableName);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                InstallRowUpdatedHandler(a, UpdateSPSchedaHander);

                a.ContinueUpdateOnError = false;
                DataTable dt = ds.SPSCHEDE;
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.AcceptChangesDuringFill = true;
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();

                a.Update(dt);
            }
        }

        private void UpdateSPSchedaHander(object sender, RowUpdatedEventArgs e)
        {
            if ((e.Status == UpdateStatus.Continue) && (e.StatementType == StatementType.Insert))
            {
                SchedeProcessoDS.SPSCHEDERow row = (SchedeProcessoDS.SPSCHEDERow)e.Row;
                SchedeProcessoDS.SPSCHEDEDataTable dt = row.Table as SchedeProcessoDS.SPSCHEDEDataTable;

                bool isIdentityReadOnly = dt.IDSPSCHEDAColumn.ReadOnly;
                dt.IDSPSCHEDAColumn.ReadOnly = false;
                try
                {
                    row.IDSPSCHEDA = (int)RetrievePostUpdateID<decimal>(e.Command, row);
                }
                finally
                {
                    dt.IDSPSCHEDAColumn.ReadOnly = isIdentityReadOnly;
                }
            }
        }

        public void UpdateTableSPMaster(SchedeProcessoDS ds)
        {

            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", ds.SPMASTERS.TableName);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                InstallRowUpdatedHandler(a, UpdateSPMasterHander);

                a.ContinueUpdateOnError = false;
                DataTable dt = ds.SPMASTERS;
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.AcceptChangesDuringFill = true;
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();

                a.Update(dt);
            }
        }

        private void UpdateSPMasterHander(object sender, RowUpdatedEventArgs e)
        {
            if ((e.Status == UpdateStatus.Continue) && (e.StatementType == StatementType.Insert))
            {
                SchedeProcessoDS.SPMASTERSRow row = (SchedeProcessoDS.SPMASTERSRow)e.Row;
                SchedeProcessoDS.SPMASTERSDataTable dt = row.Table as SchedeProcessoDS.SPMASTERSDataTable;

                bool isIdentityReadOnly = dt.IDSPMASTERColumn.ReadOnly;
                dt.IDSPMASTERColumn.ReadOnly = false;
                try
                {
                    row.IDSPMASTER = (int)RetrievePostUpdateID<decimal>(e.Command, row);
                }
                finally
                {
                    dt.IDSPMASTERColumn.ReadOnly = isIdentityReadOnly;
                }
            }
        }


        public void UpdateTableSPControlli(SchedeProcessoDS ds)
        {

            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", ds.SPCONTROLLI.TableName);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                InstallRowUpdatedHandler(a, UpdateSPCOntrolloHander);

                a.ContinueUpdateOnError = false;
                DataTable dt = ds.SPCONTROLLI;
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.AcceptChangesDuringFill = true;
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();

                a.Update(dt);
            }
        }

        private void UpdateSPCOntrolloHander(object sender, RowUpdatedEventArgs e)
        {
            if ((e.Status == UpdateStatus.Continue) && (e.StatementType == StatementType.Insert))
            {
                SchedeProcessoDS.SPCONTROLLIRow row = (SchedeProcessoDS.SPCONTROLLIRow)e.Row;
                SchedeProcessoDS.SPCONTROLLIDataTable dt = row.Table as SchedeProcessoDS.SPCONTROLLIDataTable;

                bool isIdentityReadOnly = dt.IDSPCONTROLLOColumn.ReadOnly;
                dt.IDSPCONTROLLOColumn.ReadOnly = false;
                try
                {
                    row.IDSPCONTROLLO = (int)RetrievePostUpdateID<decimal>(e.Command, row);
                }
                finally
                {
                    dt.IDSPCONTROLLOColumn.ReadOnly = isIdentityReadOnly;
                }
            }
        }
    }
}
