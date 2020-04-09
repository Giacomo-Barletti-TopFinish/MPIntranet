using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Anagrafica
{
    public class AnagraficaAdapter : MPIntranetAdapterBase
    {
        public AnagraficaAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
          base(connection, transaction)
        { }

        public void FillBrand(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM BRAND ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY BRAND ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.BRAND);
            }
        }

        public void FillReparti(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM REPARTI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY codice ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.REPARTI);
            }
        }

        public void FillFasi(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM FASI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY codice ";

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.FASI);
            }
        }
        public void FillColori(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM COLORI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N' ";

            select += "ORDER BY IDCOLORE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.COLORI);
            }
        }

        public void FillTipiDocumento(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM TIPIDOCUMENTO ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TIPIDOCUMENTO);
            }
        }

        public void FillMateriali(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM MATERIALI ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.MATERIALI);
            }
        }

        public void FillTipiProdotto(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM TIPIPRODOTTO ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY CODICE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.TIPIPRODOTTO);
            }
        }

        public void FillMateriePrime(AnagraficaDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM MATERIEPRIME ";
            if (soloNonCancellati)
                select += "WHERE CANCELLATO = 'N'";

            select += "ORDER BY CODICE";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.MATERIEPRIME);
            }
        }
        public void UpdateTable(string tablename, AnagraficaDS ds)
        {
            string query = string.Format(CultureInfo.InvariantCulture, "SELECT * FROM {0}", tablename);

            using (DbDataAdapter a = BuildDataAdapter(query))
            {
                a.ContinueUpdateOnError = false;
                DataTable dt = ds.Tables[tablename];
                DbCommandBuilder cmd = BuildCommandBuilder(a);
                a.UpdateCommand = cmd.GetUpdateCommand();
                a.DeleteCommand = cmd.GetDeleteCommand();
                a.InsertCommand = cmd.GetInsertCommand();
                a.Update(dt);
            }
        }
    }
}
