from itertools import*
k=0
for x in product('КАТЕР', repeat=6):
    s=''.join(x)
    if x[0]=='Р' and x[-1]=='К':
        k+=1
print(k)