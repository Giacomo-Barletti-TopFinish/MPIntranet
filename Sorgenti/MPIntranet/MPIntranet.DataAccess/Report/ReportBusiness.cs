﻿//using Microsoft.VisualStudio.DebuggerVisualizers;
using MPIntranet.DataAccess.Core;
using MPIntranet.Entities;
using System;
using System.Collections.Generic;

namespace MPIntranet.DataAccess.Report
{
    public class ReportBusiness : MPIntranetBusinessBase
    {
        public ReportBusiness() : base() { }

        [DataContext]
        public void FillODL_APERTI(ReportDS ds, string reparto)
        {
            ReportAdapter a = new ReportAdapter(DbConnection, DbTransaction);
            a.FillODL_APERTI(ds, reparto);
        }

        [DataContext]
        public void FillREPORTQUANTITA(ReportDS ds)
        {
            ReportAdapter r = new ReportAdapter(DbConnection, DbTransaction);
            r.FillREPORTQUANTITA(ds);

        }

        [DataContext]
        public void FillBOLLE_VENDITA(DateTime inizio, DateTime fine, ReportDS ds)
        {
            ReportAdapter r = new ReportAdapter(DbConnection, DbTransaction);
            r.FillBOLLE_VENDITA(inizio, fine, ds);

        }

        [DataContext]
        public List<string> EstraiReportQuantita(ReportDS ds)
        {
            ReportAdapter a = new ReportAdapter(DbConnection, DbTransaction);
            return a.EstraiRepartiODL_Aperti(ds);
        }

        [DataContext]
        public void FillORDINIATTIVI(ReportDS ds)
        {
            ReportAdapter a = new ReportAdapter(DbConnection, DbTransaction);
            a.FillORDINIATTIVI(ds);
        }
    }

}