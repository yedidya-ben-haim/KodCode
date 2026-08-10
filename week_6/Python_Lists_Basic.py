# region Exercises 1

def sum_of_list(lst):
    total = 0
    for num in lst:
        total += num
    return total

# endregion

# region Exercises 2

def max_of_list(lst):
    maximum = lst[0]

    for num in lst:
        if num > maximum:
            maximum = num
    return maximum

# endregion

# region Exercises 3

def count_occurrences(lst, value):
    occurrences = 0
    for num in lst:
        if num == value:
            occurrences += 1
    return occurrences

# endregion

# region Exercises 4

def reverse_list(lst):
    reversed_lst = []
    for i in range(len(lst) - 1, -1, -1):
        reversed_lst.append(lst[i])
    return reversed_lst

# endregion

# region Exercises 5

def remove_duplicates(lst):
    unique_list = []
    for num in lst:
        if num not in unique_list:
            unique_list.append(num)
    return unique_list

# endregion

# region Exercises 6

def second_largest_elegant(lst):

    unique_nums = remove_duplicates(lst)

    if len(unique_nums) < 2:
        return None

    unique_nums.sort()
    return unique_nums[-2]

# endregion

# region Exercises 7

def merge_two_sorted_lists(lst1, lst2):
    new_lst = lst1 + lst2
    new_lst.sort()
    return new_lst


# endregion

# region Exercises 8

def rotate_list(lst, k):
    if not lst:
        return lst

    k = k % len(lst)

    new_lst = lst[-k:] + lst[:-k]
    return new_lst

# endregion

