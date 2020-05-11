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
            DrawScale();
            ostentatious();
        }
        /// <summary>
        /// 画刻度
        /// </summary>
        void DrawScale()
        {
            rootGrid.Children.Clear();

            double ScaleStartAngle = 270;
            double ScaleSweepAngle = 360;
            double MajorDivisionsCount = 12;
            double MinorDivisionsCount = 5;

            double MaxValue = 12;

            //MaxValue = 24;
            //MajorDivisionsCount = 24;

            double MinValue = 0;
            int ScaleValuePrecision = 0;
            Size MajorTickSize = new Size(10, 3);
            Color MajorTickColor = Colors.LightGray;

            Color MinorTickColor = Colors.LightGray;
            Size MinorTickSize = new Size(3, 1);

            double ScaleRadius = 150;
            double ScaleLabelRadius = 170;

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
                Rectangle majortickrect = new Rectangle();
                majortickrect.Height = MajorTickSize.Height;
                majortickrect.Width = MajorTickSize.Width;
                majortickrect.Fill = new SolidColorBrush(MajorTickColor);
                Point p = new Point(0.5, 0.5);
                majortickrect.RenderTransformOrigin = p;
                majortickrect.HorizontalAlignment = HorizontalAlignment.Center;
                majortickrect.VerticalAlignment = VerticalAlignment.Center;

                TransformGroup majortickgp = new TransformGroup();
                RotateTransform majortickrt = new RotateTransform();
                majortickrt.Angle = i;
                majortickgp.Children.Add(majortickrt);
                TranslateTransform majorticktt = new TranslateTransform();

                //在这里画点中心为（0,0）
                majorticktt.X = (int)((ScaleRadius) * Math.Cos(i_radian));
                majorticktt.Y = (int)((ScaleRadius) * Math.Sin(i_radian));


                majortickgp.Children.Add(majorticktt);
                majortickrect.RenderTransform = majortickgp;
                rootGrid.Children.Add(majortickrect);
                #endregion

                #region 刻度值
                string text = "";
                if (Math.Round(minvalue, ScaleValuePrecision) <= Math.Round(MaxValue, ScaleValuePrecision))
                {
                    minvalue = Math.Round(minvalue, ScaleValuePrecision);
                    if (minvalue > 0)
                    {
                        text = minvalue.ToString();
                    }
                    minvalue = minvalue + majorTicksUnitValue;
                }
                else
                {
                    break;
                }
                TextBlock tb = DrawText(i + 90, ScaleLabelRadius, i_radian, text, Colors.LightGray, new Size(40, 20), 8);
                rootGrid.Children.Add(tb);

                #endregion

                #region 小刻度
                Double onedegree = ((i + majorTickUnitAngle) - i) / (MinorDivisionsCount);
                if ((i < (ScaleStartAngle + ScaleSweepAngle)) && (Math.Round(minvalue, ScaleValuePrecision) <= Math.Round(MaxValue, ScaleValuePrecision)))
                {
                    //绘制小刻度
                    for (Double mi = i + onedegree; mi < (i + majorTickUnitAngle); mi = mi + onedegree)
                    {
                        Rectangle mr = new Rectangle();
                        mr.Height = MinorTickSize.Height;
                        mr.Width = MinorTickSize.Width;
                        mr.Fill = new SolidColorBrush(MinorTickColor);
                        mr.HorizontalAlignment = HorizontalAlignment.Center;
                        mr.VerticalAlignment = VerticalAlignment.Center;
                        Point p1 = new Point(0.5, 0.5);
                        mr.RenderTransformOrigin = p1;

                        TransformGroup minortickgp = new TransformGroup();
                        RotateTransform minortickrt = new RotateTransform();
                        minortickrt.Angle = mi;
                        minortickgp.Children.Add(minortickrt);
                        TranslateTransform minorticktt = new TranslateTransform();

                        //计算角度
                        Double mi_radian = (mi * Math.PI) / 180;
                        //刻度点
                        minorticktt.X = (int)((ScaleRadius) * Math.Cos(mi_radian));
                        minorticktt.Y = (int)((ScaleRadius) * Math.Sin(mi_radian));

                        minortickgp.Children.Add(minorticktt);
                        mr.RenderTransform = minortickgp;
                        rootGrid.Children.Add(mr);
                    }
                }
                #endregion
            }

            #region 天干地支[子、丑、寅、卯、辰、巳、午、未、申、酉、戌、亥]
            string[] tgdz = new string[] { "子", "丑", "寅", "卯", "辰", "巳", "午", "未", "申", "酉", "戌", "亥" };
            double MajorDivisionsCount_tgdz = 12;
            double MaxValue_tgdz = 12;
            double ScaleLabelRadius_tgdz = 120;
            //刻度角度
            Double majorTickUnitAngle_tgdz = ScaleSweepAngle / MajorDivisionsCount_tgdz;

            //刻度单位值
            Double majorTicksUnitValue_tgdz = (MaxValue_tgdz - MinValue) / MajorDivisionsCount_tgdz;
            majorTicksUnitValue_tgdz = Math.Round(majorTicksUnitValue_tgdz, ScaleValuePrecision);
            Double minvalue_tgdz = MinValue;
            for (Double i = ScaleStartAngle; i <= (ScaleStartAngle + ScaleSweepAngle); i = i + majorTickUnitAngle_tgdz)
            {
                Double i_radian = (i * Math.PI) / 180;
                string text = "";
                if (Math.Round(minvalue_tgdz, ScaleValuePrecision) <= Math.Round(MaxValue_tgdz, ScaleValuePrecision))
                {
                    minvalue_tgdz = Math.Round(minvalue_tgdz, ScaleValuePrecision);
                    if (int.Parse((minvalue_tgdz).ToString()) < tgdz.Length)
                    {
                        text = tgdz[int.Parse((minvalue_tgdz).ToString())];
                    }
                    minvalue_tgdz = minvalue_tgdz + majorTicksUnitValue_tgdz;
                }
                else
                {
                    break;
                }
                TextBlock tb = DrawText(i + 90, ScaleLabelRadius_tgdz, i_radian, text, Colors.LightGray, new Size(40, 20), 8);
                rootGrid.Children.Add(tb);
            }

            #endregion

            #region 八卦
            string[] bg = new string[] { "乾", "巽", "坎", "艮", "坤", "震", "离", "兑" };
            string[] bg_tag = new string[] { "离", "坤", "兑", "乾", "坎", "艮", "震", "巽" };

            // 个数
            double MajorDivisionsCount_bg = 8;
            double MaxValue_bg = 8;
            double ScaleLabelRadius_bg = 190;
            //刻度角度
            Double majorTickUnitAngle_bg = ScaleSweepAngle / MajorDivisionsCount_bg;

            //刻度单位值
            Double majorTicksUnitValue_bg = (MaxValue_bg - MinValue) / MajorDivisionsCount_bg;
            majorTicksUnitValue_bg = Math.Round(majorTicksUnitValue_bg, ScaleValuePrecision);
            Double minvalue_bg = MinValue;
            for (Double i = ScaleStartAngle; i <= (ScaleStartAngle + ScaleSweepAngle); i = i + majorTickUnitAngle_bg)
            {
                Double i_radian = (i * Math.PI) / 180;
                Double i_radian_ta = ((i + 8) * Math.PI) / 180;
                string text = "";
                string text_tag = "";
                if (Math.Round(minvalue_bg, ScaleValuePrecision) <= Math.Round(MaxValue_bg, ScaleValuePrecision))
                {
                    minvalue_bg = Math.Round(minvalue_bg, ScaleValuePrecision);
                    if (int.Parse((minvalue_bg).ToString()) < bg.Length)
                    {
                        text_tag = bg_tag[int.Parse((minvalue_bg).ToString())];
                        text = bg[int.Parse((minvalue_bg).ToString())];
                    }
                    minvalue_bg = minvalue_bg + majorTicksUnitValue_bg;
                }
                else
                {
                    break;
                }
                TextBlock tb = DrawText(i + 90, ScaleLabelRadius_bg, i_radian, text, Colors.Red, new Size(40, 20), 12);
                TextBlock tb_tag = DrawText(i + 90, ScaleLabelRadius_bg, i_radian_ta, text_tag, Colors.LightGray, new Size(40, 20), 8);
                rootGrid.Children.Add(tb);
                rootGrid.Children.Add(tb_tag);
            }

            #endregion
        }

        TextBlock DrawText(double angle,double scaleLabelRadius,double radian, string text,Color color,Size labelSize,double fontSize) {
            TransformGroup majorscalevaluegp = new TransformGroup();
            RotateTransform majorscalevaluert = new RotateTransform();
            majorscalevaluert.Angle = angle;
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
            tb.Foreground = new SolidColorBrush(color);
            tb.TextAlignment = TextAlignment.Center;
            tb.VerticalAlignment = VerticalAlignment.Center;
            tb.HorizontalAlignment = HorizontalAlignment.Center;
            tb.Text = text;
            tb.RenderTransformOrigin = new Point(0.5, 0.5);
            tb.RenderTransform = majorscalevaluegp;
            return tb;
        }

        /// <summary>
        /// 装逼文字
        /// </summary>
        public void ostentatious()
        {
            string ostentatiousText = "寻龙分金看缠山，一重缠是一重关，关门如有八重险，不出阴阳八卦形";
            
            double angleAdd = 351.00 / ostentatiousText.Length;
            int i = 0;
            for (double angle = -175; angle < 175; angle += angleAdd)
            {
                TextBlock txtblk = new TextBlock();
                txtblk.FontFamily = new FontFamily("方正大标宋简体,黑体,宋体");
                txtblk.FontSize = 20;
                txtblk.Foreground = new SolidColorBrush(Colors.Red);
                txtblk.Text = ostentatiousText[i].ToString();
                txtblk.RenderTransformOrigin = new Point(0.5, 0);
                TransformGroup tg = new TransformGroup();
                ScaleTransform st = new ScaleTransform(0.8, 1);
                TranslateTransform tt = new TranslateTransform(0, -280);
                tg.Children.Add(st);
                tg.Children.Add(tt);
                tg.Children.Add(new RotateTransform(angle));
                txtblk.RenderTransform = tg;
                image.Children.Add(txtblk);
                Canvas.SetLeft(txtblk, 270);
                Canvas.SetTop(txtblk, 280);
                i++;
            }
        }
        public void BeginStoryboard() {
            Storyboard story = (Storyboard)this.FindResource("Run");
            story.Begin();
        }
    }
}
