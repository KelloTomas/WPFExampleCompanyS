using Kros.Data;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Kros.Pages
{
	/// <summary>
	/// Interaction logic for Page1.xaml
	/// </summary>
	public partial class DetailPage : Page
	{
		private DBLayer _db;
		private MainWindow _mainWindow;
		public TableBase SelectedMain { get; set; }
		public TableBase SelectedRecord { get; set; }
		public Person SelectedEmployee { get; set; }
		public string SubTableName
		{
			get
			{
				switch (SelectedMain)
				{
					case Firma f:
						return "Divizie";
					case Divizia d:
						return "Projekty";
					case Projekt p:
						return "Oddelenia";
					case Oddelenie o:
						return "--------";
					default:
						throw new ArgumentOutOfRangeException();
				}

			}
		}
		public string TableName
		{
			get
			{
				switch (SelectedMain)
				{
					case Firma f:
						return "Firma";
					case Divizia d:
						return $"Divizia firmy - {d.ParentTable.Name}";
					case Projekt p:
						return $"Projekt divizie - {p.ParentTable.Name}";
					case Oddelenie o:
						return $"Oddelenie projektu - {o.ParentTable.Name}";
					default:
						throw new ArgumentOutOfRangeException();
				}

			}
		}
		public DetailPage()
		{
			InitializeComponent();
			DataContext = this;
		}
		public void MyInit(DBLayer db, TableBase table, MainWindow mainWindow)
		{
			_db = db;
			BtnAddSubTable.Visibility = Visibility.Visible;
			BtnBack.Visibility = Visibility.Visible;

			switch (table)
			{
				case Firma firma:
					SelectedMain = _db.Firmy.Include("SubTable").Include("Employee").Single(f => f.Id == table.Id);
					BtnBack.Visibility = Visibility.Collapsed;
					break;
				case Divizia d:
					SelectedMain = _db.Divizie.Include("ParentTable").Include("SubTable").Include("Employee").Single(f => f.Id == table.Id);
					break;
				case Projekt p:
					SelectedMain = _db.Projekty.Include("ParentTable").Include("SubTable").Include("Employee").Single(f => f.Id == table.Id);
					break;
				case Oddelenie o:
					SelectedMain = _db.Oddelenia.Include("ParentTable").Include("Employee").Single(f => f.Id == table.Id);
					BtnAddSubTable.Visibility = Visibility.Collapsed;
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			_mainWindow = mainWindow;
		}

		private void Btn_SubTable_Add(object sender, RoutedEventArgs e)
		{
			TableBase table;
			switch (SelectedMain)
			{
				case Firma f:
					table = new Divizia();
					f.SubTable.Add((Divizia)table);
					break;
				case Divizia d:
					table = new Projekt();
					d.SubTable.Add((Projekt)table);
					break;
				case Projekt p:
					table = new Oddelenie();
					p.SubTable.Add((Oddelenie)table);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			_db.SaveChanges();
			_mainWindow.Show(table);
		}
		private void Btn_Employee_Add(object sender, RoutedEventArgs e)
		{
			Person person;
			switch (SelectedMain)
			{
				case Firma f:
					person = new PersonF() { PartOf = f };
					f.Employee.Add((PersonF)person);
					break;
				case Divizia d:
					person = new PersonD() { PartOf = d };
					d.Employee.Add((PersonD)person);
					break;
				case Projekt p:
					person = new PersonP() { PartOf = p };
					p.Employee.Add((PersonP)person);
					break;
				case Oddelenie o:
					person = new PersonO() { PartOf = o };
					o.Employee.Add((PersonO)person);
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
			_db.SaveChanges();
			_mainWindow.Show(person);
		}

		private void DataGrid_DoubleClick_SubTable(object sender, MouseButtonEventArgs e)
		{
			if (SelectedRecord != null)
				_mainWindow.Show(SelectedRecord);
		}

		private void DataGrid_DoubleClick_Employee(object sender, MouseButtonEventArgs e)
		{
			if (SelectedEmployee != null)
				_mainWindow.Show(SelectedEmployee);
		}

		private void BtnClick_Remove(object sender, RoutedEventArgs e)
		{
			_db.Remove(SelectedMain);
			_mainWindow.Close(true);
		}

		private void BtnClick_Back(object sender, RoutedEventArgs e)
		{
			switch (SelectedMain)
			{
				case Divizia d:
					_mainWindow.Show(d.ParentTable);
					break;
				case Projekt p:
					_mainWindow.Show(p.ParentTable);
					break;
				case Oddelenie o:
					_mainWindow.Show(o.ParentTable);
					break;
			}
		}
	}
}
