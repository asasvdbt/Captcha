using System;
using System.Windows.Forms;

namespace WindowsFormsApp16
{
    public partial class CaptchForm : Form
    {
        // Переменные
        private string captchaCode;
        private Random rand = new Random();
        private string chars = "0123456789АБВГДЕЕЖЗИИКЛМН" + "ОПРСТУФХЦЧШЩЬЫЬЭЮЯабвгдеёжзийклмнопрстуфхцчшщьыьэюя";

        public CaptchForm()
        {
            InitializeComponent();
        }

        // При загрузке формы
        private void CaptchForm_Load(object sender, EventArgs e)
        {
            CreateCaptcha();
            timer1.Interval = 10000; // обновлять каждые 10 секунд
            timer1.Start();
        }

        // Кнопка "Обновить"
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            CreateCaptcha();
        }

        // Таймер — обновляет капчу автоматически
        private void timer1_Tick(object sender, EventArgs e)
        {
            CreateCaptcha();
        }

        // Проверка введённого текста
        private void textBoxCaptcha_TextChanged(object sender, EventArgs e)
        {
            if (textBoxCaptcha.Text == captchaCode)
            {
                MessageBox.Show("Captcha введена верно!");
                this.Close();
            }
        }

        // Генерация новой капчи
        private void CreateCaptcha()
        {
            captchaCode = "";

            for (int i = 0; i < 5; i++)
                captchaCode += chars[rand.Next(chars.Length)];

            labelCaptcha.Text = captchaCode;
        }
    }
}
