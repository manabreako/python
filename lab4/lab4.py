import sys
from io import StringIO

def dekor(func):
    def wrapper(*args, **kwargs):       
        sys.stdout = StringIO()
    return wrapper

def hp_track():
    hp = 100 

    def modify_hp(kolvo):
        nonlocal hp  
        hp += kolvo
        if hp > 100:
            hp = 100
        elif hp < 0:
            hp = 0
        return hp

    return modify_hp

hero_hp = hp_track()

#@dekor
def print_hp():
    print(f"Текущие HP героя: {hero_hp(0)}")

print_hp()
hero_hp(-20)
print_hp()
hero_hp(45)
print_hp()