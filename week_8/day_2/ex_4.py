import requests


posts = requests.get("https://jsonplaceholder.typicode.com/posts")
post_list = posts.json()

users = requests.get("https://jsonplaceholder.typicode.com/users")
users_list = users.json()

new_dic = {}

for user in users_list:
    new_dic[user["id"]] = user["name"]

for post in post_list:
    user_id = post["userId"]
    author_name = new_dic.get(user_id)

    print(f'"{post["title"]}" by {author_name}')


