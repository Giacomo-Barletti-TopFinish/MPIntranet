using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using MPIntranet.Business;

namespace MPIntranet.Helpers
{
    public class ExcelHelper
    {
     
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

        public byte[] CreaFileFaseCicli(List<CicloBusinessCentral> cicli, out string errori)
        {
            errori = string.Empty;
            StringBuilder sb = new StringBuilder();

            byte[] content;

            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart wsTestata = workbookPart.AddNewPart<WorksheetPart>();
                wsTestata.Worksheet = new Worksheet();

                WorksheetPart wsDettaglio = workbookPart.AddNewPart<WorksheetPart>();
                wsDettaglio.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();


                Columns colonneTestata = new Columns();
                for (int i = 0; i < 19; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonneTestata.Append(c);
                }

                Columns colonneDettaglio = new Columns();
                for (int i = 0; i < 6; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonneDettaglio.Append(c);
                }

                wsTestata.Worksheet.AppendChild(colonneTestata);
                wsDettaglio.Worksheet.AppendChild(colonneDettaglio);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sTestata = new Sheet() { Id = workbookPart.GetIdOfPart(wsTestata), SheetId = 1, Name = "Righe cicli produzione" };
                Sheet sDettaglio = new Sheet() { Id = workbookPart.GetIdOfPart(wsDettaglio), SheetId = 2, Name = "Riga commento ciclo" };

                sheets.Append(sTestata);
                sheets.Append(sDettaglio);

                workbookPart.Workbook.Save();

                SheetData sheetDataTestata = wsTestata.Worksheet.AppendChild(new SheetData());
                SheetData sheetDataDettaglio = wsDettaglio.Worksheet.AppendChild(new SheetData());


                Row rowHeaderTestata = new Row();
                rowHeaderTestata.Append(ConstructCell("Nr. ciclo", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. versione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Nr. operazione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tipo", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Nr.", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo di setup", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo lavorazione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo attesa", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Tempo spostamento", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Dimensione lotto", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo di setup", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo lavoraz.", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo attesa", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. unità mis. tempo spostamento", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. collegamento tra ciclo e distinta base", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Cod. task standard", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Codice condizione", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Codice caratteristica", CellValues.String, 2));
                rowHeaderTestata.Append(ConstructCell("Codice logiche lavorazione", CellValues.String, 2));
                sheetDataTestata.AppendChild(rowHeaderTestata);

                Row rowHeaderDettaglio = new Row();
                rowHeaderDettaglio.Append(ConstructCell("Nr. ciclo", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Cod. versione", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Nr. operazione", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Nr. riga", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Data", CellValues.String, 2));
                rowHeaderDettaglio.Append(ConstructCell("Commento", CellValues.String, 2));
                sheetDataDettaglio.AppendChild(rowHeaderDettaglio);

                foreach (CicloBusinessCentral c in cicli)
                {
                    foreach (FaseCicloBusinessCentral f in c.Fasi)
                    {
                        Row rowTestata = new Row();

                        rowTestata.Append(ConstructCell(c.Codice, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Versione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Operazione.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Tipo, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.AreaProduzione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoSetup.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoLavorazione.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoAttesa.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.TempoSpostamento.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.DimensioneLotto.ToString(), CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMSetup, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMLavorazione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMAttesa, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.UMSpostamento, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Collegamento, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Task, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Condizione, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.Caratteristica, CellValues.String, 1));
                        rowTestata.Append(ConstructCell(f.LogicheLavorazione, CellValues.String, 1));

                        sheetDataTestata.AppendChild(rowTestata);


                        int numeroRiga = 1000;
                        foreach (string commento in f.Commenti)
                        {
                            List<string> elementi = SeparaStringa(commento, 80);
                            foreach (string elemento in elementi)
                            {
                                Row rowDettaglio = new Row();
                                rowDettaglio.Append(ConstructCell(c.Codice, CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(string.Empty, CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(f.Operazione.ToString(), CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(numeroRiga.ToString(), CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(DateTime.Today.ToShortDateString(), CellValues.String, 1));
                                rowDettaglio.Append(ConstructCell(elemento, CellValues.String, 1));
                                sheetDataDettaglio.AppendChild(rowDettaglio);
                                numeroRiga += 1000;
                            }
                        }
                    }
                }
                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();

                errori = sb.ToString().Trim();
                return content;
            }
        }
        private List<string> SeparaStringa(string stringa, int lunghezzaMassima)
        {
            List<string> stringhe = new List<string>();

            string stringaModificata = stringa.Replace("+", " + ");
            stringaModificata = stringaModificata.Replace("-", " - ");
            stringaModificata = stringaModificata.Replace("  ", " ");

            string[] str = stringaModificata.Split(' ');
            string stringaComposta = string.Empty;
            for (int i = 0; i < str.Length; i++)
            {
                if ((stringaComposta.Length + str[i].Length + 1) < lunghezzaMassima)
                {
                    stringaComposta = stringaComposta + " " + str[i];
                }
                else
                {
                    stringhe.Add(stringaComposta);
                    stringaComposta = str[i];
                }
                if (i == str.Length - 1)
                {
                    stringhe.Add(stringaComposta);
                }
            }
            return stringhe;
        }

        public byte[] CreaFileCompoentiDistinta(List<DistintaBusinessCentral> distinte, out string errori)
        {
            errori = string.Empty;
            StringBuilder sb = new StringBuilder();

            byte[] content;

            MemoryStream ms = new MemoryStream();

            using (SpreadsheetDocument document = SpreadsheetDocument.Create(ms, SpreadsheetDocumentType.Workbook))
            {
                WorkbookPart workbookPart = document.AddWorkbookPart();
                workbookPart.Workbook = new Workbook();

                WorksheetPart wsCicli = workbookPart.AddNewPart<WorksheetPart>();
                wsCicli.Worksheet = new Worksheet();

                // Adding style
                WorkbookStylesPart stylePart = workbookPart.AddNewPart<WorkbookStylesPart>();
                stylePart.Stylesheet = GenerateStylesheet();
                stylePart.Stylesheet.Save();


                Columns colonne = new Columns();
                for (int i = 0; i < 16; i++)
                {
                    Column c = new Column();
                    UInt32Value u = new UInt32Value((uint)(i + 1));
                    c.Min = u;
                    c.Max = u;
                    c.Width = 25;
                    c.CustomWidth = true;

                    colonne.Append(c);
                }

                wsCicli.Worksheet.AppendChild(colonne);

                Sheets sheets = workbookPart.Workbook.AppendChild(new Sheets());
                Sheet sTestata = new Sheet() { Id = workbookPart.GetIdOfPart(wsCicli), SheetId = 1, Name = "Righe DB produzione" };

                sheets.Append(sTestata);

                workbookPart.Workbook.Save();

                SheetData sheetDistinte = wsCicli.Worksheet.AppendChild(new SheetData());

                Row rowHeader = new Row();
                rowHeader.Append(ConstructCell("Nr. DB di produzione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. versione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Nr. riga", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Tipo", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Nr.", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Descrizione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. unità di misura", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Quantità", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. collegamento tra ciclo e distinta base", CellValues.String, 2));
                rowHeader.Append(ConstructCell("% scarto", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Quantità per", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Precious Quantity", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Formula quantità", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Codice condizione", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Nr. articolo neutro", CellValues.String, 2));
                rowHeader.Append(ConstructCell("Cod. formula", CellValues.String, 2));
                sheetDistinte.AppendChild(rowHeader);

                foreach (DistintaBusinessCentral d in distinte)
                {
                    int numeroRiga = 1000;
                    foreach (ComponenteDistintaBusinessCentral c in d.Componenti)
                    {
                        Row row = new Row();
                        row.Append(ConstructCell(d.Codice, CellValues.String, 1));
                        row.Append(ConstructCell(d.Versione, CellValues.String, 1));
                        row.Append(ConstructCell(numeroRiga.ToString(), CellValues.String, 1));
                        numeroRiga += 1000;
                        row.Append(ConstructCell(c.Tipo, CellValues.String, 1));
                        row.Append(ConstructCell(c.Anagrafica, CellValues.String, 1));
                        row.Append(ConstructCell(c.Descrizione.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.CodiceUM.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.Quantita.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell((c.Collegamento == null) ? string.Empty : c.Collegamento, CellValues.String, 1));
                        row.Append(ConstructCell(c.Scarto.ToString(), CellValues.String, 1));

                        row.Append(ConstructCell(c.Quantita.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.Arrotondamento.ToString(), CellValues.String, 1));
                        row.Append(ConstructCell(c.FormulaQuantita, CellValues.String, 1));
                        row.Append(ConstructCell(c.Condizione, CellValues.String, 1));
                        row.Append(ConstructCell(c.ArticoloNeutro, CellValues.String, 1));
                        row.Append(ConstructCell(c.Formula, CellValues.String, 1));
                        sheetDistinte.AppendChild(row);

                    }

                }

                workbookPart.Workbook.Save();
                document.Save();
                document.Close();

                ms.Seek(0, SeekOrigin.Begin);
                content = ms.ToArray();
            }
            errori = sb.ToString().Trim();
            return content;
        }
    }

}