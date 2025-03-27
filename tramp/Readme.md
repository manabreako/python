# Отчёт по лабораторной работе №1

## Задание №1
Составить словарь словарей расстояний между городами, используя формулу: 
$distances = \sqrt{((x_1 - x_2) ^ 2 + (y_1 - y_2) ^ 2)}$
## Результат вычислений: 
```
sites = {
    'Moscow': (550, 370),
    'London': (510, 510),
    'Paris': (480, 480),
}


distances = {}

distances = {
    city1: {
        city2: round(((x1 - x2)** 2 + (y1 - y2)**2) ** 0.5, 2)
        for (city2, (x2, y2)) in sites.items() if city1 != city2
    }
    for (city1, (x1, y1)) in sites.items()
}

print(distances)
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/0.png)

## Задание №2
1) Для начала нужно вывести на консоль значение площади круга с точностью до 4-х знаков после запятой 
Формула для нахождения площади круга: $S_к = R^2 * \pi$
2) Даны координаты точки, если точка лежит внутри того самого круга [центр в начале координат (0, 0), radius = 42], то вывести на консоль True/False, если точка лежит вовне круга.
## Результат вычислений:
```
radius = 42


pi = 3.1415926
print(round(pi*radius**2, 5))

point_1 = (23, 34)


print((point_1[0]**2+point_1[1]**2)**0,5<radius)

point_2 = (30, 30)

print((point_2[0]**2+point_2[1]**2)**0,5<radius)
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/2%E2%81%842.png)

## Задание №3
Расставить знаки операций "+", "-", "*", "/" и скобки между числами "1 2 3 4 5" так, что бы получилось число "25".
## Результат вычислений:
```
a = ((1*2)+3+(4*5))
print(a)
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/2.png)

## Задание №4
Есть строка с перечислением фильмов: 'Терминатор, Пятый элемент, Аватар, Чужие, Назад в будущее'. 
Нужно вывести на консоль с помощью индексации строки, последовательно: первый фильм, последний, второй, второй с конца.
## Результат вычислений:
```
my_favorite_movies = 'Терминатор, Пятый элемент, Аватар, Чужие, Назад в будущее'


print(my_favorite_movies[0:10])
print(my_favorite_movies[42:57])
print(my_favorite_movies[12:25])
print(my_favorite_movies[-22:-17])
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/Screenshot_20250220_142009.png)

## Задание №5
Нужно создать список семьи и их роста, вывести рост отца и общий рост семьи.
## Результат вычислений:
```
my_family = ['я', 'отец', 'мама', 'сестра']


my_family_height = [
    ['я', 172], # мой рост
    ['отец', 197], # рост отца
    ['мама', 150], # рост мамы
    ['сестра', 110], # рост сестры
]

father_height = next(height for name, height in my_family_height if name == 'отец')
print(f'Рост отца - {father_height} см')


all_height = sum(height for name, height in my_family_height)
print(f'Общий рост - {all_height} см')
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/4.png)

## Задание №6
Есть список животных в зоопарке: 'lion', 'kangaroo', 'elephant', 'monkey'. Нужно сделать:
1) Посадить медведя между львом и кенгуру;
2) Добавить птиц в зоопарк;
3) Убрать слона;
4) Узнать в какой клетке сидит лев и жаворонок.
## Результат вычислений:
```
zoo = ['lion', 'kangaroo', 'elephant', 'monkey', ]



zoo.insert(1, 'bear')
print('Список животных после добавления медведя: ', zoo)



birds = ['rooster', 'ostrich', 'lark', ]

zoo.extend(birds)
print('Список животных после добавления птиц: ', zoo)


zoo.remove('elephant')
print('Список животных без слона: ', zoo)


lion_pos = zoo.index('lion') + 1
lark_pos = zoo.index('lark') + 1
print(f'Лев сидит в клетке №{lion_pos}, а жаворонок в клетке №{lark_pos}')
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/5.png)

