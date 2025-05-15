# Импорт Kivy-модулей
from kivy.app import App
from kivy.uix.boxlayout import BoxLayout
from kivy.uix.gridlayout import GridLayout
from kivy.uix.label import Label
from kivy.uix.textinput import TextInput
from kivy.uix.spinner import Spinner
from kivy.uix.button import Button

# Импорт модуля(создания Excel отчётов)
from reports.xls_report import save_to_excel

# Импорт классов приборов
from devices.iron import Iron
from devices.tv import TV
from devices.washing_machine import Washing


class EnergyApp(BoxLayout):
    def __init__(self, **kwargs):
        super().__init__(orientation='vertical', padding=10, spacing=10, **kwargs)

        # Заголовок
        self.add_widget(Label(text='Расчет энергопотребления устройств', font_size=24, size_hint=(1, 0.1)))

        # Основная форма в GridLayout для удобства размещения элементов
        form_layout = GridLayout(cols=2, row_default_height=40, spacing=10, size_hint=(1, 0.6))
        
        # Выбор прибора
        form_layout.add_widget(Label(text='Выберите прибор:', font_size=16))
        self.device_type = Spinner(text='Утюг', values=['Утюг', 'Телевизор', 'Стиральная машина'])
        form_layout.add_widget(self.device_type)

        # Ввод мощности
        form_layout.add_widget(Label(text='Мощность (Вт):', font_size=16))
        self.power_input = TextInput(hint_text='Введите мощность', input_filter='float')
        form_layout.add_widget(self.power_input)

        # Ввод времени работы
        form_layout.add_widget(Label(text='Время работы (часы):', font_size=16))
        self.hours_input = TextInput(hint_text='Введите часы', input_filter='float')
        form_layout.add_widget(self.hours_input)

        # Ввод тарифа
        form_layout.add_widget(Label(text='Тариф (руб/кВт·ч):', font_size=16))
        self.rate_input = TextInput(hint_text='Введите тариф', input_filter='float')
        form_layout.add_widget(self.rate_input)

        self.add_widget(form_layout)

        # Кнопки в горизонтальном BoxLayout
        buttons_layout = BoxLayout(size_hint=(1, 0.2), spacing=20)

        self.calc_btn = Button(text='Рассчитать', font_size=16)
        self.calc_btn.bind(on_press=self.calculate)
        buttons_layout.add_widget(self.calc_btn)

        self.save_btn = Button(text='Сохранить отчёт', font_size=16)
        self.save_btn.bind(on_press=self.save_report)
        buttons_layout.add_widget(self.save_btn)

        self.add_widget(buttons_layout)

        # Результат расчета
        self.result_label = Label(
            text='Потребление и стоимость появятся здесь.',
            font_size=18,
            size_hint=(1, 0.2),
            halign='center',
            valign='middle'
        )
        self.result_label.bind(size=self._update_text_alignment)
        
        self.add_widget(self.result_label)

        # Инициализация переменных
        self.device = None
        self.energy = 0
        self.cost = 0

    def _update_text_alignment(self, instance, value):
        instance.text_size = (instance.width * 0.9, None)
    
    def calculate(self, instance):
        try:
            power = float(self.power_input.text)
            hours = float(self.hours_input.text)
            rate = float(self.rate_input.text)

            device_map = {
                'Утюг': Iron,
                'Телевизор': TV,
                'Стиральная машина': Washing
            }

            cls = device_map[self.device_type.text]
            self.device = cls(power, hours, rate)  # создаём экземпляр прибора
            self.energy, self.cost = self.device.calculate()

            # Вывод результата в интерфейс
            self.result_label.text = (
                f"Потребление: {self.energy:.2f} кВт·ч\n"
                f"Стоимость: {self.cost:.2f} руб."
            )

        except Exception as e:
            self.result_label.text = f"Ошибка ввода: {e}"

    def save_report(self, instance):
        if self.device:
            save_to_excel(self.device_type.text, self.energy, self.cost)
            self.result_label.text = "Отчёт сохранён."


class MyApp(App):
    def build(self):
        return EnergyApp()

if __name__ == '__main__':
    MyApp().run()

tv= TV(54,6,7)
print(tv)
print("Power ->", tv.power)