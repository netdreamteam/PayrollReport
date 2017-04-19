using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace MainUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) || string.IsNullOrEmpty(textBox2.Text))
            {
                MessageBox.Show("用户名密码不能为空", "提示");
                return;
            }
            if (!File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory,"config.txt")))
            {
                MessageBox.Show("用户名或密码不存在", "提示");
                return;
            }
            List<string> s=File.ReadLines("config.txt").ToList();
            if (s.Count<2)
            {
                MessageBox.Show("用户名或密码不存在","提示");
                return;
            }
            if (s[0].Trim().CompareTo(textBox1.Text)==0&& s[1].Trim().CompareTo(textBox2.Text)==0)
            {
                MainUI ui = new MainUI();
                this.Hide();
                ui.Show();
            }
            else
            {
                MessageBox.Show("用户名或密码错误", "提示");
            }
            
            
        }

        private void Login_Load(object sender, EventArgs e)
        {
            List<string> s = File.ReadLines("config.txt").ToList();
            textBox1.Text = s[0].Trim();
            //textBox2.Text = s[1].Trim();
        }
    }
}
