using System.Configuration;

namespace WebLiveWallpapers
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        //  Load
        private void Form2_Load(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            string bootable = config.AppSettings.Settings["Bootable"].Value;
            if (bootable == "0")
            {
                this.checkBox1.Checked = false;
            }
            else
            {
                this.checkBox1.Checked = true;
            }
        }
        //  Save
        private void button1_Click(object sender, EventArgs e)
        {
            Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            if (this.checkBox1.Checked == true)
            {
                config.AppSettings.Settings["name"].Value = "1";
                SelfStarting.SetMeAutoStart(true);
            }
            else
            {
                config.AppSettings.Settings["name"].Value = "0";
                SelfStarting.SetMeAutoStart(false);
            }
            config.Save(ConfigurationSaveMode.Modified);
            ConfigurationManager.RefreshSection("appSettings");
        }
    }
}
