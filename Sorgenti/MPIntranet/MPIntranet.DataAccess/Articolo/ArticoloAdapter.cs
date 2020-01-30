using MPIntranet.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPIntranet.DataAccess.Articolo
{
    public class ArticoloAdapter : MPIntranetAdapterBase
    {
        public ArticoloAdapter(System.Data.IDbConnection connection, IDbTransaction transaction) :
            base(connection, transaction)
        { }

        public void FillArticoli(ArticoloDS ds, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM ARTICOLI WHERE IDARTICOLO >=0 ";
            if (soloNonCancellati)
                select += "AND CANCELLATO = 'N' ";

            select += "ORDER BY MODELLO";
            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.ARTICOLI);
            }
        }

        public string GetImageNameFile(string idMagazz)
        {
            string select = @"select nomefile from gruppo.USR_PDM_FILES fi
                                inner join gruppo.USR_PDM_IMG_MAGAZZ ma on ma.IDPDMFILE = fi.IDPDMFILE
                                where ma.idmagazz = $P<IDMAGAZZ>";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDMAGAZZ", DbType.String, idMagazz);

            string nomefile;
            using (DbCommand cmd = BuildCommand(select, ps))
            {
                object returned = cmd.ExecuteScalar();
                if (returned == null)
                    nomefile = string.Empty;
                else
                    nomefile = (string)returned;
            }

            return nomefile;
        }

        public List<decimal> TrovaArticoli(bool soloNonCancellati, decimal idBrand, string codiceSam, string modello, string codiceCliente, string codiceProvvisorio)
        {
            ParamSet ps = new ParamSet();

            if (idBrand <= 0 && string.IsNullOrEmpty(codiceSam) && string.IsNullOrEmpty(modello) && string.IsNullOrEmpty(codiceCliente) && string.IsNullOrEmpty(codiceProvvisorio))
                return new List<decimal>(); ;

            string query = @"SELECT IDARTICOLO FROM ARTICOLI ";
            string where = " WHERE 1=1 ";

            if (soloNonCancellati)
                where += "AND CANCELLATO = 'N' ";

            AddConditionAndParam(ref where, "CODICESAM", "cs1", codiceSam.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "MODELLO", "m1", modello.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "CODICECLIENTE", "cc1", codiceCliente.ToUpper(), ps, true);
            if (idBrand > 0)
                AddConditionAndParam(ref where, "IDBRAND", "b1", idBrand.ToString().ToUpper(), ps, false);

            AddConditionAndParam(ref where, "CODICEPROVVISORIO", "cp1", codiceProvvisorio.ToUpper(), ps, true);

            string select = $"{query}{where}";
            using (DbCommand cmd = BuildCommand(select, ps))
            using (IDataReader reader = cmd.ExecuteReader())
            {
                List<decimal> returnedData = new List<decimal>();
                while (reader.Read())
                    returnedData.Add(reader.GetDecimal(0));
                return returnedData;
            }
        }

        public List<decimal> TrovaArticoliPerColore(bool soloNonCancellati, string codiceColoreInterno, string codiceColoreCliente)
        {
            ParamSet ps = new ParamSet();

            string query = @"SELECT IDARTICOLO FROM ARTICOLO A INNER JOIN COLORI C ON C.IDCOLORE=A.IDCOLORE";
            string where = " WHERE 1=1 ";

            if (soloNonCancellati)
            {
                where += "AND A.CANCELLATO = 'N' ";
                where += "AND C.CANCELLATO = 'N' ";
            }

            AddConditionAndParam(ref where, "C.CODICE", "ci1", codiceColoreInterno.ToUpper(), ps, true);
            AddConditionAndParam(ref where, "C.CODICECLIENTE", "cc1", codiceColoreCliente.ToUpper(), ps, true);

            string select = $"{query}{where}";
            using (DbCommand cmd = BuildCommand(select, ps))
            using (IDataReader reader = cmd.ExecuteReader())
            {
                List<decimal> returnedData = new List<decimal>();
                while (reader.Read())
                    returnedData.Add(reader.GetDecimal(0));
                return returnedData;
            }
        }
        public void FillArticoli(ArticoloDS ds, List<decimal> idArticoli, bool soloNonCancellati)
        {
            string inCOndition = ConvertToStringForInCondition(idArticoli);

            string select = @"SELECT DISTINCT * FROM Articoli WHERE IdArticolo in ( {0} )";
            if (soloNonCancellati)
            {
                select += " AND CANCELLATO = 'N' ";
            }
            select = string.Format(select, inCOndition);

            using (DbDataAdapter da = BuildDataAdapter(select))
            {
                da.Fill(ds.ARTICOLI);
            }
        }
        public void UpdateTable(string tablename, ArticoloDS ds)
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

        public void FillProcessi(ArticoloDS ds, decimal idArticolo, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM PROCESSI WHERE IDARTICOLO = $P<IDARTICOLO> ";
            if (soloNonCancellati)
                select += "AND CANCELLATO = 'N' ";

            select += "ORDER BY DESCRIZIONE";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDARTICOLO", DbType.Decimal, idArticolo);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.PROCESSI);
            }
        }

        public void FillFasiProcesso(ArticoloDS ds, decimal idArticolo, bool soloNonCancellati)
        {
            string select = @"SELECT * FROM FASIPROCESSO FP 
                                    INNER JOIN PROCESSI PR ON PR.IDPROCESSO = FP.IDPROCESSO
                                    WHERE IDARTICOLO = $P<IDARTICOLO> ";
            if (soloNonCancellati)
                select += "AND FP.CANCELLATO = 'N' ";

            select += "ORDER BY FP.IDPROCESSO,SEQUENZA";

            ParamSet ps = new ParamSet();
            ps.AddParam("IDARTICOLO", DbType.Decimal, idArticolo);
            using (DbDataAdapter da = BuildDataAdapter(select, ps))
            {
                da.Fill(ds.FASIPROCESSO);
            }
        }
    }
}
