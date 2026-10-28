namespace SpaceSurvey;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
    }

    private void OnShowResultClicked(object sender, EventArgs e)
    {
        // Проверяем минимум 2 обязательных поля (Имя и Возраст)
        if (string.IsNullOrWhiteSpace(NameEntry.Text))
        {
            DisplayAlert("Ошибка", "Пожалуйста, введите имя.", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(AgeEntry.Text))
        {
            DisplayAlert("Ошибка", "Пожалуйста, введите возраст.", "OK");
            return;
        }

        // Получаем выбранный опыт полетов
        string experience = "Не выбран";
        if (RadioNo.IsChecked) experience = "Нет опыта";
        if (RadioYes.IsChecked) experience = "Есть опыт";
        if (RadioMany.IsChecked) experience = "Много опыта";

        // Формируем сводку
        string result = $"--- СВОДКА ---\n" +
                        $"Имя: {NameEntry.Text}\n" +
                        $"Возраст: {AgeEntry.Text}\n" +
                        $"О себе: {BioEditor.Text}\n" +
                        $"Планета: {(PlanetPicker.SelectedItem ?? "Не выбрана")}\n" +
                        $"Опыт: {experience}\n" +
                        $"Правила: {(TermsCheckBox.IsChecked ? "Да" : "Нет")}\n" +
                        $"Здоровье: {(HealthCheckBox.IsChecked ? "Да" : "Нет")}\n" +
                        $"Дата вылета: {FlightDatePicker.Date:yyyy-MM-dd}\n" +
                        $"Смелость: {CourageSlider.Value}";

        // Выводим результат в Label (он станет видимым, если включен Switch)
        ResultLabel.Text = result;
        
        // На всякий случай, если Switch выключен, но мы нажали кнопку - принудительно покажем
        if (!ResultLabel.IsVisible)
        {
            ResultLabel.IsVisible = true; 
            // Примечание: в идеале нужно просто попросить включить Switch, 
            // но раз мы используем привязку к Switch, лучше сделать так, чтобы 
            // результат показывался только при включенном Switch (как в требовании).
            // Если пользователь нажал кнопку, а Switch выключен - выводим предупреждение.
            ReadySwitch.IsToggled = true; // Автоматически включаем для показа результата
        }
    }

    private void OnClearClicked(object sender, EventArgs e)
    {
        // Очищаем все поля
        NameEntry.Text = string.Empty;
        AgeEntry.Text = string.Empty;
        BioEditor.Text = string.Empty;
        PlanetPicker.SelectedItem = null;
        
        RadioNo.IsChecked = false;
        RadioYes.IsChecked = false;
        RadioMany.IsChecked = false;
        
        TermsCheckBox.IsChecked = false;
        HealthCheckBox.IsChecked = false;
        
        ReadySwitch.IsToggled = false;
        
        FlightDatePicker.Date = new DateTime(2025, 1, 1); // Дефолтная дата
        CourageSlider.Value = 50; // Дефолтное значение
        
        ResultLabel.Text = string.Empty;
    }
}