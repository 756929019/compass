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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace compass
{
    /// <summary>
    /// uc_compass.xaml 的交互逻辑
    /// </summary>
    public partial class uc_compass : UserControl
    {
        public uc_compass()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            DrawBg();
            DrawScale1();
            DrawScale2();
            DrawScale3();
        }

        void DrawBg()
        {
            // 八卦第一层
            //double cir = Ellipse3.ActualWidth * Math.PI;
            //double unit = 81.3;
            //Ellipse3.StrokeDashArray = new DoubleCollection() {cir / (unit * 0.8), cir / (unit * 1.2)};
            //Ellipse3.StrokeDashOffset = cir / (unit * 1) / 2;

        }

        /// <summary>
        /// 画刻度
        /// </summary>
        void DrawScale1()
        {
            // rootGrid.Children.Clear();

            double ScaleStartAngle = 90;
            double ScaleSweepAngle = 360;
            double MajorDivisionsCount = 36;
            double MinorDivisionsCount = 10;

            double MaxValue = 36;

            //MaxValue = 24;
            //MajorDivisionsCount = 24;

            double MinValue = 0;
            int ScaleValuePrecision = 0;
            Size MajorTickSize = new Size(10, 3);
            Color MajorTickColor = Colors.LightGray;

            Color MinorTickColor = Colors.LightGray;
            Size MinorTickSize = new Size(3, 1);

            double ScaleRadius = 390;
            double ScaleLabelRadius = 410;

            //大刻度角度
            Double majorTickUnitAngle = ScaleSweepAngle / MajorDivisionsCount;

            //小刻度角度
            Double minorTickUnitAngle = ScaleSweepAngle / MinorDivisionsCount;

            //刻度单位值
            Double majorTicksUnitValue = (MaxValue - MinValue) / MajorDivisionsCount;
            majorTicksUnitValue = Math.Round(majorTicksUnitValue, ScaleValuePrecision);


            Double minvalue = MinValue; ;
            for (Double i = ScaleStartAngle; i <= (ScaleStartAngle + ScaleSweepAngle); i = i + majorTickUnitAngle)
            {
                //大刻度、刻度值角度
                Double i_radian = (i * Math.PI) / 180;

                #region 大刻度
                Rectangle majortickrect = DrawRectangle(i, ScaleRadius, Colors.LightGray, new Size(10, 3));
                rootGrid.Children.Add(majortickrect);
                #endregion

                #region 刻度值
                string text = "";
                if (Math.Round(minvalue, ScaleValuePrecision) <= Math.Round(MaxValue, ScaleValuePrecision))
                {
                    minvalue = Math.Round(minvalue, ScaleValuePrecision);
                    if (minvalue > 0)
                    {
                        text = (minvalue*10).ToString();
                    }
                    minvalue = minvalue + majorTicksUnitValue;
                }
                else
                {
                    break;
                }
                TextBlock tb = DrawText(i, ScaleLabelRadius, text, Colors.LightGray, new Size(40, 20), 8);
                rootGrid.Children.Add(tb);

                #endregion

                #region 小刻度
                Double onedegree = ((i + majorTickUnitAngle) - i) / (MinorDivisionsCount);
                if ((i < (ScaleStartAngle + ScaleSweepAngle)) && (Math.Round(minvalue, ScaleValuePrecision) <= Math.Round(MaxValue, ScaleValuePrecision)))
                {
                    //绘制小刻度
                    for (Double mi = i + onedegree; mi < (i + majorTickUnitAngle); mi = mi + onedegree)
                    {
                        Rectangle mr = DrawRectangle(mi, ScaleRadius, Colors.LightGray, new Size(3, 1));
                        rootGrid.Children.Add(mr);
                    }
                }
                #endregion
            }

            #region 八卦
            string[] bg = new string[] { "短短短", "长短短", "长短长", "长长短", "长长长", "短长长", "短长短", "短短长"};
            double ScaleStartAngle_tmp = 90 - (360 / 16); // 线的起始位置
            // 个数
            double MajorDivisionsCount_bg = 8;
            double MinorDivisionsCount_bg = 3;
            double MaxValue_bg = 24;
            double ScaleLabelRadius_bg = Ellipse001.ActualWidth / 2 + 70;
            double ScaleLabelRadius_mibg = Ellipse002.ActualWidth / 2 + 52.5;
            //大刻度角度
            Double majorTickUnitAngle_bg = ScaleSweepAngle / MajorDivisionsCount_bg;
            //小刻度角度
            Double minorTickUnitAngle_bg = ScaleSweepAngle / MinorDivisionsCount_bg;


            //刻度单位值
            Double majorTicksUnitValue_bg = (MaxValue_bg - MinValue) / MajorDivisionsCount_bg;
            majorTicksUnitValue_bg = Math.Round(majorTicksUnitValue_bg, ScaleValuePrecision);
            MinValue = 0;
            Double minvalue_bg = MinValue;
            int idx = 0;
            for (Double i = ScaleStartAngle_tmp; i <= (ScaleStartAngle_tmp + ScaleSweepAngle); i = i + majorTickUnitAngle_bg)
            {
                #region 大刻度
                Rectangle majortickrect = DrawRectangle(i, ScaleLabelRadius_bg, Colors.LightGray, new Size(140,1));
                rootGrid.Children.Add(majortickrect);
                #endregion
                #region 八卦
                if (idx < bg.Length)
                {
                    double angle = i + (360 / 16);
                    if (bg[idx][0].Equals('长'))
                    {
                        Rectangle majortickrect_bg1 = DrawRectangle(angle, ScaleLabelRadius_bg - 48, Colors.LightGray, new Size(3, 40));
                        rootGrid.Children.Add(majortickrect_bg1);
                    }
                    else
                    {
                        Grid majortickrect_bg1 = DrawLine(angle, ScaleLabelRadius_bg - 48, Colors.LightGray, new Size(3, 40));
                        rootGrid.Children.Add(majortickrect_bg1);
                    }
                    if (bg[idx][1].Equals('长'))
                    {
                        Rectangle majortickrect_bg1 = DrawRectangle(angle, ScaleLabelRadius_bg - 54, Colors.LightGray, new Size(3, 40));
                        rootGrid.Children.Add(majortickrect_bg1);
                    }
                    else
                    {
                        Grid majortickrect_bg1 = DrawLine(angle, ScaleLabelRadius_bg - 54, Colors.LightGray, new Size(3, 40));
                        rootGrid.Children.Add(majortickrect_bg1);
                    }
                    if (bg[idx][2].Equals('长'))
                    {
                        Rectangle majortickrect_bg1 = DrawRectangle(angle, ScaleLabelRadius_bg - 60, Colors.LightGray, new Size(3, 40));
                        rootGrid.Children.Add(majortickrect_bg1);
                    }
                    else
                    {
                        Grid majortickrect_bg1 = DrawLine(angle, ScaleLabelRadius_bg - 60, Colors.LightGray, new Size(3, 40));
                        rootGrid.Children.Add(majortickrect_bg1);
                    }
                    idx++;
                }
                #endregion
                #region 小刻度
                Double onedegree = ((i + majorTickUnitAngle_bg) - i) / (MinorDivisionsCount_bg);
                if ((i < (ScaleStartAngle_tmp + ScaleSweepAngle)) && (Math.Round(minvalue_bg, ScaleValuePrecision) <= Math.Round(MaxValue_bg, ScaleValuePrecision)))
                {
                    //绘制小刻度
                    for (Double mi = i + onedegree; mi < (i + majorTickUnitAngle_bg); mi = mi + onedegree)
                    {
                        Rectangle mr = DrawRectangle(mi, ScaleLabelRadius_mibg, Colors.LightGray, new Size(105, 1));
                        rootGrid.Children.Add(mr);
                    }
                }
                #endregion
            }

            #endregion

            #region 天干地支
            ScaleStartAngle_tmp = 90 - (360 / 24); // 线的起始位置
            string[] bg1 = new string[] { "壬R", "子R", "癸R", "丑", "艮", "寅R", "甲R", "卯", "乙R", "辰R", "巽", "巳", "丙", "午R", "丁", "未", "坤R", "申R", "庚", "酉", "辛", "戌R", "乾R", "亥" };
            string[] bg2 = new string[] { "乾", "", "艮", "", "甲癸", "", "艮", "", "巽", "", "丙乙", "", "巽", "", "坤", "", "庚丁", "", "坤", "", "乾", "", "壬辛", "" };
            string[] bg3 = new string[] { "文", "破", "破", "武", "贪", "文", "禄", "廉", "弼", "破", "巨", "午", "贪", "文", "武", "廉", "辅", "破", "廉", "武", "巨", "文", "禄", "廉" };

            string[] bg4 = new string[] { "坤", "申", "庚", "巳", "丙", "午", "丁", "戌", "乾", "酉", "辛", "丑", "艮", "寅", "甲", "亥", "壬", "子", "癸", "辰", "巽", "卯", "乙", "未" };
            string[] bg5 = new string[] { "壬", "子", "癸", "丑R", "艮R", "寅R", "甲R", "卯", "乙", "辰R", "巽R", "巳", "丙", "午", "丁", "未R", "坤R", "申R", "庚R", "酉", "辛", "戌R", "乾R", "亥" };
            string[] bg6 = new string[] { "大雪", "冬至", "小寒", "大寒", "立春", "雨水", "惊蛰", "春分", "清明", "谷雨", "立夏", "小满", "芒种", "夏至", "小暑", "大暑", "立秋", "处暑", "白露", "秋分", "寒露", "霜降", "立冬", "小雪" };

            double MajorDivisionsCount_tgdz = 24;
            double MaxValue_tgdz = 24;
            double ScaleLabelRadius_1 = Ellipse001.ActualWidth / 2 + 55;
            double ScaleLabelRadius_2 = ScaleLabelRadius_1 + 28;
            double ScaleLabelRadius_3 = ScaleLabelRadius_2 + 20;

            double ScaleLabelRadius_4 = ScaleLabelRadius_3 + 50;
            double ScaleLabelRadius_5 = ScaleLabelRadius_4 + 25;
            double ScaleLabelRadius_6 = ScaleLabelRadius_5 + 30;

            double ScaleLabelRadius_wc_bg = Ellipse006.ActualWidth / 2 + 40;

            //刻度角度
            Double majorTickUnitAngle_tgdz = ScaleSweepAngle / MajorDivisionsCount_tgdz;

            //刻度单位值
            Double majorTicksUnitValue_tgdz = (MaxValue_tgdz - MinValue) / MajorDivisionsCount_tgdz;
            majorTicksUnitValue_tgdz = Math.Round(majorTicksUnitValue_tgdz, ScaleValuePrecision);
            Double minvalue_tgdz = MinValue;
            for (Double i = ScaleStartAngle_tmp; i <= (ScaleStartAngle_tmp + ScaleSweepAngle); i = i + majorTickUnitAngle_tgdz)
            {
                Double i_radian = (i * Math.PI) / 180;
                string text1 = "";
                string text2 = "";
                string text3 = "";
                string text4 = "";
                string text5 = "";
                string text6 = "";
                if (Math.Round(minvalue_tgdz, ScaleValuePrecision) <= Math.Round(MaxValue_tgdz, ScaleValuePrecision))
                {
                    minvalue_tgdz = Math.Round(minvalue_tgdz, ScaleValuePrecision);
                    if (int.Parse((minvalue_tgdz).ToString()) < bg1.Length)
                    {
                        text1 = bg1[int.Parse((minvalue_tgdz).ToString())];
                        text2 = bg2[int.Parse((minvalue_tgdz).ToString())];
                        text3 = bg3[int.Parse((minvalue_tgdz).ToString())];
                        text4 = bg4[int.Parse((minvalue_tgdz).ToString())];
                        text5 = bg5[int.Parse((minvalue_tgdz).ToString())];
                        text6 = bg6[int.Parse((minvalue_tgdz).ToString())];
                    }
                    minvalue_tgdz = minvalue_tgdz + majorTicksUnitValue_tgdz;
                }
                else
                {
                    break;
                }
                Color color1 = Colors.LightGray;
                if (text1.IndexOf("R") > -1) {
                    text1 = text1.Replace("R", "");
                    color1 = Colors.Red;
                }
                Color color2 = Colors.LightGray;
                if (text5.IndexOf("R") > -1)
                {
                    text5 = text5.Replace("R", "");
                    color2 = Colors.Red;
                }

                TextBlock tb1 = DrawText(i, ScaleLabelRadius_1, text1, color1, new Size(40, 20), 18, true);
                rootGrid.Children.Add(tb1);
                TextBlock tb2 = DrawText(i, ScaleLabelRadius_2, text2, Colors.LightGray, new Size(40, 20), 12);
                rootGrid.Children.Add(tb2);
                TextBlock tb3 = DrawText(i, ScaleLabelRadius_3, text3, Colors.LightGray, new Size(40, 20), 12);
                rootGrid.Children.Add(tb3);

                double angle = i + (360 / 48);

                TextBlock tb4 = DrawText(angle, ScaleLabelRadius_4, text4, Colors.LightGray, new Size(40, 20), 12, true);
                rootGrid.Children.Add(tb4);
                TextBlock tb5 = DrawText(angle, ScaleLabelRadius_5, text5, color2, new Size(40, 20), 18, true);
                rootGrid.Children.Add(tb5);
                TextBlock tb6 = DrawText(angle, ScaleLabelRadius_6, text6, Colors.LightGray, new Size(40, 20), 12);
                rootGrid.Children.Add(tb6);

                #region 外层刻度
                Rectangle majortickrect = DrawRectangle(i, ScaleLabelRadius_wc_bg, Colors.LightGray, new Size(80, 1));
                rootGrid.Children.Add(majortickrect);
                #endregion
            }

            #endregion

            #region 装逼文字
            string ostentatiousText = "寻龙分金看缠山，一重缠是一重关，关门如有八重险，不出阴阳八卦形";
            char[] ostentatious = ostentatiousText.ToCharArray();
            double Count_Ostentatious = ostentatious.Length;
            double MaxValue_Ostentatious = ostentatious.Length;
            double ScaleLabelRadius_Ostentatious = 515;
            //刻度角度
            Double majorTickUnitAngle_Ostentatious = ScaleSweepAngle / Count_Ostentatious;

            //刻度单位值
            Double majorTicksUnitValue_Ostentatious = (MaxValue_Ostentatious - MinValue) / Count_Ostentatious;
            majorTicksUnitValue_Ostentatious = Math.Round(majorTicksUnitValue_Ostentatious, ScaleValuePrecision);
            Double minvalue_Ostentatious = MinValue;
            for (Double i = ScaleStartAngle; i <= (ScaleStartAngle + ScaleSweepAngle); i = i + majorTickUnitAngle_Ostentatious)
            {
                Double i_radian = (i * Math.PI) / 180;
                string text = "";
                if (Math.Round(minvalue_Ostentatious, ScaleValuePrecision) <= Math.Round(MaxValue_Ostentatious, ScaleValuePrecision))
                {
                    minvalue_Ostentatious = Math.Round(minvalue_Ostentatious, ScaleValuePrecision);
                    if (int.Parse((minvalue_Ostentatious).ToString()) < ostentatious.Length)
                    {
                        text = ostentatious[int.Parse((minvalue_Ostentatious).ToString())].ToString();
                    }
                    minvalue_Ostentatious = minvalue_Ostentatious + majorTicksUnitValue_Ostentatious;
                }
                else
                {
                    break;
                }
                TextBlock tb = DrawText(i, ScaleLabelRadius_Ostentatious, text, Colors.Red, new Size(20, 20), 20);
                ostentatiousGrid.Children.Add(tb);
            }
            #endregion
        }

        /// <summary>
        /// 画刻度
        /// </summary>
        void DrawScale2()
        {
            double ScaleStartAngle = 90;
            double ScaleSweepAngle = 360;
            double MinValue = 0;
            int ScaleValuePrecision = 0;

            #region xxx
            double ScaleStartAngle_tmp = 90 - (360 / 144) * 6; // 线的起始位置
            string[] bg1 = new string[] { "", "甲子", "丙子", "戊子", "庚子", "壬子", "", "乙丑", "丁丑", "己丑", "辛丑", "癸丑", "", "丙寅", "戊寅", "庚寅", "壬寅", "甲寅", "", "丁卯", "己卯", "辛卯", "癸卯", "乙卯", "", "戊辰", "庚辰", "壬辰", "甲辰", "丙辰", "", "己巳", "辛巳", "癸巳", "乙巳", "丁巳", "", "庚午", "壬午", "甲午", "丙午", "戊午", "", "辛未", "癸未", "乙未", "丁未", "己未", "", "壬申", "甲申", "丙申", "戊申", "庚申", "", "癸酉", "乙酉", "丁酉", "己酉", "辛酉", "", "甲戌", "丙戌", "戊戌", "庚戌", "壬戌", "", "乙亥", "丁亥", "己亥", "辛亥", "癸亥" };

            double MajorDivisionsCount_tgdz = 72;
            double MaxValue_tgdz = 72;
            double ScaleLabelRadius = Ellipse005.ActualWidth / 2 + 15;
            double ScaleLabelRadius_1 = Ellipse005.ActualWidth / 2 + 14;
            double ScaleLabelRadius_2 = ScaleLabelRadius_1 + 20;

            //刻度角度
            Double majorTickUnitAngle_tgdz = ScaleSweepAngle / MajorDivisionsCount_tgdz;

            //刻度单位值
            Double majorTicksUnitValue_tgdz = (MaxValue_tgdz - MinValue) / MajorDivisionsCount_tgdz;
            majorTicksUnitValue_tgdz = Math.Round(majorTicksUnitValue_tgdz, ScaleValuePrecision);
            Double minvalue_tgdz = MinValue;
            for (Double i = ScaleStartAngle_tmp; i <= (ScaleStartAngle_tmp + ScaleSweepAngle); i = i + majorTickUnitAngle_tgdz)
            {
                string text1 = "";
                string text2 = "";
                if (Math.Round(minvalue_tgdz, ScaleValuePrecision) <= Math.Round(MaxValue_tgdz, ScaleValuePrecision))
                {
                    minvalue_tgdz = Math.Round(minvalue_tgdz, ScaleValuePrecision);
                    if (int.Parse((minvalue_tgdz).ToString()) < bg1.Length)
                    {
                        text1 = bg1[int.Parse((minvalue_tgdz).ToString())];
                    }
                    minvalue_tgdz = minvalue_tgdz + majorTicksUnitValue_tgdz;
                }
                else
                {
                    break;
                }
                double angle = i - (360 / 144) - 0.5;
                TextBlock tb1 = DrawText(angle, ScaleLabelRadius_1, text1, Colors.LightGray, new Size(12, 30), 12);
                tb1.TextWrapping = TextWrapping.Wrap;
                rootGrid2.Children.Add(tb1);

                #region 刻度
                Rectangle majortickrect = DrawRectangle(i, ScaleLabelRadius, Colors.LightGray, new Size(30, 1));
                rootGrid2.Children.Add(majortickrect);
                #endregion
            }

            #endregion
        }

        /// <summary>
        /// 画刻度
        /// </summary>
        void DrawScale3()
        {
            double ScaleStartAngle = 90;
            double ScaleSweepAngle = 360;
            double MinValue = 0;
            int ScaleValuePrecision = 0;

            #region xxx
            double ScaleStartAngle_tmp = 90 - (360 / 24); // 线的起始位置
            string[] bg1 = new string[] { "子甲", "子丙", "子戊", "子庚", "子壬", "丑乙", "丑丁", "丑己", "丑辛", "丑癸", "寅丙", "寅戊", "寅庚", "寅壬", "寅甲", "卯丁", "卯己", "卯辛", "卯癸", "卯乙", "辰戊", "辰庚", "辰壬", "辰甲", "辰丙", "巳己", "巳辛", "巳癸", "巳乙", "巳丁", "午庚", "午壬", "午甲", "午丙", "午戊", "未辛", "未癸", "未乙", "未丁", "未己", "申壬", "申甲", "申丙", "申戊", "申庚", "酉癸", "酉乙", "酉丁", "酉己", "酉辛", "戌甲", "戌丙", "戌戊", "戌庚", "戌壬", "亥乙", "亥丁", "亥己", "亥辛", "亥癸" };
            string[] bg2 = new string[] { "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七", "七三", " 正 ", "五五", " 正 ", "三七" };

            double MajorDivisionsCount_tgdz = 60;
            double MaxValue_tgdz = 60;
            double ScaleLabelRadius = Ellipse009.ActualWidth / 2 + 20;
            double ScaleLabelRadius_1 = Ellipse009.ActualWidth / 2 + 12;
            double ScaleLabelRadius_2 = ScaleLabelRadius_1 + 20;

            //刻度角度
            Double majorTickUnitAngle_tgdz = ScaleSweepAngle / MajorDivisionsCount_tgdz;

            //刻度单位值
            Double majorTicksUnitValue_tgdz = (MaxValue_tgdz - MinValue) / MajorDivisionsCount_tgdz;
            majorTicksUnitValue_tgdz = Math.Round(majorTicksUnitValue_tgdz, ScaleValuePrecision);
            Double minvalue_tgdz = MinValue;
            for (Double i = ScaleStartAngle_tmp; i <= (ScaleStartAngle_tmp + ScaleSweepAngle); i = i + majorTickUnitAngle_tgdz)
            {
                string text1 = "";
                string text2 = "";
                if (Math.Round(minvalue_tgdz, ScaleValuePrecision) <= Math.Round(MaxValue_tgdz, ScaleValuePrecision))
                {
                    minvalue_tgdz = Math.Round(minvalue_tgdz, ScaleValuePrecision);
                    if (int.Parse((minvalue_tgdz).ToString()) < bg1.Length)
                    {
                        text1 = bg1[int.Parse((minvalue_tgdz).ToString())];
                        text2 = bg2[int.Parse((minvalue_tgdz).ToString())];
                    }
                    minvalue_tgdz = minvalue_tgdz + majorTicksUnitValue_tgdz;
                }
                else
                {
                    break;
                }
                double angle = i + (360 / 120);
                TextBlock tb1 = DrawText(angle, ScaleLabelRadius_1, text1, Colors.LightGray, new Size(40, 20), 12, true);
                rootGrid2.Children.Add(tb1);
                TextBlock tb2 = DrawText(angle, ScaleLabelRadius_2, text2, Colors.LightGray, new Size(40, 20), 12);
                rootGrid2.Children.Add(tb2);

                #region 刻度
                Rectangle majortickrect = DrawRectangle(i, ScaleLabelRadius, Colors.LightGray, new Size(40, 1));
                rootGrid2.Children.Add(majortickrect);
                #endregion
            }

            #endregion
        }
        Grid DrawLine(double angle, double scaleLabelRadius, Color color, Size tickSize, bool isRotate = true)
        {
            // 计算角度
            double radian = (angle * Math.PI) / 180;
            Grid grid = new Grid();
            grid.Height = tickSize.Height;
            grid.Width = tickSize.Width;
            Rectangle mr = new Rectangle();
            mr.Height = (tickSize.Height-5) / 2;
            mr.Width = tickSize.Width;
            mr.Fill = new SolidColorBrush(color);
            mr.HorizontalAlignment = HorizontalAlignment.Center;
            mr.VerticalAlignment = VerticalAlignment.Top;
            grid.Children.Add(mr);
            Rectangle mr1 = new Rectangle();
            mr1.Height = (tickSize.Height - 5) / 2;
            mr1.Width = tickSize.Width;
            mr1.Fill = new SolidColorBrush(color);
            mr1.HorizontalAlignment = HorizontalAlignment.Center;
            mr1.VerticalAlignment = VerticalAlignment.Bottom;
            grid.Children.Add(mr1);
            Point p1 = new Point(0.5, 0.5);
            grid.RenderTransformOrigin = p1;

            TransformGroup minortickgp = new TransformGroup();
            RotateTransform minortickrt = new RotateTransform();
            minortickrt.Angle = angle;
            if (isRotate)
            {
                minortickgp.Children.Add(minortickrt);
            }
            TranslateTransform minorticktt = new TranslateTransform();

            //刻度点
            minorticktt.X = (int)((scaleLabelRadius) * Math.Cos(radian));
            minorticktt.Y = (int)((scaleLabelRadius) * Math.Sin(radian));

            minortickgp.Children.Add(minorticktt);
            grid.RenderTransform = minortickgp;
            return grid;
        }
        Rectangle DrawRectangle(double angle, double scaleLabelRadius, Color color, Size tickSize, bool isRotate = true)
        {
            // 计算角度
            double radian = (angle * Math.PI) / 180;
            Rectangle mr = new Rectangle();
            mr.Height = tickSize.Height;
            mr.Width = tickSize.Width;
            mr.Fill = new SolidColorBrush(color);
            mr.HorizontalAlignment = HorizontalAlignment.Center;
            mr.VerticalAlignment = VerticalAlignment.Center;
            Point p1 = new Point(0.5, 0.5);
            mr.RenderTransformOrigin = p1;

            TransformGroup minortickgp = new TransformGroup();
            RotateTransform minortickrt = new RotateTransform();
            minortickrt.Angle = angle;
            if (isRotate) {
                minortickgp.Children.Add(minortickrt);
            }
            TranslateTransform minorticktt = new TranslateTransform();

            //刻度点
            minorticktt.X = (int)((scaleLabelRadius) * Math.Cos(radian));
            minorticktt.Y = (int)((scaleLabelRadius) * Math.Sin(radian));

            minortickgp.Children.Add(minorticktt);
            mr.RenderTransform = minortickgp;
            return mr;
        }

        TextBlock DrawText(double angle,double scaleLabelRadius,string text,Color color,Size labelSize,double fontSize, bool isBold = false) {
            double radian = (angle * Math.PI) / 180;
            TransformGroup majorscalevaluegp = new TransformGroup();
            RotateTransform majorscalevaluert = new RotateTransform();
            majorscalevaluert.Angle = angle - 90;
            majorscalevaluegp.Children.Add(majorscalevaluert);
            TranslateTransform majorscalevaluett = new TranslateTransform();
            //在这里画点中心为（0,0）
            majorscalevaluett.X = (int)((scaleLabelRadius) * Math.Cos(radian));
            majorscalevaluett.Y = (int)((scaleLabelRadius) * Math.Sin(radian));
            majorscalevaluegp.Children.Add(majorscalevaluett);

            //值显示
            TextBlock tb = new TextBlock();

            tb.Height = labelSize.Height;
            tb.Width = labelSize.Width;
            tb.FontSize = fontSize;
            if (isBold) {
                tb.FontWeight = FontWeights.Bold;
            }
            tb.Foreground = new SolidColorBrush(color);
            tb.TextAlignment = TextAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.Text = text;
            tb.RenderTransformOrigin = new Point(0.5, 0.5);
            tb.RenderTransform = majorscalevaluegp;
            return tb;
        }

        public void BeginStoryboard() {
            Storyboard story = (Storyboard)this.FindResource("Run");
            story.Begin();
        }
    }
}
