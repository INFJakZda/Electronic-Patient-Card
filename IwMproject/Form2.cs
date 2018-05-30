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
    public partial class Form2 : Form
    {
        private FHIRconn connDB;
        private string _arg;

        public Form2()
        {
            InitializeComponent();
            connDB = new FHIRconn();
        }

        public Form2(string arg)
        {
            _arg = arg;
            InitializeComponent();
            connDB = new FHIRconn();

            Patient l = connDB.GetPatientByID(arg);
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
                string outS = l.Id + "---" + l.Name[0].GivenElement[0] + "---" + l.Name[0].Family;
                listBox1.Items.Add(outS);
            }
        }
    }
}
