using BookMaster.AppData;
using BookMaster.Model;
using BookMaster.View.Windows;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace BookMaster.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для BrowseCataLogPage.xaml
    /// </summary>
    public partial class BrowseCataLogPage : Page
    {
        List<Book> _books = App.context.Book.ToList();
        PaginationService _bookPagination;
        public BrowseCataLogPage()
        {
            InitializeComponent();
        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            //Загружаем данные из таблицы BookAuthor в список ListView.
            BookAuthorLv.ItemsSource = App.context.BookAuthor.ToList();
        }
        private void SearchBtn_Click(object sender, RoutedEventArgs e)
        {
            SearchResultGrid.Visibility = Visibility.Visible;

            if (string.IsNullOrEmpty(SearchbyBookTitleTb.Text) &&
                string.IsNullOrEmpty(SearchbyAuthorNameTb.Text) &&
                string.IsNullOrEmpty(SearchbyBookSubjectTb.Text))
            {
                _bookPagination = new PaginationService(_books);
            }
            else
            {
                List<Book> searchResults = _books.Where(book => book.Title.ToLower().Contains(SearchbyBookTitleTb.Text.ToLower()) && book.Authors.ToLower().Contains(SearchbyAuthorNameTb.Text.ToLower())).ToList();

                //Реализовывем алгоритм поиска
                _bookPagination = new PaginationService(searchResults);
            }
            // Загружаем данные из таблице BookAuthor в список ListView
            BookAuthorLv.ItemsSource = _bookPagination.CurrentPageOfBooks;
            TotalPagesTbl.DataContext = TotalBooksTbl.DataContext = _bookPagination;
            _bookPagination.UpdatePaginationButtons(PreviousBooksBtn, NextBookBtn);
            CurrentPageTb.Text = _bookPagination.CurrentPageNumber.ToString();
        }

        private void PreviousBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _bookPagination.PreviousPage();
            _bookPagination.UpdatePaginationButtons(PreviousBooksBtn, NextBookBtn);
        }

        private void CurrentPageTb_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (int.TryParse(CurrentPageTb.Text, out int pageNumber) && pageNumber >= 1 && pageNumber <= _bookPagination.TotalPages)
            {
                BookAuthorLv.ItemsSource = _bookPagination.SetCurrentPage(pageNumber);
            }
        }

        private void NextBookBtn_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorLv.ItemsSource = _bookPagination.NextPage();
            _bookPagination.UpdatePaginationButtons(PreviousBooksBtn, NextBookBtn);
            CurrentPageTb.Text = _bookPagination.CurrentPageNumber.ToString();
        }

        private void PreviousCoverBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void NextCoverBtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BookAuthorLv_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Book selectedBook = BookAuthorLv.SelectedItem as Book;

            BookDetailGrid.DataContext = selectedBook;
        }

        private void AuthorDetailsHl_Click(object sender, RoutedEventArgs e)
        {
            BookAuthorsDetailsWindow bookAuthorsDetailsWindow = new BookAuthorsDetailsWindow();
            bookAuthorsDetailsWindow.ShowDialog();
        }

        private void NextBookBtn_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
