using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VicinityCLP
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            SW = new ServiceWorker_New();
        }

        ServiceWorker_New SW;

        List<string> _auids;

        private void button1_Click(object sender, EventArgs e)
        {
            _auids = SW.GetObjectsAUIDs();
            dataGridView1.DataSource = _auids.ConvertAll(x => new { Value = x });

        }

        private void button2_Click(object sender, EventArgs e)
        {
            IDictionary<string, string> object_par = SW.GetStatus(dataGridView1.SelectedCells[0].Value.ToString());
            try
            {
                dataGridView2.DataSource = (from entry in object_par
                                            orderby entry.Key
                                            select new { entry.Key, entry.Value }).ToList();
            }
            catch
            { }
        }
        #region cold
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cildlock
            string value = comboBox1.SelectedItem.ToString();
            SW.RF_SetChildLock(dataGridView1.SelectedCells[0].Value.ToString(), value);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            //fastfreeze
            string value = comboBox2.SelectedItem.ToString();
            SW.RF_SetFastFreeze(dataGridView1.SelectedCells[0].Value.ToString(), value);
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            //supercool
            string value = comboBox3.SelectedItem.ToString();
            SW.RF_SetSuperCool(dataGridView1.SelectedCells[0].Value.ToString(), value);
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            //RF_TEMP
            int value = int.Parse(comboBox4.SelectedItem.ToString());
            SW.RF_SetFridgeTemp(dataGridView1.SelectedCells[0].Value.ToString(), value);
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            //FR_TEMP
            int value = int.Parse(comboBox5.SelectedItem.ToString());
            SW.RF_SetFreezerTemp(dataGridView1.SelectedCells[0].Value.ToString(), value);
        }
        #endregion
        #region hot
        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
            //cildlock
            string value = comboBox6.SelectedItem.ToString();
            SW.OV_SetChildLock(dataGridView1.SelectedCells[0].Value.ToString(), value);
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            //light
            string value = comboBox7.SelectedItem.ToString();
            SW.OV_SetLight(dataGridView1.SelectedCells[0].Value.ToString(), value);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string value = comboBox8.SelectedItem.ToString();
            if (value == "ON")
            {
                SW.OV_SetBakePreheat(dataGridView1.SelectedCells[0].Value.ToString(), int.Parse(textBox2.Text.ToString().Trim()), comboBox9.SelectedItem.ToString(), int.Parse(textBox1.Text.ToString().Trim()));
            }
            else
            {
                if (textBox3.Text == "0" && textBox4.Text == "0")
                {
                    SW.OV_SetBake(dataGridView1.SelectedCells[0].Value.ToString(), int.Parse(textBox2.Text.ToString().Trim()), comboBox9.SelectedItem.ToString(), int.Parse(textBox1.Text.ToString().Trim()));
                }
                else
                {
                    SW.OV_SetBakeDelayStart(dataGridView1.SelectedCells[0].Value.ToString(), int.Parse(textBox2.Text.ToString().Trim()), comboBox9.SelectedItem.ToString(), int.Parse(textBox1.Text.ToString().Trim()), int.Parse(textBox4.Text.ToString()), int.Parse(textBox3.Text.ToString()));
                }
            }         
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SW.OV_SetStart(dataGridView1.SelectedCells[0].Value.ToString());
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SW.OV_SetStop(dataGridView1.SelectedCells[0].Value.ToString());
        }
        #endregion
    }
}
