# #!/usr/bin/env python3
# # -*- coding: utf-8 -*-

# # Есть словарь координат городов

# sites = {
#     'Moscow': (550, 370),
#     'London': (510, 510),
#     'Paris': (480, 480),
# }

# # Составим словарь словарей расстояний между ними
# # расстояние на координатной сетке - ((x1 - x2) ** 2 + (y1 - y2) ** 2) ** 0.5

# distances = {}

# # TODO здесь заполнение словаря
# distances = {
#     'moskow > london' : (((550-510)**2 + (370-510)**2)**0.5),
#     'london > paris' : (((510-480)**2 + (510-480)**2)**0.5),
#     'paris > moskow' : (((480-550)**2 + (480-370)**2)**0.5),
# }

# print(distances)

#!/usr/bin/env python3
# -*- coding: utf-8 -*-

sites = {
    'Moscow': (550, 370),
    'London': (510, 510),
    'Paris': (480, 480),
}

distances = {}

for city1, x1 in sites.items():
    distances[city1] = {}
    for city2, x2 in sites.items():
        if city1 != city2:
            distance = (((x1[0] - x2[0]) ** 2) + ((x1[1] - x2[1]) ** 2)) ** 0.5
            distances[city1][city2] = distance

print(distances)





