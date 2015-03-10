using PersonRepository.Interface;
using System.Windows;
using PersonRepository.Service;
using PersonRepository.CSV;
using PersonRepository.SQL;

namespace PeopleViewer
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ServiceFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FecthData("Service");
        }

        private void CSVFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FecthData("CSV");
        }

        private void SQLFetchButton_Click(object sender, RoutedEventArgs e)
        {
            FecthData("SQL");
        }

        private void FecthData(string repositoryType)
        {
            ClearListBox();
            IPersonRepository repo = RepositoryFactory.GetRepository(repositoryType);
            var people = repo.GetPeople();
            foreach (var p in people)
            {
                PersonListBox.Items.Add(p);
            }
            ShowRepositoryType(repo);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            ClearListBox();
        }

        private void ClearListBox()
        {
            PersonListBox.Items.Clear();
        }

        private void ShowRepositoryType(IPersonRepository repository)
        {
            MessageBox.Show(string.Format("Repository Type:\n{0}",
                repository.GetType().ToString()));
        }
    }
}
