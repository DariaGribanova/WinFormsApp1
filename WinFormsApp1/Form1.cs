using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;


namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        private readonly AssembleyAdapter assembleyAdapter;
        private Type currentClassType = null;
        public Form1()
        {
            InitializeComponent();
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            assembleyAdapter = new AssembleyAdapter("WinFormsApp1.dll");
            List<string> classsNames = assembleyAdapter.GetClassNamesByInterfaceType("WinFormsApp1.Classes.IDevice");
            foreach (string className in classsNames)
            {
                comboBox1.Items.Add(className);
            }
        }
    

        private void button1_Click(object sender, EventArgs e)
        {

            if (comboBox2.SelectedIndex == -1)
                return;
            string methodName = comboBox2.SelectedItem as string;
            MethodInfo methodInfo = currentClassType.GetMethod(methodName);
            var paramList = new List<object>();
            int i = 0;
            try
            {
                foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
                {
                    string value = flowLayoutPanel1.Controls[i++].Text;
                    object param = Convert.ChangeType(value, parameterInfo.ParameterType);
                    paramList.Add(param);
                }
                object obj = Activator.CreateInstance(currentClassType);
                textBox1.Text = methodInfo.Invoke(obj, paramList.ToArray())?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string className = comboBox1.SelectedItem as string;
            currentClassType = assembleyAdapter.GetClassType(className);
            comboBox2.SelectedIndex = -1;
            comboBox2.Items.Clear();
            flowLayoutPanel1.Controls.Clear();
            textBox1.Text = "";
            foreach (MethodInfo methodInfo in currentClassType.GetMethods(BindingFlags.Public | BindingFlags.Instance))
            {
                comboBox2.Items.Add(methodInfo.Name);
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
                return;
            string methodName = comboBox2.SelectedItem as string;
            MethodInfo methodInfo = currentClassType.GetMethod(methodName);
            flowLayoutPanel1.Controls.Clear();
            textBox1.Text = "";
            foreach (ParameterInfo parameterInfo in methodInfo.GetParameters())
            {
                var textBox = new TextBox
                {
                    PlaceholderText = parameterInfo.Name,
                    Width = 400
                };
                flowLayoutPanel1.Controls.Add(textBox);
            }
        }

 
    }
}
