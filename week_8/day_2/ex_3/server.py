from fastapi import FastAPI

app = FastAPI()

@app.get("/greet")
def get_greet(name: str = "world"):
    return {"message": f"hello, {name}!"}