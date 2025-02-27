from fnmatch import*
for a in range(23, 10**9+1,23):
    s=str(a)
    if fnmatch(s, '12345?7?8')==1:
        print(a, a//23)
print('все')