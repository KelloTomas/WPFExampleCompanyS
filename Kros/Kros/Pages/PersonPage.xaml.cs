using Kros.Data;
using System.Linq;
using System.Windows.Controls;

namespace Kros.Pages
{
	/// <summary>
	/// Interaction logic for PersonPage.xaml
	/// </summary>
	public partial class PersonPage : Page
	{
		public Person Selected { get; set; }
		private MainWindow _mainWindow;
		private DBLayer _db;
		public PersonPage()
		{
			InitializeComponent();
			DataContext = this;
		}
		public void MyInit(DBLayer db, Person person, MainWindow mainWindow)
		{
			_mainWindow = mainWindow;
			_db = db;
			switch (person)
			{
				case PersonF f:
					Selected = _db.PeopleF.Include("PartOf").Single(p => p.Id == f.Id);
					break;
				case PersonD f:
					Selected = _db.PeopleD.Include("PartOf").Single(p => p.Id == f.Id);
					break;
				case PersonP f:
					Selected = _db.PeopleP.Include("PartOf").Single(p => p.Id == f.Id);
					break;
				case PersonO f:
					Selected = _db.PeopleO.Include("PartOf").Single(p => p.Id == f.Id);
					break;
				default:
					throw new System.ArgumentOutOfRangeException();
			}
		}

		private void BtnClic_back(object sender, System.Windows.RoutedEventArgs e)
		{
			switch (Selected)
			{
				case PersonF f:
					_mainWindow.Show(f.PartOf);
					break;
				case PersonD f:
					_mainWindow.Show(f.PartOf);
					break;
				case PersonP f:
					_mainWindow.Show(f.PartOf);
					break;
				case PersonO f:
					_mainWindow.Show(f.PartOf);
					break;
				default:
					throw new System.ArgumentOutOfRangeException();
			}
		}

		private void BtnClick_Remove(object sender, System.Windows.RoutedEventArgs e)
		{
			_db.Remove(Selected);
			_mainWindow.Close(true);
		}
	}
}
