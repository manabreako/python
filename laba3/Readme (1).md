# Отчёт по лабораторной работе №8

## Задание
Реализуйте приложение с GUI (приложения-игры допускается делать с использованием TUI-пакетов) по своему варианту. Можно изменить задание на собственную тему, согласовав с преподавателем. Менеджер паролей.
## Результат вычислений: 
Я сделал программу, которая представляет собой менеджер паролей с графическим интерфейсом, используя библиотеку Tkinter. При запуске открывается окно, в котором я могу ввести название сайта, логин и пароль. В окне есть две кнопки: одна для генерации случайного пароля, а другая — для сохранения введённых данных. Когда я нажимаю кнопку "Сгенерировать пароль", программа создаёт случайный пароль длиной 12 символов, используя буквы, цифры и специальные символы, и отображает его в поле пароля. При нажатии на кнопку "Сохранить пароль" программа проверяет, что все поля заполнены. Если хотя бы одно из них пустое, появляется предупреждение. Если все данные введены корректно, они сохраняются в текстовом файле password.txt в формате "Сайт: [имя сайта]\nЛогин: [логин]\nПароль: [пароль]", а поля ввода очищаются, и появляется сообщение об успешном сохранении. В случае другой ошибки выводится сообщение с её описанием. Так же по желанию пользователя можно внести изменение в сохраненые данные с помощью кнопки редактирование, после чего нажать сохранить изменения.
``` Python
import tkinter as tk
from tkinter import messagebox
import random
import string
import os

class EmptyFieldError(Exception):
    pass

class PasswordManagerApp:
    def __init__(self, root):  #инкапсуляция
        self.root = root
        self.root.title("Менеджер паролей")
        self.root.geometry("480x450")

        self.passwords = [] # <- инкап список паролей
        self.edit_index = None # crhsnfz cke;t, gthtvty

        self.setup_ui()
        self.load_from_file()

    def setup_ui(self):
        tk.Label(self.root, text="Сайт:").pack()
        self.site_entry = tk.Entry(self.root, width=40)
        self.site_entry.pack()

        tk.Label(self.root, text="Логин:").pack()
        self.login_entry = tk.Entry(self.root, width=40)
        self.login_entry.pack()

        tk.Label(self.root, text="Пароль:").pack()
        self.password_entry = tk.Entry(self.root, width=30)
        self.password_entry.pack()

        tk.Button(self.root, text="Сгенерировать пароль", command=self.generate_password).pack(pady=3)
        tk.Button(self.root, text="Сохранить пароль", command=self.save_password).pack(pady=3)
        tk.Button(self.root, text="Редактировать выбранный", command=self.edit_selected).pack(pady=3)
        tk.Button(self.root, text="Сохранить изменения", command=self.save_edit).pack(pady=3)

        tk.Label(self.root, text="Сохранённые пароли:").pack(pady=5)
        self.password_listbox = tk.Listbox(self.root, width=60, height=10)
        self.password_listbox.pack()

    def generate_password(self):
        length = 12
        chars = string.ascii_letters + string.digits + string.punctuation
        password = ''.join(random.choice(chars) for _ in range(length))
        self.password_entry.delete(0, tk.END)
        self.password_entry.insert(0, password)

    def save_password(self):
        site = self.site_entry.get()
        login = self.login_entry.get()
        password = self.password_entry.get()

        try:
            if not site or not login or not password:
                raise EmptyFieldError("Одно или несколько полей не заполнены!")

            entry = f"Сайт: {site} | Логин: {login} | Пароль: {password}"
            self.passwords.append((site, login, password))
            self.password_listbox.insert(tk.END, entry)

            self.clear_entries()
            self.save_to_file()
            messagebox.showinfo("Успех", "Пароль сохранён!")

        except EmptyFieldError as e:
            messagebox.showwarning("Ошибка", str(e))

    def edit_selected(self):
        selected = self.password_listbox.curselection()
        if not selected:
            messagebox.showwarning("Выбор", "Выберите запись для редактирования.")
            return

        index = selected[0]
        site, login, password = self.passwords[index]
        self.site_entry.delete(0, tk.END)
        self.site_entry.insert(0, site)
        self.login_entry.delete(0, tk.END)
        self.login_entry.insert(0, login)
        self.password_entry.delete(0, tk.END)
        self.password_entry.insert(0, password)

        self.edit_index = index

    def save_edit(self):
        if self.edit_index is None:
            messagebox.showwarning("Ошибка", "Нет выбранной записи для редактирования.")
            return

        site = self.site_entry.get()
        login = self.login_entry.get()
        password = self.password_entry.get()

        try:
            if not site or not login or not password:
                raise EmptyFieldError("Пожалуйста, заполните все поля.")

            self.passwords[self.edit_index] = (site, login, password)
            new_entry = f"Сайт: {site} | Логин: {login} | Пароль: {password}"
            self.password_listbox.delete(self.edit_index)
            self.password_listbox.insert(self.edit_index, new_entry)

            self.clear_entries()
            self.edit_index = None
            self.save_to_file()
            messagebox.showinfo("Успех", "Изменения сохранены!")

        except EmptyFieldError as e:
            messagebox.showwarning("Ошибка", str(e))
    def clear_entries(self):
            self.site_entry.delete(0, tk.END)
            self.login_entry.delete(0, tk.END)
            self.password_entry.delete(0, tk.END)

    def save_to_file(self):
        with open("passwords.txt", "w", encoding="utf-8") as file:
            for site, login, password in self.passwords:
                file.write(f"{site}|{login}|{password}\n")

    def load_from_file(self):
        if not os.path.exists("passwords.txt"):
            return
        with open("passwords.txt", "r", encoding="utf-8") as file:
            for line in file:
                site, login, password = line.strip().split("|")
                self.passwords.append((site, login, password))
                entry = f"Сайт: {site} | Логин: {login} | Пароль: {password}"
                self.password_listbox.insert(tk.END, entry)

# Запуск приложения
if __name__== "__main__":
    root = tk.Tk()
    app = PasswordManagerApp(root)
    root.mainloop()
```
### Результат
![](https://github.com/manabreako/python/blob/main/lab8/Screenshot_20250424_124719.png)
### Текстовый документ
![](https://github.com/manabreako/python/blob/main/lab8/Screenshot_20250424_124836.png)


# Список использованных источников: 
1) [Парадигмы и стили программирования Python: обзор и примеры](https://sky.pro/wiki/python/paradigmy-i-stili-programmirovaniya-python-obzor-i-primery/)
2) [Глава 3. Объектно-ориентированное программирование](https://metanit.com/python/tutorial/)
