using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using Hl7.Fhir.Serialization;
using Hl7.FhirPath;

namespace IwMproject
{
    public partial class Form1 : Form
    {
        private FHIRconn connDB;

        public Form1()
        {
            InitializeComponent();
            connDB = new FHIRconn();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            if (String.IsNullOrEmpty(textBox1.Text))
            {
                List<Patient> patients = connDB.GetListOfAllPatients();

                foreach (var l in patients)
                {
                    string name;
                    try
                    {
                        name = l.Name[0].GivenElement[0].ToString();
                    }
                    catch
                    {
                        name = null;
                    }

                    if (!String.IsNullOrEmpty(name))
                    {
                        string outS = l.Id + " \t " + l.Name[0].GivenElement[0] + " \t " + l.Name[0].Family;
                        listBox1.Items.Add(outS);
                    }
                }
            }
           else
            {
                if(radioButton1.Checked)
                {
                    List<Patient> patients = connDB.GetListOfPatients(textBox1.Text);

                    foreach (var l in patients)
                    {
                        string name;
                        try
                        {
                            name = l.Name[0].GivenElement[0].ToString();
                        }
                        catch
                        {
                            name = null;
                        }

                        if (!String.IsNullOrEmpty(name))
                        {
                            string outS = l.Id + " \t " + l.Name[0].GivenElement[0] + " \t " + l.Name[0].Family;
                            listBox1.Items.Add(outS);
                        }
                    }
                }
                else
                {
                    Patient l = connDB.GetPatientByID(textBox1.Text);

                    string name;
                    try
                    {
                        name = l.Name[0].GivenElement[0].ToString();
                    }
                    catch
                    {
                        name = null;
                    }

                    if (!String.IsNullOrEmpty(name))
                    {
                        string outS = l.Id + " \t " + l.Name[0].GivenElement[0] + " \t " + l.Name[0].Family;
                        listBox1.Items.Add(outS);
                    }
                }
            }
            textBox1.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
