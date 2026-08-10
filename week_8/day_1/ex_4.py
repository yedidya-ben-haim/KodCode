from datetime import datetime
from fastapi import FastAPI

app = FastAPI()


@app.get("/status")
def get_system_status():
    now = datetime.now()

    return {
        "server_name": "Yedidya's-Server",
        "current_time": now
    }