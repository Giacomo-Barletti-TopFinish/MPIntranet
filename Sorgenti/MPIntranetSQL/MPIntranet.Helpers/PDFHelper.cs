﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;

namespace MPIntranet.Helpers
{
    public class PDFHelper
    {
        private Document document = new Document();

        public void CreaScheda(string ragioneSociale, string idCollaudo, string data,
            string prefisso, string parte, string colore, string quantita,
            string descrizione, string commessa, bool controlloFisico, bool controlloFunzionale, bool controlloDimensionale,
            bool controlloEstetico, bool acconto, bool saldo, string altro, string certificati, byte[] image)
        {

            document.Info.Title = "Scheda Processp";
            document.Info.Subject = String.Empty;
            document.Info.Author = string.Empty;

            Section section = document.AddSection();

            DefineBasicStyles();
            CreaTabellaScheda(ragioneSociale, idCollaudo, data,
             prefisso, parte, colore, quantita,
             descrizione, commessa, controlloFisico, controlloFunzionale, controlloDimensionale,
             controlloEstetico, acconto, saldo, altro, certificati, image);
        }

        public void SalvaPdf(string filename)
        {
            PdfDocumentRenderer renderer = new PdfDocumentRenderer(true, PdfSharp.Pdf.PdfFontEmbedding.Always);
            renderer.Document = document;

            renderer.RenderDocument();
            renderer.PdfDocument.Save(filename);
        }
        private void DefineBasicStyles()
        {
            // Get the predefined style Normal.
            Style style = document.Styles["Normal"];
            // Because all styles are derived from Normal, the next line changes the 
            // font of the whole document. Or, more exactly, it changes the font of
            // all styles and paragraphs that do not redefine the font.
            style.Font.Name = "Calibri";
            style.Font.Size = 12;
            // Heading1 to Heading9 are predefined styles with an outline level. An outline level
            // other than OutlineLevel.BodyText automatically creates the outline (or bookmarks) 
            // in PDF.

            style = document.Styles["Heading1"];
            style.Font.Size = 17;
            style.Font.Color = Colors.Black;

            style = document.Styles["Heading2"];
            style.Font.Size = 12;
            style.Font.Bold = true;
            style.ParagraphFormat.PageBreakBefore = false;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 6;

            style = document.Styles["Heading3"];
            style.Font.Size = 10;
            style.Font.Bold = true;
            style.Font.Italic = true;
            style.ParagraphFormat.SpaceBefore = 6;
            style.ParagraphFormat.SpaceAfter = 3;

            style = document.Styles[StyleNames.Header];
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right);

            style = document.Styles[StyleNames.Footer];
            style.ParagraphFormat.AddTabStop("8cm", TabAlignment.Center);

            // Create a new style called TextBox based on style Normal
            style = document.Styles.AddStyle("TextBox", "Normal");
            style.ParagraphFormat.Alignment = ParagraphAlignment.Justify;
            style.ParagraphFormat.Borders.Width = 2.5;
            style.ParagraphFormat.Borders.Distance = "3pt";
            style.ParagraphFormat.Shading.Color = Colors.SkyBlue;

            // Create a new style called TOC based on style Normal
            style = document.Styles.AddStyle("TOC", "Normal");
            style.ParagraphFormat.AddTabStop("16cm", TabAlignment.Right, TabLeader.Dots);
            style.ParagraphFormat.Font.Color = Colors.Blue;
        }

        private void CreaTabellaScheda(string ragioneSociale, string idCollaudo, string data,
            string prefisso, string parte, string colore, string quantita,
            string descrizione, string commessa, bool controlloFisico, bool controlloFunzionale, bool controlloDimensionale,
            bool controlloEstetico, bool acconto, bool saldo, string altro, string certificati, byte[] image)
        {
            document.LastSection.AddParagraph();

            // RIGA 1
            Table table = new Table();
            table.Borders.Width = 0.75;

            Column column = table.AddColumn(Unit.FromCentimeter(13.5));
            column.Format.Alignment = ParagraphAlignment.Center;

            table.AddColumn(Unit.FromCentimeter(3.9));

            Row row = table.AddRow();
            row.Height = Unit.FromCentimeter(2.1);

            Cell cell = row.Cells[0];
            cell.AddParagraph("CERTIFICATO DI CONFORMITA'");
            cell.Style = "Heading1";
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell = row.Cells[1];
            cell.AddParagraph("MH-MO-007");
            cell.AddParagraph("Rev. 00 del");
            cell.AddParagraph("03/03/2017");
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;

            document.LastSection.Add(table);

            // RIGA 2
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(7.7));
            column = table.AddColumn(Unit.FromCentimeter(5.8));
            table.AddColumn(Unit.FromCentimeter(3.9));

