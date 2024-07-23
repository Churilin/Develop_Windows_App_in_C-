using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace itmo.CSDesctopApp.WinFormTestList
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            if (peopleList.Text.Length != 0)
            {
                memberList.Items.Add(peopleList.Text);
            }
            else MessageBox.Show("Выберите элемент из списка или введите новый");
        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            while (memberList.CheckedIndices.Count > 0)
                memberList.Items.RemoveAt(memberList.CheckedIndices[0]);
        }

        private void buttonSort_Click(object sender, EventArgs e)
        {
            memberList.Sorted = true;
        }

        private void buttonAddData_Click(object sender, EventArgs e)
        {
            peopleList.Items.Clear();
            FileStream fStream = new FileStream
                ("C:\\Обучение ИТМО\\Разработка Windows-приложений на С#\\" +
                "Выполнение лабораторных\\Lab_02\\itmo.CSDesctopApp.WinFormTestList\\4" +
                "itmo.CSDesctopApp.WinFormTestList\\XMLData.xml",
                FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

            XmlDocument xmlDoc = new XmlDocument ();
            xmlDoc.Load(fStream);

            for (int i = 0; i < xmlDoc.DocumentElement.ChildNodes.Count; i++)
            {
                peopleList.Items.Add(xmlDoc.DocumentElement.ChildNodes[i].InnerText);

                fStream.Close();
            }

        }
    }
}
