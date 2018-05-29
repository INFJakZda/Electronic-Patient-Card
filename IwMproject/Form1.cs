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
           if(String.IsNullOrEmpty(textBox1.Text))
            {
                List<Patient> patients = connDB.GetListOfAllPatients();

                foreach (var l in patients)
                {
                    int numberPatient = 0;
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
                        string outS = numberPatient + ". " + l.Id + " \t " + l.Name[0].GivenElement[0] + " \t " + l.Name[0].Family;
                        listBox1.Items.Add(outS);
                        numberPatient += 1;
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
