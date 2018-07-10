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
    public class ReporteCapacitacionD
    {

        #region Declaration
        int _totalColumnas = 3;
        Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(3);
        PdfPCell pdfPCell;
        MemoryStream _memoryStream = new MemoryStream();
        UsuarioTrabajador _usuariotrab = new UsuarioTrabajador();
        #endregion

        public byte[] PrepareReport(UsuarioTrabajador usuariotrab)
        {
            _usuariotrab = usuariotrab;

            #region
            _document = new Document(PageSize.A4, 0f, 0f, 0f, 0f);
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(20f, 20f, 20f, 20f);
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

            _fontStyle = FontFactory.GetFont("Tahoma", 12f, 1);
            pdfPCell = new PdfPCell(UsuarioTrabaInfo());
            pdfPCell.Colspan = 3;
            pdfPCell.Border = 0;
            _pdfTable.AddCell(pdfPCell); 

            #region Table Header
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);
            pdfPCell = new PdfPCell(new Phrase("Código ", _fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Nombre Capacitación", _fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("Fecha de inicio", _fontStyle));
            pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            pdfPCell.BackgroundColor = BaseColor.LIGHT_GRAY;
            _pdfTable.AddCell(pdfPCell);
            _pdfTable.CompleteRow();
            #endregion

            #region Table Body
            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 0);

            int SerialNumber = 1;

            foreach (CapacitacionR capacitaciond in _usuariotrab.DatosCapacitacion)
            {

                pdfPCell = new PdfPCell(new Phrase(capacitaciond.Id));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(capacitaciond.Tipo, _fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(pdfPCell);

                pdfPCell = new PdfPCell(new Phrase(capacitaciond.FechaInicio, _fontStyle));
                pdfPCell.HorizontalAlignment = Element.ALIGN_CENTER;
                pdfPCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                pdfPCell.BackgroundColor = BaseColor.WHITE;
                _pdfTable.AddCell(pdfPCell);

                _pdfTable.CompleteRow();
            }
            #endregion

        }

        private PdfPTable UsuarioTrabaInfo()
        {
            PdfPTable info = new PdfPTable(2);
            info.SetWidths(new float[] { 100f, 100f });

            pdfPCell = new PdfPCell(new Phrase("Nombre: ", _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(_usuariotrab.Nombre + " " + _usuariotrab.Apellidop + " " +  _usuariotrab.Apellidom, _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);
            info.CompleteRow();

            pdfPCell = new PdfPCell(new Phrase("Rut: ", _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase( _usuariotrab.Rut, _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);
            info.CompleteRow();


            pdfPCell = new PdfPCell(new Phrase("Empresa: ", _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(_usuariotrab.Empresa, _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);
            info.CompleteRow();


            pdfPCell = new PdfPCell(new Phrase("Teléfono: ", _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(_usuariotrab.Telefono, _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);
            info.CompleteRow();


            pdfPCell = new PdfPCell(new Phrase("E-mail: ", _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase(_usuariotrab.Email, _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);
            info.CompleteRow();

            pdfPCell = new PdfPCell(new Phrase("  ", _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);

            pdfPCell = new PdfPCell(new Phrase("  ", _fontStyle));
            pdfPCell.Border = 0;
            info.AddCell(pdfPCell);
            info.CompleteRow();

            return info;
        }

        private void ReportHeader()
        {
            _fontStyle = FontFactory.GetFont("Tahoma", 20f, 0);
            pdfPCell = new PdfPCell(new Phrase("SAFE - PREVENCIÓN DE RIESGOS", _fontStyle));
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

            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 0);
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