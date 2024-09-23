using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WSCADTask.Classes;
using Newtonsoft.Json;
using System.Xml.Serialization;
using System.Xml;

namespace WSCADTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string inputJsonFileName = "C:\\Users\\ASUS\\source\\repos\\WSCADTask\\WSCADTask\\JSONFiles\\Shapes1.json";
            var jsonData = File.ReadAllText(inputJsonFileName);
            GraphicsList? shapes = JsonConvert.DeserializeObject<GraphicsList>(jsonData);

            GraphicsList shapes2 = null;
            string inputXmlFileName = "C:\\Users\\ASUS\\source\\repos\\WSCADTask\\WSCADTask\\XMLFiles\\Shapes1.xml";
            XmlSerializer serializer = new XmlSerializer(typeof(GraphicsList));
            StreamReader reader = new StreamReader(inputXmlFileName);
            shapes2 = (GraphicsList)serializer.Deserialize(reader);
            reader.Close();

            foreach (var shape in shapes.graphics)
            {
                switch (shape.type)
                {
                    case "line":
                        DrawLine(shape.a, shape.b, shape.color);
                        break;
                    case "circle":
                        DrawCircle(shape.center, shape.radius, shape.color, shape.filled);
                        break;
                    case "triangle":
                        DrawTriangle(shape.a, shape.b, shape.c, shape.color, shape.filled);
                        break;
                }
            }
        }

        private void DrawLine(string a, string b, string color)
        {
            var aPoint = a.Split(';');
            var bPoint = b.Split(';');
            var colorValue = color.Split(";");

            Line line = new Line();
            line.X1 = double.Parse(aPoint[0]);
            line.Y1 = double.Parse(aPoint[1]);

            line.X2 = double.Parse(bPoint[0]);
            line.Y2 = double.Parse(bPoint[1]);

            line.Visibility = Visibility.Visible;

            Color clr = Color.FromArgb(byte.Parse(colorValue[0]), byte.Parse(colorValue[1]), byte.Parse(colorValue[2]), byte.Parse(colorValue[3]));

            line.Stroke = new SolidColorBrush(clr);

            DrawingCanvas.Children.Add(line);
        }

        private void DrawCircle(string center, string radius, string color, bool filled)
        {
            var centerPoint = center.Split(";");
            var radiusValue = radius.Replace(".", ",");
            var colorValue = color.Split(";");

            Ellipse circle = new Ellipse();
            circle.Width = double.Parse(radiusValue);
            circle.Height = double.Parse(radiusValue);

            circle.SetValue(Canvas.LeftProperty, double.Parse(centerPoint[0]));
            circle.SetValue(Canvas.RightProperty, double.Parse(centerPoint[1]));

            Color clr = Color.FromArgb(byte.Parse(colorValue[0]), byte.Parse(colorValue[1]), byte.Parse(colorValue[2]), byte.Parse(colorValue[3]));

            circle.Stroke = new SolidColorBrush(clr);

            if(filled)
            {
                circle.Fill = new SolidColorBrush(clr);
            }

            DrawingCanvas.Children.Add(circle);
        }

        private void DrawTriangle(string a, string b, string c, string color, bool filled)
        {
            var aPoint = a.Split(";");
            var bPoint = b.Split(";");  
            var cPoint = c.Split(";");
            var colorValue = color.Split(";");

            Polygon polygon = new Polygon();
            polygon.Points = new PointCollection()
            {
                new Point (double.Parse(aPoint[0]), double.Parse(aPoint[1])),
                new Point (double.Parse(bPoint[0]), double.Parse(bPoint[1])),
                new Point (double.Parse(cPoint[0]), double.Parse(cPoint[1]))
            };

            Color clr = Color.FromArgb(byte.Parse(colorValue[0]), byte.Parse(colorValue[1]), byte.Parse(colorValue[2]), byte.Parse(colorValue[3]));

            polygon.Stroke = new SolidColorBrush( clr);

            if (filled)
            {
                polygon.Fill = new SolidColorBrush(clr);
            }

            DrawingCanvas.Children.Add (polygon);

        }
    }
}