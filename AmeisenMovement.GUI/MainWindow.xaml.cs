using AmeisenMovement;
using AmeisenMovement.Formations;
using AmeisenMovement.Structs;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace AmeisenMovementGUI
{
    /// <summary>
    /// Interaktionslogik für MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private AmeisenMovementEngine movementEngine;

        private List<Vector4> Children { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            movementEngine = new AmeisenMovementEngine(new DefaultFormation())
            {
                MemberCount = 1
            };

            Children = new List<Vector4>();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            sliderX.Maximum = mainCanvas.ActualWidth;
            sliderY.Maximum = mainCanvas.ActualHeight;
            sliderX.Value = mainCanvas.ActualWidth / 2;
            sliderY.Value = mainCanvas.ActualHeight / 2;
            sliderR.Maximum = 360;
            sliderR.Value = 0.0;
            sliderD.Maximum = 250.0;
            sliderD.Value = 50.0;
            DrawStuff();
        }

        private void SliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelX.Content = $"X: {(int)sliderX.Value}";
            DrawStuff();
            RefreshChildren();
        }

        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelY.Content = $"Y: {(int)sliderY.Value}";
            DrawStuff();
            RefreshChildren();
        }

        private void SliderR_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelR.Content = $"R: {sliderR.Value}";
            DrawStuff();
            RefreshChildren();
        }

        private void SliderD_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            labelD.Content = $"Distance: {(int)sliderD.Value}";
            DrawStuff();
            RefreshChildren();
        }

        private void RefreshChildren()
        {
            for (int i = 0; i < Children.Count; i++)
            {
                Children[i] = movementEngine.GetPosition(new Vector4((int)sliderX.Value, (int)sliderY.Value, 0, (Math.PI / 180) * sliderR.Value), (int)sliderD.Value, i);
            }
        }

        private void DrawStuff()
        {
            mainCanvas.Children.Clear();
            DrawRectangle((int)sliderX.Value - 6, (int)sliderY.Value - 6, (int)sliderR.Value, 12, 12, Colors.OrangeRed, mainCanvas);

            foreach (Vector4 vector4 in Children)
            {
                DrawRectangle((int)vector4.X - 6, (int)vector4.Y - 6, (int)sliderR.Value, 12, 12, Colors.Orange, mainCanvas);
            }
        }

        private void Window_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            DragMove();
        }

        private void ButtonAddChild_Click(object sender, RoutedEventArgs e)
        {
            movementEngine.MemberCount = Children.Count + 1;
            Children.Add(movementEngine.GetPosition(
                new Vector4(
                    (int)sliderX.Value,
                    (int)sliderY.Value,
                    0,
                    (Math.PI / 180) * sliderR.Value),
                (int)sliderD.Value,
                movementEngine.MemberCount - 1));
            DrawStuff();
            RefreshChildren();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void DrawRectangle(int x, int y, int r, int width, int height, Color color, Canvas canvas)
        {
            Rectangle rect = new Rectangle
            {
                Width = width,
                Height = height,
                LayoutTransform = new RotateTransform(r)
            };

            rect.Fill = new SolidColorBrush(color);

            Canvas.SetLeft(rect, x);
            Canvas.SetTop(rect, y);

            canvas.Children.Add(rect);
        }

        private void DrawLine(int startX, int startY, int endX, int endY, int thickness, Color color, Canvas canvas)
        {
            Line line = new Line
            {
                Stroke = new SolidColorBrush(color),
                StrokeThickness = thickness,
                X1 = startX,
                X2 = endX,
                Y1 = startY,
                Y2 = endY,
            };

            canvas.Children.Add(line);
        }

        private void ButtonClearChilds_Click(object sender, RoutedEventArgs e)
        {
            movementEngine.MemberCount = 0;
            Children.Clear();
            DrawStuff();
            RefreshChildren();
        }
    }
}
