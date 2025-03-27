# Отчёт по лабораторной работе №4

## Задание
Замыкание для отслеживания количества HP героя - HP не может подниматься больше 100 и опускаться ниже 0, герой может лечиться или получать урон.
Декоратор для подавления вывода функции на консоль.
## Результат вычислений: 
В результате программа корректно изменяет HP героя, отображая его текущее состояние после каждой модификации.
```
import sys
from io import StringIO

def dekor(func):
    def cover(*args, **kwargs):       
        sys.stdout = StringIO()
    return cover

def hp_track():
    hp = 100 

    def modify_hp(kolvo):
        nonlocal hp  
        hp += kolvo
        if hp > 100:
            hp = 100
        elif hp < 0:
            hp = 0
        return hp

    return modify_hp

hero_hp = hp_track()

#@dekor
def print_hp():
    print(f"Текущие HP героя: {hero_hp(0)}")

print_hp()
hero_hp(-20)
print_hp()
hero_hp(45)
print_hp()
```

![](https://github.com/manabreako/python/blob/main/lab4/Screenshot_20250327_115458.png)


# Список использованных источников: 
1) [Декоратор для кэширования](https://clck.ru/MfEMS)
2) [Замыкание](https://docs.python.org/3/search.html?q=round)
