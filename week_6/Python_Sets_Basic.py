# region Exercise 1

def remove_duplicates(input_list):
    new_set = set(input_list)

    result_list = list(new_set)

    return result_list

# endregion

# region Exercise 2

def count_distinct_elements(my_list):
    new_set = set()

    count = 0

    for item in my_list:
        if item not in new_set:
            count += 1
            new_set.add(item)

    return count

# endregion

# region Exercise 3

def find_common_elements(list1, list2):
    set1 = set(list1)
    set2 = set(list2)

    new_set = set1 & set2

    return sorted(new_set)

# endregion

# region Exercise 4

def elements_in_only_one(list1, list2):
    set1 = set(list1)
    set2 = set(list2)

    special_set = set1 ^ set2

    return sorted(list(special_set))

# endregion

# region Exercise 5

def is_subset(list_a, list_b):
    set_a = set(list_a)
    set_b = set(list_b)

    return set_a.issubset(set_b)

# endregion

# region Exercise 6

def unique_characters(text):

    text_length = len(text)
    set_length = len(set(text))

    return text_length == set_length

# endregion

# region Exercise 7

def first_repeated_element(lst):
    see = set()

    for item in lst:

        if item in see:
            return item

        see.add(item)

    return None

# endregion

# region Exercise 8

def count_distinct_words(text):

    lower_text = text.lower()
    words_list = lower_text.split()

    special_words = set(words_list)

    return len(special_words)

# endregion

# region Exercise 9

def pair_sum_exists(lst, target):
    see = set()

    for num in lst:
        complement = target - num
        if complement in see:
            return True
        see.add(num)

    return False

# endregion

# region Exercise 10

def sym_diff(list1, list2):
    set1 = set(list1)
    set2 = set(list2)
    result = []

    for item in set1:
        if item not in set2:
            result.append(item)

    for item in set2:
        if item not in set1:
            result.append(item)

    return sorted(result)

# endregion