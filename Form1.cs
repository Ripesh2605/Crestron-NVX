using System;
using System.Windows.Forms;
using System.Net.Http;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;

namespace Crestron_NVX
{
    public partial class Form1 : Form
    {
        NvxApiManager NvxApiManager;
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Ths method is called when the Login button is clicked.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Login_Click(object sender, EventArgs e)
        {
            if (Login.Text == "Login")
            {
                DisableUI();
                if (CheckCred())
                {
                    try
                    {
                        NvxApiManager = new NvxApiManager(IPAdd.Text, new MemoryCache(new MemoryCacheOptions()));

                        //BeginSession() method is called to start a session with the device.
                        HttpResponseMessage response = await NvxApiManager.BeginSession();
                        if(!response.IsSuccessStatusCode)
                        {
                            MessageBox.Show("Failed to connect to device. Please check IP Address and try again.");
                            Login.Enabled = true;
                            return;
                        }
                        //Authenticate() method is called to authenticate the user.
                        response = await NvxApiManager.Authenticate(Uname.Text, Passwrd.Text);

                        //GetAsync() method is called to get the resolution and current sync status of the device.
                        string result = await NvxApiManager.GetAsync("/Device/AudioVideoInputOutput/");

                        //The JSON response is parsed and the values are displayed on the UI.
                        dynamic json = JsonConvert.DeserializeObject(result);
                        Horizontal.Text = (String)json["AudioVideoInputOutput"]["Inputs"][0]["HorizontalResolution"];
                        Vertical.Text = (String)json["AudioVideoInputOutput"]["Inputs"][0]["VerticalResolution"];
                        SyncDetect.Text = ((bool)json["AudioVideoInputOutput"]["Inputs"][0]["IsSyncDetected"]) ? "Yes" : "No";

                        
                        Login.Enabled = true;
                        Login.Text = "Logout";
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                        Uname.Text = Passwrd.Text = IPAdd.Text = "";
                        ResetUI();
                        Login.Enabled = true;
                    }
                }
            }
            else
            {
                ///<summary>
                ///This block is called when the user clicks on Logout button.
                ///</summary>  
                ///<returns></returns>
                try
                {
                    HttpResponseMessage response = await NvxApiManager.EndSession();
                    if (response.IsSuccessStatusCode)
                    {
                        Login.Text = "Login";
                        IPAdd.Text = Uname.Text = Passwrd.Text = Horizontal.Text = Vertical.Text = SyncDetect.Text = "";
                        ResetUI();
                    }
                    else
                    {
                        throw new Exception("Failed to logout. Please try again.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    IPAdd.Text = Uname.Text = Passwrd.Text = Horizontal.Text = Vertical.Text = SyncDetect.Text = "";
                    ResetUI();

                }
            }
        }

        /// <summary>
        /// This method is called to validate the credentials entered by the user.
        /// </summary>
        /// <returns></returns>
        private bool CheckCred()
        {
            
            if (IPAdd.Text == "" || !ValidateIPAddress(IPAdd.Text))
            {
                MessageBox.Show("Please enter valid IP Address");
                ResetUI();
                return false;
            }
            
            if (Uname.Text == "")
            {
                MessageBox.Show("Please enter username. ");
                ResetUI();
                return false;
            }

            if (Passwrd.Text == "")
            {
                MessageBox.Show("Please enter password. ");
                ResetUI();
                return false;
            }
            
            return true;
        }

        /// <summary>
        /// This method validates the IP Address entered by the user.
        /// </summary>
        /// <param name="ipaddress"></param>
        /// <returns></returns>
        private bool ValidateIPAddress(string ipaddress)
        {
            var regex = new System.Text.RegularExpressions.Regex(@"^(?:[0-9]{1,3}\.){3}[0-9]{1,3}$");
            return regex.IsMatch(ipaddress);
        }

        //Disables UI elements
        private void DisableUI()
        {
            Uname.Enabled = Passwrd.Enabled = IPAdd.Enabled = Login.Enabled = false;
        }

        //Resets UI elements
        private void ResetUI()
        {
            Uname.Enabled = Passwrd.Enabled = IPAdd.Enabled = Login.Enabled = true;
        }
    }
}
