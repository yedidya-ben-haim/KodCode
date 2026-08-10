import requests

response = requests.get("http://localhost:8000/greet/yedidya")

print(response.status_code)
print(response.json())