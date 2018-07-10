using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WebSafe.Models;

namespace WebSafe.Reporte
{
    public class ReporteCapacitacion
    {
        #region Declaration
        int _totalColumnas = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        List<CapacitacionR> _capacitaciones = new List<CapacitacionR>();
        #endregion

        public byte[] PrepareReport(List<CapacitacionR> capacitaciones)
        {
            _capacitaciones = capacitaciones;

            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins( 20f, 20f, 20f, 20f);
            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            PdfWriter.GetInstance(_document, _memoryStream);
            _document.Open();
            _pdfTable.SetWidths(new float[] { 20f, 105f, 100f });
            #endregion

            this.ReportHeader();
            this.ReportBody();
            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);
            _document.Close();
            return _memoryStream.ToArray();

        }

        private void ReportBody()
        {
            #region Table Header
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfPCell = new PdfPCell(new Phrase("Código", _fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Tipo de capacitación", _fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Fecha de capacitación", _fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(pdfPCell);
            _pdfTable.CompleteRow();
            #endregion

            #region Table Body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);
            int SerialNumber = 1;
            foreach (CapacitacionR capacitacion in _capacitaciones)
            {

                pdfPCell = new PdfPCell(new Phrase(SerialNumber++.ToString(), _fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(capacitacion.Tipo, _fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(capacitacion.FechaInicio, _fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(pdfPCell);
                _pdfTable.CompleteRow();
            }
            #endregion

        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 0);
            pdfPCell = new PdfPCell(new Phrase("SAFE - PREVENCIÓN DE RIESGOS", _fontStyle));
            pdfPCell.Colspan = _totalColumnas;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(pdfPCell);
            _pdfTable.CompleteRow();
            
            _fontStyle = FontFactory.GetFont("Tahoma", 19f, 0);
            pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            pdfPCell.Colspan = _totalColumnas;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 0);
            pdfPCell = new PdfPCell(new Phrase("Informe de Capacitaciones", _fontStyle));
            pdfPCell.Colspan = _totalColumnas;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(pdfPCell);
            _pdfTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 11f, 0);
            pdfPCell = new PdfPCell(new Phrase(" ", _fontStyle));
            pdfPCell.Colspan = _totalColumnas;
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.Border = 0;
            pdfPCell.BackgroundColor = BaseColor.WHITE;
            pdfPCell.ExtraParagraphSpace = 0;
            _pdfTable.AddCell(pdfPCell);
            _pdfTable.CompleteRow();

        }
    }
}