## Задание №7
Дан список песен группы Depeche Mode, распечатать общее время звучания трех песен: 'Halo', 'Enjoy the Silence', 'Clean' в формате "Три песни звучат ХХХ.ХХ минут", вывести общее время звучания других трёх песен: 'Sweetest Perfection', 'Policy of Truth', 'Blue Dress' в формате "А другие три звучат ХХХ минут"
## Результат вычислений:
```
violator_songs_list = [
    ['World in My Eyes', 4.86],
    ['Sweetest Perfection', 4.43],
    ['Personal Jesus', 4.56],
    ['Halo', 4.9],
    ['Waiting for the Night', 6.07],
    ['Enjoy the Silence', 4.20],
    ['Policy of Truth', 4.76],
    ['Blue Dress', 4.29],
    ['Clean', 5.83],
]



time = round(violator_songs_list[3][1]+violator_songs_list[5][1]+violator_songs_list[-1][1], 2)
print('Три песни звучат: ', time, ' минуты')


violator_songs_dict = {
    'World in My Eyes': 4.76,
    'Sweetest Perfection': 4.43,
    'Personal Jesus': 4.56,
    'Halo': 4.30,
    'Waiting for the Night': 6.07,
    'Enjoy the Silence': 4.6,
    'Policy of Truth': 4.88,
    'Blue Dress': 4.18,
    'Clean': 5.68,
}


secondtime = round(violator_songs_dict['Sweetest Perfection'] + violator_songs_dict['Policy of Truth'] + violator_songs_dict['Blue Dress'])
print('А другие три песни звучат: ', secondtime, 'минут')
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/6.png)

## Задание №8
Дано зашифрованное сообщение, необходимо его расшифровать и вывести на консоль
* Ключ к расшифровке:
первое слово - 4-я буква
второе слово - буквы с 10 по 13, включительно
третье слово - буквы с 6 по 15, включительно, через одну
четвертое слово - буквы с 8 по 13, включительно, в обратном порядке
пятое слово - буквы с 17 по 21, включительно, в обратном порядке
## Результат вычислений: 
```
secret_message = [
    'квевтфпп6щ3стмзалтнмаршгб5длгуча',
    'дьсеы6лц2бане4т64ь4б3ущея6втщл6б',
    'т3пплвце1н3и2кд4лы12чф1ап3бкычаь',
    'ьд5фму3ежородт9г686буиимыкучшсал',
    'бсц59мегщ2лятьаьгенедыв9фк9ехб1а',
]


a = secret_message[0][3]
b = secret_message[1][9:13]
c = secret_message[2][5:14:2]
d = secret_message[3][7:13][::-1]
e = secret_message[4][16:21][::-1]
print(a, b, c, d, e)
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/7.png)

## Задание №9
Даны луг и сад, необходимо узнать:
1) Какие цветы растут и там, и там
2) Какие цветы растут в саду, но не растут в лугу
3) Какие цветы растут на лугу, но не растут в саду
## Результат вычислений:
```
#!/usr/bin/env python3
# -*- coding: utf-8 -*-

# в саду сорвали цветы
garden = ('ромашка', 'роза', 'одуванчик', 'ромашка', 'гладиолус', 'подсолнух', 'роза', )

# на лугу сорвали цветы
meadow = ('клевер', 'одуванчик', 'ромашка', 'клевер', 'мак', 'одуванчик', 'ромашка', )

# создайте множество цветов, произрастающих в саду и на лугу
# garden_set =
# meadow_set =
# TODO здесь ваш код

garden_set = set(garden)
meadow_set = set(meadow)

# выведите на консоль все виды цветов
# TODO здесь ваш код

print ('Все виды цветов: ', 'Сад - ', str(garden_set), 'Луг - ', str(meadow_set))

# выведите на консоль те, которые растут и там и там
# TODO здесь ваш код

together=garden_set&meadow_set
print('Растут и там и там: ', together)

# выведите на консоль те, которые растут в саду, но не растут на лугу
# TODO здесь ваш код

print('Растут в саду, но не растут на лугу: ', garden_set-meadow_set)

# выведите на консоль те, которые растут на лугу, но не растут в саду
# TODO здесь ваш код

print('Растут на лугу, но не растут в саду: ', meadow_set-garden_set)

```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/8.png)

