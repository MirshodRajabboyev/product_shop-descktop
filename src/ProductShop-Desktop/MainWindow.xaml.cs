﻿using Integrated.ServiceLayer.Brands;
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

            for (int i = 0; i < products.productGetViewModels.Count; i++)
            {
                ProductGetViewModel productGetViewModel = new ProductGetViewModel();
                productGetViewModel.Id = products.productGetViewModels[i].Id;
                productGetViewModel.BrandName = products.productGetViewModels[i].BrandName;
                productGetViewModel.CategoryName = products.productGetViewModels[i].CategoryName;
                productGetViewModel.Name = products.productGetViewModels[i].Name;
                productGetViewModel.UnitPrice = products.productGetViewModels[i].UnitPrice;
                productGetViewModel.Description = products.productGetViewModels[i].Description;
                productGetViewModel.CreatedAt = products.productGetViewModels[i].CreatedAt;
                
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
                for (int i = 0; i < products.productGetViewModels.Count; i++)
                {
                    if ((products.productGetViewModels[i].UnitPrice >= int.Parse(tbMin.Text) & products.productGetViewModels[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products.productGetViewModels[i].CategoryName == cbCategory.SelectedItem.ToString()) &
                        (products.productGetViewModels[i].BrandName == cbBrand.SelectedItem.ToString()) &
                        (products.productGetViewModels[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products.productGetViewModels[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products.productGetViewModels[i]);
                    }
                }
            }

            else if (int.Parse(tbMin.Text) <= int.Parse(tbMax.Text) & dpBolshalnishVaqt.SelectedDate.Value <= dpTugashVaqt.SelectedDate.Value &
                cbBrand.SelectionBoxItem.ToString() != "Brand" & cbCategory.SelectionBoxItem.ToString() == "Category")
            {
                for (int i = 0; i < products.productGetViewModels.Count; i++)
                {
                    if ((products.productGetViewModels[i].UnitPrice >= int.Parse(tbMin.Text) & products.productGetViewModels[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products.productGetViewModels[i].BrandName == cbBrand.SelectedItem.ToString()) &
                        (products.productGetViewModels[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products.productGetViewModels[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products.productGetViewModels[i]);
                    }
                }
            }

            else if (int.Parse(tbMin.Text) <= int.Parse(tbMax.Text) & dpBolshalnishVaqt.SelectedDate.Value <= dpTugashVaqt.SelectedDate.Value &
                cbBrand.SelectionBoxItem.ToString() == "Brand" & cbCategory.SelectionBoxItem.ToString() != "Category")
            {
                for (int i = 0; i < products.productGetViewModels.Count; i++)
                {
                    if ((products.productGetViewModels[i].UnitPrice >= int.Parse(tbMin.Text) & products.productGetViewModels[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products.productGetViewModels[i].CategoryName == cbCategory.SelectedItem.ToString()) &
                        (products.productGetViewModels[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products.productGetViewModels[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products.productGetViewModels[i]);
                    }
                }
            }
            else if (int.Parse(tbMin.Text) <= int.Parse(tbMax.Text) & dpBolshalnishVaqt.SelectedDate.Value <= dpTugashVaqt.SelectedDate.Value &
                cbBrand.SelectionBoxItem.ToString() == "Brand" & cbCategory.SelectionBoxItem.ToString() == "Category")
            {
                for (int i = 0; i < products.productGetViewModels.Count; i++)
                {
                    if ((products.productGetViewModels[i].UnitPrice >= int.Parse(tbMin.Text) & products.productGetViewModels[i].UnitPrice <= int.Parse(tbMax.Text)) &
                        (products.productGetViewModels[i].UpdatedAt >= dpBolshalnishVaqt.SelectedDate.Value & products.productGetViewModels[i].UpdatedAt <= dpTugashVaqt.SelectedDate.Value))
                    {
                        dgProducts.Items.Add(products.productGetViewModels[i]);
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

            for (int i = 0; i < products.productGetViewModels.Count; i++)
            {
                string mainString = (products.productGetViewModels[i].Id.ToString() + " " + products.productGetViewModels[i].Name + " " + products.productGetViewModels[i].CategoryName + " " + products.productGetViewModels[i].BrandName).ToLower();
                if (mainString.Contains(tbSearch.Text.ToLower()))
                {
                    dgProducts.Items.Add(products.productGetViewModels[i]);
                }
            }
        }


        public async Task refreshAsync()
        {
            //await RefreshWithLike();


            dgProducts.Items.Clear();
            int page = int.Parse(tbPage.Text);
            var result = await _productService.GetAllViewAsync(page);
            var pagination = result.pageData;
            if (result.pageData.TotalPages < 2)
            {
                tbPage.Visibility = Visibility.Collapsed;
                tbTotalPage.Visibility = Visibility.Collapsed;
                tbbackslash.Visibility = Visibility.Collapsed;
                btnNext.Visibility = Visibility.Collapsed;
                btnPervouce.Visibility = Visibility.Collapsed;
            }
            tbTotalPage.Text = result.pageData.TotalPages.ToString();
            var products = result.productGetViewModels;
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
        private async void PreviousPage_Click(object sender, RoutedEventArgs e)
        {
            
            btnPervouce.IsEnabled = false;
            int page = int.Parse(tbPage.Text);
            if (page > 1)
            {
                page -= 1;
                tbPage.Text = page.ToString();
                await refreshAsync();
            }
            btnPervouce.IsEnabled = true;
        }

        private void NextPage_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
