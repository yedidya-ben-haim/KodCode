# region Exercise 1

class Dog:
    def __init__(self, name):
        self.name = name

    def bark(self):
        return self.name + " says woof"

# endregion

# region Exercise 2

class Rectangle:
    def __init__(self, width, height):
        self.width = width
        self.height = height

        def area(self):
            return self.width * self.height

# endregion

# region Exercise 3

class Counter:
    def __init__(self):
        self.count = 0

    def increment(self):
        self.count += 1

    def value(self):
        return self.count

# endregion

# region Exercise 4

class Point:
    def __init__(self, x, y):
        self.x = x
        self.y = y

    def __str__(self):
        return f"({self.x}, {self.y})"

# endregion

# region Exercise 5

class BankAccount:
    def __init__(self):
        self.balance = 0

    def deposit(self, amount):
        self.balance += amount

    def withdraw(self, amount):
        if amount <= self.balance:
            self.balance -= amount

# endregion

# region Exercise 6

class Temperature:
    def __init__(self, celsius):
        self.celsius = celsius

    def to_fahrenheit(self):
        return (self.celsius * 9 / 5) + 32

# endregion

# region Exercise 7

class Student:

    school = "Kodcode"

    def __init__(self, name):
        self.name = name

student1 = Student("avi")
student2 = Student("david")
student1.school= "kodcode-2"

# endregion

# region Exercise 8

class Player:
    counter = 0

    def __init__(self, name):
        self.name = name
        Player.counter += 1

# endregion

# region Exercise 9

class Money:
    def __init__(self, amount):
        self.amount = amount

    def is_more_than(self, other):
        return self.amount > other.amount

# endregion

# region Exercise 10

class Playlist:
    def __init__(self, list_of_songs):
        self.songs = list_of_songs

    def add(self, title):
        self.songs.append(title)

    def remove(self, title):
        self.songs.remove(title)

    def count(self):
        return len(self.songs)

    def __str__(self):
        return ", ".join(self.songs)

# endregion








