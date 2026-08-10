from fastapi import FastAPI

app = FastAPI()

grades = {
    "1": {"name": "Moshe", "grade": 88},
    "2": {"name": "Yaakov", "grade": 75},
    "3": {"name": "David", "grade": 92}
}

@app.get("/students")
def get_all_students():
    return grades


@app.get("/students/top")
def get_top_student():
    top_student_name = None
    top_student_grade = -1

    for student in grades.values():
        if student["grade"] > top_student_grade:
            top_student_grade = student["grade"]
            top_student_name = student["name"]


    return {f"top student {top_student_name}": top_student_grade}


@app.get("/students/average")
def get_average_student():
    total_grade = 0
    for student in grades.values():
        total_grade += student["grade"]
    average_grade = total_grade / len(grades)
    return {"average class": average_grade}

@app.get("/students/count")
def get_student_count():
    return {"total_students": len(grades)}

@app.get("/students/{student_id}")
def get_single_student(student_id: str):
    if student_id in grades:
        return grades[student_id]
    return {"error": "student not found"}

