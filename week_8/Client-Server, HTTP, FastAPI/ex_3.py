from fastapi import FastAPI

app = FastAPI()

@app.get("/")
def read_root():
    return {"nothing"}

@app.get("/calc/{a}/{op}/{b}")
def calc(a: int, b: int, op: str):
    result = None
    if op == "div":
        if b == 0:
            return {"Cannot divide by 0"}
        result = a / b
    if op == "add":
        result = a + b
    if op == "sub":
        result = a - b
    if op == "mul":
        result = a * b
    return {"operation": {op}, "result": {result}}