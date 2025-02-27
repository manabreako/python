a=216**6+216**4+36**6-6**14-24
f=[]
while a>0:
    z=a%6
    f+=[z]
    a=a//6
f.reverse()
k=set(f)
print(len(k))