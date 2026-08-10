import os

# region Part 1

part1_file = ["15-01-2024\n", "16-01-2024\n","17-01-2024\n"]

with open("diary.txt","w", encoding="utf-8") as f:
    f.writelines(part1_file)
    print("היומן נוצר בצלחה")

with open("diary.txt","r", encoding="utf-8") as f:
    print(f.read())

# endregion

# region Part 2

def add_entry(filename, date, content):
    with open(filename, "a", encoding="utf-8") as f:
        f.writelines(f"{date}: {content}\n")

# endregion

#region Part 3

import os


def safe_read_diary(filename):
    if os.path.exists(filename):
        with open(filename, "r", encoding="utf-8") as f:
            return f.readlines()
    else:
        raise FileNotFoundError(f"הקובץ {filename} לא נמצא")


def search_diary(filename, keyword):
    keyword_list = []

    try:
        lines = safe_read_diary(filename)

        for line in lines:
            if keyword in line:
                keyword_list.append(line.strip())
        return keyword_list

    except FileNotFoundError:
        print("file not found")
