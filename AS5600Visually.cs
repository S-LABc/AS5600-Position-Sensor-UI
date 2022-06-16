using System;
using System.Drawing;
using System.IO.Ports;
using System.Windows.Forms;

/*
 * AS5600PositionSensorUI
 * 
 * Демонстрационное приложение для датчика AS5600 https://ams.com/documents/20143/36005/AS5600_DS000365_5-00.pdf
 * GitHub https://github.com/S-LABc/AMS-AS5600-Arduino-Library
 * 
 * Copyright(C) 2022. v1.0 / Скляр Роман S-LAB
 * YouTube https://www.youtube.com/channel/UCbkE52YKRphgkvQtdwzQbZQ
 * Microsoft Visual Studio Professional 2019 Версия 16.11.8
 * .NET framework 4.7.2
 */

namespace AS5600PositionSensorUI
{
    /// <summary>
    /// У формы включена двойная буферизация чтобы не было мерцания при обновлении дуги!
    /// Скорость связи 115200
    /// Буфер для чтения 10 байтов
    /// </summary>
    public partial class FormAS5600 : Form
    {
        //Для WndProc
        private const int WM_DEVICECHANGE = 0x0219; //Сообщение об аппаратных изменениях
        private const int DBT_DEVICEARRIVAL = 0x8000; //Подключен USB-COM
        private const int DBT_DEVICEREMOVECOMPLETE = 0x8004; //Отключен USB-COM

        //Значения такие чтобы начало и конец дуги были вверху
        float sweepAngle = 360.0F;
        float startAngle = -90.0F;

        Pen blackPen;
        Rectangle rect;

        public FormAS5600()
        {
            InitializeComponent();
            //Настройка списка портов
            PortPreparation();
            //Кисть
            blackPen = new Pen(Color.MediumSlateBlue, 50);
            //Прямоугольник куда впишется окружность
            rect = new Rectangle((Width / 2) - 80, 35, 150, 150);
        }

        //Подготовка и автовыбор порта в списке
        private void PortPreparation()
        {
            //Заполнение массива найденными портами
            string[] ports = SerialPort.GetPortNames();
            //Очистка и заполнение списка
            cbPort.Items.Clear();
            cbPort.Items.AddRange(ports);
            //Если есть хоть один порт - выбрать его, иначе пустое поле
            cbPort.SelectedIndex = (ports.Length != 0) ? 0 : -1;
            //Активность кнопки в зависимости от наличия портов
            if (cbPort.Text == string.Empty)
            {
                btnConn.Enabled = false;
                cbPort.Enabled = false;
            }
            else
            {
                btnConn.Enabled = true;
                cbPort.Enabled = true;
            }
        }

        //Рисуем дугу
        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.DrawArc(blackPen, rect, startAngle, sweepAngle);
        }

        //Обновление списка портов при подключении или отключении USB-COM устройств 
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DEVICECHANGE)
            {
                if (m.WParam.ToInt32() == DBT_DEVICEARRIVAL ||
                    m.WParam.ToInt32() == DBT_DEVICEREMOVECOMPLETE)
                    PortPreparation();
            }
            base.WndProc(ref m);
        }

        //Событие клика для чтения данных от датчика
        private void BtnConn_Click(object sender, EventArgs e)
        {
            //Включать или отключать
            if (SerialPort.IsOpen)
            {
                SerialPort.Close();
                if (!SerialPort.IsOpen)
                {
                    //Сменить название для включения
                    btnConn.Text = "Connect";
                }
            }
            else
            {
                try
                {
                    //Выбор порта
                    SerialPort.PortName = Convert.ToString(cbPort.Text);
                    //Открыть соединение
                    SerialPort.Open();
                    if (SerialPort.IsOpen)
                    {
                        //Сменить название для отключения
                        btnConn.Text = "Disconnect";
                    }
                }
                catch
                {
                    if (SerialPort.IsOpen)
                    {
                        SerialPort.Close();
                    }
                }
            }
            
        }

        //Делегат
        private delegate void ReceivedEvent(string data);

        //Событие приема данных из порта
        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //Вызов метода выдачи значений через делегат 
            BeginInvoke(new ReceivedEvent(DataProcessing), SerialPort.ReadLine());
        }

        //Обработка принятых из порта данных
        private void DataProcessing(string dataReceived)
        {
            //Чистые значения с АЦП
            lblReadAng.Text = dataReceived;
            //Перевод в градусы
            lblDegAng.Text = (Convert.ToSingle(dataReceived) * 0.08789).ToString("0.00"); //Пара знаков после точки
            //Новое положение края дуги
            sweepAngle = (float)(Convert.ToSingle(dataReceived) * 0.08789); // 360/4096=0.087890625, 5 знаков после точки для АЦП 12 бит достаточно
            //Вызов отрисовки
            Invalidate();
        }

        //Событие закрытия формы
        private void FormAS5600_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(SerialPort.IsOpen)
            {
                SerialPort.Close();
            }
        }
    }
}
