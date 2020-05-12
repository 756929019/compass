﻿using System;
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
            DrawScale();
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
        void DrawScale()
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

            double MajorDivisionsCount_tgdz = 24;
            double MaxValue_tgdz = 24;
            double ScaleLabelRadius_1 = Ellipse001.ActualWidth / 2 + 55;
            double ScaleLabelRadius_2 = ScaleLabelRadius_1 + 28;
            double ScaleLabelRadius_3 = ScaleLabelRadius_2 + 20;
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
                if (Math.Round(minvalue_tgdz, ScaleValuePrecision) <= Math.Round(MaxValue_tgdz, ScaleValuePrecision))
                {
                    minvalue_tgdz = Math.Round(minvalue_tgdz, ScaleValuePrecision);
                    if (int.Parse((minvalue_tgdz).ToString()) < bg1.Length)
                    {
                        text1 = bg1[int.Parse((minvalue_tgdz).ToString())];
                        text2 = bg2[int.Parse((minvalue_tgdz).ToString())];
                        text3 = bg3[int.Parse((minvalue_tgdz).ToString())];
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
                TextBlock tb1 = DrawText(i, ScaleLabelRadius_1, text1, color1, new Size(40, 20), 18, true);
                rootGrid.Children.Add(tb1);
                TextBlock tb2 = DrawText(i, ScaleLabelRadius_2, text2, Colors.LightGray, new Size(40, 20), 12);
                rootGrid.Children.Add(tb2);
                TextBlock tb3 = DrawText(i, ScaleLabelRadius_3, text3, Colors.LightGray, new Size(40, 20), 12);
                rootGrid.Children.Add(tb3);
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
