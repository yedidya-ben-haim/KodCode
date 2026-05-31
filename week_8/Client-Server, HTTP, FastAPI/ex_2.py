from fastapi import FastAPI

app = FastAPI()

@app.get("/")
def read_root():
    return {"service": "my-api", "version": "1.0"}

@app.get("/users/admin")
def get_admin():
    return {"role": "admin", "access": "full"}

@app.get("/users/{user_id}")
def get_user_by_id(user_id: int):
    return {
        "user_id": user_id,
        "name": f"User_{user_id}",
        "email": f"user_{user_id}@example.com"
        }