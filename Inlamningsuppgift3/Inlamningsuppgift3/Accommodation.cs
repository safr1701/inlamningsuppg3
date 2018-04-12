using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inlamningsuppgift3
{
    class Accommodation
    {
        private int room_id;
        private int host_id;
        private string room_type;
        private string borough;
        private string neighborhood;
        private int reviews;
        private double overall_satisfaction;
        private int accommodates;
        private double bedrooms;
        private double price;
        private double minstay;
        private double latitude;
        private double longitude;
        private string last_modified;

        public Accommodation(
            int Room_id,
            int Host_id,
            string Room_type,
            string Borough,
            string Neighborhood,
            int Reviews,
            double Overall_Satisfaction,
            int Accommodates,
            double Bedrooms,
            double Price,
            double Minstay,
            double Latitude,
            double Longitude,
            string Last_modified
            )
        {
            this.room_id = Room_id;
            this.host_id = Host_id;
            this.room_type = Room_type;
            this.borough = Borough;
            this.neighborhood = Neighborhood;
            this.reviews = Reviews;
            this.overall_satisfaction = Overall_Satisfaction;
            this.accommodates = Accommodates;
            this.bedrooms = Bedrooms;
            this.price = Price;
            this.minstay = Minstay;
            this.latitude = Latitude;
            this.longitude = Longitude;
            this.last_modified = Last_modified;

        }

        public int Room_id { get => room_id; set => room_id = value; }
        public int Host_id { get => host_id; set => host_id = value; }
        public string Room_type { get => room_type; set => room_type = value; }
        public string Borough { get => borough; set => borough = value; }
        public string Neighborhood { get => neighborhood; set => neighborhood = value; }
        public int Reviews { get => reviews; set => reviews = value; }
        public double Overall_satisfaction { get => overall_satisfaction; set => overall_satisfaction = value; }
        public int Accommodates { get => accommodates; set => accommodates = value; }
        public double Bedrooms { get => bedrooms; set => bedrooms = value; }
        public double Price { get => price; set => price = value; }
        public double Minstay { get => minstay; set => minstay = value; }
        public double Latitude { get => latitude; set => latitude = value; }
        public double Longitude { get => longitude; set => longitude = value; }
        public string Last_modified { get => last_modified; set => last_modified = value; }
    }
}
