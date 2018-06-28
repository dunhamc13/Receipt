using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.Net;
using Octokit;
using System.Reflection;

namespace ReceiptTransformer
{
    public partial class frmReceiptTransformer : Form
    {
        string[] lines;
        const string VERSION_NUMBER = "1.1";
        public frmReceiptTransformer()
        {
            //http://adamthetech.com/2011/06/embed-dll-files-within-an-exe-c-sharp-winforms/
            AppDomain.CurrentDomain.AssemblyResolve += (sender, args) =>
            {
                string resourceName = new AssemblyName(args.Name).Name + ".dll";
                string resource = Array.Find(this.GetType().Assembly.GetManifestResourceNames(), element => element.EndsWith(resourceName));

                using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resource))
                {
                    Byte[] assemblyData = new Byte[stream.Length];
                    stream.Read(assemblyData, 0, assemblyData.Length);
                    return Assembly.Load(assemblyData);
                }
            };
            InitializeComponent();
        }

        private async void CheckForUpdateAsync()
        {
            var client = new GitHubClient(new ProductHeaderValue("ReceiptTransformer"));
            
            var latestRelease = await client.Repository.Release.GetLatest("olympiancode", "ReceiptTransformer");
            if (latestRelease.TagName != VERSION_NUMBER)
            {
                linkNewVersion.Visible = true;
                linkNewVersion.Enabled = true;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            ResetForm();
            openFileDialog1.ShowDialog();
            txtFilePath.Text = openFileDialog1.FileName;
            OpenFile(txtFilePath.Text);
        }

        private void OpenFile(string path)
        {
            try
            {
                lines = System.IO.File.ReadAllLines(path); // get file into string array
            }
            catch (ArgumentException ae)
            {
                //don't do anything, stop processing
                return;
            }
            foreach (string line in lines)
            {
                txtInput.Text += line + "\r\n";
            }
            Transform();
        }

        private void btnTransform_Click(object sender, EventArgs e)
        {
            Transform();
        }

        private void Transform()
        {
            bool skippingCoupons = false;

            if (lines == null)
                lines = txtInput.Text.Split('\n'); // get text into string array
            if (lines.Length == 0)
                MessageBox.Show("Please open a transaction file or paste the contents in.");
            List<string> dpcis = new List<string>(); //init list to catch dpcis
            int count = 0;//init count
            for (int i = 0; i < lines.Length; i++)//for every line of the receipt
            {

                try
                {
                    string thisLine = lines[i];//iteration variable
                    //additional test to see if a phone is being activated.  If it is, remove the last dpci added
                    if (thisLine == "    PREPAID SERVICE ACTIVATION              " || thisLine == "    PREPAID SERVICE ACTIVATION              \r")
                        dpcis.RemoveAt(dpcis.Count - 1);

                    if (thisLine == "*** START COUPON RESPONSE PROCESSING ***    " || thisLine == "*** START COUPON RESPONSE PROCESSING ***    \r")
                        skippingCoupons = true;
                    else if (thisLine == "*** END COUPON RESPONSE PROCESSING ***      " || thisLine == "*** END COUPON RESPONSE PROCESSING ***      \r")
                        skippingCoupons = false;
                    if (!skippingCoupons)
                    {
                        Regex dpciPattern = new Regex(@"\d{3}:[SK]\d{9}\s"); //regex pattern for dpci - whitespace at end ensures it doesn't get a cartwheel code
                        Regex discountPattern = new Regex(@"\s-\d{1,3}\.\d{2}-\s");//pattern for negative price
                        if (dpciPattern.IsMatch(thisLine.Substring(0, 15)))//if this line has a dpci
                        {
                            //only proceed if the line doesn't contain adjust coupon
                            //and if the line doesn't subtract from the subtotal (coupon or cartwheel discount applied to a specific dpci)
                            if (!thisLine.ToUpper().Contains("ADJST COUPON") && !discountPattern.Match(thisLine).Success)
                            {
                                //grab the dpci
                                string thisDpci = thisLine.Substring(5, 3) + "-" + thisLine.Substring(8, 2) + "-" + thisLine.Substring(10, 4);
                                //check if it's a paper bag fee
                                if (thisDpci == "004-10-0001")
                                {
                                    continue;
                                }
                                //if this line is not voiding a dpci
                                if (!thisLine.Contains("*VOID LINE*"))
                                {
                                    //add it and increment the counter
                                    dpcis.Add(thisDpci);
                                    count++;
                                }
                                else
                                {//else remove it and decrement the counter
                                    dpcis.Remove(thisDpci);
                                    count--;
                                }
                            }
                        }
                    }
                }
                catch (ArgumentOutOfRangeException aoore)
                {
                    continue;
                }
            }
            //now we've got all the dpcis, prepare the output
            string output = "";
            for (int i = 0; i < dpcis.Count; i++)
            {
                //for all but the last add a space
                if (i < dpcis.Count - 1)
                    output += dpcis[i] + " ";
                else
                    output += dpcis[i];
            }
            if (count == 0)
            {
                MessageBox.Show("No DPCIs found.  \n\nPlease make sure you've entered the right data. \nIf the data is good and it's still not working, tell John about it.");
            }
            txtOutput.Text = output;
            lblCount.Text = count.ToString() + " total items";
            lines = null;
        }

        private void btnCopy_Click(object sender, EventArgs e)
        {
            txtOutput.SelectAll();
            txtOutput.Copy();
        }

        private void frmReceiptTransformer_Load(object sender, EventArgs e)
        {
            lblCount.Text = "";
            txtInput.Focus();
            CheckForUpdateAsync();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        private void ResetForm()
        {
            txtFilePath.Clear();
            txtInput.Clear();
            txtOutput.Clear();
            txtInput.Focus();
            lblCount.Text = "";
        }

        //https://social.msdn.microsoft.com/Forums/vstudio/en-US/487b9ffd-246a-4e5f-a388-6a623d7d63a5/adding-dragdrop-to-a-text-box?forum=csharpgeneral

        private void txtFilePath_DragDrop(object sender, DragEventArgs e)
        {
            ResetForm();
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);

                if (System.IO.File.Exists(files[0]))
                {
                    this.txtFilePath.Text = files[0];
                    OpenFile(this.txtFilePath.Text);
                    Transform();
                }
            }
        }

        private void txtFilePath_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.Copy;
            else
                e.Effect = DragDropEffects.None;
        }

        private void txtFilePath_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (txtFilePath.Text.Length == 0)
                    btnOpen.PerformClick();
                else
                {
                    string p = txtFilePath.Text;
                    ResetForm();
                    txtFilePath.Text = p;
                    OpenFile(p);
                }
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtFilePath_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void txtFilePath_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
            }
        }

        private void linkNewVersion_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/olympiancode/ReceiptTransformer/releases");
        }
    }
}
