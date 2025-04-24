def rekurs(x, k):
    if k == 0:
        return 1
    elif k == 1:
        b_k = 1 / (2 * x)
    else:
        b_k = rekurs(x, k - 1) * (x ** 2)
    return b_k * rekurs(x, k - 1)

def iterav(x, k):
    y = 1
    b = 1 / (2 * x)
    for i in range(1, k + 1):
        y *= b
        b *= (x ** 2)
    return y

def n_massiv_array(n, size, lvl=None):
    if lvl is None:
        lvl = n
    
    if lvl == 1:
        return ['lvl ' + str(n)] * size
    
    return [n_massiv_array(n, size, lvl - 1) for _ in range(size)]

def n_massiv_arrayiterav(n, size):

    result = ['lvl ' + str(n)] * size
    
    for _ in range(1, n):
        result = [result[:] for _ in range(size)]

    return result

print("Результат рекурсивной функции:", rekurs(2, 3))     
print("Результат итеративной функции:", iterav(2, 3))       

# Создание и вывод двумерного массива размером 3x3
result_2d = n_massiv_array(2, 3)
print("\nДвумерный массив:\n[")
for item in result_2d:
    print(" " , item)
print("]")

# Создание и вывод трехмерного массива размером 2x2x2
result_3d = n_massiv_array(3, 2)
print("\nТрехмерный массив:")
print("[")
for i in range(len(result_3d)):
    print("   [") 
    for j in result_3d[i]:
        print("     ", j, ",") 
    print("   ],") 
print("]")

# Создание и вывод iteravдвумерного массива размером 3x3
result_2d = n_massiv_arrayiterav(2, 3)
print("\nДвумерный массив:\n[")
for item in result_2d:
    print(" " , item)
print("]")

# Создание и вывод iteravтрехмерного массива размером 2x2x2
result_3d = n_massiv_arrayiterav(3, 2)
print("\nТрехмерный массив:")
print("[")
for i in range(len(result_3d)):
    print("   [") 
    for j in result_3d[i]:
        print("     ", j, ",") 
    print("   ],") 
print("]")