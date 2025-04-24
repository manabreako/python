# Отчёт по лабораторной работе №3

## Задание
Напишите две функции для решения задач своего варианта - с использованием рекурсии и без.
## Результат вычислений: 
Выполняется две функции одна для с рекурсией другая с итерацией, далее создаётся два массива и в результате программа выдает функцию для создания n-мерных массивов.
```Python
def recurs(x, k):
    if k == 0:
        return 1
    elif k == 1:
        b_k = 1 / (2 * x)
    else:
        b_k = recurs(x, k - 1) * (x ** 2)
    return b_k * recurs(x, k - 1)

def iterative(x, k):
    y = 1
    b = 1 / (2 * x)
    for i in range(1, k + 1):
        y *= b
        b *= (x ** 2)
    return y

def create_n_dim_array(n, size, lvl=None):
    if lvl is None:
        lvl = n
    
    if lvl == 1:
        return ['level ' + str(n)] * size
    
    return [create_n_dim_array(n, size, lvl - 1) for _ in range(size)]

def create_n_dim_arrayIterative(n, size):

    result = ['level ' + str(n)] * size
    
    for _ in range(1, n):
        result = [result[:] for _ in range(size)]

    return result

print("Результат рекурсивной функции:", recurs(2, 3))     
print("Результат итеративной функции:", iterative(2, 3))       

# Создание и вывод двумерного массива размером 3x3
result_2d = create_n_dim_array(2, 3)
print("\nДвумерный массив:\n[")
for item in result_2d:
    print(" " , item)
print("]")

# Создание и вывод трехмерного массива размером 2x2x2
result_3d = create_n_dim_array(3, 2)
print("\nТрехмерный массив:")
print("[")
for i in range(len(result_3d)):
    print("   [") 
    for j in result_3d[i]:
        print("     ", j, ",") 
    print("   ],") 
print("]")

# Создание и вывод iterativeдвумерного массива размером 3x3
result_2d = create_n_dim_arrayIterative(2, 3)
print("\nДвумерный массив:\n[")
for item in result_2d:
    print(" " , item)
print("]")

# Создание и вывод iterativeтрехмерного массива размером 2x2x2
result_3d = create_n_dim_arrayIterative(3, 2)
print("\nТрехмерный массив:")
print("[")
for i in range(len(result_3d)):
    print("   [") 
    for j in result_3d[i]:
        print("     ", j, ",") 
    print("   ],") 
print("]")
```
### Результат 
![](https://github.com/manabreako/python/blob/main/laba03/Screenshot_20250424_161654.png)


# Список использованных источников: 
1) [Рекурсивные функции](https://proglib.io/p/samouchitel-po-python-dlya-nachinayushchih-chast-13-rekursivnye-funkcii-2023-01-23)
2) [Понимание итераторов в Python](https://habr.com/ru/articles/488112/)
