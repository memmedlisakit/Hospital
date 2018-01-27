using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hospital_app
{
    public partial class PatientForm : Form
    {
        private PatintDBEntities db = new PatintDBEntities();
        OpenFileDialog file = new OpenFileDialog();
        private bool checking = false;

        public PatientForm()
        {
            InitializeComponent();
            this.FillAllCmb();
            this.btnSave.Click += new  EventHandler(this.AddPatient);
            this.lbl_p_browse.Click += new EventHandler(this.ShowUload);
            this.btnSearch.Click += new EventHandler(this.OpenSearchForm);
            this.btnDelete.Click += new EventHandler(this.Delete);
            this.btnUpdate.Click += new EventHandler(this.Update);
        }

        private void OpenSearchForm(object sender, EventArgs e)
        {
            SearchForm form = new SearchForm();
            form.ShowDialog();
        }
        
        private void AddPatient(object sender, EventArgs e)
        {
            if (this.Checking() == true)
            {
                if(p_male.Checked == true || p_female.Checked == true)
                {
                    if(f_male.Checked == true || f_female.Checked == true)
                    {
                        string p_photo_name = null;
                        string upload_path = null;
                        bool f_gender = false;
                        bool p_gender = false;
                        if (this.f_male.Checked == true)
                        {
                            f_gender = true;
                        }
                        if (this.p_male.Checked == true)
                        {
                            p_gender = true;
                        }
                        int f_origin = db.State_of_Origin.FirstOrDefault(s => s.state_of_origin_name == this.cmb_f_state_of_origin.Text).id;


                        int p_account_number = Convert.ToInt32(txt_account_no.Text);
                        int count = db.Patients.Where(p => p.account_number == p_account_number).Count();
                        if (count > 0)
                        {
                            this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                            this.lblError.Text = "Alredy exixtis this number patient.";
                            return;
                        }
                        // add patient family.
                        Patient_Family family = new Patient_Family();
                        family.full_name = this.txt_f_fullname.Text;
                        family.gender_type = f_gender;
                        family.state_of_origin_id = f_origin;
                        family.phone = this.txt_f_phone.Text;
                        family.adress = this.txt_f_address.Text;
                        family.same_as_patient = this.ckb_f_same_as_patient.Checked;
                        family.relitionship_with_patient = this.txt_f_relationship.Text;
                        db.Patient_Family.Add(family);
                        db.SaveChanges();


                        if (checking == true)
                        {
                            p_photo_name = DateTime.Now.ToString("yyyyddMMssmmHH") + file.SafeFileName;
                            upload_path = @"C:\Users\Sakit\source\repos\Hospital_app\Hospital_app\Uploads\" + p_photo_name;
                        }




                        int p_famly_id = db.Patient_Family.FirstOrDefault(f => f.full_name == family.full_name).id;
                        int p_title_id = db.Titles.FirstOrDefault(t => t.title_name == cmb_p_title.Text).id;
                        int p_material_id = db.Material_Status.FirstOrDefault(m => m.materil_name == cmb_p_materila_sts.Text).id;
                        int p_origin = db.State_of_Origin.FirstOrDefault(s => s.state_of_origin_name == this.cmb_p_state_of_origin.Text).id;
                        int p_religion_id = db.Religions.FirstOrDefault(r => r.religion_name == cmb_p_relation.Text).id;
                        int p_occupation_id = db.Occupations.FirstOrDefault(o => o.occupation_name == cmb_p_occuption.Text).id;
                        int p_card_type_id = db.Card_Type.FirstOrDefault(c => c.card_type_name == cmb_card_type.Text).id;
                        int p_patient_catgory_id = db.Patient_Category.FirstOrDefault(p => p.patient_category_name == cmb_patient_category.Text).id;
                        int p_account_id = db.Existing_Account.FirstOrDefault(a => a.existing_account_name == cmb_existing_accounts.Text).id;
                       
                        // add patient
                        Patient pat = new Patient();
                        pat.title_id = p_title_id;
                        pat.first_name = txt_p_firstname.Text;
                        pat.middle_name = txt_p_middlename.Text;
                        pat.surname = txt_p_surname.Text;
                        pat.gender_type = p_gender;
                        pat.material_id = p_material_id;
                        pat.date_of_birth = dtp_p_date_of_birth.Value;
                        pat.state_of_origin_id = p_origin;
                        pat.tribe = txt_p_tribe.Text;
                        pat.religion_id = p_religion_id;
                        pat.occupation_id = p_occupation_id;
                        pat.permanent_adress = txt_p_permanet_address.Text;
                        pat.home_adress = txt_p_home_addres.Text;
                        pat.photo = p_photo_name;
                        pat.family_id = p_famly_id;
                        pat.old_file_number = txt_old_file_number.Text;
                        pat.card_type_id = p_card_type_id;
                        pat.patient_category_id = p_patient_catgory_id;
                        pat.existing_account_id = p_account_id;
                        pat.account_number = p_account_number;
                        db.Patients.Add(pat);
                        db.SaveChanges();
                        this.lblError.ForeColor = Color.FromArgb(128, 255, 128);
                        this.lblError.Text = "Added successful.";
                        this.Cleaner();


                        if (file.FileName != "")
                        {
                            WebClient webclient = new WebClient();
                            webclient.DownloadFile(file.FileName, upload_path);
                        }                      

                    }
                    else
                    {
                        this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                        this.lblError.Text = "Do not empty";
                    }
                }
                else
                {
                    this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                    this.lblError.Text = "Do not empty";
                } 
            }
            else
            {
                this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                this.lblError.Text = "Do not empty";
            }
            
        }

        private void FillAllCmb()
        {
            List<State_of_Origin> origins = db.State_of_Origin.ToList();
            List<Title> titles = db.Titles.ToList();
            List<Religion> religiens =db.Religions.ToList();
            List<Patient_Category> p_categories = db.Patient_Category.ToList();
            List<Occupation> occupations = db.Occupations.ToList();
            List<Material_Status> mat_status = db.Material_Status.ToList();
            List<Existing_Account> accounts = db.Existing_Account.ToList();
            List<Card_Type> card_types = db.Card_Type.ToList();
            foreach (State_of_Origin item in origins)
            {
                this.cmb_p_state_of_origin.Items.Add(item.state_of_origin_name);
            }
            foreach (State_of_Origin item in origins)
            {
                this.cmb_f_state_of_origin.Items.Add(item.state_of_origin_name);
            }
            foreach (Title item in titles)
            {
                this.cmb_p_title.Items.Add(item.title_name);
            }
            foreach (Religion item in religiens)
            {
                this.cmb_p_relation.Items.Add(item.religion_name);
            }
            foreach (Patient_Category item in p_categories)
            {
                this.cmb_patient_category.Items.Add(item.patient_category_name);
            }
            foreach (Occupation item in occupations)
            {
                this.cmb_p_occuption.Items.Add(item.occupation_name);
            }
            foreach (Material_Status item in mat_status)
            {
                this.cmb_p_materila_sts.Items.Add(item.materil_name);
            }
            foreach (Existing_Account item in accounts)
            {
                this.cmb_existing_accounts.Items.Add(item.existing_account_name);
            }
            foreach (Card_Type item in card_types)
            {
                this.cmb_card_type.Items.Add(item.card_type_name);
            }

        }

        private bool Checking()
        {
            if(txt_p_firstname.Text==""||txt_p_middlename.Text==""||txt_p_surname.Text==""||
               cmb_p_materila_sts.Text==""||cmb_p_relation.Text==""||cmb_p_occuption.Text==""||
               txt_p_permanet_address.Text==""||txt_p_home_addres.Text==""||cmb_p_state_of_origin.Text==""||
               cmb_f_state_of_origin.Text==""|| txt_f_fullname.Text==""|| txt_f_phone.Text==""||txt_f_address.Text==""||
               txt_f_relationship.Text==""|| cmb_card_type.Text==""||cmb_patient_category.Text==""||txt_account_no.Text=="0"||
               txt_old_file_number.Text =="0"||cmb_p_title.Text==""||txt_p_tribe.Text==""||cmb_existing_accounts.Text==""
                )
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        private void ShowUload(object sender, EventArgs e)
        {
            file.ShowDialog();
            if (file.FileName != "")
            {
                this.pct_p_patient.Image = Image.FromFile(file.FileName);
                checking = true;
            }
        }

        private void Cleaner()
        {
            this.txt_account_no.Text = "";
            this.txt_f_address.Text = "";
            this.txt_f_fullname.Text = "";
            this.txt_f_phone.Text = "";
            this.txt_f_relationship.Text = "";
            this.txt_old_file_number.Text = "";
            this.txt_p_firstname.Text = "";
            this.txt_p_home_addres.Text = "";
            this.txt_p_middlename.Text = "";
            this.txt_p_permanet_address.Text = "";
            this.txt_p_surname.Text = "";
            this.txt_p_tribe.Text = "";
            this.cmb_card_type.SelectedIndex = -1;
            this.cmb_existing_accounts.SelectedIndex = -1;
            this.cmb_f_state_of_origin.SelectedIndex = -1;
            this.cmb_patient_category.SelectedIndex = -1;
            this.cmb_p_materila_sts.SelectedIndex = -1;
            this.cmb_p_occuption.SelectedIndex = -1;
            this.cmb_p_relation.SelectedIndex = -1;
            this.cmb_p_state_of_origin.SelectedIndex = -1;
            this.cmb_p_title.SelectedIndex = -1;
            this.dtp_p_date_of_birth.Value = DateTime.Now;
            this.p_male.Checked = false;
            this.p_female.Checked = false;
            this.f_male.Checked = false;
            this.f_female.Checked = false;
            this.ckb_f_same_as_patient.Checked = false;
            this.pct_p_patient.Image = Image.FromFile(@"C:\Users\Sakit\source\repos\Hospital_app\Hospital_app\Uploads\patient.png");
            this.lblError.Text = "";
            this.btnSave.Visible = true;
            this.btnSearch.Visible = true;
            this.btnUpdate.Visible = false;
            this.btnDelete.Visible = false;
        }

        private void Update(object sender, EventArgs e)
        {
            Patient_Family family = db.Patient_Family.Find(SearchForm.selectedPatient.family_id);
            Patient patient = db.Patients.Find(SearchForm.selectedPatient.id);
            if (this.Checking() == true)
            {
                if (p_male.Checked == true || p_female.Checked == true)
                {
                    if (f_male.Checked == true || f_female.Checked == true)
                    {
                        string p_photo_name = null;
                        string upload_path = null;
                        bool f_gender = false;
                        bool p_gender = false;
                        if (this.f_male.Checked == true)
                        {
                            f_gender = true;
                        }
                        if (this.p_male.Checked == true)
                        {
                            p_gender = true;
                        }
                        int f_origin = db.State_of_Origin.FirstOrDefault(s => s.state_of_origin_name == this.cmb_f_state_of_origin.Text).id;


                        int p_account_number = Convert.ToInt32(txt_account_no.Text);
                        int count = db.Patients.Where(p => p.account_number == p_account_number).Count();
                        if (count > 0)
                        {
                            this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                            this.lblError.Text = "Alredy exixtis this number patient.";
                            return;
                        }
                        // add patient family.
                        family.full_name = this.txt_f_fullname.Text;
                        family.gender_type = f_gender;
                        family.state_of_origin_id = f_origin;
                        family.phone = this.txt_f_phone.Text;
                        family.adress = this.txt_f_address.Text;
                        family.same_as_patient = this.ckb_f_same_as_patient.Checked;
                        family.relitionship_with_patient = this.txt_f_relationship.Text;
                        db.SaveChanges();


                        if (checking == true)
                        {
                            p_photo_name = DateTime.Now.ToString("yyyyddMMssmmHH") + file.SafeFileName;
                            upload_path = @"C:\Users\Sakit\source\repos\Hospital_app\Hospital_app\Uploads\" + p_photo_name;
                        }




                        int p_famly_id = db.Patient_Family.FirstOrDefault(f => f.full_name == family.full_name).id;
                        int p_title_id = db.Titles.FirstOrDefault(t => t.title_name == cmb_p_title.Text).id;
                        int p_material_id = db.Material_Status.FirstOrDefault(m => m.materil_name == cmb_p_materila_sts.Text).id;
                        int p_origin = db.State_of_Origin.FirstOrDefault(s => s.state_of_origin_name == this.cmb_p_state_of_origin.Text).id;
                        int p_religion_id = db.Religions.FirstOrDefault(r => r.religion_name == cmb_p_relation.Text).id;
                        int p_occupation_id = db.Occupations.FirstOrDefault(o => o.occupation_name == cmb_p_occuption.Text).id;
                        int p_card_type_id = db.Card_Type.FirstOrDefault(c => c.card_type_name == cmb_card_type.Text).id;
                        int p_patient_catgory_id = db.Patient_Category.FirstOrDefault(p => p.patient_category_name == cmb_patient_category.Text).id;
                        int p_account_id = db.Existing_Account.FirstOrDefault(a => a.existing_account_name == cmb_existing_accounts.Text).id;

                        // add patient
                        patient.title_id = p_title_id;
                        patient.first_name = txt_p_firstname.Text;
                        patient.middle_name = txt_p_middlename.Text;
                        patient.surname = txt_p_surname.Text;
                        patient.gender_type = p_gender;
                        patient.material_id = p_material_id;
                        patient.date_of_birth = dtp_p_date_of_birth.Value;
                        patient.state_of_origin_id = p_origin;
                        patient.tribe = txt_p_tribe.Text;
                        patient.religion_id = p_religion_id;
                        patient.occupation_id = p_occupation_id;
                        patient.permanent_adress = txt_p_permanet_address.Text;
                        patient.home_adress = txt_p_home_addres.Text;
                        patient.photo = p_photo_name == null ? patient.photo : p_photo_name;
                        patient.family_id = p_famly_id;
                        patient.old_file_number = txt_old_file_number.Text;
                        patient.card_type_id = p_card_type_id;
                        patient.patient_category_id = p_patient_catgory_id;
                        patient.existing_account_id = p_account_id;
                        patient.account_number = p_account_number;
                        db.SaveChanges();
                        this.lblError.ForeColor = Color.FromArgb(128, 255, 128);
                        this.lblError.Text = "Updated successful.";
                        this.Cleaner();


                        if (file.FileName != "")
                        {
                            WebClient webclient = new WebClient();
                            webclient.DownloadFile(file.FileName, upload_path);
                        }
                    }
                    else
                    {
                        this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                        this.lblError.Text = "Do not empty";
                    }
                }
                else
                {
                    this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                    this.lblError.Text = "Do not empty";
                }
            }
            else
            {
                this.lblError.ForeColor = Color.FromArgb(255, 128, 128);
                this.lblError.Text = "Do not empty";
            }

        }

        private void Delete(object sender, EventArgs e)
        {
            Patient_Family family = db.Patient_Family.Find(SearchForm.selectedPatient.family_id);
            Patient patient = db.Patients.Find(SearchForm.selectedPatient.id);
            db.Patients.Remove(patient);
            db.Patient_Family.Remove(family);
            db.SaveChanges();
            this.Cleaner();
        }
    }
}
