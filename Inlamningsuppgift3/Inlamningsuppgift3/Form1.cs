using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Windows.Forms.DataVisualization.Charting;

namespace Inlamningsuppgift3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            List<Accommodation> BostonList = GetList("select * from boston");
            List<Accommodation> AmsterdamList = GetList("select * from amsterdam");
            List<Accommodation> BarcelonaList = GetList("select * from barcelona");

            City Boston = new City("Boston", 100000, 3000, 10000, BostonList);
            City Amsterdam = new City("Amsterdam", 200000, 3000, 10000, AmsterdamList);
            City Barcelona = new City("Barcelona", 100000, 3000, 10000, BarcelonaList);

            List<City> Cities = new List<City> { Boston, Amsterdam, Barcelona };

            Country Spain = new Country("Spain", 30000000, 20000, Cities);
            Country Holland = new Country("Netherlands", 9000000, 50000, Cities);
            Country Usa = new Country("USA", 30000000, 20000, Cities);

            chart1.Titles.Add("Barcelona price");
            chart1.ChartAreas[0].AxisX.Title = "Room";
            chart1.ChartAreas[0].AxisY.Title = "Price";
            chart1.Series["Series1"].ChartType = SeriesChartType.Column;

            chart2.Titles.Add("Amsterdam price");
            chart2.ChartAreas[0].AxisX.Title = "Room";
            chart2.ChartAreas[0].AxisY.Title = "Price";
            chart2.Series["Series1"].ChartType = SeriesChartType.Column;

            chart3.Titles.Add("Boston price");
            chart3.ChartAreas[0].AxisX.Title = "Room";
            chart3.ChartAreas[0].AxisY.Title = "Price";
            chart3.Series["Series1"].ChartType = SeriesChartType.Column;

            chart4.Titles.Add("Barcelona price/overall satifaction");
            chart4.ChartAreas[0].AxisX.Title = "Price";
            chart4.ChartAreas[0].AxisY.Title = "Overall Satifation";
            chart4.Series["Series1"].ChartType = SeriesChartType.Point;

            chart5.Titles.Add("Amsterdam price/overall satifaction");
            chart5.ChartAreas[0].AxisX.Title = "Price";
            chart5.ChartAreas[0].AxisY.Title = "Overall Satifation";
            chart5.Series["Series1"].ChartType = SeriesChartType.Point;

            chart6.Titles.Add("Boston price/overall satifaction");
            chart6.ChartAreas[0].AxisX.Title = "Price";
            chart6.ChartAreas[0].AxisY.Title = "Overall Satifation";
            chart6.Series["Series1"].ChartType = SeriesChartType.Point;


            // Värden till Histogrammen 1, 2 och 3
            foreach (Accommodation a in BarcelonaList.Where(x => x.Room_type == "Private room"))
            {
                chart1.Series["Series1"].Points.AddY(a.Price);
            }

            foreach (Accommodation a in AmsterdamList.Where(x => x.Room_type == "Private room"))
            {
                chart2.Series["Series1"].Points.AddY(a.Price);
            }

            foreach (Accommodation a in BostonList.Where(x => x.Room_type == "Private room"))
            {
                chart3.Series["Series1"].Points.AddY(a.Price);
            }

            // Värden till Scatterplottarna 1, 2 och 3 
            foreach (Accommodation a in BarcelonaList.Where(x => x.Overall_satisfaction != 0 && x.Overall_satisfaction < 4.5))
            {
                chart4.Series["Series1"].Points.AddXY(a.Overall_satisfaction, a.Price);
            }

            foreach (Accommodation a in AmsterdamList.Where(x => x.Overall_satisfaction != 0 && x.Overall_satisfaction < 4.5))
            {
                chart5.Series["Series1"].Points.AddXY(a.Overall_satisfaction, a.Price);
            }

            foreach (Accommodation a in BostonList.Where(x => x.Overall_satisfaction != 0 && x.Overall_satisfaction < 4.5))
            {
                chart6.Series["Series1"].Points.AddXY(a.Overall_satisfaction, a.Price);
            }
        }

        private List<Accommodation> GetList(string InputQuery)
        {

            SqlConnection connect = new SqlConnection(); // Skapar en ny connection till SQL

            connect.ConnectionString = "Data Source=LAPTOP-4R563C6G\\SQL2017;Initial Catalog=AirBNB;Integrated Security=True";
            connect.Open();

            SqlCommand MyQuery = new SqlCommand(InputQuery, connect);

            SqlDataReader MyReader = MyQuery.ExecuteReader();

            List<Accommodation> Accommodations = new List<Accommodation>();


            while (MyReader.Read()) //Så länge det finns rader så läser den in
            {
                int Room_id = (int)MyReader["room_id"];
                int Host_id = (int)MyReader["host_id"];
                string Room_type = MyReader["room_type"].ToString();
                string Borough = MyReader["borough"].ToString();
                string Neighborhood = (string)MyReader["neighborhood"];
                int Reviews = (int)MyReader["reviews"];
                double Overall_Satisfaction = Convert.ToDouble(MyReader["overall_satisfaction"]);
                int Accommodates = (int)MyReader["accommodates"];
                double Bedrooms = Convert.ToDouble(MyReader["bedrooms"]);
                double Price = Convert.ToDouble(MyReader["price"]);
                double Minstay = double.TryParse(MyReader["minstay"].ToString(), out double MinstayI) ? MinstayI : 0;
                double Latitude = Convert.ToDouble(MyReader["latitude"]);
                double Longitude = Convert.ToDouble(MyReader["longitude"]);
                string Last_modified = MyReader["last_modified"].ToString();

                Accommodations.Add(new Accommodation(
                    Room_id,
                    Host_id,
                    Room_type,
                    Borough,
                    Neighborhood,
                    Reviews,
                    Overall_Satisfaction,
                    Accommodates,
                    Bedrooms,
                    Price,
                    Minstay,
                    Latitude,
                    Longitude,
                    Last_modified
                    ));
            }
            return Accommodations;
        }
    }
}
