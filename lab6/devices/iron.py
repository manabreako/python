def count_iron(power, hours, cost_per_kwh):
    energy_kwh = (power / 1000) * hours  
    cost = energy_kwh * cost_per_kwh  
    return round(energy_kwh, 2), round(cost, 2)
