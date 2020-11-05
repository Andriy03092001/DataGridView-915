using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_USER
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private User _user;
        public User NewUser { 
            get 
            {
                return _user;
            }
            private set
            {
                _user = value;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if(
                !String.IsNullOrEmpty(this.txtEmail.Text) &&
                !String.IsNullOrEmpty(this.txtFullName.Text) &&
                !String.IsNullOrEmpty(this.txtImage.Text) &&
                !String.IsNullOrEmpty(this.txtPhone.Text))
            {
                Random random = new Random();
                string NamePhoto = "";

                while (NamePhoto.Length < 20)
                {
                    char c = (char)random.Next(30, 200);
                    if(char.IsLetterOrDigit(c))
                    {
                        NamePhoto += c;
                    }
                }

                FileStream fsRead = File.OpenRead(this.txtImage.Text);
                string path = @"images\" + NamePhoto + ".jpg";  // image/829f98d79d98f.jpg
                FileStream fsWrite = File.Open(path, FileMode.Create);

                long fileSize = fsRead.Length;
                int i = 0;
                while (i < fileSize)
                {
                    byte temp = (byte)fsRead.ReadByte();
                    fsWrite.WriteByte(temp);
                    i++;
                }

                this._user = new User()
                {
                    Email = this.txtEmail.Text,
                    FullName = this.txtFullName.Text,
                    Image = path,
                    Phone = this.txtPhone.Text
                };
                this.DialogResult = DialogResult.OK;
                fsRead.Close();
                fsWrite.Close();
                this.Close();
               
            }
            else
            {
                MessageBox.Show("Error: Please, enter all fields!");
            }
        }

        private void btnChooseImage_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtImage.Text = ofd.FileName;
                this.userAvatar.Image = Image.FromFile(ofd.FileName);
            }
        }
    }
}
