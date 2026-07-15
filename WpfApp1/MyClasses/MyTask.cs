using System;
using System.Collections.Generic;
using System.Text;

namespace WpfApp1.MyClasses
{
    public class MyTask
    {
        public string Name { get; set; }
        public string Urgency { get; set; }
        public string DueDate { get; set; }
        public bool IsCompleted { get; set; } // שים לב לשם התואם ל-Binding ב-XAML שלך
    }
}
