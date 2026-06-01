import requests


response = requests.get("https://jsonplaceholder.typicode.com/users/1")

data = response.json()

print(f"Name: {data["name"]}")
print(f"Email: {data["email"]}")
print(f"city: {data["address"]["city"]}")

response_2 = requests.get("https://jsonplaceholder.typicode.com/posts")

data_2 = response_2.json()

print(len(data_2))

response_3 = requests.get("https://jsonplaceholder.typicode.com/posts?userId=2")

data_3 = response_3.json()

for post in data_3:
    print(f"{post["title"]}")
