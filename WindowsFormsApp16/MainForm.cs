using System;
using System.Linq;
using System.Windows.Forms;
using WindowsFormsApp16.Models; // имя проекта и папки с моделью
using WindowsFormsApp16.Models;

namespace WindowsFormsApp16
{
    public partial class MainForm : Form
    {
        ModelEF db = new ModelEF();
        int failedAttempts = 0;

        public MainForm()
        {
            InitializeComponent();
        }

        private void buttonEnter_Click(object sender, EventArgs e)
        {
            string login = textBoxLogin.Text;
            string password = textBoxPassword.Text;

            var user = db.Users.FirstOrDefault(u => u.Login == login && u.Password == password);

            if (user != null)
            {
                MessageBox.Show("Добро пожаловать, " + user.Login + "!");
                failedAttempts = 0;
            }
            else
            {
                failedAttempts++;
                MessageBox.Show("Неверный логин или пароль!");

                if (failedAttempts >= 1)
                {
                    CaptchForm captchaForm = new CaptchForm();
                    captchaForm.ShowDialog();
                    failedAttempts = 0;
                }
            }
        }
    }
}
