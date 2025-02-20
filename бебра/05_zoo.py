#!/usr/bin/env python3
# -*- coding: utf-8 -*-

# есть список животных в зоопарке

zoo = ['lion', 'kangaroo', 'elephant', 'monkey', ]

# посадите медведя (bear) между львом и кенгуру
#  и выведите список на консоль
# TODO здесь ваш код

zoo.insert(1, 'bear')
print('Список животных после добавления медведя: ', zoo)

# добавьте птиц из списка birds в последние клетки зоопарка

birds = ['rooster', 'ostrich', 'lark', ]

#  и выведите список на консоль
# TODO здесь ваш код

zoo.extend(birds)
print('Список животных после добавления птиц: ', zoo)

# уберите слона
#  и выведите список на консоль
# TODO здесь ваш код

zoo.remove('elephant')
print('Список животных без слона: ', zoo)

# выведите на консоль в какой клетке сидит лев (lion) и жаворонок (lark).
# Номера при выводе должны быть понятны простому человеку, не программисту.
# TODO здесь ваш код

lion_pos = zoo.index('lion') + 1
lark_pos = zoo.index('lark') + 1
print(f'Лев сидит в клетке №{lion_pos}, а жаворонок в клетке №{lark_pos}')
