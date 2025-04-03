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