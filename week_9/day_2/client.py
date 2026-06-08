import requests


url = "http://127.0.0.1:8000/soldiers/4"

# new_data = { "name": "yedidya",
#       "soldier_rank": "sergent",
#       "unit": "8200"}

response = requests.delete(url)
print(response.status_code)
print(response.text)