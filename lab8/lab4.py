import tkinter as tk
from tkinter import messagebox
import random
import string

# Собственное исключение
class EmptyFieldError(Exception):
    pass

# Основной класс приложения
class PasswordManagerApp:
    def __init__(self, root):
        self.root = root
        self.root.title("Менеджер паролей")
        self.root.geometry("400x250")

        self.setup_ui()

    def setup_ui(self):
        # Метки и поля ввода
        tk.Label(self.root, text="Сайт: ").pack()
        self.site_entry = tk.Entry(self.root, width=40)
        self.site_entry.pack()

        tk.Label(self.root, text="Логин: ").pack()
        self.login_entry = tk.Entry(self.root, width=40)
        self.login_entry.pack()

        tk.Label(self.root, text="Пароль: ").pack()
        self.password_entry = tk.Entry(self.root, width=30)
        self.password_entry.pack()

        # Кнопки
        tk.Button(self.root, text="Сгенерировать пароль", command=self.generate_password).pack()
        tk.Button(self.root, text="Сохранить пароль", command=self.save_password).pack()

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

            with open("password.txt", "a") as file:
                file.write(f"Сайт: {site}\nЛогин: {login}\nПароль: {password}\n---\n")

            # Очистка полей
            self.site_entry.delete(0, tk.END)
            self.login_entry.delete(0, tk.END)
            self.password_entry.delete(0, tk.END)

            messagebox.showinfo("Успех", "Пароль сохранён!")

        except EmptyFieldError as e:
            messagebox.showwarning("Ошибка", str(e))
        except Exception as e:
            messagebox.showerror("Ошибка", f"Произошла непредвиденная ошибка: {e}")

# Запуск приложения
if __name__ == "__main__":
    root = tk.Tk()
    app = PasswordManagerApp(root)
    root.mainloop()