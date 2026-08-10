def load_tasks(filename):
    """
    קוראת את הקובץ ומחזירה רשימה של dicts:
    [{'id': 1, 'status': 'PENDING', 'desc': ' ללמוד Python'}, ...]
    אם הקובץ לא קיים — מחזירה רשימה ריקה
    """
    tasks = []

    try:
        with open(filename, 'r', encoding='utf-8') as file:
            for line in file:
                line = line.strip()
                # בדיקת שורות ריקות
                if not line:
                    continue

                parts = line.split('|')

                task_id = int(parts[0].strip())
                status = parts[1].strip()
                desc = parts[2].strip()


                tasks.append({
                    'id': task_id,
                    'status': status,
                    'desc': desc
                })

    except FileNotFoundError:
        print(f"הודעה: הקובץ '{filename}' לא נמצא. ")
        return []

    return tasks

def save_tasks(filename, tasks):
    """
    שומרת את רשימת המשימות לקובץ
    פורמט כל שורה : id|status|description
    """

    with open(filename, 'w', encoding='utf-8') as file:
        for task in tasks:
            task_id = task['id']
            status = task['status']
            desc = task['desc']

            line = f"{task_id}|{status}|{desc}\n"

            file.write(line)

def add_task(filename, description):
    """
    מוסיפה משימה: חדשה עם
    - ID = מספר המשימה הבאה
    - status = 'PENDING'
    - description = הפרמטר שניתן
    """
    tasks = load_tasks(filename)
    last_task = tasks[-1]
    new_id = last_task['id'] + 1

    # נרשום את המשימה החדשה
    with open(filename, 'a', encoding='utf-8') as file:
        file.write(f'{new_id}|PENDING|{description}\n')

def complete_task(filename, task_id):
    """
    משנה את status של משימה task_id מ-PENDING ל-DONE.
    אם ה-ID לא קיים — מדפיסה הודעת שגיאה.
    """
    tasks = load_tasks(filename)

    task_found = False

    for task in tasks:
        if task['id'] == int(task_id):
            task['status'] = 'DONE'
            task_found = True  # מסמנים שמצאנו
            break

    if task_found:
        save_tasks(filename, tasks)
        print(f"משימה {task_id} סומנה כהושלמה בהצלחה!")
    else:
        print(f"שגיאה: משימה עם ID {task_id} לא קיימת במערכת.")

def list_tasks(filename):
    """
    מציגה את כל המשימות בפורמט מסודר:
    1|[✓]|description
    2|[]|description
    """
    icon_of_done = {"DONE":"[✓]","PENDING":"[]"}
    tasks = load_tasks(filename)

    print("\n=== רשימת המשימות שלך ===")

    for task in tasks:
        status_icon = icon_of_done[task['status']]
        print(f"{task['id']}|{status_icon}|{task['desc']}")

    print("=========================")

def delete_task(filename, task_id):
    tasks = load_tasks(filename)
    for task in tasks:
        if task['id'] == int(task_id):
            tasks.remove(task)
            print(f"המשימה {task_id} נמחקה בהצלחה")
            break

    with open(filename, 'w', encoding='utf-8') as file:
        for task in tasks:
            task_id = task['id']
            status = task['status']
            desc = task['desc']
            line = f"{task_id}|{status}|{desc}\n"
            file.write(line)

def filter_by_status(filename, status):
    """
    מדפיסה רשימת משימות לפי סטטוס
    """
    tasks = load_tasks(filename)

    for task in tasks:
        if task['status'] == status:
            print(f"{task['id']}|{status}|{task['desc']}")


def main():
    """
    הלולאה הראשית של מנהל המשימות (CLI)
    """
    FILENAME = "tasks.txt"

    while True:
        print('\n=== To-Do List Manager ===')
        print('1. הצג משימות')
        print('2. הוסף משימה')
        print('3. סמן כהושלם')
        print('4. מחיקת משימה')
        print('5. סינון משימות')
        print('6. יציאה')

        choice = input('בחירה:> ').strip()

        if choice == '1':
            list_tasks(FILENAME)

        elif choice == '2':
            desc = input('תיאור המשימה: ')
            if desc.strip():
                add_task(FILENAME, desc)
            else:
                print("שגיאה: לא ניתן להוסיף משימה ריקה.")

        elif choice == '3':
            try:
                task_id = int(input('מספר משימה: '))
                complete_task(FILENAME, task_id)
            except ValueError:
                print("שגיאה: נא להזין מספר משימה תקין.")
        elif choice == '4':
            try:
                task_id = int(input('מספר משימה: '))
                delete_task(FILENAME, task_id)
            except ValueError:
                print("שגיאה: נא להזין מספר משימה תקין.")
        elif choice == '5':
            task_status = input("הכנס סטטוס משימה> ").strip()
            filter_by_status(FILENAME, task_status)


        elif choice == '6':
            print('!להתראות')
            break

        else:
            print('בחירה לא תקינה')






if __name__ == '__main__':
    main()