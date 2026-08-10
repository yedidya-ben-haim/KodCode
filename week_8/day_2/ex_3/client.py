import requests

url = "http://127.0.0.1:8000/greet"

response1 = requests.get(url)
if response1.status_code == 200:
    print(response1.json())
else:
    print("ERROR")


query = {"name": "yedidya"}
response2 = requests.get(url, params=query)

if response2.status_code == 200:
    print(response2.json())
else:
    print("error")