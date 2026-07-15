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

namespace WpfApp1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //
        List<MyTask> tasks = new List<MyTask>();
        List<string> cityList = new List<string>()  { "נמוכה", "בינונית", "גבוהה" };
        List<ComboBoxItem> cityComboBoxList = new List<ComboBoxItem>();
        DateTime? selectedDate = null;   
            public MainWindow()
            {
               InitializeComponent();
               foreach (string s in cityList)
               {
                 ComboBoxItem cb = new ComboBoxItem();
                 cb.Content = s;
                cityComboBoxList.Add(cb);

            }
                
               UrgencyComboBox.ItemsSource = cityComboBoxList;
            }


        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            // 1. בדיקת תקינות
            string taskText = newTaskTextBox.Text.Trim();
            if (string.IsNullOrEmpty(taskText))
            {
                MessageBox.Show("אנא הקלד תיאור למשימה.", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // 2. חילוץ רמת הדחיפות
            string urgencyText = "רגיל"; // ערך ברירת מחדל
            if (UrgencyComboBox.SelectedItem is ComboBoxItem selectedItem)
            {
                urgencyText = selectedItem.Content.ToString();
            }

            // 3. חילוץ התאריך (נניח שיש לך פקד תאריך או משתנה selectedDate)
            string dateText = DateTime.Now.ToString("dd/MM/yyyy");
            // אם יש לך פקד DatePicker בשם taskDatePicker, תוכל להשתמש בזה:
            // string dateText = taskDatePicker.SelectedDate?.ToString("dd/MM/yyyy") ?? DateTime.Now.ToString("dd/MM/yyyy");

            // 4. יצירת אובייקט משימה חדש (במקום סטרינג משורשר!)
            MyTask newTask = new MyTask()
            {
                Name = taskText,
                Urgency = urgencyText,
                DueDate = dateText,
                IsCompleted = false
            };

            // 5. הוספה לרשימה ועדכון ה-ListView
            tasks.Add(newTask);


            MyTasksListView.ItemsSource = null;
            MyTasksListView.ItemsSource = tasks;

            // 6. איפוס וניקוי שדה הקלט
            newTaskTextBox.Clear();
            newTaskTextBox.Focus();
        }

        // פונקציה זו מופעלת בכל פעם שהמשתמש לוחץ על כפתור ה"הוסף"
        //private void AddButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //   1.בדיקת תקינות: ודואגים שהמשתמש לא מנסה להוסיף משימה ריקה
        //    string taskText = newTaskTextBox.Text.Trim();
        //    if (string.IsNullOrEmpty(taskText))
        //    {
        //        MessageBox.Show("אנא הקלד תיאור למשימה.", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // 2. חילוץ רמת הדחיפות שנבחרה מה-ComboBox


           
        //    string urgencyText = string.Empty;

        //    if (UrgencyComboBox.SelectedItem is ComboBoxItem selectedItem)
        //    {
        //        // selectedItem.Content מחזיר אובייקט, לכן נמיר אותו ל-string
        //         urgencyText = selectedItem.Content.ToString();

                
        //    }
          
            

        //    // 6. איפוס וניקוי שדה הקלט כדי להכין אותו למשימה הבאה
        //    newTaskTextBox.Clear();
        //    newTaskTextBox.Focus(); // מחזיר את הסמן האוטומטי לתיבת הטקסט

        //    string currentTask =$"{taskText}, Urgency = {urgencyText}, DueDate = {selectedDate}, IsCompleted = {false}";
        //    tasks.Add(currentTask);
        //    MyTasksListView.ItemsSource = null;
        //    MyTasksListView.ItemsSource = tasks;

        //}
        //private void AddButton_Click(object sender, RoutedEventArgs e)
        //{
        //    //   1.בדיקת תקינות: ודואגים שהמשתמש לא מנסה להוסיף משימה ריקה
        //    string taskText = newTaskTextBox.Text.Trim();
        //    if (string.IsNullOrEmpty(taskText))
        //    {
        //        MessageBox.Show("אנא הקלד תיאור למשימה.", "שגיאה", MessageBoxButton.OK, MessageBoxImage.Warning);
        //        return;
        //    }

        //    // 2. חילוץ רמת הדחיפות שנבחרה מה-ComboBox
        //    ComboBoxItem selectedUrgency = (ComboBoxItem)UrgencyComboBox.SelectedItem;
        //    string urgencyText = selectedUrgency.Content.ToString();

        //    // 3. יצירת הפקדים החדשים באופן דינמי

        //    // יצירת StackPanel אופקי שיאגד את המשימה הספציפית הזו
        //    StackPanel taskPanel = new StackPanel();
        //    taskPanel.Orientation = Orientation.Horizontal;
        //    taskPanel.Margin = new Thickness(5);

        //    // יצירת תיבת הסימון (CheckBox)
        //    CheckBox taskCheckBox = new CheckBox();
        //    taskCheckBox.VerticalAlignment = VerticalAlignment.Center;
        //    taskCheckBox.Margin = new Thickness(0, 0, 10, 0);

        //    // יצירת ה-TextBlock שיציג את שם המשימה והדחיפות
        //    TextBlock taskTextBlock = new TextBlock();
        //    taskTextBlock.Text = $"{taskText} (דחיפות: {urgencyText})";
        //    if (selectedDate.HasValue)
        //    {
        //        taskTextBlock.Text += $" - תאריך יעד: {selectedDate.Value.ToShortDateString()}";
        //    }
        //    taskTextBlock.FontSize = 14;
        //    taskTextBlock.VerticalAlignment = VerticalAlignment.Center;

        //    // 4. הרכבת הפקדים: הוספת ה-CheckBox וה-TextBlock אל תוך ה-StackPanel האופקי
        //    taskPanel.Children.Add(taskCheckBox);
        //    taskPanel.Children.Add(taskTextBlock);

        //    // 5. הוספת המשימה השלמה אל תוך רשימת המשימות הראשית במסך (XAML)
        //    TasksContainer.Children.Add(taskPanel);

        //    // 6. איפוס וניקוי שדה הקלט כדי להכין אותו למשימה הבאה
        //    newTaskTextBox.Clear();
        //    newTaskTextBox.Focus(); // מחזיר את הסמן האוטומטי לתיבת הטקסט
        //}

        private void ShowCalander(object sender, TextChangedEventArgs e)
        {
            if (newTaskTextBox.Text.ToString().Length>0)
                taskCalander.Visibility = Visibility.Visible;
            else taskCalander.Visibility = Visibility.Collapsed;
        }

        private void DateWasChoosed(object sender, SelectionChangedEventArgs e)
        {
            selectedDate = taskCalander.SelectedDate;  
        }

        //private void MyTasksSelected(object sender, SelectionChangedEventArgs e)
        //{
        //   MyTask currentTask= (MyTask)MyTasksListView.SelectedItem;
        //}
    }
    }
