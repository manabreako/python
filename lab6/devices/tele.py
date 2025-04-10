def count_tele(power, hours, cost_per_kwh):
    energy_kwh = (power / 1000) * hours  # перевод в квт
    cost = energy_kwh * cost_per_kwh  # цена
    return round(energy_kwh, 2), round(cost, 2)  # возврат + округление до 2 знаков
