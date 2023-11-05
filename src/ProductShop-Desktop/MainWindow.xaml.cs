using Integrated.ServiceLayer.Brands;
using Integrated.ServiceLayer.Brands.Concrete;
using Integrated.ServiceLayer.Categories;
using Integrated.ServiceLayer.Categories.Concrete;
using Integrated.ServiceLayer.Products;
using Integrated.ServiceLayer.Products.Concrete;
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
using ViewModels.Products;

namespace ProductShop_Desktop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductGetViewModel productGetViewModels = new ProductGetViewModel();
        private readonly IProductService _productService;
        private readonly IBrandService _brandService;
        private readonly ICategoryService _categoryService;
        public MainWindow()
        {
            InitializeComponent();
            this._productService = new ProductService();
            this._brandService = new BrandService();
            this._categoryService = new CategoryService();
            refresh();
        }
        private async void refresh()
        {
            dgProducts.Items.Clear();
            
            var products = await _productService.GetAllViewAsync(1);
            var brands = await _brandService.GetAllAsync(1);
            var categories = await _categoryService.GetAllAsync(1);
            tbMin.Text = "2000";
            tbMax.Text = "7500000";
            for (int i = 0; i < brands.Count; i++)
            {
                cbBrand.Items.Add(brands[i].Name);
            }

            for (int i = 0; i < categories.Count; i++)
            {
                cbCategory.Items.Add(categories[i].Name);
            }

            for (int i = 0; i < products.Count; i++)
            {
                ProductGetViewModel productGetViewModel = new ProductGetViewModel();
                productGetViewModel.Id = products[i].Id;
                productGetViewModel.BrandName = products[i].BrandName;
                productGetViewModel.CategoryName = products[i].CategoryName;
                productGetViewModel.Name = products[i].Name;
                productGetViewModel.UnitPrice = products[i].UnitPrice;
                productGetViewModel.Description = products[i].Description;
                productGetViewModel.CreatedAt = products[i].CreatedAt;
                
                dgProducts.Items.Add(productGetViewModel);
            }
        }


        private async void apply_Click(object sender, RoutedEventArgs e)
        {
            dgProducts.Items.Clear();
            var products = await _productService.GetAllViewAsync(1);
            var brands = await _brandService.GetAllAsync(1);
            var categories = await _categoryService.GetAllAsync(1);

            tbSearch.Text = "";
            
            List<ProductGetViewModel> productGetViewModels = new List<ProductGetViewModel>();

            if (int.Parse(tbMin.Text) <= int.Parse(tbMax.Text) & dpBolshalnishVaqt.SelectedDate.Value <= dpTugashVaqt.SelectedDate.Value &
                cbBrand.SelectionBoxItem.ToString() != "Brand" & cbCategory.SelectionBoxItem.ToString() != "Category")
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if ((products[i].UnitPrice >= int.Parse(tbMin.Text) & products[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products[i].CategoryName == cbCategory.SelectedItem.ToString()) &
                        (products[i].BrandName == cbBrand.SelectedItem.ToString()) &
                        (products[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products[i]);
                    }
                }
            }

            else if (int.Parse(tbMin.Text) <= int.Parse(tbMax.Text) & dpBolshalnishVaqt.SelectedDate.Value <= dpTugashVaqt.SelectedDate.Value &
                cbBrand.SelectionBoxItem.ToString() != "Brand" & cbCategory.SelectionBoxItem.ToString() == "Category")
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if ((products[i].UnitPrice >= int.Parse(tbMin.Text) & products[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products[i].BrandName == cbBrand.SelectedItem.ToString()) &
                        (products[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products[i]);
                    }
                }
            }

            else if (int.Parse(tbMin.Text) <= int.Parse(tbMax.Text) & dpBolshalnishVaqt.SelectedDate.Value <= dpTugashVaqt.SelectedDate.Value &
                cbBrand.SelectionBoxItem.ToString() == "Brand" & cbCategory.SelectionBoxItem.ToString() != "Category")
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if ((products[i].UnitPrice >= int.Parse(tbMin.Text) & products[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products[i].CategoryName == cbCategory.SelectedItem.ToString()) &
                        (products[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products[i]);
                    }
                }
            }
            else if (int.Parse(tbMin.Text) <= int.Parse(tbMax.Text) & dpBolshalnishVaqt.SelectedDate.Value <= dpTugashVaqt.SelectedDate.Value &
                cbBrand.SelectionBoxItem.ToString() == "Brand" & cbCategory.SelectionBoxItem.ToString() == "Category")
            {
                for (int i = 0; i < products.Count; i++)
                {
                    if ((products[i].UnitPrice >= int.Parse(tbMin.Text) & products[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products[i]);
                    }
                }
            }

            //List<ProductGetViewModel> productGetViewModels2 = new List<ProductGetViewModel>();
            //for (int i = 0; i < productGetViewModels.Count; i++)
            //{
            //    if (productGetViewModels[i].CategoryName==cbCategory.SelectedItem.ToString() & cbCategory.SelectedItem.ToString()!="Category")
            //    {
            //        productGetViewModels2.Add(productGetViewModels[i]);
            //    }
            //}

            //List<ProductGetViewModel> productGetViewModels3 = new List<ProductGetViewModel>();
            //for (int i = 0; i < productGetViewModels2.Count; i++)
            //{
            //    if (productGetViewModels2[i].BrandName == cbBrand.SelectedItem.ToString() & cbBrand.SelectedItem.ToString() != "Brand")
            //    {
            //        productGetViewModels3.Add(productGetViewModels2[i]);
            //    }
            //}

            //List<ProductGetViewModel> productGetViewModels4 = new List<ProductGetViewModel>();
            //for (int i = 0; i < productGetViewModels3.Count; i++)
            //{
            //    if (productGetViewModels3[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & productGetViewModels3[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value)
            //    {
            //        productGetViewModels4.Add(productGetViewModels3[i]);
            //    }
            //}
        }

        private async void search_Click(object sender, RoutedEventArgs e)
        {

            dgProducts.Items.Clear();
            cbBrand.Items.Clear();
            cbCategory.Items.Clear();

            var products = await _productService.GetAllViewAsync(1);

            var brands = await _brandService.GetAllAsync(1);
            var categories = await _categoryService.GetAllAsync(1);
            tbMin.Text = "2000";
            tbMax.Text = "7500000";
            cbBrand.Items.Add("Brand");
            cbBrand.SelectedIndex = 0;
            cbCategory.Items.Add("Category");
            cbCategory.SelectedIndex = 0;
            //dpBolshalnishVaqt.SelectedDate("12.31.2023");
            for (int i = 0; i < brands.Count; i++)
            {
                cbBrand.Items.Add(brands[i].Name);
            }


            for (int i = 0; i < categories.Count; i++)
            {
                cbCategory.Items.Add(categories[i].Name);
            }

            for (int i = 0; i < products.Count; i++)
            {
                string mainString = (products[i].Id.ToString() + " " + products[i].Name + " " + products[i].CategoryName + " " + products[i].BrandName).ToLower();
                if (mainString.Contains(tbSearch.Text.ToLower()))
                {
                    dgProducts.Items.Add(products[i]);
                }
            }
        }
    }
}
