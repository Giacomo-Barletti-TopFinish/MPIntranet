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

namespace MPIntranet.Models.Report
{
    public class ExcelHelper
    {
        public byte[] CreaExcelMancanti(ReportDS ds)
        {
            byte[] content;
            MemoryStream ms = new MemoryStream();
            //string filename = @"c:\temp\mancanti.xlsx";
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

                // Setting up columns
                Columns columns = new Columns(
                        new Column
                        {
                            Min = 1,
                            Max = 1,
                            Width = 15,
                            CustomWidth = true
                        },
                        new Column
                        {
                            Min = 2,
                            Max = 2,
                            Width = 20,
                            CustomWidth = false
                        },
                        new Column
                        {
                            Min = 3,
                            Max = 3,
                            Width = 20,
                            CustomWidth = true
                        },
                        new Column
                        {
                            Min = 4,
                            Max = 4,
                            Width = 40,
                            CustomWidth = false
                        },
                        new Column
                        {
                            Min = 5,
                            Max = 5,
                            Width = 60,
                            CustomWidth = true
                        },
                        new Column
                        {
                            Min = 1,
                            Max = 1,
                            Width = 15,
                            CustomWidth = true
                        });

                worksheetPart.Worksheet.AppendChild(columns);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());

                Sheet sheet = new Sheet() { Id = workbookPart.GetIdOfPart(worksheetPart), SheetId = 1, Name = "Mancanti" };

                sheets.Append(sheet);

                workbookPart.Workbook.Save();

                SheetData sheetData = worksheetPart.Worksheet.AppendChild(new SheetData());

                // Constructing header
                Row row = new Row();

                row.Append(
                        ConstructCell("Azienda", CellValues.String, 2),
                        ConstructCell("Tipo Lancio", CellValues.String, 2),
                        ConstructCell("Codice", CellValues.String, 2),
                        ConstructCell("Codiceclifo", CellValues.String, 2),
                        ConstructCell("Ragione Soc", CellValues.String, 2),
                        ConstructCell("Nummovfase", CellValues.String, 2),
                        ConstructCell("pianificato_sn", CellValues.String, 2));
                ConstructCell("NomeCommessa", CellValues.String, 2);
                ConstructCell("segnalatore", CellValues.String, 2);
                ConstructCell("Codtipomovfase", CellValues.String, 2);
                ConstructCell("destipomovfase", CellValues.String, 2);
                ConstructCell("Modello_lancio", CellValues.String, 2);
                ConstructCell("Desmodello_lancio", CellValues.String, 2);
                ConstructCell("Modello_wip", CellValues.String, 2);
                ConstructCell("Elencofasi", CellValues.String, 2);
                ConstructCell("datamovfase", CellValues.String, 2);
                ConstructCell("Datainizio_odl", CellValues.String, 2);
                ConstructCell("Dataprimoinvio_odl", CellValues.String, 2);
                ConstructCell("Documenti_invio", CellValues.String, 2);
                ConstructCell("Datafine_odl_e_multipla", CellValues.String, 2);
                ConstructCell("Datafine_fasecommessa", CellValues.String, 2);
                ConstructCell("Conta_multiple", CellValues.String, 2);
                ConstructCell("Codiceunimi", CellValues.String, 2);
                ConstructCell("Qta", CellValues.String, 2);
                ConstructCell("qtadater", CellValues.String, 2);
                ConstructCell("Priorita", CellValues.String, 2);
                ConstructCell("Noteparticolarifase", CellValues.String, 2);
                ConstructCell("Modello_lancio_mp", CellValues.String, 2);
                ConstructCell("Desmodello-lancio_mp", CellValues.String, 2);
                ConstructCell("Impegnatoareparto", CellValues.String, 2);
                ConstructCell("Internoesterno", CellValues.String, 2);
                ConstructCell("Fermounasettimana", CellValues.String, 2);
                ConstructCell("Scaduto", CellValues.String, 2);
                ConstructCell("Annocarico", CellValues.String, 2);
                ConstructCell("Settimanacarico", CellValues.String, 2);
                ConstructCell("Apertodaduegiorni", CellValues.String, 2);
                ConstructCell("Nota", CellValues.String, 2);
                ConstructCell("Appoggio", CellValues.String, 2);
                
                // Insert the header row to the Sheet Data
                sheetData.AppendChild(row);

                foreach (ReportDS.ODL_APERTIRow odl_aperto in _ds.ODL_APERTI)
                {
                    row = new Row();

                    row.Append(

                        ConstructCell(odl_aperto.AZIENDA, CellValues.String, 1),
                        ConstructCell(odl_aperto.CODICETIPOO, CellValues.String, 1),
                        ConstructCell(odl_aperto.RAGIONESOC, CellValues.String, 1),
                        ConstructCell(odl_aperto.NUMMOVFASE, CellValues.String, 1),
                        ConstructCell(odl_aperto.NOMECOMMESSA, CellValues.Number, 1),
                    ConstructCell(odl_aperto.SEGNALATORE, CellValues.String, 1),
                    ConstructCell(odl_aperto.CODTIPOMOVFASE, CellValues.String, 1),
                    ConstructCell(odl_aperto.MODELLO_LANCIO, CellValues.String, 1),
                    ConstructCell(odl_aperto.MODELLO_WIP, CellValues.String, 1),
                    ConstructCell(odl_aperto.ELENCOFASI, CellValues.Number, 1),
                    ConstructCell(odl_aperto.DATAMOVFASE.ToShortDateString(), CellValues.String, 1),
                    ConstructCell(odl_aperto.QTA.ToString(), CellValues.String, 1),
                    ConstructCell(odl_aperto.QTADATER.ToString(), CellValues.Number, 1),
                   

                    sheetData.AppendChild(row));
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