using BookMaster.Model;
using System.Windows;

namespace BookMaster
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Контекст данных, который хранит в себе все таблицы БД.
        public static BookmasterEntities context = new BookmasterEntities();
    }
}
