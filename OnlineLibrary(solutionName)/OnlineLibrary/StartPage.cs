using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

namespace OnlineLibrary
{
    public partial class StartPage : Form
    {
        public static IMongoClient client = new MongoClient();
        public static IMongoDatabase db = client.GetDatabase("StudentDataBase");
        public static IMongoCollection<Student> collection = db.GetCollection<Student>("mycol");

        public StartPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Student student = new Student(textBox1.Text
                                            , textBox2.Text,
                                            textBox3.Text);

            collection.InsertOne(student);
            readData();

        }

        public void readData()
        {
            List<Student> list1 = collection.AsQueryable().ToList();
            dataGridView1.DataSource = list1;

            textBox1.Text = dataGridView1.Rows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.Rows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.Rows[0].Cells[3].Value.ToString();
        }

        public class Student
        {
            [BsonId]
            public ObjectId Id { get; set; }
            
            
            [BsonElement("Name")]
            public string Name { get; set; }
           
           
            [BsonElement("CourseName")]
            public string CourseName { get; set; }
           
           
            [BsonElement("Grade")]
            public string Grade { get; set; }

            public Student(string name, string courseName, string grade)
            {
                Name = name;
                CourseName = courseName;
                Grade = grade;
            }

        }
    }
}