## Задание №10
Дан словарь магазинов с распродажами, нужно создать словарь цен на продукты следующего вида.
## Результат вычислений:
```
shops = {
    'ашан':
        [
            {'name': 'печенье', 'price': 10.99},
            {'name': 'конфеты', 'price': 34.99},
            {'name': 'карамель', 'price': 45.99},
            {'name': 'пирожное', 'price': 67.99}
        ],
    'пятерочка':
        [
            {'name': 'печенье', 'price': 9.99},
            {'name': 'конфеты', 'price': 32.99},
            {'name': 'карамель', 'price': 46.99},
            {'name': 'пирожное', 'price': 59.99}
        ],
    'магнит':
        [
            {'name': 'печенье', 'price': 11.99},
            {'name': 'конфеты', 'price': 30.99},
            {'name': 'карамель', 'price': 41.99},
            {'name': 'пирожное', 'price': 62.99}
        ],
}


sweets = {
    'название сладости': [
        {'shop': 'название магазина', 'price': 99.99},
        'печенье'
    ],

    'печенье':[{'shop':'пятёрочка', 'price':9.99},
               {'shop':'ашан', 'price':10.99},],
    'конфеты':[{'shop':'магнит', 'price':30.99},
               {'shop':'пятёрочка', 'price':32.99,}],
    'карамель':[{'shop':'магнит', 'price':41.99},
               {'shop':'ашан', 'price':45.99},],
    'пироженое':[{'shop':'пятёрочка', 'price':59.99,},
                 {'shop':'магнит', 'price':62.99},
            ] 
}

print(sweets)
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/9.png)

## Задание №11
Дан словарь кодов товаров и словарь списка количества товаров на складе, нужно рассчитать на какую сумму лежит каждого товара на складе.
## Результат вычислений:
```
goods = {
    'Лампа': '12345',
    'Стол': '23456',
    'Диван': '34567',
    'Стул': '45678',
}


store = {
    '12345': [
        {'quantity': 27, 'price': 42},
    ],
    '23456': [
        {'quantity': 22, 'price': 510},
        {'quantity': 32, 'price': 520},
    ],
    '34567': [
        {'quantity': 2, 'price': 1200},
        {'quantity': 1, 'price': 1150},
    ],
    '45678': [
        {'quantity': 50, 'price': 100},
        {'quantity': 12, 'price': 95},
        {'quantity': 43, 'price': 97},
    ],
}


lamps_cost = store[goods['Лампа']][0]['quantity'] * store[goods['Лампа']][0]['price']
lamp_code = goods['Лампа']
lamps_item = store[lamp_code][0]
lamps_quantity = lamps_item['quantity']
lamps_price = lamps_item['price']
lamps_cost = lamps_quantity * lamps_price
print('Лампа -', lamps_quantity, 'шт, стоимость', lamps_cost, 'руб')


table_cost1=0
table_code = goods['Стол']
table_cost=(store[goods['Стол']][0]['quantity']*store[goods['Стол']][0]['price'])+(store[goods['Стол']][1]['quantity']*store[goods['Стол']][1]['price'])
table_quantity = (store[goods['Стол']][0]['quantity'])+(store[goods['Стол']][1]['quantity'])
print('Стол -', table_quantity, 'шт, стоимость', table_cost, 'руб')

chear_cost = (store[goods['Стул']][0]['quantity']*store[goods['Стул']][0]['price'])+(store[goods['Стул']][1]['quantity']*store[goods['Стул']][1]['price'])+(store[goods['Стул']][2]['quantity']*store[goods['Стул']][2]['price'])
chear_code = goods['Стул']
chear_item = (store[goods['Стул']][0]['quantity'])+(store[goods['Стул']][1]['quantity'])+(store[goods['Стул']][2]['quantity'])
print('Стул -', chear_item, 'шт, стоимость', chear_cost, 'руб')

print('Диван -', (store[goods['Диван']][0]['quantity'])+(store[goods['Диван']][1]['quantity']), 'шт, стоимость', (store[goods['Диван']][0]['quantity']*store[goods['Диван']][0]['price'])+store[goods['Диван']][1]['quantity']*store[goods['Диван']][1]['price'], 'руб')
```
![](https://github.com/manabreako/python/blob/main/%D0%B1%D0%B5%D0%B1%D1%80%D0%B0/SCRENS/10.png)

# Список использованных источников: 
1) [Подробная информация об обратных срезах](https://clck.ru/MfEMS)
2) [Функция round](https://docs.python.org/3/search.html?q=round)

# Шпаргалка по работе с командами git:
* git add - добавление файлов в индекс;
* git status - проверка статуса репозитория;
* git push - отправка изменений в удаленный репозиторий;
* git restote - отмена изменений;
* git commit - добавление файлов в репозиторий.
