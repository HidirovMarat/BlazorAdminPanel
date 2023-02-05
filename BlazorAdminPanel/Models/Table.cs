using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Unicode;


namespace BlazorAdminPanel.Models
{
    public abstract class Table
    {
        // Путь к базе.
        public abstract string PathTable { get; }

        // Методы инициализации данных.
        public abstract void Init();

        // Делегат события обновления таблицы базы данных.
        public delegate void UpdateEventHandler(object sender);

        // Событие обновления таблицы базы данных.
        public event UpdateEventHandler UpdateEvent;

        // База в памяти. Читается из файла и сохраняется в оперпамяти.
        public List<Row> Rows { get; set; } = new List<Row>();



        public Table()
        {
            // Первоначальное заполнение таблицы в памяти.
            Read();
        }



        // Запись в файл базы данных.
        public void Write()
        {
            // Перед записью пересчитаем процентное содержание технологий.
            // У кого они есть. Другим это не помешает.
            ComputePercents();

            // Запись базы в файл
            var serializerOptions = new JsonSerializerOptions
            {
                // Формирует вид, привлекательный для чтения и печати.
                WriteIndented = true,

                // Настройка кодировки символов для кириллицы.
                // По умолчанию сериализатор выполняет escape - последовательность символов,
                // отличных от ASCII.То есть он заменяет их на \uxxxx,
                // где xxxx является кодом Юникода символа.
                Encoder = JavaScriptEncoder.Create(UnicodeRanges.All, UnicodeRanges.Cyrillic)
            };


            string s = JsonSerializer.Serialize(Rows, serializerOptions);

            using var sw = new StreamWriter(PathTable);
            sw.Write(s);
            sw.Close();

            // Обновляем данные в памяти.
            Read();

            // Событие обновления после записи.
            UpdateEvent?.Invoke(this);
        }


        // Чтение из базы в память
        public void Read()
        {
            using var streamReader = new StreamReader(PathTable);

            Rows = JsonSerializer.Deserialize<List<Row>>(streamReader.ReadToEnd());

            streamReader.Close();
        }


        // Вычисляет проценты для кого необходимо.
        private void ComputePercents()
        {
            // Распределение процентов
            int _100Percents = 0;
            foreach (var i in Rows)
            {
                _100Percents += i.NumCustomers;
            }


            foreach (var i in Rows)
            {
                double percent = ((double)i.NumCustomers / (double)_100Percents) * 100.0;
                i.Percent = Math.Round(percent, 2);
            }
        }
    }
}
