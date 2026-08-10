# region Exercise 1

count_Ex1 = 0
def bump():
    global count_Ex1
    count_Ex1 += 1
def value():
    return count_Ex1

# endregion

# region Exercise 2

def make_counter():
    num = 0

    def counter():
        nonlocal num
        num += 1
        return num

    return counter

# endregion

# region Exercise 3

output = """local
        enclosing
        global"""

# endregion

# region Exercise 4

# Because we overrode the list method

# correct way
new_list = [1,2,3]
print(list(range(5)))

# endregion

# region Exercise 7

from datetime import datetime as dt; print(dt.now())

# endregion

# region Exercise 8

def public_names(m):

    all_names = dir(m)
    public_list = []

    for name in all_names:
        if not name.startswith('_'):
            public_list.append(name)

    return sorted(public_list)

# endregion

# region Exercise 9

def add_item(item, bag=None):
    if bag is None:
        bag = []

    bag.append(item)
    return bag

# endregion









