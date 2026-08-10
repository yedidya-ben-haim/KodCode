# region Exercise 1

def calculate_dict_sum(my_dict):
    total_sum = 0

    for value in my_dict.values():
        total_sum += value

    return total_sum

# endregion

# region Exercise 2

def maximum_value_key(my_dict):
    max_value = float('-inf')
    max_value_key = None
    for key, value in my_dict.items():
        if value > max_value:
            max_value = value
            max_value_key = key
    return max_value_key

# endregion

# region Exercise 3

def count_characters(my_str):
    new_dict = {}
    for character in my_str:
        if character in new_dict:
            new_dict[character] += 1
        else:
            new_dict[character] = 1

    return new_dict

# endregion

# region Exercise 4

def invert_a_dictionary(my_dict):
    new_dict = {}

    for key, value in my_dict.items():
        new_dict[value] = key

    return new_dict

# endregion

# region Exercise 5

def merge_two_dictionaries(my_dict1, my_dict2):
    new_dict = my_dict1.copy()
    new_dict.update(my_dict2)

    return new_dict

# endregion

# region Exercise 6

def filter_dictionary(my_dict, threshold):
    new_dict = {}
    for key, value in my_dict.items():
        if value > threshold:
            new_dict[key] = value
    return new_dict

# endregion

# region Exercise 7

def group_by_first_letter(list_of_words):
    new_dict = {}
    for word in list_of_words:
        letter = word[0]
        if letter not in new_dict:
            new_dict[letter] = [word]
        else:
            new_dict[letter].append(word)
    return new_dict

# endregion

# region Exercise 8

def count_the_words(text):

    words_list = text.split()
    word_counts = {}

    for word in words_list:
        if word not in word_counts:
            word_counts[word] = 1
        else:
            word_counts[word] += 1

    return word_counts

# endregion

# region Exercise 9

def find_common_keys(dict1, dict2):
    common_keys = []

    for key in dict1:
        if key in dict2:
            common_keys.append(key)

    return sorted(common_keys)

# endregion

# region Exercise 10

def find_most_frequent_value(my_dict):
    if not my_dict:
        return None

    value_counts = {}
    for value in my_dict.values():
        value_counts[value] = value_counts.get(value, 0) + 1

    max_count = float('-inf')
    most_frequent = None

    for value, count in value_counts.items():
        if count > max_count:
            max_count = count
            most_frequent = value

    return most_frequent

# endregion