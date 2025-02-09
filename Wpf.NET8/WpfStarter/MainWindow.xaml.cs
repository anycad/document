﻿using AnyCAD.Foundation;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace WpfStarter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ObservableCollection<TreeModel> mModel;
        public MainWindow()
        {
            InitializeComponent();
            mModel = TreeModel.GetData();
            mTreeCtrl.ItemsSource = mModel;
            var item = mModel.First().Children.First();           
            TreeModel.ExpandParentNodes(item);
            item.IsSelected = true;
            
        }

        private void mRenderCtrl_ViewerReady()
        {
            var shape = ShapeBuilder.MakeCylinder(GP.XOY(), 10, 20, 0);
            mRenderCtrl.ShowShape(shape, ColorTable.AliceBlue);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            PrevewWindow window = new PrevewWindow();
            window.Owner = this;
            window.Show();
        }
    }
}
