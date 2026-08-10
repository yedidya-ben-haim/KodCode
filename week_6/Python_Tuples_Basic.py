# region Exercise 1
import math


def sum_of_tuple(tup):
    total_sum = 0
    for num in tup:
        total_sum += num
    return total_sum

# endregion

# region Exercise 2

def max_in_tuple(tup):
    max_num = 0
    for num in tup:
        if num > max_num:
            max_num = num
    return max_num

# endregion

# region Exercise 3

def count_occurrences(tup, value):
    occurrences = 0
    for num in tup:
        if num == value:
            occurrences += 1
    return occurrences

# endregion

# region Exercise 4

def reverse_tuple(tup):
    reversed_list = []
    for i in range(len(tup) -1, -1, -1):
        reversed_list.append(tup[i])
    return tuple(reversed_list)

# endregion

# region Exercise 5

def swap_pairs(tup):
    new_list = []

    for i in range(0, len(tup), 2):
        new_list.append(tup[i + 1])
        new_list.append(tup[i])

    return tuple(new_list)

# endregion

# region Exercise 6

def min_max_tuple(tup):
    min_num = tup[0]
    max_num = tup[0]
    for num in tup:
        if num < min_num:
            min_num = num
        elif num > max_num:
            max_num = num
    return min_num, max_num

# endregion

# region Exercise 7

import math

def distance_between_points(point1, point2):
    x1, y1 = point1
    x2, y2 = point2

    return math.sqrt((x1 - x2) ** 2 + (y1 - y2) ** 2)

# endregion

# region Exercise 8

def merge_and_sort_tuple(tup1, tup2):
    list1 = sorted(tup1)
    list2 = sorted(tup2)

    pos_1 = 0
    pos_2 = 0
    sorted_list = []

    while pos_1 < len(list1) and pos_2 < len(list2):
        if list1[pos_1] < list2[pos_2]:
            sorted_list.append(list1[pos_1])
            pos_1 += 1
        else:
            sorted_list.append(list2[pos_2])
            pos_2 += 1

    sorted_list.extend(list1[pos_1:])
    sorted_list.extend(list2[pos_2:])

    return tuple(sorted_list)

# endregion

# region Exercise 9

def frequency_table(tup):
    dict_of_freq = {}
    for item in tup:
        if item not in dict_of_freq:
            dict_of_freq[item] = 1
        else:
            dict_of_freq[item] += 1

    return tuple(dict_of_freq.items())

# endregion

# region Exercise 10

def rotate_a_tuple(tup, k):
    if len(tup) == 0:
        return tup

    k = k % len(tup)

    new_tup = tup[-k:] + tup[:-k]
    return new_tup

# endregion








