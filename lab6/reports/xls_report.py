import openpyxl

def save_to_excel(device, energy, cost, filename="report.xlsx"):
    wb = openpyxl.Workbook()
    ws = wb.active
    ws.title = "Энергопотребление"
    
    ws.append(["Прибор", "Энергия (кВт·ч)", "Цена (р.)"])
    ws.append([device, energy, cost])
    
    wb.save(filename)