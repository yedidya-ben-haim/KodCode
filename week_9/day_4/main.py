from fastapi import FastAPI
import reports

app = FastAPI()


@app.get("/stats/summary")
def get_summary():
    return reports.get_summary()

@app.get("/stats/units")
def get_count_by_unit():
    return reports.count_by_unit()

@app.get("/stats/understaffed")
def get_units_with_multiple_soldiers():
    return reports.get_units_with_multiple_soldiers()

@app.get("/soldiers/missing-rank")
def get_missing_data():
    return reports.get_missing_data()

@app.get("/stats/units/top")
def get_unit_with_most_soldiers():
    units_count = reports.count_by_unit()
    return units_count[0]

