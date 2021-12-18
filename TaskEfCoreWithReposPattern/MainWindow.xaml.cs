using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using TaskEfCoreWithReposPattern.Context;
using TaskEfCoreWithReposPattern.DataAccess.Abstract;
using TaskEfCoreWithReposPattern.DataAccess.Concrete;
using TaskEfCoreWithReposPattern.Models;

namespace TaskEfCoreWithReposPattern
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IGenericRepository<Product> _reposProduct;
        IGenericRepository<Category> _reposCategory;
        public MainWindow()
        {
            InitializeComponent();
            _reposCategory = new GenericRepository<Category>();
            _reposProduct = new GenericRepository<Product>();
            //Add();
            var categories = _reposCategory.GetAll().Include(c => c.Products).ToList();
            dataGridCategory.ItemsSource = categories;
            
        }

        private void Add()
        {
            _reposCategory.GetAll().Include("Products");
            Product p1 = new Product() { Name = "Acer", UnitPrice = 1599.99m };
            Product p2 = new Product() { Name = "Iphone 12", UnitPrice = 3499.99m };
            Product p3 = new Product() { Name = "Galaxy S10", UnitPrice = 2899.99m };
            Product p4 = new Product() { Name = "Asus", UnitPrice = 2599.99m };
            _reposProduct.Insert(p1);
            _reposProduct.Insert(p2);
            _reposProduct.Insert(p3);
            _reposProduct.Insert(p4);

            Category c1 = new Category() { Name = "Notebook" };
            Category c2 = new Category() { Name = "Phone" };
            _reposCategory.Insert(c1);
            _reposCategory.Insert(c2);

            c1.Products.Add(p1);
            c1.Products.Add(p4);
            c2.Products.Add(p2);
            c2.Products.Add(p3);

            _reposProduct.SaveChanges();
            _reposCategory.SaveChanges();
        }

        private void dataGridCategory_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
                var products = _reposProduct.Query(p => p.Category.Name == (dataGridCategory.SelectedItem as Category).Name).ToList();
                dataGridProduct.ItemsSource = products;
        }
    }
}
