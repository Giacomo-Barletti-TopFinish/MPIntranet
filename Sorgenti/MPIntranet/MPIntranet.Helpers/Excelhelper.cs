using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MPIntranet.Entities;
using MPIntranet.Models.Report;

namespace MPIntranet.Helpers
{
    public class ExcelHelper
    {
        public byte[] CaricoLavoroExcel(ReportDS ds)
        {


            byte[] content;
            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();

                int numeroColonne = 38;
                Columns columns = new Columns();
                for (int i = 0; i < numeroColonne; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 15;

                    columns.Append(c);
                }

                worksheetPart.Worksheet.AppendChild(columns);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Carico lavoro" };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header

                Row row = new Row();

                row.Append(ConstructCell("Azienda", CellValues.String, 2));
                row.Append(ConstructCell("Tipo Lancio", CellValues.String, 2));
                row.Append(ConstructCell("Codice", CellValues.String, 2));
                row.Append(ConstructCell("Codiceclifo", CellValues.String, 2));
                row.Append(ConstructCell("Ragione Soc", CellValues.String, 2));
                row.Append(ConstructCell("nummovfase", CellValues.String, 2));
                row.Append(ConstructCell("pianificato_sn", CellValues.String, 2));
                row.Append(ConstructCell("NomeCommessa", CellValues.String, 2));
                row.Append(ConstructCell("segnalatore", CellValues.String, 2));
                row.Append(ConstructCell("Codtipomovfase", CellValues.String, 2));
                row.Append(ConstructCell("destipomovfase", CellValues.String, 2));
                row.Append(ConstructCell("Modello_lancio", CellValues.String, 2));
                row.Append(ConstructCell("Desmodello_lancio", CellValues.String, 2));
                row.Append(ConstructCell("Idmagazz", CellValues.String, 2));
                row.Append(ConstructCell("Modello_wip", CellValues.String, 2));
                row.Append(ConstructCell("Desmodello_wip", CellValues.String, 2));
                row.Append(ConstructCell("Elencofasi", CellValues.String, 2));
                row.Append(ConstructCell("datamovfase", CellValues.String, 2));
                row.Append(ConstructCell("Datainizio_odl", CellValues.String, 2));
                row.Append(ConstructCell("Dataprimoinvio_odl", CellValues.String, 2));
                row.Append(ConstructCell("Documenti_invio", CellValues.String, 2));
                row.Append(ConstructCell("Datafine_odl_e_multipla", CellValues.String, 2));
                row.Append(ConstructCell("Datafine_fasecommessa", CellValues.String, 2));
                row.Append(ConstructCell("Conta_multiple", CellValues.String, 2));
                row.Append(ConstructCell("Codiceunimi", CellValues.String, 2));
                row.Append(ConstructCell("Qta", CellValues.String, 2));
                row.Append(ConstructCell("qtadater", CellValues.String, 2));
                row.Append(ConstructCell("Priorita", CellValues.String, 2));
                row.Append(ConstructCell("Noteparticolarifase", CellValues.String, 2));
                row.Append(ConstructCell("Notaparticolareodl", CellValues.String, 2));
                row.Append(ConstructCell("Modello_lancio_mp", CellValues.String, 2));
                row.Append(ConstructCell("Desmodello-lancio_mp", CellValues.String, 2));
                row.Append(ConstructCell("Impegnatoareparto", CellValues.String, 2));
                row.Append(ConstructCell("Internoesterno", CellValues.String, 2));
                row.Append(ConstructCell("Fermounasettimana", CellValues.String, 2));
                row.Append(ConstructCell("Scaduto", CellValues.String, 2));
                row.Append(ConstructCell("Annocarico", CellValues.String, 2));
                row.Append(ConstructCell("Settimanacarico", CellValues.String, 2));
                row.Append(ConstructCell("Apertodaduegiorni", CellValues.String, 2));
                row.Append(ConstructCell("Nota", CellValues.String, 2));
                row.Append(ConstructCell("Appoggio", CellValues.String, 2));

                sheetData.AppendChild(row);

                foreach (ReportDS.ODL_APERTIRow odl_aperto in ds.ODL_APERTI)
                {
                    Row rowDati = new Row();
                    rowDati.Append(ConstructCell(odl_aperto.IsAZIENDANull() ? string.Empty : odl_aperto.AZIENDA, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDESTIPOLANCIONull() ? string.Empty : odl_aperto.DESTIPOLANCIO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsCODICETIPOONull() ? string.Empty : odl_aperto.CODICETIPOO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsCODICECLIFONull() ? string.Empty : odl_aperto.CODICECLIFO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsRAGIONESOCNull() ? string.Empty : odl_aperto.RAGIONESOC, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsNUMMOVFASENull() ? string.Empty : odl_aperto.NUMMOVFASE, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsPIANIFICATO_SNNull() ? string.Empty : odl_aperto.PIANIFICATO_SN, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsNOMECOMMESSANull() ? string.Empty : odl_aperto.NOMECOMMESSA, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsSEGNALATORENull() ? string.Empty : odl_aperto.SEGNALATORE, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsCODTIPOMOVFASENull() ? string.Empty : odl_aperto.CODTIPOMOVFASE, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDESTIPOMOVFASENull() ? string.Empty : odl_aperto.DESTIPOMOVFASE, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsMODELLO_LANCIONull() ? string.Empty : odl_aperto.MODELLO_LANCIO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDESMODELLO_LANCIONull() ? string.Empty : odl_aperto.DESMODELLO_LANCIO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsIDMAGAZZ_WIPNull() ? string.Empty : odl_aperto.IDMAGAZZ_WIP, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsMODELLO_WIPNull() ? string.Empty : odl_aperto.MODELLO_WIP, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDESMODELLO_WIPNull() ? string.Empty : odl_aperto.DESMODELLO_WIP, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsELENCOFASINull() ? string.Empty : odl_aperto.ELENCOFASI, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDATAMOVFASENull() ? string.Empty : odl_aperto.DATAMOVFASE.ToShortDateString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDATAINIZIO_ODLNull() ? string.Empty : odl_aperto.DATAINIZIO_ODL.ToShortDateString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDATAPRIMOINVIO_ODLNull() ? string.Empty : odl_aperto.DATAPRIMOINVIO_ODL.ToShortDateString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDOCUMENTI_INVIONull() ? string.Empty : odl_aperto.DOCUMENTI_INVIO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDATAFINE_ODL_E_MULTIPLANull() ? string.Empty : odl_aperto.DATAFINE_ODL_E_MULTIPLA.ToShortDateString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDATAFINE_FASECOMMESSANull() ? string.Empty : odl_aperto.DATAFINE_FASECOMMESSA.ToShortDateString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsCONTA_MULTIPLENull() ? string.Empty : odl_aperto.CONTA_MULTIPLE, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsCODICEUNIMINull() ? string.Empty : odl_aperto.CODICEUNIMI, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsQTANull() ? string.Empty : odl_aperto.QTA.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsQTADATERNull() ? string.Empty : odl_aperto.QTADATER.ToString(), CellValues.Number, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsPRIORITANull() ? string.Empty : odl_aperto.PRIORITA.ToString(), CellValues.Number, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsNOTEPARTICOLARIFASENull() ? string.Empty : odl_aperto.NOTEPARTICOLARIFASE, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsNOTAPARTICOLAREODLNull() ? string.Empty : odl_aperto.NOTAPARTICOLAREODL, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsMODELLO_LANCIO_MPNull() ? string.Empty : odl_aperto.MODELLO_LANCIO_MP, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsDESMODELLO_LANCIO_MPNull() ? string.Empty : odl_aperto.DESMODELLO_LANCIO_MP, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsIMPEGNATOAREPARTONull() ? string.Empty : odl_aperto.IMPEGNATOAREPARTO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsINTERNOESTERNONull() ? string.Empty : odl_aperto.INTERNOESTERNO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsFERMOUNASETTIMANANull() ? string.Empty : odl_aperto.FERMOUNASETTIMANA, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsSCADUTONull() ? string.Empty : odl_aperto.SCADUTO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsANNOCARICONull() ? string.Empty : odl_aperto.ANNOCARICO.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsSETTIMANACARICONull() ? string.Empty : odl_aperto.SETTIMANACARICO.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsAPERTODADUEGIORNINull() ? string.Empty : odl_aperto.APERTODADUEGIORNI, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsNOTANull() ? string.Empty : odl_aperto.NOTA, CellValues.String, 1));
                    rowDati.Append(ConstructCell(odl_aperto.IsAPPOGGIONull() ? string.Empty : odl_aperto.APPOGGIO, CellValues.String, 1));


                    sheetData.AppendChild(rowDati);
                }




                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
                
            }
            return content;



        }

