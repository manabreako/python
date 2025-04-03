# Отчёт по лабораторной работе №5

## Задание
Генератор для объединения последовательностей по заданной стратегии. Сверните возвращемые последовательности в зависимости от типа данных в них.
## Результат вычислений: 
Код объединяет несколько списков в один. Затем он проверяет тип данных и числа суммируются. Если список пустой, возвращается None.
```python
from functools import reduce
from itertools import chain

def sequence_merger(*sequences):
    merged = list(chain(*sequences))
    
    if not merged:
        yield None
    
    first_item = merged[0]
    if isinstance(first_item, (int, float)):
        yield merged
    else:
        yield None

def reduce_merger(*sequences):
    merged_result = list(sequence_merger(*sequences)) 
    return reduce(lambda x, y: x + y, merged_result[0], 0)

sequences = ([1, 2, 3], [4, 5, 6], [7, 8, 9])
print(reduce_merger(*sequences)) 
```

![](https://github.com/manabreako/python/blob/main/lab5/scr/5f75acde-9c29-4797-b361-1358eb199127.jpeg)

# Список использованных источников: 
1) [Подробная информация об Генераторах](https://clck.ru/MfEMS)
2) [Функция reduce](https://docs.python.org/3/search.html?q=round)

