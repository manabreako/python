from abc import ABC, abstractmethod # ABC — для создания абстрактных классов

# Абстрактный базовый класс для всех электроприборов
class Device(ABC):
    def __init__(self, power, hours, rate):
        self._power = power
        self._hours = hours   # - managed atributes 
        self._rate = rate

    @abstractmethod
    def calculate(self): # - абстрактный метод
        pass

    @property
    def power(self): 
        return self._power # атрибуты

    @power.setter
    def power(self, value):
        self._power = value 

    @property
    def hours(self):
        return self._hours 

    @hours.setter
    def hours(self, value):
        self._hours = value 

    def __str__(self): # - используется при печати print(device)
        return f"{self.__class__.__name__} (P={self._power}W, H={self._hours}h, Rate={self._rate})"
    
    # Dunder-методы, дают строку с названием прибора и его параметрами

    def __repr__(self): # - техническое представление объекта, например в списках
        return self.__str__()
    
    