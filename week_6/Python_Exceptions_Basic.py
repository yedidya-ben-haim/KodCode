# region Exercise 1

def safe_int(s):
    try:
        return int(s)
    except (ValueError, TypeError):
        return None

# endregion

# region Exercise 2

def safe_divide(a, b):
    try:
        return a / b
    except ZeroDivisionError:
        return "undefined"

# endregion

# region Exercise 3

def get_value(d, key):
    try:
        return d[key]
    except KeyError:
        return "missing"

# endregion

# region Exercise 4

def parse_ints(values):
    result = []
    for value in values:
        try:
            result.append(int(value))
        except (ValueError, TypeError):
            pass
    return result

# endregion

# region Exercise 5

def set_age_clean(age):
    if 0 <= age <= 150:
        return age

    raise ValueError("Age out of range")

# endregion

# region Exercise 6

def retry(func, n):
    last_exception = None

    for i in range(n):
        try:
            return func()
        except Exception as e:
            last_exception = e

    raise last_exception

# endregion

# region Exercise 7

def count_errors(funcs):
    errors_count = 0

    for fun in funcs:
        try:
            fun()
        except Exception:
            errors_count += 1

    return errors_count

# endregion

# region Exercise 8

def load_config(path):
    try:
        with open(path, "r") as f:
            first_line = f.readline()
            return int(first_line.strip())
    except Exception as e:
        raise RuntimeError("failed to load config") from e

# endregion

