using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WpfApp1.MyClasses;

namespace WpfApp1.User_Controls
{
    /// <summary>
    /// Interaction logic for ContactCardUserControl.xaml
    /// </summary>
 
    public partial class ContactCardControl : UserControl
    {
        // 1. הגדרת האירועים החוצה. נשתמש ב-EventHandler שיעביר את אובייקט ה-Contacts הרלוונטי
        public event EventHandler<Contacts> ContactDeleted;
        public event EventHandler<Contacts> ContactDetailsRequested;

        public ContactCardControl()
        {
            InitializeComponent();
        }

        // לחיצה על כפתור המחיקה הפנימי
        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            // שליפת ה-Contacts שמקושר לכרטיס הנוכחי
            if (this.DataContext is Contacts currentContact)
            {
                // הפעלת האירוע החוצה (בדיקה שהוא לא null)
                ContactDeleted?.Invoke(this, currentContact);
            }
        }

        // לחיצה על כפתור הפרטים הפנימי
        private void DetailsButton_Click(object sender, RoutedEventArgs e)
        {
            if (this.DataContext is Contacts currentContact)
            {
                // הפעלת האירוע החוצה
                ContactDetailsRequested?.Invoke(this, currentContact);
            }
        }
    }
}