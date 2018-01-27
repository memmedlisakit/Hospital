using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_app
{
    public partial class SearchForm : Form
    {
        private PatintDBEntities db = new PatintDBEntities();
        string path = @"C:\Users\Sakit\source\repos\Hospital_app\Hospital_app\Uploads\";
        public static Patient selectedPatient;

        public SearchForm()
        {
            InitializeComponent();
            this.Fill_cmb();
            this.btnSearch.Click += new EventHandler(this.SearchPatient);
        }

       


        private void SearchPatient(object sender, EventArgs e)
        {
            if (txt_account_no.Text == "" && txt_file_no.Text == "" && txt_first_name.Text == "" &&
                txt_permanent_address.Text == "" && txt_surname.Text == "" && cmb_religion.Text == "" && 
                dtp_date_of_birth.Value.ToString("dd/MM/yyyy") == DateTime.Now.ToString("dd/MM/yyyy"))
            {
                List<Patient> pats = db.Patients.ToList();
                this.Fill_dgw_patient_data(pats);
            }
            else
            {
                int accountNumber = this.Converter(txt_account_no.Text);
                if (txt_account_no.Text != "" && accountNumber == 0) 
                {
                    this.lblError.Text = "Account number must be number";
                    return;
                }
                

                List<Patient> newPatients = db.Patients.Where(p =>
                p.account_number == accountNumber ||
                p.date_of_birth == dtp_date_of_birth.Value||
                p.permanent_adress == txt_permanent_address.Text||
                p.surname == txt_surname.Text ||
                p.first_name == txt_first_name.Text ||
                p.Religion.religion_name == cmb_religion.Text ||
                p.old_file_number == txt_file_no.Text
                ).ToList();


                this.Fill_dgw_patient_data(newPatients);
            }

            this.Cleaner();
        }

        private int Converter(string input)
        {
            int number = 0;
            Int32.TryParse(input, out number);
            return number;
        }

        private void Fill_dgw_patient_data(List<Patient> patients)
        {
            this.dgwPatientData.Rows.Clear();
            for(int i = 0; i < patients.Count; i++)
            {
                this.dgwPatientData.Rows.Add();
                this.dgwPatientData.Rows[i].Cells[0].Value = patients[i].id;
                this.dgwPatientData.Rows[i].Cells[1].Value = patients[i].account_number;
                this.dgwPatientData.Rows[i].Cells[2].Value = patients[i].old_file_number;
                this.dgwPatientData.Rows[i].Cells[3].Value = patients[i].first_name;
                this.dgwPatientData.Rows[i].Cells[4].Value = patients[i].surname;
                this.dgwPatientData.Rows[i].Cells[5].Value = patients[i].gender_type == true ? "Male" : "Female";
                this.dgwPatientData.Rows[i].Cells[6].Value = patients[i].Material_Status.materil_name;
                this.dgwPatientData.Rows[i].Cells[7].Value = patients[i].date_of_birth.ToString("dd/MM/yyyy");
                this.dgwPatientData.Rows[i].Cells[8].Value = patients[i].Religion.religion_name;
                this.dgwPatientData.Rows[i].Cells[9].Value = patients[i].Occupation.occupation_name;
                this.dgwPatientData.Rows[i].Cells[10].Value = patients[i].permanent_adress;
                this.dgwPatientData.Rows[i].Cells[11].Value = patients[i].Patient_Family.full_name;
            }
        }

        private void Fill_cmb()
        {
            List<Religion> religions = db.Religions.ToList();
            foreach (Religion item in religions)
            {
                this.cmb_religion.Items.Add(item.religion_name);
            }
        }

        private void Cleaner()
        {
            this.txt_account_no.Text = "";
            this.txt_file_no.Text = "";
            this.txt_first_name.Text = "";
            this.txt_permanent_address.Text = "";
            this.txt_surname.Text = "";
            this.cmb_religion.SelectedIndex=-1;
            this.dtp_date_of_birth.Value = DateTime.Now;
        }

        private void Upadet_or_Delete(object sender, DataGridViewCellMouseEventArgs e)
        {
            int id = (int)this.dgwPatientData.Rows[e.RowIndex].Cells[0].Value;
            selectedPatient = db.Patients.Find(id);
            PatientForm fo = new PatientForm();
            fo.txt_p_firstname.Text = selectedPatient.first_name;
            fo.txt_p_home_addres.Text = selectedPatient.home_adress;
            fo.txt_p_middlename.Text = selectedPatient.middle_name;
            fo.txt_p_permanet_address.Text = selectedPatient.permanent_adress;
            fo.txt_p_surname.Text = selectedPatient.surname;
            fo.txt_p_tribe.Text = selectedPatient.tribe;
            fo.txt_old_file_number.Text = selectedPatient.old_file_number;
            fo.txt_account_no.Text = selectedPatient.account_number.ToString();
            fo.cmb_patient_category.Text = selectedPatient.Patient_Category.patient_category_name;
            fo.cmb_p_materila_sts.Text = selectedPatient.Material_Status.materil_name;
            fo.cmb_p_occuption.Text = selectedPatient.Occupation.occupation_name;
            fo.cmb_p_relation.Text = selectedPatient.Religion.religion_name;
            fo.cmb_p_state_of_origin.Text = selectedPatient.State_of_Origin.state_of_origin_name;
            fo.cmb_p_title.Text = selectedPatient.Title.title_name;
            fo.dtp_p_date_of_birth.Value = selectedPatient.date_of_birth;
            fo.p_male.Checked = selectedPatient.gender_type == true ? true : false;
            fo.p_female.Checked = selectedPatient.gender_type == true ? false : true;
            fo.cmb_card_type.Text = selectedPatient.Card_Type.card_type_name;
            fo.cmb_existing_accounts.Text = selectedPatient.Existing_Account.existing_account_name;
            fo.txt_f_address.Text = selectedPatient.Patient_Family.adress;
            fo.txt_f_fullname.Text = selectedPatient.Patient_Family.full_name;
            fo.txt_f_phone.Text = selectedPatient.Patient_Family.phone;
            fo.txt_f_relationship.Text = selectedPatient.Patient_Family.relitionship_with_patient;
            fo.cmb_f_state_of_origin.Text = selectedPatient.Patient_Family.State_of_Origin.state_of_origin_name;
            fo.f_male.Checked = selectedPatient.Patient_Family.gender_type == true ? true : false;
            fo.f_female.Checked = selectedPatient.Patient_Family.gender_type == true ? false : true;
            fo.ckb_f_same_as_patient.Checked = (bool)selectedPatient.Patient_Family.same_as_patient;
            fo.pct_p_patient.Image = selectedPatient.photo == null ? null : Image.FromFile(path + selectedPatient.photo);
            fo.btnSave.Visible = false;
            fo.btnSearch.Visible = false;
            fo.btnUpdate.Visible = true;
            fo.btnDelete.Visible = true;
            fo.ShowDialog();
            this.Dispose();
        }
    }
}
