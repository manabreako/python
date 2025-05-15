from .base_device import Device

class Iron(Device):
    def calculate(self):
        energy = (self.power / 1000) * self.hours
        cost = energy * self._rate
        return round(energy, 2), round(cost, 2)
