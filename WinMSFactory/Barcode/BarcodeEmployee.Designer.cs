﻿namespace WinMSFactory.Barcode
{
	partial class BarcodeEmployee
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary> 
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			DevExpress.XtraPrinting.BarCode.Code39ExtendedGenerator code39ExtendedGenerator1 = new DevExpress.XtraPrinting.BarCode.Code39ExtendedGenerator();
			DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters msSqlConnectionParameters1 = new DevExpress.DataAccess.ConnectionParameters.MsSqlConnectionParameters();
			DevExpress.DataAccess.Sql.CustomSqlQuery customSqlQuery1 = new DevExpress.DataAccess.Sql.CustomSqlQuery();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BarcodeEmployee));
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.DetailReport = new DevExpress.XtraReports.UI.DetailReportBand();
			this.Detail1 = new DevExpress.XtraReports.UI.DetailBand();
			this.xrBarCode1 = new DevExpress.XtraReports.UI.XRBarCode();
			this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
			this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
			this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
			this.sqlDataSource1 = new DevExpress.DataAccess.Sql.SqlDataSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// TopMargin
			// 
			this.TopMargin.Dpi = 254F;
			this.TopMargin.HeightF = 200F;
			this.TopMargin.Name = "TopMargin";
			// 
			// BottomMargin
			// 
			this.BottomMargin.Dpi = 254F;
			this.BottomMargin.HeightF = 200.4792F;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// Detail
			// 
			this.Detail.Dpi = 254F;
			this.Detail.HeightF = 0F;
			this.Detail.HierarchyPrintOptions.Indent = 50.8F;
			this.Detail.Name = "Detail";
			// 
			// DetailReport
			// 
			this.DetailReport.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.Detail1});
			this.DetailReport.DataSource = this.sqlDataSource1;
			this.DetailReport.Dpi = 254F;
			this.DetailReport.Level = 0;
			this.DetailReport.Name = "DetailReport";
			// 
			// Detail1
			// 
			this.Detail1.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrBarCode1,
            this.xrTable1});
			this.Detail1.Dpi = 254F;
			this.Detail1.HeightF = 495.375F;
			this.Detail1.HierarchyPrintOptions.Indent = 50.8F;
			this.Detail1.KeepTogether = true;
			this.Detail1.MultiColumn.ColumnCount = 2;
			this.Detail1.MultiColumn.Layout = DevExpress.XtraPrinting.ColumnLayout.AcrossThenDown;
			this.Detail1.MultiColumn.Mode = DevExpress.XtraReports.UI.MultiColumnMode.UseColumnCount;
			this.Detail1.Name = "Detail1";
			// 
			// xrBarCode1
			// 
			this.xrBarCode1.AutoModule = true;
			this.xrBarCode1.Dpi = 254F;
			this.xrBarCode1.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[EMPLOYEE_ID]")});
			this.xrBarCode1.LocationFloat = new DevExpress.Utils.PointFloat(56.10413F, 255.1458F);
			this.xrBarCode1.Module = 5.08F;
			this.xrBarCode1.Name = "xrBarCode1";
			this.xrBarCode1.Padding = new DevExpress.XtraPrinting.PaddingInfo(26, 26, 0, 0, 254F);
			this.xrBarCode1.SizeF = new System.Drawing.SizeF(840.6667F, 190.5F);
			code39ExtendedGenerator1.CalcCheckSum = false;
			code39ExtendedGenerator1.WideNarrowRatio = 3F;
			this.xrBarCode1.Symbology = code39ExtendedGenerator1;
			// 
			// xrTable1
			// 
			this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrTable1.Dpi = 254F;
			this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(50.1041F, 30.41667F);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
			this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
			this.xrTable1.SizeF = new System.Drawing.SizeF(846.6667F, 185.2083F);
			this.xrTable1.StylePriority.UseBorders = false;
			// 
			// xrTableRow1
			// 
			this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2});
			this.xrTableRow1.Dpi = 254F;
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 1D;
			// 
			// xrTableCell1
			// 
			this.xrTableCell1.Dpi = 254F;
			this.xrTableCell1.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrTableCell1.Multiline = true;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.StylePriority.UseFont = false;
			this.xrTableCell1.StylePriority.UseTextAlignment = false;
			this.xrTableCell1.Text = "사원";
			this.xrTableCell1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			this.xrTableCell1.Weight = 1D;
			// 
			// xrTableCell2
			// 
			this.xrTableCell2.Dpi = 254F;
			this.xrTableCell2.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[Query].[EMPLOYEE_NAME]")});
			this.xrTableCell2.Font = new System.Drawing.Font("나눔고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.xrTableCell2.Multiline = true;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.StylePriority.UseFont = false;
			this.xrTableCell2.StylePriority.UseTextAlignment = false;
			this.xrTableCell2.Text = "xrTableCell2";
			this.xrTableCell2.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			this.xrTableCell2.Weight = 2.3333336537278542D;
			// 
			// sqlDataSource1
			// 
			this.sqlDataSource1.ConnectionName = "localhost_team2_Connection";
			msSqlConnectionParameters1.AuthorizationType = DevExpress.DataAccess.ConnectionParameters.MsSqlAuthorizationType.SqlServer;
			msSqlConnectionParameters1.DatabaseName = "team2";
			msSqlConnectionParameters1.ServerName = "whyfi8888.ddns.net,11433";
			this.sqlDataSource1.ConnectionParameters = msSqlConnectionParameters1;
			this.sqlDataSource1.Name = "sqlDataSource1";
			customSqlQuery1.Name = "Query";
			customSqlQuery1.Sql = "SELECT UPPER(EMPLOYEE_ID) + \'_\' BAR_EMP, EMPLOYEE_ID, EMPLOYEE_NAME\r\nFROM TBL_EMP" +
    "LOYEE";
			this.sqlDataSource1.Queries.AddRange(new DevExpress.DataAccess.Sql.SqlQuery[] {
            customSqlQuery1});
			this.sqlDataSource1.ResultSchemaSerializable = resources.GetString("sqlDataSource1.ResultSchemaSerializable");
			// 
			// BarcodeEmployee
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.DetailReport});
			this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.sqlDataSource1});
			this.DataMember = "Query";
			this.DataSource = this.sqlDataSource1;
			this.Dpi = 254F;
			this.Font = new System.Drawing.Font("Arial", 9.75F);
			this.Margins = new System.Drawing.Printing.Margins(100, 100, 200, 200);
			this.PageHeight = 2970;
			this.PageWidth = 2100;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
			this.SnapGridSize = 25F;
			this.Version = "20.1";
			((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.DetailReportBand DetailReport;
		private DevExpress.XtraReports.UI.DetailBand Detail1;
		private DevExpress.XtraReports.UI.XRBarCode xrBarCode1;
		private DevExpress.XtraReports.UI.XRTable xrTable1;
		private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
		private DevExpress.DataAccess.Sql.SqlDataSource sqlDataSource1;
	}
}
