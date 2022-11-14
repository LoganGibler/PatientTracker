using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace PatientSorter
{
    public partial class Form1 : Form
    {
        myDBconnection con = new myDBconnection();
        MySqlCommand command;
        MySqlDataAdapter da;
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            con.Connect();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        // GET ALL PATIENTS
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                con.cn.Open();
                command = new MySqlCommand("Select * from patients", con.cn);
                //command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();
            }
            catch (Exception)
            {
                throw;
            }
        }


        // GET PATIENT BY NAME
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                
                con.cn.Open();
                button3.Enabled = false;
                string name = textBox1.Text;
                command = new MySqlCommand($"Select * from patients where `Patient Name`='" + name + "'" , con.cn);
                command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                con.cn.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("User Doesnt Exist");
            }
            finally
            {
                button3.Enabled = true;
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        //SIGN IN PATIENT
        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                
                con.cn.Open();
                button2.Enabled = false;
                string name = textBox1.Text;
                string buildingLetter = textBox2.Text;
                string floorNum = textBox3.Text;
                string roomNum = textBox4.Text;
                string doctorAssigned = textBox5.Text;
                string department = textBox6.Text;
                string doctorsNotes = textBox7.Text;
                command = new MySqlCommand($"INSERT INTO `patients`(`Patient Name`, `Building Letter`, `Floor num`, `Room num`, `Doctor Assigned`, `Department`, `Doctors Notes`) VALUES ('{name}','{buildingLetter}','{floorNum}','{roomNum}','{doctorAssigned}','{department}','{doctorsNotes}')", con.cn);
                //command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                MessageBox.Show("Patient Signed in.");

                con.cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                button2.Enabled = true;
            }
        }

        // SIGN OUT PATIENT
        private void button4_Click(object sender, EventArgs e)
        {
            try
            {

                con.cn.Open();
                button4.Enabled = false;
                string name = textBox1.Text;
                
                command = new MySqlCommand($"DELETE FROM `patients` WHERE `Patient Name`='{name}'", con.cn);
                //command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                MessageBox.Show("Patient Signed Out.");

                con.cn.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Patient does not exist.");
                throw;
            }
            finally
            {
                button4.Enabled = true;
            }
        }

        //update patient info
        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

                con.cn.Open();
                button5.Enabled = false;
                string name = textBox1.Text;
                string buildingLetter = textBox2.Text;
                string floorNum = textBox3.Text;
                string roomNum = textBox4.Text;
                string doctorAssigned = textBox5.Text;
                string department = textBox6.Text;
                string doctorsNotes = textBox7.Text;
                command = new MySqlCommand($"UPDATE `patients` SET `Patient Name`='{name}',`Building Letter`='{buildingLetter}',`Floor num`='{floorNum}',`Room num`='{roomNum}',`Doctor Assigned`='{doctorAssigned}',`Department`='{department}',`Doctors Notes`='{doctorsNotes}' WHERE `Patient Name`='{name}'", con.cn);
                //command.ExecuteNonQuery();
                dt = new DataTable();
                da = new MySqlDataAdapter(command);
                da.Fill(dt);
                dataGridView1.DataSource = dt.DefaultView;
                MessageBox.Show("Patient Info Updated.");

                con.cn.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                button5.Enabled = true;
            }
        }
    }
}
