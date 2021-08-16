using Panuon.UI.Silver.Core;
using System;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Panuon.UI.Silver
{
    public class Pagination : Control
    {
        static Pagination()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(Pagination), new FrameworkPropertyMetadata(typeof(Pagination)));
        }

        public Pagination()
        {
            if (TotalIndex == 0)
                TotalIndex = 1;
            if (CurrentIndex == 0)
                CurrentIndex = 1;
        }

        #region Routed Event
        public static readonly RoutedEvent CurrentIndexChangedEvent = EventManager.RegisterRoutedEvent("CurrentIndexChanged", RoutingStrategy.Bubble, typeof(CurrentIndexChangedEventHandler), typeof(Pagination));
        public event CurrentIndexChangedEventHandler CurrentIndexChanged
        {
            add { AddHandler(CurrentIndexChangedEvent, value); }
            remove { RemoveHandler(CurrentIndexChangedEvent, value); }
        }
        void RaiseCurrentIndexChanged(int index)
        {
            var arg = new CurrentIndexChangedEventArgs(index, CurrentIndexChangedEvent);
            RaiseEvent(arg);
        }
        #endregion

        #region Property
        /// <summary>
        /// 使用后缀
        /// </summary>
        public bool UseSuffix
        {
            get { return (bool)GetValue(UseSuffixProperty); }
            set { SetValue(UseSuffixProperty, value); }
        }

        public static readonly DependencyProperty UseSuffixProperty =
            DependencyProperty.Register("UseSuffix", typeof(bool), typeof(Pagination), new PropertyMetadata(false));

        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix
        {
            get { return (string)GetValue(PrefixProperty); }
            set { SetValue(PrefixProperty, value); }
        }

        public static readonly DependencyProperty PrefixProperty =
            DependencyProperty.Register("Prefix", typeof(string), typeof(Pagination), new PropertyMetadata(null));
        /// <summary>
        /// 后缀
        /// </summary>
        public string Suffix
        {
            get { return (string)GetValue(SuffixProperty); }
            set { SetValue(SuffixProperty, value); }
        }

        public static readonly DependencyProperty SuffixProperty =
            DependencyProperty.Register("Suffix", typeof(string), typeof(Pagination), new PropertyMetadata(null));


        /// <summary>
        /// Current index.
        /// </summary>
        public int CurrentIndex
        {
            get { return (int)GetValue(CurrentIndexProperty); }
            set { SetValue(CurrentIndexProperty, value); }
        }

        public static readonly DependencyProperty CurrentIndexProperty =
            DependencyProperty.Register("CurrentIndex", typeof(int), typeof(Pagination), new PropertyMetadata(OnCurrentIndexChanged));


        /// <summary>
        /// Total index.
        /// </summary>
        public int TotalIndex
        {
            get { return (int)GetValue(TotalIndexProperty); }
            set { SetValue(TotalIndexProperty, value); }
        }

        public static readonly DependencyProperty TotalIndexProperty =
            DependencyProperty.Register("TotalIndex", typeof(int), typeof(Pagination), new PropertyMetadata(OnTotalIndexChanged));


        /// <summary>
        /// Theme brush.
        /// </summary>
        public Brush HoverBrush
        {
            get { return (Brush)GetValue(HoverBrushProperty); }
            set { SetValue(HoverBrushProperty, value); }
        }

        public static readonly DependencyProperty HoverBrushProperty =
            DependencyProperty.Register("HoverBrush", typeof(Brush), typeof(Pagination));

        /// <summary>
        /// Pagination style.
        /// </summary>
        public PaginationStyle PaginationStyle
        {
            get { return (PaginationStyle)GetValue(PaginationStyleProperty); }
            set { SetValue(PaginationStyleProperty, value); }
        }

        public static readonly DependencyProperty PaginationStyleProperty =
            DependencyProperty.Register("PaginationStyle", typeof(PaginationStyle), typeof(Pagination), new PropertyMetadata(PaginationStyle.Standard));

        /// <summary>
        /// Spacing
        /// </summary>
        public double Spacing
        {
            get { return (double)GetValue(SpacingProperty); }
            set { SetValue(SpacingProperty, value); }
        }

        public static readonly DependencyProperty SpacingProperty =
            DependencyProperty.Register("Spacing", typeof(double), typeof(Pagination));


        /// <summary>
        /// CornerRadius
        /// </summary>
        public CornerRadius CornerRadius
        {
            get { return (CornerRadius)GetValue(CornerRadiusProperty); }
            set { SetValue(CornerRadiusProperty, value); }
        }

        public static readonly DependencyProperty CornerRadiusProperty =
            DependencyProperty.Register("CornerRadius", typeof(CornerRadius), typeof(Pagination));
        #endregion

        #region Internal Property
        internal ObservableCollection<PaginationItem> PaginationItems
        {
            get { return (ObservableCollection<PaginationItem>)GetValue(PaginationItemsProperty); }
            set { SetValue(PaginationItemsProperty, value); }
        }

        internal static readonly DependencyProperty PaginationItemsProperty =
            DependencyProperty.Register("PaginationItems", typeof(ObservableCollection<PaginationItem>), typeof(Pagination));

        internal ICommand PreviousCommand
        {
            get { return (ICommand)GetValue(PreviousCommandProperty); }
            set { SetValue(PreviousCommandProperty, value); }
        }

        internal static readonly DependencyProperty PreviousCommandProperty =
            DependencyProperty.Register("PreviousCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new PreviousCommand()));



        internal ICommand NextCommand
        {
            get { return (ICommand)GetValue(NextCommandProperty); }
            set { SetValue(NextCommandProperty, value); }
        }

        internal static readonly DependencyProperty NextCommandProperty =
            DependencyProperty.Register("NextCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new NextCommand()));



        internal ICommand IndexCommand
        {
            get { return (ICommand)GetValue(IndexCommandProperty); }
            set { SetValue(IndexCommandProperty, value); }
        }

        internal static readonly DependencyProperty IndexCommandProperty =
            DependencyProperty.Register("IndexCommand", typeof(ICommand), typeof(Pagination), new PropertyMetadata(new IndexCommand()));


        #endregion

        #region EventHandler
        private static void OnCurrentIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as Pagination;

            if (pagination.CurrentIndex > pagination.TotalIndex)
            {
                pagination.CurrentIndex = pagination.TotalIndex;
                return;
            }
            else if (pagination.CurrentIndex < 1)
            {
                pagination.CurrentIndex = 1;
                return;
            }

            pagination.UpdatePaginationItems();
            pagination.RaiseCurrentIndexChanged(pagination.CurrentIndex);
        }

        private static void OnTotalIndexChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            var pagination = d as Pagination;

            if (pagination.TotalIndex < 1)
            {
                pagination.TotalIndex = 1;
                return;
            }

            if (pagination.CurrentIndex > pagination.TotalIndex)
            {
                pagination.CurrentIndex = pagination.TotalIndex;
            }

            pagination.UpdatePaginationItems();
        }
        #endregion

        #region Function
        private void UpdatePaginationItems()
        {
            if (PaginationItems == null)
                PaginationItems = new ObservableCollection<PaginationItem>();

            PaginationItems.Clear();

            if (TotalIndex <= 7)
            {
                for (var i = 1; i <= TotalIndex; i++)
                {
                    PaginationItems.Add(new PaginationItem(i, CurrentIndex == i, UseSuffix, Prefix, Suffix));
                }
            }
            else
            {
                PaginationItems.Add(new PaginationItem(1, CurrentIndex == 1, UseSuffix, Prefix, Suffix));
                PaginationItems.Add(new PaginationItem(2, CurrentIndex == 2, UseSuffix, Prefix, Suffix));


                if (CurrentIndex == 1 || CurrentIndex == 2 || CurrentIndex == 3 || CurrentIndex == 4)
                {
                    PaginationItems.Add(new PaginationItem(3, CurrentIndex == 3, UseSuffix, Prefix, Suffix));
                    PaginationItems.Add(new PaginationItem(4, CurrentIndex == 4, UseSuffix, Prefix, Suffix));
                    PaginationItems.Add(new PaginationItem(5, CurrentIndex == 5, UseSuffix, Prefix, Suffix));
                }

                PaginationItems.Add(new PaginationItem(null,false, UseSuffix, Prefix, Suffix));

                if (CurrentIndex >= TotalIndex - 3)
                {
                    PaginationItems.Add(new PaginationItem(null,false, UseSuffix, Prefix, Suffix));

                    for (var i = TotalIndex - 4; i <= TotalIndex; i++)
                    {
                        PaginationItems.Add(new PaginationItem(i, CurrentIndex == i, UseSuffix, Prefix, Suffix));
                    }
                    return;
                }
                if (CurrentIndex != 1 && CurrentIndex != 2 && CurrentIndex != 3 && CurrentIndex != 4)
                {
                    for (var i = CurrentIndex - 1; i <= (CurrentIndex + 1); i++)
                    {
                        PaginationItems.Add(new PaginationItem(i, CurrentIndex == i, UseSuffix, Prefix, Suffix));
                    }
                }
                PaginationItems.Add(new PaginationItem(null,false, UseSuffix, Prefix, Suffix));
                for (var i = TotalIndex - 1; i <= TotalIndex; i++)
                {
                    PaginationItems.Add(new PaginationItem(i, CurrentIndex == i, UseSuffix, Prefix, Suffix));
                }
            }
        }
        #endregion
    }

    internal class PaginationItem
    {
        public PaginationItem(int? value, bool _UseSuffix = false, string _Prefix = null, string _Suffix = null)
        {
            Value = value;
            this.UseSuffix = _UseSuffix;
            this.Prefix = _Prefix;
            this.Suffix = _Suffix;
        }

        public PaginationItem(int? value, bool isSelected, bool _UseSuffix = false, string _Prefix = null, string _Suffix = null)
        {
            Value = value;
            IsSelected = isSelected;
            this.UseSuffix = _UseSuffix;
            this.Prefix = _Prefix;
            this.Suffix = _Suffix;
        }
        public bool UseSuffix { get; set; } = false;
        /// <summary>
        /// 前缀
        /// </summary>
        public string Prefix { get; set; } = null;
        /// <summary>
        /// 后缀
        /// </summary>
        public string Suffix { get; set; } = null;

        public int? Value { get; set; }

        public bool IsSelected { get; set; }

        public string ValueText {
            get {
                if (!Value.HasValue)
                    return "1";
                if (UseSuffix)
                {
                    string sValue = NumToChinese(Value.Value.ToString());
                    if (!string.IsNullOrEmpty(Prefix) && !string.IsNullOrEmpty(Suffix))
                        return $"{Prefix} {sValue} {Suffix}";
                    else if (!string.IsNullOrEmpty(Prefix) && string.IsNullOrEmpty(Suffix))
                        return $"{Prefix} {sValue}";
                    else if (string.IsNullOrEmpty(Prefix) && !string.IsNullOrEmpty(Suffix))
                        return $"{sValue} {Suffix}";
                    else if (Value.HasValue)
                        return $"{sValue}";
                    else
                        return "1";
                }
                else
                {
                    return Convert.ToString(Value.Value);
                }
            }
        }

        /// <returns></returns>
        /// <summary>
        /// 阿拉伯数字转换成中文数字
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public string NumToChinese(string x)
        {
            string[] pArrayNum = { "零", "一", "二", "三", "四", "五", "六", "七", "八", "九" };
            //为数字位数建立一个位数组
            string[] pArrayDigit = { "", "十", "百", "千" };
            //为数字单位建立一个单位数组
            string[] pArrayUnits = { "", "万", "亿", "万亿" };
            var pStrReturnValue = ""; //返回值
            var finger = 0; //字符位置指针
            var pIntM = x.Length % 4; //取模
            int pIntK;
            if (pIntM > 0)
                pIntK = x.Length / 4 + 1;
            else
                pIntK = x.Length / 4;
            //外层循环,四位一组,每组最后加上单位: ",万亿,",",亿,",",万,"
            for (var i = pIntK; i > 0; i--)
            {
                var pIntL = 4;
                if (i == pIntK && pIntM != 0)
                    pIntL = pIntM;
                //得到一组四位数
                var four = x.Substring(finger, pIntL);
                var P_int_l = four.Length;
                //内层循环在该组中的每一位数上循环
                for (int j = 0; j < P_int_l; j++)
                {
                    //处理组中的每一位数加上所在的位
                    int n = Convert.ToInt32(four.Substring(j, 1));
                    if (n == 0)
                    {
                        if (j < P_int_l - 1 && Convert.ToInt32(four.Substring(j + 1, 1)) > 0 && !pStrReturnValue.EndsWith(pArrayNum[n]))
                            pStrReturnValue += pArrayNum[n];
                    }
                    else
                    {
                        if (!(n == 1 && (pStrReturnValue.EndsWith(pArrayNum[0]) | pStrReturnValue.Length == 0) && j == P_int_l - 2))
                            pStrReturnValue += pArrayNum[n];
                        pStrReturnValue += pArrayDigit[P_int_l - j - 1];
                    }
                }
                finger += pIntL;
                //每组最后加上一个单位:",万,",",亿," 等
                if (i < pIntK) //如果不是最高位的一组
                {
                    if (Convert.ToInt32(four) != 0)
                        //如果所有4位不全是0则加上单位",万,",",亿,"等
                        pStrReturnValue += pArrayUnits[i - 1];
                }
                else
                {
                    //处理最高位的一组,最后必须加上单位
                    pStrReturnValue += pArrayUnits[i - 1];
                }
            }
            return pStrReturnValue;
        }
    }
    internal class PreviousCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var pagination = (parameter as Pagination);

            if (pagination.CurrentIndex - 1 < 0)
                return;

            pagination.CurrentIndex--;
        }
    }

    internal class NextCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var pagination = (parameter as Pagination);

            if (pagination.CurrentIndex + 1 > pagination.TotalIndex)
                return;

            pagination.CurrentIndex++;
        }
    }

    internal class IndexCommand : ICommand
    {
        event EventHandler ICommand.CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            var objs = parameter as object[];

            var pagination = objs[0] as Pagination;
            var index = (int)objs[1];


            pagination.CurrentIndex = index;
        }
    }

    
}