            row = table.AddRow();

            cell = row.Cells[0];
            cell.AddParagraph("RAGIONE SOCIALE FORNITORE:");
            cell.Format.Alignment = ParagraphAlignment.Left;
            cell = row.Cells[1];
            cell.AddParagraph("N° ID Collaudo:");
            cell.Format.Alignment = ParagraphAlignment.Left;
            cell = row.Cells[2];
            cell.AddParagraph("DATA:");
            cell.Format.Alignment = ParagraphAlignment.Left;
            table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.None, 0);
            table.SetEdge(0, 0, 3, 1, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 3, 1, Edge.Right, BorderStyle.Single, 0.75);


            document.LastSection.Add(table);

            // RIGA 3
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(7.7));
            column = table.AddColumn(Unit.FromCentimeter(5.8));
            table.AddColumn(Unit.FromCentimeter(3.9));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.6);

            cell = row.Cells[0];
            cell.AddParagraph(ragioneSociale);
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[1];
            cell.AddParagraph(idCollaudo);
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[2];
            cell.AddParagraph(data);
            cell.Format.Alignment = ParagraphAlignment.Center;

            table.SetEdge(0, 0, 3, 1, Edge.Top, BorderStyle.None, 0);

            document.LastSection.Add(table);

            // RIGA 4
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(5.8));
            column = table.AddColumn(Unit.FromCentimeter(5.8));
            table.AddColumn(Unit.FromCentimeter(5.8));

            row = table.AddRow();

            cell = row.Cells[0];
            cell.AddParagraph("PREFISSO-PARTE-COLORE:");
            cell.Format.Alignment = ParagraphAlignment.Left;
            cell = row.Cells[1];
            cell.AddParagraph("QUANTITA':");
            cell.Format.Alignment = ParagraphAlignment.Left;
            cell = row.Cells[2];
            cell.AddParagraph("Descrizione:");
            cell.Format.Alignment = ParagraphAlignment.Left;
            table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.None, 0);
            table.SetEdge(0, 0, 3, 1, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 3, 1, Edge.Right, BorderStyle.Single, 0.75);

            document.LastSection.Add(table);

            // RIGA 5
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(5.8));
            column = table.AddColumn(Unit.FromCentimeter(5.8));
            table.AddColumn(Unit.FromCentimeter(5.8));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.6);

            cell = row.Cells[0];
            string testo = string.Format("{0}-{1}-{2}", prefisso, parte, colore);
            cell.AddParagraph(testo);
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[1];
            cell.AddParagraph(quantita);
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell = row.Cells[2];
            cell.AddParagraph(descrizione);
            cell.Format.Alignment = ParagraphAlignment.Center;

            table.SetEdge(0, 0, 3, 1, Edge.Box, BorderStyle.Single, 0.75);

            document.LastSection.Add(table);
            // RIGA 6
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(5.8));
            table.AddColumn(Unit.FromCentimeter(11.6));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);

            cell = row.Cells[0];
            cell.AddParagraph("ORDINE/COMMESSA:");
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell = row.Cells[1];
            cell.AddParagraph(commessa);
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;

            table.SetEdge(0, 0, 2, 1, Edge.Top, BorderStyle.None, 0);
            table.SetEdge(0, 0, 2, 1, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 2, 1, Edge.Right, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 2, 1, Edge.Bottom, BorderStyle.Single, 0.75);

            document.LastSection.Add(table);
            // RIGA 7
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(17.4));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);

            cell = row.Cells[0];
            cell.AddParagraph("NOTE");
            cell.Format.Font.Bold = true;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;

            table.SetEdge(0, 0, 1, 1, Edge.Top, BorderStyle.None, 0);
            table.SetEdge(0, 0, 1, 1, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 1, 1, Edge.Right, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 1, 1, Edge.Bottom, BorderStyle.Single, 0.75);

            document.LastSection.Add(table);

            // RIGA 8.1
            table = new Table();
            // table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(5.4));
            column = table.AddColumn(Unit.FromCentimeter(12));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);

            cell = row.Cells[0];
            cell.VerticalAlignment = VerticalAlignment.Center;
            Paragraph p = cell.AddParagraph("Controllo Fisico e Chimico");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph(string.Empty);
            p.AddFormattedText(controlloFisico ? "\u00fe" : "\u00A8", new Font("Wingdings"));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);
            cell = row.Cells[0];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph("Controllo Funzionale");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph(string.Empty);
            p.AddFormattedText(controlloFunzionale ? "\u00fe" : "\u00A8", new Font("Wingdings"));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);
            cell = row.Cells[0];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph("Controllo Dimensionale");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph(string.Empty);
            p.AddFormattedText(controlloDimensionale ? "\u00fe" : "\u00A8", new Font("Wingdings"));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);
            cell = row.Cells[0];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph("Controllo Estetico");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph(string.Empty);
            p.AddFormattedText(controlloEstetico ? "\u00fe" : "\u00A8", new Font("Wingdings"));

            table.SetEdge(0, 0, 2, 4, Edge.Top, BorderStyle.None, 0);
            table.SetEdge(0, 0, 2, 4, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 2, 4, Edge.Right, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 2, 4, Edge.Bottom, BorderStyle.None, 0);

            document.LastSection.Add(table);
            // RIGA 8.2
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(17.4));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(3);

            cell = row.Cells[0];
            p = cell.AddParagraph(string.Empty);
            if (string.IsNullOrEmpty(certificati))
                p = cell.AddParagraph("Certificati: ..........................................................................................................................................");
            else
                p = cell.AddParagraph(string.Format("Certificati: {0}", certificati));
            p = cell.AddParagraph(string.Empty);
            if (string.IsNullOrEmpty(altro))
                p = cell.AddParagraph("Altro: ..................................................................................................................................................");
            else
                p = cell.AddParagraph(string.Format("Altro: {0}", altro));

            table.SetEdge(0, 0, 1, 1, Edge.Top, BorderStyle.None, 0);
            table.SetEdge(0, 0, 1, 1, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 1, 1, Edge.Right, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 1, 1, Edge.Bottom, BorderStyle.Single, 0.75);

            document.LastSection.Add(table);
            // RIGA 9
            table = new Table();
            table.Borders.Width = 0.75;

            column = table.AddColumn(Unit.FromCentimeter(17.4));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(2.1);

            cell = row.Cells[0];
            cell.AddParagraph("SI CERTIFICA CHE LA FORNITURA E' CONFORME IN OGNI PARTE ALL'ORDINE CUI SI RIFERISCE, AD ECCEZIONE DELLE DEROGHE/CONCESSIONI ANNOTATE, E CHE LE FORNITURE SONO STATE VERIFICATE E PROVATE IN CONFORMITA' AI REQUISITI DELL'ORDINE/COMMESSA.");

            table.SetEdge(0, 0, 1, 1, Edge.Top, BorderStyle.None, 0);
            table.SetEdge(0, 0, 1, 1, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 1, 1, Edge.Right, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 1, 1, Edge.Bottom, BorderStyle.Single, 0.75);

            document.LastSection.Add(table);

            // RIGA 9
            table = new Table();

            column = table.AddColumn(Unit.FromCentimeter(4.4));
            column = table.AddColumn(Unit.FromCentimeter(3.3));
            column = table.AddColumn(Unit.FromCentimeter(9.7));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.3);

            cell = row.Cells[0];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph("ACCONTO FORNITURA");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph(string.Empty);
            p.AddFormattedText(acconto ? "\u00fe" : "\u00A8", new Font("Wingdings"));

            cell = row.Cells[2];
            cell.MergeDown = 1;
            p = cell.AddParagraph("Timbro e Firma Responsabile della Qualità");
            if (image != null)
            {
                string fileImage = MigraDocFilenameFromByteArray(image);

                p.AddImage(fileImage);

            }

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.3);

            cell = row.Cells[0];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph("SALDO");
            cell = row.Cells[1];
            cell.VerticalAlignment = VerticalAlignment.Center;
            p = cell.AddParagraph(string.Empty);
            p.AddFormattedText(saldo ? "\u00fe" : "\u00A8", new Font("Wingdings"));

            table.SetEdge(0, 0, 3, 2, Edge.Top, BorderStyle.None, 0);
            table.SetEdge(0, 0, 3, 2, Edge.Left, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 3, 2, Edge.Right, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 3, 2, Edge.Bottom, BorderStyle.Single, 0.75);
            table.SetEdge(0, 0, 2, 2, Edge.Right, BorderStyle.Single, 0.75);
            document.LastSection.Add(table);
        }

        private string MigraDocFilenameFromByteArray(byte[] image)
        {
            if (image == null) return string.Empty;
            return "base64:" + Convert.ToBase64String(image);
        }
        public void CreaReportSchedaProcesso(bool pesoArticolo, string data, string dataProduzione, string prefisso, string parte, string colore, string commessa, string quantita, byte[] iloghi)
        {
            bool nichelFree = false;
            document.Info.Title = "Scheda Processo ";
            document.Info.Subject = String.Empty;
            document.Info.Author = string.Empty;

            Section section = document.AddSection();

            DefineBasicStyles();

            Paragraph p = document.LastSection.AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Center;
            string iLogoMP = MigraDocFilenameFromByteArray(iloghi);
            p.AddImage(iLogoMP);
            p = document.LastSection.AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Center;
            Font fontPiccolo = new Font("Times New Roman");
            fontPiccolo.Size = 8;
            p.AddFormattedText("Viale Kennedy, 103 - 50038 SCARPERIA (FI) - P.Iva 04949200481", fontPiccolo);
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddFormattedText("Tel 055 843611 - Fax 055 8436130 - e-mail: info@metal-plus.it", fontPiccolo);

            Font fontGrande = new Font("Times New Roman");
            fontGrande.Size = 22;
            fontGrande.Bold = true;
            p = document.LastSection.AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Center;
            p.AddLineBreak();
            p.AddLineBreak();
            if (nichelFree)
                p.AddFormattedText("Autodichiarazione per articoli Nichel free", fontGrande);
            else
                p.AddFormattedText("Autodichiarazione per articoli Antiallergico", fontGrande);
            p = document.LastSection.AddParagraph();
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddLineBreak();

            Table table = new Table();
            table.Borders.Width = 1.5;

            Column column = table.AddColumn(Unit.FromCentimeter(4.5));
            column = table.AddColumn(Unit.FromCentimeter(12.5));

            Row row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.3);

            Cell cell = row.Cells[0];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.AddParagraph("DATA");

            cell = row.Cells[1];
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.AddParagraph(data);

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.3);
            cell = row.Cells[0];
            cell.AddParagraph("DATA PRODUZIONE");
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;

            cell = row.Cells[1];
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph(dataProduzione);

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.3);
            cell = row.Cells[0];
            cell.Format.Font.Size = 14;
            cell.Format.Font.Bold = true;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph("ARTICOLO");
            cell = row.Cells[1];
            cell.Format.Font.Bold = true;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Size = 14;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph(string.Format("{0}-{1}", prefisso, parte));

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);
            cell = row.Cells[0];
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph("FINITURA");
            cell = row.Cells[1];
            cell.Format.Font.Bold = true;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.Format.Font.Size = 14;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph(colore);

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);
            cell = row.Cells[0];
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph("COMMESSA");
            cell = row.Cells[1];
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph(commessa);

            row = table.AddRow();
            row.Height = Unit.FromCentimeter(1.1);
            cell = row.Cells[0];
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph("N° PEZZI PRODOTTI");
            cell = row.Cells[1];
            cell.Format.Font.Bold = true;
            cell.Format.Font.Size = 14;
            cell.Format.Alignment = ParagraphAlignment.Center;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.AddParagraph(quantita);

            document.LastSection.Add(table);


            Font fontNormale = new Font("Times New Roman");
            fontNormale.Size = 14;

            p = document.LastSection.AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Center;
            p.Format.Font = fontNormale;
            p.AddLineBreak();
            p.AddLineBreak();
            if (nichelFree)
                p.AddFormattedText("L’azienda Metalplus dichiara in fede che nella realizzazione del riporto galvanico del lotto in oggetto è stato seguito il ciclo Nichel free previsto sulla scheda del Capitolato Gucci, con la giusta sequenza dei bagni evitando tassativamente di utilizzare un qualunque bagno o trattamento che possa comportare un qualsivoglia deposito di nichel su pezzi. ", fontNormale);
            else
                p.AddFormattedText("L’azienda Metalplus dichiara in fede che nella realizzazione del riporto galvanico del lotto in oggetto è stato seguito il ciclo antiallergico previsto sulla scheda del Capitolato Gucci, con la giusta sequenza dei bagni. ", fontNormale);
            p.AddLineBreak();
            p.AddLineBreak();

            fontNormale = new Font("Times New Roman");
            fontNormale.Size = 14;

            p = document.LastSection.AddParagraph();
            p.Format.Alignment = ParagraphAlignment.Right;
            p.Format.Font = fontNormale;
            p.AddLineBreak();
            p.AddLineBreak();
            p.AddText("In fede");
            p.AddLineBreak();
            p.AddText("Crolli Fabio");
        }



      
    }      
}

