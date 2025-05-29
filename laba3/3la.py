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
    
    array = [create_n_dim_array(n, size, level - 1) for _ in range(size)]
    
    if level == n:
        if n == 2:
            print("\nДвумерный массив:\n[")
            for item in array:
                print(" ", item)
            print("]")
        elif n == 3:
            print("\nТрехмерный массив:")
            print("[")
            for i in range(len(array)):
                print("   [") 
                for j in array[i]:
                    print("     ", j, ",") 
                print("   ],") 
            print("]")
    
    return array

def create_n_dim_arrayIterative(n, size):
    result = ['level ' + str(n)] * size
    
    for _ in range(1, n):
        result = [result[:] for _ in range(size)]
    
    if n == 2:
        print("\nДвумерный массив (итеративный):\n[")
        for item in result:
            print(" ", item)
        print("]")
    elif n == 3:
        print("\nТрехмерный массив (итеративный):")
        print("[")
        for i in range(len(result)):
            print("   [") 
            for j in result[i]:
                print("     ", j, ",") 
            print("   ],") 
        print("]")
    
    return result

# Тестирование функций
print("Результат рекурсивной функции:", recursive(2, 3))     
print("Результат итеративной функции:", iterative(2, 3))       

# Создание и вывод массивов
create_n_dim_array(2, 3)
create_n_dim_array(3, 2)
create_n_dim_arrayIterative(2, 3)
create_n_dim_arrayIterative(3, 2)