# region Part 1

def create_grades_file(filename):
    students = [
        ("Dan", [85, 90, 78]),
        ("MOMO", [92, 88, 95]),
        ("Yoni", [70, 65, 80]),
        ("Avi", [100, 95, 98]),
        ("Sara", [60, 72, 68]),
        ]
    with open("grades.txt", "w") as file:
        for name, grade in students:
            line = f"{name},{grade[0]},{grade[1]},{grade[2]}\n"
            file.write(line)

# endregion

# region Part 2

def calculate_averages(filename):
    """
    קוראת את grades.txt, ומחשבת ממוצע לכל סטודנט
    מחזיר:
    dict: {שם: ממוצע}
    """
    averages = {}

    with open("grades.txt", "r") as file:
        for line in file:
            line = line.strip().split(",")

            name = line[0]
            grade1 = float(line[1])
            grade2 = float(line[2])
            grade3 = float(line[3])

            student_average = (grade1 + grade2 + grade3) / 3

            averages[name] = student_average

    return averages

results = calculate_averages('grades.txt')
for name, avg in results.items():
    print(f'{name}: {avg:.1f}')

# endregion

# region Part 3

def save_results(averages, output_filename):
    """
    פונקציה המקבלת מילון של ממוצעים ושם קובץ פלט,
    ומשמרת את התוצאות ממוינות מהגבוה לנמוך ללא שימוש ב-enumerate.
    """

    sorted_averages = sorted(averages.items(), key=lambda item: item[1], reverse=True)


    with open(output_filename, 'w', encoding='utf-8') as f:

        f.write("=== Student Results ===\n")


        counter = 1


        for name, avg in sorted_averages:

            f.write(f"{counter}. {name}: {avg:.1f}\n")

            # קידום המונה ב-1 לקראת הסטודנט הבא
            counter += 1

# endregion

# region Part 4

def save_results_with_statistics(averages, output_filename):
    """
        פונקציה המקבלת מילון של ממוצעים, כותבת את הסטודנטים הממוינים
        ומוסיפה בסוף הקובץ סטטיסטיקה כיתתית.
    """
    sorted_averages = sorted(averages.items(), key=lambda item: item[1], reverse=True)
    total_students = len(sorted_averages)

    # חישוב ממוצע של הכיתה
    sum_of_averages = sum(averages.values())
    class_average = sum_of_averages / total_students

    # הציון הגבוה והנמוך ביותר (שולפים לפי המיקום ברשימה הממוינת)
    highest_student, highest_avg = sorted_averages[0]
    lowest_student, lowest_avg = sorted_averages[-1]

    # ספירת הסטודנטים העוברים (ציון >= 60)
    passing_count = 0
    for name, avg in sorted_averages:
        if avg >= 60:
            passing_count += 1


    # כתיבה לקובץ
    with open(output_filename, 'w', encoding='utf-8') as f:
        f.write("=== Student Results ===\n")
        counter = 1
        for name, avg in sorted_averages:
            f.write(f"{counter}. {name}: {avg:.1f}\n")
            counter += 1

        f.write("\n=== Statistics ===\n")
        f.write(f"Class average: {class_average:.1f}\n")
        f.write(f"Highest: {highest_student} {highest_avg:.1f}\n")
        f.write(f"Lowest: {lowest_student} {lowest_avg:.1f}\n")
        f.write(f"Passing (>=60): {passing_count}/{total_students}\n")

# endregion