using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using WpfApp1.MyClasses;
using System.Collections.ObjectModel; // מומלץ להשתמש בזה לעדכון אוטומטי של הרשימה במסך
using System.Windows;

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for UserControlWindow.xaml
    /// </summary>
    public partial class UserControlWindow : Window
    {

        // שימוש ב-ObservableCollection במקום ב-List רגיל מאפשר למסך להתעדכן אוטומטית ברגע שמוחקים פריט
        private ObservableCollection<Contacts> _contactsList;

        public UserControlWindow()
        {
            InitializeComponent();
            // טעינת נתונים ראשונית
                _contactsList = new ObservableCollection<Contacts>
            {
                new Contacts { Name = "אבי כהן", City = "ירושלים", BornDate = new DateTime(1988, 10, 5) },
                new Contacts { Name = "דנה לוי", City = "תל אביב", BornDate = new DateTime(1992, 2, 28) },
                new Contacts { Name = "יוסי מזרחי", City = "באר שבע", BornDate = new DateTime(2001, 7, 19) }
            };

                // קישור הרשימה
                ContactsListView.ItemsSource = _contactsList;
            }

            // פונקציית הטיפול באירוע מחיקה
            private void ContactCard_ContactDeleted(object sender, Contacts contact)
            {
                if (contact != null)
                {
                    // וידוא מול המשתמש
                    MessageBoxResult result = MessageBox.Show($"האם אתה בטוח שברצונך למחוק את {contact.Name}?",
                                                              "אישור מחיקה",
                                                              MessageBoxButton.YesNo,
                                                              MessageBoxImage.Warning);

                    if (result == MessageBoxResult.Yes)
                    {
                        // מחיקה מהאוסף - ה-ListView יתעדכן אוטומטית!
                        _contactsList.Remove(contact);
                    }
                }
            }

            // פונקציית הטיפול באירוע הצגת פרטים
            private void ContactCard_ContactDetailsRequested(object sender, Contacts contact)
            {
                if (contact != null)
                {
                    // הצגת הפרטים המלאים בתיבת הודעה (עושה שימוש ב-ToString שדרסנו במחלקה)
                    MessageBox.Show(contact.ToString(), "פרטי איש קשר", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
        }
    }



