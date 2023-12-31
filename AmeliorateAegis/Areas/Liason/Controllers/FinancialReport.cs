﻿using AmeliorateAegis.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace AmeliorateAegis.Reports
{
    public class FinancialReport
    {
        private readonly IWebHostEnvironment _oHostEnvironment;
        public FinancialReport( IWebHostEnvironment oHostEnvironment)
        {
            _oHostEnvironment = oHostEnvironment;
        }

        #region Declaration
        int _maxColumn = 4;
       Document _document;
        Font _fontStyle;
        PdfPTable _pdfTable = new PdfPTable(4);
        PdfPCell _pdfCell;
        MemoryStream _memoryStream = new MemoryStream();

        List<Financial> _oFinancials = new List<Financial>();

        #endregion 

        public byte[] Report(List<Financial> oFinancials)
        {
            _oFinancials = oFinancials;

            _document = new Document();
            _document.SetPageSize(PageSize.A4);
            _document.SetMargins(5f, 5f, 20f, 5f);

            _pdfTable.WidthPercentage = 100;
            _pdfTable.HorizontalAlignment = Element.ALIGN_LEFT;

            _fontStyle = FontFactory.GetFont("Tahoma", 8f, 1);

            PdfWriter docWrite = PdfWriter.GetInstance(_document, _memoryStream);

            _document.Open();

            float[] sizes = new float[_maxColumn];
            for (var i=0; i< _maxColumn; i++)
            {
                if (i == 0) sizes[i] = 20;
                else sizes[i] = 100;
            }

            _pdfTable.SetWidths(sizes);

            this.ReportHeader();
            this.EmptyRow(2);
            this.ReportBody();

            _pdfTable.HeaderRows = 2;
            _document.Add(_pdfTable);

            _document.Close();

            return _memoryStream.ToArray();
        }

        private void ReportHeader()
        {
            _pdfCell = new PdfPCell(this.Addlogo());
            _pdfCell.Colspan = 1;
            _pdfCell.Border = 0;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(this.SetPageTitle());
            _pdfCell.Colspan = _maxColumn-1;
            _pdfCell.Border = 0;
            _pdfTable.AddCell(_pdfCell);

            _pdfTable.CompleteRow();
        }

        private PdfPTable Addlogo()
        {
            int maxColumn = 1;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);
            string path = _oHostEnvironment.WebRootPath + "/Images";

            string imgCombine = Path.Combine(path, "Ameliorate.PNG");
            Image img = Image.GetInstance(imgCombine);

            _pdfCell = new PdfPCell(img);
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.CompleteRow();

            return pdfPTable;
        }

        private PdfPTable SetPageTitle()
        {
            int maxColumn = 4;
            PdfPTable pdfPTable = new PdfPTable(maxColumn);

            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfCell = new PdfPCell(new Phrase("Printed by Provincial Liaison", _fontStyle));
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            _fontStyle = FontFactory.GetFont("Tahoma", 18f, 1);
            _pdfCell = new PdfPCell(new Phrase("Financial Records", _fontStyle));
            _pdfCell.Colspan = maxColumn;
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.Border = 0;
            _pdfCell.ExtraParagraphSpace = 0;
            pdfPTable.AddCell(_pdfCell);
            pdfPTable.CompleteRow();

            return pdfPTable;

        }

        private void EmptyRow(int nCount)
        {
            for(int i=1; i<= nCount; i++)
            {
                _pdfCell = new PdfPCell(new Phrase("", _fontStyle));
                _pdfCell.Colspan = _maxColumn;
                _pdfCell.Border = 0;
                _pdfCell.ExtraParagraphSpace = 10;
                _pdfTable.AddCell(_pdfCell);
                _pdfTable.CompleteRow();
            }
        }

        private void ReportBody()
        {
            var fontStyleBold = FontFactory.GetFont("Tahoma", 9f, 1);
            _fontStyle = FontFactory.GetFont("Tahoma", 9f, 0);

            #region Details Table Header
            _pdfCell = new PdfPCell(new Phrase("Id", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);

            _pdfCell = new PdfPCell(new Phrase("Center Name", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfCell = new PdfPCell(new Phrase("Cost Description", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfCell = new PdfPCell(new Phrase("Amount", fontStyleBold));
            _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
            _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
            _pdfCell.BackgroundColor = BaseColor.Gray;
            _pdfTable.AddCell(_pdfCell);


            _pdfTable.CompleteRow();
            #endregion

            #region Detail table body
            foreach( var oFinancial in _oFinancials)
            {
                _pdfCell = new PdfPCell(new Phrase(oFinancial.FinancialId.ToString(), _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);

                _pdfCell = new PdfPCell(new Phrase(oFinancial.centerName, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(oFinancial.regionCost, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);


                _pdfCell = new PdfPCell(new Phrase(oFinancial.amount, _fontStyle));
                _pdfCell.HorizontalAlignment = Element.ALIGN_LEFT;
                _pdfCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                _pdfCell.BackgroundColor = BaseColor.White;
                _pdfTable.AddCell(_pdfCell);

                _pdfTable.CompleteRow();
            }
            #endregion

        }
    }
  
}
