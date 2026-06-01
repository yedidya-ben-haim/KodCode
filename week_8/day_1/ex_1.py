from fastapi import FastAPI

app = FastAPI()

@app.get("/ping")
def ping():
    return {"status": "pong"}

@app.get("/greet/{name}")
def greet(name: str):
    return {"message": f"Hello, {name}!"}

