def recurs(x, k):
    # Рекурсивная функция, которая считает произведение элементов последовательности
    if k == 0:
        return 1
    elif k == 1:
        return 1 / (2 * x) 
    else:
        bk = recurs(x, k - 1) * (x ** 2) 
    return bk * recurs(x, k - 1)


def iterative(x, k):
    y = 1  
    b = 1 / (2 * x)  
    for i in range(1, k + 1):
        y *= b  
        b *= (x ** 2)  
    return y


def create_n_m(n, size, lvl=None):
    # Рекурсивное создание n-мерного массива
    if lvl is None:
        lvl = n 
    if lvl == 1:
        return ['lvl ' + str(n)] * size 
    return [create_n_m(n, size, lvl - 1) for _ in range(size)]


def creat_n_mas_inter(n, size):
    # Итеративное создание n-мерного массива
    result = ['lvl ' + str(n)] * size
    for _ in range(1, n):
        result = [result[:] for _ in range(size)]
    return result

print("Результат рекурсивной функции:", recurs(2, 3))     
print("Результат итеративной функции:", iterative(2, 3))       

# Создание и вывод двумерного массива
res2d = create_n_m(2, 3)
print("\nДвумерный массив:\n[")
for item in res2d:
    print(" ", item)
print("]")

# Создание и вывод трёхмерного массива
res3d = create_n_m(3, 2)
print("\nТрехмерный массив:")
print("[")
for i in range(len(res3d)):
    print("   [")
    for j in res3d[i]:
        print("     ", j, ",") 
    print("   ],")
print("]")

# Создание и вывод двумерного массива через итеративный метод
res2d = creat_n_mas_inter(2, 3)
print("\nДвумерный массив(итеративный метод):\n[")
for item in res2d:
    print(" ", item) 
print("]")

# Создание и вывод трёхмерного массива через итеративный метод 
res3d = creat_n_mas_inter(3, 2)
print("\nТрёхмерный массив(итеративный метод):")
print("[")
for i in range(len(res3d)):
    print(" [")
    for j in res3d[i]:
        print(" ", j, ",")
    print (" ]")
print(" ]")