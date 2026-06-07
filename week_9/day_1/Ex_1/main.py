from fastapi import FastAPI
import db


app = FastAPI()


@app.get("/")
def home():
    return "welcome to soldiers db"

@app.post("/steps")
def steps():
    return {"status": "ok"}

@app.get("/schema")
def get_table_schema():
    columns = db.get_schema()
    return {"columns": columns}

@app.get("/soldiers")
def get_all_soldiers():
    return {"soldiers": []}
