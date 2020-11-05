using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD_USER
{
    public partial class Form1 : Form
    {
        List<User> listUsers = new List<User>();
        public Form1()
        {
            InitializeComponent();
            InitData();
        }

        public void InitData()
        {
            this.listUsers.Add(new User()
            {
                Email = "cuanid236316@gmail.com",
                FullName = "Riabii Andrii Sergiyovich",
                Phone = "095 41 66 765",
                Image = "images/default.png"
            });

            this.listUsers.Add(new User()
            {
                Email = "nastia236316@gmail.com",
                FullName = "Riaba Nastia Setgiyovna",
                Phone = "097 67 44 121",
                Image = "images/default.png"
            });
            RefreshData();
        }

        public void RefreshData()
        {
            this.tableUsers.Rows.Clear();
            foreach (User item in listUsers)
            {
                object[] row = { false, Image.FromFile(item.Image), item.FullName, item.Email, item.Phone };
                this.tableUsers.Rows.Add(row);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddUser addUserForm = new AddUser();
            if(addUserForm.ShowDialog() == DialogResult.OK)
            {
                this.listUsers.Add(addUserForm.NewUser);
                RefreshData();
            }
        }
    }
}
