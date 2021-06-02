using Panuon.UI.Silver;
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

namespace WindowsFormsWPFUI.Controls
{
    /// <summary>
    /// ComboBoxView.xaml 的交互逻辑
    /// </summary>
    public partial class ComboBoxView : UserControl
    {
        public ComboBoxView()
        {
            InitializeComponent();
            Loaded += ButtonView_Loaded;
        }
        private void ButtonView_Loaded(object sender, RoutedEventArgs e)
        {
            UpdateTemplate();
        }
        private void CmbCustom_SearchTextChanged(object sender, Panuon.UI.Silver.Core.SearchTextChangedEventArgs e)
        {
            if (!IsLoaded)
                return;

            foreach (ComboBoxItem item in CmbCustom.Items)
            {
                item.Visibility = item.Content.ToString().Contains(e.Text) ? Visibility.Visible : Visibility.Collapsed;
            }
        }
        #region Function
        private void UpdateTemplate()
        {
            var color = Color.FromArgb(255, 128, 128, 255);
            ComboBoxHelper.SetCornerRadius(CmbCustom, new CornerRadius(30));
            ComboBoxHelper.SetIsSearchTextBoxVisible(CmbCustom, true);
            ComboBoxHelper.SetWatermark(CmbCustom, "请输入用户名");
            ComboBoxHelper.SetIcon(CmbCustom, "\uf11c");
            ComboBoxHelper.SetSelectedBackground(CmbCustom, new Color() { A = 50, R = color.R, G = color.G, B = color.B }.ToBrush());
            ComboBoxHelper.SetHoverBackground(CmbCustom, new Color() { A = 30, R = color.R, G = color.G, B = color.B }.ToBrush());
        }
        #endregion
    }
}
