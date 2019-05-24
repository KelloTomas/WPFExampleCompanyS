using Kros.Data;
using Kros.Pages;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace Kros
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		private DBLayer _db;

		public MainWindow()
		{
			InitializeComponent();
			DataContext = this;
			_db = new DBLayer();
		}

		private void MenuButtonClick(object sender, RoutedEventArgs e)
		{
			TablePage page = new TablePage();
			switch (((Button)e.Source).Name)
			{
				case "Firmy":
					page.MyInit(_db, _db.Firmy.ToList().Cast<TableBase>().ToList(), TableCategory.Firma, this);
					SetPage(page);
					break;
				case "Divizie":
					page.MyInit(_db, _db.Divizie.ToList().Cast<TableBase>().ToList(), TableCategory.Divizia, this);
					SetPage(page);
					break;
				case "Projekty":
					page.MyInit(_db, _db.Projekty.ToList().Cast<TableBase>().ToList(), TableCategory.Projekt, this);
					SetPage(page);
					break;
				case "Oddelenia":
					page.MyInit(_db, _db.Oddelenia.ToList().Cast<TableBase>().ToList(), TableCategory.Oddelenie, this);
					SetPage(page);
					break;
				case "Zatvorit":
					this.Close();
					break;
				default:
					throw new ArgumentOutOfRangeException();
			}
		}
		public void SetPage(Page page)
		{
			_db.SaveChanges();
			MyPage.Content = page;
		}
		private void Btn_Click_AddFirma(object sender, System.Windows.RoutedEventArgs e)
		{
			Firma firma = new Firma();
			_db.Add(firma);
			_db.SaveChanges();
			Show(firma);
		}

		public void Show(TableBase table)
		{
			DetailPage detailPage = new DetailPage();
			detailPage.MyInit(_db, table, this);
			SetPage(detailPage);
		}
		public void Show(Person person)
		{
			PersonPage detailPage = new PersonPage();
			detailPage.MyInit(_db, person, this);
			SetPage(detailPage);
		}
		public void Close(bool Close)
		{
			if (Close)
				SetPage(null);
		}
	}
}
