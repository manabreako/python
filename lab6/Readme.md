# Отчёт по лабораторной работе №6

## Задание
По своему варианту задания создайте пакет, содержащий 3 модуля, и подключите его к основной программе.
## Результат вычислений: 
Я написад программу на Python с графическим интерфейсом, для него я использовал tkinter для создания окна, добавил выпадающий список для выбора прибора, поля для ввода данных (мощность, время работы, тариф) и кнопки для расчёта. Приложение позволяет рассчитывать потребление электроэнергии для разных бытовых приборов (утюг, телевизор, стиральная машина) с помощью введённых данных упомянутых ранее. После расчёта выводится результат, который также можно сохранить в Excel-файл. 

Так же я создал пакет devices, который включает три модуля: iron, tele, и wash. Каждый из этих модулей содержит функцию для расчёта потребления электроэнергии и стоимости для соответствующего прибора:

iron — для расчёта потребления утюга,

tele — для расчёта потребления телевизора,

wash — для расчёта потребления стиральной машины.

Я импортировал эти модули в основной код и использовал их функции для выполнения расчётов, в зависимости от выбранного пользователем прибора.

### Калькулятор
![](https://github.com/manabreako/python/blob/main/lab6/screen/Screenshot_20250410_142111.png)

### Excel-файл
![](https://github.com/manabreako/python/blob/main/lab6/screen/Screenshot_20250410_142159.png)


# Список использованных источников: 
1) [Разработка пользовательского интерфейса](https://texterra.ru/blog/razrabotka-polzovatelskogo-interfeysa-kak-sozdat-gui.html)
2) [Python модули и пакеты](https://docs.python.org/3/search.html?q=round)
