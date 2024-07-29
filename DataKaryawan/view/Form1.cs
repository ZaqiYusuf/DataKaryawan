using DataKaryawan.controller;
using DataKaryawan.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataKaryawan
{
    public partial class Form1 : Form
    {
        Koneksi Koneksi = new Koneksi();
        Karyawan_m karyawan =new Karyawan_m();
        string id;

        public void Tampil()
        {
            DataTable.DataSource = Koneksi.Showdata("SELECT * FROM karyawan");

            DataTable.Columns[0].HeaderText = "#";
            DataTable.Columns[1].HeaderText = "NIK";
            DataTable.Columns[2].HeaderText = "Nama Karyawan";
            DataTable.Columns[3].HeaderText = "Jabatan";
            DataTable.Columns[4].HeaderText = "Alamat";
            DataTable.Columns[5].HeaderText = "Email";
            DataTable.Columns[6].HeaderText = "Nomor Telpon";
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Memanggil Data
            Tampil();

            //List Jabatan
            //Jabatan.Items.Add("Frontend");
            //Jabatan.Items.Add("Backend");
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void DataTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            id = DataTable.Rows[e.RowIndex].Cells[0].Value.ToString();
            NIK.Text = DataTable.Rows[e.RowIndex].Cells[1].Value.ToString();
            NamaKaryawan.Text = DataTable.Rows[e.RowIndex].Cells[2].Value.ToString();
            Jabatan.Text = DataTable.Rows[e.RowIndex].Cells[3].Value.ToString();
            Alamat.Text = DataTable.Rows[e.RowIndex].Cells[4].Value.ToString();
            Email.Text = DataTable.Rows[e.RowIndex].Cells[5].Value.ToString();
            NoHp.Text = DataTable.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void Tombol_Simpan_Click(object sender, EventArgs e)
        {
            if (NamaKaryawan.Text == "" || NIK.Text == "" || Jabatan.SelectedIndex == -1 || Alamat.Text == "" || Email.Text == "" || NoHp.Text == "")
            {
                MessageBox.Show("Data Tidak Boleh Kosong!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Karyawan kr = new Karyawan();
                karyawan.Nik = NIK.Text;
                karyawan.Nama = NamaKaryawan.Text;
                karyawan.Jabatan = Jabatan.Text;
                karyawan.Alamat = Alamat.Text;
                karyawan.Email = Email.Text;
                karyawan.Nohp = NoHp.Text;

                kr.Insert(karyawan);
                NIK.Text = "";
                NamaKaryawan.Text = "";
                Jabatan.SelectedIndex = -1;
                Alamat.Text = "";
                Email.Text = "";
                NoHp.Text = "";

                Tampil();
            }
        }

        private void Tombol_Ubah_Click(object sender, EventArgs e)
        {
            if (NamaKaryawan.Text == "" || NIK.Text == "" || Jabatan.SelectedIndex == -1 || Alamat.Text == "" || Email.Text == "" || NoHp.Text == "")
            {
                MessageBox.Show("Data Tidak Boleh Kosong!", "Perhatian", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                Karyawan kr = new Karyawan();
                karyawan.Nik = NIK.Text;
                karyawan.Nama = NamaKaryawan.Text;
                karyawan.Jabatan = Jabatan.Text;
                karyawan.Alamat = Alamat.Text;
                karyawan.Email = Email.Text;
                karyawan.Nohp = NoHp.Text;

                kr.Update(karyawan, id);
                NIK.Text = "";
                NamaKaryawan.Text = "";
                Jabatan.SelectedIndex = -1;
                Alamat.Text = "";
                Email.Text = "";
                NoHp.Text = "";

                Tampil();
            }
        }

        private void Tombol_Hapus_Click(object sender, EventArgs e)
        {
            DialogResult pesan = MessageBox.Show("Yakin ingin menghapus data ini?", "Perhatian", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (pesan == DialogResult.Yes)
            {
                Karyawan kr = new Karyawan();
                kr.Delete(id);
                Tampil();
            }
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void CariData_TextChanged(object sender, EventArgs e)
        {
            DataTable.DataSource = Koneksi.Showdata("SELECT * FROM karyawan WHERE nik LIKE '%' '" + CariData.Text + "' '%' OR nama LIKE '%' '" + CariData.Text + "' '%'");
        }
    }
}
