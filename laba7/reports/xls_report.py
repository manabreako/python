import openpyxl

def save_to_excel(device_name, energy, cost, filename="report.xlsx"):
    wb = openpyxl.Workbook()
    ws = wb.active
    ws.title = "Энергопотребление"
    ws.append(["Прибор", "Энергия (кВт·ч)", "Стоимость (руб.)"])
    ws.append([device_name, energy, cost])
    wb.save(filename)