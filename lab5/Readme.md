# Отчёт по лабораторной работе №5

## Задание
Генератор для объединения последовательностей по заданной стратегии. Сверните возвращемые последовательности в зависимости от типа данных в них.
## Результат вычислений: 
Код объединяет несколько списков в один. Затем он проверяет тип данных и сворачивает их: числа суммируются, строки склеиваются, булевы значения объединяются через and, а списки соединяются. Если список пустой, возвращается None.
```
from functools import reduce
from itertools import chain
def sequence_merger(*sequences):

    # Объединяем все последовательности в одну
    merged = list(chain(*sequences))

    # Определяем тип первого элемента
    first_item = merged[0] if merged else None

    if first_item is None:
        yield None
        return

    if isinstance(first_item, (int, float)):
        result = reduce(lambda x, y: x + y, merged, 0)
    elif isinstance(first_item, str):
        # Если строки, то склеиваем их
        result = reduce(lambda x, y: x + y, merged, '')
    elif isinstance(first_item, bool):
        result = reduce(lambda x, y: x and y, merged, True)
    elif isinstance(first_item, list):
        result = reduce(lambda x, y: x + y, merged, [])
    yield result

sequences_str = (["Алоха", "-"], ["Денс", ")"])
print(list(sequence_merger(*sequences_str)))

sequences = ([1, 2, 3], [4, 5, 6], [7, 8, 9])
print(list(sequence_merger(*sequences)))
```

![](https://github.com/manabreako/python/blob/main/lab5/scr/1c0a0551-e50c-47f7-8337-5a11559dac21.jpeg)

# Список использованных источников: 
1) [Подробная информация об Генераторах](https://clck.ru/MfEMS)
2) [Функция reduce](https://docs.python.org/3/search.html?q=round)

# Шпаргалка по работе с командами git:
* git add - добавление файлов в индекс;
* git status - проверка статуса репозитория;
* git push - отправка изменений в удаленный репозиторий;
* git restote - отмена изменений;
* git commit - добавление файлов в репозиторий.
