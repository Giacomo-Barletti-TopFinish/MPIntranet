using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Documenti
{
    public class DocumentiAdapter : MPIntranetAdapterBase
    {
        public DocumentiAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
        base(connection, transaction)
        { }

        public void FillTipiDocumento(DocumentiDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM TIPIDOCUMENTO ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 0 ";

            select += " ORDER BY DESCRIZIONE ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TIPIDOCUMENTO);
            }
        }
        public void FillDocumenti(DocumentiDS ds, int idEsterna, string TabellaEsterna,bool soloNonCancellati)
        {
            string select = @"SELECT IDDOCUMENTO,IDTIPODOCUMENTO,FILENAME,ESTENSIONE,IDESTERNA,TABELLAESTERNA,IDBLOCCO,CANCELLATO,DATAMODIFICA,UTENTEMODIFICA 
                                FROM DOCUMENTI WHERE IDESTERNA = $P<IDESTERNA> AND TABELLAESTERNA = $P<TABELLAESTERNA> ";
            if (soloNonCancellati)
                select += " CANCELLATO = 0 ";

            select += " ORDER BY FILENAME ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDESTERNA", DbType.Int32, idEsterna);
            ps.AddParam("TABELLAESTERNA", DbType.String, TabellaEsterna);

            using (DbDataAdapter da = BuildDataAdapter(select,ps))
            {
                da.Fill(ds.DOCUMENTI);
            }
        }

        public void EstraiDocumentoCompleto(DocumentiDS ds, int idDocumento)
        {
            string select = @"SELECT * FROM DOCUMENTI WHERE IDDOCUMENTO = $P<IDDOCUMENTO> ";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDDOCUMENTO", DbType.Int32, idDocumento);

            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.DOCUMENTI);
            }
        }
        public void UpdateTable(string tablename, DocumentiDS ds)
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

    }
}
