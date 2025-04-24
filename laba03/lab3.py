def recursive(x, k):
    if k == 0:
        return 1
    elif k == 1:
        b_k = 1 / (2 * x)
    else:
        b_k = recursive(x, k - 1) * (x ** 2)
    return b_k * recursive(x, k - 1)

def iterative(x, k):
    y = 1
    b = 1 / (2 * x)
    for i in range(1, k + 1):
        y *= b
        b *= (x ** 2)
    return y

def create_n_dim_array(n, size, level=None):
    if level is None:
        level = n
    
    if level == 1:
        return ['level ' + str(n)] * size
    
    return [create_n_dim_array(n, size, level - 1) for _ in range(size)]

def create_n_dim_arrayIterative(n, size):

    result = ['level ' + str(n)] * size
    
    for _ in range(1, n):
        result = [result[:] for _ in range(size)]

    return result

print("Результат рекурсивной функции:", recursive(2, 3))     
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