# Отчёт по лабораторной работе №6

## Задание
По своему варианту задания создайте пакет, содержащий 3 модуля, и подключите его к основной программе.
## Результат вычислений: 
Программа представляет собой простой калькулятор расхода электроэнергии с графическим интерфейсом. Пользователь выбирает прибор, вводит мощность, время работы и тариф, после чего программа рассчитывает потреблённую энергию и стоимость. Результаты можно сохранить в Excel-файл. Все вычисления и сохранения делаются с помощью отдельных подключаемых функций.
```python
import tkinter as tk
from tkinter import ttk, messagebox
from devices.iron import count_iron
from devices.tele import count_tele
from devices.wash import count_wash
from reports.xls_report import save_to_excel

def count():
    device = device_var.get()
    try:
        power = float(power_entry.get())
        hours = float(hours_entry.get())
        rate = float(rate_entry.get())
    except ValueError:
        messagebox.showerror("Ошибка", "Введите числовые значения ещё раз.")
        return

    if device == "Утюг":
        energy, cost = count_iron(power, hours, rate)
    elif device == "Телевизор":
        energy, cost = count_tele(power, hours, rate)
    elif device == "Стиральная машина":
        energy, cost = count_wash(power, hours, rate)
    else:
        messagebox.showerror("Ошибка", "Прибор не выбран")
        return
    
    global counted_energy, counted_cost
    counted_energy = energy
    counted_cost = cost

    result_label.config(text=f"Потребление энергии: {energy:.2f} кВт·ч\nИтоговая стоимость: {cost:.2f} руб.")

def save_report():
    device = device_var.get()

    if 'counted_energy' not in globals() or 'counted_cost' not in globals():
        messagebox.showerror("Ошибка", "Расчёт не выполнен")
        return

    energy = counted_energy
    cost = counted_cost

    save_to_excel(device, energy, cost)
    messagebox.showinfo("Отчёт", "Сохранение выполнено")# Функция для сохранения отчёта


root = tk.Tk()
root.title("Калькулятор")
root.geometry("350x400")
root.resizable(False, False)# главное окно

main_frame = ttk.Frame(root, padding="15")
main_frame.pack(fill="both", expand=True)# основной фрейм

ttk.Label(main_frame, text="Выберите прибор:").pack(anchor="w", pady=(0, 5))
device_var = tk.StringVar()
device_menu = ttk.Combobox(main_frame, textvariable=device_var, values=["Утюг", "Телевизор", "Стиральная машина"], state="readonly")
device_menu.pack(fill="x", pady=(0, 10))# выбор прибора

ttk.Label(main_frame, text="Мощность (кВт):").pack(anchor="w")
power_entry = ttk.Entry(main_frame)
power_entry.pack(fill="x", pady=(0, 10))# мощность

ttk.Label(main_frame, text="Время работы (ч):").pack(anchor="w")
hours_entry = ttk.Entry(main_frame)
hours_entry.pack(fill="x", pady=(0, 10))# время

ttk.Label(main_frame, text="Тариф (руб/кВт·ч):").pack(anchor="w")
rate_entry = ttk.Entry(main_frame)
rate_entry.pack(fill="x", pady=(0, 20))# тариф

calc_button = ttk.Button(main_frame, text="Рассчитать", command=count)
calc_button.pack(pady=(0, 10))# расчёт

result_label = ttk.Label(main_frame, text="Потребление энергии: \nЦена: ", anchor="center", background="#f0f0f0", relief="sunken", padding=10)
result_label.pack(fill="x", pady=(0, 10))# результат

save_button = ttk.Button(main_frame, text="Сохранить", command=save_report)
save_button.pack()# сохранение

root.mainloop()# запуск
```

![](https://github.com/manabreako/python/blob/main/lab6/screen/Screenshot_20250410_142111.png)
![](https://github.com/manabreako/python/blob/main/lab6/screen/Screenshot_20250410_142159.png)


# Список использованных источников: 
1) [Разработка пользовательского интерфейса](https://texterra.ru/blog/razrabotka-polzovatelskogo-interfeysa-kak-sozdat-gui.html)
2) [Python модули и пакеты](https://docs.python.org/3/search.html?q=round)
