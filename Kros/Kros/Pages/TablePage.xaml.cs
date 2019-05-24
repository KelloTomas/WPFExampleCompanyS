using Kros.Data;
using System;
using System.Collections.Generic;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kros.Pages
{
	/// <summary>
	/// Interaction logic for TablePage.xaml
	/// </summary>
	public partial class TablePage : Page
	{
		private DBLayer _db;
		private MainWindow _mainWindow;
		private TableCategory _tableName;
		public List<TableBase> Tables { get; set; }
		public TableBase Table { get; set; }
		public string TableName
		{
			get
			{
				switch (_tableName)
				{
					case TableCategory.Firma:
						return "Firmy";
					case TableCategory.Divizia:
						return "Divizie";
					case TableCategory.Projekt:
						return "Projekty";
					case TableCategory.Oddelenie:
						return "Oddelenia";
					default:
						throw new ArgumentOutOfRangeException();
				}

			}
		}

		public TablePage()
		{
			InitializeComponent();
			DataContext = this;
		}

		public void MyInit(DBLayer db, List<TableBase> tables, TableCategory tableName, MainWindow mainWindow)
		{
			_db = db;
			Tables = tables;
			_tableName = tableName;
			_mainWindow = mainWindow;
		}

		private void DataGrid_MouseDoubleClick(object sender, MouseButtonEventArgs e)
		{
			if (Table != null)
			{
				DetailPage detailPage = new DetailPage();
				detailPage.MyInit(_db, Table, _mainWindow);
				_mainWindow.SetPage(detailPage);
			}
		}

	}
}
