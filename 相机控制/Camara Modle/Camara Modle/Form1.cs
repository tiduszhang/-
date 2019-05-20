using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GCS
{   

    public partial class CameraModle : Form
    {
        private AirSurveyKit cameraM;
        int m_i = 0;
        public CameraModle(AirSurveyKit cameram)
        {
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            InitializeComponent();
            cameraM = cameram;

            int cou = cameraM.getAirSurveyList().Count();

            listBox1.Items.Clear();
            for (int i=0;i<cou;++i)
            {
                listBox1.Items.Add(cameraM.getAirSurveyList()[i].model);
            }
        }

        void addItem(string modelName)
        {
            if (textBox1.Text != "" && textBox2.Text != "" && textBox3.Text != "" && textBox4.Text != "" && textBox5.Text != "" && textBox6.Text != "")
            {
                listBox1.Items.Add(modelName);
                cameraM.addCameraModle(textBox1.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox5.Text, textBox2.Text);
                return;
            }
            MessageBox.Show("输入错误！");
        }

        void delItem()
        {
            if (m_i >= 0 && m_i < listBox1.Items.Count)
            {
                listBox1.Items.RemoveAt(m_i);
                cameraM.delCameraModle(m_i);
            }
        }

        void updateItem()
        {
            if (m_i >= 0 && m_i < listBox1.Items.Count)
            {
                cameraM.updateCameraModle(m_i, textBox1.Text, textBox3.Text, textBox4.Text, textBox6.Text, textBox5.Text, textBox2.Text);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            addItem(listBox1.Text);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            updateItem();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            delItem();
        }

        private void listBox1_MouseClick(object sender, MouseEventArgs e)
        {
            m_i = listBox1.SelectedIndex;
        }
    }
}
