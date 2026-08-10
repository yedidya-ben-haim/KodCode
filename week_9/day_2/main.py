import uvicorn
from fastapi import FastAPI, HTTPException
import db
from pydantic import BaseModel


app = FastAPI()


class Soldiers(BaseModel):
    name: str
    rank: str
    unit: str



@app.get("/")
def home():
    return {"welcome": ""}

@app.get("/soldiers")
def get_all_soldiers():
    """
        Return all soldiers
    """
    return {"all soldiers:": db.get_all()}


@app.get("/soldiers/{id}")
def get_by_id(id: int):
    """
        Return soldiers by ID
    """
    soldier = db.get_by_id(id)

    if not soldier:
        raise HTTPException(status_code=404, detail=f"Soldier with id {id} not found")
    return {"soldier found:" : soldier}


@app.post("/soldiers",status_code=201)
def create_soldier(data: Soldiers):
    """
        create a soldiers
    """
    new_id = db.create(data.name, data.rank, data.rank)
    return {"new soldier created with id:": new_id}


@app.put("/soldiers/{id}")
def update_soldier(id: int, new_data: dict):
    updated = db.update(id, new_data)

    if not updated:
        raise HTTPException(status_code=404, detail="Can't create the soldier")

    return {"The soldier was successfully updated.": " "}

app.delete("/soldiers/{id}")
def delete_soldier(id: int):
    deleted = db.delete(id)

    if not deleted:
        raise HTTPException(status_code=404, detail=f"cant delete soldiers {id}")
    return {"the soldiers wes deleted"}


if __name__ == "__main__":
    uvicorn.run("main:app", host="localhost", reload=True)