        public byte[] ReportQuantitaExcel(ReportDS ds)
        {


            byte[] content;
            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();

                int numeroColonne = 4;
                Columns columns = new Columns();
                for (int i = 0; i < numeroColonne; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 15;

                    columns.Append(c);
                }

                worksheetPart.Worksheet.AppendChild(columns);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Report" };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header

                Row row = new Row();

                row.Append(ConstructCell("Codice", CellValues.String, 2));
                row.Append(ConstructCell("Ragione Soc", CellValues.String, 2));
                row.Append(ConstructCell("Somma", CellValues.String, 2));
                row.Append(ConstructCell("Percentuale", CellValues.String, 2));


                sheetData.AppendChild(row);

                foreach (ReportDS.REPORTQUANTITARow reportquantita in ds.REPORTQUANTITA)
                {
                    Row rowDati = new Row();
                    rowDati.Append(ConstructCell(reportquantita.CODICECLIFO, CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.RAGIONESOC, CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.SOMMA.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.PERC.ToString(), CellValues.String, 1));



                    sheetData.AppendChild(rowDati);
                }




                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }
            return content;
      
        }

        public byte[] ReportOrdiniAttiviExcel(List<OrdiniAttiviModel> lista)
        {


            byte[] content;
            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart worksheetPart = workbookPart.AddNewPart<WorksheetPart>();
                worksheetPart.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();

                int numeroColonne = 12;
                Columns columns = new Columns();
                for (int i = 0; i < numeroColonne; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 15;

                    columns.Append(c);
                }

                worksheetPart.Worksheet.AppendChild(columns);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Report" };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header

                Row row = new Row();

                row.Append(ConstructCell("Segnalatore", CellValues.String, 2));
                row.Append(ConstructCell("Quantità", CellValues.String, 2));
                row.Append(ConstructCell("Quantità non spedita", CellValues.String, 2));
                row.Append(ConstructCell("Quantità scaduta", CellValues.String, 2));
                row.Append(ConstructCell("Quantità annullata", CellValues.String, 2));
                row.Append(ConstructCell("Valore", CellValues.String, 2));
                row.Append(ConstructCell("Valore non spedito", CellValues.String, 2));
                row.Append(ConstructCell("Valore scaduto", CellValues.String, 2));
                row.Append(ConstructCell("Valore annullato", CellValues.String, 2));
                row.Append(ConstructCell("% scaduto su cliente", CellValues.String, 2));
                row.Append(ConstructCell("% scaduto su totale", CellValues.String, 2));


                sheetData.AppendChild(row);

                foreach (OrdiniAttiviModel reportquantita in lista)
                {
                    Row rowDati = new Row();
                    rowDati.Append(ConstructCell(reportquantita.Cliente, CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.Quantita.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.QuantitaNonSpedita.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.QuantitaScaduta.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.QuantitaAnnullata.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.Valore.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.ValoreNonSpedito.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.ValoreScaduto.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.ValoreAnnullato.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.PercScadutoCliente.ToString(), CellValues.String, 1));
                    rowDati.Append(ConstructCell(reportquantita.PercScadutoSulTotale.ToString(), CellValues.String, 1));

                    sheetData.AppendChild(rowDati);
                }




                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }
            return content;

        }

        private Cell ConstructCell(string value, CellValues dataType, uint styleIndex = 0)
        {
            return new Cell()
            {
                CellValue = new CellValue(value),
                DataType = new EnumValue<CellValues>(dataType),
                StyleIndex = styleIndex
            };
        }

        private Stylesheet GenerateStylesheet()
        {
            Stylesheet styleSheet = null;

            Fonts fonts = new Fonts(
                new Font( // Index 0 - default
                    new FontSize() { Val = 10 }

                ),
                new Font( // Index 1 - header
                    new FontSize() { Val = 10 },
                    new Bold(),
                    new Color() { Rgb = "FFFFFF" }

                ));

            Fills fills = new Fills(
                    new Fill(new PatternFill() { PatternType = PatternValues.None }), // Index 0 - default
                    new Fill(new PatternFill() { PatternType = PatternValues.Gray125 }), // Index 1 - default
                    new Fill(new PatternFill(new ForegroundColor { Rgb = new HexBinaryValue() { Value = "66666666" } })
                    { PatternType = PatternValues.Solid }) // Index 2 - header
                );

            Borders borders = new Borders(
                    new Border(), // index 0 default
                    new Border( // index 1 black border
                        new LeftBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new RightBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new TopBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new BottomBorder(new Color() { Auto = true }) { Style = BorderStyleValues.Thin },
                        new DiagonalBorder())
                );

            CellFormats cellFormats = new CellFormats(
                    new CellFormat(), // default
                    new CellFormat { FontId = 0, FillId = 0, BorderId = 1, ApplyBorder = true }, // body
                    new CellFormat { FontId = 1, FillId = 2, BorderId = 1, ApplyFill = true } // header
                );

            styleSheet = new Stylesheet(fonts, fills, borders, cellFormats);

            return styleSheet;
        }
    }

}